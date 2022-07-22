using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    MenuButtonController menuButtonController;

    [SerializeField]
    GameObject Setting;

    [SerializeField]
    GameObject mainMenu;

    public float volume;

    public AudioMixer audioMixer;



    private void Start()
    { 
        mainMenu.SetActive(true);
        Setting.SetActive(false);

        menuButtonController = GetComponent<MenuButtonController>();
    }
    private void Update()
    {
        if(this.menuButtonController != null && Input.GetAxis("Submit") == 1 && mainMenu.activeInHierarchy)
        {
            switch (menuButtonController.index)
            {
                case 0:
                    
                    NewGame();
                    
                    break;

                case 1:
                    
                    Options();
                    
                  
                    break;

                case 2:

                    Quit();

                    break;

                default:

                    break;

            }

        }
           
    }

    private void Options()
    {
        mainMenu.gameObject.SetActive(false);
        Setting.gameObject.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Application Closed");
    }

    public void NewGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);   
    }

    public void AdjustVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }

}
