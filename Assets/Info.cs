using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class Info : MonoBehaviour
{
    public Button btn;
    public TextMeshProUGUI text;

    /*public void SetActive(bool b, string str = "")
    {
        gameObject.SetActive(b);

        if (b)
        {
            text.text = str;
        }
        else
        {
            ResetCamera();
        }
    }

    public void ResetCamera()
    {
        Camera.main.transform.position = new Vector3(0f, 1f, -10f);
    }*/
    public void TurnOn(string str)
    {
        gameObject.SetActive(true);
        text.text = str;
    }

    public void TurnOff()
    {
        StartCoroutine(GameManager.Instance.touchManager.LerpCamera(Camera.main.transform.position, new Vector3(0f, 1f, -10f), false)); 
        //Camera.main.transform.position = new Vector3(0f, 1f, -10f);
        //GameManager.Instance.touchManager.hitObject?.GetComponent<Outline>().TurnOffOutline();
    }
    public void TurnOffObject()
    {
        gameObject.SetActive(false);
    }

}
