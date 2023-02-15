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

        if (dialogText.text == "(토미는 기절을")
        {
            tomee_eyes.gameObject.SetActive(true);
            spaceship.gameObject.SetActive(false);
        }

        if (dialogText.text == "(정신을")
        {
            tomee_eyes.gameObject.SetActive(false);
            image.GetComponent<Image>().sprite = Resources.Load("PrologueImage\\23_0", typeof(Sprite)) as Sprite;
        }

        if (dialogText.text == "(정신을 차린 토미는 우주선을")
        {
            image.GetComponent<Image>().sprite = Resources.Load("PrologueImage\\23_1", typeof(Sprite)) as Sprite;
        }

        if (dialogText.text == "(정신을 차린 토미는 우주선을 나가려고 하는데.)")
        {
            image.GetComponent<Image>().sprite = Resources.Load("PrologueImage\\23_2", typeof(Sprite)) as Sprite;
        }
    }
}
