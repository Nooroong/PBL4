/*
 https://m.blog.naver.com/PostView.naver?isHttpsRedirect=true&blogId=2983934&logNo=220987664525
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour {
    public Text label; //���� �Է� ĭ
    public Text timeText; //Ÿ�̸� �ؽ�Ʈ
    private float time = 10f; //���ѽð�


    // Update is called once per frame
    void Update() {
        //�ð��� ���Ұų� ������ �Է����� ���� ���, �����Ӹ��� �ð��� ����
        if (time > 0f && (label.GetComponent<Text>().text != "119")) {
            time -= Time.deltaTime;
            timeText.text = time.ToString();
            timeText.text = string.Format("{0:N2}", time);
        } else {
            //�ð��� �� �ǰų� ������ �Է��� ���, ��ư���� ��Ȱ��ȭ

            //�ð��� ������ ������ ��츦 ����
            if (time <= 0) timeText.text = "0.00";

            //���� ��ư��
            GameObject BtnsGrid = GameObject.Find("BtnsGrid"); //����� �ڽĵ��� ���� ��Ȱ��ȭ
            for (int i = 0; i < BtnsGrid.transform.childCount; i++) {
                var btn = BtnsGrid.transform.GetChild(i);
                btn.GetComponent<Button>().interactable = false;
            }
            //����� ��ư
            GameObject.Find("backspace").GetComponent<Button>().interactable = false;
        }
    }
}
