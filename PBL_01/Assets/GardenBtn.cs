using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GardenBtn : MonoBehaviour
{
    public Button Plant1;
    public Button Plant2;
    public Button Plant3;
    public Button Home;
    

    public bool isClicked1 = false;
    public bool isClicked2 = false;
    public bool isClicked3 = false;



    // Start is called before the first frame update
    void Start()
    {
        Home.gameObject.SetActive(false);

        
    }

    // Update is called once per frame
    void Update()
    {
        Select();
    }

    public void IsClicked1()
    {
        isClicked1 = true;
    }

    public void IsClicked2()
    {
        isClicked2 = true;
    }

    public void IsClicked3()
    {
        isClicked3 = true;
    }

    void Select()
    {
        if((isClicked1==true) && (isClicked2==true) && (isClicked3 == true))
        {
            Invoke("Show", 1f);
         
        }
    }

    void Show()
    {
        Home.gameObject.SetActive(true);
        
    }
    public void Return()
    {
        isClicked1 = false;
        isClicked2 = false;
        isClicked3 = false;
    }

}
