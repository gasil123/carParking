using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy_checkpoint_sphere : MonoBehaviour
{
    public static int numberofspheres;
  
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CarTimerScript.timer += 5.0f;
            spehere_collitionDetector_Script.count++;
            gameObject.SetActive(false);
        }
    }
}
