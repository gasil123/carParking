using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Ui_PauseMenu : MonoBehaviour
{
    bool isPauseMenu = false;

    public GameObject pausemenu;
    public GameObject pauseButton;
    public GameObject controlButtonsUi;

    public void PauseMenuActiveDeactive()
    {
        isPauseMenu = !isPauseMenu;

        if (isPauseMenu)
        {
            Time.timeScale = 0;
            
            pausemenu.SetActive(true);
            pauseButton.SetActive(false);
            controlButtonsUi.SetActive(false);
        }
        if (!isPauseMenu)
        {
            Time.timeScale = 1;
            pausemenu.SetActive(false);
            pauseButton.SetActive(true);
            controlButtonsUi.SetActive(true);
        }
    }
   
}
