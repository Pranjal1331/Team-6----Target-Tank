using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using TMPro;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public static bool Gameispaused = false;
    public GameObject PauseMenuUI;
    public Slider VOL, sfxslider;

    
     void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Gameispaused)
            {
                Resume();
            }
            else
            {
                Pause();

            }
            //Gameispaused = !Gameispaused;
        }
    }

    void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
       
        FindObjectOfType<AudioManager>().Resume("Theme");
        FindObjectOfType<AudioManager>().Stop("Pausemusic"); 
        Gameispaused = false;
    }

    void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        
        FindObjectOfType<AudioManager>().Play("Pausemusic");
        FindObjectOfType<AudioManager>().Pause("Theme");
        Gameispaused = true;
        
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }
    
    public void Setvolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
        VOL.value = volume;
    }

    public void Setsfxvol(float volume)
    {
        audioMixer.SetFloat("sfxvol", volume);
        sfxslider.value = volume;
    }
}
