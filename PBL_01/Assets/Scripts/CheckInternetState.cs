using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckInternetState : MonoBehaviour
{
    public Text net_text;

    void Update() {
        if(Application.internetReachability == NetworkReachability.NotReachable) {
            net_text.text = "인터넷 연결 상태를 확인해 주세요.";
        } else {
            net_text.text = "";
        }
    }
}
