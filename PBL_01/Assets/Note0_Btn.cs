using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Note0_Btn : MonoBehaviour
{
    public GameObject Note0, Note1;
    public Button btn;
    public Text text;

    // Start is called before the first frame update
    void Start()
    {
        switch (PlayerPrefs.GetInt("day"))
        {
            case 1:

                text.text = "�ȳ�, �ٽ� �� �� ������ �°� ȯ����." + "\n"+
                            "���� ��ħ ���� ����ϰ� ���� �ʰ� ����ؼ� �Ƹ� �ʿ� ������ ���� �� �����ž�." + "\n" +
                            "��� ���� ��ħ���� ������ ������ �����." + "\n" +
                            "ps. ���� ����� ������ ������ ì�ܸԾ�." + "\n" +
                            "������ �� ��Ⱑ ���Դ���. ��Ź ���� �Ź� Ȯ���غ�.";
                break;
            case 2:
                text.text = "��ħ ���� ������ �� �ʰ� �����ϱ� �� �� ���� ����." + "\n" +
                            "���� �Ϸ絵 ������ �� ����! ���⼭ ������ ���� �������� ���ϰ� ������." + "\n" +
                            "���õ� �� �԰� �� ������. ���� ������ ���� �����ϱ� �����غ�.";
                            
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void nextNote()
    {
        Note0.SetActive(false);
        Note1.SetActive(true);
    }
}
