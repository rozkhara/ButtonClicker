using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelPrefab : MonoBehaviour
{
    
    public int automata_id;

    public UnityEngine.UI.Image automata1_image;
    public UnityEngine.UI.Image automata2_image;
    public UnityEngine.UI.Image automata3_image;
    public UnityEngine.UI.Image automata4_image;
    public UnityEngine.UI.Image automata5_image;

    public UnityEngine.UI.Text automata1_title;
    public UnityEngine.UI.Text automata2_title;
    public UnityEngine.UI.Text automata3_title;
    public UnityEngine.UI.Text automata4_title;
    public UnityEngine.UI.Text automata5_title;

    public UnityEngine.UI.Text automata1_exp;
    public UnityEngine.UI.Text automata2_exp;
    public UnityEngine.UI.Text automata3_exp;
    public UnityEngine.UI.Text automata4_exp;
    public UnityEngine.UI.Text automata5_exp;



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void onClick()
    {
        GameManager.Instance.store.BuyAutomata(GameManager.Instance.automata_list[automata_id]);
    }
}
