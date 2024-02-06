using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class PanelPrefab : MonoBehaviour
{

    public int automata_id;
    string str;


    public void SetPanelPrefab(int index) 
    {
        automata_id = index;
        str = "Image/" + GameManager.Instance.prefabs[automata_id].GetComponent<Automata>().automata_data.name;
        transform.GetChild(0).GetComponent<RawImage>().texture = Resources.Load<Texture>(str);
        transform.GetChild(1).GetComponent<TMP_Text>().text = GameManager.Instance.prefabs[automata_id].GetComponent<Automata>().automata_data.name;
        transform.GetChild(2).GetComponent<TMP_Text>().text = GameManager.Instance.prefabs[automata_id].GetComponent<Automata>().automata_data.id.ToString();
    }

    public void onclick()
    {
        BuyButtonUI.target = automata_id;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
