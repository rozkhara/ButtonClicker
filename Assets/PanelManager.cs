using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PanelManager: MonoBehaviour
{
    public UnityEngine.UI.Image panel1;

    public void onclick()
    {
        BuyButtonUI.target = GameManager.automata_list[0];
    }
}