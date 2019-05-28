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
    private enum smokeMode { Even, Vertical, None };

    [Tooltip("The speed at whitch the smoke builds up.(not implemented yet.)")]
    [SerializeField] private float buildUpSpeed;

    [Tooltip("Delay in seconds before the smoke starts to build up.")]
    [SerializeField] private float smokeDelay;

    [Tooltip("Makes the build up exponential. This is purely a mechanical choice, and shouldn't have much impact on gameplay.")]
    [SerializeField] private renderMode rm = new renderMode();

    [Tooltip("Decides how the smoke builds up in the world. \n" +
        "Standard: smoke builds up evenly. \n" +
        "Vertical: Smoke builds up vertically (This might murder your cpu). \n" +
        "None: Smoke doesn't build up (Best performance, but sad as fuck).")]
    [SerializeField] private smokeMode smoke = new smokeMode();

    [Tooltip("This one's only important if you're using Vertical smokeMode. Otherwise, ignore. \n " +
        "(I will make the script more self sufficient at a later date.. If I have time.)")]
    [SerializeField] private GameObject g_smoke;

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

        if (smoke == smokeMode.Even)
        {
            RenderSettings.fogColor = new Color(0.2f, 0.2f, 0.2f);
            RenderSettings.fog = true;
        }
        else if (smoke == smokeMode.Vertical)
        {

        }
    }

    private IEnumerator ExponentialBuildUp ()
    {
        yield return new WaitForSeconds(smokeDelay);

        RenderSettings.fogDensity = 0.0f;
        while (smoke == smokeMode.Even)
        {
            if (g_smoke.activeInHierarchy)
                g_smoke.SetActive(false);

            RenderSettings.fogDensity += (buildUpSpeed / 10000);
            yield return new WaitForSeconds(0.01f);
        }
        while (smoke == smokeMode.Vertical)
        {
            if (!g_smoke.activeInHierarchy)
                g_smoke.SetActive(true);

            g_smoke.GetComponent<ParticleSystem>().startLifetime += (buildUpSpeed / 500);
            yield return new WaitForSeconds(0.01f);
        }
    }
}
