using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Sound_manager : MonoBehaviour
{
    public Button n_btn, c_btn;
    public AudioSource BgSource;
    public AudioClip[] bglist;
    public static Sound_manager instance;

    int tea, Out;
    string s_name = "";
    float fadeInTime = 2.0f;
    float fadeOutTime = 1.0f;
    int cnt = 0;
    
    private void Awake()
    {
        FadeOut fadeOut = new FadeOut();
        tea = -1;
        Out = -1;

        if (instance== null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
            SceneManager.sceneLoaded += OnSceneLoaded;       
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1) //���� ������ �� ���� ����
    {
        Debug.Log("�� �ٲ�");
        cnt += 1;
        if(cnt == 1) //���� ù ���� ���� ���̵� �ƿ�X
        {
            s_name = arg0.name;
            BGSoundPlay(bglist[0]);
        }
        else
        {
            for (int i = 0; i < bglist.Length; i++)
            {
                if (arg0.name == bglist[i].name) //���� main, Walking, meditation �� ����
                {
                    s_name = arg0.name;
                    BGSoundPlay(bglist[i]);
                    break;
                }
                else if (tea != PlayerPrefs.GetInt("Tea") | Out != PlayerPrefs.GetInt("out") //�� ���ñ�, ������ ������, ���� ���� main, Walking, meditation �̾��� ���
                    | s_name != "")
                {
                    s_name = "";

                    tea = PlayerPrefs.GetInt("Tea");
                    Out = PlayerPrefs.GetInt("out");

                    if (PlayerPrefs.GetInt("Tea") == 1)
                    {
                        BGSoundPlay(bglist[3]);
                    }
                    else if (PlayerPrefs.GetInt("out") == 0)
                    {
                        BGSoundPlay(bglist[0]);
                    }
                    else if (PlayerPrefs.GetInt("out") == 1)
                    {
                        switch (PlayerPrefs.GetInt("day"))
                        {
                            case 0:
                                BGSoundPlay(bglist[4]);
                                break;
                            case 1:
                                BGSoundPlay(bglist[5]);
                                break;
                            case 2:
                                BGSoundPlay(bglist[6]);
                                break;
                            case 3:
                                BGSoundPlay(bglist[7]);
                                break;
                        }


                    }
                }
            }
        }



    }
    public void SFXPlay(string sfxName, AudioClip clip) // ȿ���� ��� �Լ�
    {
        GameObject go = new GameObject(sfxName + "Sound");
        AudioSource audioSource =  go.AddComponent<AudioSource>();
        audioSource.clip = clip;
        audioSource.Play();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void BGSoundPlay(AudioClip clip)
    {
        BgSource.clip = clip;
        BgSource.loop = true;
        StartCoroutine(Audio_F.FadeIn(BgSource, fadeInTime));
    }
}
