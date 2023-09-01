using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehavior : MonoBehaviour
{
    private void OnMouseDown()
    {
        gameObject.transform.Translate(new Vector3(0f, -0.5f, 0f) * transform.lossyScale.x);
        SoundManager.Instance.PlaySFXSound("ButtonDown");
    }

    private void OnMouseUp()
    {
        gameObject.transform.Translate(new Vector3(0f, 0.5f, 0f) * transform.lossyScale.x);
        SoundManager.Instance.PlaySFXSound("ButtonUp");
    }

    private void OnMouseUpAsButton()
    {
        
    }
}