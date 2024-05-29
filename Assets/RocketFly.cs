using UnityEngine;

public class FlyCamControl : MonoBehaviour
{
    public float speed = 5.0f;

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float moveZ = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        float moveY = 0;

        // Adding altitude control with additional keys
        if (Input.GetKey(KeyCode.Space)) // Move Up
        {
            moveY = speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftControl)) // Move Down
        {
            moveY = -speed * Time.deltaTime;
        }

        // Apply movement
        transform.Translate(moveX, moveY, moveZ);

        // Optional: Add rotation controls
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(Vector3.up, -90 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(Vector3.up, 90 * Time.deltaTime);
        }
    }
}