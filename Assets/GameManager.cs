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
    public GameObject desk;

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
        //LoadGameData();
        Score = 0;


        Fauto_sum(auto_sum);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            StartCoroutine(AppearDesk());
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            SaveGameData();
        }
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

    public IEnumerator InstantiateAutomata(int index)
    {
        if (index == 5)
        {
            yield return StartCoroutine(AppearDesk());
        }
        AutomataData automataData = prefabs[index].GetComponent<Automata>().automata_data;
        GameObject nowObject = Instantiate(prefabs[index], new Vector3(automataData.position_x,automataData.position_y,automataData.position_z),Quaternion.Euler(0.0f,automataData.rotation_y,0.0f));
        nowObject.transform.localScale = Vector3.one * automataData.scale;

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
        for (int i = 0; i < prefabs.Count; i++)
        {
            prefabs[i].GetComponent<Automata>().quantity = 0;
        }
        if (CheckGameData())
        {
            string fromJsonData = File.ReadAllText(fileName);
            data = JsonUtility.FromJson<GameData>(fromJsonData);

            Score = data.money;
            nowIndex = data.automataIndex;

            for (int i = 0; i < nowIndex; i++)
            {
                prefabs[i].GetComponent<Automata>().quantity = data.automataLevels[i];
            }
        }
    }
    public void SaveGameData()
    {
        data.money = Score;
        data.automataIndex = nowIndex;
        List<int> automataLevel = new List<int>();

        for (int i = 0; i < nowIndex; i++)
        {
            automataLevel.Add(prefabs[i].GetComponent<Automata>().quantity);
        }
        data.automataLevels = automataLevel;

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

    public IEnumerator AppearDesk()
    {
        float delta = 0;
        float duration = 1f;
        Vector3 deskEndPos = new Vector3(0f, 2.24f, 8.67f);
        Vector3 deskStartPos = desk.transform.position;

        while (delta <= duration)
        {
            float t = delta / duration;

            desk.transform.position = Vector3.Lerp(deskStartPos,deskEndPos, t);

            delta += Time.deltaTime;
            yield return null;
        }
    }
}

[Serializable]
public class GameData
{
    public long money;
    public int automataIndex;
    public List<int> automataLevels;
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

