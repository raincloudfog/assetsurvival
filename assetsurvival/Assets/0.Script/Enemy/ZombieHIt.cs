using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHIt : MonoBehaviour
{
    [SerializeField] Zombie zombie; // ���� ��Ʈ

   

   

    
    public void zombieHit(float damage)
    {
        Debug.Log("���񶧸�����");
        zombie.Hit(damage);
    }
}
