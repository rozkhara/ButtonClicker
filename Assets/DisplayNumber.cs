using System.Collections;
using System.Collections.Generic;

public class DisplayNumber
{
    public static char[] englishNum = new char[30] { 'K', 'M', 'B', 'T', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
    public static string EnglishNumber(long number)
    {
        int cnt = -1;
        string str;

        while (number >= 1000)
        {
            number /= 1000;
            cnt++;
            if (cnt >= 30)
                break;
        }

        str = number.ToString();

        if (cnt != -1)
        {
            str += englishNum[cnt];
        }

        return str;
    }

    public static string ExponentNumber(long number)
    {
        int cnt = 0;
        double num = number;
        string str;

        while (num > 10)
        {
            num /= 10;
            cnt++;
        }
        
        str = num.ToString("0.##");

        if (cnt != 0)
        {
            str += "e" + cnt.ToString();
        }

        return str;
    }
}
