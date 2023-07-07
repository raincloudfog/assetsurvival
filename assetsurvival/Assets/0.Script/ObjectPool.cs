using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Singleton;

public class ObjectPool : SingletonMono<ObjectPool>
{
    [Tooltip("�ܰ��� �����ּ���")]
    public Dagger dagger;
    [Tooltip("�ظӸ� �����ּ���")]
    public BoomerangHammer Hammer;
    [Tooltip("���� �����ּ���")]
    public Enemy zombie;
    [Tooltip("��������ǥ�� �־��ּ���")]
    public GameObject spon;

    Queue<Dagger> daggers = new Queue<Dagger>();
    Queue<BoomerangHammer> Hammers = new Queue<BoomerangHammer>();
    Queue<Enemy> zombies = new Queue<Enemy>();
    Queue<GameObject> spons = new Queue<GameObject>();

    /// <summary>
    /// �ܰ� ��������
    /// </summary>
    /// <param name="_dagger"></param>
    public void daggersreturn(Dagger _dagger)
    {
        daggers.Enqueue(_dagger);
        
        //_dagger.transform.localPosition = Vector3.zero;
        _dagger.gameObject.SetActive(false);
    }
    /// <summary>
    /// �ܰ� ��������
    /// </summary>
    /// <returns></returns>
    public Dagger daggerDequeue()
    {
        if(daggers.Count <= 0)
        {
            for (int i = 0; i < 5; i++)
            {
                Dagger newobj = Instantiate(dagger, CharacterManager.Instance.Firepoint);
                daggers.Enqueue(newobj);
                newobj.gameObject.SetActive(false);
            }            
        }

        Dagger obj = daggers.Dequeue();
        obj.gameObject.SetActive(true);
        
        return obj;
    }
    /// <summary>
    /// �ظ� ��������
    /// </summary>
    /// <param name="_Boomerang"></param>
    public void HammerReturn(BoomerangHammer _Boomerang)
    {
        Hammers.Enqueue(_Boomerang);
        //Debug.Log("��������..");
        _Boomerang.gameObject.SetActive(false);
    }
    /// <summary>
    /// �ظ� ��������
    /// </summary>
    /// <returns></returns>
    public BoomerangHammer HammerDequeue()
    {
       if(Hammers.Count <= 0)
        {
            for (int i = 0; i < 5; i++)
            {
                //Debug.Log("�ظ� �����ϱ�");
                BoomerangHammer newobj = Instantiate(Hammer);
                Hammers.Enqueue(newobj);
                newobj.gameObject.SetActive(false);
            }
        }

        BoomerangHammer obj = Hammers.Dequeue();
        obj.gameObject.SetActive(true);
        // Debug.Log("�ظӸ� �����ֱ�");
        return obj;
    }
    /// <summary>
    /// ���� �ҷ�����
    /// </summary>
    /// <param name="enemy"></param>
    public void ZombieReturn(Enemy enemy)
    {
        zombies.Enqueue(enemy);
        enemy.gameObject.SetActive(false);
    }
    /// <summary>
    /// ���� ��������
    /// </summary>
    /// <returns></returns>
    public Enemy ZombieDequeque()
    {
        if(zombies.Count <= 0)
        {
            Enemy newEnemy = Instantiate(zombie);
            zombies.Enqueue(zombie);
            newEnemy.gameObject.SetActive(false);
        }
        Enemy enemy = zombies.Dequeue();
        enemy.gameObject.SetActive(true);
        return enemy;
    }
    /// <summary>
    /// ������ ��������
    /// </summary>
    /// <param name="obj"></param>
    public void ResponEnqueque(GameObject obj)
    {
        spons.Enqueue(obj);
        obj.SetActive(false);
    }
    /// <summary>
    /// ���� ��������
    /// </summary>
    /// <returns></returns>
    public GameObject ResponDequeue()
    {
        if(spons.Count <= 0)
        {
            GameObject newobj = Instantiate(spon);
            spons.Enqueue(newobj);
            newobj.SetActive(false);

        }
        GameObject obj = spons.Dequeue();
        obj.SetActive(true);
        return obj;
    }
}
