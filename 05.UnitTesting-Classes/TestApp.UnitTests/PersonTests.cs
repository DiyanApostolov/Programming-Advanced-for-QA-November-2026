using NUnit.Framework;

using System;
using System.Collections.Generic;
using System.Text;

namespace TestApp.UnitTests;

public class PersonTests
{
    private Person _person;

    [SetUp]
    public void SetUp()
    {
        _person = new Person();
    }

    // TODO: finish test
    [Test]
    public void Test_AddPeople_ReturnsListWithUniquePeople()
    {
        // Arrange
        string[] peopleData = { "Alice A001 25", "Bob B002 30", "Alice A001 35" };

        List<Person> expectedPeopleList = new List<Person>();

        Person person1 = new Person()
        {
            Name = "Alice",
            Id = "A001",
            Age = 35
        };

        Person person2 = new Person()
        {
            Name = "Bob",
            Id = "B002",
            Age = 30
        };

        expectedPeopleList.Add(person1);
        expectedPeopleList.Add(person2);

        // Act
        List<Person> resultPeopleList = _person.AddPeople(peopleData);

        // Assert
        Assert.That(resultPeopleList, Has.Count.EqualTo(2));

        for (int i = 0; i < resultPeopleList.Count; i++)
        {
            Assert.That(resultPeopleList[i].Name, Is.EqualTo(expectedPeopleList[i].Name));
            Assert.That(resultPeopleList[i].Id, Is.EqualTo(expectedPeopleList[i].Id));
            Assert.That(resultPeopleList[i].Age, Is.EqualTo(expectedPeopleList[i].Age));
        }
    }

    [Test]
    public void Test_GetByAgeAscending_SortsPeopleByAge()
    {
        // Arrange
        List<Person> listOfPersons = new List<Person>();

        Person person1 = new Person()
        {
            Name = "Alice",
            Id = "A001",
            Age = 25
        };

        Person person2 = new Person()
        {
            Name = "Bob",
            Id = "B002",
            Age = 30
        };

        Person person3 = new Person()
        {
            Name = "Dido",
            Id = "D003",
            Age = 20
        };

        listOfPersons.Add(person1);
        listOfPersons.Add(person2);
        listOfPersons.Add(person3);

        StringBuilder expected = new StringBuilder();
        expected.AppendLine("Dido with ID: D003 is 20 years old.");
        expected.AppendLine("Alice with ID: A001 is 25 years old.");
        expected.AppendLine("Bob with ID: B002 is 30 years old.");

        // Act
        string result = _person.GetByAgeAscending(listOfPersons);

        // Assert
        Assert.That(result, Is.EqualTo(expected.ToString().Trim()));
    }
}
