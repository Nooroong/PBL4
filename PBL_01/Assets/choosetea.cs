using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class choosetea : MonoBehaviour
{
    public static string tea;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Btn1()
    {
        tea = "chamomile";
        SceneManager.LoadScene("TeaTime1");
    }
    public void Btn2()
    {
        tea = "lavender";
        SceneManager.LoadScene("TeaTime1");
    }
    public void Btn3()
    {
        tea = "jasmine";
        SceneManager.LoadScene("TeaTime1");
    }
    public void LoadHome()
    {
        PlayerPrefs.SetInt("Tea", 0);
        SceneManager.LoadScene("House");
    }
}
