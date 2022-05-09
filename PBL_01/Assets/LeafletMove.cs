using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LeafletMove : MonoBehaviour
{
    public Image img;
    int speed = 250;
    float yMove;


    public void ShowPlayer() {
        yMove = 0;

        if (img.gameObject.transform.position.y < 450.0f) {
            yMove = +speed * Time.deltaTime;
            img.transform.Translate(new Vector3(0, yMove, 0));

        } else {
            Invoke("NextScene", 2.0f);
        }
    }

    // Update is called once per frame
    void Update() {
        ShowPlayer();
    }


    void NextScene() {
        SceneManager.LoadScene("HospitalReception2");
    }
}
