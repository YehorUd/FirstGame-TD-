using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PausePanel : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject PauseMenuUI, PauseUI, ResumeUI;

    private void Start()
    {
        ResumeUI.gameObject.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
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
        PauseMenuUI.SetActive(false);
        PauseUI.gameObject.SetActive(true);
        ResumeUI.gameObject.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
   public void Pause()
    {
        PauseMenuUI.SetActive(true);
        PauseUI.gameObject.SetActive(false);
        ResumeUI.gameObject.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void Quit()
    {
        Application.Quit();
    }
}
