using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton
{
    private static Singleton instance;

    public static Singleton Instance
    {
        get 
        {
            if (instance == null)
            {
                instance = new Singleton();
            }
            return instance;
        }
    }

    /*
    public static Singleton Instance()
    {
        if (instance == null)
        {
            instance = new Singleton();
        }
        return instance;
    }
    */
}
