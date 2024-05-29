using UnityEngine;
using UnityEngine.UI;  // Include UI namespace to use UI elements

public class TimeController : MonoBehaviour
{
    public Slider timeSlider;  // Reference to the slider

    void Start()
    {
        // Optional: Initialize slider position
        timeSlider.value = 1;  // Default time scale (normal speed)
    }

    void Update()
    {
        // Adjust the time scale according to the slider's value
        Time.timeScale = timeSlider.value;
    }
}
