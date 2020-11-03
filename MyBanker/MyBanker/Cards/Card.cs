using MyBanker.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyBanker.Cards
{
    public abstract class Card : ICard
    {
        // private properties
        private string _cardHolder;
        private string _cardNumber;
        private DateTime _cardExpireDate;
        private string _accountNumber;

        // constructor for card class
        public Card(string CardHolder, string CardNumber, DateTime CardExpireDate, string AccountNumber)
        {
            _cardHolder = CardHolder;
            _cardNumber = CardNumber;
            _cardExpireDate = CardExpireDate;
            _accountNumber = AccountNumber;
        }

        // method to get account number
        public string AccountNumber
        {
            get { return _accountNumber; }
            private set { _accountNumber = value; }
        }

        // method to get card expire date
        public DateTime CardExpireDate
        {
            get { return _cardExpireDate; }
            private set { _cardExpireDate = value; }
        }

        // method to get card number
        public string CardNumber
        {
            get { return _cardNumber; }
            private set { _cardNumber = value; }
        }

        // method to get card holder
        public string CardHolder
        {
            get { return _cardHolder; }
            private set { _cardHolder = value; }
        }

        // method to deposit money - not implemented
        public void Deposit()
        {
            throw new NotImplementedException();
        }

        // method to withdraw money - not implemented
        public void Withdraw()
        {
            throw new NotImplementedException();
        }

        // method to print card information - override of tostring
        public override string ToString()
        {
            string cardClassType = this.GetType().ToString();
            string cardType = cardClassType.Split('.').Last();

            string cardInfo = "Card type: " + cardType + Environment.NewLine + "Card holder: " + this.CardHolder + Environment.NewLine + "Card number: " + this.CardNumber + Environment.NewLine
                + "Expiry date: " + this.CardExpireDate.ToString("MM-yyyy") + Environment.NewLine + "Account number: " + this.AccountNumber;
            return cardInfo;
        }
    }
}
