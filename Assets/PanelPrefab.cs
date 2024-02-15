using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;
using static UnityEngine.GraphicsBuffer;

public class PanelPrefab : MonoBehaviour
{

    public int automata_id;
    string assetRoute;
    Automata automata;
    int quantity;
    string autoname;

    public void SetPanelPrefab(int index) 
    {
        automata_id = index;
        autoname = GameManager.Instance.prefabs[automata_id].GetComponent<Automata>().automata_data.name;
        quantity = GameManager.Instance.prefabs[automata_id].GetComponent<Automata>().quantity;
        assetRoute = "Image/" + GameManager.Instance.prefabs[automata_id].GetComponent<Automata>().automata_data.name;
        transform.GetChild(0).GetComponent<RawImage>().texture = Resources.Load<Texture>(assetRoute);
        transform.GetChild(1).GetComponent<TMP_Text>().text = autoname + " " + "Lv." + quantity.ToString();
        transform.GetChild(2).GetComponent<TMP_Text>().text = "Now:" + DisplayNumber.EnglishNumber(GameManager.Instance.prefabs[automata_id].GetComponent<Automata>().all_production);
        transform.GetChild(3).GetComponent<TMP_Text>().text = "Next:" + DisplayNumber.EnglishNumber(Balancing.Produce[automata_id, quantity]);
        automata = GameManager.Instance.prefabs[automata_id].GetComponent<Automata>();
    }

    void Update()
    {
        quantity = GameManager.Instance.prefabs[automata_id].GetComponent<Automata>().quantity;
        transform.GetChild(1).GetComponent<TMP_Text>().text = autoname + " " + "Lv." + quantity.ToString();
        transform.GetChild(2).GetComponent<TMP_Text>().text = "Now:" + DisplayNumber.EnglishNumber(GameManager.Instance.prefabs[automata_id].GetComponent<Automata>().all_production);
        transform.GetChild(3).GetComponent<TMP_Text>().text = "Next:" + DisplayNumber.EnglishNumber(Balancing.Produce[automata_id, quantity]);
        if (GameManager.Score >= transform.GetChild(5).GetComponent<BuyButtonUITen>().price10)
        {
            transform.GetChild(5).gameObject.SetActive(true);
        }
        else
        {
            transform.GetChild(5).gameObject.SetActive(false);
        }
    }



}
