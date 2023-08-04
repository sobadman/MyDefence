using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//제네릭 클래스 : 형식 매개변수 T에 지정한 형식으로 클래스와 멤버의 성질이 결정되는 클래스
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
            new Person() { Name = "홍길동", Number = 1 },
            new Person() { Name = "백두산", Number = 2 },
            new Person() { Name = "장길산", Number = 3 }
        };

        for (int i = 0; i < people.Count; i++)
        {
            Debug.Log($"{people[i].Name} - {people[i].Number}");
        }

        //people.Add()
        Person person = new Person();
        person.Name = "김단비";
        person.Number = 4;
        people.Add(person);

        foreach (Person p in people)
        {
            Debug.Log($"{p.Name} - {p.Number}");
        }

    }
}
