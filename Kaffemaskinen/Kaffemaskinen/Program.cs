using Kaffemaskinen.ErrorMsg;
using Kaffemaskinen.Machines;
using Kaffemaskinen.Machines.Accessories;
using Kaffemaskinen.Powders;
using System;
using System.Threading;

namespace Kaffemaskinen
{
    class Program
    {
        static ErrorMessages error = new ErrorMessages();
        static void Main(string[] args)
        {
            Console.WriteLine("Unpacking new coffee machine");
            Machine coffeeMachine = new CoffeeMachine("Nespresso");
            Pot pot = new Pot(10);
            FilterHolder holder = new FilterHolder(12);
            Thread.Sleep(1000);
            Console.WriteLine("Opening filter package");
            Filter filter = new Filter(12);

            Thread.Sleep(1000);
            Console.Clear();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Press 1 for power options");
                Console.WriteLine("Press 2 for pot options");
                Console.WriteLine("Press 3 for filterholder options");
                Console.WriteLine("Press 4 to order new parts");

                switch (int.Parse(Console.ReadLine()))
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Press 1 to check power");
                        Console.WriteLine("Press 2 to turn power on");
                        Console.WriteLine("Press 3 to turn power off");
                        switch (int.Parse(Console.ReadLine()))
                        {
                            case 1:
                                Console.WriteLine(((CoffeeMachine)coffeeMachine).CheckPower());
                                Thread.Sleep(1000);
                                break;
                            case 2:
                                ((CoffeeMachine)coffeeMachine).PowerOn();
                                break;
                            case 3:
                                ((CoffeeMachine)coffeeMachine).PowerOff();
                                break;
                            default:
                                Console.WriteLine(error.Message(ErrorTypes.Input));
                                Thread.Sleep(1000);
                                break;
                        }
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Press 1 to check pot size");
                        Console.WriteLine("Press 2 to add water to the pot");
                        Console.WriteLine("Press 3 to add water to the coffee machine");
                        Console.WriteLine("Press 4 to pour content into a cup");
                        Console.WriteLine("Press 5 to empty the pot into the sink");
                        Console.WriteLine("Press 6 to add pot to coffee machine");
                        Console.WriteLine("Press 7 to remove pot from coffee machine");
                        switch (int.Parse(Console.ReadLine()))
                        {
                            case 1:
                                Console.Clear();
                                Console.WriteLine("the pot can hold {0} cups", pot.CupSize);
                                Thread.Sleep(1000);
                                break;
                            case 2:
                                Console.Clear();
                                Console.WriteLine("Enter amount of water to add to the pot");
                                if (!pot.AddContent(double.Parse(Console.ReadLine()), "Water"))
                                {
                                    Console.WriteLine(error.Message((ErrorTypes.TooMuchContent)));
                                    Thread.Sleep(1000);
                                }
                                break;
                            case 3:
                                Console.Clear();
                                Console.WriteLine("Enter amount of water to add to the coffee machine");
                                ((CoffeeMachine)coffeeMachine).AddWater(pot, double.Parse(Console.ReadLine()));
                                break;
                            case 4:
                                Console.Clear();
                                Console.WriteLine("You got {0} cup {1}", pot.PourContent(1), pot.Content);
                                Thread.Sleep(1000);
                                break;
                            case 5:
                                Console.Clear();
                                Console.WriteLine("You poured {0} cups of {1} into the sink", pot.PourContent(pot.CupSize), pot.Content);
                                Thread.Sleep(1000);
                                break;
                            case 6:
                                ((CoffeeMachine)coffeeMachine).AddPot(pot);
                                break;
                            case 7:
                                pot = ((CoffeeMachine)coffeeMachine).RemovePot();
                                break;
                            default:
                                Console.WriteLine(error.Message(ErrorTypes.Input));
                                Thread.Sleep(1000);
                                break;
                        }
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Press 1 to check filterholder size");
                        Console.WriteLine("Press 2 to check filter size");
                        Console.WriteLine("Press 3 to add filter");
                        Console.WriteLine("Press 4 check filter for content");
                        Console.WriteLine("Press 5 to add content to filter");
                        Console.WriteLine("Press 6 to remove filter from filterholder");
                        Console.WriteLine("Press 7 to remove filterholder from coffee machine");
                        Console.WriteLine("Press 8 to add filterholder to coffee machine");
                        switch (int.Parse(Console.ReadLine()))
                        {
                            case 1:
                                Console.Clear();
                                Console.WriteLine("Size is {0}", holder.CheckSize());
                                Thread.Sleep(1000);
                                break;
                            case 2:
                                Console.Clear();
                                Console.WriteLine("Size is {0}", holder.Filter.CheckSize());
                                Thread.Sleep(1000);
                                break;
                            case 3:
                                Console.Clear();
                                holder.AddFilter(filter);
                                break;
                            case 4:
                                Console.Clear();
                                Console.WriteLine("Filter content is : {0}", holder.Filter.Content);
                                Thread.Sleep(1000);
                                break;
                            case 5:
                                Console.WriteLine("Press 1 for coffee");
                                Console.WriteLine("Press 2 for tea");
                                switch (int.Parse(Console.ReadLine()))
                                {
                                    case 1:
                                        Console.Clear();
                                        holder.Filter.AddContent(new Coffee("Gevalia"));
                                        break;
                                    case 2:
                                        Console.Clear();
                                        holder.Filter.AddContent(new Tea("Strawberry"));
                                        break;
                                    default:
                                        break;
                                }
                                break;
                            case 6:
                                holder.RemoveFilter();
                                break;
                            case 7:
                                holder = ((CoffeeMachine)coffeeMachine).RemoveFilterHolder();
                                break;
                            case 8:
                                ((CoffeeMachine)coffeeMachine).AddFilterHolder(holder);
                                break;
                            default:
                                Console.WriteLine(error.Message(ErrorTypes.Input));
                                break;
                        }
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("Press 1 for new pot");
                        Console.WriteLine("Press 2 for new filterholder");
                        Console.WriteLine("Press 3 for new filters");
                        switch (int.Parse(Console.ReadLine()))
                        {
                            case 1:
                                Console.Clear();
                                Console.WriteLine("Enter cupsize of new pot");
                                pot = new Pot(double.Parse(Console.ReadLine()));
                                break;
                            case 2:
                                Console.Clear();
                                Console.WriteLine("Enter new filterholder size");
                                holder = new FilterHolder(double.Parse(Console.ReadLine()));
                                break;
                            case 3:
                                Console.Clear();
                                Console.WriteLine("Enter new filter size");
                                filter = new Filter(double.Parse(Console.ReadLine()));
                                break;
                            default:
                                Console.WriteLine(error.Message(ErrorTypes.Input));
                                break;
                        }
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine(error.Message(ErrorTypes.Input));
                        Thread.Sleep(1000);
                        break;
                }
            }
        }
    }
}
