using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TeaTime2ctr : MonoBehaviour
{
    public Button home;
    public GameObject Bar;
    // Start is called before the first frame update
    void Start()
    {
        home.interactable = false;
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
        SceneManager.LoadScene("House");
    }
}
