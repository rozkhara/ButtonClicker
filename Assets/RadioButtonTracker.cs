using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadioButtonTracker : MonoBehaviour
{
    Toggle toggle;
    private void Awake()
    {
        toggle = GetComponent<Toggle>();
    }
    public void CheckValue()
    {
        if (toggle.isOn)
        {
            GameManager.Instance.isDisplayModeEnglish = true;
            GameManager.Instance.SetScore(0);
        }
        else
        {
            GameManager.Instance.isDisplayModeEnglish = false;
            GameManager.Instance.SetScore(0);
        }
    }
}
