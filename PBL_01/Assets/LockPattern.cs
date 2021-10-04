/*
 ���� ��ũ:
https://www.youtube.com/watch?v=wkypEC294K8 (���� ���� ����)
https://pastebin.com/xRdFU8Pm (�ҽ��ڵ�)
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class LockPattern : MonoBehaviour {
    public GameObject linePrefab;
    public Canvas canvas; //������ ĵ������ �ڽ����� ������
    public List<CircleIdentifier> lines = new List<CircleIdentifier>(); //CircleIdentifier: �� ������ ��� circle�κ��� �����ƴ��� �� �� ����.
    public List<int> pattern = new List<int>();

    GameObject lineOnEdit; //���� �������� ������ ������ ��� ����
    RectTransform lineOnEditRcTs;
    CircleIdentifier circleOnEdit; //������ ������ ������ ���� ����
    Dictionary<int, CircleIdentifier> circles = new Dictionary<int, CircleIdentifier>();

    bool unLocking; //������� ���¸� �����ϴ� ����
    bool enabled = true;
    // Start is called before the first frame update
    void Start() {
        for (int i = 0; i < transform.childCount; i++) {
            var circle = transform.GetChild(i);
            var identifier = circle.GetComponent<CircleIdentifier>();
            identifier.id = i;
            circles.Add(i, identifier);
        }

        CreatePattern(pattern);
    }

    // Update is called once per frame
    void Update() {
        if (!enabled) {
            return;
        }

        //�׻� ���� �������� ������ ������ ���콺�� ����ٴѴ�. ���� Update()���� ó��.
        if (unLocking) {
            Vector3 mousePos = canvas.transform.InverseTransformPoint(Input.mousePosition);
            lineOnEditRcTs.sizeDelta = new Vector2(lineOnEditRcTs.sizeDelta.x, Vector3.Distance(mousePos, circleOnEdit.transform.localPosition));
            lineOnEditRcTs.rotation = Quaternion.FromToRotation(Vector3.up, (mousePos - circleOnEdit.transform.localPosition).normalized);
        }
    }

    IEnumerator Release() {
        enabled = false;

        yield return new WaitForSeconds(3);

        foreach (var circle in circles) {
            circle.Value.GetComponent<Image>().DOColor(Color.white, .25F);
            circle.Value.GetComponent<RectTransform>().DOScale(1f, .5f).SetEase(Ease.OutBounce);
        }

        foreach (var line in lines) {
            Destroy(line.gameObject);
        }

        lines.Clear();
        lineOnEdit = null;
        lineOnEditRcTs = null;
        circleOnEdit = null;

        enabled = true;
    }

    GameObject CreateLine(Vector3 pos, int id) {
        //������ �θ� ������Ʈ ��ǥ�� (0, 0, 0)���� Ȯ��. �ƴϸ� ���� �̻��ϰ� �׷��� �� ����.
        var line = GameObject.Instantiate(linePrefab, canvas.transform); //���������� ����
        line.transform.localPosition = pos; //������ ���� ��ġ�� Ŭ���� ���� ����
        var linedf = line.AddComponent<CircleIdentifier>();
        linedf.id = id; //������ id == ������ ������ ���� id
        lines.Add(linedf);
        return line;
    }
    void TrySetLineEdit(CircleIdentifier circle) {
        //Ŭ���� ������ �̹� ������ ������ �ִ��� �˻�.
        foreach (var line in lines) {
            if (line.id == circle.id) { //�ش� ���� �̹� ������ �����ƴٸ�
                return; //������ ���� �������� ����.
            }
        }

        lineOnEdit = CreateLine(circle.transform.localPosition, circle.id);
        lineOnEditRcTs = lineOnEdit.GetComponent<RectTransform>();
        circleOnEdit = circle;
    }

    bool IsCorrect(List<CircleIdentifier> a, List<int> b) {
        if (a.Count != b.Count) return false;

        for (int i = b.Count - 1; i >= 0; i--) {
            if (a[i].id != b[i]) return false;
        }
        return true;
    }

    void CreatePattern(List<int> ptn) {
        int cnt = this.transform.childCount;
        for(int i = 0; i < cnt; i++) {
            ptn.Add(i);
        }
    }

    public void OnMouseEnterCircle(CircleIdentifier idf) {
        if (!enabled) {
            return;
        }
        if (unLocking) {
            lineOnEditRcTs.sizeDelta = new Vector2(lineOnEditRcTs.sizeDelta.x, Vector3.Distance(circleOnEdit.transform.localPosition, idf.transform.localPosition));
            lineOnEditRcTs.rotation = Quaternion.FromToRotation(Vector3.up, (idf.transform.localPosition - circleOnEdit.transform.localPosition).normalized);
            TrySetLineEdit(idf);
            circles[idf.id].GetComponent<RectTransform>().DOScale(1.2f, .5f).SetEase(Ease.OutBounce);
        }
    }
    public void OnMouseExitCircle(CircleIdentifier idf) {
        if (!enabled) {
            return;
        }
        StartCoroutine(OnMouseExitCircle(idf.id));
    }

    IEnumerator OnMouseExitCircle(int _idf) {
        yield return new WaitForSeconds(.5f);
        circles[_idf].GetComponent<RectTransform>().DOScale(1f, .5f).SetEase(Ease.OutBounce);
    }

    public void OnMouseDownCircle(CircleIdentifier idf) {
        if (!enabled) {
            return;
        }
        unLocking = true;
        TrySetLineEdit(idf);
    }
    public void OnMouseUpCircle(CircleIdentifier idf) {
        if (!enabled) {
            return;
        }
        if (unLocking) {
            //���� ��ġ
            if (IsCorrect(lines, pattern)) {
                foreach (var item in lines) {
                    circles[item.id].GetComponent<Image>().DOColor(Color.green, .25F);
                }

                Destroy(lines[lines.Count - 1].gameObject);
                lines.RemoveAt(lines.Count - 1);

                foreach (var item in lines) {
                    item.GetComponent<Image>().DOColor(Color.green, .25F);
                }
            } else {
                //���� ����ġ
                foreach (var item in lines) {
                    circles[item.id].GetComponent<Image>().DOColor(Color.red, .25F);
                }

                Destroy(lines[lines.Count - 1].gameObject);
                lines.RemoveAt(lines.Count - 1);

                foreach (var item in lines) {
                    item.GetComponent<Image>().DOColor(Color.red, .25F);
                }

                StartCoroutine(Release());
            }


        }
        unLocking = false;
    }
}