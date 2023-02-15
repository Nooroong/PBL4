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
        
        if (dialogText.text == "(��̴� ��")
        {
            Alarm.gameObject.SetActive(false);
            this.GetComponent<Image>().sprite = Resources.Load("PrologueImage\\19_0", typeof(Sprite)) as Sprite;
        }

        if (dialogText.text == "(��̴� ���ÿ� ���� ������Ʈ�� �Ǵ�.)")
        {
            this.GetComponent<Image>().sprite = Resources.Load("PrologueImage\\19_1", typeof(Sprite)) as Sprite;
        }
        if (dialogText.text == "(��̴� ��")
        {
            this.GetComponent<Image>().sprite = Resources.Load("PrologueImage\\20", typeof(Sprite)) as Sprite;
        }
    }
}
