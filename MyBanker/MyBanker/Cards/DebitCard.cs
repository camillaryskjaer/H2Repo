using System;
using System.Collections.Generic;
using System.Text;

namespace MyBanker.Cards
{
    public class DebitCard : Card
    {
        // uses no interfaces additional interfaces

        // constructor for debit card class
        public DebitCard(string CardHolder, string CardNumber, DateTime CardExpireDate, string AccountNumber) : base(CardHolder, CardNumber, CardExpireDate, AccountNumber)
        {

        }
    }
}
