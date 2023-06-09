using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy_checkpoint_sphere : MonoBehaviour
{
    public static int numberofspheres;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            spehere_collitionDetector_Script.count++;
            Destroy(gameObject);
        }
    }
}
