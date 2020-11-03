using System;
using System.Collections.Generic;
using System.Text;

namespace MyBanker.Cards
{
    public class DebitCard : Card
    {
        public DebitCard(string CardHolder, string CardNumber, DateTime CardExpireDate, string AccountNumber) : base(CardHolder, CardNumber, CardExpireDate, AccountNumber)
        {

        }
    }
}
