using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class test : MonoBehaviour
{
    public AudioSource Alarm;

    float time = 0f;
    int cnt = 0;
    public void Start()
    {
        //StartCoroutine(Move());
    }
    public void Moving()
    {
        StartCoroutine(Move());
    }
    IEnumerator Move()
    {
        while (true)
        { 
            time += Time.deltaTime;
            transform.Translate(Vector2.up *100* Time.deltaTime);
            
            if(time >= 2f)
            {
                Alarm.Play();
                if ( cnt == 4 || cnt == 5)
                {
                    time = 0f;
                    cnt++;
                    yield return new WaitForSeconds(2f);
                }
                else if (cnt == 14)
                {
                    break;
                }
                else
                {
                    time = 0f;
                    cnt++;
                    yield return new WaitForSeconds(10f);
                }
            }
            yield return null;
        }
    }
}
