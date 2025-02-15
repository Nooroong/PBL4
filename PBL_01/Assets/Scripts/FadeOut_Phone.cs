using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeOut_Phone : MonoBehaviour
{
    public Image Panel;
    public Button Back;


    float time = 0f;
    float F_time = 2f;

    public void F_Out()
    {
        if (Back.interactable == false)
        {
            StartCoroutine(FadeOutFlow());
        }
        
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
        SceneManager.LoadScene("Ambulance");
    }



    public void Start()
    {
        F_Out();
    }
}
