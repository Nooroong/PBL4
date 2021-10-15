using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
        Invoke("NextScene", 4f);

    }
    
    public void NextScene()
    {
        if (door.gameObject.transform.position.x < 570.0f)
        {
            SceneManager.LoadScene("Consult3");
        }
    }

  

    // Update is called once per frame
    void Update()
    {
        ShowDoor();
        
        
    }
}
