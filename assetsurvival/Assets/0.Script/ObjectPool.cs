using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Singleton;

public class ObjectPool : SingletonMono<ObjectPool>
{
    [Tooltip("단검을 놓아주세요")]
    public Dagger dagger;
    [Tooltip("해머를 놓아주세요")]
    public Boomerang Hammer; 


    Queue<Dagger> daggers = new Queue<Dagger>();
    Queue<Boomerang> Hammers = new Queue<Boomerang>();
    public void daggersreturn(Dagger _dagger)
    {
        daggers.Enqueue(_dagger);
        
        //_dagger.transform.localPosition = Vector3.zero;
        _dagger.gameObject.SetActive(false);
    }

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

    public void HammerReturn(Boomerang _Boomerang)
    {
        Hammers.Enqueue(_Boomerang);
        Debug.Log("사라졌어요..");
        _Boomerang.gameObject.SetActive(false);
    }

    public Boomerang HammerDequeue()
    {
       if(Hammers.Count <= 0)
        {
            for (int i = 0; i < 5; i++)
            {
                Debug.Log("해머 생성하기");
                Boomerang newobj = Instantiate(Hammer);
                Hammers.Enqueue(newobj);
                newobj.gameObject.SetActive(false);
            }
        }

        Boomerang obj = Hammers.Dequeue();
        obj.gameObject.SetActive(true);
        Debug.Log("해머를 보내주기");
        return obj;
    }
}
