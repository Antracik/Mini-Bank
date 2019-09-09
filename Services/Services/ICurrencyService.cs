using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Services
{
    public interface ICurrencyService
    {
        int GetCurrencyId(string currency);
        double GetExchangeRate(string from, string to);
        /// <summary>
        /// Gets the exchange rate for the specified currencies, if no exchange rate is found, then returns double.MinValue
        /// </summary>
        /// <param name="currencyIdFrom"></param>
        /// <param name="currencyIdTo"></param>
        /// <returns></returns>
        double GetExchangeRate(int currencyIdFrom, int currencyIdTo);
    }
}
