using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonBo : MonoBehaviour
{
    public GameObject Hammer; // �θ޶� ��ȯ
    public float timer = 0; // Ÿ�̸�
    [System.NonSerialized]
    float responHammer = 2; // �ظ� ������ �ð�
    Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = CharacterManager.Instance.MainPlayer;
    }

    private void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (ButtonManager.Instance.weaPons.Contains(Weapons.Hammer) == true)
        {
            
            //GameObject clone = Instantiate(Hammer, new Vector3(transform.position.x, transform.position.y, transform.position.z),transform.rotation );

            if (timer >= responHammer)
            {
                
                timer = 0;
                Boomerang obj = ObjectPool.Instance.HammerDequeue();
                obj.transform.position = player.transform.position + transform.forward;
                Debug.Log("�ظ� ��ȯ" + timer);

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
}
