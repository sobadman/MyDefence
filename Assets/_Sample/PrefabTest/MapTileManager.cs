using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTileManager : MonoBehaviour
{
    //�� Ÿ�� ������ ������Ʈ
    public GameObject tilePrefab;

    //������ �� Ÿ���� �θ� ������Ʈ
    public Transform parent;

    //�� Ÿ�� ������ üũ�ϴ� ����
    bool isCreate = false;

    // Start is called before the first frame update
    void Start()
    {
        //�������� ���ӿ�����Ʈ ����
        //Instantiate(tilePrefab, new Vector3(0, 0, 0), Quaternion.identity);

        //CreateMapTile();

        //�ڷ�ƾ �Լ� ȣ��
        //StartCoroutine(SetWeigth());
        //Debug.Log("����4");

        //StartCoroutine(GenerateMapTile());
    }

    // Update is called once per frame
    void Update()
    {
        //�ڷ�ƾ �Լ� ȣ�� - 1ȸ ȣ��
        if(isCreate == false)
        {
            //�� ���� �ڷ�ƾ �Լ� ȣ��
            StartCoroutine(GenerateMapTile());

            Debug.Log("��Ÿ�� ��� ����");
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

    //[Q] ��Ÿ�� ��� �Լ� ���� - tile ������ �̿�
    //Ÿ�� 10����
    //1�� ���������� 1�� ������ �ٽ� ���
    //��ġ�� Random x:0~45, y=0, z:-45~0
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

        Debug.Log("��Ÿ�� ��� �Ϸ�");
        isCreate = false;
    }


    //�ڷ�ƾ �Լ� ����
    IEnumerator SetWeigth()
    {
        Debug.Log("����1");
        yield return null; //�Ͻ� ����,
        
        Debug.Log("����2"); //���⼭ ���� �ٽ� ����

        yield return new WaitForSeconds(1.0f); //�Ͻ� ������ ���� 1���Ŀ� ���� ���� ����

        Debug.Log("1���� ����"); //���⼭ ���� �ٽ� ����

        yield return new WaitForSeconds(3.0f); //�Ͻ� ������ ���� 1���Ŀ� ���� ���� ����

        Debug.Log("3���� ����"); //���⼭ ���� �ٽ� ����
    }
}
