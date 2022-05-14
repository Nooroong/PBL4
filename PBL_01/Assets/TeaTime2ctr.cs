using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TeaTime2ctr : MonoBehaviour
{
    public Button home;
    public GameObject Bar;

    GameObject Memo_ctrl;

    // Start is called before the first frame update
    void Start()
    {
        home.interactable = false;

        //메모 가져오기
        Memo_ctrl = GameObject.Find("Memo_ctrl");
    }

    // Update is called once per frame
    void Update()
    {
        if(Bar.GetComponent<Image>().fillAmount == 1)
        {
            home.interactable = true;
        }
    }

    public void LoadHome()
    {
        Complete();
        SceneManager.LoadScene("House");
    }
    public void Complete()
    {
        Memo_ctrl.gameObject.GetComponent<Memo_dontdestroy>().Random();
    }
}
