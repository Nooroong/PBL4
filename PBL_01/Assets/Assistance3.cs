using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Assistance3 : MonoBehaviour
{
    int speed = 80;
    int speed1 = 150;
   float yMove;
    float xMove;
    public Image Background;
    public Image Player;
    
    // Start is called before the first frame update
    

    void Move()
    {
        yMove = 0;
        if (Background.gameObject.transform.position.y > 380.0f)
        {
            yMove = -speed * Time.deltaTime;
            Background.transform.Translate(new Vector3(0, yMove, 0));
        }
    }
    public void PlayerMv()
    {
        
        if (Player.gameObject.transform.position.x > 520.0f)
       {
            xMove = 0;

            xMove = -speed1 * Time.deltaTime;
            Player.transform.Translate(new Vector3(xMove, 0, 0));
        }
    }
    void Show()
    {
        Player.gameObject.SetActive(true);
        PlayerMv();
    }
     
    void Update()
    {
        Move();
        Invoke("Show", 5f);
    }
    void Start()
    {
        Player.gameObject.SetActive(false);
    }

}
