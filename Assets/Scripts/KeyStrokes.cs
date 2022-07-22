using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyStrokes : MonoBehaviour
{
    Pause_menu pause_Menu;

    private void Start()
    {
        pause_Menu = FindObjectOfType<Pause_menu>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Pause_menu.isGamePaused)
            {
                pause_Menu.Resume();
            }
            else
            {
                pause_Menu.Pause();
            }

        }

    }
}
