using MyBanker.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBanker.Cards
{
    public class MasterCard : Card, INetUsable, IInternational, IDebtable
    {
        // uses interfaces that allows it to shop online, internationally and go into debt

        // constructor for master card class
        public MasterCard(string CardHolder, string CardNumber, DateTime CardExpireDate, string AccountNumber) : base(CardHolder, CardNumber, CardExpireDate, AccountNumber)
        {
        }
    }
}
