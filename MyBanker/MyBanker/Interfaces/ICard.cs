using System;
using System.Collections.Generic;
using System.Text;

namespace MyBanker.Interfaces
{
    interface ICard
    {
        // interface to allowd cards to withdraw and deposit money
        public void Withdraw();
        public void Deposit();
    }
}
