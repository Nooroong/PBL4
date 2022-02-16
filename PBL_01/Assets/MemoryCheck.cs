using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MemoryCheck : MonoBehaviour {
    public Image ch; //üũ �̹��� ����

    private void Update() {
        if(Input.GetMouseButtonUp(0)) {
            int cnt = transform.childCount; //�ش� ������Ʈ�� �ڽ� ��

            //���� ����� 3���̹Ƿ� �ϴ� ���ǿ� 3 �̻��� ����
            if (cnt >= 3) {
                for (int i = 0; i < cnt; i++) {
                    //�̸��� bad�� ���� ���� �ڽ��� �ִٸ�
                    if (!transform.GetChild(i).name.Contains("bad")) {
                        ch.gameObject.SetActive(false); //üũ �̹��� ��Ȱ��ȭ
                        return; //�˻� ���� ������
                    }
                }
                ch.gameObject.SetActive(true); //�ڽ��� ��� bad memory��� ���.(�̹��� Ȱ��ȭ)
            } else { //����� 2�� ������ ���
                ch.gameObject.SetActive(false);
            }
        }
        
    }
}
