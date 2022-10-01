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
            black.SetActive(true);
            black.GetComponent<fightgame_black>().enabled = true;
            Invoke("Fail", 3);
        }
        else if (Bar.GetComponent<Image>().fillAmount != 1.0f)
        {
            Bar.GetComponent<Image>().fillAmount -= 0.0008f;
        }
        else if(Bar.GetComponent<Image>().fillAmount == 1.0f)
        {
            black.SetActive(true);
            black.GetComponent<fightgame_black>().enabled = true;
            Invoke("Complete", 3);
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
}
