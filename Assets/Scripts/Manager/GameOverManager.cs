using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] private string mainMenuSceneName = "MainMenu";

    public void OnMainMenuButtonPressed()
    {
        SceneManager.LoadScene(mainMenuSceneName);
    }
}
