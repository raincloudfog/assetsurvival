using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHIt : MonoBehaviour
{
    [SerializeField] Zombie zombie; // 좀비 히트

   

   

    
    public void zombieHit(float damage)
    {
        Debug.Log("좀비때리는중");
        zombie.Hit(damage);
    }
}
