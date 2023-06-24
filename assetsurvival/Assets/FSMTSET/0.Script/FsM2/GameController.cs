using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    string[] arrayStudents; // Student���� �̸� �迭
    [SerializeField]
    GameObject studentPrefab; // Student Ÿ���� ������

    //��� ��� ���� ��� ������Ʈ ����Ʈ
    List<BaseGameEntity> entitys;

    private void Awake()
    {
        entitys = new List<BaseGameEntity>();

        for (int i = 0; i < arrayStudents.Length; i++)
        {
            //������Ʈ ����, �ʱ�ȭ �޼ҵ� ȣ��
            GameObject clone = Instantiate(studentPrefab);
            Student entity = clone.GetComponent<Student>();
            entity.SetUp(arrayStudents[i]);

            //������Ʈ���� ��� ��� ���� ����Ʈ�� ����
            entitys.Add(entity);
        } 
    }

    private void Update()
    {
        //��� ������Ʈ�� UPdate()�� ȣ���� ������Ʈ ����
        for (int i = 0; i < entitys.Count; i++)
        {
            entitys[i].Updated();
        }
    }
}
