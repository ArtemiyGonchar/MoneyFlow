﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyFlow.Domain.Entities.ValueObjects
{
    /// <summary>
    /// Money is the Value Object for Transaction class, every Transaction has some amount of money that Money validates.
    /// </summary>
    public class Money
    {
        public decimal Amount { get; private set; }

        private Money() { }
        public Money(decimal amount)
        {
            if (amount < 0) throw new ArgumentOutOfRangeException(nameof(amount));
            Amount = amount;
        }
    }
}
