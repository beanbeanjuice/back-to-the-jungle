using UnityEngine;

/// <summary>
/// Class used to navigate to pause and end UI.
/// Base code from "PAUSE MENU in Unity" - Brackeys.
/// <remarks>Coded by Westley.</remarks>
/// </summary>
public class GameplayManager : MonoBehaviour
{
    [SerializeField] private GameObject gameScreenUI;
    [SerializeField] private GameObject pauseScreenUI;
    [SerializeField] private GameObject endScreenUI;
    public static bool GamePaused = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseScreenUI.SetActive(false);
        Time.timeScale = 1f;
        GamePaused = false;
    }

    private void Pause()
    {
        pauseScreenUI.SetActive(true);
        Time.timeScale = 0f;
        GamePaused = true;
    }

    public void EndGame()
    {
        gameScreenUI.SetActive(false);
        endScreenUI.SetActive(true);
        Time.timeScale = 0f;
        GamePaused = true;
    }
}
