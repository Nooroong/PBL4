using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Note0_Btn : MonoBehaviour
{
    public GameObject Note0, Note1;
    public Button btn;
    public Text text;
    public Text ps;

    // Start is called before the first frame update
    void Start()
    {
        ps.gameObject.SetActive(false);
        switch (PlayerPrefs.GetInt("day"))
        {
            case 2:

                text.text = "안녕, 다시 한 번 지구에 온걸 환영해." + "\n"+
                            "나는 아침 일찍 출근하고 저녁 늦게 퇴근해서 아마 너와 마추질 일은 얼마 없을거야." + "\n" +
                            "대신 매일 아침마다 너한테 쪽지를 남길게." + "\n" +
                            "ps. 밥은 냉장고에 있으니 꺼내서 챙겨먹어." + "\n" +
                            "뉴스에 너 얘기가 나왔더라. 식탁 위에 신문 확인해봐.";
                break;
            case 3:
                
                if(PlayerPrefs.GetString("note").Contains("퇴근하시고 피곤하실텐데 일찍 주무세요!"))
                {
                    ps.text = "낯선 곳에 와서 여러모로 힘들텐데 제대로 챙겨주지 못해 미안해.";
                }
                else if(PlayerPrefs.GetString("note").Contains("말썽 안 피우고 잘 지낼게요!"))
                {
                    ps.text = "나 없는 동안 뭐 하고 지냈는지 궁금하구나.";
                }
                else
                {
                    ps.text = "나도 볼 수 있으면 좋겠구나.";
                }
                text.text = "아침 일찍 나가고 밤 늦게 들어오니까 얼굴 볼 일이 적네." + "\n" +
                            "오늘 하루도 조심히 잘 지내! 여기서 지내는 동안 마음놓고 편하게 있으렴." + "\n" +
                            "오늘도 밥 먹고 약 잊지마. 오늘 마을에 축제 열리니까 구경해봐." + "\n" +
                            ps.text;
                break;
            case 4:

                if (PlayerPrefs.GetString("note").Contains("매일 쪽지 남겨 주셔서 감사해요!"))
                {
                    ps.text = "얼굴도 못 보는데 이렇게라도 서로 얘기해야지.";
                }
                else if (PlayerPrefs.GetString("note").Contains("오늘은 무슨 일이 일어날지 걱정돼요."))
                {
                    ps.text = "너무 걱정하지마. 용기를 내.";
                }
                else
                {
                    ps.text = "잘하면 오늘은 퇴근이 빨라질 수도 있어.";
                }
                text.text = "여러가지 일들이 있었구나. 여기 온지 얼마 되지도 않아서 힘들었을 텐데 고생 많았어." + "\n" +
                            "아, 한 가지 부탁할게 있어. 식재료가 떨어져서 근처 마트에서 사다줬으면 해." + "\n" +
                            "식탁 위에 돈이랑 목록 적어 놓은 포스트잇 붙여놨어 부탁할게, 고마워." + "\n" +
                            ps.text;
                break;
            case 5:

                ps.text = "ps. 오늘이 마지막이구나. 오늘은 일찍 끝내고 들어가마.";

                text.text = "어제 너가 골목에서 어떤 아이를 도와줬다는 얘기를 듣고, 참 기뻤어." + "\n" +
                            "지구에 처음 왔을 때랑 많이 달라진 것 같구나. 떠날 날이 얼마 남지 않았다는 게 느껴져." + "\n" +
                            "오늘도 약 챙겨 먹고, 밥은 내가 식탁에 차려놨어." + "\n" +
                            "입맛에 맞을지 모르겠지만 잘 먹으면 좋겠다." + "\n" +
                            ps.text;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void nextNote()
    {
        StartCoroutine(nextNote_co(btn));
    }

    IEnumerator nextNote_co(Button obj)
    {
        obj.GetComponent<AudioSource>().Play();
        yield return new WaitUntil(() => !obj.GetComponent<AudioSource>().isPlaying);
        Note0.SetActive(false);
        Note1.SetActive(true);
    }
}
