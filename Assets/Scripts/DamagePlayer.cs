using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    [SerializeField] float damage;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerHealth>() != null)
            other.GetComponent<PlayerHealth>().TakeDamage(damage);
        print("fu");
    }
}
