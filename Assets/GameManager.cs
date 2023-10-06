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

        store store = new store();

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

        auto_sum auto_sum = new auto_sum();

        auto_sum.automatas = automata_list;
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

public class store : ISubject
{
    List<IObserver> observer_list = new List<IObserver>();

    public void AddObserver(IObserver observer)
    {
        observer_list.Add(observer);
    }
    public void RemoveObserver(IObserver observer)
    {
        observer_list.Remove(observer);
    }
    public void NotifyObserver()
    {
        foreach (IObserver observer in observer_list)
        {
            observer.subject_alert();
        }
    }
}

public class automata : ISubject, IObserver
{
    int id;
    int price;
    int sol_production;
    public int all_production;
    int quantity;
    List<IObserver> observer_list = new List<IObserver>();

    public void subject_alert()
    {
        all_production = sol_production * quantity;
        NotifyObserver();
    }

    public void AddObserver(IObserver observer)
    {
        observer_list.Add(observer);
    }
    public void RemoveObserver(IObserver observer)
    {
        observer_list.Remove(observer);
    }
    public void NotifyObserver()
    {
        foreach (IObserver observer in observer_list)
        {
            observer.subject_alert();
        }
    }
}

public class auto_sum : IObserver
{
    public List<automata> automatas = new List<automata>();
    public long increment;
    public void subject_alert()
    {
        foreach(automata automata in automatas)
        {
            increment += automata.all_production;
        }
    }
}

public interface ISubject
{
    void AddObserver(IObserver observer);
    void RemoveObserver(IObserver observer);
    void NotifyObserver();
}

public interface IObserver
{
    public void subject_alert();
}

