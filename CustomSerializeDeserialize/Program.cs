using CustomSerializeDeserialize;

Employee employee = new Employee();
employee.Name = "Eldar";
employee.Salary = 1000;
employee.Married = false;

Animal animal = new Animal();
animal.Name = "Exapmle Dog";
animal.Age = 5;

string jsonString1 = CustomSD.Serialize(employee);
string jsonString2 = CustomSD.Serialize(animal);

Console.WriteLine(jsonString1);
Console.WriteLine("********************");
Console.WriteLine(jsonString2);




public class Employee
{
    public string Name { get; set; }
    public int Salary { get; set; }
    public bool Married { get; set; }
}

public class Animal
{
    public string Name { get; set; }
    public int Age { get; set; }

}



