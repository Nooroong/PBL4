using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using UnityEngine;
# if PLATFORM_ANDROID
using UnityEngine.Android;
# endif

// https://young-94.tistory.com/44 ����

public class MicrophonePermission : MonoBehaviour
{
    public GameObject Popup;
    public Text Popup_txt;

    private int MicCheck = 0;

    public Button Cha, Lav, Jas, S_Btn;

    void Start()
    {
#if PLATFORM_ANDROID
        if (Permission.HasUserAuthorizedPermission(Permission.Microphone))
        {
            // ����ڰ� ����ũ ��� ������ ������� ��
        }
        else // ����ڰ� ����ũ ��� ������ ������� �ʾ��� ��
        {
            // ȯ�漳���� Ȩ ��ư �̿ܿ� ��Ȱ��ȭ
            Cha.interactable = false;
            Lav.interactable = false;
            Jas.interactable = false;
            S_Btn.interactable = false;
            StartCoroutine("MicrophonePermissionRequest");
#endif
        }
    }

    IEnumerator MicrophonePermissionRequest()
    {
        if (MicCheck == 0)
        {
            // ����ڿ��� ����ũ ��� ���� ��û
            Permission.RequestUserPermission(Permission.Microphone);
        }
        else if(MicCheck != 0) // ����ڰ� ����ũ ��� ������ �ź� ���� ��
        {
            // ���� ����� ���� ���� �˾�â ����
            Popup_txt.text = "����ũ�� ����� �� �����ϴ�. " +
                "������ ������ ���� �ܸ����� " +
                "\"���� > ���ø����̼� > ���� �� ������ > ����> ����ũ\"�� ������� �������ּ���.";

            if (!Popup.activeInHierarchy) Popup.SetActive(true);

        }

        ++MicCheck;

        yield return new WaitForSeconds(0.2f);
        yield return new WaitUntil(() => Application.isFocused == true); 
        //������ ���� ���¿��� ������ ���� �ʰ� ���� ��Ŀ�� ������ ������ ��ٸ�

        if (!Permission.HasUserAuthorizedPermission(Permission.Microphone)) //������ ������� �ʾҴٸ� �ڷ�ƾ �ٽ� ����
        {
            StartCoroutine("MicrophonePermissionRequest");
            yield break;
        }

        //������ ������� ��� ��ư Ȱ��ȭ
        Cha.interactable = true;
        Lav.interactable = true;
        Jas.interactable = true;
        S_Btn.interactable = true;

        Popup.SetActive(false);
    }

}
