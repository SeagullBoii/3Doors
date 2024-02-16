using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireArm : MonoBehaviour
{
    [SerializeField] public Gun gun;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] LayerMask collideWithRay;
    Animator animator;
    bool hasShot;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        HandleInput();
    }

    private void HandleInput()
    {
        if (Input.GetMouseButton(0)) Shoot();
    }

    private void Shoot()
    {
        if (!hasShot)
        {
            GameObject bullet = Instantiate(gun.bullet) as GameObject;
            Vector3 bulletPosAddition = Camera.main.transform.right * gun.bulletOffset.x + Camera.main.transform.up * gun.bulletOffset.y + Camera.main.transform.forward * gun.bulletOffset.z;
            bullet.transform.position = Camera.main.transform.position + bulletPosAddition;
            bullet.GetComponent<Rigidbody>().AddForce(BulletDirection(bullet.transform.position) * gun.bulletForce, ForceMode.Impulse);
            Destroy(bullet, 2);

            animator.Play("Shoot");
            muzzleFlash?.Play();
            hasShot = true;
            Invoke(nameof(ResetShot), gun.firerate);
        }
    }
    
    private Vector3 BulletDirection(Vector3 shootPosition)
    {
        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 1000, collideWithRay))
        {
            return (hit.point - shootPosition).normalized;
        }

        return (Camera.main.transform.forward * 1000 - shootPosition).normalized;
    }

    private void ResetShot()
    {
        hasShot = false;
    }
}
