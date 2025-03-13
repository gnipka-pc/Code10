using System;

class Person
{
    public string name;
    public int age;

    public void Introduce()
    {
        System.Console.WriteLine($"Привет, мое имя {name}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Person person = new Person();
        person.name = "Ivan";
        person.age = 50;

        System.Console.WriteLine(person.name);
        System.Console.WriteLine(person.age);
    }
}