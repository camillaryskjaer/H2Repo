using MyBanker.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBanker.Cards
{
    public class VisaElectronCard : Card, INetUsable, IInternational
    {
        // uses interfaces that allows it to shop online and internationally

        // constructor for visa electron card class
        public VisaElectronCard(string CardHolder, string CardNumber, DateTime CardExpireDate, string AccountNumber) : base(CardHolder, CardNumber, CardExpireDate, AccountNumber)
        {
        }
    }
}
