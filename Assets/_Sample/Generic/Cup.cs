using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water { }

public class Cola { }

//���׸� Ŭ���� : ���� �Ű����� T�� ������ �������� Ŭ������ ����� ������ �����Ǵ� Ŭ����
//���׸� Ŭ���� ����� : public class Ŭ�����̸�<T>
// T : (������)���� �Ű�����
public class Cup<T>
{
    public T Content { get; set; }

    public void PrintData(T data)
    {
        Debug.Log(data);
    }
}
