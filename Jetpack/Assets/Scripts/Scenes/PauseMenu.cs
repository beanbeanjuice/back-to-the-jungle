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
            Debug.Log("PRESSED!");
            if (GamePaused)
            {
                Resume();
                Debug.Log("resume");
            }
            else
            {
                Pause();
                Debug.Log("pause");
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
}
