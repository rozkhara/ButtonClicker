using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayNumber : MonoBehaviour
{
    char[] englishNum = new char[4]{ 'K', 'M', 'B', 'T' };
    public string EnglishNumber(int number)
    {
        int cnt = -1;
        string str;

        while (number >= 1000)
        {
            number /= 1000;
            cnt++;
        }

        str = number.ToString();

        if (cnt != 0)
        {
            str += englishNum[cnt];
        }

        return str;
    }

    public string ExponentNumber(int number)
    {
        int cnt = 0;
        float num = number;
        string str;

        while (num < 10)
        {
            num /= 10;
            cnt++;
        }

        str = num.ToString();

        if (cnt != 0)
        {
            str += "e" + cnt.ToString();
        }

        return str;
    }
}
