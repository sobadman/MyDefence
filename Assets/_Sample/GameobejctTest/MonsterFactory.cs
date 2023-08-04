using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterFactory
{
    //매개변수로 MonterType을 받아 타입에 맞게 몬스터를 생성하고 Monster를 반환하는함수 구현
    public Monster CreateMonster(MonterType mType)
    {
        switch (mType)
        {
            case MonterType.M_Slime:
                return new Slime();
            case MonterType.M_Zombie:
                return new Zombie();
            case MonterType.M_Goblin:
                return new Goblin();
        }

        return null;
    }
}
