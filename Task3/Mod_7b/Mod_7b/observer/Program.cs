using System;
using System.Threading;
using System.Collections.Generic;

namespace observer
{

    // Nayyar / John
    public interface Subscriber
    { 
        void Update(IPublisher subject);
    }

    class ConcreteSubscriberA : Subscriber
    {
        public void Update(IPublisher subject)
        {            
            Console.WriteLine("Mobile Device (display): " + (subject as Publisher).Wickets + "/" + (subject as Publisher).Score);
        }
    }

    class ConcreteSubscriberB : Subscriber
    {
        public void Update(IPublisher subject)
        {
            Console.WriteLine("Laptop Device (display): " + (subject as Publisher).Wickets + "/" + (subject as Publisher).Score);
        }
    }

    public interface IPublisher
    {
        // Attach an observer to the subject.
        void Attach(Subscriber observer);

        // Detach an observer from the subject.
        void Detach(Subscriber observer);

        // Notify all observers about an event.
        void Notify();
    }

    public class Publisher : IPublisher
    {
        public int Wickets { get; set; } = -0;
        public int Score { get; set; } = -0;

        // List of subscribers. In real life, the list of subscribers can be
        // stored more comprehensively (categorized by event type, etc.).
        private List<Subscriber> subscribers = new List<Subscriber>();

        // The subscription management methods.
        public void Attach(Subscriber observer)
        {
            Console.WriteLine("Subject: Attached an observer.");
            this.subscribers.Add(observer);
        }

        public void Detach(Subscriber observer)
        {
            this.subscribers.Remove(observer);
            Console.WriteLine("Subject: Detached an observer.");
        }

        // Trigger an update in each subscriber.
        public void Notify()
        {
            Console.WriteLine("Subject: Notifying observers...");

            foreach (var subscriber in subscribers)
            {
                subscriber.Update(this);
            }
        }

        public void wicketFallen()
        {
            Thread.Sleep(10000);

            this.Wickets += 1;

            Console.WriteLine("Subject: Wicket Fallen: " + this.Wickets);
            this.Notify();
        }

        public void scoreIncrease(int score)
        {
            Thread.Sleep(10000);

            this.Score += score;

            Console.WriteLine("Subject: Score Changed: " + this.Score);
            this.Notify();
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            // The client code.
            // new game between england and newzealand is started:
            var publisher = new Publisher();
            
            // Nayyar has opened his website
            var subscriberA = new ConcreteSubscriberA();
            publisher.Attach(subscriberA);

            // Aya opening her website
            var subscriberB = new ConcreteSubscriberB();
            publisher.Attach(subscriberB);

            /* Game has started */
            publisher.scoreIncrease(1);
            publisher.scoreIncrease(1);
            publisher.scoreIncrease(6);
            
            publisher.wicketFallen();
            
            publisher.Detach(subscriberB);
            
            publisher.scoreIncrease(1);
            publisher.scoreIncrease(6);
            publisher.wicketFallen();
        }
    }

}
