using System;

namespace _7._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Lamp l1 = new Lamp();
            Button b1 = new Button(l1);
            b1.detect();
        }
    }

    class Lamp {
        public void TurnOn() {
            Console.WriteLine("Turning on the Lamp");
        }
        public void TurnOff() {
            Console.WriteLine("Turning off the lamp");
        }
    }

    class Button {

        private Lamp lamp;

        public Button(Lamp lamp) {
            Console.WriteLine("I am in the constructor of Button");
            this.lamp = lamp;
        }

        public void detect() {
            Boolean buttonOn = false; //associated with something physical

            if (buttonOn) {
                lamp.TurnOn();
            } else {
                lamp.TurnOff();
            }
        }

    }
}
