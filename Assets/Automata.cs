using System.Collections.Generic;
using System;
using UnityEngine;

public class Automata : MonoBehaviour, IObserver, ISubject
{
    //public SpeedController speedController;
    public AutomataData automata_data = new AutomataData();
    public long all_production { get; private set; } = 0;
    public int quantity = 0;
    public List<IObserver> observer_list = new List<IObserver>();
    public int autoindex;
    public long accumulate;

    public Automata(AutomataData automataData)
    {
        automata_data = automataData;
    }

    public void SetAutomataData(AutomataData automataData, int i, IObserver auto_sum)
    {
        automata_data = automataData;
        autoindex = i;
        AddObserver(auto_sum);
    }
    public void subject_alert()
    {

        if (quantity - 1 != -1)
        {
            all_production = Balancing.Produce[autoindex, quantity-1];
        }
        else
        {
            all_production = 0;
        }

        NotifyObserver();
        if (autoindex == 9 && quantity >= 10)
        {
            GameManager.Instance.ClearGame();
        }
    }

    public void AddObserver(IObserver observer)
    {
        if (observer_list == null)
            observer_list = new List<IObserver>();
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