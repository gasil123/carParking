using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelWon_Script : MonoBehaviour
{
    public GameObject LevelWonUI;
    public GameObject GameUi;
    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(levelwon());
        GameUi.SetActive(false);
    }

    IEnumerator levelwon()
    {
        yield return new WaitForSeconds(3);
        Time.timeScale = 0;
        LevelWonUI.SetActive(true);
       
    }
}
