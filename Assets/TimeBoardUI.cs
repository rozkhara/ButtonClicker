using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[Serializable]
public class LeaderBoardData
{
    public string facName;
    public string userName;
    public float claerTime;
}


public class TimeBoardUI : MonoBehaviour
{
    public GameObject boardPrefab;
    public GameObject boardLinePrefab;
    
    // Start is called before the first frame update
    void LeaderBoardInstantiate()
    {
        /*+foreach (LeaderBoardData user in users)
        {
            Instantiate(boardLinePrefab, boardPrefab.transform);
        }*/
    }

    public void ActiveBoard()
    {
        this.gameObject.SetActive(true);
    }

    public void DeActiveBoard()
    {
        this.gameObject.SetActive(false);
    }


}


