using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static long Score { get; private set; }

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
            }
            return instance;
        }
    }
    private void Awake()
    {
        if (Instance != this)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    /// <summary>
    /// Changes the score with the given operator accordingly.
    /// Score is updated with Score = Score (operator) value.<br/>
    /// Division does not perform anything if value == 0;
    /// </summary>
    /// <param name="value">Value to modify the current score with</param>
    /// <param name="operator">+, -, /, *</param>
    /// <returns></returns>
    public long ChangeScore(int value, string @operator = "+")
    {
        long _score = Score;
        try
        {
            Score = @operator switch
            {
                "+" => Score + value,
                "-" => Score - value,
                "/" => Score / value,
                "*" => Score * value,
                _ => throw new Exception()
            };
        }
        catch (DivideByZeroException)
        {
            Score = _score;
        }
        return Score;
    }
}

public class automata
{
    int id;
    int weight;
    int Level;
    int Upgradelevel;
    public long increment;

    public void cal()
    {
        increment = weight * Level;
    }
}

public class automata_list
{
    automata hand = new automata();
    automata spring = new automata();
    automata waterwheel = new automata();
    automata windmill = new automata();
    automata hamster = new automata();
    automata steam1 = new automata();
    automata steam2 = new automata();
    automata steam3 = new automata();
    long total_increment;
    public void cal()
    {
        total_increment =
            hand.increment +
            spring.increment +
            waterwheel.increment +
            windmill.increment +
            hamster.increment +
            steam1.increment +
            steam2.increment +
            steam3.increment;
    }
}
