using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Desk_click : MonoBehaviour
{
    public Button note, newspaper;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadNote()
    {
        SceneManager.LoadScene("Note");
    }
    public void LoadNewspaper()
    {
        SceneManager.LoadScene("Newspaper");
    }
}
