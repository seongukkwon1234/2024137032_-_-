using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�׸��� �� Ŭ������ �� �׸��� ���� ���¿� �����͸� ���� �մϴ�.
public class GridCell 
{
    public Vector3Int Position;  //���� �׸��� �� ��ġ
    public bool IsOccupied;  //���� �ǹ��� ������ ����
    public GameObject Building; //���� ��ġ�� �ǹ� ��ü 

    public GridCell(Vector3Int position)  //Ŭ���� �̸��� ������ �Լ� (������) Ŭ������ ���� �� �� ȣ�� 
    {
        Position = position;
        IsOccupied = false;
        Building = null;
    }
  
}
