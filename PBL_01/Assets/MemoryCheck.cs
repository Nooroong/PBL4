using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MemoryCheck : MonoBehaviour {
    public Image ch; //üũ �̹��� ����
    public Image mind; //��� �� �̹���

    public Image Panel;
    float time = 0f;
    float F_time = 2f;
    bool flag = true;

    private void Update() {
        if(Input.GetMouseButtonUp(0)) {
            int cnt = transform.childCount; //�ش� ������Ʈ�� �ڽ� ��

            //���� ����� 3���̹Ƿ� �ϴ� ���ǿ� 3 �̻��� ����
            if (cnt >= 3) {
                for (int i = 0; i < cnt; i++) {
                    //�̸��� bad�� ���� ���� �ڽ��� �ִٸ�
                    if (!transform.GetChild(i).name.Contains("bad")) {
                        ch.gameObject.SetActive(false); //üũ �̹��� ��Ȱ��ȭ
                        return; //�˻� ���� ������
                    }
                }
                ch.gameObject.SetActive(true); //�ڽ��� ��� bad memory��� ���.(�̹��� Ȱ��ȭ)
                //��� ��ġ ��Ȱ��ȭ
                for (int i = 0; i < transform.childCount; i++)
                    transform.GetChild(i).GetComponent<MemoryMovement>().enabled = false;
                for (int i = 0; i < mind.transform.childCount; i++) 
                    mind.transform.GetChild(i).GetComponent<MemoryMovement>().enabled = false;

                //���̵� �ƿ� �� ��ġ�� ȭ���� ���ڰŸ��� ������ ����
                //ȭ���� �ƹ��� ��ġ�ص� F_Out()�� ���� 1ȸ�� �����ϵ��� �Ѵ�.
                if (flag) {
                    Invoke("F_Out", 1f);
                    flag = !flag;
                }
            } else { //����� 2�� ������ ���
                ch.gameObject.SetActive(false);
            }
        }
        
    }


    public void F_Out()
    {
        StartCoroutine(FadeOutFlow());
    }

    IEnumerator FadeOutFlow()
    {
        Panel.gameObject.SetActive(true);
        time = 0f;
        Color alpha = Panel.color;

        while (alpha.a < 1f)
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(0, 1, time);
            Panel.color = alpha;
            yield return null;
        }
        yield return null;
        NextScene();
    }
    void NextScene()
    {
        SceneManager.LoadScene("Medicine");
    }


    public void Start()
    {
        Panel.gameObject.SetActive(false);
    }
}
