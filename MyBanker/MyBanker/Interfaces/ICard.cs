using System;
using System.Collections.Generic;
using System.Text;

namespace MyBanker.Interfaces
{
    interface ICard
    {
        public void Withdraw();
        public void Deposit();
    }
}
