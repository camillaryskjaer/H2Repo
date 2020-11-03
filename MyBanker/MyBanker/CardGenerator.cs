using MyBanker.Cards;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBanker
{
    public class CardGenerator
    {
        Random random = new Random();
        DateTime date = DateTime.Now;
        Card card;
        public Card GenerateCard(Customer customer)
        {
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

            string cardNumber;
            string accountNumber = "3520";

            while (accountNumber.Length < 14)
            {
                accountNumber += random.Next(0, 10).ToString();
            }

            if (customer.Age < 15)
            {
                cardNumber = "2400";
                while (cardNumber.Length > 16)
                {
                    cardNumber += random.Next(0, 10).ToString();
                }
                card = new DebitCard(customer.Name, cardNumber, DateTime.MinValue, accountNumber);
            }
            else if (customer.Age >= 15 && customer.Age < 18)
            {
                cardNumber = visaElectronPrefix[random.Next(0, visaElectronPrefix.Count - 1)];
                while (cardNumber.Length > 16)
                {
                    cardNumber += random.Next(0, 10).ToString();
                }
                card = new VisaElectronCard(customer.Name, cardNumber, date.AddYears(5), accountNumber);
            }
            else
            {
                int cardType = random.Next(1, 6);
                switch (cardType)
                {
                    case 1:
                        cardNumber = "2400";
                        while (cardNumber.Length > 16)
                        {
                            cardNumber += random.Next(0, 10).ToString();
                        }
                        card = new DebitCard(customer.Name, cardNumber, DateTime.MinValue, accountNumber);
                        break;

                    case 2:
                        cardNumber = maestroPrefix[random.Next(0, maestroPrefix.Count - 1)];
                        while (cardNumber.Length > 19)
                        {
                            cardNumber += random.Next(0, 10).ToString();
                        }
                        Card maestroCard = new MaestroCard(customer.Name, cardNumber, date.AddYears(5), accountNumber);
                        break;

                    case 3:
                        cardNumber = visaElectronPrefix[random.Next(0, visaElectronPrefix.Count - 1)];
                        while (cardNumber.Length > 16)
                        {
                            cardNumber += random.Next(0, 10).ToString();
                        }
                        card = new VisaElectronCard(customer.Name, cardNumber, date.AddYears(5), accountNumber);
                        break;

                    case 4:
                        cardNumber = "4";
                        while (cardNumber.Length > 16)
                        {
                            cardNumber += random.Next(0, 10).ToString();
                        }
                        card = new VisaCard(customer.Name, cardNumber, date.AddYears(5), accountNumber);
                        break;

                    case 5:
                        cardNumber = masterCardPrefix[random.Next(0, masterCardPrefix.Count - 1)];
                        while (cardNumber.Length > 16)
                        {
                            cardNumber += random.Next(0, 10).ToString();
                        }
                        card = new MasterCard(customer.Name, cardNumber, date.AddYears(5), accountNumber);
                        break;
                }
            }
            return card;
        }
    }
}
