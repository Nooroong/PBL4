using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Note1_Btn : MonoBehaviour
{
    public GameObject Note1, Note2;
    public Text ps;
    public Button btn1, btn2, btn3;
    public Button next;
    public Text b1text, b2text, b3text;

    // Start is called before the first frame update
    void Start()
    {
        next.interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Btn1()
    {
        ps.text = b1text.text;
        next.interactable = true;
    }
    public void Btn2()
    {
        ps.text = b2text.text;
        next.interactable = true;
    }
    public void Btn3()
    {
        ps.text = b3text.text;
        next.interactable = true;
    }
    public void nextNote()
    {
        Note1.SetActive(false);
        Note2.SetActive(true);
    }
}
