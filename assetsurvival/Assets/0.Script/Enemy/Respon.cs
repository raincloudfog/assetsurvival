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
            GameObject enemy = ObjectPool.Instance.ZombieDequeque();
            try
            {
                enemy.transform.position = transform.position;
                //enemy.gameObject.SetActive(true);
            }
            catch
            {
                Debug.Log("버그뜸");
            }
            ObjectPool.Instance.ResponEnqueque(this.gameObject);
        }
    }
}
