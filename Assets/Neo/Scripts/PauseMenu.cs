using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject restartPrompt;
    [SerializeField] private GameObject exitPrompt;

    private bool isPaused;
    
    // Start is called before the first frame update


    public void PauseGame()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void ExitPrompt()
    {
        exitPrompt.SetActive(true);
    }
    public void ExitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
    public void CancelExit()
    {
        exitPrompt.SetActive(false);
    }

    public void RestartLevel()
    {
        restartPrompt.SetActive(true);
    }

    public void ContinueRestart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        restartPrompt.SetActive(false);
    }

    public void CancelRestart()
    {
        restartPrompt.SetActive(false);
    }
}
