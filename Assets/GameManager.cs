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
    public static long Score { get; private set; }

    public store store = new store();

    public era ancient = new era();
    public era steam = new era();
    public era modern = new era();
    public era electronic = new era();
    public era future = new era();

    public TouchManager touchManager;

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



        List<automata> automata_list = new List<automata>();

        automata hand = new automata(ancient,1,1);
        automata spring = new automata(ancient, 5,5);
        automata waterwheel = new automata(ancient, 10,10);
        automata windmill = new automata(ancient, 15,15);
        automata hamster = new automata(ancient, 20,20);

        automata steam1 = new automata(steam, 30,30);
        automata steam2 = new automata(steam, 40, 40);
        automata steam3 = new automata(steam, 50, 50);

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

        ancient.AddObserver(hand);
        ancient.AddObserver(spring);
        ancient.AddObserver(waterwheel);
        ancient.AddObserver(windmill);
        ancient.AddObserver(hamster);

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
    public long SetScore(int value, string @operator = "+")
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
        if (GameManager.Score >= automata.price)
        {
            GameManager.Instance.SetScore(automata.price, "-");
            automata.SetAutomata(1, "+");
            NotifyObserver();
        }
        else
        {

        }
    }

    public void Buy_10Automata(automata automata)
    {
        if (GameManager.Score >= automata.price * 10)
        {
            GameManager.Instance.SetScore(automata.price * 10, "-");
            automata.SetAutomata(10, "+");
            NotifyObserver();
        }
        else
        {

        }
    }

    public void Buyeff(era effobject)
    {
        if (GameManager.Score >= effobject.price * 10)
        {
            GameManager.Instance.SetScore(effobject.price, "-");
            effobject.SetPhase(1, "+");
            NotifyObserver();
        }
        else
        {

        }
    }

}

public class era : ISubject, IObserver
{
    public List<IObserver> observer_list = new List<IObserver>();
    public int phase { get; private set; } = 0;
    public double efficiency { get; private set; } = 1;
    public int price { get; private set; }

    public void subject_alert()
    {
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
    public long SetPhase(int value, string @operator = "+")
    {
        phase = @operator switch
        {
            "+" => phase + value,
            "-" => phase - value,
            _ => throw new Exception()
        };
        return phase;
    }
}

public class automata : ISubject, IObserver
{
    //int id;
    era tag;
    public int price { get; private set; }
    int default_production;
    int sol_production;
    public int all_production { get; private set; } = 0;
    public int quantity { get; private set; } = 0;
    public List<IObserver> observer_list = new List<IObserver>();

    public automata(era tag, int pricein, int sol)
    {
        this.tag = tag;
        price = pricein;
        default_production = sol;
    }
    public void subject_alert()
    {
        sol_production = (int)(default_production * tag.efficiency);
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

    public long SetAutomata(int value, string @operator = "+")
    {
        quantity = @operator switch
        {
            "+" => quantity + value,
            "-" => quantity - value,
            _ => throw new Exception()
        };
        return quantity;
    }

}

public class auto_sum : IObserver
{
    public List<automata> automatas = new List<automata>();
    public long increment { get; private set; }
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

