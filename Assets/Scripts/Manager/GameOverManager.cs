using UnityEngine;
using UnityEngine.SceneManagement;
//summary
//when you get a gameover it allows you to go back to the main menu when you press the button.
//summary
public class GameOverManager : MonoBehaviour
{
    [SerializeField] private string mainMenuSceneName = "MainMenu";

    public void OnMainMenuButtonPressed()
    {
        SceneManager.LoadScene(mainMenuSceneName);
    }
}
