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
        //textDisplay = forceVal.force();
        
    }

    
    void FixedUpdate()
    {
        //forceVal = FindObjectOfType<forceNoMovement>();
        //Debug.Log("Coming from TextManager.cs" + forceVal.force);
        textDisplay.text = "Force vector for blue particle: "+ Environment.NewLine + forceVal.force.ToString();

    }
}
