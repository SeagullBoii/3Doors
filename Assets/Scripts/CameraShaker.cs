using UnityEngine;
using DG.Tweening;
using System;

public class CameraShaker : MonoBehaviour
{
    public static event Action<float, float, float, float, Transform, float, bool> Shake;

    public static void Invoke(float duration, float positionStrength, float rotationStrength, float vibrato, Transform originTransform, float maxDistance, bool fade)
    {
        Shake?.Invoke(duration, positionStrength, rotationStrength, vibrato, originTransform, maxDistance, fade);
    }

    private void OnEnable() => Shake += ShakeScreen;
    private void OnDisable() => Shake -= ShakeScreen;

    public void ShakeScreen(float duration, float positionStrength, float rotationStrength, float vibrato, Transform originTransform, float maxDistance, bool fade)
    {
        float distance = Mathf.Abs((transform.position - originTransform.position).magnitude);

        int vibrationAmount = 15;
        float shakeMultiplier = 0.1f;

        if (distance <= maxDistance && fade)
        {
            shakeMultiplier = 1;
            vibrationAmount = (int)(vibrato * (maxDistance - distance) / maxDistance);
        }
        if (!fade)
        {
            vibrationAmount = (int)vibrato;
        }

        transform.DOComplete();
        transform.DOShakePosition(duration, positionStrength * shakeMultiplier, vibrationAmount);
        transform.DOShakeRotation(duration, rotationStrength * shakeMultiplier, vibrationAmount);
    }
}
