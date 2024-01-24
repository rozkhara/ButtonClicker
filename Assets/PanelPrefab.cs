using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class PanelPrefab : MonoBehaviour
{
    
    public int automata_id;

    public void onclick()
    {
        BuyButtonUI.target = GameManager.Instance.automata_list[automata_id];
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
