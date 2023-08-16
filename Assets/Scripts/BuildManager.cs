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

        //다른씬에도 가져가고 싶으면
        //DontDestroyOnLoad(this.gameObject);
    }

    //설치할 터렛 데이터(TurretBlueprint-프리팹, 비용, 오프셋)을 저장하는 변수
    private TurretBlueprint turretToBuild;

    //타일 UI
    public TileUI tileUI;

    private Tile selectTile;

    //설치할 터렛을 반환하는 함수
    public TurretBlueprint GetTurretToBuild()
    {
        return turretToBuild;
    }

    //설치할 터렛을 저장하는 함수
    public void SetTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
    }

    //맵 타일을 선택
    public void SelectTile(Tile tile)
    {
        //중복검사
        if(selectTile == tile)
        {
            DeSelectTile();            
            return;
        }

        selectTile = tile;
        turretToBuild = null;

        tileUI.ShowTileUI(selectTile);
    }

    //맵 타일 선택 해제
    public void DeSelectTile()
    {
        tileUI.HideTileUI();
        selectTile = null;
    }

}
