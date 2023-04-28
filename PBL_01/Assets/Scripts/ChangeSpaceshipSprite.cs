using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSpaceshipSprite : MonoBehaviour
{
    public Image Alarm;
    public Text dialogText;

    void Start()
    {
        Alarm.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (dialogText.text == "'")
        {
            Alarm.gameObject.SetActive(true);
        }
        
        if (dialogText.text == "(토미는 지")
        {
            Alarm.gameObject.SetActive(false);
            this.GetComponent<Image>().sprite = Resources.Load("PrologueImage\\19_0", typeof(Sprite)) as Sprite;
        }

        if (dialogText.text == "(토미는 지시에 따라 안전벨트를 맨다.)")
        {
            this.GetComponent<Image>().sprite = Resources.Load("PrologueImage\\19_1", typeof(Sprite)) as Sprite;
        }
        if (dialogText.text == "(토미는 심")
        {
            this.GetComponent<Image>().sprite = Resources.Load("PrologueImage\\20", typeof(Sprite)) as Sprite;
        }
    }
}
