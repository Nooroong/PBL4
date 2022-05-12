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
    public List<string> tasks = new List<string>(); //�� ��
    public int index = -1;

    private string collisionObj = "null"; //���ΰ��� �浹�� ������Ʈ�� �̸��� �����ϴ� ����
    private string[] ign_arr = { "null", "wall", "floor", "phonograph", "sofa" }; //�浹�ص� ��ư�� Ȱ��ȭ ��Ű�� �ʴ� ������Ʈ
    private List<string> ign_list = new List<string>(); //ign_arr�� ����Ʈ�� ��ȯ�� ��


    // Start is called before the first frame update
    void Start()
    {
        btn.interactable = false; //��ư ��Ȱ��ȭ
        text.gameObject.SetActive(false);
        meal.gameObject.SetActive(false);


        tasks.Add("meditation");
        tasks.Add("walking");
        tasks.Add("cooking");

        //�迭�� ����Ʈ��
        for (int i = 0; i < ign_arr.Length; i++)
            ign_list.Append(ign_arr[i]);

        index = Random.Range(0, 3); //������ �� ����

        Debug.Log(tasks[index]);

        ign_list.Add(tasks[index]);
        tasks.RemoveAt(index);
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
        btn.interactable = false; //��ư ��Ȱ��ȭ
        meal.interactable = false;
    }
}
