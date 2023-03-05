using System;

namespace PaymentTerminal
{

    class MainClass
    {
        public static void Main(string[] args)
        {
            Person debitCardHolder = new Person(Guid.NewGuid(), "YURII", "BIELIKOV", DateTime.Now);
            Person creditCardHolder = new Person(Guid.NewGuid(), "A", "B", DateTime.Now);
            ICard testDebitCard = new DebitCard("4149 2222 5555 7821", 323, 1488, debitCardHolder, 1000, new DateTime(2025, 11, 28));
            ICard testCreditCard = new CreditCard("4149 2222 5555 7822", 324, 1489, creditCardHolder, 200, 1000, new DateTime(2025, 11, 28));

            IPaymentTerminal paymentTerminal = new ShopPaymentTerminal();

            paymentTerminal.EnterPriceToPay(200);
            paymentTerminal.EnterCardPinCode(1488);
            paymentTerminal.WithDrawMoneyFrom(testDebitCard);
            Console.WriteLine($"Debit card balance is {testDebitCard.GetBalance()}");

            paymentTerminal.EnterPriceToPay(250);
            paymentTerminal.EnterCardPinCode(1489);
            paymentTerminal.WithDrawMoneyFrom(testCreditCard);
            Console.WriteLine($"Credit card balance is {testCreditCard.GetBalance()}");
            testCreditCard.AddToAccount(250);
            Console.WriteLine($"Credit card balance is {testCreditCard.GetBalance()}");

            Console.ReadKey();
        }
    }
}
