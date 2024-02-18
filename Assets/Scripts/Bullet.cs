using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;
    [SerializeField] GameObject smoke;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Health>()) {
            collision.gameObject.GetComponent<Health>().TakeDamage(damage);
            collision.gameObject.GetComponent<Health>().Bleed(transform);
        }
        else if (smoke != null)
        {
            GameObject newParticles = Instantiate(smoke, transform.position, Quaternion.identity) as GameObject;
            Destroy(newParticles, 4f);
        }
        Destroy(gameObject);
    }
}
