using System;

namespace simplefactory
{
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

    class SimplePizzaFactory {

        public Pizza createPizza(String type) {
            
            Pizza pizza = null;

            if (type.Equals("Cheese")) {
                pizza = new CheesePizza();
            } else if (type.Equals("Pepperoni")) {
                pizza = new PepperoniPizza();
            } 

            return pizza;

        }

    }

    abstract class AbstractPizzaFactory {

        abstract public Pizza factoryMethod();

        public string SomeOperation()
        {
            // Call the factory method to create a Product object.
            Pizza pizza = factoryMethod();
            // Now, use the product.
            var result = " -- " + pizza.prepare();

            return result;
        }

    }
    class CheesePizzaCreator : AbstractPizzaFactory
    {
        public override Pizza factoryMethod()
        {
            return new CheesePizza();
        }
    }

    class PepperoniPizzaCreator : AbstractPizzaFactory
    {
        public override Pizza factoryMethod()
        {
            return new PepperoniPizza();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to World's Best Pizza!");

            String type = "Cheese";

            /* Bad way of ordering pizza */
            Pizza pizza = orderPizza(type);

            Console.WriteLine(pizza.prepare());

            /* Ugly way of ordering pizza [Simple Factory] */
            SimplePizzaFactory factory = new SimplePizzaFactory();
            pizza = factory.createPizza(type);

            Console.WriteLine(pizza.prepare());

            /* Good way of ordering pizza [Factory Method] */
            AbstractPizzaFactory afactory = new CheesePizzaCreator();
            pizza = afactory.factoryMethod();

            Console.WriteLine(pizza.prepare());
        }

        static Pizza orderPizza(String type) {
            Pizza pizza = null;

            if (type.Equals("Cheese")) {
                pizza = new CheesePizza();
            } else if (type.Equals("Pepperoni")) {
                pizza = new PepperoniPizza();
            } 

            return pizza;
        }
    }

}
