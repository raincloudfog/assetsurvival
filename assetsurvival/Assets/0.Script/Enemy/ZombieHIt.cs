using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHIt : MonoBehaviour
{
    [SerializeField] Zombie zombie; // 좀비 히트

    [SerializeField] Material[] material;
    [SerializeField] Material origin;
    [SerializeField] Material red;

    public void OnEnable()
    {
        zombie.SetData(MonsterData.Instance.mData.monster[0], WeaponManager.Instance.player);
    }

    public void zombieHit(float damage)
    {
        Debug.Log("좀비때리는중");
        StartCoroutine(Hitcolor());
        zombie.Hit(damage);
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.layer == 8)
        {
            collision.gameObject.GetComponent<Player>().Hp -= Time.deltaTime * zombie.Damage;
        }
    }

    public virtual IEnumerator Hitcolor()
    {
        this.GetComponent<Renderer>().material = red;
        
        yield return new WaitForSeconds(0.3f);
        this.GetComponent<Renderer>().materials = material;
        
        yield break;
    }
}
