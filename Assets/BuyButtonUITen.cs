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
    }

    public void onclick()
    {
        target = transform.parent.GetComponent<PanelPrefab>().automata_id;
        GameManager.Instance.store.Buy_10Automata(target);
        Debug.Log("Buyed");
    }
}
