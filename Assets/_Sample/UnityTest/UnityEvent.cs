using UnityEngine;

public class UnityEvent : MonoBehaviour
{
	private void Awake()
	{
		Debug.Log("1����");
	}

	private void OnEnable()
	{
		Debug.Log("Ȱ��ȭ�� ����");
	}

	// Start is called before the first frame update
	void Start()
	{
		Debug.Log("2����");
	}

	private void FixedUpdate()
	{
		Debug.Log("1�ʿ� 50�� ����");
	}

	// Update is called once per frame
	void Update()
	{
		Debug.Log("�����Ӵ� 1�� ����");
	}

	private void LateUpdate()
	{
		Debug.Log("������Ʈ ���� ����");
	}

	private void OnDisable()
	{
		Debug.Log("��Ȱ��ȭ�� ����");    
	}

	private void OnDestroy()
	{
		Debug.Log("onDestroy ����");
	}
}
