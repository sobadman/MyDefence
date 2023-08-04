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

        bluePrint = buildManager.GetTurretToBuild();

        //������ Ÿ������ �ͷ��� ��ġ�Ǿ� �ִ��� �ߺ� ��ġ �˻�
        if (turret != null)
        {   
            //Ÿ�� UI �����ֱ�
            buildManager.SelectTile(this);
            return;
        }

        //�ͷ� ���� ��ư�� Ŭ������ �ʾ��� ���
        if(bluePrint == null)
        {
            Debug.Log("�ͷ��� ��ġ���� ���߽��ϴ�");
            return;
        }

        BuildTurret();
    }

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

    private void OnMouseEnter()
    {
        //UI�� ���� ��ġ�ϴ���
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        bluePrint = buildManager.GetTurretToBuild();

        //��ġ�� �ͷ��� ������
        if (bluePrint == null)
        {   
            return;
        }

        //������ üũ
        if (PlayerStats.HasMoney(bluePrint.cost) == true)
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
