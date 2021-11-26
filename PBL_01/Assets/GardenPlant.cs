using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GardenPlant : MonoBehaviour
{

    public GameObject Button;
    public Button Plant1;
    public Button Plant2;
    public Button Plant3;
   

    // Start is called before the first frame update
    void Start()
    {
        Button = GameObject.Find("Button");
        Plant1.GetComponent<Button>().interactable = false;
        Plant2.GetComponent<Button>().interactable = false;
        Plant3.GetComponent<Button>().interactable = false;
    }

    public void OnClickButton()
    {
        Button.SetActive(false);
        Plant1.GetComponent<Button>().interactable = true;
        Plant2.GetComponent<Button>().interactable = true;
        Plant3.GetComponent<Button>().interactable = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
