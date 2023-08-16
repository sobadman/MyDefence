using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    private static BuildManager instance;

    public static BuildManager Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;

        //�ٸ������� �������� ������
        //DontDestroyOnLoad(this.gameObject);
    }

    //��ġ�� �ͷ� ������(TurretBlueprint-������, ���, ������)�� �����ϴ� ����
    private TurretBlueprint turretToBuild;

    //Ÿ�� UI
    public TileUI tileUI;

    private Tile selectTile;

    //��ġ�� �ͷ��� ��ȯ�ϴ� �Լ�
    public TurretBlueprint GetTurretToBuild()
    {
        return turretToBuild;
    }

    //��ġ�� �ͷ��� �����ϴ� �Լ�
    public void SetTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
    }

    //�� Ÿ���� ����
    public void SelectTile(Tile tile)
    {
        //�ߺ��˻�
        if(selectTile == tile)
        {
            DeSelectTile();            
            return;
        }

        selectTile = tile;
        turretToBuild = null;

        tileUI.ShowTileUI(selectTile);
    }

    //�� Ÿ�� ���� ����
    public void DeSelectTile()
    {
        tileUI.HideTileUI();
        selectTile = null;
    }

}
