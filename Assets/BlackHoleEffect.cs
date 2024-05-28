using UnityEngine;

public class BlackHoleForce : MonoBehaviour
{
    public float gravity = -10f;
    public float destroyRadius = 1.0f; // Distance from center at which objects will disappear

    void OnTriggerStay(Collider other)
    {
        if (other.attachedRigidbody)
        {
            Vector3 direction = other.transform.position - transform.position; // Direction from black hole to the object
            float distance = direction.magnitude;

            if (distance < destroyRadius)
            {
                Destroy(other.gameObject); // Destroys the object when it's close enough
            }
            else
            {
                other.attachedRigidbody.AddForce(direction.normalized * gravity * other.attachedRigidbody.mass);
            }
        }
    }
}
