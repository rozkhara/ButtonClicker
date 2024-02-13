using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SettingButtonBehavior : MonoBehaviour
{
    private Vector3 initPos;
    private Vector3 pressedPos;
    private bool isDown = false;
    public GameObject settingPanel;

    private void Awake()
    {
        initPos = gameObject.transform.position;
        pressedPos = gameObject.transform.position + new Vector3(0f, -0.5f, 0f) * transform.lossyScale.x;
    }

    private void OnMouseDown()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            SoundManager.Instance.PlaySFXSound("ButtonDown");
            this.gameObject.transform.position = pressedPos;
            isDown = true;
            settingPanel.SetActive(true);
        }
    }

    private void OnMouseUp()
    {
        if (isDown)
        {
            SoundManager.Instance.PlaySFXSound("ButtonUp");
            this.gameObject.transform.position = initPos;
            isDown = false; 
        }
    }
}
