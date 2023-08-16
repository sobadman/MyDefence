using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TileUI : MonoBehaviour
{
    public GameObject tileUI; //canvas

    Tile selectTile; //선택한 타일의 객체를 저장

    //업그레이드 버튼
    public Button upgradeButton; 

    //가격 UI
    public TextMeshProUGUI upgradeCost;
    public TextMeshProUGUI sellCost;

    /*private void Update()
    {
        //UI 실시간 변경 적용
    }

    private void OnEnable()
    {
        //UI 활성화시에만 값 1번만 적용
    }*/

    public void ShowTileUI(Tile tile)
    {
        selectTile = tile;

        tileUI.SetActive(true);
        this.transform.position = selectTile.transform.position;

        //UI 활성화 - 1번만 적용
        if(selectTile.IsUpgrade == true)
        {
            upgradeCost.text = "DONE";
            upgradeButton.interactable = false;
        }
        else
        {
            upgradeCost.text = selectTile.BluePrint.upgradeCost.ToString() + "G";
            upgradeButton.interactable = true;
        }

        sellCost.text = selectTile.BluePrint.GetSellCost().ToString();
    }

    public void HideTileUI()
    {
        tileUI.SetActive(false);        
    }

    public void Upgrade()
    {   
        //업그레이드 기능 구현
        bool isUpgradeSucess = selectTile.UpgradeTurret();

        //창을 닫을때 처리
        if(isUpgradeSucess == true)
            BuildManager.Instance.DeSelectTile();
    }

    public void Sell()
    {   
        //판매 기능 구현
        selectTile.SellTurret();       
        BuildManager.Instance.DeSelectTile();
    }

}
