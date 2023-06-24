using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace studnetOwnedStates
{
    public class RestAndSleep : State
    {
        public override void Enter(Student entity)
        {
            entity.CurrentLocation = Locations.SweetHome;
            entity.Stress = 0;

            entity.PrintText("���� ���´�. �ູ�� �츮��.. ���� ���� ��Ʈ������ �������.");
            entity.PrintText("ħ�뿡 ���� ���� �ܴ�..");
        }

        public override void Execute(Student entity)
        {
            entity.PrintText("zzZ~ zzz~ zzzzzZ~~");

            //�Ƿΰ� 0�� �ƴϸ�
            if(entity.Fatigue >0)
            {
                //�Ƿΰ� 10�� ����
                entity.Fatigue -= 10;
            }
            //�Ƿΰ� 0�̸�
            else
            {
                //������ ���� ���θ� �ϴ� "StudyHard" ���·� ����
            }
        }

        public override void Exit(Student entity)
        {
            entity.PrintText("ħ�븦 �����ϰ� �� ������ ������.");
        }
    }
}