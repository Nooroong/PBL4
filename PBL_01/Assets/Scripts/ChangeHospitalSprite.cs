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
 
            if (dialogText.text == "���Խ��ϴ�. �ϴ� �� ������ ���ô�.")
            {   //��̿� �ǻ� ���� �� �̹��� ��Ȱ��ȭ
                tomee.gameObject.SetActive(false);
                doctor.gameObject.SetActive(false);
                image.GetComponent<Image>().sprite = Resources.Load("PrologueImage\\2", typeof(Sprite)) as Sprite;
            }
            if (dialogText.text == "���� ������ ��ô� �������� �Ƹ� �ɸ������� ����")
            {   //��̿� �ǻ� ���� �� �̹��� Ȱ��ȭ
                image.GetComponent<Image>().sprite = Resources.Load("PrologueImage\\1_BG", typeof(Sprite)) as Sprite;
                tomee.gameObject.SetActive(true);
                doctor.gameObject.SetActive(true);
                image.gameObject.GetComponent<ChangeHospitalSprite>().enabled = false;
            }
    }
}
