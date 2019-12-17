using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Weapon
{
    [SerializeField]
    bullet bullet = null;
    [SerializeField]
    Transform spawnPoint = null;
    [SerializeField]
    float BulletSpeed = 50;
    Player p = null;
    
    private void Start()
    {
        p = FindObjectOfType<Player>();
    }
   
    public override void attack(int i)
    {
       bullet newBullet=  Instantiate(bullet, spawnPoint.position, spawnPoint.rotation) as bullet;
        Vector3 direction = p.transform.position- transform.position;
        newBullet.rb.AddForce(direction*BulletSpeed);
        
    }
  
}
