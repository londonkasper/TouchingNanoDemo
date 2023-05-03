using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shakingScript : MonoBehaviour
{
    public float shake_speed;
    public float shake_intensity;
    public Vector3 originPosition;
    public float rangeOfMovement;
    public bool isShaking = true;
 
    void Start()
    {
        originPosition = transform.position;
        Debug.Log("originPosition is " + originPosition);
    }
 
    void Update()
    {
        if (isShaking)
        {
            float goalz = Mathf.Clamp(originPosition.z + Random.insideUnitSphere.z, originPosition.z - rangeOfMovement, originPosition.z + rangeOfMovement);
            float goaly = Mathf.Clamp(originPosition.y + Random.insideUnitSphere.z, originPosition.y -rangeOfMovement, originPosition.y + rangeOfMovement);
            Vector3 goalPos = new Vector3(originPosition.x, goaly, goalz);
            float step = (shake_speed * Time.deltaTime)/10 ;//* shake_intensity
            transform.position = Vector3.MoveTowards(transform.position, goalPos, step); // need only y z movement, no x movement needed
        // MoveTowards(current, target, maxDistanceDelta)
        }
    }
}
