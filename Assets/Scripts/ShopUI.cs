using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUI : MonoBehaviour
{
    private BuildManager buildManager;

    //기본 터렛 데이터
    public TurretBlueprint basicTurret; //프리팹 정보, 설치비용(100), 오프셋(0.5)
    //미사일 런처 데이터
    public TurretBlueprint missileLauncher; //프리팹 정보, 설치비용(250), 오프셋(0.42)
    //레이저 빔 데이터
    public TurretBlueprint laserBeamer; //프리팹 정보, 설치비용(350), 오프셋(-0.03)

    private void Start()
    {
        buildManager = BuildManager.Instance;
    }

    public void SelectBasicTurret()
    {
        Debug.Log("기본 터렛을 선택하였습니다");
        buildManager.SetTurretToBuild(basicTurret);
    }

    public void SelectMissileLauncher()
    {
        Debug.Log("미사일 런처를 선택하였습니다");
        buildManager.SetTurretToBuild(missileLauncher);
    }

    public void SelectLaserBeamer()
    {
        Debug.Log("레이져빔을 선택 하였습니다");
        buildManager.SetTurretToBuild(laserBeamer);
    }

}
