using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpAndLandSounds : MonoBehaviour
{
    AudioPlayer audioPlayer;
    PlayerMovement pm;
    Rigidbody rb;

    private void Start()
    {
        audioPlayer = GetComponent<AudioPlayer>();
        pm = GetComponent<PlayerMovement>();
        rb = GetComponent<Rigidbody>();
    }

    bool inTheAir = false;
    private void Update()
    {
        if (!pm.grounded) { inTheAir = true; }
        else if (pm.grounded && inTheAir)
        {
            audioPlayer.PlaySound();
            inTheAir = false;
        }
        else
        {
            inTheAir = false;
        }
    }
}
