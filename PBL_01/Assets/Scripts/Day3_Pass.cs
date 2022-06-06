using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Day3_Pass : MonoBehaviour
{
    public Image Panel;
    public Image Panel2;
    public Button Button;
    float time = 0f;
    float F_time = 1f;

    public void F_In()
    {
        
        StartCoroutine(FadeInFlow());
    }

    IEnumerator FadeInFlow()
    {
        Button.GetComponent<AudioSource>().Play();
        yield return new WaitUntil(() => !Button.GetComponent<AudioSource>().isPlaying);
        
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
        Button.gameObject.SetActive(false);

        Invoke("F_Out", 1f);


    }

    public void F_Out()
    {
        StartCoroutine(FadeOutFlow1());
    }

    IEnumerator FadeOutFlow1()
    {
        time = 0f;
        Color alpha = Panel.color;

        while (alpha.a > 0f)
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(1, 0, time);
            Panel.color = alpha;
            yield return null;
        }
        Invoke("F_Out2", 1f);

    }

    public void F_Out2()
    {
        StartCoroutine(FadeOutFlow2());
    }

    IEnumerator FadeOutFlow2()
    {
        Panel2.gameObject.SetActive(true);
        time = 0f;
        Color alpha = Panel2.color;

        while (alpha.a < 1f)
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(0, 1, time);
            Panel2.color = alpha;
            yield return null;
        }
        yield return null;
        SceneManager.LoadScene("Day3_End");
    }

    public void Start()
    {
        Panel2.gameObject.SetActive(false);

    }

}
