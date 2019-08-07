using Mini_Bank.Models.EnumModels;
using System.Collections.Generic;

namespace Mini_Bank.Services
{
    public interface INomenclatureService
    {
        IEnumerable<CountryModel> GetCountries();
        IEnumerable<CurrencyModel> GetCurrencies();
        IEnumerable<StatusModel> GetStatuses();
    }
}
