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
    private float time = 10f; //제한시간


    // Update is called once per frame
    void Update() {
        //시간이 남았거나 정답을 입력하지 않은 경우, 프레임마다 시간을 감소
        if (time > 0f && (label.GetComponent<Text>().text != "119")) {
            time -= Time.deltaTime;
            timeText.text = time.ToString();
            timeText.text = string.Format("{0:N2}", time);
        } else {
            //시간이 다 되거나 정답을 입력한 경우, 버튼들을 비활성화

            //시간이 음수로 나오는 경우를 방지
            if (time <= 0) timeText.text = "0.00";

            //숫자 버튼들
            GameObject BtnsGrid = GameObject.Find("BtnsGrid"); //요것의 자식들을 전부 비활성화
            for (int i = 0; i < BtnsGrid.transform.childCount; i++) {
                var btn = BtnsGrid.transform.GetChild(i);
                btn.GetComponent<Button>().interactable = false;
            }
            //지우기 버튼
            GameObject.Find("backspace").GetComponent<Button>().interactable = false;
        }
    }
}
