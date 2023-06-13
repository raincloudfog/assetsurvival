using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firepos : MonoBehaviour
{
    public Dagger dagger; // 단검 던지기 확인용
    public Weapon[] weapons; // 무기들
    public Transform dagTnf; // 무기가 담길 위치

    float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ButtonManager.Instance.weaPons.Contains(Weapons.Dagger))
        {
            
            // 플레이어의 회전 값을 가져옴
            // 발사 방향 계산
            Quaternion playerRotation = CharacterManager.Instance.MainPlayer.transform.rotation ;
           
            Vector3 shootDirection = playerRotation * Vector3.forward;
            
            

            timer += Time.deltaTime;
            if (timer > 1)
            {
                timer = 0;
                // 발사체 생성 및 발사                
                    //Instantiate(dagger, CharacterManager.Instance.Firepoint);
                Dagger obj = ObjectPool.Instance.daggerDequeue();
                obj.transform.SetParent(CharacterManager.Instance.Firepoint);
                obj.Init();
                obj.setVec(shootDirection);

                obj.transform.SetParent(dagTnf); // 상위객체 바꿔주기               

            }


        }
    }
}
