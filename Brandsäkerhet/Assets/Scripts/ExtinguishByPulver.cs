using UnityEngine;

public class ExtinguishByPulver : MonoBehaviour
{
    private bool pulverCollided;
    
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
            myStartLife.startLifetimeMultiplier = Mathf.MoveTowards(myStartLife.startLifetimeMultiplier, 0f, Time.deltaTime);

            pulverCollided = false;

            if (myStartLife.startLifetimeMultiplier < 0.01f && GetComponentInChildren<ParticleSystem>())
            {
                Destroy(GetComponentInChildren<ParticleSystem>()); //once for the fire particles
                Destroy(GetComponentInChildren<ParticleSystem>()); //once for the smoke particles
                InfoCollector.fireCondition = false;
            }
        }

        
    }

    private void Update()
    {
        DecreaseFire();
    }
}
