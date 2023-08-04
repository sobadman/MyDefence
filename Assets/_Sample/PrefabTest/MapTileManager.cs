using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTileManager : MonoBehaviour
{
    //맵 타일 프리팹 오브젝트
    public GameObject tilePrefab;

    //생성될 맵 타일의 부모 오브젝트
    public Transform parent;

    //맵 타일 생성을 체크하는 변수
    bool isCreate = false;

    // Start is called before the first frame update
    void Start()
    {
        //프리팹의 게임오브젝트 생성
        //Instantiate(tilePrefab, new Vector3(0, 0, 0), Quaternion.identity);

        //CreateMapTile();

        //코루틴 함수 호출
        //StartCoroutine(SetWeigth());
        //Debug.Log("실행4");

        //StartCoroutine(GenerateMapTile());
    }

    // Update is called once per frame
    void Update()
    {
        //코루틴 함수 호출 - 1회 호출
        if(isCreate == false)
        {
            //맵 생성 코루틴 함수 호출
            StartCoroutine(GenerateMapTile());

            Debug.Log("맵타일 찍기 시작");
            isCreate = true;
        }

    }

    void CreateMapTile()
    {
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                Instantiate(tilePrefab, new Vector3(i * 5, 0, j * -5), Quaternion.identity, parent);
            }
        }

    }

    //[Q] 맵타일 찍는 함수 구현 - tile 프리팹 이용
    //타일 10개만
    //1개 찍을때마다 1초 지연후 다시 찍고
    //위치는 Random x:0~45, y=0, z:-45~0
    IEnumerator GenerateMapTile()
    {
        float xPos = 0f;
        float zPos = 0f;

        for (int i = 0; i < 10; i++)
        {
            xPos = Random.Range(0f, 45f);
            zPos = Random.Range(-45f, 0f);

            Instantiate(tilePrefab, new Vector3(xPos, 0, zPos), Quaternion.identity);
            yield return new WaitForSeconds(1.0f);
        }

        Debug.Log("맵타일 찍기 완료");
        isCreate = false;
    }


    //코룬틴 함수 정의
    IEnumerator SetWeigth()
    {
        Debug.Log("실행1");
        yield return null; //일시 정지,
        
        Debug.Log("실행2"); //여기서 부터 다시 시작

        yield return new WaitForSeconds(1.0f); //일시 정지한 다음 1초후에 다음 라인 실행

        Debug.Log("1초후 실행"); //여기서 부터 다시 시작

        yield return new WaitForSeconds(3.0f); //일시 정지한 다음 1초후에 다음 라인 실행

        Debug.Log("3초후 실행"); //여기서 부터 다시 시작
    }
}
