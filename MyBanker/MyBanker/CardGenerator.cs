using MyBanker.Cards;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBanker
{
    public class CardGenerator
    {
        // account number generator to generate account numbers
        AccountNumberGenerator accountGenerator = new AccountNumberGenerator();

        // card number generator to generate card numbers
        CardNumberGenerator cardNumberGenerator = new CardNumberGenerator();

        // random generator to pull numbers
        Random random = new Random();

        // gets the current date
        DateTime date = DateTime.Now;

        // empty card
        Card card;

        // constructor for card class
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

            // empty card number
            string cardNumber;

            // checks on customer age due to card type restrictions
            if (customer.Age < 15)
            {
                // generates card number from prefix and length requirements
                cardNumber = cardNumberGenerator.GenerateCardNumber("2400", 16);

                // generates card
                card = new DebitCard(customer.Name, cardNumber, DateTime.MinValue, accountNumber);
            }
            else if (customer.Age >= 15 && customer.Age < 18)
            {
                // generates card number from prefix and length requirements
                cardNumber = cardNumberGenerator.GenerateCardNumber(visaElectronPrefix[random.Next(0, visaElectronPrefix.Count - 1)], 16);

                // generates card
                card = new VisaElectronCard(customer.Name, cardNumber, date.AddYears(5), accountNumber);
            }
            else
            {
                // random number for card type
                int cardType = random.Next(1, 6);

                // defines card from card number
                switch (cardType)
                {
                    case 1:
                        // generates card number from prefix and length requirements
                        cardNumber = cardNumberGenerator.GenerateCardNumber("2400", 16);

                        // generates card
                        card = new DebitCard(customer.Name, cardNumber, DateTime.MinValue, accountNumber);
                        break;

                    case 2:
                        // generates card number from prefix and length requirements
                        cardNumber = cardNumberGenerator.GenerateCardNumber(maestroPrefix[random.Next(0, maestroPrefix.Count - 1)], 19);

                        // generates card
                        card = new MaestroCard(customer.Name, cardNumber, date.AddYears(5), accountNumber);
                        break;

                    case 3:
                        // generates card number from prefix and length requirements
                        cardNumber = cardNumberGenerator.GenerateCardNumber(visaElectronPrefix[random.Next(0, visaElectronPrefix.Count - 1)], 16);

                        // generates card
                        card = new VisaElectronCard(customer.Name, cardNumber, date.AddYears(5), accountNumber);
                        break;

                    case 4:
                        // generates card number from prefix and length requirements
                        cardNumber = cardNumberGenerator.GenerateCardNumber("4", 16);

                        // generates card
                        card = new VisaCard(customer.Name, cardNumber, date.AddYears(5), accountNumber);
                        break;

                    case 5:
                        // generates card number from prefix and length requirements
                        cardNumber = cardNumberGenerator.GenerateCardNumber(masterCardPrefix[random.Next(0, masterCardPrefix.Count - 1)], 16);

                        // generates card
                        card = new MasterCard(customer.Name, cardNumber, date.AddYears(5), accountNumber);
                        break;
                }
            }
            // returns generated card
            return card;
        }
    }
}
