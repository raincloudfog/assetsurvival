using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Monstercontroller : MonoBehaviour
{
    public GameObject rangeObject; // ��ü
    public GameObject respon; // ��ȯ ������ ǥ�õǴ� ������Ʈ
    public Transform parent;
    [SerializeField] Player player;
    float spawnTimer;
    List<int> wavemonsterLength = new List<int>(); //��ȯ�Ǵ� ������ ��
    [SerializeField]BoxCollider rangeCollider; // �ڽ��ݶ��̴� ũ��
    int nextWave = 1;

    [SerializeField] GameObject waveStop; // ���̺� �������� ������ ������

    [SerializeField] int Timeset; // �⺻ Ÿ�̸� �ð�
    [SerializeField] Text TimerText; // Ÿ�̸� �ؽ�Ʈ
    [SerializeField] float time; // ���ð�

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
    /// ����ȯ
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
    /// ���̺� ��������
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
    /// ������ ��ġ�� ��ȯ
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
