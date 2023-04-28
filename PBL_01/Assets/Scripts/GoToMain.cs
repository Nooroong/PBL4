using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GoToMain : MonoBehaviour
{
    public Button Button; //Config_Btn
    public GameObject Config_Box;

    private string scene_name;
    private List<string> igr_scene = new List<string>(); // 여기서 나가도 저장하면 안되는 씬

    // Start is called before the first frame update
    private void Awake()
    {
        var obj = FindObjectsOfType<GoToMain>();

        if (obj.Length == 1) {
            DontDestroyOnLoad(gameObject);
            //DontDestory_Child(gameObject); 
        } else {
            Destroy(gameObject);
        }

        igr_scene.Add("main");
        igr_scene.Add("Ending_Credit");
    }

    private void Start() {
        Config_Box.SetActive(false);
    }

    //자식들도 모두 DontDestroyOnLoad를 적용
    private void DontDestory_Child(GameObject obj) {
        for (int i = 0; i < obj.transform.childCount; i++)
            DontDestory_Child(obj.transform.GetChild(i).gameObject);
        DontDestroyOnLoad(obj);
    }

    public void BtnOnClick() {
        Config_Box.SetActive(!Config_Box.activeSelf);
    }

    public void GoToMain_Btn_Click() {
        scene_name = SceneManager.GetActiveScene().name;

        if (!igr_scene.Contains(scene_name)) { 
            if (PlayerPrefs.GetInt("out", -1) == 1) {
                PlayerPrefs.SetString("Last_scene", scene_name);
            } 
            else if (PlayerPrefs.GetInt("day", -1) == 6)
            {
                /*day6일 때 씬을 저장하기 위한 조건문
                  day6의 브금은 main과 House에서 재생되는 음악과 동일하기(out==0) 때문에 
                  out==0인 상황에서 Last_scene이 House로 저장되지 않기 위한 조건문이다.*/

                PlayerPrefs.SetString("Last_scene", scene_name);
            }
            else {
                if (PlayerPrefs.GetInt("Tea") == 1)
                    PlayerPrefs.SetInt("Tea", 0);
                PlayerPrefs.SetString("Last_scene", "House");
            }
        }
        else if(scene_name == "Ending_Credit" & PlayerPrefs.GetInt("day", -1) == 6) 
        {
            //메인 화면에서 크레딧 버튼을 누른 경우가 아닌,
            //day6가 끝난 후 재생되는 엔딩 크레딧 장면에서의 Last_scene 저장 조건문
            
            PlayerPrefs.SetString("Last_scene", "House");
        }

        // Debug.Log(PlayerPrefs.GetString("Last_scene"));
        
        StartCoroutine(UntilPlayback(Button));
    }

    IEnumerator UntilPlayback(Button obj)
    {
        obj.GetComponent<AudioSource>().Play();
        yield return new WaitUntil(() => !obj.GetComponent<AudioSource>().isPlaying);
        Config_Box.SetActive(false);
        SceneManager.LoadScene("LoadingScene");
    }
}
