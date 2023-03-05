using System;
using System.Diagnostics.Contracts;

namespace PaymentTerminal
{
    internal class CreditCard : ICard
    {
        private String _cardNumber;
        private UInt16 _securityCode;
        private int _pinCode;
        private Person _cardHolder;
        private Double _balance;
        private Double _creditLimit;
        private Double _creditMoney;
        private DateTime _expirationDate;

        public CreditCard(String cardNumber,
                          UInt16 securityCode, 
                          int pinCode,
                          Person cardHolder,
                          Double balance,
                          Double creditLimit, 
                          DateTime expirationDate)
        {
            _cardNumber = cardNumber;
            _securityCode = securityCode;
            _pinCode = pinCode;
            _cardHolder = cardHolder;
            _balance = balance;
            _creditLimit = creditLimit;
            _creditMoney = creditLimit;
            _expirationDate = expirationDate;
        }

        public void WithDrawMoney(Double amount)
        { 
            Contract.Ensures(_balance + _creditLimit > 0, "Amount of money you can use is less than the needed");
            Contract.Ensures(Contract.OldValue(this._balance) + Contract.OldValue(this._creditMoney) == this._balance + this._creditMoney + amount, "The new balance is calculated wrongly");
            if (_balance > amount)
            {
              _balance -= amount;
            }
            else
            {
                Double difference = amount - _balance;
                _balance = 0.0;
                _creditMoney -= difference;
            }
        }

        public void AddToAccount(Double amount)
        {
            Contract.Requires(amount > 0.0, "Amount of money to add to the account must be greater that 0");
            Contract.Ensures(Contract.OldValue(this._balance) + Contract.OldValue(this._creditMoney) + amount == this._balance + this._creditMoney, "The balance on adding the money is calculated wrongly");
            if (_creditMoney < _creditLimit)
            {
                _creditMoney += amount;
                Double surplus = _creditMoney - _creditLimit;

                if ( surplus > 0)
                {
                    _creditMoney = _creditLimit;
                    _balance += surplus;
                }
            }
            else
            {
                _balance += amount;
            }
        }

        public Double GetBalance()
        {
            return _balance + _creditMoney;
        }

        public int GetPin()
        {
            return _pinCode;
        }

        [ContractInvariantMethod]
        private void ExpirationDateInvariant()
        {
            Contract.Invariant(this._expirationDate > DateTime.Now, "A violation of the card invariant. The card has expired");
        }
    }
}
