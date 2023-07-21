using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MonsterType
{
    M_Slime,
    M_Zombie
}

public abstract class Monster
{
    public abstract void Attack();
}

public class Slime : Monster
{
    public override void Attack()
    {
        Debug.Log("������ ����");
    }
}
public class Zombie : Monster
{
    public override void Attack()
    {
        Debug.Log("���� ����");
    }
}