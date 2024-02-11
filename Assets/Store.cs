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
                GameManager.Instance.StartCoroutine(GameManager.Instance.InstantiateAutomata(index));
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

    public void Buy_10Automata(int index)
    {
        Automata automata = GameManager.Instance.prefabs[index].GetComponent<Automata>();
        if (GameManager.Score >= 10 * automata.automata_data.price)
        {
            if (automata.quantity == 0)
            {
                GameManager.Instance.StartCoroutine(GameManager.Instance.InstantiateAutomata(index));
            }
            GameManager.Instance.SetScore(automata.automata_data.price, "-");
            automata.SetAutomata(10, "+");
            NotifyObserver();
            Debug.Log("BuyAutomata");
        }
        else
        {

        }
    }


}