using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{

    public Transform player;
    Vector3 StartPos; // ������ġ
    Vector3 EndPos; // �÷��̾� ��ġ
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
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

        transform.position = Vector3.Lerp(StartPos, EndPos, 5f);
    }
}
