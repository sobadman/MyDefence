using UnityEngine;

public class Tile : MonoBehaviour
{
    private Renderer rend;

    public Color hoverColor;
    private Color startColor;

    public Material hoverMaterial;

    private Material startMaterial;

    public GameObject turretPrefab;

    public Vector3 offsetPos;

    private GameObject turret = null;

    private void Start()
    {
        rend = this.GetComponent<Renderer>();
        startColor = rend.material.color;
        startMaterial = rend.material;
    }

    void OnMouseEnter()
	{
        //rend.material.color = hoverColor;
        rend.material = hoverMaterial;
	}

	void OnMouseExit() 
	{
        rend.material = startMaterial;
        //rend.material.color = startColor;
	}

    void OnMouseDown()
    {
        if(turret == null)
        {
            turret = Instantiate(BuildManager.Instance.GetTurretToBuild(), this.transform.position + offsetPos, Quaternion.identity);
        }
    }
}
