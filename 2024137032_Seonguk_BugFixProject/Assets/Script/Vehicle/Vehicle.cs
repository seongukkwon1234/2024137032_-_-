using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Vehicle : MonoBehaviour
{
    public float speed = 10.0f;  //�̵��ӵ� ����

    //���� �޼��� : �̵�
    public virtual void Move()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime); //�������� �̵�
    }

    //�߻� �ż��� : ���� 
    public abstract void Horn();

}
