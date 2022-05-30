using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeOut : MonoBehaviour
{
    public Image Panel;

    float time = 0f;
    float F_time = 2f;

    public void F_Out(string scene_name)
    {
        StartCoroutine(FadeOutFlow(scene_name));
    }

    IEnumerator FadeOutFlow(string scene_name)
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
        SceneManager.LoadScene(scene_name);
    }

    public  void Click_Start_Btn() {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("out", 1);
        PlayerPrefs.SetInt("day", 0);
        F_Out("Prologue_Hospital");
    }

    public void Click_Continue_Btn() {
        F_Out(PlayerPrefs.GetString("Last_scene"));
    }

}
