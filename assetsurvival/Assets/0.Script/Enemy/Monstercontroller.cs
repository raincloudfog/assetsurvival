using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monstercontroller : MonoBehaviour
{
    public GameObject rangeObject; // 본체
    public GameObject respon; // 소환 직전에 표시
    public Transform parent;
    [SerializeField] Player player;
    float spawnTimer;
    [SerializeField]BoxCollider rangeCollider; // 박스콜라이더 크기

    
    // Update is called once per frame
    void Update()
    {
        

        spawnTimer += Time.deltaTime;
        if(spawnTimer > 5f)
        {
           

            spawnTimer = 0;
            GameObject responpoint = Instantiate(respon, Return_RandomPosition(), Quaternion.identity);
            responpoint.transform.position += new Vector3(0,3,0);
            /*int rand = Random.Range(0, enemys.Length);
            Enemy enemy = Instantiate(enemys[rand], Return_RandomPosition(), Quaternion.identity);
            enemy.SetData(MonsterData.Instance.mData.monster[rand], WeaponManager.Instance.player);*/
            
            

        }
    }

    Vector3 Return_RandomPosition()
    {
        Vector3 OriginPosition = rangeObject.transform.position;

        float range_X = rangeCollider.bounds.size.x;
        float range_Z = rangeCollider.bounds.size.z;

        range_X = Random.Range((range_X / 2) * -1, range_X / 2);
        range_Z = Random.Range((range_Z / 2) * -1, range_Z / 2);
        Vector3 randomPosition = new Vector3(range_X, 0f, range_Z);

        Vector3 respawnPosition = OriginPosition + randomPosition;
        return respawnPosition;
    }
}
