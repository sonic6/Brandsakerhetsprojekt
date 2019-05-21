/*
 *  Put this script on the fire effect gameobject.
 *  That way, the smog effect will always start when 
 *  the fire is created.
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SmokeBuildUp : MonoBehaviour
{
    private enum renderMode { Exponential };

    [Tooltip("The speed at whitch the smoke builds up.(not implemented yet.)")]
    [SerializeField] private float buildUpSpeed;

    [Tooltip("Makes the build up exponential. This is purely a mechanical choice, and shouldn't have much impact on gameplay.")]
    [SerializeField] private renderMode rm = new renderMode();

    void Start()
    {
        if (rm == renderMode.Exponential)
        {
            RenderSettings.fogMode = FogMode.Exponential;
            StartCoroutine("ExponentialBuildUp");
        }
        //else if (rm == renderMode.Linear)
        //{
        //    RenderSettings.fogMode = FogMode.Linear;
        //    StartCoroutine("LinearBuildUp");
        //}
        RenderSettings.fogColor = new Color(0.2f, 0.2f, 0.2f);
        RenderSettings.fog = true;
    }

    private IEnumerator ExponentialBuildUp ()
    {
        RenderSettings.fogDensity = 0.0f;
        while (true)
        {
            RenderSettings.fogDensity += (buildUpSpeed / 10000);
            yield return new WaitForSeconds(0.01f);
        }
    }

    private IEnumerator LinearBuildUp ()
    {
        RenderSettings.fogEndDistance = 10;
        RenderSettings.fogStartDistance = 0;
        while (true)
        {
            RenderSettings.fogEndDistance -= 0.05f;
            yield return new WaitForSeconds(1);
        }
    }
}
