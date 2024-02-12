using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySceneManager : MonoBehaviour
{
    private void Start()
    {
        PlayScene();
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