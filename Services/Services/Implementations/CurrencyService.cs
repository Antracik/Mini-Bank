using Data;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Services.Services.Implementations
{
    public class CurrencyService : ICurrencyService
    {
        private readonly UnitOfWork _unitOfWork;

        public CurrencyService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public int GetCurrencyId(string currency)
        {
            return _unitOfWork.AddRepository<CurrencyEntityModel>()
                              .GetRepository<CurrencyEntityModel>()
                              .Get(x => x.Name == currency)
                              .FirstOrDefault()
                              .Id;
        }

        public double GetExchangeRate(string from, string to)
        {
            int fromId = GetCurrencyId(from);
            int toId = GetCurrencyId(to);

            return GetExchangeRate(fromId, toId);
        }

        public double GetExchangeRate(int currencyIdFrom, int currencyIdTo)
        {
            var repo = _unitOfWork.AddRepository<CurrencyExchangeEntityModel>()
                                  .GetRepository<CurrencyExchangeEntityModel>();

            var exchange = repo.Get(x => x.FromCurrencyId == currencyIdFrom && x.ToCurrencyId == currencyIdTo).FirstOrDefault();

            if (exchange != null)
                return exchange.Rate;
            else
                return double.MinValue;
        }
    }
}
