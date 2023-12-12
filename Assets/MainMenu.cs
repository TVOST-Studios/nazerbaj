using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Start()
    {
        AudioManager.Instance.FadeMusic(AudioManager.Instance.BackgroundMusic2,AudioManager.Instance.GetCurrentAudio());
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        AudioManager.Instance.FadeMusic(AudioManager.Instance.BackgroundMusic1, AudioManager.Instance.GetCurrentAudio());
    }

    public void QuitGame()
    {
        print("Quit");
        Application.Quit();
    }
}
