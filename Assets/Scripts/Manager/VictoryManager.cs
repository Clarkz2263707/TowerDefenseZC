using UnityEngine;
using UnityEngine.SceneManagement;
//summary
//much like the other menus it handles the main menu buttopn to take you back to the main menu.
//summary
public class VictoryManager : MonoBehaviour
{
    [SerializeField] private string mainMenuSceneName = "MainMenu";

    public void OnMainMenuButtonPressed()
    {
        SceneManager.LoadScene(mainMenuSceneName);
    }
}
