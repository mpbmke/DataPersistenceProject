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
}
