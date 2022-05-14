using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Memo_dontdestroy : MonoBehaviour
{
    public GameObject Memo_ctrl;
    public TextMeshProUGUI text1, text2, text3, text4;

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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Eating()
    {
        text1.text = "<s>" + text1.text + "</s>";
    }
    public void Take_A_Pill()
    {
        text2.text = "<s>" + text2.text + "</s>";
    }
    public void Planter()
    {
        text3.text = "<s>" + text3.text + "</s>";
    }
    public void Random()
    {
        text4.text = "<s>" + text4.text + "</s>";
    }
}
