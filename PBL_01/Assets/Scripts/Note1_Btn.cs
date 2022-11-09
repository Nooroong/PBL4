using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Note1_Btn : MonoBehaviour
{
    public GameObject Note1, Note2;
    public Text ps;
    public Button btn1, btn2, btn3, btn4;
    public Button next;
    public Text note;
    public Text b1text, b2text, b3text, b4text;

    // Start is called before the first frame update
    void Start()
    {
        next.interactable = false;
        switch (PlayerPrefs.GetInt("day"))
        {
            case 2:
                note.text = "�������� ���� ��ó�� �������ּż� �����ؿ�." + "\n" +
                            "�� ���� �ʰ� �����Կ�. ���ּ� ������ ���ȸ� �ż����ڽ��ϴ�." + "\n" +
                            "ì���ּż� �����մϴ�!" + "\n";

                b1text.text = "����Ͻð� �ǰ��Ͻ��ٵ� ���� �ֹ�����!";
                b2text.text = "���� �� �ǿ�� �� �����Կ�!";
                b3text.text = "������ �� �� ������ ���ھ��!";
                break;
            case 3:
                note.text = "���� ��Ÿ��� ������ ����� �þ��." + "\n" +
                            "������ ����� ��� ���ö� ���� ������, ��⸦ ���� �������� �θ��� ����óġ�� �߾��. ���� ���� �ִ� �Ϸ翴���." + "\n";


                b1text.text = "���� ���� ���� �ּż� �����ؿ�!";
                b2text.text = "������ ���� ���� �Ͼ�� �����ſ�.";
                b3text.text = "������ �� �� �� �־����� ���ھ��.";
                break;
            case 4:
                note.text = "���� �� �о����. ��... ���� �����̶�� �ؾ�����..." + "\n" +
                            "�ǰ� �β����׿�. ���� �ƴϾ�� ������ �߾�� ���� ���̾��� �ſ���. �ٸ� ������� �������� Ī���� �� ���Ӱ�, ������ ���ϴ� �� ��������." + "\n";


                b1text.text = "���� ��ħ ������ ����ҰԿ�.";
                b2text.text = "���������� ��Ȱ�� ���� �����ǰ� �־��.";
                b3text.text = "������ �� �� �ְ���?";
                break;
            case 5:
                note.text = "��ħ�� �����ؿ�! �� ��¥ ���־����." + "\n" +
                            "���� ���� ���� �� ���� �ʾҳ׿�. �� ��⸦ ��� �⻼�ٴ� ���� �� ������ ���鼭 �ູ�ؿ�. ���������� �� �����Կ�." + "\n";

                btn1.gameObject.SetActive(false);
                btn2.gameObject.SetActive(false);
                btn3.gameObject.SetActive(false);
                btn4.gameObject.SetActive(true);
                b4text.text = "���ݱ��� �� ì���ּż� �����߽��ϴ�. ���߿� ������ �Ǹ� ���� ���� �ص帱�Կ�!";

                break;
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Btn1()
    {
        ps.text ="ps. " + b1text.text;
        PlayerPrefs.SetString("note", (note.text+"\n"+ps.text));
        next.interactable = true;
    }
    public void Btn2()
    {
        ps.text = "ps. " + b2text.text;
        PlayerPrefs.SetString("note", (note.text + "\n" + ps.text));
        next.interactable = true;
    }
    public void Btn3()
    {
        ps.text = "ps. " + b3text.text;
        PlayerPrefs.SetString("note", (note.text + "\n" + ps.text));
        next.interactable = true;
    }
    public void Btn4()
    {
        ps.text = "ps. " + b4text.text;
        PlayerPrefs.SetString("note", (note.text + "\n" + ps.text));
        next.interactable = true;
    }
    public void nextNote()
    {
        StartCoroutine(nextNote_co(next));
    }

    IEnumerator nextNote_co(Button obj)
    {
        obj.GetComponent<AudioSource>().Play();
        yield return new WaitUntil(() => !obj.GetComponent<AudioSource>().isPlaying);
        Note1.SetActive(false);
        Note2.SetActive(true);
    }
}
