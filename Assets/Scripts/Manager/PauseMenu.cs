using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject container;

    // Summary
    // If I press escape on any of the 4 playable levels the game pauses and I can either go to the main menu or unpause the pause and continue with the level. It freezes time while it is up.
    // Summary
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            container.SetActive(true);
            Time.timeScale = 0;
        }
    }
    public void ResumeButton()
    {
        container.SetActive(false);
        Time.timeScale = 1;
    }
    public void MainMenuButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}
