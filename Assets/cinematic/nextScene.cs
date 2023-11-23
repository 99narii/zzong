using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class nextScene : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    private void Start()
    {
        videoPlayer.loopPointReached += OnVideoPlaybackComplete;
    }
    private void OnVideoPlaybackComplete(VideoPlayer vp)
    {
        // ���� ����� �Ϸ�Ǹ� ȣ��˴ϴ�.
        // ���� ������ ��ȯ�մϴ�.
        SceneManager.LoadScene("1_Cave");
    }
}
