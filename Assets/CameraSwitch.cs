using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera mainCamera;
    public Camera topDownCamera;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))  // Press 'C' to switch cameras
        {
            // Toggle camera states ensuring one is always enabled
            if (mainCamera.enabled)
            {
                mainCamera.enabled = false;
                topDownCamera.enabled = true;
            }
            else
            {
                mainCamera.enabled = true;
                topDownCamera.enabled = false;
            }
        }
    }
}
