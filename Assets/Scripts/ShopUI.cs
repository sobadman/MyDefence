using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUI : MonoBehaviour
{
    private BuildManager buildManager;

    //�⺻ �ͷ� ������
    public TurretBlueprint basicTurret; //������ ����, ��ġ���(100), ������(0.5)
    //�̻��� ��ó ������
    public TurretBlueprint missileLauncher; //������ ����, ��ġ���(250), ������(0.42)
    //������ �� ������
    public TurretBlueprint laserBeamer; //������ ����, ��ġ���(350), ������(-0.03)

    private void Start()
    {
        buildManager = BuildManager.Instance;
    }

    public void SelectBasicTurret()
    {
        Debug.Log("�⺻ �ͷ��� �����Ͽ����ϴ�");
        buildManager.SetTurretToBuild(basicTurret);
    }

    public void SelectMissileLauncher()
    {
        Debug.Log("�̻��� ��ó�� �����Ͽ����ϴ�");
        buildManager.SetTurretToBuild(missileLauncher);
    }

    public void SelectLaserBeamer()
    {
        Debug.Log("���������� ���� �Ͽ����ϴ�");
        buildManager.SetTurretToBuild(laserBeamer);
    }

}
