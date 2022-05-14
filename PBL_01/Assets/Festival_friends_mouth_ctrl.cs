using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Festival_friends_mouth_ctrl : MonoBehaviour, IPointerDownHandler
{
    public bool istyping;
    public GameObject panel;
    public GameObject friend1, friend2, friend3, BG;
    int cnt = 0;

    Animator f1_Animator, f2_Animator, f3_Animator, BG_Animator;

    // Start is called before the first frame update
    void Start()
    {
        f1_Animator = friend1.GetComponent<Animator>();
        f1_Animator.GetComponent<Animator>().enabled = true;

        f2_Animator = friend2.GetComponent<Animator>();
        f2_Animator.GetComponent<Animator>().enabled = false;

        f3_Animator = friend3.GetComponent<Animator>();
        f3_Animator.GetComponent<Animator>().enabled = false;

        BG_Animator = BG.GetComponent<Animator>();
        BG_Animator.GetComponent<Animator>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        istyping = DialogManager.istyping;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (!istyping)
        {
            cnt++;

            if (cnt == 1)
            {
                f2_Animator.GetComponent<Animator>().enabled = true;
                f1_Animator.GetComponent<Animator>().enabled = false;
                BG_Animator.GetComponent<Animator>().enabled = false;
                
                friend1.GetComponent<Image>().sprite = Resources.Load("Day3\\Friends mouth\\friend1_m_close", typeof(Sprite)) as Sprite;
                BG.GetComponent<Image>().sprite = Resources.Load("Day3\\friends5", typeof(Sprite)) as Sprite;
            }
            else if (cnt == 2)
            {
                f1_Animator.GetComponent<Animator>().enabled = true;
                f2_Animator.GetComponent<Animator>().enabled = false;

                friend2.GetComponent<Image>().sprite = Resources.Load("Day3\\Friends mouth\\friend2_m_close", typeof(Sprite)) as Sprite;
            }
            else if (cnt == 3)
            {
                f1_Animator.GetComponent<Animator>().enabled = false;
                f3_Animator.GetComponent<Animator>().enabled = true;

                friend1.GetComponent<Image>().sprite = Resources.Load("Day3\\Friends mouth\\friend1_m_close", typeof(Sprite)) as Sprite;
            }
            else if (cnt == 4)
            {
                f3_Animator.GetComponent<Animator>().enabled = false;

                friend3.GetComponent<Image>().sprite = Resources.Load("Day3\\Friends mouth\\friend3_m_close", typeof(Sprite)) as Sprite;
            }
        }
    }
    /*
    public void Anim_ctrl()
    {
        Debug.Log(istyping);
        if (!istyping)
        {
            cnt++;

            if (cnt == 1)
            {
                f2_Animator.GetComponent<Animator>().enabled = true;
                f1_Animator.GetComponent<Animator>().enabled = false;
                BG.GetComponent<Image>().sprite = Resources.Load("Day3\\friends5", typeof(Sprite)) as Sprite;
                BG_Animator.GetComponent<Animator>().enabled = false;
            }
            else if (cnt == 2)
            {
                f1_Animator.GetComponent<Animator>().enabled = true;
                f2_Animator.GetComponent<Animator>().enabled = false;
            }
            else if (cnt == 3)
            {
                f1_Animator.GetComponent<Animator>().enabled = false;
                f3_Animator.GetComponent<Animator>().enabled = true;
            }
            else if (cnt == 4)
            {
                f3_Animator.GetComponent<Animator>().enabled = false;
            }
        }

    }*/
    
}
