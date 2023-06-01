using UnityEngine;

public class TyreRotation : MonoBehaviour
{
    public WheelCollider wheelCollider;

    private void Update()
    {
        // Get the current rotation of the wheel collider
        Quaternion rotation;
        Vector3 position;
        wheelCollider.GetWorldPose(out position, out rotation);

        // Apply the rotation and position to the tire mesh
        transform.rotation = rotation;
        transform.position = position;    }
}
