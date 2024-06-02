using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class EllipticalOrbitTests
{
    private GameObject sunObject;
    private GameObject orbitingObject;
    private EllipticalOrbit ellipticalOrbit;

    [SetUp]
    public void Setup()
    {
        // Create a GameObject to represent the sun
        sunObject = new GameObject("Sun");

        // Create a GameObject to represent the orbiting object
        orbitingObject = new GameObject("OrbitingObject");

        // Add the EllipticalOrbit script to the orbiting object
        ellipticalOrbit = orbitingObject.AddComponent<EllipticalOrbit>();

        // Set the sun reference
        ellipticalOrbit.sun = sunObject.transform;

        // Set initial values for the ellipse
        ellipticalOrbit.semiMajorAxis = 10f;
        ellipticalOrbit.semiMinorAxis = 9.8f;
        ellipticalOrbit.orbitalPeriod = 365f;
    }

    [TearDown]
    public void Teardown()
    {
        // Destroy the created objects after each test
        Object.Destroy(orbitingObject);
        Object.Destroy(sunObject);
    }

    [Test]
    public void TestInitialPosition()
    {
        // Set an initial position for the orbiting object
        orbitingObject.transform.position = new Vector3(10f, 0f, 0f);

        // Call Start to initialize the script
        ellipticalOrbit.Start();

        // Check the initial position is set correctly relative to the sun
        Assert.AreEqual(new Vector3(10f, 0f, 0f), orbitingObject.transform.position);
    }

    [UnityTest]
    public IEnumerator TestUpdatePosition()
    {
        // Set an initial position for the orbiting object
        orbitingObject.transform.position = new Vector3(10f, 0f, 0f);

        // Call Start to initialize the script
        ellipticalOrbit.Start();

        // Simulate one second of time passing
        float timeToSimulate = 1f;
        float initialAngle = ellipticalOrbit.angle;

        // Update position based on the simulation time
        ellipticalOrbit.Update();

        // Wait for the time to pass
        yield return new WaitForSeconds(timeToSimulate);

        // Calculate the expected angle after the time has passed
        float expectedAngle = initialAngle + 2 * Mathf.PI / ellipticalOrbit.orbitalPeriod * timeToSimulate;

        // Calculate the expected position based on the new angle
        float expectedX = ellipticalOrbit.semiMajorAxis * Mathf.Cos(expectedAngle);
        float expectedZ = ellipticalOrbit.semiMinorAxis * Mathf.Sin(expectedAngle);
        Vector3 expectedPosition = new Vector3(expectedX, 0, expectedZ) + sunObject.transform.position;

        // Define a tolerance for floating-point comparisons
        float tolerance = 0.01f;

        // Check that the position has been updated correctly within the tolerance
        Assert.AreEqual(expectedPosition.x, orbitingObject.transform.position.x, tolerance);
        Assert.AreEqual(expectedPosition.y, orbitingObject.transform.position.y, tolerance);
        Assert.AreEqual(expectedPosition.z, orbitingObject.transform.position.z, tolerance);
    }
}
