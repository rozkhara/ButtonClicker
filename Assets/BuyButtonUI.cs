using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BuyButtonUI : MonoBehaviour
{
    public static int target;
    public int quatity;
    public TMP_Text button;
    public long production;
    public long price;

    private void Start()
    {
        target = transform.parent.GetComponent<PanelPrefab>().automata_id;
        quatity = GameManager.Instance.prefabs[target].GetComponent<Automata>().quantity;
        price = Balancing.Cost[target, quatity + 1];
        if (GameManager.Instance.isDisplayModeEnglish)
        {
            button.text = DisplayNumber.EnglishNumber(price);
        }
        else
        {
            button.text = DisplayNumber.ExponentNumber(price);
        }
    }

    public void onclick()
    {
        target = transform.parent.GetComponent<PanelPrefab>().automata_id;
        GameManager.Instance.store.BuyAutomata(target);
        quatity = GameManager.Instance.prefabs[target].GetComponent<Automata>().quantity;
        price = Balancing.Cost[target, quatity + 1];
        if (GameManager.Instance.isDisplayModeEnglish)
        {
            button.text = DisplayNumber.EnglishNumber(price);
        }
        else
        {
            button.text = DisplayNumber.ExponentNumber(price);
        }
        Debug.Log("Buyed");
    }

}