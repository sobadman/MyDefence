using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMonsterFactory
{
    Monster CreateMonster(); //���丮 �޼���
}

public class SlimeFactory : IMonsterFactory
{
    public int count = 0;

    public Monster CreateMonster()
    {
        return new Slime();
    }

    public void SlimeCount() => count++;
}

public class ZombieFactory : IMonsterFactory
{
    public Monster CreateMonster()
    {
        return new Zombie();
    }

    public void AddSomething()
    {
        Debug.Log("Add Something");
    }
}
