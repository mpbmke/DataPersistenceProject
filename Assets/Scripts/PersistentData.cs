using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentData : MonoBehaviour
{
    public static PersistentData Data;
    static string _playerName;
    static string _highScorePlayer;
    static int _highScore;
    
    void Awake()
    {
        if (Data != null)
        {
            Destroy(this);
            return;
        }

        Data = this;
        DontDestroyOnLoad(this);
    }

    public void SetPlayerName(string name)
    {
        _playerName = name;
    }

    public string GetPlayerName()
    {
        string name = _playerName;
        return name;
    }

    public void SetHighScore(int score)
    {
        _highScore = score;
    }

    public int GetHighScore()
    {
        int score = _highScore;
        return score;
    }

    public void SetHighScorePlayer(string name)
    {
        _highScorePlayer = name;
    }

    public string GetHighScorePlayerName()
    {
        string name = _highScorePlayer;
        return name;
    }

    [System.Serializable]
    class SaveData
    {
        public string _highScorePlayer;
        public int _highScore;
    }

    public void SaveHighScore()
    {
        SaveData saveData = new SaveData();

        saveData._highScorePlayer = _highScorePlayer;
        saveData._highScore = _highScore;

        string json = JsonUtility.ToJson(saveData);
        File.WriteAllText(Application.persistentDataPath + "savedata.json", json);
    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "savedata.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData saveData = JsonUtility.FromJson<SaveData>(json);

            _highScore = saveData._highScore;
            _highScorePlayer = saveData._highScorePlayer;
        }
    }
}
