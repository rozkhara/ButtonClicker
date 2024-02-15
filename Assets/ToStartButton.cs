using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToStartButton : MonoBehaviour
{

    public void Set_onclick()
    {
        SceneManager.LoadScene("Start");
        SoundManager.Instance.PlaySFXSound("MenuSound");

    }

}
