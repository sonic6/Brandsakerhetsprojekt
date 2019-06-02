using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class SoundHandler : MonoBehaviour
{
    private enum type { fire_alarm, steps, door, fire_ex, fire }
    private AudioSource audio_source;
    public List<ParticleSystem> fires;
    private bool isPlaying = false;
    private VRTK_ControllerEvents events;
    private VRTK_ControllerReference controller_ref;

    [Tooltip("Decides the source of the sound.")]
    [SerializeField] private type _type = new type();

    [Tooltip("Link whatever sound you want to play.")]
    [SerializeField] private AudioClip _audio;

    [Tooltip("Decides the delay before the audio clip plays when the requirements for playing has been met.")]
    [SerializeField] private float audio_delay;


    private void Awake()
    {
        if (_type == type.steps)
        {
            events = FindObjectOfType<VRTK_ControllerEvents>();
            controller_ref = VRTK_DeviceFinder.GetControllerReferenceLeftHand();
        }
    }


    void Start()
    {
        if (GetComponent<AudioSource>())
        {
            audio_source = GetComponent<AudioSource>();
            audio_source.loop = true;
            audio_source.clip = _audio;
        }
        else if (!GetComponent<AudioSource>())
        {
            audio_source = gameObject.AddComponent<AudioSource>();
            audio_source.loop = true;
            audio_source.clip = _audio;
        }
    }


    private void Update()
    {
        switch (_type)
        {
            case type.fire_alarm:
                if (fires.Count > 0 && !isPlaying)
                {
                    StartCoroutine(PlaySound());
                }
                FireCheck();
                break;

            case type.fire:
                if (!isPlaying)
                    StartCoroutine(PlaySound());

                if (!IsBurning())
                    StopSound();
                break;

            case type.fire_ex:
                // TODO: Add logic for primary fire, or whatever fires the extinguisher.
                break;

            case type.door:
                // TODO: Add cool logic for door sound. Easy stuff actually.
                break;

            case type.steps:
                // TODO: You know the drill by this point..
                Stepping();
                break;

            default:
                break;
        }
    }


    /// <summary>
    /// Handles stepping sounds.
    /// </summary>
    private void Stepping ()
    {
        if (!isPlaying && events.touchpadPressed && VRTK_DeviceFinder.GetControllerVelocity(controller_ref) != Vector3.zero)
            StartCoroutine(PlaySound());

        else if (!events.touchpadPressed)
            StopSound();
    }


    /// <summary>
    /// Stops all sound from this gameobject.
    /// </summary>
    public void StopSound ()
    {
        isPlaying = false;
    }


    /// <summary>
    /// A lazy override for playing sick tunes. Use it if you wanna start the sound from outside the script.
    /// </summary>
    public void StartSoundOverride()
    {
        if (isPlaying == false)
            StartCoroutine(PlaySound());
    }


    /// <summary>
    /// Plays the sound.
    /// </summary>
    /// <returns></returns>
    private IEnumerator PlaySound ()
    {
        isPlaying = true;

        yield return new WaitForSeconds(audio_delay);
        Debug.Log("Sound is playing.");

        if (audio_source != null)
            audio_source.Play();

        yield return new WaitUntil(() => isPlaying == false);

        audio_source.Stop();
        Debug.Log("Sound has stopped.");
    }


    /// <summary>
    /// Is only used for the fire alarm. Checks if there're active fires in the scene.
    /// </summary>
    private void FireCheck ()
    {
        foreach (ParticleSystem fire in fires)
        {
            if (fire == null)
            {
                fires.Remove(fire);
            }
        }

        if (fires.Count == 0)
            isPlaying = false;
    }

    private bool IsBurning ()
    {
        foreach (ParticleSystem a in GetComponentsInChildren<ParticleSystem>())
        {
            if (a.gameObject.name == "Fire")
                return true;
        }

        return false;
    }
}
