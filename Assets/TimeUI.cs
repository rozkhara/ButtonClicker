using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeUI : MonoBehaviour
{
    public GameObject timeUI;
    public float time;
    public int hour;
    public int minute;

    private void Update()
    {
        time = GameManager.Instance.currentTime;
        hour = (int)time / 3600;
        time = time - 3600 * hour;
        minute = (int)time / 60;
        time = time - 60 * minute;

        timeUI.GetComponent<TMP_Text>().text = string.Format("{0:}:{1:00}:{2:00.00}", hour, minute, time);
    }
}
