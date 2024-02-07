using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;
using System.Net;
using UnityEditor.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static long Score { get; private set; }

    public Store store = new Store();
    public Auto_sum auto_sum = new Auto_sum();
    public TouchManager touchManager;
    public PanelManager panelManager;

    public List<Automata> automata_list = new List<Automata>();
    public List<GameObject> prefabs = new List<GameObject>();

    public int nowIndex = 0;
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

        //Save();
        LoadAssetData();
        LoadGameData();
        Score = 0;


        Fauto_sum(auto_sum);
    }

    public static void PrintDict<K, V>(Dictionary<K, V> dict)
    {
        foreach (KeyValuePair<K, V> entry in dict)
        {
            Debug.Log("Key: " + entry.Key + ", Value: " + entry.Value);
        }
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
        Debug.Log(Score);
        return Score;
    }

    public void InstantiateAutomata(int index)
    {
        Instantiate(prefabs[index]);
        nowIndex++;
        panelManager.InstantiatePanel(nowIndex);
    }
    IEnumerator Fauto_sum(Auto_sum auto_sum)
    {
        yield return new WaitForSecondsRealtime(1);
        Score += auto_sum.increment;
    }

    public GameData data = new GameData();
    public string fileName;
    public List<AutomataData> automataDataJson;

    public void LoadGameData()
    {
        if (CheckGameData())
        {
            string fromJsonData = File.ReadAllText(fileName);
            data = JsonUtility.FromJson<GameData>(fromJsonData);
        }
    }
    public void SaveGameData()
    {
        fileName = Application.persistentDataPath + "/GameData.json";
        string toJsonData = JsonUtility.ToJson(data, true);

        File.WriteAllText(fileName, toJsonData);
    }

    public bool CheckGameData()
    {
        fileName = Application.persistentDataPath + "/GameData.json";
        return File.Exists(fileName);
    }

    /*public void Save()
    {
        fileName = Application.dataPath + "/AssetData.json";
        Debug.Log(fileName);

        List<AutomataData> gamedata = new List<AutomataData>();

        foreach (GameObject ob in prefabs)
        {
            Debug.Log(ob.name);
            Debug.Log(ob.GetComponent<Automata>().automata_data.id);
            gamedata.Add(ob.GetComponent<Automata>().automata_data);
        }

        foreach (AutomataData automatadata in gamedata)
        {
            Debug.Log(automatadata.id);
        }
        string toJsonData = JsonConvert.SerializeObject(gamedata,);


        Debug.Log(toJsonData);
        File.WriteAllText(fileName, toJsonData);
    }*/
    public void LoadAssetData()
    {
        fileName = Application.dataPath + "/AssetData.json";
        string fromJsonData = File.ReadAllText(fileName);

        automataDataJson = JsonConvert.DeserializeObject<List<AutomataData>>(fromJsonData);

        for (int i = 0; i < automataDataJson.Count; i++)
        {
            //prefabs[i].GetComponent<Automata>().automata_data = automataDataJson[i];
            Automata auto = prefabs[i].GetComponent<Automata>();
            //Debug.Log(auto_sum);
            if (auto != null)
            {
                auto.SetAutomataData(automataDataJson[i], auto_sum);
                Debug.Log(auto.automata_data.id);
            }
            store.AddObserver(prefabs[i].GetComponent<Automata>());
        }
    }

    /*public void InstantiateAutomata(Automata automata)
    {
        GameObject gameAutomata;

        Instantiate(gameAutomata, assetLocation[automata.id], Quaternion.identity);
    }*/
}

[Serializable]
public class GameData
{
    public int money;
    public Vector3 a = Vector3.one;

}



public class Auto_sum : IObserver
{
    public long increment { get; private set; }
    public void subject_alert()
    {
        foreach (GameObject automata in GameManager.Instance.prefabs)
        {
            increment += automata.GetComponent<Automata>().all_production;
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

