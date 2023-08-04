using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterFactory
{
    //�Ű������� MonterType�� �޾� Ÿ�Կ� �°� ���͸� �����ϰ� Monster�� ��ȯ�ϴ��Լ� ����
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
