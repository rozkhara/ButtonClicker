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
    public bool boardOn;
    //public List<LeaderBoardData> users;

    void BoardLineInstantiate(int index)
    {
        GameObject boardline = Instantiate(boardLinePrefab, boardPrefab.transform);
        boardline.transform.GetChild(0).GetComponent<TMP_Text>().text = index.ToString();
        boardline.transform.GetChild(1).GetComponent<TMP_Text>().text = GameManager.Instance.users[index].facName;
        boardline.transform.GetChild(2).GetComponent<TMP_Text>().text = GameManager.Instance.users[index].userName;
        boardline.transform.GetChild(3).GetComponent<TMP_Text>().text = GameManager.Instance.users[index].claerTime.ToString();
    }

    public void LeaderBoardInstantiate()
    {
        int minCount = GameManager.Instance.users.Count < 10 ? GameManager.Instance.users.Count : 10;
        for (int i = 0; i < minCount; i++)
        {
            BoardLineInstantiate(i);
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

    public void ReLeaderBoardInstantiate()
    {
        while (boardPrefab.transform.GetChild(0)!=null)
        {
            Destroy(boardPrefab.transform.GetChild(0));
        }
        LeaderBoardInstantiate();
    }
}
