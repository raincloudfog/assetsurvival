using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    public Transform leftside; // ��ư�� �����ϰ�
    public TMP_Text StartText; // ����ȭ�� �۾�
    public Button StartButton; // ���� ��ư;
    public GameObject StartScreen; // ���� ȭ�� �۾� , ��ư
    public GameObject Character_Screen; // ĳ���� ���� â

    int WeaponNum = 6;
    public TMP_Text WeaponNumber; // ���� ��
    public void OnStartButton() // ���� ��ư
    {
        Vector3 Startpos = StartScreen.transform.position;

        Vector3 endpos = leftside.position;
        float distance = (Startpos - endpos).sqrMagnitude;
        StartScreen.transform.position = Vector3.Lerp(Startpos, endpos, 5f);
        if (distance <= 1)
        {
            StartScreen.transform.position = endpos;
        }
        Character_Screen.SetActive(true);
    }

    public void OnUnityChan()
    {
        StartSave.Instance.character_type = Character.UnityChan;
        StartSave.Instance.WeaponCount = int.Parse(WeaponNumber.text);
        SceneManager.LoadScene(1);
    }
    public void OnMisaki()
    {
        StartSave.Instance.character_type = Character.Misaki;
        StartSave.Instance.WeaponCount = int.Parse(WeaponNumber.text);
        SceneManager.LoadScene(1);
    }
    public void OnYuko()
    {
        StartSave.Instance.character_type = Character.Yuko;
        StartSave.Instance.WeaponCount = int.Parse(WeaponNumber.text);
        SceneManager.LoadScene(1);
    }
    public void OnWeaponCount()
    {
        WeaponNum++;
        if(WeaponNum > 6)
        {
            WeaponNum = 1;
        }

        WeaponNumber.text = WeaponNum.ToString();
    }
    public void OnEndButton() // ������ ��ư
    {
        Application.Quit();
    }
   
}
