using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class hapticController : MonoBehaviour
{
    public XRBaseController leftController, rightController;
    public float defaultAmplitude, defaultDuration;

    [ContextMenu("Send Haptics")]
    public void SendHaptics(){
        leftController.SendHapticImpulse(defaultAmplitude, defaultDuration);
        rightController.SendHapticImpulse(defaultAmplitude, defaultDuration);

    }

    public void SendHaptics(float amplitude, float duration){
        leftController.SendHapticImpulse(amplitude, duration);
        rightController.SendHapticImpulse(amplitude, duration);
    }
}
