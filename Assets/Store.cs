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
        long price = 0;
        int quantity = automata.quantity;
        price = Balancing.Cost[index, quantity];
        if (GameManager.Score >= price)
        {
            if (automata.quantity == 0)
            {
                GameManager.Instance.StartCoroutine(GameManager.Instance.InstantiateAutomata(index));
            }
            GameManager.Instance.SetScore(price, "-");
            automata.SetAutomata(1, "+");
            NotifyObserver();
            SoundManager.Instance.PlaySFXSound("Upgrade");
        }
        else
        {
            SoundManager.Instance.PlaySFXSound("Error");
        }
    }

    public void Buy_10Automata(int index)
    {
        Automata automata = GameManager.Instance.prefabs[index].GetComponent<Automata>();
        long totalPrice = 0;
        int quatity = automata.quantity;
        for (int i = 0;i<10;i++)
        {
            totalPrice += Balancing.Cost[index, quatity + i];
        }
        if (GameManager.Score >= totalPrice)
        {
            if (automata.quantity == 0)
            {
                GameManager.Instance.StartCoroutine(GameManager.Instance.InstantiateAutomata(index));
            }
            GameManager.Instance.SetScore(totalPrice, "-");
            automata.SetAutomata(10, "+");
            NotifyObserver();
            Debug.Log("BuyAutomata");
        }
        else
        {

        }
    }


}