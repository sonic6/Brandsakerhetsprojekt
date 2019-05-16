using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Liquid : MonoBehaviour
{
    [SerializeField] GameObject LiquidUnit;
    [SerializeField] Transform bottleCap;
    [SerializeField] float time;
    [SerializeField] float timeMax;

    void Update()
    {
        time = time + 1 * Time.deltaTime;

        if ((bottleCap.eulerAngles.x >= 90 && bottleCap.eulerAngles.x <= 270) || (bottleCap.eulerAngles.z >= 90 && bottleCap.eulerAngles.z <= 270))
        {
            if (time >= timeMax)
            {
                Instantiate(LiquidUnit, bottleCap.position, transform.rotation);
                time = 0;
            }
        }
    }
}
