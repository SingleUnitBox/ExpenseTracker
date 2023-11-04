using ExpenseTracker.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Domain.Aggregates.ExpenseAggregates
{
    public sealed class Currency : Enumeration
    {
        public static readonly Currency Pln = new Currency(0, "Polish Zloty", "PLN");
        public static readonly Currency GBP = new Currency(1, "Pound Sterling", "£");
        public string Symbol { get; set; }
        public Currency(int value, string name, string symbol) : base(value, name)
        {
            Symbol = symbol;
        }
    }
}
