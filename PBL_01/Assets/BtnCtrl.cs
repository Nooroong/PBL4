using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnCtrl : MonoBehaviour
{
    private Button btn;

    public void Start() {
        //아래 따옴표 안에 해당되는 버튼 오브젝트의 이름을 적는다.
        btn = GameObject.Find("Button").GetComponent<Button>();
        btn.interactable = false; //버튼 상호작용 비활성화
    }

    public void BtnState() {
        //!아래 조건 변경!
        if (true) { //모든 항목을 체크한 경우
            btn.interactable = true; //버튼 상호작용 활성화
        } else { //항목이 모두 체크되지 않은 경우
            btn.interactable = false; //버튼 상호작용 비활성화
        }
    }
}
