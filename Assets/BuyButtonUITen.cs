using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyButtonUITen : MonoBehaviour
{
    public static int target;


    public void onclick()
    {
        target = transform.parent.GetComponent<PanelPrefab>().automata_id;
        GameManager.Instance.store.Buy_10Automata(target);
        Debug.Log("Buyed");
    }
}
