using UnityEngine;

//상점에서 파는 품목(터렛)의 속성을 관리하는 클래스
[System.Serializable]
public class TurretBlueprint
{
    public GameObject turretPrefab; //터렛 프리팹
    public int cost;                //터렛 설치 비용

    public GameObject upgardePrefab; //업그레이드 터렛 프리팹
    public int upgradeCost;          //업그레이드 가격

    public Vector3 offset;          //터렛 설치 위치 오프셋
    
    public int GetSellCost()
    {
        return cost / 2;
    }

}
