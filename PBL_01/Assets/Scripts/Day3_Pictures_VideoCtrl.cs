using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class Day3_Pictures_VideoCtrl : MonoBehaviour
{
    public RawImage mScreen = null;
    public VideoPlayer mVideoPlayer = null;
    public Image Panel;

    float time = 0f;
    float F_time = 1f;
    
    void Start() {
        Panel.gameObject.SetActive(false);

        if (mScreen != null && mVideoPlayer != null) {
            mVideoPlayer.loopPointReached += CheckOver; //���� �������� Ȯ��(https://mentum.tistory.com/170)
            // ���� �غ� �ڷ�ƾ ȣ��
            StartCoroutine(PrepareVideo());
        }
    }

    protected IEnumerator PrepareVideo() {
        // ���� �غ�
        mVideoPlayer.Prepare();

        // ������ �غ�Ǵ� ���� ��ٸ�
        while (!mVideoPlayer.isPrepared) {
            yield return new WaitForSeconds(0.5f);
        }

        // VideoPlayer�� ��� texture�� RawImage�� texture�� �����Ѵ�
        mScreen.texture = mVideoPlayer.texture;
    }

    public void PlayVideo() {
        if (mVideoPlayer != null && mVideoPlayer.isPrepared) {
            // ���� ���
            mVideoPlayer.Play();
        }
    }

    public void StopVideo() {
        if (mVideoPlayer != null && mVideoPlayer.isPrepared) {
            // ���� ����
            mVideoPlayer.Stop();
        }
    }

    void CheckOver(UnityEngine.Video.VideoPlayer vp) {
        Invoke("F_Out", 0.5f); //���� ������ ���� ������ �Ѿ
    }


    public void F_Out() {
        StartCoroutine(FadeOutFlow());
    }

    IEnumerator FadeOutFlow() {
        Panel.gameObject.SetActive(true);
        time = 0f;
        Color alpha = Panel.color;

        while (alpha.a < 1f) {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(0, 1, time);
            Panel.color = alpha;
            yield return null;
        }
        yield return null;
        NextScene();
    }
    void NextScene() {
        SceneManager.LoadScene("Day3_Pass");
    }
}
