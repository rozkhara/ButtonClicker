using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balancing : MonoBehaviour
{
    //private readonly float multiplier = 1.5f;
    private const int base_value = 3;
    private const int to_next_value = 13;

    public int level = 1;
    public int tier = 0;
    public int era = 1;

    public int GetThatMoney(int level = 1, int tier = 0, int era = 1)
    {
        int baseLine;
        int ret = 0;
        for (int i = 0; i < tier; ++i)
        {
            baseLine = Mathf.FloorToInt(Mathf.Pow(base_value, i) * (1 + (float)(era / 10f)));
            ret += baseLine * to_next_value;
        }
        baseLine = Mathf.FloorToInt(Mathf.Pow(base_value, tier) * (1 + (float)(era / 10f)));
        ret += baseLine * level;
        Debug.Log(ret);
        return ret;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            GetThatMoney(level, tier, era);
        }
    }

    //public int GetCost(int id = 0, int level = 1)
    //{
    //    return 0;
    //}
}
