using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class MapTileManager : MonoBehaviour
{
    //맵 타일 prefab 오브젝트
    public GameObject tilePrefab;

    public Transform parent;

    bool isCreate = false;


    // Start is called before the first frame update
    void Start()
    {
        //코루틴 함수 호출
        //StartCoroutine(SetWeigth());
        //Debug.Log("실행3");
        /*
        //prefab 인스턴스화
        for(int i = 0; i < 10; i++)
        {
            for(int j = 0; j < 10; j++)
            {
                Instantiate(tilePrefab, new Vector3(i*5, 0, j*5), Quaternion.identity, parent);
            }
        }
        */
        if (isCreate == false)
        {
            StartCoroutine(SetTile());

            Debug.Log("맵타일 생성 시작");
            isCreate = true;
        }
    }



    //코루틴 함수 정의
    IEnumerator SetWeigth()
    {
        Debug.Log("실행1");
        yield return null;
        Debug.Log("실행2");
        yield return new WaitForSeconds(1.0f);
        Debug.Log("실행3");
    }

    //[Q]맵타일 찍는 함수 구현, 타일 10개만, 1개찍고 1초후에 다시찍도록

    IEnumerator SetTile()
    {
        System.Random rand = new System.Random();
        for (int i = 0; i < 10;  i++)
        {
            Instantiate(tilePrefab, new Vector3(rand.Next(0,45), 0, rand.Next(0,45)), Quaternion.identity, parent);
            yield return new WaitForSeconds(1.0f);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
