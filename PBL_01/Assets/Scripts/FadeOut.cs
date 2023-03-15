using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeOut : MonoBehaviour
{
    public Image Panel;
    public Image new_start_alert;
    public Button new_start_btn;
    public Button continue_btn;

    float time = 0f;
    float F_time = 2f;

    private string LastScene = ""; //마지막씬의 이름을 저장하여 비교하는 변수

    private void Awake() {
        new_start_alert.gameObject.SetActive(false);
    }

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
        if(PlayerPrefs.GetString("Last_scene") != "") { // 이어하기 데이터가 있으면
            new_start_alert.gameObject.SetActive(true);
            new_start_btn.GetComponent<AudioSource>().Play();
        }
        else {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.SetInt("out", 1);
            PlayerPrefs.SetInt("day", 0);
            StartCoroutine(UntilPlayback(new_start_btn, "Prologue_Hospital"));
        }
        
    }

    public void Click_Continue_Btn() {
       
        /*
        강종 할 땐 씬을 저장을 안하기 때문에 게임을 이어서 할 때 
        강종된 장면을 Last_scene으로 수정하여 강종 장면부터 이어서 플레이 한다.
          
        방법: Last_scene과 브금에 사용되는 Playerprefs 값을 비교하여 알맞지 않은 경우 Last_scene을 수정한다.
        
        단, 차 마시기 장면은 예외로 Tea의 값을 0으로 수정한다. */


        LastScene += PlayerPrefs.GetString("Last_scene");

        
        if (PlayerPrefs.GetInt("Bully", -1) == 1 & (LastScene != "Day4_Bully" | LastScene != "Day4_flashback" | LastScene != "Day4_flashback2"))
        {
            //Bully 값이 1이지만 저장이 안되었을 경우 Last_scene 값을 Day4_Bully로 수정
            PlayerPrefs.SetString("Last_scene", "Day4_Bully");
        }
        else if (PlayerPrefs.GetInt("Guitar", -1) == 1 & (LastScene != "FollowMusic" | LastScene != "ListenMusic"))
        {
            //Guitar 값이 1이지만 저장이 안되었을 경우 Last_scene 값을 FollowMusic으로 수정
            PlayerPrefs.SetString("Last_scene", "FollowMusic");
        }
        else if (PlayerPrefs.GetInt("BuskingEnd", -1) == 1 & (LastScene != "TalkToBusker"))
        {
            //BuskingEnd 값이 1이지만 저장이 안되었을 경우 Last_scene 값을 TalkToBusker로 수정
            PlayerPrefs.SetString("Last_scene", "TalkToBusker");
        }
        else if (PlayerPrefs.GetInt("Tea", -1) == 1)
        {
            //Tea 값이 1이지만 저장이 안되었을 경우 Tea 값을 0으로 수정

            PlayerPrefs.SetInt("Tea", 0);
        }
        else if (PlayerPrefs.GetInt("Rain", -1) == 1 & (LastScene != "FootPrint" | LastScene != "Day1_Meetitng"))
        {
            //Rain 값이 1이지만 저장이 안되었을 경우 Last_scene 값을 FootPrint로 수정
            PlayerPrefs.SetString("Last_scene", "FootPrint");
        }

        StartCoroutine(UntilPlayback(continue_btn, PlayerPrefs.GetString("Last_scene")));
    }

    public void Click_new_start_yes() {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("out", 1);
        PlayerPrefs.SetInt("day", 0);
        StartCoroutine(UntilPlayback(new_start_btn, "Prologue_Hospital"));
    }

    public void Click_new_start_no() {        
        StartCoroutine(Click_new_start_no(new_start_alert.transform.Find("No_Button").GetComponent<Button>()));
    }
    
    IEnumerator UntilPlayback(Button obj, string scene_name)
    {
        obj.GetComponent<AudioSource>().Play();
        yield return new WaitUntil(() => !obj.GetComponent<AudioSource>().isPlaying);
        F_Out(scene_name);
    }

    IEnumerator Click_new_start_no(Button obj) {
        obj.GetComponent<AudioSource>().Play();
        yield return new WaitUntil(() => !obj.GetComponent<AudioSource>().isPlaying);
        new_start_alert.gameObject.SetActive(false);
    }

}
