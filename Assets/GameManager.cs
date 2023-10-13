using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static long Score;

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

        Score = 0;

        store store = new store();

        List<automata> automata_list = new List<automata>();

        automata hand = new automata(1,1);
        automata spring = new automata(5,5);
        automata waterwheel = new automata(10,10);
        automata windmill = new automata(15,15);
        automata hamster = new automata(20,20);
        automata steam1 = new automata(30,30);
        automata steam2 = new automata(40, 40);
        automata steam3 = new automata(50, 50);

        automata_list.Add(hand);
        automata_list.Add(spring);
        automata_list.Add(waterwheel);
        automata_list.Add(windmill);
        automata_list.Add(hamster);
        automata_list.Add(steam1);
        automata_list.Add(steam2);
        automata_list.Add(steam3);

        auto_sum auto_sum = new auto_sum();

        store.AddObserver(hand);
        store.AddObserver(spring);
        store.AddObserver(waterwheel);
        store.AddObserver(windmill);
        store.AddObserver(hamster);
        store.AddObserver(steam1);
        store.AddObserver(steam2);
        store.AddObserver(steam3);

        hand.AddObserver(auto_sum);
        spring.AddObserver(auto_sum);
        waterwheel.AddObserver(auto_sum);
        windmill.AddObserver(auto_sum);
        hamster.AddObserver(auto_sum);
        steam1.AddObserver(auto_sum);
        steam2.AddObserver(auto_sum);
        steam3.AddObserver(auto_sum);


        auto_sum.automatas = automata_list;

        Fauto_sum(auto_sum);
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

    IEnumerator Fauto_sum(auto_sum auto_sum)
    {
        yield return new WaitForSecondsRealtime(1);
        Score += auto_sum.increment;
    }


}

public class store : ISubject
{
    public List<IObserver> observer_list = new List<IObserver>();

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

    public void BuyAutomata(automata automata)
    {
        GameManager.Score -= automata.price;
        automata.quantity += 1;
        NotifyObserver();
    }

    public void Buy_10Automata(automata automata)
    {
        GameManager.Score -= automata.price * 10;
        automata.quantity += 10;
        NotifyObserver();
    }

}

public class automata : ISubject, IObserver
{
    //int id;
    public int price;
    int sol_production;
    public int all_production = 0;
    public int quantity=0;
    public List<IObserver> observer_list = new List<IObserver>();

    public automata(int pricein, int sol)
    {
        price = pricein;
        sol_production = sol;
    }
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

