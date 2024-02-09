using System.Collections.Generic;
using System;
using UnityEngine;

public class Automata : MonoBehaviour,IObserver, ISubject
{
    //public SpeedController speedController;
    public AutomataData automata_data = new AutomataData();
    int sol_production;
    public int all_production { get; private set; } = 0;
    public int quantity = 0;
    public List<IObserver> observer_list = new List<IObserver>();

    public Automata(AutomataData automataData)
    {
        automata_data = automataData;
    }

    public void SetAutomataData(AutomataData automataData, IObserver auto_sum)
    {
        automata_data = automataData;
        AddObserver(auto_sum);
    }
    public void subject_alert()
    {
        sol_production = automata_data.default_production;
        all_production = sol_production * quantity;
        NotifyObserver();
    }

    public void AddObserver(IObserver observer)
    {
        if(observer_list == null)
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