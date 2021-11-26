using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Teatime_blow : MonoBehaviour
{

    public float sensitivity = 100;
    public float loudness = 0;
    private AudioSource _audio;
    public Text text;
    void Awake()
    {
        _audio = GetComponent<AudioSource>();
    }
    void Start()
    {
        _audio.clip = Microphone.Start(null, true, 10, 44100);
        _audio.loop = true;
        _audio.mute = false;
        while (!(Microphone.GetPosition(null) > 0)) { }
        _audio.Play();

        text.gameObject.SetActive(false);

        //  Movie2.SetActive(false);
        //  Movie1.SetActive(true);

    }
    void Update()
    {
        loudness = GetAveragedVolume() * sensitivity;
        if (loudness > 7)
        {
            Debug.Log("loudness is bigger than 1");
            text.gameObject.SetActive(true);
        }
        else
        {
            // Movie2.SetActive(false);
            text.gameObject.SetActive(false);
            //Debug.Log("Ready");
        }
        if (Input.GetButtonDown("Cancel"))
        {
            Application.Quit();
        }
    }
    float GetAveragedVolume()
    {
        float[] data = new float[256];
        float a = 0;
        _audio.GetOutputData(data, 0);
        foreach (float s in data)
        {
            a += Mathf.Abs(s);
        }
        return a / 256;
    }
}


