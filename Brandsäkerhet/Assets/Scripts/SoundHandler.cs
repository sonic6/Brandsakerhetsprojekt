using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundHandler : MonoBehaviour
{
    private enum type { fire_alarm, steps, door, fire_ex, fire }
    private AudioSource audio_source;
    public List<GameObject> fires;
    private bool isPlaying = false;

    [Tooltip("Decides the source of the sound.")]
    [SerializeField] private type _type = new type();

    [Tooltip("Link whatever sound you want to play.")]
    [SerializeField] private AudioClip _audio;

    [Tooltip("Decides the delay before the audio clip plays when the requirements for playing has been met.")]
    [SerializeField] private float audio_delay;


    void Start()
    {
        if (GetComponent<AudioSource>())
        {
            audio_source = GetComponent<AudioSource>();
            audio_source.clip = _audio;
        }
        else if (!GetComponent<AudioSource>())
        {
            audio_source = gameObject.AddComponent<AudioSource>();
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
                StartCoroutine(PlaySound());
                break;

            case type.fire_ex:
                // TODO: Add logic for primary fire, or whatever fires the extinguisher.
                break;

            case type.door:
                // TODO: Add cool logic for door sound. Easy stuff actually.
                break;

            case type.steps:
                // TODO: You know the drill by this point..
                break;

            default:
                break;
        }
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
            PlaySound();
    }


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
        foreach (GameObject fire in fires)
        {
            if (fire == null)
            {
                fires.Remove(fire);
            }
        }

        if (fires.Count == 0)
            isPlaying = false;
    }
}
