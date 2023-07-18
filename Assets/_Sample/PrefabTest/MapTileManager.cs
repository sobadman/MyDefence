using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class MapTileManager : MonoBehaviour
{
    //�� Ÿ�� prefab ������Ʈ
    public GameObject tilePrefab;

    public Transform parent;

    bool isCreate = false;


    // Start is called before the first frame update
    void Start()
    {
        //�ڷ�ƾ �Լ� ȣ��
        //StartCoroutine(SetWeigth());
        //Debug.Log("����3");
        /*
        //prefab �ν��Ͻ�ȭ
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

            Debug.Log("��Ÿ�� ���� ����");
            isCreate = true;
        }
    }



    //�ڷ�ƾ �Լ� ����
    IEnumerator SetWeigth()
    {
        Debug.Log("����1");
        yield return null;
        Debug.Log("����2");
        yield return new WaitForSeconds(1.0f);
        Debug.Log("����3");
    }

    //[Q]��Ÿ�� ��� �Լ� ����, Ÿ�� 10����, 1����� 1���Ŀ� �ٽ��ﵵ��

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
