﻿using Services.Models;
using System.Collections.Generic;

namespace Services.Services
{
    public interface INomenclatureService
    {
        IEnumerable<CountryServiceModel> GetCountries();
        IEnumerable<CurrencyServiceModel> GetCurrencies();
        IEnumerable<StatusServiceModel> GetStatuses();
        IEnumerable<FinancialTransactionTypeServiceModel> GetFinancialTransactionTypes();
        IEnumerable<TicketTypeServiceModel> GetTicketTypes();
        IEnumerable<TicketStatusServiceModel> GetTicketStatuses();

    }
}
