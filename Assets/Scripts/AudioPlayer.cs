using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField] AudioClip clip;
    [SerializeField] float pitch;
    [SerializeField] float pitchRandomization;
    [SerializeField] float volume;
    [SerializeField] AudioSource sfx;
    [SerializeField] AudioMixerGroup mixerGroup;
    public void PlaySound()
    {
        sfx.clip = clip;
        sfx.pitch = pitch + Random.Range(-pitchRandomization, pitchRandomization);
        sfx.volume = volume;
        sfx.outputAudioMixerGroup = mixerGroup;
        sfx.PlayOneShot(clip);
    }
}
