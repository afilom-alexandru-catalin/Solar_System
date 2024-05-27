using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonOrbit : MonoBehaviour
{
    public Transform earth; // Reference to the Earth
    public float semiMajorAxis = 2f; // Semi-major axis of the Moon's ellipse
    public float semiMinorAxis = 1.8f; // Semi-minor axis of the Moon's ellipse
    public float orbitalPeriod = 27.3f; // Orbital period in days (Moon's orbital period around Earth)

    private Vector3 initialPosition;
    private float angle; // Current angle in radians

    void Start()
    {
        // Store the initial position of the Moon relative to the Earth
        initialPosition = transform.position - earth.position;

        // Calculate the initial angle based on the initial position
        angle = Mathf.Atan2(initialPosition.z / semiMinorAxis, initialPosition.x / semiMajorAxis);
    }

    void Update()
    {
        // Calculate the angle based on the time and orbital period
        angle += 2 * Mathf.PI / orbitalPeriod * Time.deltaTime;

        // Calculate the position in polar coordinates relative to the initial position
        float x = semiMajorAxis * Mathf.Cos(angle);
        float z = semiMinorAxis * Mathf.Sin(angle);

        // Set the position relative to the Earth
        transform.position = new Vector3(x, 0, z) + earth.position;
    }
}
