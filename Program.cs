using System;
using System.Text;

class Pizza
{
    public string Dough { get; set; }
    public string Sauce { get; set; }
    public string Topping { get; set; }

    public void Display()
    {
        Console.WriteLine($"Тесто: {Dough}\nСоус: {Sauce}\nНачинка: {Topping}\n");
    }
}

interface IPizzaBuilder
{
    void SetDough(string dough);
    void SetSauce(string sauce);
    void SetTopping(string topping);
    Pizza GetPizza();
}

class MargheritaBuilder : IPizzaBuilder
{
    private Pizza _pizza = new Pizza();

    public void SetDough(string dough) => _pizza.Dough = dough;
    public void SetSauce(string sauce) => _pizza.Sauce = sauce;
    public void SetTopping(string topping) => _pizza.Topping = topping;

    public Pizza GetPizza() => _pizza;
}

class Chef
{
    private IPizzaBuilder _builder;

    public Chef(IPizzaBuilder builder) => _builder = builder;

    public void MakePizza()
    {
        _builder.SetDough("Тонкое");
        _builder.SetSauce("Томатный");
        _builder.SetTopping("Сыр + Помидоры");
    }
}

class Program
{
    static void Main()
    {
        var builder = new MargheritaBuilder();
        var chef = new Chef(builder);

        chef.MakePizza();
        Pizza pizza = builder.GetPizza();
        pizza.Display();
    }
}