using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;
    public string PlayerName;
    public string HighPlayerName;
    public int HighScore;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    class SaveData
    {
        public string HighPlayerName;
        public int HighScore;
    }

    public void SaveHighScore()
    {
        SaveData data = new SaveData();
        data.HighScore = HighScore;
        data.HighPlayerName = HighPlayerName;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/scoredata.json", json);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/scoredata.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            HighPlayerName = data.HighPlayerName;
            HighScore = data.HighScore;
        }
    }
}
