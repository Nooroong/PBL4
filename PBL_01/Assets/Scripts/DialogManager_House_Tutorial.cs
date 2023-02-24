using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DialogManager_House_Tutorial : MonoBehaviour, IPointerDownHandler
{
    public List<GameObject> obj_list = new List<GameObject>();
    public GameObject button;
    public Text dialogText;
    public GameObject next;
    public CanvasGroup dialogGroup;
    public Queue<string> sentences;

    int i = 0;

    public string[] Set_sentences;

    private string currentSentence;

    public float typingSpeed = 0.08f;
    public static bool istyping;

    public static DialogManager_House_Tutorial instance;

    int cnt = -1;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        sentences = new Queue<string>();
        instance.Ondialogue(Set_sentences);

        dialogGroup.gameObject.SetActive(true);

        foreach(GameObject obj in obj_list) {
            obj.SetActive(false);
        }
    }

    public void Ondialogue(string[] lines)
    {
        sentences.Clear();
        foreach(string line in lines)
        {
            sentences.Enqueue(line);
        }
        dialogGroup.alpha = 1;
        dialogGroup.blocksRaycasts = true;

        NextSentence();
    }

    public void NextSentence()
    {
        if (sentences.Count != 0)
        {
            currentSentence = sentences.Dequeue();

            istyping = true;
            next.SetActive(false);
            StartCoroutine(Typing(currentSentence));

            switch(i) {
                case 1:
                    this.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 500, 0);
                    obj_list[0].gameObject.SetActive(true);
                    // image.GetComponent<Image>().sprite = Resources.Load("PrologueImage\\5", typeof(Sprite)) as Sprite;
                    break;
                case 2:
                    this.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 0);
                    obj_list[0].gameObject.SetActive(false);
                    break;
                case 3:
                    obj_list[1].gameObject.SetActive(true);
                    break;
                case 4:
                    obj_list[1].gameObject.SetActive(false);
                    obj_list[2].gameObject.SetActive(true);
                    break;
                case 5:
                    obj_list[3].gameObject.SetActive(true);
                    break;
                case 6:
                    obj_list[2].gameObject.SetActive(false);
                    obj_list[3].gameObject.SetActive(false);
                    obj_list[4].gameObject.SetActive(true);
                    break;
                case 7:
                    obj_list[4].gameObject.SetActive(false);
                    obj_list[5].gameObject.SetActive(true);
                    break;
            }

            i++;
        }
        else
        {
            obj_list[5].gameObject.SetActive(false);
            
            dialogGroup.alpha = 0;
            dialogGroup.blocksRaycasts = false;
            button.gameObject.SetActive(true);
        }
    }

    IEnumerator Typing(string line)
    {
        dialogText.text = "";
        foreach(char letter in line.ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    void Update()
    {
       if(dialogText.text.Equals(currentSentence))
        {
            next.SetActive(true);
            istyping = false;
        }
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        if(!istyping) {
            StartCoroutine(UntilPlayback(next));
        }

    }

    public int Cnt()
    {
        return cnt;
    }

    
    IEnumerator UntilPlayback(GameObject obj)
    {
        obj.GetComponent<AudioSource>().Play();
        yield return new WaitUntil(() => !obj.GetComponent<AudioSource>().isPlaying);
        NextSentence();
    }
}
