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

        List<automata> automata_list = new List<automata>();

        automata hand = new automata();
        automata spring = new automata();
        automata waterwheel = new automata();
        automata windmill = new automata();
        automata hamster = new automata();
        automata steam1 = new automata();
        automata steam2 = new automata();
        automata steam3 = new automata();

        automata_list.Add(hand);
        automata_list.Add(spring);
        automata_list.Add(waterwheel);
        automata_list.Add(windmill);
        automata_list.Add(hamster);
        automata_list.Add(steam1);
        automata_list.Add(steam2);
        automata_list.Add(steam3);

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

public class automata : ISubject
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

public interface ISubject
{
    void AddObserver(Observer observer)
    {

    }
    void RemoveObserver(Observer observer)
    {

    }
    void NotifyObserver()
    {

    }
}

public interface Observer
{

}
