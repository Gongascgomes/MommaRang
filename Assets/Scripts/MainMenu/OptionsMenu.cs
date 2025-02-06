using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField] private GameObject _mainMenuPanel;
    [SerializeField] private GameObject _optionsPanel;

    private void BackToMainMenu()
    {     
        _optionsPanel.SetActive(false);
        _mainMenuPanel.SetActive(true);
    }
}
