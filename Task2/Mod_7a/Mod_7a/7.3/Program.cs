using System;

namespace _7._3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            ButtonClient lamp = new Lamp();
            Button b1 = new RubberButton(lamp, 10);
            b1.detect();

            ButtonClient motor = new Motor();
            Button b2 = new PlasticButton(motor, 5, 2);
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

    abstract class Button {

        ButtonClient buttonClient;

        public Button(ButtonClient buttonClient) {
            Console.WriteLine("I am in the constructor of Button");
            this.buttonClient = buttonClient;
        }

        virtual public void detect() {
            Boolean buttonOn = false;

            if (buttonOn) {
                buttonClient.TurnOn();
            } else {
                buttonClient.TurnOff();
            }
        }

    }

    class RubberButton : Button {

        private int speed;

        public RubberButton(ButtonClient buttonClient, int speed) : base(buttonClient) {
            Console.WriteLine("I am in the constructor of Rubber Button");
            this.speed = speed;
        }

    }

    class PlasticButton : Button {

        private int speed;
        private int max;

        public PlasticButton(ButtonClient buttonClient, int speed, int max) : base(buttonClient) {
            Console.WriteLine("I am in the constructor of Plastic Button");
            this.speed = speed;
            this.max = max;
        }

    }

}
