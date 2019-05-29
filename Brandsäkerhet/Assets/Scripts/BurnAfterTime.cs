﻿using System.Collections;
using UnityEngine;

public class BurnAfterTime : MonoBehaviour
{
    public bool activateScenario;
    [SerializeField] float startBurningAfterSeconds;
    private GameObject myFire;
    SmokeBuildUp mySmokeBuilder;

    private void Awake()
    {
        mySmokeBuilder = GameObject.FindObjectOfType<SmokeBuildUp>();
        mySmokeBuilder.enabled = false;
        myFire = transform.GetComponentInChildren<ParticleSystem>().gameObject;
        myFire.SetActive(false);
    }

    void Start()
    {
        if (activateScenario == true)
        {
            StartCoroutine(BurnNow());
        }
    }

    IEnumerator BurnNow()
    {
        yield return new WaitForSeconds(startBurningAfterSeconds);
        myFire.SetActive(true);
        mySmokeBuilder.enabled = true;
    }
    
}
