using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    public Brick BrickPrefab;
    public int LineCount = 6;
    public Rigidbody Ball;

    public Text ScoreText;
    [SerializeField] Text _highScoreText;
    public GameObject GameOverText;
    
    private bool m_Started = false;
    private int m_Points;
    string _playerName;
    string _highScorePlayer;
    int _highScore;
    private bool m_GameOver = false;

    
    // Start is called before the first frame update
    void Start()
    {
        PersistentData.Data.LoadHighScore();
        _playerName = PersistentData.Data.GetPlayerName();
        UpdateHighScore();

        const float step = 0.6f;
        int perLine = Mathf.FloorToInt(4.0f / step);

        int[] pointCountArray = new[] { 1, 1, 2, 2, 5, 5 };
        for (int i = 0; i < LineCount; ++i)
        {
            for (int x = 0; x < perLine; ++x)
            {
                Vector3 position = new Vector3(-1.5f + step * x, 2.5f + i * 0.3f, 0);
                var brick = Instantiate(BrickPrefab, position, Quaternion.identity);
                brick.PointValue = pointCountArray[i];
                brick.onDestroyed.AddListener(AddPoint);
            }
        }
    }

    private void UpdateHighScore()
    {
        if(PersistentData.Data.GetHighScorePlayerName() != null)
        {
            _highScorePlayer = PersistentData.Data.GetHighScorePlayerName();
            _highScore = PersistentData.Data.GetHighScore();

            _highScoreText.text = "High Score: " + _highScore + " by " + _highScorePlayer;
        }
        else
        {
            _highScoreText.text = "No high score has been set!";
        }
    }

    private void Update()
    {
        if (!m_Started)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_Started = true;
                float randomDirection = Random.Range(-1.0f, 1.0f);
                Vector3 forceDir = new Vector3(randomDirection, 1, 0);
                forceDir.Normalize();

                Ball.transform.SetParent(null);
                Ball.AddForce(forceDir * 2.0f, ForceMode.VelocityChange);
            }
        }
        else if (m_GameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    void AddPoint(int point)
    {
        m_Points += point;
        ScoreText.text = $"Score : {m_Points}";
    }

    public void GameOver()
    {
        int highScore = PersistentData.Data.GetHighScore();

        if (m_Points > highScore)
        {
            PersistentData.Data.SetHighScore(m_Points);
            PersistentData.Data.SetHighScorePlayer(_playerName);
            PersistentData.Data.SaveHighScore();
            UpdateHighScore();
        }
        Debug.Log("New High Score Player: " + PersistentData.Data.GetHighScorePlayerName());
        
        m_GameOver = true;
        GameOverText.SetActive(true);
    }
}
