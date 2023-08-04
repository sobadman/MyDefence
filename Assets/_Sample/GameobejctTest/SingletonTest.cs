using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SingletonTest : MonoBehaviour
{
    private static SingletonTest instance;

    public static SingletonTest Instance
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

        //씬 전환시에 삭제가 안됨
        //DontDestroyOnLoad(gameObject);
    }

}
