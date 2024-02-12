using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyButtonUI : MonoBehaviour
{
    public static int target;


    public void onclick()
    {
        target = transform.parent.GetComponent<PanelPrefab>().automata_id;
        GameManager.Instance.store.BuyAutomata(target);
        Debug.Log("Buyed");
    }
}