using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MemoryCheck : MonoBehaviour {
    public Image ch; //체크 이미지 변수

    private void Update() {
        if(Input.GetMouseButtonUp(0)) {
            int cnt = transform.childCount; //해당 오브젝트의 자식 수

            //나쁜 기억이 3개이므로 일단 조건에 3 이상을 넣음
            if (cnt >= 3) {
                for (int i = 0; i < cnt; i++) {
                    //이름에 bad가 들어가지 않은 자식이 있다면
                    if (!transform.GetChild(i).name.Contains("bad")) {
                        ch.gameObject.SetActive(false); //체크 이미지 비활성화
                        return; //검사 과정 나가리
                    }
                }
                ch.gameObject.SetActive(true); //자식이 모두 bad memory라면 통과.(이미지 활성화)
            } else { //기억이 2개 이하인 경우
                ch.gameObject.SetActive(false);
            }
        }
        
    }
}
