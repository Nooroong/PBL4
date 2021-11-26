using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Assistance1 : MonoBehaviour
{

    public Image player;
    int speed = 80;
    float xMove;

    void Move()
    {
        xMove = 0;
        player.gameObject.SetActive(true);

        
        xMove = -speed * Time.deltaTime;
        player.transform.Translate(new Vector3(xMove, 0, 0));

        Invoke("NextScene", 4);
 
    }

    void NextScene()
    {
        SceneManager.LoadScene("Assistance2");
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
}
