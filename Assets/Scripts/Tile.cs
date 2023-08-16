using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tile : MonoBehaviour
{
    private BuildManager buildManager;

    //���� Ÿ������ ��ġ�� �ͷ�
    private GameObject turret;

    //���� ���� ��ư���� ���õ� �ͷ� ����
    private TurretBlueprint bluePrint;
    public TurretBlueprint BluePrint
    {
        get { return bluePrint; }
    }

    //��ġ�� �ͷ��� ���׷��̵� ����
    private bool isUpgrade = false;
    public bool IsUpgrade
    {
        get { return isUpgrade; }
    }

    //
    private Renderer rend;

    //���콺�� �ö󰥶��� ���� �÷���
    public Color hoverColor;
    //Ÿ���� �ʱ� �÷���
    private Color startColor;

    //���콺�� �ö󰥶��� ���� ���͸��� (���� ����Ҷ�)
    public Material hoverMaterial;
    //���콺�� �ö󰥶��� ���� ���͸��� (���� �����Ҷ�)
    public Material moneyMaterial;
    //Ÿ���� ���͸��� �ʱⰪ
    private Material startMaterial;
    //�ͷ� ��ġ ��ġ ������
    public Vector3 offsetPos;

    //�Ǽ� ����Ʈ
    public GameObject buildEffectPrefab;

    //�Ǹ� ����Ʈ
    public GameObject sellEffectPrefab;

    private void Start()
    {
        buildManager = BuildManager.Instance;

        rend = this.GetComponent<Renderer>();
        //startColor = rend.material.color;
        startMaterial = rend.material;
    }

    private void OnMouseDown()
    {
        //UI�� ���� ��ġ�ϴ���
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        //������ Ÿ������ �ͷ��� ��ġ�Ǿ� �ִ��� �ߺ� ��ġ �˻�
        if (turret != null)
        {   
            //Ÿ�� UI �����ֱ�
            buildManager.SelectTile(this);
            return;
        }

        bluePrint = buildManager.GetTurretToBuild();

        //�ͷ� ���� ��ư�� Ŭ������ �ʾ��� ���
        if (bluePrint == null)
        {
            Debug.Log("�ͷ��� ��ġ���� ���߽��ϴ�");
            return;
        }

        BuildTurret();
    }

    //�ͷ� �Ǽ�
    void BuildTurret()
    {
        //��� ���
        if (PlayerStats.UseMoney(bluePrint.cost) == true)
        {
            //���� ����Ʈ - ������Ÿ��(2��)�� ų
            GameObject eff = Instantiate(buildEffectPrefab, this.transform.position, Quaternion.identity);
            Destroy(eff, 2f);

            //����� �ͷ� �������� ��ġ
            turret = Instantiate(bluePrint.turretPrefab, this.transform.position + bluePrint.offset, Quaternion.identity);

            //��ġ�� �ͷ��� null �ʱ�ȭ
            buildManager.SetTurretToBuild(null);
            //��ġ ��� ���
            //Debug.Log($"��ġ�� ���� ������: {PlayerStats.Money}");
        }
    }

    //�ͷ� ���׷��̵�(���׷��̵� ����, ���׷��̵� ������)
    public bool UpgradeTurret()
    {
        //�����
        if(PlayerStats.UseMoney(bluePrint.upgradeCost) == true)
        {
            //���׷��̵� ����Ʈ(���������� ����) - ������Ÿ��(2��)�� ų
            GameObject eff = Instantiate(buildEffectPrefab, this.transform.position, Quaternion.identity);
            Destroy(eff, 2f);

            //���� ��ġ�� �ͷ��� ����(?)
            Destroy(turret);

            //����� �ͷ��� ���׷��̵� �������� ��ġ
            turret = Instantiate(bluePrint.upgardePrefab, this.transform.position + bluePrint.offset, Quaternion.identity);

            //���׷��̵� ���� ����
            isUpgrade = true;

            //���׷��̵� ��� ���
            Debug.Log($"���׷��̵� �� ���� ������: {PlayerStats.Money}");

            return true;
        }

        return false;
    }

    //�ͷ� �Ǹ�
    public void SellTurret()
    {
        //�Ǹ� ��� ���
        int sellMoney = bluePrint.GetSellCost();

        //�ͷ� ����
        Destroy(turret);
        bluePrint = null;

        //�Ǹ� ����Ʈ - ������Ÿ��(2��)�� ų
        GameObject eff = Instantiate(sellEffectPrefab, this.transform.position, Quaternion.identity);
        Destroy(eff, 2f);

        //���׷��̵� ���� �ʱ�ȭ
        isUpgrade = false;

        PlayerStats.AddMoney(sellMoney);

        //�ǸŽ� �� �� ���
        Debug.Log($"�Ǹ� �� ���� ������: {PlayerStats.Money}");
    }

    private void OnMouseEnter()
    {
        //UI�� ���� ��ġ�ϴ���
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        TurretBlueprint selectBluePrint = buildManager.GetTurretToBuild();

        //��ġ�� �ͷ��� ������
        if (selectBluePrint == null)
        {   
            return;
        }

        //������ üũ
        if (PlayerStats.HasMoney(selectBluePrint.cost) == true)
        {
            //rend.material.color = hoverColor;
            rend.material = hoverMaterial;
        }
        else //������
        {
            rend.material = moneyMaterial;
        }        
    }

    private void OnMouseExit()
    {
        //rend.material.color = startColor;        
        rend.material = startMaterial;
    }

}
