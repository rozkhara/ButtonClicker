using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyButtonUI : MonoBehaviour
{
    public static int target;
    public GameObject buybutton;

    public void onclick()
    {
        GameManager.Instance.store.BuyAutomata(target);
        Debug.Log("Buyed");
    }
}