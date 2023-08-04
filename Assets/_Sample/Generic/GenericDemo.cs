using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericDemo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Cup (제네릭)클래스의 객체 생성
        //Cup c = new Cup();
        //문자열 데이터를 저장하는 속성을 가진 객체 생성
        Cup<string> text = new Cup<string>();
        text.Content = "문자열 속성";

        //int형 데이터를 저장하는 속성을 가진 객체 생성
        Cup<int> number = new Cup<int>();
        number.Content = 1234;

        Debug.Log($"{text.Content} - {number.Content}");

        //Water 를 저장하는 속성을 가진 객체 생성
        Cup<Water> waterCup = new Cup<Water>();
        Water water = new Water();
        waterCup.Content = water;
        Debug.Log(waterCup.Content.ToString());

    }
}
