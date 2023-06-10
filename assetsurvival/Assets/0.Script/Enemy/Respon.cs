using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Singleton;

public class Respon : MonoBehaviour
{
    [SerializeField] Enemy[] enemies;

    float spawnTimer;

    // Update is called once per frame
    void Update()
    {
        int rand = Random.Range(0, enemies.Length);

        spawnTimer += Time.deltaTime;

        if(spawnTimer >= 1)
        {
            spawnTimer = 0;

            Enemy enemy = Instantiate(enemies[rand], transform);
            enemy.SetData(MonsterData.Instance.mData.monster[rand], WeaponManager.Instance.player);
            enemy.transform.SetParent(null);
            Destroy(gameObject);
        }
        

    }
}
