using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class Health : MonoBehaviour
{
    [SerializeField] float maxHealth;
    [SerializeField] GameObject bloodParticles;
    [SerializeField] GameObject deathParticles;
    [SerializeField] AudioPlayer hurtSound;
    [SerializeField] DungeonDoor door;
    float health;
    bool dead = false;

    private void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(float dmg)
    {
        health -= dmg;
        health = Mathf.Clamp(health, 0, maxHealth);
        if (health <= 0 && !dead) Die();
    }

    public void Bleed(Transform dmgSource)
    {
        if (bloodParticles == null) return;
        GameObject newParticles = Instantiate(bloodParticles, dmgSource.position, Quaternion.identity) as GameObject;
        Destroy(newParticles, 4f);
    }

    private void Die()
    {
        if (hurtSound != null) hurtSound.PlaySound();
        if (deathParticles != null)
        {
            if (door != null) door.enemiesKilled++;
            GameObject newParticles = Instantiate(deathParticles, transform.position, Quaternion.identity) as GameObject;
            Destroy(newParticles, 4f);
            dead = true;

        }
        Destroy(gameObject);
    }
}
