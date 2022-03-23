namespace StackLite;

public class Animal : IWalkable
{
    public string Name { get; set; }

    public virtual void Walk()
    {
        Console.WriteLine("I walk");
    }
}
public class Dog : Animal
{
    public Dog(string name)
    {
        this.Name = name;
    }
    public override void Walk()
    {
        Console.WriteLine("Dog walks");
    }
}

public class Cat : Animal
{
    public override void Walk()
    {
        Console.WriteLine("Cat walks");
    }
}