using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class DialogManager : MonoBehaviour, IPointerDownHandler
{
    public Image image;
    public GameObject button;
    public Text dialogText;
    public GameObject next;
    public CanvasGroup dialogGroup;
    public Queue<string> sentences;

    public string[] Set_sentences;

    private string currentSentence;

    public float typingSpeed = 0.08f;
    public static bool istyping;

    public static DialogManager instance;

    int cnt = -1;
    float time = 0f;
    float F_time = 1f;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        button.gameObject.SetActive(false);
        sentences = new Queue<string>();
        instance.Ondialogue(Set_sentences);
    }

    IEnumerator FadeIn()
    {
        image.gameObject.SetActive(true);
        time = 0f;
        Color alpha = image.color;

        while (alpha.a < 1f)
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(0, 1, time);
            image.color = alpha;
            yield return null;
        }
        yield return null;
        button.gameObject.SetActive(true);
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
        if(sentences.Count != 0)
        {
            cnt++;
            currentSentence = sentences.Dequeue();
            istyping = true;
            next.SetActive(false);
            StartCoroutine(Typing(currentSentence));

        }
        else
        {
            cnt++;
            dialogGroup.alpha = 0;
            dialogGroup.blocksRaycasts = false;
            StartCoroutine(FadeIn());

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

    public static implicit operator DialogManager(DialogManager_House_Tutorial v)
    {
        throw new NotImplementedException();
    }
}
