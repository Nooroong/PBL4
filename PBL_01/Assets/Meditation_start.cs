using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Meditation_start : MonoBehaviour
{
    public GameObject Text;
    public GameObject home;
    // Start is called before the first frame update
    void Start()
    {
        //Text.gameObject.GetComponent<test>().enabled = false;
    }

    public void Onclick()
    {
        this.gameObject.SetActive(false);
        //Text.gameObject.GetComponent<test>().enabled = true;
        Text.gameObject.GetComponent<test>().Moving();
        home.gameObject.GetComponent<Meditation_home>().Interactive();
    }
}
