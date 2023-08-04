using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//���׸� Ŭ���� : ���� �Ű����� T�� ������ �������� Ŭ������ ����� ������ �����Ǵ� Ŭ����
public class Person
{
    public string Name { get; set; }
    public int Number { get; set; }
}


public class GenericCollection : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        List<Person> people = new List<Person>
        {
            new Person() { Name = "ȫ�浿", Number = 1 },
            new Person() { Name = "��λ�", Number = 2 },
            new Person() { Name = "����", Number = 3 }
        };

        for (int i = 0; i < people.Count; i++)
        {
            Debug.Log($"{people[i].Name} - {people[i].Number}");
        }

        //people.Add()
        Person person = new Person();
        person.Name = "��ܺ�";
        person.Number = 4;
        people.Add(person);

        foreach (Person p in people)
        {
            Debug.Log($"{p.Name} - {p.Number}");
        }

    }
}
