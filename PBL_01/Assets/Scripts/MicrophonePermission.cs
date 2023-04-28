using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using UnityEngine;
# if PLATFORM_ANDROID
using UnityEngine.Android;
# endif

// https://young-94.tistory.com/44 참조

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
            // 사용자가 마이크 사용 권한을 허용했을 때
        }
        else // 사용자가 마이크 사용 권한을 허용하지 않았을 때
        {
            // 환경설정과 홈 버튼 이외에 비활성화
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
            // 사용자에게 마이크 사용 권한 요청
            Permission.RequestUserPermission(Permission.Microphone);
        }
        else if(MicCheck != 0) // 사용자가 마이크 사용 권한을 거부 했을 때
        {
            // 권한 허용을 위해 설명 팝업창 띄우기
            Popup_txt.text = "마이크를 사용할 수 없습니다. " +
                "게임의 진행을 위해 단말기의 " +
                "\"설정 > 애플리케이션 > 비욘드 더 갤럭시 > 권한> 마이크\"를 허용으로 설정해주세요.";

            if (!Popup.activeInHierarchy) Popup.SetActive(true);

        }

        ++MicCheck;

        yield return new WaitForSeconds(0.2f);
        yield return new WaitUntil(() => Application.isFocused == true); 
        //권한이 없는 상태에서 오류가 나지 않게 앱이 포커스 상태일 떄까지 기다림

        if (!Permission.HasUserAuthorizedPermission(Permission.Microphone)) //권한을 허용하지 않았다면 코루틴 다시 시작
        {
            StartCoroutine("MicrophonePermissionRequest");
            yield break;
        }

        //권한을 허용했을 경우 버튼 활성화
        Cha.interactable = true;
        Lav.interactable = true;
        Jas.interactable = true;
        S_Btn.interactable = true;

        Popup.SetActive(false);
    }

}
