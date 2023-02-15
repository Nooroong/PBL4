using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChagneForecedLandingSprite : MonoBehaviour
{
    public GameObject image;
    public Text dialogText;
    public Image spaceship;
    public Image tomee_eyes;

    void Start()
    {
        tomee_eyes.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (dialogText.text == "(��̴� ������")
        {
            tomee_eyes.gameObject.SetActive(true);
            spaceship.gameObject.SetActive(false);
        }

        if (dialogText.text == "(������")
        {
            tomee_eyes.gameObject.SetActive(false);
            image.GetComponent<Image>().sprite = Resources.Load("PrologueImage\\23_0", typeof(Sprite)) as Sprite;
        }

        if (dialogText.text == "(������ ���� ��̴� ���ּ���")
        {
            image.GetComponent<Image>().sprite = Resources.Load("PrologueImage\\23_1", typeof(Sprite)) as Sprite;
        }

        if (dialogText.text == "(������ ���� ��̴� ���ּ��� �������� �ϴµ�.)")
        {
            image.GetComponent<Image>().sprite = Resources.Load("PrologueImage\\23_2", typeof(Sprite)) as Sprite;
        }
    }
}
