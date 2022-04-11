using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnCtl : MonoBehaviour
{
    public GameObject cam, stick; 

    // Start is called before the first frame update
    void Start()
    {
        cam.transform.gameObject.GetComponent<MaskCamera>().enabled = false;
        stick.transform.gameObject.GetComponent<Drag>().enabled = false;
    }

    // Update is called once per frame
    public void Onclick()
    {
        this.gameObject.SetActive(false);
        cam.transform.gameObject.GetComponent<MaskCamera>().enabled = true;
        stick.transform.gameObject.GetComponent<Drag>().enabled = true;
    }
}
