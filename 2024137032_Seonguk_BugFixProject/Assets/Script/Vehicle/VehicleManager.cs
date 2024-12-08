using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleManager : MonoBehaviour
{
    public Vehicle[] vehicles;  //Ż�� ��ü �迭 �����Ѵ�.

    public Car car; //�ڵ��� ����
    public Bicycle bicycle; //������ ����

    float Timer; //������ �ð� float ���� ���� 

    void Update()
    {
        car.Move();  //�̵� �Լ� ȣ��
        bicycle.Move(); 
        Timer -= Time.deltaTime;  //�ð��� ���δ�

        if(Timer < 0)  //1�ʸ��� ȣ��ǰ� �Ѵ�
        {
            car.Horn();  //���� �Լ� ȣ�� 
            bicycle.Horn();
            Timer = 1;
        }
    }
}
