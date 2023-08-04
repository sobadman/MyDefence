using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityEvent : MonoBehaviour
{
    private void Awake()
    {
        Debug.Log("[1] Awake 실행"); //1회만 실행
    }

    private void OnEnable()
    {
        Debug.Log("[7-1] OnEnable 실행"); //1회만 실행, 활성화 될때마다
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("[2] Start 실행"); //1회만 실행 - 초기화
    }

    private void FixedUpdate()
    {
        Debug.Log("[3] FixedUpdate 실행"); //1초에 50번 호출 - 고정
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("[4] Update 실행"); //매 프레임마다 호출, 
    }

    private void OnMouseOver()
    {
        
    }

    private void LateUpdate()
    {
        Debug.Log("[5] LateUpdate 실행"); //Update 실행뒤에 바로 뒤따라서 실행
    }

    private void OnDisable()
    {
        Debug.Log("[7-1] OnDisable 실행"); //1회만 실행, 비활성화 될때마다
    }

    private void OnDestroy()
    {
        Debug.Log("[6] OnDestroy 실행");
    }
}
