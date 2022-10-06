using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ListenMusicBGCtrl : MonoBehaviour
{
    public Image[] change_Img; // 다음에 보여질 이미지 목록들, 마지막은 Black
    public string nextScene;

    float time = 0f;
    float F_time = 1.5f;
    

    private void Awake() {
        for(int i = 1; i < change_Img.Length; i++) {
            change_Img[i].gameObject.SetActive(false);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // 순서대로 다음 이미지들의 투명도를 조절한다.
        StartCoroutine(FadeOutFlow(change_Img));

    }


    IEnumerator FadeOutFlow(Image[] img)
    {
        for(int i = 0; i < change_Img.Length; i++) {
            yield return new WaitForSeconds(2.5f);

            img[i].gameObject.SetActive(true);
            time = 0f;
            Color alpha = img[i].color;

            while (alpha.a < 1f)
            {
                time += Time.deltaTime / F_time;
                alpha.a = Mathf.Lerp(0, 1, time);

                // 부모
                img[i].color = alpha;
                // 자식
                for(int j = 0; j < img[i].transform.childCount; j++) {
                    img[i].transform.GetChild(j).GetComponent<Image>().color = alpha;
                }
                
                yield return null;
            }
        }

        // 다음씬으로 이동
        SceneManager.LoadScene(nextScene);
    }
}
