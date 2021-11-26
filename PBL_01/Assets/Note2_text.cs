using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Note2_text : MonoBehaviour
{
    public Text text;
    public Text note, ps;
    public Button exit;

    // Start is called before the first frame update
    void Start()
    {
        text.text = note.text + ps.text;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Exit()
    {
        SceneManager.LoadScene("desk");
    } 
}
