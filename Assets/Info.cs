using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class Info : MonoBehaviour
{
    public Button btn;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI descriptionText;
    public TextMeshProUGUI productionText;

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
    public void TurnOn(Automata automata)
    {
        gameObject.SetActive(true);
        nameText.text = automata.automata_data.name;
        descriptionText.text = "";
        productionText.text = automata.all_production.ToString();
    }

    public void TurnOff()
    {
        GameManager.Instance.touchManager.LerpCameraAni(Camera.main.transform, new Vector3(0f, 8.79f, -8.95f), new Vector3(33,0,0), false);
        //Camera.main.transform.position = new Vector3(0f, 1f, -10f);
        //GameManager.Instance.touchManager.hitObject?.GetComponent<Outline>().TurnOffOutline();
    }
    public void TurnOffObject()
    {
        gameObject.SetActive(false);
    }

}
