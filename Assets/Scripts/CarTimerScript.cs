using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CarTimerScript : MonoBehaviour
{
    public TextMeshProUGUI timerText;

    public static float timer;

    public GameObject GameOverUi;
    public GameObject ControlButtonsUi;
    public GameObject PauseButton;

    private void Awake()
    {
        ControlButtonsUi.SetActive(true);
        PauseButton.SetActive(true);
        GameOverUi.SetActive(false);
        Time.timeScale = 1;
        timer = 4f;
    }
    private void LateUpdate()
    {
        timer = timer -= 0.3f * Time.deltaTime;

        string formattedValue = timer.ToString("F2");

        timerText.text = formattedValue;

        //Debug.Log("remaining time" + timer);

        if (timer <= 0)
        {
            ControlButtonsUi.SetActive(false);
            PauseButton.SetActive(false);
            GameOverUi.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
