using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day_manager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //초기화 되어서 다음날이 되었을 때 & 처음 시작할 때
        if( !PlayerPrefs.HasKey("bap") && !PlayerPrefs.HasKey("pill") && !PlayerPrefs.HasKey("planter")
            && !PlayerPrefs.HasKey("random1") && !PlayerPrefs.HasKey("random2") && !PlayerPrefs.HasKey("sleep"))
        {
            PlayerPrefs.SetInt("bap", 0);
            PlayerPrefs.SetInt("pill", 0);
            PlayerPrefs.SetInt("planter", 0);
            PlayerPrefs.SetInt("random1", 0);
            PlayerPrefs.SetInt("random2", 0);
            PlayerPrefs.SetInt("sleep", 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //모두 진행되었을 때 초기화
        if ((bool)GetBool("bap") && (bool)GetBool("pill") && (bool)GetBool("planter")
            && (bool)GetBool("random1") && (bool)GetBool("random2") && (bool)GetBool("sleep"))
        {
            PlayerPrefs.DeleteKey("bap");
            PlayerPrefs.DeleteKey("pill");
            PlayerPrefs.DeleteKey("planter");
            PlayerPrefs.DeleteKey("random1");
            PlayerPrefs.DeleteKey("random2");
            PlayerPrefs.DeleteKey("sleep");
        }
    }
    // int 값이 1이면 true, 2이면 false
    public static bool? GetBool(string key)
    {
        int tmp = PlayerPrefs.GetInt(key);
        if (tmp == 1)
            return true;
        else if (tmp == 0)
            return false;
        else
            return null;
    }
}
