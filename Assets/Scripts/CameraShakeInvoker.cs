using UnityEngine;
using DG.Tweening;
using System;

public class CameraShakeInvoker : MonoBehaviour
{
    public bool onStart;
    public float duration;
    public float maxPositionIntensity;
    public float maxRotationIntensity;


    private void Start()
    {
        if (onStart)
        {
            Transform cam = Camera.main.transform;
            float distance = Mathf.Abs((cam.position - transform.position).magnitude);

            float posIntensity = maxPositionIntensity / distance;
            float rotIntensity = maxRotationIntensity / distance;

            //if (cam.GetComponent<CameraShake>()) cam.GetComponent<CameraShake>().ShakeScreen(duration, posIntensity, rotIntensity);
        }

    }

    private void Update()
    {
        if (!onStart)
        {
            Transform cam = Camera.main.transform;
            float distance = Mathf.Abs((cam.position - transform.position).magnitude);

            float posIntensity = maxPositionIntensity / distance;
            float rotIntensity = maxRotationIntensity / distance;

            // if (cam.GetComponent<CameraShake>()) cam.GetComponent<CameraShake>().ShakeScreen(duration, posIntensity, rotIntensity);
        }
    }
}
