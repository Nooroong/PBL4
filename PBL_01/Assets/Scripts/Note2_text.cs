using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Note2_text : MonoBehaviour
{
    GameObject Memo_ctrl;

    public Text text;
    public Text note, ps;
    public Button exit;

    // Start is called before the first frame update
    void Start()
    {
        text.text = PlayerPrefs.GetString("note");

        //메모 가져오기
        Memo_ctrl = GameObject.Find("Memo_ctrl");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Exit()
    {

        StartCoroutine(Exit_co(exit));
    }

    IEnumerator Exit_co(Button obj)
    {
        obj.GetComponent<AudioSource>().Play();
        yield return new WaitUntil(() => !obj.GetComponent<AudioSource>().isPlaying);
        Memo_ctrl.gameObject.GetComponent<Memo_dontdestroy>().Reply();
        SceneManager.LoadScene("desk");
    }
}
