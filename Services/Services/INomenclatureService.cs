using System.Collections.Generic;

namespace Services.Models
{
    public interface INomenclatureService
    {
        IEnumerable<CountryServiceModel> GetCountries();
        IEnumerable<CurrencyServiceModel> GetCurrencies();
        IEnumerable<StatusServiceModel> GetStatuses();
    }
}
