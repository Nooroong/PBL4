using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Consult2 : MonoBehaviour
{

    public Image door;
    int speed = 160;
    float xMove;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ShowDoor()
    {
        xMove = 0;

        if (door.gameObject.transform.position.x > 570.0f)
        {
            xMove = -speed * Time.deltaTime;
            door.transform.Translate(new Vector3(xMove, 0, 0));

        }
    }

    // Update is called once per frame
    void Update()
    {
        ShowDoor();
    }
}
