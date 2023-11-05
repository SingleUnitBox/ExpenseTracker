using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTracker.Application.Infrastructure
{
    public static class Check
    {
        public static void NotNull(object arg, string argName)
        {
            if (arg == null)
            {
                throw new ArgumentNullException(argName);
            }
        }
        public static void NotNullOrEmpty<T>(IEnumerable<T> arg, string argName)
        {
            if (arg == null) 
            {
                throw new ArgumentNullException(argName);
            }
        }

        public static void NotNullOrEmpty(string arg, string argName)
        {
            if (string.IsNullOrWhiteSpace(arg))
            {
                throw new ArgumentNullException(argName);
            }
        }

        public static void GreaterThan(int lowerBound, int arg, string argName)
        {
            if (arg <= lowerBound)
            {
                throw new ArgumentOutOfRangeException(argName);
            }
        }

        public static void StartDatePrecedesEndDate(DateTime startDate, DateTime endDate)
        {
            if (startDate > endDate)
            {
                throw new ArgumentOutOfRangeException(nameof(startDate));
            }
        }

        public static void NotEmpty(Guid arg, string argName)
        {
            if (arg == Guid.Empty)
            {
                throw new ArgumentException(argName);
            }
        }
    }
}
