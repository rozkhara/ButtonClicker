using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyButtonUI : MonoBehaviour
{
    public static Automata target;
    public GameObject buybutton;

    public void onclick()
    {
        GameManager.Instance.store.BuyAutomata(target);
        Debug.Log("Buyed");
        Debug.Log(GameManager.Instance.automata_list[0].quantity);
    }
}