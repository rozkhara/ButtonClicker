using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;
using static UnityEngine.GraphicsBuffer;

public class PanelPrefab : MonoBehaviour
{

    public int automata_id;
    string assetRoute;
    Automata automata;


    public void SetPanelPrefab(int index) 
    {
        automata_id = index;
        assetRoute = "Image/" + GameManager.Instance.prefabs[automata_id].GetComponent<Automata>().automata_data.name;
        transform.GetChild(0).GetComponent<RawImage>().texture = Resources.Load<Texture>(assetRoute);
        transform.GetChild(1).GetComponent<TMP_Text>().text = GameManager.Instance.prefabs[automata_id].GetComponent<Automata>().automata_data.name;
        transform.GetChild(2).GetComponent<TMP_Text>().text = GameManager.Instance.prefabs[automata_id].GetComponent<Automata>().automata_data.id.ToString();
        automata = GameManager.Instance.prefabs[automata_id].GetComponent<Automata>();
    }

    // 밑에 있는 거랑 10개 구입 가격 늘어나는 거 고려 안 함
    void Update()
    {
        if (GameManager.Score >= 10 * automata.automata_data.price)
        {
            transform.GetChild(4).gameObject.SetActive(true);
        }
        else
        {
            transform.GetChild(4).gameObject.SetActive(false);
        }
    }



}
