using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeHomeSprite : MonoBehaviour
{
    public GameObject image;
    public Image tomee_eyes1;
    public Text dialogText;

    void Start()
    {
        tomee_eyes1.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (dialogText.text == "(침")
        {
            tomee_eyes1.gameObject.SetActive(true);
            image.GetComponent<Image>().sprite = Resources.Load("PrologueImage\\8_BG", typeof(Sprite)) as Sprite;
        }
        if (dialogText.text == "")
        {
            tomee_eyes1.gameObject.SetActive(false);
            image.GetComponent<Image>().sprite = Resources.Load("PrologueImage\\9", typeof(Sprite)) as Sprite;
        }
    }
}
