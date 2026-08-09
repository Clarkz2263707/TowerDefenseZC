using UnityEngine;
using UnityEngine.SceneManagement;
//summary
//handles the main menu button that takes you back to the main menu
//summary
public class OptionsMenuManager : MonoBehaviour
{
    [SerializeField] private string mainMenuSceneName = "MainMenu";

    public void OnMainMenuButtonPressed()
    {
        SceneManager.LoadScene(mainMenuSceneName);
    }
}
