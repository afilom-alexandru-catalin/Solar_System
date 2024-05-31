using UnityEngine;

public class ProximityDisplay : MonoBehaviour
{
    public GameObject informationPanel;  // Drag the Text Panel to this field in the Inspector

    void Start()
    {
        if (informationPanel != null)
            informationPanel.SetActive(false);  // Ensure the panel is hidden initially
    }

    // Triggered when another collider enters this trigger collider
    void OnTriggerEnter(Collider other)
    {
		Debug.Log("Enter");

        if (other.CompareTag("Player"))  // Make sure your avatar has the tag "Player"
        {
            informationPanel.SetActive(true);
        }
    }

    // Triggered when another collider exits this trigger collider
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            informationPanel.SetActive(false);
        }
    }
}
