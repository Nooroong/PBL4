using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Next_btn : MonoBehaviour
{
    public string nextScene;

    public GameObject components;
    public Button next;
   
    public GameObject circuit;
    public Button hint_btn;
    public Image complete;

    int next_cnt = 0;

    float time = 0f;
    float F_time = 2f;

    public void Onclick()
    {
        StartCoroutine(UntilPlayback(this.GetComponent<Button>()));

        next_cnt++;

        if (next_cnt < 2)
        {
            //버튼이 연속으로 눌려 완성된 신호기의 모습이 뜨기 전에 넘어가는 것을 막기 위해
            //버튼을 비활성화 한 뒤 1초뒤 활성화 시킴
            next.interactable = false;
            Invoke("ActiveBtn", 1f);

            circuit.gameObject.SetActive(false);
            components.gameObject.SetActive(false);
            hint_btn.gameObject.SetActive(false);

            Invoke("FadeIn", 1f);
        }
        else
        {
            SceneManager.LoadScene(nextScene);
        }
    }
    private void ActiveBtn()
    {
        next.interactable = true;
    }

    public void FadeIn()
    {
        StartCoroutine(FadeInFlow());
    }

    IEnumerator FadeInFlow()
    {
        complete.gameObject.SetActive(true);
        time = 0f;
        Color alpha = complete.color;

        while (alpha.a < 1f)
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(0, 1, time);
            complete.color = alpha;
            yield return null;
        }
        yield return null;
    }

        
    IEnumerator UntilPlayback(Button obj)
    {
        obj.GetComponent<AudioSource>().Play();
        yield return new WaitUntil(() => !obj.GetComponent<AudioSource>().isPlaying);
    }
}
