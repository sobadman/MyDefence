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

        //�� ��ȯ�ÿ� ������ �ȵ�
        //DontDestroyOnLoad(gameObject);
    }

}
