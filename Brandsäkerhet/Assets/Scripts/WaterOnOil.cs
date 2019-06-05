using UnityEngine;

public class WaterOnOil : MonoBehaviour
{
    private bool waterCollided;
    [SerializeField] float fireRadiusOnIncrease = 1f;
    [SerializeField] float fireAmountIncrease = 40f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "water")
        {
            waterCollided = true;
        }
    }

    private void IncreaseFire()
    {
        if (waterCollided == true)
        {
            var myShape = GetComponentInChildren<ParticleSystem>().shape; //You can only modify shape if it's within a new variable you've created
            var myEmission = GetComponentInChildren<ParticleSystem>().emission;
            myShape.radius = Mathf.MoveTowards(myShape.radius, fireRadiusOnIncrease, Time.deltaTime * 2);
            myEmission.rateOverTime = fireAmountIncrease;
            InfoCollector.fireIncreased = true;
            waterCollided = false;
        }
    }

    private void Update()
    {
        IncreaseFire();
    }
}
