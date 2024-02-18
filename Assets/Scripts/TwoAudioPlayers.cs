using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class TwoAudioPlayers : MonoBehaviour
{
    [SerializeField] AudioClip firstClip;
    [SerializeField] AudioClip secondClip;
    [SerializeField] float pitch;
    [SerializeField] float pitchRandomization;
    [SerializeField] float volume;
    [SerializeField] AudioSource sfx;
    [SerializeField] AudioMixerGroup mixerGroup;
    public void PlayFirstSound()
    {
        sfx.clip = firstClip;
        sfx.pitch = pitch + Random.Range(-pitchRandomization, pitchRandomization);
        sfx.volume = volume;
        sfx.outputAudioMixerGroup = mixerGroup;
        sfx.PlayOneShot(firstClip);
    }

    public void PlaySecondSound()
    {
        sfx.clip = secondClip;
        sfx.pitch = pitch + Random.Range(-pitchRandomization, pitchRandomization);
        sfx.volume = volume;
        sfx.outputAudioMixerGroup = mixerGroup;
        sfx.PlayOneShot(secondClip);
    }
}
