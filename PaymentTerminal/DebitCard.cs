#define CONTRACTS_FULL

using System;
using System.Diagnostics.Contracts;

namespace PaymentTerminal
{
    internal class DebitCard : ICard
    {
        private String _cardNumber;
        private UInt16 _securityCode;
        private int _pinCode;
        private Person _cardHolder;
        private Double _balance;
        private DateTime _expirationDate;

        public DebitCard(String cardNumber,
                         UInt16 securityCode,
                         int pinCode,
                         Person cardHolder,
                         Double balance,
                         DateTime expirationDate)
        {
            _cardNumber = cardNumber;
            _securityCode = securityCode;
            _pinCode = pinCode;
            _cardHolder = cardHolder;
            _balance = balance;
            _expirationDate = expirationDate;
        }

        public void WithDrawMoney(Double amount)
        {
            Contract.Requires(amount > 0.0, "The amount of money to withdraw should be greater than 0");
            Contract.Ensures(Contract.OldValue(this._balance) == this._balance + amount, "The new balance is calculated wrongly");
            _balance -= amount;   
        }

        public void AddToAccount(Double amount)
        {
            Contract.Requires(amount > 0.0, "Amount of money you are adding should be greater than 0");
            Contract.Ensures(Contract.OldValue(this._balance) + amount == this._balance, "The new balance is calculated wrongly");
            _balance += amount;
        }

        public Double GetBalance()
        {
            return _balance;
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
