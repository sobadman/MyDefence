using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //슬라임 생성, //슬라임 공격
        //Monster slime = FactoryFn(MonterType.M_Slime);        
        //slime.Attack();
        //좀비 생성, //좀비 공격
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

    //매개변수로 MonterType을 받아 타입에 맞게 몬스터를 생성하고 Monster를 반환하는함수 구현
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
디자인 패턴 (프로그램 설계 패턴)
- 개발자가 프로그램을 설계하면서 자주 반복되는 문제들 해결하기 위한 방법을 미리 구체화 시킨것
- 생성
.. 팩토리 패턴 (심플)
.. 팩토리 메서드 패턴
   . 팩토리 패턴 확장
   . 팩토리에 추가 기능
.. 추상 팩토리 패턴

.. 싱글톤 패턴
..
..
- 구조

- 행동


*/
