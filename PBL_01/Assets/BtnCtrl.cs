using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnCtrl : MonoBehaviour
{
    private Button btn;

    public void Start() {
        //�Ʒ� ����ǥ �ȿ� �ش�Ǵ� ��ư ������Ʈ�� �̸��� ���´�.
        btn = GameObject.Find("Button").GetComponent<Button>();
        btn.interactable = false; //��ư ��ȣ�ۿ� ��Ȱ��ȭ
    }

    public void BtnState() {
        //!�Ʒ� ���� ����!
        if (true) { //��� �׸��� üũ�� ���
            btn.interactable = true; //��ư ��ȣ�ۿ� Ȱ��ȭ
        } else { //�׸��� ��� üũ���� ���� ���
            btn.interactable = false; //��ư ��ȣ�ۿ� ��Ȱ��ȭ
        }
    }
}
