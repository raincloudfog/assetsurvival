using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{

    public Transform target;  // 플레이어의 Transform 컴포넌트를 참조할 변수
    public float smoothTime = 0.3f;
    public Vector3 offset;
    private Vector3 velocity = Vector3.zero;

    

    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        if(target != null)
        {
            Vector3 targetPosition = target.position + offset;
            transform.position = Vector3.SmoothDamp(
                transform.position,
                targetPosition, ref velocity, smoothTime);
        }
    }
}

