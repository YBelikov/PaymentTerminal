using System;

namespace PaymentTerminal
{
    internal interface ICard
    {
        void WithDrawMoney(Double prices);
        void AddToAccount(Double amount);
        Double GetBalance();
        int GetPin();
    }
}
