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
        if (keycodes.ContainsKey(keyCode)) // Ű�ڵ忡 Ű�� �ִٸ�
        {
            keycodes[keyCode] = null; // Ű�� ����ְ�
            keycodes[keyCode] = action; // ���ο� �׼��� �־��ش�
        }
        else // Ű�ڵ忡 Ű�� ���ٸ�
        {
            keycodes.Add(keyCode, action); // �����ϱ� �߰����ش�.
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
