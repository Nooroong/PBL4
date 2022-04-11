using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MemoryCheck : MonoBehaviour {
    public Image ch; //체크 이미지 변수
    public Image mind; //기억 속 이미지

    public Image Panel;
    float time = 0f;
    float F_time = 2f;
    bool flag = true;

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
                //기억 터치 비활성화
                for (int i = 0; i < transform.childCount; i++)
                    transform.GetChild(i).GetComponent<MemoryMovement>().enabled = false;
                for (int i = 0; i < mind.transform.childCount; i++) 
                    mind.transform.GetChild(i).GetComponent<MemoryMovement>().enabled = false;

                //페이드 아웃 중 터치시 화면이 깜박거리는 현상을 방지
                //화면을 아무리 터치해도 F_Out()이 최초 1회만 동작하도록 한다.
                if (flag) {
                    Invoke("F_Out", 1f);
                    flag = !flag;
                }
            } else { //기억이 2개 이하인 경우
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
