using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spehere_collitionDetector_Script : MonoBehaviour
{
    public List<GameObject> sphere_checkpoints = new List<GameObject>();
    GameObject visibleSphere;
    public static int count;
    public GameObject DirectionArrow;


    void Start()
    {
        count = 0;
        sphere_checkpoints[count].SetActive(true); ;
    }
    void Update()
    {
        
        if (count < sphere_checkpoints.Count)
        {
            visibleSphere = sphere_checkpoints[count];
            visibleSphere.SetActive(true);
            DirectionArrow.transform.LookAt(visibleSphere.transform.position);
            
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.collider.name);
    }
}
