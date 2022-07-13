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
    public GameObject tank, proj;

    
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
        tank.GetComponent<Playertankcontroller>().enabled = true;
        tank.GetComponent<TankTurrent>().enabled = true;
        tank.SetActive(true);
        proj.GetComponent<Projectile>().enabled = true;
        FindObjectOfType<AudioManager>().Resume("Theme");
        FindObjectOfType<AudioManager>().Resume("Tanktrack");
        FindObjectOfType<AudioManager>().Stop("Pausemusic"); 
        Gameispaused = false;
    }

    void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        tank.GetComponent<Playertankcontroller>().enabled = false;
        tank.GetComponent<TankTurrent>().enabled = false;
        tank.SetActive(false);
        proj.GetComponent<Projectile>().enabled = false;
        FindObjectOfType<AudioManager>().Play("Pausemusic");
        FindObjectOfType<AudioManager>().Pause("Theme");
        FindObjectOfType<AudioManager>().Pause("Tanktrack");
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
