using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Attributes 
{
    [System.Serializable] // ����ü Ȥ�� Ŭ������ ������
    public struct Monster
    {
        public string name;
        public float movespeed;
        public float Hp;
        public float power;
    }
}
