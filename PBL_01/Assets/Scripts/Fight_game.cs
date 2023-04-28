using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Fight_game : MonoBehaviour
{
    public Image Bar;
    public GameObject black;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Bar.GetComponent<Image>().fillAmount == 0)
        {
            StartCoroutine(UntilPlayback("Fail"));
        }
        else if (Bar.GetComponent<Image>().fillAmount != 1.0f)
        {
            Bar.GetComponent<Image>().fillAmount -= 0.001f;
        }
        else if(Bar.GetComponent<Image>().fillAmount == 1.0f)
        {
            StartCoroutine(UntilPlayback("Complete"));
        }
    }

    public void Fail()
    {
        SceneManager.LoadScene("fight_game");
    }
    public void Complete()
    {
        SceneManager.LoadScene("Day4_fight1");
    }

    IEnumerator UntilPlayback(string scene)
    {
        black.SetActive(true);
        black.GetComponent<fightgame_black>().enabled = true;
        Invoke(scene, 3);
        yield return null;
    }
}
