using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Desk_Tablet : MonoBehaviour
{
    public Button Tablet;
    public Text text;
    public AudioSource audioSource;
    public AudioClip bgm;

    // Start is called before the first frame update
    void Start() {
        text.gameObject.SetActive(false);
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = bgm;
        audioSource.loop = false;
    }

    public void Sound() {
        audioSource.Play();
    }

    public void BtnClick() {
        text.gameObject.SetActive(true);
        Tablet.GetComponent<Button>().interactable = false;
        StartCoroutine(FadeTextToZero());
    }
    public IEnumerator FadeTextToZero() {
        text.color = new Color(text.color.r, text.color.g, text.color.b, 1);
        while (text.color.a > 0.0f) {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - (Time.deltaTime / 2.0f));
            yield return null;
        }

    }
}
