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


    private void Start()
    {
        LeaderBoardInstantiate();
        DeActiveBoard();
    }

    void BoardLineInstantiate(int index)
    {
        float time = GameManager.Instance.users[index].claerTime;
        int hour;
        int minute;
        hour = (int)time / 3600;
        time = time - 3600 * hour;
        minute = (int)time / 60;
        time = time - 60 * minute;
        int grade = index + 1;
        GameObject boardline = Instantiate(boardLinePrefab, boardPrefab.transform);
        boardline.transform.GetChild(0).GetComponent<TMP_Text>().text = grade.ToString();
        boardline.transform.GetChild(1).GetComponent<TMP_Text>().text = GameManager.Instance.users[index].facName;
        boardline.transform.GetChild(2).GetComponent<TMP_Text>().text = GameManager.Instance.users[index].userName;
        boardline.transform.GetChild(3).GetComponent<TMP_Text>().text = string.Format("{0:}:{1:00}:{2:00.00}", hour, minute, time);
    }

    public void LeaderBoardInstantiate()
    {
        int minCount = (GameManager.Instance.users.Count < 10 ? GameManager.Instance.users.Count : 10);
        Debug.Log("asdf"+minCount);
        for (int i = 0; i < minCount; i++)
        {
            Debug.Log(i);
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
        /*foreach (Transform child in boardPrefab.transform)
        {
            Destroy(boardPrefab.transform.GetChild(0));
        }*/

        for(int i = 0; i < boardPrefab.transform.childCount; i++)
        {
            Destroy(boardPrefab.transform.GetChild(0).gameObject);
        }

        LeaderBoardInstantiate();
    }
}
