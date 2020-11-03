using MyBanker.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBanker.Cards
{
    public class MaestroCard : Card, INetUsable, IInternational
    {
        // uses interfaces that allows it to shop online and internationally

        // constructor for maestro card class
        public MaestroCard(string CardHolder, string CardNumber, DateTime CardExpireDate, string AccountNumber) : base(CardHolder, CardNumber, CardExpireDate, AccountNumber)
        {
        }
    }
}
