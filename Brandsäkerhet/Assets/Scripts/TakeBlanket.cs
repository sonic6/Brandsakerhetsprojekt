using UnityEngine;
using VRTK;

public class TakeBlanket : MonoBehaviour
{
    [SerializeField] GameObject fireBlanket;

    private void OnTriggerStay(Collider other)
    {
        if (other.transform.parent.transform.parent.GetComponent<VRTK_ControllerEvents>().triggerClicked == true) //This will check if the trigger button of the VR controller that's colliding is all the way down
        {
            fireBlanket.SetActive(true);
        }
    }
}
