using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water { }

public class Cola { }

//제네릭 클래스 : 형식 매개변수 T에 지정한 형식으로 클래스와 멤버의 성질이 결정되는 클래스
//제네릭 클래스 만들기 : public class 클래스이름<T>
// T : (데이터)형식 매개변수
public class Cup<T>
{
    public T Content { get; set; }

    public void PrintData(T data)
    {
        Debug.Log(data);
    }
}
