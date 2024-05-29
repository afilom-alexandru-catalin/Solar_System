using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalUIHandler : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] GameObject earth;

    // Start is called before the first frame update
    void Start()
    {
        if (slider == null)
            return;
        slider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ValueChangeCheck()
    {
        if(slider == null || earth == null)
            return;
        Debug.Log(slider.value);
    }
}
