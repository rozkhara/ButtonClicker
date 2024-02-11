using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StartButtonBehavior : MonoBehaviour
{
    private Vector3 initPos;
    private Vector3 pressedPos;
    private bool isDown = false;
    public GameObject inputPanel;

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
            TurnOnPanel(true);
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

    private void TurnOnPanel(bool active)
    {
        inputPanel.SetActive(active);
    }

    public void LoadPlayScene()
    {
        if (GameManager.Instance.factoryName != "" && GameManager.Instance.userName != "")
        {
            GameManager.Instance.StartNewGame();
        }
    }
}
