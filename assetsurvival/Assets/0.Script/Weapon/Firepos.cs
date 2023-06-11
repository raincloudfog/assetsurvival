using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firepos : MonoBehaviour
{
    public Dagger dagger; // 단검 던지기 확인용
    public Weapon[] weapons; // 무기들
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ButtonManager.Instance.weaPons.Contains(new Dagger()))
        {
            Debug.Log("왜안 뜸?");
            // 플레이어의 회전 값을 가져옴
            Quaternion playerRotation = dagger.player.transform.rotation;

            // 발사 방향 계산
            Vector3 shootDirection = playerRotation * Vector3.forward;

            // 발사체 생성 및 발사
            GameObject dag = Instantiate(dagger.gameObject, dagger.firePoint.position, playerRotation);
            dag.GetComponent<Dagger>().setVec(shootDirection);
        }
    }
}
