using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHIt : MonoBehaviour
{
    [SerializeField] Zombie zombie; // 좀비 히트

    [SerializeField] Material[] material;




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
        material[0].color = Color.red;
        material[1].color = Color.red;
        yield return new WaitForSeconds(0.3f);
        material[0].color = new Color(1, 1, 1);
        material[1].color = new Color(1, 1, 1);
        yield break;
    }
}
