using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day_manager : MonoBehaviour
{
    int cnt = 0;
    // Start is called before the first frame update
    void Start()
    {
        
        //�ʱ�ȭ �Ǿ �������� �Ǿ��� �� & ó�� ������ ��
        if ( !PlayerPrefs.HasKey("bap") && !PlayerPrefs.HasKey("pill") && !PlayerPrefs.HasKey("planter")
            && !PlayerPrefs.HasKey("random1") && !PlayerPrefs.HasKey("random2") && !PlayerPrefs.HasKey("sleep"))
        {
            PlayerPrefs.SetInt("bap", 0); //��Ա�
            PlayerPrefs.SetInt("pill", 0); //��Ա�
            PlayerPrefs.SetInt("planter", 0); //ȭ�� ���ٱ�
            PlayerPrefs.SetInt("random1", 0); //����1
            PlayerPrefs.SetInt("random2", 0); //����2
            PlayerPrefs.SetInt("routine", 0); //�ۿ��� �Ͼ�� ��
            PlayerPrefs.SetInt("sleep", 0); //���ڱ�
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        //��� ����Ǿ��� �� Ű ���� �ʱ�ȭ
        if ((bool)GetBool("bap") && (bool)GetBool("pill") && (bool)GetBool("planter")
            && (bool)GetBool("random1") && (bool)GetBool("random2") && (bool)GetBool("routine") && (bool)GetBool("sleep"))
        {
            PlayerPrefs.DeleteKey("bap");
            PlayerPrefs.DeleteKey("pill");
            PlayerPrefs.DeleteKey("planter");
            PlayerPrefs.DeleteKey("random1");
            PlayerPrefs.DeleteKey("random2");
            PlayerPrefs.DeleteKey("routine");
            PlayerPrefs.DeleteKey("sleep");
            PlayerPrefs.DeleteKey("NoteCp");
            

            cnt += PlayerPrefs.GetInt("day") + 1;
            PlayerPrefs.SetInt("day", cnt);
        }
    }
    // int ���� 1�̸� true, 2�̸� false
    public static bool? GetBool(string key)
    {
        int tmp = PlayerPrefs.GetInt(key);
        if (tmp == 1)
            return true;
        else if (tmp == 0)
            return false;
        else
            return null;
    }
}
