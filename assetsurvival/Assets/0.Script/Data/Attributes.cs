using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Attributes 
{
    [System.Serializable] // 구조체 혹은 클래스를 보려면
    public struct Monster
    {
        public string name;
        public float movespeed;
        public float Hp;
        public float power;
    }
}
