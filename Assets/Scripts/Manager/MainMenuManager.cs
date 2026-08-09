using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager1 : MonoBehaviour
{
    [SerializeField] private string level1 = "Level1";
    [SerializeField] private string optionsMenu = "OptionsMenu";

    // Summary
    //Handles the operations of the main menu in regards to pressing the play button, options button, and the quit button.
    // Summary
    public void OnStartButtonPressed()
    {
        SceneManager.LoadScene(level1);
    }

    public void OnOptionsButtonPressed()
    {
        SceneManager.LoadScene(optionsMenu);
    }

    public void OnExitButtonPressed()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
