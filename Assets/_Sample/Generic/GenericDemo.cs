using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericDemo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Cup (���׸�)Ŭ������ ��ü ����
        //Cup c = new Cup();
        //���ڿ� �����͸� �����ϴ� �Ӽ��� ���� ��ü ����
        Cup<string> text = new Cup<string>();
        text.Content = "���ڿ� �Ӽ�";

        //int�� �����͸� �����ϴ� �Ӽ��� ���� ��ü ����
        Cup<int> number = new Cup<int>();
        number.Content = 1234;

        Debug.Log($"{text.Content} - {number.Content}");

        //Water �� �����ϴ� �Ӽ��� ���� ��ü ����
        Cup<Water> waterCup = new Cup<Water>();
        Water water = new Water();
        waterCup.Content = water;
        Debug.Log(waterCup.Content.ToString());

    }
}
