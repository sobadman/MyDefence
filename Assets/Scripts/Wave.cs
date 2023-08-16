using UnityEngine;

//Wave 데이터를 관리하는 클래스
[System.Serializable]
public class Wave
{
    public GameObject enemyPrefab;  //스폰할 적 프리팹
    public int count;               //스폰할 적의 숫자
    public float dealyTime;         //스폰 간격
}
