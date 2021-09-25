using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hopital_Door : MonoBehaviour
{
    public Image player;
    int speed = 120;
    float yMove;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ShowPlayer()
    {
        yMove = 0;
        
        if (player.gameObject.transform.position.y < 150.0f)
        {
            yMove = +speed * Time.deltaTime;
            player.transform.Translate(new Vector3(0, yMove, 0));
            
        }
    }


    // Update is called once per frame
    void Update()
    {
        ShowPlayer();
    }
}
