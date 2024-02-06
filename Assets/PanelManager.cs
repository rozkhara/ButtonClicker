using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PanelManager: MonoBehaviour
{
    public PanelPrefab panelprefab;
    public GameObject storeContent;
    private void Awake()
    {

    }

    private void Start()
    {

        //기본적으로
        storeContent = GameObject.Find("Content");
        InstantiatePanel(0);

    }

    public void InstantiatePanel(int index)
    {
        PanelPrefab panel = Instantiate(panelprefab, storeContent.transform);
        panel.SetPanelPrefab(index);
    }

    private void Update()
    {
        
    }


}