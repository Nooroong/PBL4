using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PuzzleClearSensing : MonoBehaviour
{
    public Image Goal;
    public Image Panel;
    public GameObject hBlockParent;
    public GameObject vBlockParent;
    public string nextScene;
    public LayerMask puzzleLayer;

    private float time = 0f;
    private float F_time = 1.5f;

    private int gameEnd = 0;
    private RaycastHit2D hit;
    private float rayDistance = 10f;
    private Vector2 rayVec = Vector2.zero;


    // Start is called before the first frame update
    void Start()
    {
        gameEnd = 0;

        rayVec.x = this.transform.position.x;
        rayVec.y = Goal.transform.position.y;

        // 블록 이동 활성화
        for(int i = 0; i < hBlockParent.transform.childCount; i++) {
            hBlockParent.transform.GetChild(i).GetComponent<HorizontalMoving>().enabled = true;
        }
        for(int i = 0; i < vBlockParent.transform.childCount; i++) {
            vBlockParent.transform.GetChild(i).GetComponent<VerticalMoving>().enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // ray 그리기
        // Debug.DrawRay(rayVec, transform.right * rayDistance, Color.red);

        // 드래그가 끝나면
        if(Input.GetMouseButtonUp(0)) {
            // 레이어가 puzzleBlock인 오브젝트가 ray에 감지되지 않은 경우 == 길이 뚫린 경우
            if (!Physics2D.Raycast(rayVec, transform.right, rayDistance, puzzleLayer)) {
                gameEnd++;

                // 블록 이동 정지
                for(int i = 0; i < hBlockParent.transform.childCount; i++) {
                    hBlockParent.transform.GetChild(i).GetComponent<HorizontalMoving>().enabled = false;
                }
                for(int i = 0; i < vBlockParent.transform.childCount; i++) {
                    vBlockParent.transform.GetChild(i).GetComponent<VerticalMoving>().enabled = false;
                }


                // 오브젝트 오른쪽으로 이동 + 페이드 아웃 + 다음 씬으로 전환
                if (gameEnd == 1)
                    StartCoroutine(MoveRight_and_FadeOutFlow());
            }
        }
    }


    IEnumerator MoveRight_and_FadeOutFlow() {
        float humanX = 0;
        float humanY = this.GetComponent<RectTransform>().anchoredPosition.y;
        
        time = 0f;

        // 3초 동안 목표지점으로 이동
        while (this.GetComponent<RectTransform>().anchoredPosition.x < 700)
        {
            time += Time.deltaTime / 2.0f;
            humanX = Mathf.Lerp(-700, 800, time);
            this.GetComponent<RectTransform>().anchoredPosition = new Vector2(humanX, humanY);
            yield return null;
        }


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
        PlayerPrefs.SetInt("routine", 1);// 하루 일과 끝
        SceneManager.LoadScene(nextScene);
    }

}
