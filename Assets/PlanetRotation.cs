using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetRotation : MonoBehaviour
{
    public float rotationSpeed = 10f; // Rotation speed in degrees per second
    public float axialTilt = 23.44f; // Axial tilt in degrees

    void Start()
    {
        // Apply the axial tilt at the start
        transform.rotation = Quaternion.Euler(axialTilt, 0, 0) * transform.rotation;
    }

    void Update()
    {
        // Determine the rotation direction based on the sign of rotationSpeed
        float direction = Mathf.Sign(rotationSpeed);

        // Rotate the planet around its tilted axis
        transform.Rotate(Vector3.up, Mathf.Abs(rotationSpeed) * Time.deltaTime * direction, Space.Self);
    }
}
