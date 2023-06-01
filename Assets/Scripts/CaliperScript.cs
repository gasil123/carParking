using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaliperScript : MonoBehaviour
{
    public Transform disk;
    // Start is called before the first frame update
    private void Update()
    {
        float targetRotationY = disk.rotation.eulerAngles.y;

        // Apply the retrieved Y-axis rotation to the current game object
        Vector3 currentEulerAngles = transform.rotation.eulerAngles;
        currentEulerAngles.y = targetRotationY;
        transform.rotation = Quaternion.Euler(currentEulerAngles);
    }
}
