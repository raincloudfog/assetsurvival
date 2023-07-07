using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Monstercontroller : MonoBehaviour
{
    public GameObject rangeObject; // 본체
    public GameObject respon; // 소환 직전에 표시되는 오브젝트
    public Transform parent;
    [SerializeField] Player player;
    float spawnTimer;
    List<int> wavemonsterLength = new List<int>(); //소환되는 몬스터의 수
    [SerializeField]BoxCollider rangeCollider; // 박스콜라이더 크기
    int nextWave = 1;

    [SerializeField] GameObject waveStop; // 웨이브 끝났을때 나오는 증가량

    [SerializeField] int Timeset; // 기본 타이머 시간
    [SerializeField] Text TimerText; // 타이머 텍스트
    [SerializeField] float time; // 뺄시간

    Vector3 tempvec = Vector3.zero;

    private void Start()
    {        
        for (int i = 5; i < 15; i++)
        {
            wavemonsterLength.Add(i + 1);
        }
        StartCoroutine(Wave());

        Timeset = 30;
        
    }

    private void FixedUpdate()
    {     
        check();
    }
    /// <summary>
    /// 몹소환
    /// </summary>
    void spon()
    {        
        
        for (int i = 0; i < wavemonsterLength[nextWave]; i++)
        {
            //tempvec.z += 0.4f;
            GameObject responpoint = ObjectPool.Instance.ResponDequeue();
            responpoint.transform.position = Return_RandomPosition();
            //GameObject responpoint = Instantiate(respon, tempvec, Quaternion.identity);
            responpoint.transform.position += new Vector3(0, 3, 0);
        }
        nextWave++;
       

    }
    /// <summary>
    /// 웨이브 끝났을시
    /// </summary>
    void check()
    {               
        time  += Time.deltaTime;
        if(time >= 1)
        {            
            Timeset -= (int)time;
            time = 0;
        }
        
        TimerText.text = Timeset.ToString();
        if (Timeset <= 0)
        {
            Time.timeScale = 0;
            time = 0;
            Timeset = 30;
            GameManager.Instance.WaveCount++;
            StartCoroutine(Wave());
            waveStop.SetActive(true);
        }                    
    }
    /// <summary>
    /// 랜덤한 위치에 소환
    /// </summary>
    /// <returns></returns>
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
