using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowScaling : MonoBehaviour
{

    public GameObject centerParticle;
    public GameObject myArrow;
    // public Transform center;
    public float ScaleMultiplier;
    private Vector3 initialScale;

    // Start is called before the first frame update
    void Start()
    {
        initialScale = myArrow.transform.localScale;
        
    }

    // Update is called once per frame
    void Update()
    {
        // need to have something to say if the two particles are so far apart (no force between the two) then the arrow disappears
        //myArrow.transform.LookAt(centerParticle.transform);
        float distance = Vector3.Distance(centerParticle.transform.position, myArrow.transform.position);
        myArrow.transform.localScale = (initialScale/distance) * ScaleMultiplier;
    }
}
