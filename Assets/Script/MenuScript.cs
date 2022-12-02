using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject missionMenu;
    public ObjectableZombie objectableZombie;
    public ObjectPickUp objectPickUp;
    public SwitchScene scene;
    public static bool isPaused = false;
    private AudioSource[] allAudioSources;
    public AudioSource src;
    void StopAllAudio() {
        allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        foreach( AudioSource audioS in allAudioSources) {
            audioS.Stop();
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                resume();
                Cursor.lockState = CursorLockMode.Locked;
            }
            else
            {
                pause();
                Cursor.lockState = CursorLockMode.None;
            }
        }
        else if (Input.GetKeyDown("tab"))
        {
            if (isPaused)
            {
                closeMission();
                Cursor.lockState = CursorLockMode.Locked;
            }
            else
            {
                showMission();
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }
    public void showMission()
    {
        missionMenu.SetActive(true);
        isPaused = true;
        Time.timeScale = 0;
        StopAllAudio();
    }

    public void closeMission()
    {
        missionMenu.SetActive(false);
        isPaused = false;
        Time.timeScale = 1f;
        src.Play();
    }

    public void resume()
    {
        pauseMenu.SetActive(false);
        isPaused = false;
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        src.Play();
    }

    public void pause()
    {
        pauseMenu.SetActive(true);
        isPaused = true;
        Time.timeScale = 0;
        StopAllAudio();
    }

    public void restart()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 1;
        //cek kondisi
        if (objectableZombie.isScene1 == true)
        {
            objectPickUp.isPickedUp = false;
            scene.LoadScene(1);
        }
        else if (objectableZombie.isScene2 == true)
        {
            objectableZombie.isKillZombie = false;
            objectableZombie.isScene1 = false;
            objectableZombie.Zombie = 10;
            objectPickUp.isPickedUp = true;
            scene.LoadScene(3);
        }
        else if (objectableZombie.isScene3 == true)
        {
            objectableZombie.isKillZombie = false;
            objectableZombie.isScene2 = false;
            objectableZombie.Zombie = 10;
            objectPickUp.isPickedUp = true;
            scene.LoadScene(4);
        }
        else if (objectableZombie.isScene4 == true)
        {
            objectableZombie.isKillZombie = false;
            objectableZombie.isScene3 = false;
            objectPickUp.isPickedUp = true;
            objectableZombie.Zombie = 2;
            scene.LoadScene(5);
        }
        else
        {
            return;
        }

    }

    public void mainMenu()
    {
        Time.timeScale = 1;
        objectableZombie.isKillZombie = false;
        objectableZombie.isScene3 = false;
        objectableZombie.isScene2 = false;
        objectableZombie.isScene1 = false;
        objectableZombie.isScene4 = false;
        objectPickUp.isPickedUp = false;
        objectPickUp.isPickMagicItem = false;
        objectableZombie.Zombie = 10;
        scene.LoadScene(0);
    }


}
