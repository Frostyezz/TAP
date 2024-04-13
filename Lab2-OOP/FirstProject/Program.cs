namespace FirstProject;

class Program
{
    static void Main(string[] args)
    {
        Manager manager1 = new Manager("Andrei", "Marketing", 1000);
        Manager manager2 = new Manager("Paul", "HR", 2000);

        Console.WriteLine($"Angajatul {manager1.GetNume()} din departamentul {manager1.GetDepartament()} are un salariu de {manager1.CalculSalariu()}");
        Console.WriteLine($"Angajatul {manager2.GetNume()} din departamentul {manager2.GetDepartament()} are un salariu de {manager2.CalculSalariu()}");
    }
}
 
// [Abstraction] clasa de baza
public abstract class Angajat
{
    private string nume;
    private string departament;

    protected Angajat(string nume1, string departament1)
    {
        nume = nume1;
        departament = departament1;
    }

    // [Abstraction] metoda abstracta
    public abstract int CalculSalariu();

    // [Encapsulation] functie de returnare a numelui
    public string GetNume()
    {
        return nume;
    }

    // [Encapsulation] functie de returnare a departamentului
    public string GetDepartament()
    {
        return departament;
    }
}

// [Inheritance] mostenire clasa de baza
public class Manager : Angajat
{
    // [Encapsulation] bonusul ramane privat
    private int bonus;

    public Manager(string nume, string departament, int bonus1) : base(nume, departament)
    {
        bonus = bonus1;
    }

    // [Polymorphism] implementarea metodei abstracte
    public override int CalculSalariu()
    {
        return 5000 + bonus;
    }
}

