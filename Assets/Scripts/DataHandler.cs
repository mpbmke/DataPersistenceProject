using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataHandler : MonoBehaviour
{
    public static DataHandler Data;
    public static string _playerName;
    int _highScore;

    private void Awake()
    {
        if (Data != null)
        {
            Destroy(this);
            return;
        }
        
        Data = this;
        DontDestroyOnLoad(this);
    }

    public void SetPlayerName(string nameInput)
    {
        _playerName = nameInput;
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
}
