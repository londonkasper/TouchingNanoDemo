using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowScaling : MonoBehaviour
{

    public GameObject centerParticle;
    public GameObject blueParticle;
    public GameObject myArrow;

    // public Transform center;
    public float ScaleMultiplier;
    private Vector3 initialScale;

    public float maxDistance;
    //Color colorStart = Color.red;
    Color colorStart = new Color(1f, 0f, 0f, 0.1f);
    Color colorEnd = new Color(0f, 0f, 1f, 0.1f);

    //Color colorEnd = Color.blue;
    private Material currentMat;
    // Start is called before the first frame update
    void Start()
    {
        initialScale = myArrow.transform.localScale;
        currentMat = myArrow.GetComponent<Renderer>().material;
        
    }

    // Update is called once per frame
    void Update()
    {
        // need to have something to say if the two particles are so far apart (no force between the two) then the arrow disappears
        //myArrow.transform.LookAt(centerParticle.transform);
        float distance = Vector3.Distance(centerParticle.transform.position, blueParticle.transform.position);
        myArrow.transform.localScale = (initialScale/distance) * ScaleMultiplier;
        currentMat.color = Color.Lerp(colorStart, colorEnd, distance/maxDistance);
        //ChangeAlpha(currentMat, distance/maxDistance); // if dist = maxDistance it will be fully opaque
        ChangeAlpha(currentMat, Mathf.Clamp(distance/maxDistance, 0.25f, 1.0f ));
        
    }
    void ChangeAlpha(Material mat, float alphaVal)
    {
        Debug.Log("alphaVal: " + alphaVal);
        Color oldColor = mat.color;
        Color newColor = new Color(oldColor.r, oldColor.g, oldColor.b, alphaVal);
        mat.SetColor("_Color", newColor);

    }
}
