using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Walkigstreet : MonoBehaviour
{
    Animator m_Animator;
    float p_speed = 7f;
    float xMove;
    public Image player;

    // Start is called before the first frame update
    void Awake()
    {
        m_Animator = GetComponent<Animator>();
        walking();
    }
    void Start()
    {
        //walking();
    }

    // Update is called once per frame
    void Update()
    {
        if(player.gameObject.transform.position.x >= 1320.0f)
        {
            m_Animator.GetComponent<Animator>().enabled = false;
            Invoke("LoadScene", 2f);

        }
    }
    public void walking()
    {
        StartCoroutine(WalkingFlow());
    }

    IEnumerator WalkingFlow()
    {
        while (player.gameObject.transform.position.x < 1320.0f)
        {
            xMove = 0;
            xMove = 1/p_speed;
            player.transform.Translate(new Vector3(xMove, 0, 0));
            yield return null;
        }
        yield return null;
    }
    public void LoadScene()
    {
        SceneManager.LoadScene("StreetLeaflet");
    }
}
