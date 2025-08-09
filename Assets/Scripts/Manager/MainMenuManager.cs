using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager1 : MonoBehaviour
{
    [SerializeField] private string level1 = "Level1";
    [SerializeField] private string optionsMenu = "OptionsMenu";


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
