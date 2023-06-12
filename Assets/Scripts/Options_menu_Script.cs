using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

// to swich cameras in the main menu when settings icon is pressed 
public class Options_menu_Script : MonoBehaviour
{
    public CinemachineVirtualCamera cam1;
    public CinemachineVirtualCamera cam2;
    public GameObject button1;
    public GameObject button2;
    public GameObject cnvs;
    bool isCam = true;
 
    
    public void changeCamPriority()
    {
        isCam = !isCam;

        if (isCam)
        {
            cam1.Priority = 11;
            cam2.Priority = 10;
            button1.SetActive(true);
            button2.SetActive(false);
            cnvs.SetActive(true);
        }
        if (!isCam)
        {
            cam1.Priority = 10;
            cam2.Priority = 11;
            button1.SetActive(false);
            button2.SetActive(true);
            cnvs.SetActive(false);
        }
    }
}
