using UnityEngine;

//�������� �Ĵ� ǰ��(�ͷ�)�� �Ӽ��� �����ϴ� Ŭ����
[System.Serializable]
public class TurretBlueprint
{
    public GameObject turretPrefab; //�ͷ� ������
    public int cost;                //�ͷ� ��ġ ���

    public GameObject upgardePrefab; //���׷��̵� �ͷ� ������
    public int upgradeCost;          //���׷��̵� ����

    public Vector3 offset;          //�ͷ� ��ġ ��ġ ������
    
    public int GetSellCost()
    {
        return cost / 2;
    }

}
