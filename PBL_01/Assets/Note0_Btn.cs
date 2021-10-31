using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Note0_Btn : MonoBehaviour
{
    public GameObject Note0, Note1;
    public Button btn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void nextNote()
    {
        Note0.SetActive(false);
        Note1.SetActive(true);
    }
}
