using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tile : MonoBehaviour
{
    private BuildManager buildManager;

    //현재 타일위에 설치된 터렛
    private GameObject turret;

    //현재 상점 버튼으로 선택된 터렛 정보
    private TurretBlueprint bluePrint;
    public TurretBlueprint BluePrint
    {
        get { return bluePrint; }
    }

    //설치된 터렛의 업그레이드 유무
    private bool isUpgrade = false;
    public bool IsUpgrade
    {
        get { return isUpgrade; }
    }

    //
    private Renderer rend;

    //마우스가 올라갈때의 변경 컬러값
    public Color hoverColor;
    //타일의 초기 컬러값
    private Color startColor;

    //마우스가 올라갈때의 변경 메터리얼 (돈이 충분할때)
    public Material hoverMaterial;
    //마우스가 올라갈때의 변경 메터리얼 (돈이 부족할때)
    public Material moneyMaterial;
    //타일의 메터리얼 초기값
    private Material startMaterial;
    //터렛 설치 위치 조정값
    public Vector3 offsetPos;

    //건설 이펙트
    public GameObject buildEffectPrefab;

    //판매 이펙트
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
        //UI를 위에 위치하는지
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        //선택한 타일위에 터렛이 설치되어 있는지 중복 설치 검사
        if (turret != null)
        {   
            //타일 UI 보여주기
            buildManager.SelectTile(this);
            return;
        }

        bluePrint = buildManager.GetTurretToBuild();

        //터렛 선택 버튼을 클릭하지 않았을 경우
        if (bluePrint == null)
        {
            Debug.Log("터렛을 설치하지 못했습니다");
            return;
        }

        BuildTurret();
    }

    //터렛 건설
    void BuildTurret()
    {
        //비용 계산
        if (PlayerStats.UseMoney(bluePrint.cost) == true)
        {
            //빌드 이펙트 - 라이프타임(2초)후 킬
            GameObject eff = Instantiate(buildEffectPrefab, this.transform.position, Quaternion.identity);
            Destroy(eff, 2f);

            //저장된 터렛 프리팹을 설치
            turret = Instantiate(bluePrint.turretPrefab, this.transform.position + bluePrint.offset, Quaternion.identity);

            //설치할 터렛을 null 초기화
            buildManager.SetTurretToBuild(null);
            //설치 비용 계산
            //Debug.Log($"설치후 남은 소지금: {PlayerStats.Money}");
        }
    }

    //터렛 업그레이드(업그레이드 가격, 업그레이드 프리팹)
    public bool UpgradeTurret()
    {
        //비용계산
        if(PlayerStats.UseMoney(bluePrint.upgradeCost) == true)
        {
            //업그레이드 이펙트(빌드이펙드와 공용) - 라이프타임(2초)후 킬
            GameObject eff = Instantiate(buildEffectPrefab, this.transform.position, Quaternion.identity);
            Destroy(eff, 2f);

            //현재 설치된 터렛을 제거(?)
            Destroy(turret);

            //저장된 터렛의 업그레이드 프리팹을 설치
            turret = Instantiate(bluePrint.upgardePrefab, this.transform.position + bluePrint.offset, Quaternion.identity);

            //업그레이드 상태 저장
            isUpgrade = true;

            //업그레이드 비용 계산
            Debug.Log($"업그레이드 후 남은 소지금: {PlayerStats.Money}");

            return true;
        }

        return false;
    }

    //터렛 판매
    public void SellTurret()
    {
        //판매 비용 계산
        int sellMoney = bluePrint.GetSellCost();

        //터렛 제거
        Destroy(turret);
        bluePrint = null;

        //판매 이펙트 - 라이프타임(2초)후 킬
        GameObject eff = Instantiate(sellEffectPrefab, this.transform.position, Quaternion.identity);
        Destroy(eff, 2f);

        //업그레이드 상태 초기화
        isUpgrade = false;

        PlayerStats.AddMoney(sellMoney);

        //판매시 번 돈 계산
        Debug.Log($"판매 후 남은 소지금: {PlayerStats.Money}");
    }

    private void OnMouseEnter()
    {
        //UI를 위에 위치하는지
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        TurretBlueprint selectBluePrint = buildManager.GetTurretToBuild();

        //설치할 터렛이 없으면
        if (selectBluePrint == null)
        {   
            return;
        }

        //소지금 체크
        if (PlayerStats.HasMoney(selectBluePrint.cost) == true)
        {
            //rend.material.color = hoverColor;
            rend.material = hoverMaterial;
        }
        else //돈부족
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
