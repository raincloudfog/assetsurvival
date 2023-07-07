using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Singleton;
using System;

public class InPutManager : SingletonMono<InPutManager>
{
    Dictionary<KeyCode, Action> keycodes = new Dictionary<KeyCode, Action>();

    public void AddKeycode(KeyCode keyCode, Action action)
    {
        if (keycodes.ContainsKey(keyCode)) // 키코드에 키가 있다면
        {
            keycodes[keyCode] = null; // 키를 비워주고
            keycodes[keyCode] = action; // 새로운 액션을 넣어준다
        }
        else // 키코드에 키가 없다면
        {
            keycodes.Add(keyCode, action); // 없으니까 추가해준다.
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (keycodes.ContainsKey(KeyCode.Escape))
            {
                keycodes[KeyCode.Escape]();
            }
        }
        
    }
}
