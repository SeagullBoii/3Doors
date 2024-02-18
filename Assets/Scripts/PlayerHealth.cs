using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float maxHealth;
    [SerializeField] Rigidbody rb;
    float health;
    static bool dead;

    //Slider
    float vel = 0;
    [SerializeField] Slider hpSlider;
    [SerializeField] TMP_Text slideText;
    public static bool IsDead()
    {
        return dead;
    }

    private void Start()
    {
        health = maxHealth;
    }

    private void Update()
    {
        hpSlider.value = Mathf.SmoothDamp(hpSlider.value, health, ref vel, 0.5f);
        slideText.text = ((int)health).ToString();
    }

    public void TakeDamage(float dmg)
    {
        health -= dmg;
        health = Mathf.Clamp(health, 0, maxHealth);
        if (health <= 0 && !dead) Die();
        CameraShaker.Invoke(0.5f, 1, 5, 5, transform, 10, false);
    }

    private void Die()
    {
        dead = true;
        rb.freezeRotation = false;
        rb.AddForce(transform.forward*200);
        Invoke(nameof(FreezeTime), 2);
        Cursor.lockState = CursorLockMode.None;
    }

    private void FreezeTime()
    {
        SceneManager.LoadScene(0);
        PlayerHealth.dead = false;
    }

}
