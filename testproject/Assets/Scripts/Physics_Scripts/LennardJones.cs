using UnityEngine;

public class LennardJones : MonoBehaviour {

    public float epsilon; // well depth of the Lennard-Jones potential
    public float sigma; // distance at which the Lennard-Jones potential energy is zero
    public GameObject otherParticle; // add other particle to interact with

    
    public static Vector3 CalculateForce(Vector3 position1, Vector3 position2, float radius1, float radius2, float epsilon, float sigma) {
        // Calculate the distance between the two particles
        float distance = Vector3.Distance(position1, position2);
        // Calculate the force between the two particles
        Vector3 direction = position1 - position2;
        float forceMagnitude = -12 * epsilon * (Mathf.Pow(sigma / distance, 13) - Mathf.Pow(sigma / distance, 7));
        Vector3 force = direction.normalized * forceMagnitude;
        // Apply a repulsive force if the particles overlap
        float overlap = distance - radius1 - radius2;
        if (overlap < 0) {
            force -= direction.normalized * Mathf.Pow(-overlap, 1.5f); // This seems like it may be too strong, consider lowering the change
        }
        return force;
    }

    void FixedUpdate() { // Fixed update for physics 
        // Get the positions and radii of the two particles
        Vector3 position1 = transform.position;
        float radius1 = transform.localScale.x / 2f; // The scale of the particles has a huge effect on the force <---- WARNING
        Vector3 position2 = otherParticle.transform.position;
        float radius2 = otherParticle.transform.localScale.x / 2f;
        // Calculate the force between the two particles
        Vector3 force = CalculateForce(position1, position2, radius1, radius2, epsilon, sigma); // This is Van der Waal's force
        // Apply the force to the particle
        //force = force * 10f; //commented out for magnitude
        force = force * 0.005f;
        //Debug.Log("Value of force calculation: " + force);
        GetComponent<Rigidbody>().AddForce(force);
    }
}

