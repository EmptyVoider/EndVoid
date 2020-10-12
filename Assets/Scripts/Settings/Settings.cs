using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Settings : MonoBehaviour
{
    public AudioMixer audioMixer;

    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject settingsMenuUI;
    public GameObject videoMenuUI;
    public GameObject audioMenuUI;
    public GameObject otherMenuUI;

    private void Update()
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
        pauseMenuUI.SetActive(false);
        settingsMenuUI.SetActive(false);
        audioMenuUI.SetActive(false);
        videoMenuUI.SetActive(false);
        otherMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void NavigateTo(GameObject navigateTo)
    {
        pauseMenuUI.SetActive(false);
        settingsMenuUI.SetActive(false);
        videoMenuUI.SetActive(false);
        audioMenuUI.SetActive(false);
        otherMenuUI.SetActive(false);
        navigateTo.SetActive(true);
    }

    public void QuitGame()
    {
        Debug.LogWarning("If nothing happened, check if the name of the menu scene is: Menu");
        SceneManager.LoadScene("Menu");
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
        Debug.Log(volume);
    }

    public void SetMusic(float volume)
    {
        audioMixer.SetFloat("Music", volume);
        Debug.Log(volume);
    }

    public void SetSounds(float volume)
    {
        audioMixer.SetFloat("Sounds", volume);
        Debug.Log(volume);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Debug.LogWarning("If not in editor, fullscreen would be: " + isFullscreen);
        Screen.fullScreen = isFullscreen;
    }
}
