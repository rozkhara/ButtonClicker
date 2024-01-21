using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PanelManager: MonoBehaviour
{
    public PanelPrefab panelprefab;
    public GameObject storeContent;
    private void Start()
    {
        storeContent = GameObject.Find("Content");
        PanelPrefab automata1_panel = Instantiate(panelprefab, storeContent.transform);
        automata1_panel.automata_id = 1;
    }

    private void Update()
    {
        
    }


}