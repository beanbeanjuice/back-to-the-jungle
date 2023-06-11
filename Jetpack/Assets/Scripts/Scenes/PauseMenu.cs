using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseScreenUI;
    public static bool GamePaused = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    private void Resume()
    {
        pauseScreenUI.SetActive(true);
        Time.timeScale = 1f;
        GamePaused = false;
    }

    private void Pause()
    {
        pauseScreenUI.SetActive(true);
        Time.timeScale = 0f;
        GamePaused = true;
    }
}
