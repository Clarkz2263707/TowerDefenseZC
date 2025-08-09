using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryManager : MonoBehaviour
{
    [SerializeField] private string mainMenuSceneName = "MainMenu";

    public void OnMainMenuButtonPressed()
    {
        SceneManager.LoadScene(mainMenuSceneName);
    }
}
