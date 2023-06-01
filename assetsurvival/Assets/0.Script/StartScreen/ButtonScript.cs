using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    public Transform leftside; // 버튼들 움직일곳
    public TMP_Text StartText; // 시작화면 글씨
    public Button StartButton; // 시작 버튼;
    public GameObject StartScreen; // 시작 화면 글씨 , 버튼
    public GameObject Character_Screen; // 캐릭터 선택 창

    int WeaponNum = 6;
    public TMP_Text WeaponNumber; // 무기 수
    public void OnStartButton() // 시작 버튼
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
    public void OnEndButton() // 나가기 버튼
    {
        Application.Quit();
    }
   
}
