using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Milk : MonoBehaviour
{
    public Button milk;
    public AudioSource audioSource;
    public AudioClip bgm;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = bgm;
        audioSource.loop = false;
    }
    public void Sound()
    {
        audioSource.Play();
        Invoke("Hide", 0.5f);
    }
    public void Hide()
    {
        milk.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
