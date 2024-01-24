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



    public string hand_title = "hand";
    public string punch_title = "punch";
    public string waterwheel_title = "waterwheel";
    public string windmill_title = "windmill";
    public string hamster_title = "hamster";

    public string hand_exp = "101";
    public string punch_exp = "201";
    public string waterwheel_exp = "202";
    public string windmill_exp = "203";
    public string hamster_exp = "204";


    private void Awake()
    {

    }

    private void Start()
    {
        Texture hand_image = Resources.Load<Texture>("Image/hand");
        Texture punch_image = Resources.Load<Texture>("Image/punch");
        Texture waterwheel_image = Resources.Load<Texture>("Image/waterwheel");
        Texture windmill_image = Resources.Load<Texture>("Image/windmill");
        Texture hamster_image = Resources.Load<Texture>("Image/hamster");

        storeContent = GameObject.Find("Content");
        PanelPrefab hand_panel = Instantiate(panelprefab, storeContent.transform);
        hand_panel.automata_id = 1;
        hand_panel.transform.GetChild(0).GetComponent<RawImage>().texture = hand_image;
        hand_panel.transform.GetChild(1).GetComponent<TMP_Text>().text = hand_title;
        hand_panel.transform.GetChild(2).GetComponent<TMP_Text>().text = hand_exp;

        PanelPrefab punch_panel = Instantiate(panelprefab, storeContent.transform);
        punch_panel.automata_id = 2;
        punch_panel.transform.GetChild(0).GetComponent<RawImage>().texture = punch_image;
        punch_panel.transform.GetChild(1).GetComponent<TMP_Text>().text = punch_title;
        punch_panel.transform.GetChild(2).GetComponent<TMP_Text>().text = punch_exp;

        PanelPrefab waterwheel_panel = Instantiate(panelprefab, storeContent.transform);
        waterwheel_panel.automata_id = 3;
        waterwheel_panel.transform.GetChild(0).GetComponent<RawImage>().texture = waterwheel_image;
        waterwheel_panel.transform.GetChild(1).GetComponent<TMP_Text>().text = waterwheel_title;
        waterwheel_panel.transform.GetChild(2).GetComponent<TMP_Text>().text = waterwheel_exp;

        PanelPrefab windmill_panel = Instantiate(panelprefab, storeContent.transform);
        windmill_panel.automata_id = 4;
        windmill_panel.transform.GetChild(0).GetComponent<RawImage>().texture = windmill_image;
        windmill_panel.transform.GetChild(1).GetComponent<TMP_Text>().text = windmill_title;
        windmill_panel.transform.GetChild(2).GetComponent<TMP_Text>().text = windmill_exp;

        PanelPrefab hamster_panel = Instantiate(panelprefab, storeContent.transform);
        hamster_panel.automata_id = 5;
        hamster_panel.transform.GetChild(0).GetComponent<RawImage>().texture = hamster_image;
        hamster_panel.transform.GetChild(1).GetComponent<TMP_Text>().text = hamster_title;
        hamster_panel.transform.GetChild(2).GetComponent<TMP_Text>().text = hamster_exp;

    }

    private void Update()
    {
        
    }


}