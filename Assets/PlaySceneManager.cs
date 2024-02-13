using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySceneManager : MonoBehaviour
{
    public float currentTime;
    public float startTime;
    private void Start()
    {
        PlayScene();
        startTime = Time.time;
    }

    private void PlayScene()
    {
        if (GameManager.Instance.isNewGame)
        {
            GameManager.Instance.StartNewGame();
        }
        else
        {
            GameManager.Instance.StartLoadGame();
        }
    }
}
