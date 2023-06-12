using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelWon_Script : MonoBehaviour
{
    public GameObject LevelWonUI;
    public GameObject GameUi;
    public GameObject DirectionArrow;
    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(levelwon());
        GameUi.SetActive(false);
        DirectionArrow.SetActive(false);

    }

    IEnumerator levelwon()
    {
        yield return new WaitForSeconds(2.5f);
        Time.timeScale = 0;
        LevelWonUI.SetActive(true);
    }
}
