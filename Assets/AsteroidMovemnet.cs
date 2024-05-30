using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
    public Vector3 moveDirection = new Vector3(-1, 0, 0); // Movement direction
    public float speed = 5.0f; // Speed of movement

    // Update is called once per frame
    void Update()
    {
        // Move the asteroid in the specified direction at the specified speed
        transform.Translate(moveDirection.normalized * speed * Time.deltaTime);
    }
}
