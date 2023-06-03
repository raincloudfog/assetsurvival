using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{

    public Transform player;
    Vector3 StartPos; // ������ġ
    Vector3 EndPos; // �÷��̾� ��ġ

    private void FixedUpdate()
    {
        Move();
    }
    void Move()
    {
        StartPos = transform.position;
        EndPos.x = player.position.x;
        EndPos.z = player.position.z;
        EndPos.y = transform.position.y;

        transform.position = Vector3.Lerp(StartPos, EndPos, 1f);
    }
}
