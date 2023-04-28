using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Memo_dontdestroy : MonoBehaviour
{
    public GameObject Memo_ctrl;
    public TextMeshProUGUI text0, text1, text2, text3, text4, text5;
    // text0: 쪽지 답장 (PlayerPrefs 키 이름 NoteCp)
    // text1: 밥먹기    (PlayerPrefs 키 이름 bap)
    // text2: 약먹기    (PlayerPrefs 키 이름 pill)
    // text3: 화분 가꾸기 (PlayerPrefs 키 이름 planter)
    // text4: 랜덤1     (PlayerPrefs 키 이름 random1)
    // text5: 랜덤2     (PlayerPrefs 키 이름 random2)

    void Awake()
    {
        var obj = FindObjectsOfType<Memo_dontdestroy>();

        if (obj.Length == 1)
        {
            DontDestroyOnLoad(Memo_ctrl);
        }
        else
        {
            Destroy(Memo_ctrl);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        switch (PlayerPrefs.GetInt("task_index", -1))
        {
            case 0:
                text4.text = "산책하기";
                text5.text = "차 마시기";
                break;
            case 1:
                text4.text = "명상하기";
                text5.text = "차 마시기";
                break;
            case 2:
                text4.text = "명상하기";
                text5.text = "산책하기";
                break;
            default:
                text4.text = "default";
                text5.text = "default";
                break;
        }

        //다른 공간에 있다가 House씬으로 돌아왔을 때 or 이어서하기 House 씬에서 시작할 때 할 일이 True 라면 취소선
        if ((bool)Day_manager.GetBool("NoteCp")) // 쪽지 답장쓰기
        {
            text0.text = "<s>" + text0.text + "</s>";
        }
        if ((bool)Day_manager.GetBool("bap")) //밥 먹기
        {
            text1.text = "<s>" + text1.text + "</s>";
        }
        if ((bool)Day_manager.GetBool("pill")) //약 먹기
        {
            text2.text = "<s>" + text2.text + "</s>";
        }
        if ((bool)Day_manager.GetBool("planter")) //화분 가꾸기
        {
            text3.text = "<s>" + text3.text + "</s>";
        }
        if ((bool)Day_manager.GetBool("random1")) //랜덤 할 일1
        {
            text4.text = "<s>" + text4.text + "</s>";
        }
        if ((bool)Day_manager.GetBool("random2")) //랜덤 할 일2
        {
            text5.text = "<s>" + text5.text + "</s>";
        }
    }

    // Update is called once per frame
    void Update() 
    {   /* 모든 일이 끝나고 잠자기 했을 때 실행 */
        if (!PlayerPrefs.HasKey("NoteCp") && !PlayerPrefs.HasKey("bap") && !PlayerPrefs.HasKey("pill") && 
            !PlayerPrefs.HasKey("planter") && !PlayerPrefs.HasKey("random1") && !PlayerPrefs.HasKey("random2"))
        {
            Destroy(Memo_ctrl);
        }
    }

    /* 할 일이 수행시 취소선 긋는 함수 */
    public void Reply() //쪽지 답장
    {
        text0.text = "<s>" + text0.text + "</s>";
        PlayerPrefs.SetInt("NoteCp", 1);
    }
    public void Eating() //밥먹기
    {
        text1.text = "<s>" + text1.text + "</s>";
        PlayerPrefs.SetInt("bap", 1);
    }
    public void Take_A_Pill() //약먹기
    {
        text2.text = "<s>" + text2.text + "</s>";
        PlayerPrefs.SetInt("pill", 1);
    }
    public void Planter() //화분 가꾸기
    {
        text3.text = "<s>" + text3.text + "</s>";
        PlayerPrefs.SetInt("planter", 1);
    }
    public void Walking() //산책
    {
        if (text4.text.Contains("산책")) //random1인지 random2인지 확인하기 위한 조건문
        {
            text4.text = "<s>" + text4.text + "</s>";
            PlayerPrefs.SetInt("random1", 1);
        }

        else
        {
            text5.text = "<s>" + text5.text + "</s>";
            PlayerPrefs.SetInt("random2", 1);
        }
    }
    public void Meditation() //명상
    {
        if (text4.text.Contains("명상")) //random1인지 random2인지 확인하기 위한 조건문
        {
            text4.text = "<s>" + text4.text + "</s>";
            PlayerPrefs.SetInt("random1", 1);
        }

        else
        {
            text5.text = "<s>" + text5.text + "</s>";
            PlayerPrefs.SetInt("random2", 1);
        }
    }
    public void Tea() //차마시기
    {
        if (text4.text.Contains("차")) //random1인지 random2인지 확인하기 위한 조건문
        {
            text4.text = "<s>" + text4.text + "</s>";
            PlayerPrefs.SetInt("random1", 1);
        }

        else
        {
            text5.text = "<s>" + text5.text + "</s>";
            PlayerPrefs.SetInt("random2", 1);
        }
    }
}
