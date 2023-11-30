using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehavior : MonoBehaviour
{
    private void OnMouseDown()
    {
        SoundManager.Instance.PlaySFXSound("ButtonDown");
        gameObject.transform.Translate(new Vector3(0f, -0.5f, 0f) * transform.lossyScale.x);
        GameManager.Instance.SetScore(1);
    }

    private void OnMouseUp()
    {
        SoundManager.Instance.PlaySFXSound("ButtonUp");
        gameObject.transform.Translate(new Vector3(0f, 0.5f, 0f) * transform.lossyScale.x);
    }

    private void OnMouseUpAsButton()
    {
        
    }
}