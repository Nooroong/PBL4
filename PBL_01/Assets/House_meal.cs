using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class House_meal : MonoBehaviour
{
    public Button Meal;
    public Text text;

    // Start is called before the first frame update
    void Start()
    {
        text.gameObject.SetActive(false);
    }

    public void BtnClick()
    {
        text.gameObject.SetActive(true);
        StartCoroutine(FadeTextToZero());
        Invoke("Hide", 3f);
    }
    public IEnumerator FadeTextToZero()
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b, 1);
        while (text.color.a > 0.0f)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - (Time.deltaTime / 2.0f));
            yield return null;
        }

    }

    void Hide()
    {
        Meal.gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
