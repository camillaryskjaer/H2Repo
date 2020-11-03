using MyBanker.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyBanker.Cards
{
    public abstract class Card : ICard
    {
        private string _cardHolder;
        private string _cardNumber;
        private DateTime _cardExpireDate;
        private string _accountNumber;

        public Card(string CardHolder, string CardNumber, DateTime CardExpireDate, string AccountNumber)
        {
            _cardHolder = CardHolder;
            _cardNumber = CardNumber;
            _cardExpireDate = CardExpireDate;
            _accountNumber = AccountNumber;
        }

        public string AccountNumber
        {
            get { return _accountNumber; }
            private set { _accountNumber = value; }
        }

        public DateTime CardExpireDate
        {
            get { return _cardExpireDate; }
            private set { _cardExpireDate = value; }
        }

        public string CardNumber
        {
            get { return _cardNumber; }
            private set { _cardNumber = value; }
        }

        public string CardHolder
        {
            get { return _cardHolder; }
            private set { _cardHolder = value; }
        }

        public void Deposit()
        {
            throw new NotImplementedException();
        }

        public void Withdraw()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            string cardClassType = this.GetType().ToString();
            string cardType = cardClassType.Split('.').Last();

            string cardInfo = "Card type: " + cardType + Environment.NewLine + "Card holder: " + this.CardHolder + Environment.NewLine + "Card number: " + this.CardNumber + Environment.NewLine
                + "Expiry date: " + this.CardExpireDate +Environment.NewLine + "Account number: " + this.AccountNumber;
            return cardInfo;
        }
    }
}
