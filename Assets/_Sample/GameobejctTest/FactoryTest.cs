using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //������ ����, //������ ����
        //Monster slime = FactoryFn(MonterType.M_Slime);        
        //slime.Attack();
        //���� ����, //���� ����
        //Monster zombie = FactoryFn(MonterType.M_Zombie);        
        //zombie.Attack();

        //MonsterFactory monsterFactory = new MonsterFactory();
        //Monster slime = monsterFactory.CreateMonster(MonterType.M_Slime);
        //slime.Attack();

        //Monster zombie = monsterFactory.CreateMonster(MonterType.M_Zombie);
        //zombie.Attack();

        SlimeFactory slimeFactory = new SlimeFactory();
        Monster slime = slimeFactory.CreateMonster();
        slimeFactory.SlimeCount();
        Debug.Log(slimeFactory.count);

        ZombieFactory zombieFactory = new ZombieFactory();
        Monster zombie = zombieFactory.CreateMonster();
        zombieFactory.AddSomething();

    }

    //�Ű������� MonterType�� �޾� Ÿ�Կ� �°� ���͸� �����ϰ� Monster�� ��ȯ�ϴ��Լ� ����
    Monster FactoryFn(MonterType mType)
    {
        switch (mType)
        {
            case MonterType.M_Slime:
                return new Slime();
            case MonterType.M_Zombie:
                return new Zombie();
        }

        return null;
    }

}


/*
������ ���� (���α׷� ���� ����)
- �����ڰ� ���α׷��� �����ϸ鼭 ���� �ݺ��Ǵ� ������ �ذ��ϱ� ���� ����� �̸� ��üȭ ��Ų��
- ����
.. ���丮 ���� (����)
.. ���丮 �޼��� ����
   . ���丮 ���� Ȯ��
   . ���丮�� �߰� ���
.. �߻� ���丮 ����

.. �̱��� ����
..
..
- ����

- �ൿ


*/
