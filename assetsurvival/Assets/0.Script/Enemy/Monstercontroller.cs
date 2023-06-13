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
    List<int> wavemonsterLength = new List<int>();
    [SerializeField]BoxCollider rangeCollider; // 박스콜라이더 크기
    int nextWave = 0;

    private void Start()
    {
        for (int i = 5; i < 15; i++)
        {
            wavemonsterLength.Add(i);
        }
    }

    // Update is called once per frame
    void Update()
    {

        StartCoroutine(Wave());

    }
    private void FixedUpdate()
    {
        
        
    }

    void spon()
    {
        
        
        for (int i = 0; i < wavemonsterLength[nextWave]; i++)
        {
            GameObject responpoint = Instantiate(respon, Return_RandomPosition(), Quaternion.identity);
            responpoint.transform.position += new Vector3(0, 3, 0);
                
        }
        nextWave++;
        /*int rand = Random.Range(0, enemys.Length);
        Enemy enemy = Instantiate(enemys[rand], Return_RandomPosition(), Quaternion.identity);
        enemy.SetData(MonsterData.Instance.mData.monster[rand], WeaponManager.Instance.player);*/

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

    IEnumerator Wave()
    {
        yield return new WaitForSeconds(2f);
        spon();
        yield return new WaitForSeconds(4f);
        spon();
        yield return new WaitForSeconds(6f);
        spon();
        yield return new WaitForSeconds(8f);
        spon();
        yield return new WaitForSeconds(10f);
        spon();
    }
}
