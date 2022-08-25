using System;

namespace _7._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            ButtonClient lamp = new Lamp();
            Button b1 = new Button(lamp);
            b1.detect();

            ButtonClient motor = new Motor();
            Button b2 = new Button(motor);
            b2.detect();
        }
    }

    abstract class ButtonClient {
        abstract public void TurnOn();
        abstract public void TurnOff();
    }

    class Lamp : ButtonClient {

        override public void TurnOn() {
            Console.WriteLine("Turning on the Lamp");
        }

        override public void TurnOff() {
            Console.WriteLine("Turning off the Lamp");
        }

    }

    class Motor : ButtonClient {

        override public void TurnOn() {
            Console.WriteLine("Turning on the Motor");
        }

        override public void TurnOff() {
            Console.WriteLine("Turning off the Motor");
        }

    }

    class Button {

        ButtonClient buttonClient;

        public Button(ButtonClient buttonClient) {
            Console.WriteLine("I am in the constructor of Button");
            this.buttonClient = buttonClient;
        }

        public void detect() {
            Boolean buttonOn = false;

            if (buttonOn) {
                buttonClient.TurnOn();
            } else {
                buttonClient.TurnOff();
            }
        }

    }

}
