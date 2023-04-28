using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shoot_startBtn : MonoBehaviour
{
    public GameObject targets;
    public Image black;
    public Text timer;

    // Start is called before the first frame update
    void Start()
    {
        // targets.gameObject.GetComponent<Target_move>().enabled = false;
        for(int i = 0; i < targets.transform.childCount; i++){
            targets.transform.GetChild(i).GetComponent<Target_move>().enabled = false;
        }
        
        timer.gameObject.GetComponent<Timer>().enabled = false;
        black.enabled = true;
    }

    // Update is called once per frame
    public void Onclick()
    {
        for(int i = 0; i < targets.transform.childCount; i++){
            targets.transform.GetChild(i).GetComponent<Target_move>().enabled = true;
        }

        StartCoroutine(Onclick_co(this.gameObject.GetComponent<Button>()));
    }
        

    IEnumerator Onclick_co(Button obj)
    {
        obj.GetComponent<AudioSource>().Play();
        yield return new WaitUntil(() => !obj.GetComponent<AudioSource>().isPlaying);

        this.gameObject.SetActive(false);

        // targets.gameObject.GetComponent<Target_move>().enabled = true;
        for(int i = 0; i < targets.transform.childCount; i++){
            targets.transform.GetChild(i).GetComponent<Target_move>().enabled = true;
        }

        timer.gameObject.GetComponent<Timer>().enabled = true;
        black.enabled = false;
    }
}
