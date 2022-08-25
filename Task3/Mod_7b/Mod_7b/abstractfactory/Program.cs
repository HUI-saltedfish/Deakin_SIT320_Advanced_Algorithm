using System;

namespace abstractfactory
{
    public interface IAbstractFactory
    {
        Pizza CreatePizza();

        Burger CreateBurger();
    }

    class CheeseFactory : IAbstractFactory
    {
        public Pizza CreatePizza()
        {
            return new CheesePizza();
        }

        public Burger CreateBurger()
        {
            return new CheeseBurger();
        }
    }

    class PepperoniFactory : IAbstractFactory
    {
        public Pizza CreatePizza()
        {
            return new PepperoniPizza();
        }

        public Burger CreateBurger()
        {
            return new PepperoniBurger();
        }
    }

    public interface Pizza
    {
        string prepare();
    }

    class CheesePizza : Pizza
    {
        public string prepare()
        {
            return "Preparing a yummy Cheese Pizza";
        }
    }

    class PepperoniPizza : Pizza
    {
        public string prepare()
        {
            return "Preparing a yummy Pepperoni Pizza";
        }
    }

    public interface Burger
    {
        string prepare();

        string Combo(Pizza pizza);
    }

    class CheeseBurger : Burger
    {
        public string prepare()
        {
            return "Preparing a yummy Cheese Burger";
        }

        public string Combo(Pizza pizza)
        {
            return pizza.prepare() + prepare();

        }
    }

    class PepperoniBurger : Burger
    {
        public string prepare()
        {
            return "Preparing a yummy Pepperoni Burger";
        }

        public string Combo(Pizza pizza)
        {
            return pizza.prepare() + prepare();

        }
    }

    class Client
    {
        public void Main()
        {
            Console.WriteLine("Client: Testing client code with the first factory type...");
            ClientMethod(new CheeseFactory());
            Console.WriteLine();

            Console.WriteLine("Client: Testing the same client code with the second factory type...");
            ClientMethod(new PepperoniFactory());
        }

        public void ClientMethod(IAbstractFactory factory)
        {
            var pizza = factory.CreatePizza();
            var burger = factory.CreateBurger();

            Console.WriteLine(pizza.prepare());
            Console.WriteLine(burger.prepare());
            //Console.WriteLine(burger.Combo(pizza));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            new Client().Main();
        }
    }

}
