using System.Collections;
using UnityEngine;

public class BurnAfterTime : MonoBehaviour
{
    public bool activateScenario;
    [SerializeField] float startBurningAfterSeconds;
    private GameObject myFire;
    private GameObject mySmoke;
    SmokeBuildUp mySmokeBuilder;
    [SerializeField] SoundHandler alarmSound;

    private void Awake()
    {
        mySmokeBuilder = GameObject.FindObjectOfType<SmokeBuildUp>();
        mySmokeBuilder.enabled = false;
        myFire = transform.GetComponentInChildren<ParticleSystem>().gameObject;
        myFire.SetActive(false);
        mySmoke = transform.GetComponentInChildren<ParticleSystem>().gameObject;
        mySmoke.SetActive(false);
        alarmSound.enabled = false;
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
        mySmoke.SetActive(true);
        mySmokeBuilder.enabled = true;
        alarmSound.enabled = true;
    }
    
}
