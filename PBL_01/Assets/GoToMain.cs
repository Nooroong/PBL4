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

        if (PlayerPrefs.GetInt("out", -1) == 1) {
            PlayerPrefs.SetString("Last_scene", scene_name);
            Debug.Log(scene_name);
        } else {
            PlayerPrefs.SetString("Last_scene", "House");
        }

        Config_Box.SetActive(false);
        SceneManager.LoadScene("SampleScene");
    }
}
