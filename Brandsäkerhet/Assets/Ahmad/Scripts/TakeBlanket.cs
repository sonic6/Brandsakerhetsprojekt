using UnityEngine;
using VRTK;

public class TakeBlanket : MonoBehaviour
{
    [SerializeField] GameObject fireBlanket;

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponentInParent<VRTK_ControllerEvents>().triggerPressed == true)
        { 
            fireBlanket.SetActive(true);
            other.GetComponentInParent<VRTK_InteractGrab>().AttemptGrab();
        }
    }
}
