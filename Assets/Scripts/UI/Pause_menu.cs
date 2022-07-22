using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause_menu : MonoBehaviour
{
    MenuButtonController menuButtonController;

    public static bool isGamePaused;

    [SerializeField]
    GameObject pauseMenuUI;

    Player_controller playerController; 

    private void Start()
    {
        if(!isGamePaused)
        {
            pauseMenuUI.SetActive(false);
        }
        menuButtonController = GetComponent<MenuButtonController>();
        playerController = FindObjectOfType<Player_controller>();
    
    }
    private void Update()
    {

        if(this.menuButtonController != null && Input.GetAxis("Submit") == 1)
        {
            switch (menuButtonController.index)
            {
                case 0:
                    Resume();
                    break;

                case 1:
                    Menu();
                    break;

                case 2:
                    Quit();
                    break;

                default:
                    break;

            }

        }   
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isGamePaused = true;
        playerController.enabled = false;
     
        
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
        playerController.enabled = true;
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
        Resume();
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Application Closed");
    }


}
