using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class nextBtn : MonoBehaviour
{
    public Image black;

    float time = 0f;
    float F_time = 3f;

    public void Onclick()
    {
       FadeOut();      
    }

    public void FadeOut()
    {
        StartCoroutine(FadeOutFlow());
    }

    IEnumerator FadeOutFlow()
    {
        black.gameObject.SetActive(true);
        time = 0f;
        Color alpha = black.color;

        while (alpha.a < 1f)
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(0, 1, time);
            black.color = alpha;
            yield return null;
        }
        SceneManager.LoadScene("Consult1");
        yield return null;
    }
}
