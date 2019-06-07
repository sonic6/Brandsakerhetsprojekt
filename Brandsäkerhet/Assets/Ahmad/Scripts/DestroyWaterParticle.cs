using UnityEngine;
using System.Collections;

public class DestroyWaterParticle : MonoBehaviour
{
    [SerializeField] float destroyWaterAfterSeconds = 3f;

    private void Start()
    {
        StartCoroutine(DestroyWater());
    }

    IEnumerator DestroyWater()
    {
        yield return new WaitForSeconds(destroyWaterAfterSeconds);
        Destroy(gameObject);
    }
}
