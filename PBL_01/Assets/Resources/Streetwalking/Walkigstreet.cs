using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Walkigstreet : MonoBehaviour
{
    public Camera m_cam;

    public GameObject tree, building, sky, fly;
    Vector3 P_screenPos;

    Animator m_Animator;

    float time = 0f;
    float F_time = 4f;
    float p_speed = 200f;
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

    }

    // Update is called once per frame
    void Update()
    {
        P_screenPos= m_cam.WorldToScreenPoint(player.gameObject.transform.position);
        time += Time.deltaTime / F_time;
    }
    public void walking()
    {
        StartCoroutine(WalkingFlow());
    }

    IEnumerator WalkingFlow()
    {
        while (P_screenPos.x < 1400)
        {
            xMove = 0;
            xMove = 1/p_speed;
            player.transform.Translate(new Vector3(xMove, 0, 0));
            yield return null;
        }
        m_Animator.GetComponent<Animator>().enabled = false;
        tree.gameObject.GetComponent<BG_Moving>().enabled = false;
        sky.gameObject.GetComponent<BG_Moving>().enabled = false;
        building.gameObject.GetComponent<BG_Moving>().enabled = false;
        fly.gameObject.GetComponent<BG_Moving>().enabled = false;
        Invoke("LoadScene", 2f);
        yield return null;
    }
    public void LoadScene()
    {
        SceneManager.LoadScene("StreetLeaflet");
    }
}
