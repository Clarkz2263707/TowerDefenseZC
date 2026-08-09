using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager1 : MonoBehaviour
{
    [SerializeField] private string level1 = "Level1";
    [SerializeField] private string optionsMenu = "OptionsMenu";

    // Summary
    //Handles the operations of the main menu in regards to pressing the play button, options button, and the quit button.
    // Summary
    private void OnStartButtonPressed()
    {
        SceneManager.LoadScene(level1);
    }

    private void OnOptionsButtonPressed()
    {
        SceneManager.LoadScene(optionsMenu);
    }

    private void OnExitButtonPressed()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
