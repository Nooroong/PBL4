/*
 https://m.blog.naver.com/PostView.naver?isHttpsRedirect=true&blogId=2983934&logNo=220987664525
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour {
    public Text label; //정답 입력 칸
    public Text timeText; //타이머 텍스트
    public Text alertText; //알림창
    private float time = 10f; //제한시간


    private void Start() {
        alertText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update() {
        //시간이 남았거나 정답을 입력하지 않은 경우, 프레임마다 시간을 감소
        //if (time > 0f && (label.GetComponent<Text>().text != "119"))

        //시간 감소
        time -= Time.deltaTime;
        timeText.text = time.ToString();
        timeText.text = string.Format("{0:N2}", time);
        
        //시간이 음수로 나오는 경우를 방지
        //if (time <= 0) timeText.text = "0.00";
    }
    

    //전화 버튼 클릭 시
    public void OnClicked() {
        if (label.GetComponent<Text>().text != "119") { //입력된 전화번호가 119가 아닐 시
            //잘못된 번호라는 알림창 띄우기
            StartCoroutine(FadeText());
        }
        else { //올바른 전화번호를 입력
            //숫자 버튼들
            GameObject BtnsGrid = GameObject.Find("NumGrid"); //요것의 자식들을 전부 비활성화
            for (int i = 0; i < BtnsGrid.transform.childCount; i++) {
                var btn = BtnsGrid.transform.GetChild(i);
                btn.GetComponent<Button>().interactable = false;
            }

            //지우기 버튼도 비활성화
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
