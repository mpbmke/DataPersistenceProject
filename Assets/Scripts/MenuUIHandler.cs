using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuUIHandler : MonoBehaviour
{
    [SerializeField] TMP_InputField _playerNameInput;

    void Start()
    {
        if (_playerNameInput == null)
            Debug.LogError("TMP_InputField is null");
    }

    void Update()
    {
        
    }

    public void StartNew()
    {
        PersistentData.Data.SetPlayerName(_playerNameInput.text);
        Debug.Log(PersistentData.Data.GetPlayerName());
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
