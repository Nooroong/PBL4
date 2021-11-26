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

    private string collisionObj = "null"; //주인공과 충돌한 오브젝트의 이름을 저장하는 변수
    private string[] ign = { "null", "wall", "floor", "phonograph", "sofa" }; //충돌해도 버튼을 활성화 시키지 않는 오브젝트

    // Start is called before the first frame update
    void Start()
    {
        btn.interactable = false; //버튼 비활성화
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
                //SceneManager.LoadScene("");
                break;
            case "table":
                SceneManager.LoadScene("desk");
                break;
            case "walking":
                //SceneManager.LoadScene("");
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
        if(!ign.Contains(collisionObj)) btn.interactable = true;
            
    }
    private void OnCollisionExit2D(Collision2D collision) {
        collisionObj = "null";
        btn.interactable = false; //버튼 비활성화
    }
}
