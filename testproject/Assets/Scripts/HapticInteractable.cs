using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
[System.Serializable]
public class Haptic{

    public float intensity, duration;
    
    public GameObject centerParticle;
    public GameObject blueParticle;
    public float maxDistance;
    public void TriggerHaptic(BaseInteractionEventArgs eventArgs){
        if(eventArgs.interactorObject is XRBaseControllerInteractor controllerInteractor){
            TriggerHaptic(controllerInteractor.xrController);
        }
    }

    public void TriggerHaptic(XRBaseController controller){
       if(intensity > 0){
            float distance = Vector3.Distance(centerParticle.transform.position, blueParticle.transform.position);
            controller.SendHapticImpulse(1.0f - distance/maxDistance, duration);  
       } 
    }
}
public class HapticInteractable : MonoBehaviour
{
    

    XRBaseController controller;
    public Haptic hapticOnActivated;
    public Haptic hapticHoverEntered;
    public Haptic hapticHoverExited;
    public Haptic hapticSelectEntered;
    public Haptic hapticSelectExited;
    
    XRBaseInteractable interactable; 
    void Start(){
        interactable = GetComponent<XRBaseInteractable>();
        interactable.activated.AddListener(hapticOnActivated.TriggerHaptic);
        interactable.hoverEntered.AddListener(hapticHoverEntered.TriggerHaptic);
        interactable.hoverExited.AddListener(hapticHoverExited.TriggerHaptic);
        interactable.selectEntered.AddListener(hapticSelectEntered.TriggerHaptic); // when select is entered call the trigger haptic function using the set parameters 
        interactable.selectExited.AddListener(hapticSelectExited.TriggerHaptic);

    }

}
