using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Singleton;

public class Respon : MonoBehaviour
{
    [SerializeField] Enemy[] enemies; // 에너미 소환

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
            enemy.transform.SetParent(null);
            enemy.SetData(MonsterData.Instance.mData.monster[rand], WeaponManager.Instance.player); // 제이슨에 있는 데이터를 받아오고 플레이어도 설정해줌
                
            Destroy(gameObject);
            
            
        }
        

    }
}
