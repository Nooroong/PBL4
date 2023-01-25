using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Memo_dontdestroy : MonoBehaviour
{
    public GameObject Memo_ctrl;
    public TextMeshProUGUI text0, text1, text2, text3, text4, text5;
    // text0: ���� ���� (PlayerPrefs Ű �̸� NoteCp)
    // text1: ��Ա�    (PlayerPrefs Ű �̸� bap)
    // text2: ��Ա�    (PlayerPrefs Ű �̸� pill)
    // text3: ȭ�� ���ٱ� (PlayerPrefs Ű �̸� planter)
    // text4: ����1     (PlayerPrefs Ű �̸� random1)
    // text5: ����2     (PlayerPrefs Ű �̸� random2)

    void Awake()
    {
        var obj = FindObjectsOfType<Memo_dontdestroy>();

        if (obj.Length == 1)
        {
            DontDestroyOnLoad(Memo_ctrl);
        }
        else
        {
            Destroy(Memo_ctrl);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        switch (PlayerPrefs.GetInt("task_index", -1))
        {
            case 0:
                text4.text = "��å�ϱ�";
                text5.text = "�� ���ñ�";
                break;
            case 1:
                text4.text = "����ϱ�";
                text5.text = "�� ���ñ�";
                break;
            case 2:
                text4.text = "����ϱ�";
                text5.text = "��å�ϱ�";
                break;
            default:
                text4.text = "default";
                text5.text = "default";
                break;
        }

        //�ٸ� ������ �ִٰ� House������ ���ƿ��� �� or �̾�ϱ� House ������ ������ �� �� ���� True ��� ��Ҽ�
        if ((bool)Day_manager.GetBool("NoteCp")) // ���� ���徲��
        {
            text0.text = "<s>" + text0.text + "</s>";
        }
        if ((bool)Day_manager.GetBool("bap")) //�� �Ա�
        {
            text1.text = "<s>" + text1.text + "</s>";
        }
        if ((bool)Day_manager.GetBool("pill")) //�� �Ա�
        {
            text2.text = "<s>" + text2.text + "</s>";
        }
        if ((bool)Day_manager.GetBool("planter")) //ȭ�� ���ٱ�
        {
            text3.text = "<s>" + text3.text + "</s>";
        }
        if ((bool)Day_manager.GetBool("random1")) //���� �� ��1
        {
            text4.text = "<s>" + text4.text + "</s>";
        }
        if ((bool)Day_manager.GetBool("random2")) //���� �� ��2
        {
            text5.text = "<s>" + text5.text + "</s>";
        }
    }

    // Update is called once per frame
    void Update() 
    {   /* ��� ���� ������ ���ڱ� ���� �� ���� */
        if (!PlayerPrefs.HasKey("NoteCp") && !PlayerPrefs.HasKey("bap") && !PlayerPrefs.HasKey("pill") && 
            !PlayerPrefs.HasKey("planter") && !PlayerPrefs.HasKey("random1") && !PlayerPrefs.HasKey("random2"))
        {
            Destroy(Memo_ctrl);
        }
    }

    /* �� ���� ����� ��Ҽ� �ߴ� �Լ� */
    public void Reply() //���� ����
    {
        text0.text = "<s>" + text0.text + "</s>";
        PlayerPrefs.SetInt("NoteCp", 1);
    }
    public void Eating() //��Ա�
    {
        text1.text = "<s>" + text1.text + "</s>";
        PlayerPrefs.SetInt("bap", 1);
    }
    public void Take_A_Pill() //��Ա�
    {
        text2.text = "<s>" + text2.text + "</s>";
        PlayerPrefs.SetInt("pill", 1);
    }
    public void Planter() //ȭ�� ���ٱ�
    {
        text3.text = "<s>" + text3.text + "</s>";
        PlayerPrefs.SetInt("planter", 1);
    }
    public void Walking() //��å
    {
        if (text4.text.Contains("��å")) //random1���� random2���� Ȯ���ϱ� ���� ���ǹ�
        {
            text4.text = "<s>" + text4.text + "</s>";
            PlayerPrefs.SetInt("random1", 1);
        }

        else
        {
            text5.text = "<s>" + text5.text + "</s>";
            PlayerPrefs.SetInt("random2", 1);
        }
    }
    public void Meditation() //���
    {
        if (text4.text.Contains("���")) //random1���� random2���� Ȯ���ϱ� ���� ���ǹ�
        {
            text4.text = "<s>" + text4.text + "</s>";
            PlayerPrefs.SetInt("random1", 1);
        }

        else
        {
            text5.text = "<s>" + text5.text + "</s>";
            PlayerPrefs.SetInt("random2", 1);
        }
    }
    public void Tea() //�����ñ�
    {
        if (text4.text.Contains("��")) //random1���� random2���� Ȯ���ϱ� ���� ���ǹ�
        {
            text4.text = "<s>" + text4.text + "</s>";
            PlayerPrefs.SetInt("random1", 1);
        }

        else
        {
            text5.text = "<s>" + text5.text + "</s>";
            PlayerPrefs.SetInt("random2", 1);
        }
    }
}
