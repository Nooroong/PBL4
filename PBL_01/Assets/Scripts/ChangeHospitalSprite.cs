using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeHospitalSprite : MonoBehaviour
{
    public GameObject image;
    public Image tomee, doctor;
    public Text dialogText;

    void Start()
    {
        //m_Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
 
            if (dialogText.text == "나왔습니다. 일단 뇌 사진을 봅시다.")
            {   //토미와 의사 눈과 입 이미지 비활성화
                tomee.gameObject.SetActive(false);
                doctor.gameObject.SetActive(false);
                image.GetComponent<Image>().sprite = Resources.Load("PrologueImage\\2", typeof(Sprite)) as Sprite;
            }
            if (dialogText.text == "지금 느끼고 계시는 문제들은 아마 심리적으로 느끼")
            {   //토미와 의사 눈과 입 이미지 활성화
                image.GetComponent<Image>().sprite = Resources.Load("PrologueImage\\1_BG", typeof(Sprite)) as Sprite;
                tomee.gameObject.SetActive(true);
                doctor.gameObject.SetActive(true);
                image.gameObject.GetComponent<ChangeHospitalSprite>().enabled = false;
            }
    }
}
