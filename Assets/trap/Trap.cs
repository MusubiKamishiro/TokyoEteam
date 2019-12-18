using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField]
    GameObject particle=null;
    [SerializeField]
    float damage = 1;
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
           
            EnemyHealth health = other.GetComponent<EnemyHealth>();
            health.takeDamage(damage);
        }
        else if(other.tag=="Player")
        {
           
            PlayerHealth health = other.GetComponent<PlayerHealth>();
            health.takeDamage(damage);
        }
        if (particle != null)
        {
            Instantiate(particle, transform.position, transform.rotation);
        }
        Destroy(gameObject);
    }
}
