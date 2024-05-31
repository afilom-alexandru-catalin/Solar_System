using UnityEngine;

public class ClickableObject : MonoBehaviour
{
    public GameObject informationPanel; // Assign a UI panel in the inspector

    void OnMouseDown() // This function is called when the object is clicked
    {
        informationPanel.SetActive(!informationPanel.activeSelf); // Toggle visibility of the information panel
    }
}