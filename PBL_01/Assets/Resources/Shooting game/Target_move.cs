using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target_move : MonoBehaviour
{
    float speed = 5f;
    float yMove;

    // Start is called before the first frame update
    void Start()
    {
        Up();
    }
    public void Up()
    {
        StartCoroutine(UpFlow());
    }
    public void Down()
    {
        StartCoroutine(DownFlow());
    }
    IEnumerator UpFlow()
    {
        while (this.transform.position.y < 1000.0f)
        {
            yMove = 0;
            yMove = speed;
            this.transform.Translate(new Vector3(0, yMove, 0));
            yield return null;
        }
        StartCoroutine(DownFlow());
        yield return null;
    }
    IEnumerator DownFlow()
    {
        while (this.transform.position.y > 500.0f)
        {
            yMove = 0;
            yMove = -speed;
            this.transform.Translate(new Vector3(0, yMove, 0));
            yield return null;
        }
        StartCoroutine(UpFlow());
        yield return null;
    }
}
