using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadSceneManager : MonoBehaviour
{
    [SerializeField]
    Image progressBar;

    private void Start()
    {
        StartCoroutine(LoadingScene());
    }

    public static void LoadScene(bool isNew)
    {
        GameManager.Instance.isNewGame = isNew;
        SceneManager.LoadScene("Loading");
    }

    IEnumerator LoadingScene()
    {
        yield return null;

        AsyncOperation op = SceneManager.LoadSceneAsync("Play");
        op.allowSceneActivation = false;

        float timer = 0.0f;
        while (!op.isDone)
        {
            yield return null;

            timer += Time.deltaTime; 
            if (op.progress < 0.9f) 
            { 
                progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, op.progress, timer); 
                if (progressBar.fillAmount >= op.progress) 
                { 
                    timer = 0f; 
                } 
            }
            else 
            {
                progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, 1f, timer); 
                if (progressBar.fillAmount == 1.0f) 
                {
                    op.allowSceneActivation = true;
                    yield break;
                } 
            }
        }
    }
}