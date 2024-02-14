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
        GameManager.Instance.isDisplayModeEnglish = toggle.isOn;
        GameManager.Instance.SetScore(0);
    }
}
