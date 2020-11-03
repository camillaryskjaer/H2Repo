using MyBanker.Cards;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBanker
{
    public class CardGenerator
    {
        AccountNumberGenerator accountGenerator = new AccountNumberGenerator();
        CardNumberGenerator cardNumberGenerator = new CardNumberGenerator();
        // random generator to pull numbers
        Random random = new Random();
        // gets the current date
        DateTime date = DateTime.Now;
        // empty card
        Card card;
        public Card GenerateCard(Customer customer)
        {
            #region Prefix lists
            // lists of prefixes for the different card types
            List<string> visaElectronPrefix = new List<string>()
            {
                "4026", "417500", "4508", "4844", "4913", "4917"
            };
            List<string> masterCardPrefix = new List<string>()
            {
                "51", "52", "53", "54", "55"
            };
            List<string> maestroPrefix = new List<string>()
            {
                "5018", "5020", "5038", "5893", "6304", "6759", "6761", "6762", "6763"
            };
            #endregion

            // generates a random account number with account prefix          
            string accountNumber = accountGenerator.GenerateAccountNumber("3520");

            string cardNumber;

            // checks on customer age due to card type restrictions
            if (customer.Age < 15)
            {
                cardNumber = cardNumberGenerator.GenerateCardNumber("2400", 16);
                card = new DebitCard(customer.Name, cardNumber, DateTime.MinValue, accountNumber);
            }
            else if (customer.Age >= 15 && customer.Age < 18)
            {
                cardNumber = cardNumberGenerator.GenerateCardNumber(visaElectronPrefix[random.Next(0, visaElectronPrefix.Count - 1)], 16);
                card = new VisaElectronCard(customer.Name, cardNumber, date.AddYears(5), accountNumber);
            }
            else
            {
                int cardType = random.Next(1, 6);
                switch (cardType)
                {
                    case 1:
                        cardNumber = cardNumberGenerator.GenerateCardNumber("2400", 16);
                        card = new DebitCard(customer.Name, cardNumber, DateTime.MinValue, accountNumber);
                        break;

                    case 2:
                        cardNumber = cardNumberGenerator.GenerateCardNumber(maestroPrefix[random.Next(0, maestroPrefix.Count - 1)], 19);
                        card = new MaestroCard(customer.Name, cardNumber, date.AddYears(5), accountNumber);
                        break;

                    case 3:
                        cardNumber = cardNumberGenerator.GenerateCardNumber(visaElectronPrefix[random.Next(0, visaElectronPrefix.Count - 1)], 16);
                        card = new VisaElectronCard(customer.Name, cardNumber, date.AddYears(5), accountNumber);
                        break;

                    case 4:
                        cardNumber = cardNumberGenerator.GenerateCardNumber("4", 16);
                        card = new VisaCard(customer.Name, cardNumber, date.AddYears(5), accountNumber);
                        break;

                    case 5:
                        cardNumber = cardNumberGenerator.GenerateCardNumber(masterCardPrefix[random.Next(0, masterCardPrefix.Count - 1)], 16);
                        card = new MasterCard(customer.Name, cardNumber, date.AddYears(5), accountNumber);
                        break;
                }
            }
            return card;
        }
    }
}
