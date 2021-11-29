using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListenForAudioCommand : MonoBehaviour
{
    public GameObject Bar;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float db = 20 * Mathf.Log10(Mathf.Abs(mic_volume.MicLoudness));
        Debug.Log("Volume is " + mic_volume.MicLoudness.ToString("##.####")+ ", decibels is" + db.ToString());

        if (db < 1 && db > -20f)
        {
            Debug.Log("loudness is bigger than 1");
            IncreaseBar();
        }
    }
    public void IncreaseBar()
    {
        Bar.GetComponent<Image>().fillAmount += 0.01f;
    }
}
