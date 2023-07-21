using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //������ ����
        Monster slime = FactoryFn(MonsterType.M_Slime);
        //������ ����
        slime.Attack();
        //���� ����
        Monster zombie = FactoryFn(MonsterType.M_Zombie);
        //���� ����
        zombie.Attack();

    }

    Monster FactoryFn(MonsterType mType)
    {
        switch (mType)
        {
            case MonsterType.M_Slime:
                return new Slime();
            case MonsterType.M_Zombie:
                return new Zombie();
        }

        return null;
    }
}
