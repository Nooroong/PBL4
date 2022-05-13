using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class House_MemoButton : MonoBehaviour
{

    public GameObject Memo;
    public Button Button;
    public GameObject text1;
    public GameObject text2;
    public GameObject text3;
    public GameObject text4;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void BtnOnClick()
    {
        if (Memo.activeSelf == true)
        {
            Memo.SetActive(false);
            text1.SetActive(false);
            text2.SetActive(false);
            text3.SetActive(false);
            text4.SetActive(false);
        }
        else
        {
            Memo.SetActive(true);
            text1.SetActive(true);
            text2.SetActive(true);
            text3.SetActive(true);
            text4.SetActive(true);
        }
        

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
