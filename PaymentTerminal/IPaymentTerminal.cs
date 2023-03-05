using System;
namespace PaymentTerminal
{
    internal interface IPaymentTerminal
    {
        void EnterPriceToPay(Double price);
        void EnterCardPinCode(int pinCode);
        void ResetPrice();
        void ResetPin();
        void CancelPayment();
        void WithDrawMoneyFrom(ICard card);
    }
}
