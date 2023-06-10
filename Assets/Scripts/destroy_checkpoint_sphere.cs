using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy_checkpoint_sphere : MonoBehaviour
{
    public ParticleSystem ps;
    public static int numberofspheres;
  
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            spehere_collitionDetector_Script.count++;

            Destroy(gameObject);
        }
    }
}
