using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeBoardUI : MonoBehaviour
{
    public GameObject boardPrefab;
    public GameObject boardLinePrefab;
    public List<Tuple<string, float>> users = new List<Tuple<string, float>>();

    // Start is called before the first frame update
    void Start()
    {
        foreach (Tuple<string, float> user in users)
        {
            Instantiate(boardLinePrefab, boardPrefab.transform);
        }
    }

    public void ActiveBoard()
    {
        this.gameObject.SetActive(true);
    }

    public void DeActiveBoard()
    {
        this.gameObject.SetActive(false);
    }
    // Update is called once per frame
}
