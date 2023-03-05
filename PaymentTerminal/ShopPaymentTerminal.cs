#define CONTRACTS_FULL

using System;
using System.Diagnostics.Contracts;

namespace PaymentTerminal
{
    internal class ShopPaymentTerminal : IPaymentTerminal
    {
        public Double _amountToWithDraw = 0;
        public int _cardPinCode = 0;

        public ShopPaymentTerminal()
        {

        }

        public void EnterPriceToPay(Double price)
        {
            Contract.Ensures(price > 0.0, "The price should be greater than 0");
            _amountToWithDraw = price;
        }
        
        public void EnterCardPinCode(int pinCode)
        {
            Contract.Requires(pinCode != 0, "The entered pin code does not follow specific rules");
            _cardPinCode = pinCode;
        }

        public void ResetPrice()
        {
            Contract.Ensures(this._amountToWithDraw == 0, "Entered price was not reset correctly");
            _amountToWithDraw = 0;
        }

        public void ResetPin()
        {
            Contract.Ensures(this._cardPinCode == 0, "Entered pin code was not reset correclty");
            _cardPinCode = 0;
        }

        public void CancelPayment()
        {
            Contract.Ensures(this._amountToWithDraw == 0, "Entered price was not reset correctly");
            Contract.Ensures(this._cardPinCode == 0, "Entered pin code was not reset correclty");
            _amountToWithDraw = 0;
            _cardPinCode = 0;
        }

        public void WithDrawMoneyFrom(ICard card)
        {
            Contract.Requires(card.GetPin() == _cardPinCode, "The card's pin code doesn't match with the entered one");
            Contract.Requires((card is CreditCard || card is DebitCard), "The card type is unknown");
            Contract.Requires(card.GetBalance() > _amountToWithDraw, "Amount of available money is less than needed");
            card.WithDrawMoney(_amountToWithDraw);
        }
    }
}
