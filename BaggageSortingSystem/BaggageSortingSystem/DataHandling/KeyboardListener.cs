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
                        Program.checkIns.Add(checkIn);
                        t.Start();
                    }
                    else if (charInput[1] == 'g')
                    {
                        Gate gate = new Gate(int.Parse(charInput[2].ToString()));
                        Thread t = new Thread(() => gate.FillFlight());
                        Program.gates.Add(gate);
                        t.Start();
                    }
                }
                else if (charInput.Length != 0 && charInput[0] == 'c')
                {
                    if (charInput[1] == 'c')
                    {
                        CheckIn c = Program.checkIns.Find(x => x.GetCheckInNumber() == int.Parse(charInput[2].ToString()));
                        Program.checkIns.Remove(c);
                        c.Alive = false;
                    }
                    else if (charInput[1] == 'g')
                    {
                        Gate g = Program.gates.Find(x => x.GetGateNumber() == int.Parse(charInput[2].ToString()));
                        Program.gates.Remove(g);
                        g.Alive = false;
                    }
                }
            }
        }
    }
}
