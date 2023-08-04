using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityEvent : MonoBehaviour
{
    private void Awake()
    {
        Debug.Log("[1] Awake ����"); //1ȸ�� ����
    }

    private void OnEnable()
    {
        Debug.Log("[7-1] OnEnable ����"); //1ȸ�� ����, Ȱ��ȭ �ɶ�����
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("[2] Start ����"); //1ȸ�� ���� - �ʱ�ȭ
    }

    private void FixedUpdate()
    {
        Debug.Log("[3] FixedUpdate ����"); //1�ʿ� 50�� ȣ�� - ����
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("[4] Update ����"); //�� �����Ӹ��� ȣ��, 
    }

    private void OnMouseOver()
    {
        
    }

    private void LateUpdate()
    {
        Debug.Log("[5] LateUpdate ����"); //Update ����ڿ� �ٷ� �ڵ��� ����
    }

    private void OnDisable()
    {
        Debug.Log("[7-1] OnDisable ����"); //1ȸ�� ����, ��Ȱ��ȭ �ɶ�����
    }

    private void OnDestroy()
    {
        Debug.Log("[6] OnDestroy ����");
    }
}
