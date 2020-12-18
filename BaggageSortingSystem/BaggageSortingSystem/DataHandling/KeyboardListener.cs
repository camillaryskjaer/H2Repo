using BaggageSortingSystem.DataConsumers;
using BaggageSortingSystem.DataProducers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace BaggageSortingSystem.DataHandling
{
    public class KeyboardListener
    {
        public void Listen()
        {
            // thread method
            while (true)
            {
                string input = Console.ReadLine();

                char[] charInput = input.ToCharArray();
                if (charInput.Length != 0 && charInput[0] == 'o')
                {
                    if (charInput[1] == 'c')
                    {
                        CheckIn checkIn = new CheckIn(int.Parse(charInput[2].ToString()));
                        Thread t = new Thread(() => checkIn.Produce());
                        t.Name = charInput[2].ToString();
                        Program.checkIns.Add(t);
                        t.Start();
                    }
                    else if (charInput[1] == 'g')
                    {
                        Gate gate = new Gate(int.Parse(charInput[2].ToString()));
                        Thread t = new Thread(() => gate.FillFlight());
                        Program.gates.Add(t);
                        t.Start();
                    }
                }
                else if (charInput.Length != 0 && charInput[0] == 'c')
                {
                    if (charInput[1] == 'c')
                    {
                        Thread t = Program.checkIns.Find(x => x.Name == charInput[2].ToString());
                        Program.checkIns.Remove(t);
                        t.Abort();
                    }
                }
            }
        }
    }
}
