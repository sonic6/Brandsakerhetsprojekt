﻿using VRTK;
using UnityEngine;

public class FireExtinguisher : MonoBehaviour
{
    private SoundHandler _audio;

    [SerializeField] GameObject pulver;
    [SerializeField] Transform nozzle;
    private float time;
    [Tooltip("a lower number makes it spray more often")]
    [SerializeField] private float sprayFrequency;
    [SerializeField] float pulverThrust;


    private void Start()
    {
        if (GetComponent<SoundHandler>())
            _audio = GetComponent<SoundHandler>();
        else
            Debug.LogError(gameObject.name + " requires a soundhandler to play extinguishing sounds etc.");
    }


    void Update()
    {
        time = time + 1 * Time.deltaTime;

        if (transform.GetComponentInParent<SteamVR_TrackedObject>() != null)
        {
            VRTK_ControllerEvents controller = GetComponentInParent<SteamVR_TrackedObject>().gameObject.GetComponentInChildren<VRTK_ControllerEvents>();
            if (time >= sprayFrequency && controller.gripClicked == true)
            {
                GameObject newPulver = Instantiate(pulver, nozzle.position, transform.rotation);
                newPulver.GetComponent<Rigidbody>().AddRelativeForce(Vector3.back * pulverThrust);
                time = 0;

                _audio.StartSoundOverride();
            }

            if (!controller.gripClicked)
            {
                _audio.StopSound();
            }
        }
    }
}
