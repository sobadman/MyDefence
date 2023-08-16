using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TileUI : MonoBehaviour
{
    public GameObject tileUI; //canvas

    Tile selectTile; //������ Ÿ���� ��ü�� ����

    //���׷��̵� ��ư
    public Button upgradeButton; 

    //���� UI
    public TextMeshProUGUI upgradeCost;
    public TextMeshProUGUI sellCost;

    /*private void Update()
    {
        //UI �ǽð� ���� ����
    }

    private void OnEnable()
    {
        //UI Ȱ��ȭ�ÿ��� �� 1���� ����
    }*/

    public void ShowTileUI(Tile tile)
    {
        selectTile = tile;

        tileUI.SetActive(true);
        this.transform.position = selectTile.transform.position;

        //UI Ȱ��ȭ - 1���� ����
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
        //���׷��̵� ��� ����
        bool isUpgradeSucess = selectTile.UpgradeTurret();

        //â�� ������ ó��
        if(isUpgradeSucess == true)
            BuildManager.Instance.DeSelectTile();
    }

    public void Sell()
    {   
        //�Ǹ� ��� ����
        selectTile.SellTurret();       
        BuildManager.Instance.DeSelectTile();
    }

}
