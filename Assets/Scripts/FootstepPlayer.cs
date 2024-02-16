using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class FootstepPlayer : MonoBehaviour
{
    [SerializeField] AudioClip clip;
    [SerializeField] float pitch;
    [SerializeField] float pitchRandomization;
    [SerializeField] float volume;
    [SerializeField] AudioSource sfx;
    [SerializeField] AudioMixerGroup mixerGroup;
    [SerializeField] PlayerMovement pm;

    public void PlaySound()
    {
        if (pm != null)
            if (pm.grounded && pm.GetComponent<Rigidbody>().velocity.magnitude > 0.1f)
            {
                sfx.clip = clip;
                sfx.pitch = pitch + Random.Range(-pitchRandomization, pitchRandomization);
                sfx.volume = volume;
                sfx.outputAudioMixerGroup = mixerGroup;
                sfx.PlayOneShot(clip);
            }
    }
}
