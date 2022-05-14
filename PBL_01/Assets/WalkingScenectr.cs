using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WalkingScenectr : MonoBehaviour
{
    public Button start, finish, Home;
    Animator m_Animator;

    GameObject Memo_ctrl;

    // Start is called before the first frame update
    void Start()
    {
        finish.gameObject.SetActive(false);
        finish.enabled = false;
        Home.enabled = false;
        m_Animator = GetComponent<Animator>();
        m_Animator.GetComponent<Animator>().enabled = false;

        //�޸� ��������
        Memo_ctrl = GameObject.Find("Memo_ctrl");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startWalk()
    {
        m_Animator.GetComponent<Animator>().enabled = true;
        finish.gameObject.SetActive(true);
        finish.enabled = true;
        start.gameObject.SetActive(false);
    }
    public void finishWalk()
    {
        m_Animator.GetComponent<Animator>().enabled = false;
        Home.enabled = true;
    }
    public void LoadHouse()
    {
        SceneManager.LoadScene("House");
        Complete();
    }
    public void Complete()
    {
        Memo_ctrl.gameObject.GetComponent<Memo_dontdestroy>().Random();
    }

}
