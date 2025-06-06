using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private GameManager _gameManager;
    [SerializeField] private GameObject _mainMenuPanel;
    [SerializeField] private GameObject _howToPlayPanel;

    private void Start()
    {
        _gameManager = GameManager.Instance;    
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Demo Level");
    }
    
    public void HowToPlay()
    {
       _mainMenuPanel.SetActive(false);
        _howToPlayPanel.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }   
}

