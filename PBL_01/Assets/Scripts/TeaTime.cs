using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TeaTime : MonoBehaviour
{
    public Image kettle, tea;
    int speed = 320;
    float yMove;

    public void B_water()
    {
        StartCoroutine(BoilingWaterFlow());
    }

    IEnumerator BoilingWaterFlow()
    {
        yMove = 0;

        while (kettle.gameObject.transform.position.y < 1500.0f)
        {
            yMove = speed * Time.deltaTime;
            kettle.transform.Translate(new Vector3(0, yMove, 0));
            yield return null;
        }
        yield return new WaitForSeconds(3.0f);

        yMove = 0;

        while (kettle.gameObject.transform.position.y >= 540.0f)
        {
            yMove = -speed * Time.deltaTime;
            kettle.transform.Translate(new Vector3(0, yMove, 0));
            yield return null;
        }
        yield return null;
    }

    public void A_Tea()
    {
        StartCoroutine(AddTea());
    }

    IEnumerator AddTea()
    {
        yMove = 0;

        while (tea.gameObject.transform.position.y < 1500.0f)
        {
            yMove = speed * Time.deltaTime;
            tea.transform.Translate(new Vector3(0, yMove, 0));
            yield return null;
        }
        yield return new WaitForSeconds(2.0f);

        yMove = 0;

        while (tea.gameObject.transform.position.y >= 683.0f)
        {
            yMove = -speed * Time.deltaTime;
            tea.transform.Translate(new Vector3(0, yMove, 0));
            yield return null;
        }
        yield return null;
    }

    public void nextScene()
    {
        SceneManager.LoadScene("TeaTime2");
    }
    public void Awake()
    {
        Invoke("A_Tea", 3);
        Invoke("B_water", 10);
        Invoke("nextScene", 30);
    }
}
