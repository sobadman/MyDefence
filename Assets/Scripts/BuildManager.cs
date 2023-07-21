using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    private static BuildManager instance;

    public static BuildManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new BuildManager();
            }
            return instance;
        }
    }

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;
    }

    //¼³Ä¡ÇÒ ÅÍ·¿
    private GameObject turretToBuild;
    public GameObject basicTurretPrefab;

    private void Start()
    {
        turretToBuild = basicTurretPrefab;
    }

    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }
}
