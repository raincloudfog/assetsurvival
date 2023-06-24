using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    string[] arrayStudents; // Student들의 이름 배열
    [SerializeField]
    GameObject studentPrefab; // Student 타입의 프리팹

    //재생 제어를 위한 모든 에이전트 리스트
    List<BaseGameEntity> entitys;

    private void Awake()
    {
        entitys = new List<BaseGameEntity>();

        for (int i = 0; i < arrayStudents.Length; i++)
        {
            //에이전트 생성, 초기화 메소드 호출
            GameObject clone = Instantiate(studentPrefab);
            Student entity = clone.GetComponent<Student>();
            entity.SetUp(arrayStudents[i]);

            //에이전트들의 재생 제어를 위해 리스트에 저장
            entitys.Add(entity);
        } 
    }

    private void Update()
    {
        //모든 에이전트의 UPdate()를 호출해 에이전트 구동
        for (int i = 0; i < entitys.Count; i++)
        {
            entitys[i].Updated();
        }
    }
}
