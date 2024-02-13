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
    public List<LeaderBoardData> users;

    void BoardLineInstantiate(int index)
    {
        GameObject boardline = Instantiate(boardLinePrefab, boardPrefab.transform);
        boardline.transform.GetChild(0).GetComponent<TMP_Text>().text = index.ToString();
        boardline.transform.GetChild(1).GetComponent<TMP_Text>().text = users[index].facName;
        boardline.transform.GetChild(2).GetComponent<TMP_Text>().text = users[index].userName;
        boardline.transform.GetChild(3).GetComponent<TMP_Text>().text = users[index].claerTime.ToString();
    }

    void LeaderBoardInstantiate()
    {
        for (int i = 0; i < 10; i++)
        {
            BoardLineInstantiate (i);
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

    public void SortLeaderBoardData()
    {
        users.Sort((LeaderBoardData a, LeaderBoardData b) => (a.claerTime > b.claerTime ? 1 : -1));
    }
}


