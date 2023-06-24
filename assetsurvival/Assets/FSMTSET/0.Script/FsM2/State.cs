using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{

    /// <summary>
    /// �ش� ���¸� ������ �� 1ȸ ȣ��
    /// </summary>
    /// <param name="entity"></param>
    public abstract void Enter(Student entity);

    /// <summary>
    /// �ش� ���¸� ������Ʈ�� �� �� ������ ȣ��
    /// </summary>
    /// <param name="entity"></param>
    public abstract void Execute(Student entity);

    /// <summary>
    /// �ش� ���¸� ������ �� 1ȸ ȣ��
    /// </summary>
    /// <param name="entity"></param>
    public abstract void Exit(Student entity);
}
