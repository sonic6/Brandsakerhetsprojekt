using UnityEngine;

public class WaterOnOil : MonoBehaviour
{
    private bool waterCollided;

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
            myShape.radius = Mathf.Lerp(0.1f, 30f, Time.deltaTime);
            
            waterCollided = false;
        }
    }

    private void Update()
    {
        IncreaseFire();
    }
}
