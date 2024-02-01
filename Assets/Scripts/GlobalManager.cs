using System;
using System.IO;
using UnityEngine;

public class GlobalManager : MonoBehaviour
{
    public static GlobalManager Instance;
    public string playerName;
    public string bestPlayerName;
    public int bestScore;
    string fileName = "savefile.json";
    string path;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        path = Application.persistentDataPath + "/" + fileName;
        LoadGame();
    }

    
    public void SaveGame()
    {
        SaveData saveData = new SaveData();
        saveData.bestPlayerName = bestPlayerName;
        saveData.bestScore = bestScore;
        string json = JsonUtility.ToJson(saveData);
        File.WriteAllText(path, json);
    }
    [Serializable]
    class SaveData
    {
        public string bestPlayerName;
        public int bestScore;
    }

    void LoadGame()
    {
        
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData saveData = JsonUtility.FromJson<SaveData>(json);
            bestPlayerName = saveData.bestPlayerName;
            bestScore = saveData.bestScore;
        }
    }
}
