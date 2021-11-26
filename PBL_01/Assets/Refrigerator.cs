using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Refrigerator : MonoBehaviour
{
    public GameObject Button;
    public Button Cereal;
    public Button Milk;
    

    // Start is called before the first frame update
    void Start()
    {
        Button = GameObject.Find("Button");
        Cereal.GetComponent<Button>().interactable = false;
        Milk.GetComponent<Button>().interactable = false;
        
    }
    public void OnClickButton()
    {
        Button.SetActive(false);
        Cereal.GetComponent<Button>().interactable = true;
        Milk.GetComponent<Button>().interactable = true;
       
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
