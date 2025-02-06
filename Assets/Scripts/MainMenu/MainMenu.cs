using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class MainMenu : MonoBehaviour
{
    private GameManager _gameManager;
    [SerializeField] private GameObject _mainMenuPanel;
    [SerializeField] private GameObject _optionsPanel;

    private void Start()
    {
        _gameManager = GameManager.Instance;    
    }

    private void PlayGame()
    {
        //_gameManager.LoadLevel(1);
    }
    
    private void Options()
    {
       _mainMenuPanel.SetActive(false);
        _optionsPanel.SetActive(true);
    }

    private void ExitGame()
    {
        Application.Quit();
    }   
}

