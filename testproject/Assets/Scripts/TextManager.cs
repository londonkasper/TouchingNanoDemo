using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class TextManager : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;

    public forceNoMovement forceVal; //object 
    // Start is called before the first frame update
    void Start()
    {
        forceVal = FindObjectOfType<forceNoMovement>();
        textDisplay = GetComponent<TextMeshProUGUI>();
        
    }

    
    void FixedUpdate()
    {
        textDisplay.text = "Van der Waal's Forces are the interactions particles experience as they get close together." + Environment.NewLine + Environment.NewLine+ "At a certain distance, two particles will experience an attractive force. This is called the Lennard-Jones Potential." + Environment.NewLine + Environment.NewLine+ "Try moving the blue particle away from the red particles, and see how the force decreases. Once it hits zero, you have passed the threshold." + Environment.NewLine+ Environment.NewLine+"Directional force vector for blue particle: "+ Environment.NewLine + forceVal.force.ToString();

    }
}
