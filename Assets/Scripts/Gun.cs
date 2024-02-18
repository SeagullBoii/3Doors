using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Gun", menuName = "Gun")]
public class Gun: ScriptableObject
{
    public string Name;
    public float firerate;
    public float damage;
    public float bulletForce;
    public float bloom;
    public float bulletsPerShot;
    public float positionShake;
    public float rotationalShake;
    public float shakeVibration;
    public GameObject bullet;
    public Vector3 bulletOffset;
}
