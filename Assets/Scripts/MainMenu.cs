using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string sceneToLoad;
    public GameObject mainMenu;
    public GameManager _manager;

    void Start()
    {
        _manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    
    public void StartGame()
    {
        SceneManager.LoadScene(sceneToLoad);
        _manager.ResetScores();
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
