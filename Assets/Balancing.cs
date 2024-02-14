using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balancing
{
    private const float Costmultiplier = 1.3f; // 7티어 * 1.3 그 다음 오토마타 구매 비용
    private readonly float[] CostCoefficient = new float[2] { 1.3f, 1.4f }; // 지수
    private const float AutomataProduceRatio = 0.8f; // 생산비율의 몇프로를 담당
    private readonly float[] TimeEfficiency = new float[5] { 1.05f, 1.09f, 1.16f, 1.23f, 1.3f }; // TimeDisc에 곱해질 인자들

    public int level = 1;
    public int tier = 0;
    public int era = 1;

    public static long[,] Produce = new long[13, 3000];
    public static long[,] Cost = new long[13, 3000];
    public static float[,] TimeDisc = new float[13, 3000];

    private void Init()
    {
        for (int i = 0; i < 13; ++i)
        {
            for (int j = 0; j < 3000; ++j)
            {
                Produce[i, j] = -1L;
                Cost[i, j] = -1L;
                TimeDisc[i, j] = -1f;
            }
        }
    }

    public void CallDP()
    {
        Init();
        CostDP();
        TimeDP();
        ProduceDP();
    }

    public long RetProduce(int tier = 0, int level = 1)
    {
        long ret = Produce[tier, level];
        Debug.Log(ret);
        return ret;
    }

    public long RetCost(int tier = 0, int level = 1)
    {
        long ret = Cost[tier, level];
        Debug.Log(ret);
        return ret;
    }

    public float RetTime(int tier = 0, int level = 1)
    {
        float ret = TimeDisc[tier, level];
        Debug.Log(ret);
        return ret;
    }

    public void CostDP()
    {
        for (int i = 0; i < 3000; ++i)
        {
            Cost[0, i] = 5 + 2 * i;
        }
        for (int i = 1; i < 13; ++i)
        {
            if (i < 6) era = 0; else era = 1;
            Cost[i, 0] = (long)Mathf.FloorToInt((float)(Cost[i - 1, 6]) * Costmultiplier);
            for (int j = 1; j < 3000; ++j)
            {
                Cost[i, j] = (long)Mathf.FloorToInt(Cost[i, j - 1] * CostCoefficient[era]);
            }
        }
    }

    public void TimeDP()
    {
        for (int i = 0; i < 13; ++i)
        {
            for (int j = 0; j < 3000; ++j)
            {
                if (j == 0)
                {
                    switch (i)
                    {
                        case >= 9:
                            TimeDisc[i, 0] = 5; era = 5; break;
                        case >= 6:
                            TimeDisc[i, 0] = 4; era = 4; break;
                        case >= 2:
                            TimeDisc[i, 0] = 3; era = 3; break;
                        case 0:
                            TimeDisc[i, 0] = 1; era = 1; break;
                        case 1:
                            TimeDisc[i, 0] = 2; era = 2; break;
                    }
                }
                else
                {
                    TimeDisc[i, j] = TimeDisc[i, j - 1] * TimeEfficiency[era - 1];
                }
            }
        }
    }

    public void ProduceDP()
    {
        for (int i = 0; i < 3000; ++i)
        {
            Produce[0, i] = i + 1;
        }

        for (int i = 1; i < 13; ++i)
        {
            for (int j = 0; j < 2999; ++j)
            {
                Produce[i, j] = (long)Mathf.FloorToInt(AutomataProduceRatio * Cost[i, j + 1] / TimeDisc[i, j + 1]);
            }
        }
    }

    /*public int GetThatMoney(int level = 1, int tier = 0, int era = 1)
        {
            int baseLine;
            int ret = 0;

            switch (tier)
            {
                case 0:
                    era = 0; break;
                case 1:
                    era = 1; break;
                case <= 5:
                    era = 2; break;
                case <= 8:
                    era = 3; break;
                case <= 12:
                    era = 4; break;
            }

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
        */

    //private void Start()
    //{
    //    Init();
    //}

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Q))
    //    {
    //        RetProduce(tier, level);
    //    }
    //    if (Input.GetKeyDown(KeyCode.W))
    //    {
    //        RetCost(tier, level);
    //    }
    //    if (Input.GetKeyDown(KeyCode.E))
    //    {
    //        RetTime(tier, level);
    //    }
    //    if (Input.GetKeyDown(KeyCode.C))
    //    {
    //        CallDP();
    //    }
    //}
}
