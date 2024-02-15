using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BuyButtonUITen : MonoBehaviour
{
    public static int target;
    public int quatity;
    public TMP_Text button10;
    public long price10;

    private void Start()
    {
        target = transform.parent.GetComponent<PanelPrefab>().automata_id;
        quatity = GameManager.Instance.prefabs[target].GetComponent<Automata>().quantity;
        price10 = 0;
        for (int i = 0; i < 10; i++)
        {
            price10 += Balancing.Cost[target, quatity + i];
        }
        if (GameManager.Instance.isDisplayModeEnglish)
        {
            button10.text = DisplayNumber.EnglishNumber(price10);
        }
        else
        {
            button10.text = DisplayNumber.ExponentNumber(price10);
        }
    }

    public void onclick()
    {
        target = transform.parent.GetComponent<PanelPrefab>().automata_id;
        GameManager.Instance.store.Buy_10Automata(target);
        quatity = GameManager.Instance.prefabs[target].GetComponent<Automata>().quantity;
        price10 = 0;
        for (int i = 0; i < 10; i++)
        {
            price10 += Balancing.Cost[target, quatity + i];
        }
        if (GameManager.Instance.isDisplayModeEnglish)
        {
            button10.text = DisplayNumber.EnglishNumber(price10);
        }
        else
        {
            button10.text = DisplayNumber.ExponentNumber(price10);
        }
    }
}
