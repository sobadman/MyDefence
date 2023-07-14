using UnityEngine;

public class UnityEvent : MonoBehaviour
{
	private void Awake()
	{
		Debug.Log("1실행");
	}

	private void OnEnable()
	{
		Debug.Log("활성화시 실행");
	}

	// Start is called before the first frame update
	void Start()
	{
		Debug.Log("2실행");
	}

	private void FixedUpdate()
	{
		Debug.Log("1초에 50번 실행");
	}

	// Update is called once per frame
	void Update()
	{
		Debug.Log("프레임당 1번 실행");
	}

	private void LateUpdate()
	{
		Debug.Log("업데이트 이후 실행");
	}

	private void OnDisable()
	{
		Debug.Log("비활성화시 실행");    
	}

	private void OnDestroy()
	{
		Debug.Log("onDestroy 실행");
	}
}
