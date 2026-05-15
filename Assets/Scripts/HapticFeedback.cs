using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class HapticFeedback : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;

    void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.impulse.magnitude < 2f) return;

        // Find which hand is holding this object
        if (grabInteractable != null && grabInteractable.isSelected)
        {
            var interactor = grabInteractable.firstInteractorSelecting
                             as XRBaseControllerInteractor;

            if (interactor != null)
            {
                float intensity = Mathf.Clamp01(col.impulse.magnitude / 15f);
                interactor.SendHapticImpulse(intensity, 0.15f);
            }
        }
    }
}