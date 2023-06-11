using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Singleton;

public class Respon : MonoBehaviour
{
    [SerializeField] Enemy[] enemies; // ���ʹ� ��ȯ

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
            enemy.SetData(MonsterData.Instance.mData.monster[rand], WeaponManager.Instance.player); // ���̽��� �ִ� �����͸� �޾ƿ��� �÷��̾ ��������
                
            Destroy(gameObject);
            
            
        }
        

    }
}
