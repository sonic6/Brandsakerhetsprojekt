using UnityEngine;

public class ExtinguishByPulver : MonoBehaviour
{
    private bool pulverCollided;
    bool mySmokeBool = false;
    [SerializeField] Animator alarm;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "pulver")
        {
            pulverCollided = true;
        }
    }

    private void DecreaseFire()
    {
        if (pulverCollided == true)
        {
            var myStartLife = GetComponentInChildren<ParticleSystem>().main;
            myStartLife.startLifetimeMultiplier = Mathf.MoveTowards(myStartLife.startLifetimeMultiplier, 0f, Time.deltaTime * 2);

            pulverCollided = false;

            if (myStartLife.startLifetimeMultiplier < 0.01f && GetComponentInChildren<ParticleSystem>())
            {
                Destroy(GetComponentInChildren<ParticleSystem>()); //to destroy the fire particles
                mySmokeBool = true;
                GetComponentInChildren<Light>().enabled = false;
                InfoCollector.fireCondition = false;
            }
            if(mySmokeBool == true)
            {
                var mySmoke = GetComponentInChildren<ParticleSystem>().main;
                mySmoke.loop = false;
                alarm.SetBool("light", false);
            }
        }

        
    }

    private void Update()
    {
        DecreaseFire();
    }
}
