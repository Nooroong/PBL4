using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//https://wergia.tistory.com/217 (����: 2D �Լ� �����)

public class HouseCollisionCheck : MonoBehaviour
{
    public Button btn; //������(��ư)
    public static bool click1;
    public static bool click2;
    public Text text;
    public Button meal;
    

    private string collisionObj = "null"; //���ΰ��� �浹�� ������Ʈ�� �̸��� �����ϴ� ����
    private string[] ign = { "null", "wall", "floor", "phonograph", "sofa" }; //�浹�ص� ��ư�� Ȱ��ȭ ��Ű�� �ʴ� ������Ʈ

    // Start is called before the first frame update
    void Start()
    {
        
        btn.interactable = false; //��ư ��Ȱ��ȭ
        meal.gameObject.SetActive(false);
        text.gameObject.SetActive(false);


    }

    public void BtnOnClick() {
        //�̵��� �� �Է����ָ� �ɵ�?
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
                SceneManager.LoadScene("Walking");
                break;
            case "window":
                SceneManager.LoadScene("GardenPlant");
                break;
            default:
                //Ȥ���� �߸� Ȱ��ȭ �Ǵ� ���
                break;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision) {
        //�浹 ���� ��
        //���ΰ��� �浹�� ������Ʈ�� �̸��� ����
        collisionObj = collision.gameObject.name;
        
    }

    private void OnCollisionStay2D(Collision2D collision) {
        //�浹�� ���ӵǴ� ����
        //�浹�� ������Ʈ�� �� �̵��� �����ִٸ� ��ư Ȱ��ȭ
        if(!ign.Contains(collisionObj)) btn.interactable = true;
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
        btn.interactable = false; //��ư ��Ȱ��ȭ
        meal.interactable = false;
    }
}
