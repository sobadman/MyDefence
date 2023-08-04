using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileUI : MonoBehaviour
{
    public GameObject tileUI; //canvas

    public void ShowTileUI(Tile tile)
    {
        tileUI.SetActive(true);
        this.transform.position = tile.transform.position;
    }

    public void HideTileUI()
    {
        tileUI.SetActive(false);
    }
}
