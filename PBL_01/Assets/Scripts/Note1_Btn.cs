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
                note.text = "지구에서 지낼 거처를 마련해주셔서 감사해요." + "\n" +
                            "약 잊지 않고 먹을게요. 우주선 수리할 동안만 신세지겠습니다." + "\n" +
                            "챙겨주셔서 감사합니다!" + "\n";

                b1text.text = "퇴근하시고 피곤하실텐데 일찍 주무세요!";
                b2text.text = "말썽 안 피우고 잘 지낼게요!";
                b3text.text = "내일은 볼 수 있으면 좋겠어요!";
                break;
            case 3:
                note.text = "어제 길거리에 쓰러진 사람을 봤어요." + "\n" +
                            "과거의 기억이 잠시 떠올라 겁이 났지만, 용기를 내서 구급차를 부르고 응급처치를 했어요. 많은 일이 있던 하루였어요." + "\n";


                b1text.text = "매일 쪽지 남겨 주셔서 감사해요!";
                b2text.text = "오늘은 무슨 일이 일어날지 걱정돼요.";
                b3text.text = "오늘은 꼭 볼 수 있었으면 좋겠어요.";
                break;
            case 4:
                note.text = "쪽지 잘 읽었어요. 어... 무슨 느낌이라고 해야하지..." + "\n" +
                            "되게 부끄럽네요. 제가 아니었어도 누구든 했어야 했을 일이었을 거예요. 다른 사람에게 오랜만에 칭찬을 들어서 새롭고, 스스로 변하는 게 느껴져요." + "\n";


                b1text.text = "내일 아침 쪽지도 기대할게요.";
                b2text.text = "지구에서의 생활이 점점 적응되고 있어요.";
                b3text.text = "오늘은 볼 수 있겠죠?";
                break;
            case 5:
                note.text = "아침밥 감사해요! 밥 진짜 맛있었어요." + "\n" +
                            "이제 떠날 날이 얼마 남지 않았네요. 제 얘기를 듣고 기뻤다니 저도 이 쪽지를 보면서 행복해요. 마지막까지 잘 지낼게요." + "\n";

                btn1.gameObject.SetActive(false);
                btn2.gameObject.SetActive(false);
                btn3.gameObject.SetActive(false);
                btn4.gameObject.SetActive(true);
                b4text.text = "지금까지 잘 챙겨주셔서 감사했습니다. 나중에 만나게 되면 제가 음식 해드릴게요!";

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
