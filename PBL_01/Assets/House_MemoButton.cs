using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class House_MemoButton : MonoBehaviour
{

    public GameObject Memo;
    public Button Button;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void BtnOnClick()
    {
        if (Memo.activeSelf == true)
        {
            Memo.SetActive(false);
        }
        else
        {
            Memo.SetActive(true);
        }
        

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
