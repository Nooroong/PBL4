using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Memo_text_ctrl : MonoBehaviour
{
    public TextMeshProUGUI text0, text1, text2, text3, text4, text5;
    GameObject Memo_ctrl;
    GameObject TMPs;
    TextMeshProUGUI tmp0, tmp1, tmp2, tmp3, tmp4, tmp5;


    // tmp0, text0: 쪽지 답장 (PlayerPrefs 키 이름 NoteCp)
    // tmp1, text1: 밥먹기    (PlayerPrefs 키 이름 bap)
    // tmp2, text2: 약먹기    (PlayerPrefs 키 이름 pill)
    // tmp3, text3: 화분 가꾸기 (PlayerPrefs 키 이름 planter)
    // tmp4, text4: 랜덤1     (PlayerPrefs 키 이름 random1)
    // tmp5, text5: 랜덤2     (PlayerPrefs 키 이름 random2)


    // Start is called before the first frame update
    void Awake()
    {
        /* House 씬 Memo_ctrl > TMPS > T0, T1, T2, T3, T4, T5 가져오기 */
        Memo_ctrl = GameObject.Find("Memo_ctrl");
        TMPs = Memo_ctrl.transform.Find("TMPs").gameObject;
        tmp0 = TMPs.transform.Find("T0").gameObject.GetComponent<TextMeshProUGUI>();
        tmp1 = TMPs.transform.Find("T1").gameObject.GetComponent<TextMeshProUGUI>();
        tmp2 = TMPs.transform.Find("T2").gameObject.GetComponent<TextMeshProUGUI>();
        tmp3 = TMPs.transform.Find("T3").gameObject.GetComponent<TextMeshProUGUI>();
        tmp4 = TMPs.transform.Find("T4").gameObject.GetComponent<TextMeshProUGUI>();
        tmp5 = TMPs.transform.Find("T5").gameObject.GetComponent<TextMeshProUGUI>();
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        /* 메모지에 할 일 띄우기 */
        text0.text = tmp0.text;
        text1.text = tmp1.text;
        text2.text = tmp2.text;
        text3.text = tmp3.text;
        text4.text = tmp4.text;
        text5.text = tmp5.text;
    }
}
