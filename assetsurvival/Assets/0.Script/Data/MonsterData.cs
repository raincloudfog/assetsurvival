using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Singleton;


public class MonsterData : SingletonMono<MonsterData>
{
    [SerializeField] private TextAsset monsterTxt;
    
    
    [System.Serializable]
    public class MData
    {
        public List<Attributes.Monster> monster;
    }
    public MData mData = new MData();
    void Start()
    {
        mData =JsonUtility.FromJson<MData>(monsterTxt.text);
    }

   
}
