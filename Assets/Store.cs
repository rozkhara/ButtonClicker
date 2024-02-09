using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : ISubject
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

    public void BuyAutomata(int index)
    {
        Automata automata = GameManager.Instance.prefabs[index].GetComponent<Automata>();
        if (GameManager.Score >= automata.automata_data.price)
        {
            if (automata.quantity == 0)
            {
                GameManager.Instance.InstantiateAutomata(index);
            }
            GameManager.Instance.SetScore(automata.automata_data.price, "-");
            automata.SetAutomata(1, "+");
            NotifyObserver();
            Debug.Log("BuyAutomata");
        }
        else
        {

        }
    }

    public void Buy_10Automata(Automata automata)
    {
        if (GameManager.Score >= automata.automata_data.price * 10)
        {
            GameManager.Instance.SetScore(automata.automata_data.price * 10, "-");
            automata.SetAutomata(10, "+");
            NotifyObserver();
        }
        else
        {

        }
    }


}