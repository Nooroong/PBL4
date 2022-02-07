/*
 https://m.blog.naver.com/PostView.naver?isHttpsRedirect=true&blogId=2983934&logNo=220987664525
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour {
    public Text label; //���� �Է� ĭ
    public Text timeText; //Ÿ�̸� �ؽ�Ʈ
    public Text alertText; //�˸�â
    private float time = 10f; //���ѽð�


    private void Start() {
        alertText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update() {
        //�ð��� ���Ұų� ������ �Է����� ���� ���, �����Ӹ��� �ð��� ����
        //if (time > 0f && (label.GetComponent<Text>().text != "119"))

        //�ð� ����
        time -= Time.deltaTime;
        timeText.text = time.ToString();
        timeText.text = string.Format("{0:N2}", time);
        
        //�ð��� ������ ������ ��츦 ����
        //if (time <= 0) timeText.text = "0.00";
    }
    

    //��ȭ ��ư Ŭ�� ��
    public void OnClicked() {
        if (label.GetComponent<Text>().text != "119") { //�Էµ� ��ȭ��ȣ�� 119�� �ƴ� ��
            //�߸��� ��ȣ��� �˸�â ����
            StartCoroutine(FadeText());
        }
        else { //�ùٸ� ��ȭ��ȣ�� �Է�
            //���� ��ư��
            GameObject BtnsGrid = GameObject.Find("NumGrid"); //����� �ڽĵ��� ���� ��Ȱ��ȭ
            for (int i = 0; i < BtnsGrid.transform.childCount; i++) {
                var btn = BtnsGrid.transform.GetChild(i);
                btn.GetComponent<Button>().interactable = false;
            }

            //����� ��ư�� ��Ȱ��ȭ
            GameObject.Find("backspace").GetComponent<Button>().interactable = false;
        }
    }


    public IEnumerator FadeText() {
        alertText.gameObject.SetActive(true);
        alertText.color = new Color(alertText.color.r, alertText.color.g, alertText.color.b, 0);
        while (alertText.color.a < 1.0f) {
            alertText.color = new Color(alertText.color.r, alertText.color.g, alertText.color.b, alertText.color.a + (Time.deltaTime / 0.6f));

            yield return null;
        }
        StartCoroutine(FadeTextToZero());
    }

    public IEnumerator FadeTextToZero() {
        alertText.color = new Color(alertText.color.r, alertText.color.g, alertText.color.b, 1);
        while (alertText.color.a > 0.0f) {
            alertText.color = new Color(alertText.color.r, alertText.color.g, alertText.color.b, alertText.color.a - (Time.deltaTime / 0.6f));
            yield return null;
        }
        alertText.gameObject.SetActive(false);
    }

}
