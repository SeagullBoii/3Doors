using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayParticleSystem : MonoBehaviour
{
    [SerializeField] ParticleSystem particles;
    public void Play()
    {
        particles.Play();
    }
}
