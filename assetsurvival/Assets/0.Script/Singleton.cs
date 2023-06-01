using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Singleton
{
    public class SingletonMono<T> : MonoBehaviour where T : SingletonMono<T>
    {
        protected static T _instance;
        public static T Instance
        {
            get
            {
                if(_instance == null)
                {
                    var obj = FindAnyObjectByType<T>(); // 하이어라키에 있는 매니저 객체찾기
                    if(obj !=null)
                    {
                        _instance = obj;
                        _instance.Init();
                        DontDestroyOnLoad(obj.gameObject);
                    }
                    else
                    {
                        var newObj = new GameObject(typeof(T).Name, typeof(T));// 없으면 만들어 준다.
                        _instance = newObj.GetComponent<T>();
                        if(_instance == null)
                        {
                            _instance = newObj.AddComponent<T>();
                        }
                        _instance.Init();
                    }
                }
                return _instance;
            }
            private set
            {
                _instance = value;
            }
        }

        protected virtual void Init()
        {

        }
    }


    public class Singleton<T> where T : Singleton<T>, new()
    {
        static T _instance = null;
        public static T Instance
        {
            get
            {
                if (_instance != null)
                    return _instance;

                _instance = new T();
                _instance.Init();
                return _instance;
            }
        }
        
        protected virtual void Init()
        {

        }
    }
}