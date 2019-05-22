using VRTK;
using UnityEngine;

public class FireExtinguisher : MonoBehaviour
{
    [SerializeField] GameObject pulver;
    [SerializeField] Transform nozzle;
    private float time;
    [Tooltip("a lower number makes it spray more often")]
    [SerializeField] private float sprayFrequency;
    [SerializeField] float pulverThrust;

    void Update()
    {
        time = time + 1 * Time.deltaTime;

        if (transform.GetComponentInParent<SteamVR_TrackedObject>() != null)
        {
            if (time >= sprayFrequency && GetComponentInParent<SteamVR_TrackedObject>().gameObject.GetComponentInChildren<VRTK_ControllerEvents>().gripPressed == true)
            {
                GameObject newPulver = Instantiate(pulver, nozzle.position, transform.rotation);
                newPulver.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * pulverThrust);
                time = 0;
            }
        }
    }
}
