using FlaskeAutomaten.Bottles;
using System;
using System.Collections.Generic;
using System.Threading;

namespace FlaskeAutomaten
{
    class Program
    {
        static Queue<Bottle> combinedbelt = new Queue<Bottle>(10);
        static Queue<Bottle> sodabelt = new Queue<Bottle>(10);
        static Queue<Bottle> beerbelt = new Queue<Bottle>(10);
        static int bNumber = 0;
        static void Main(string[] args)
        {
            Thread t = new Thread(Producer);
            t.Start();
            t = new Thread(Splitter);
            t.Start();
            t = new Thread(BeerConsumer);
            t.Start();
            t = new Thread(SodaConsumer);
            t.Start();

            while (true)
            {

            }
        }

        static void Producer()
        {
            Random random = new Random();
            Bottle bottle = null;
            lock (combinedbelt)
            {
                while (true)
                {

                    switch (random.Next(1, 3))
                    {
                        case 1:
                            if (combinedbelt.Count < 10)
                            {
                                bottle = new SodaBottle("Soda", bNumber.ToString());
                                bNumber++;
                                Console.WriteLine("Proucer made a soda");
                                combinedbelt.Enqueue(bottle);
                                Monitor.Pulse(combinedbelt);

                            }
                            if (combinedbelt.Count == 10)
                            {
                                Monitor.Wait(combinedbelt);
                                combinedbelt.Enqueue(bottle);
                            }
                            break;
                        case 2:
                            if (combinedbelt.Count < 10)
                            {
                                bottle = new BeerBottle("Beer", bNumber.ToString());
                                bNumber++;
                                Console.WriteLine("Producer made a beer");
                                lock (combinedbelt)
                                {
                                    combinedbelt.Enqueue(bottle);
                                    Monitor.Pulse(combinedbelt);
                                }
                            }
                            if (combinedbelt.Count == 10)
                            {
                                Monitor.Wait(combinedbelt);
                            }
                            break;
                    }
                }
            }
        }

        static void Splitter()
        {
            Bottle bottle;
            lock (combinedbelt)
            {
                lock (sodabelt)
                {
                    lock (beerbelt)
                    {
                        Monitor.Wait(combinedbelt);
                        while (true)
                        {
                            bottle = combinedbelt.Dequeue();
                            if (bottle is SodaBottle)
                            {
                                if (sodabelt.Count == 10)
                                {
                                    Monitor.Wait(sodabelt);
                                }
                                if (sodabelt.Count < 10)
                                {
                                    sodabelt.Enqueue(bottle);
                                    Console.WriteLine("split to soda");
                                    Monitor.Pulse(sodabelt);
                                    Monitor.Pulse(combinedbelt);
                                }
                            }
                            if (bottle is BeerBottle)
                            {
                                if (beerbelt.Count == 10)
                                {
                                    Monitor.Wait(beerbelt);
                                }
                                if (beerbelt.Count < 10)
                                {
                                    beerbelt.Enqueue(bottle);
                                    Console.WriteLine("split to beer");
                                    Monitor.Pulse(beerbelt);
                                    Monitor.Pulse(combinedbelt);
                                }
                            }
                            if (combinedbelt.Count == 0)
                            {
                                Monitor.Wait(combinedbelt);
                            }
                        }
                    }
                }
            }
        }

        static void BeerConsumer()
        {
            Bottle bottle;
            lock (beerbelt)
            {
                while (true)
                {
                    Monitor.Wait(beerbelt);
                    bottle = beerbelt.Dequeue();
                    Console.WriteLine("Beerconsumer took a " + bottle.GetBottleContent() + " with serial number: " + bottle.GetSerialNumber());
                    Monitor.Pulse(beerbelt);
                    Thread.Sleep(2000);
                }
            }
        }


        static void SodaConsumer()
        {
            Bottle bottle;
            lock (sodabelt)
            {
                while (true)
                {
                    Monitor.Wait(sodabelt);
                    bottle = sodabelt.Dequeue();
                    Console.WriteLine("Sodaconsumer took a " + bottle.GetBottleContent() + " with serial number: " + bottle.GetSerialNumber());
                    Monitor.Pulse(sodabelt);
                    Thread.Sleep(2000);
                }
            }
        }
    }
}