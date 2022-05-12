using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//https://wergia.tistory.com/217 (주의: 2D 함수 써야함)

public class HouseCollisionCheck : MonoBehaviour
{
    public Button btn; //돋보기(버튼)
    public static bool click1;
    public static bool click2;
    public Text text;
    public Button meal;
    public List<string> tasks = new List<string>(); //할 일
    public int index = -1;

    private string collisionObj = "null"; //주인공과 충돌한 오브젝트의 이름을 저장하는 변수
    private string[] ign_arr = { "null", "wall", "floor", "phonograph", "sofa" }; //충돌해도 버튼을 활성화 시키지 않는 오브젝트
    private List<string> ign_list = new List<string>(); //ign_arr을 리스트로 변환한 것


    // Start is called before the first frame update
    void Start()
    {
        btn.interactable = false; //버튼 비활성화
        text.gameObject.SetActive(false);
        meal.gameObject.SetActive(false);


        tasks.Add("meditation");
        tasks.Add("walking");
        tasks.Add("cooking");

        //배열을 리스트로
        for (int i = 0; i < ign_arr.Length; i++)
            ign_list.Append(ign_arr[i]);

        index = Random.Range(0, 3); //제외할 일 고르기

        Debug.Log(tasks[index]);

        ign_list.Add(tasks[index]);
        tasks.RemoveAt(index);
    }

    public void BtnOnClick() {
        //이동할 씬 입력해주면 될듯?
        switch (collisionObj) {
            case "bed":
                //SceneManager.LoadScene("");
                break;
            case "fridge":
                SceneManager.LoadScene("Refrigerator");
                break;
            case "cooking":
                SceneManager.LoadScene("TeaTime0");
                break;
            case "frontDoor":
                //SceneManager.LoadScene("");
                break;
            case "meditation":
                SceneManager.LoadScene("meditation test");
                break;
            case "table":
                SceneManager.LoadScene("desk");
                break;
            case "walking":
                SceneManager.LoadScene("Walking");
                break;
            case "window":
                SceneManager.LoadScene("GardenPlant");
                break;
            default:
                //혹여나 잘못 활성화 되는 경우
                break;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision) {
        //충돌 시작 시
        //주인공과 충돌한 오브젝트의 이름을 저장
        collisionObj = collision.gameObject.name;
        
    }

    private void OnCollisionStay2D(Collision2D collision) {
        //충돌이 지속되는 동안
        //충돌한 오브젝트가 씬 이동과 관계있다면 버튼 활성화
        if(!ign_list.Contains(collisionObj)) btn.interactable = true;
        string s = "table";
        if (collisionObj.CompareTo(s) == 0)
        {
            if ((click1 == true) && (click2 == true))
            {
                meal.gameObject.SetActive(true);
                if(meal.gameObject.activeSelf == true)
                {
                    meal.interactable = true;
                }
                

            }
        }
    
    }

    public void Meal()
    {
        click1 = false;
        click2 = false;
    }

    private void OnCollisionExit2D(Collision2D collision) {
        collisionObj = "null";
        btn.interactable = false; //버튼 비활성화
        meal.interactable = false;
    }
}
