using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannonball : MonoBehaviour
{
    public float damage;
    [SerializeField] GameObject smoke;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<PlayerHealth>())
        {
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
        else if (smoke != null)
        {
            GameObject newParticles = Instantiate(smoke, transform.position, Quaternion.identity) as GameObject;
            Destroy(newParticles, 4f);
        }
        Destroy(gameObject);
    }
}
