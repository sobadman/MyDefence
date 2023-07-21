using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //슬라임 생성
        Monster slime = FactoryFn(MonsterType.M_Slime);
        //슬라임 공격
        slime.Attack();
        //좀비 생성
        Monster zombie = FactoryFn(MonsterType.M_Zombie);
        //좀비 공격
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
