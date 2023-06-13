using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firepos : MonoBehaviour
{
    public Dagger dagger; // �ܰ� ������ Ȯ�ο�
    public Weapon[] weapons; // �����
    public Transform dagTnf; // ���Ⱑ ��� ��ġ

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
            
            // �÷��̾��� ȸ�� ���� ������
            // �߻� ���� ���
            Quaternion playerRotation = CharacterManager.Instance.MainPlayer.transform.rotation ;
           
            Vector3 shootDirection = playerRotation * Vector3.forward;
            
            

            timer += Time.deltaTime;
            if (timer > 1)
            {
                timer = 0;
                // �߻�ü ���� �� �߻�                
                    //Instantiate(dagger, CharacterManager.Instance.Firepoint);
                Dagger obj = ObjectPool.Instance.daggerDequeue();
                obj.transform.SetParent(CharacterManager.Instance.Firepoint);
                obj.Init();
                obj.setVec(shootDirection);

                obj.transform.SetParent(dagTnf); // ������ü �ٲ��ֱ�               

            }


        }
    }
}
