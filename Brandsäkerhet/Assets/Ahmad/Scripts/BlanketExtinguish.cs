using UnityEngine;

public class BlanketExtinguish : MonoBehaviour
{
    public int myTriggers;
    public GameObject[] triggerChildren;
    [SerializeField] Animator alarm;

    private void Start()
    {
        for (int i = 0; i < triggerChildren.Length; i++)
        {
            triggerChildren[i].AddComponent<TriggersOnMe>();
        }
    }

    private void FixedUpdate()
    {
        if (myTriggers == triggerChildren.Length)
        {
            Destroy(GetComponentInChildren<ParticleSystem>());
            Destroy(GetComponentInChildren<Light>());
            alarm.SetBool("light", false);
            InfoCollector.fireCondition = false;
        }
    }
}

public class TriggersOnMe : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "blanket")
            transform.GetComponentInParent<BlanketExtinguish>().myTriggers++;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "blanket")
            transform.GetComponentInParent<BlanketExtinguish>().myTriggers--;
    }
}
