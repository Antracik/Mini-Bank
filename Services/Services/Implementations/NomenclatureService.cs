using AutoMapper;
using Data;
using Data.Entities;
using Services.Models;
using System.Collections.Generic;
using System.Linq;

namespace Services.Services.Implementations
{
    public class NomenclatureService : INomenclatureService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public NomenclatureService(UnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<CountryServiceModel> GetCountries()
        {
            _unitOfWork.AddRepository<CountryEntityModel>();
            
            var countriesRepoModel = _unitOfWork.GetRepository<CountryEntityModel>().Get().ToList();

            var countriesServiceModel = _mapper.Map<List<CountryServiceModel>>(countriesRepoModel);

            return countriesServiceModel;
        }

        public IEnumerable<CurrencyServiceModel> GetCurrencies()
        {
            _unitOfWork.AddRepository<CurrencyEntityModel>();
            
            var currenciesRepoModel = _unitOfWork.GetRepository<CurrencyEntityModel>().Get().ToList();

            var currenciesServiceModel = _mapper.Map<List<CurrencyServiceModel>>(currenciesRepoModel);

            return currenciesServiceModel;
        }

        public IEnumerable<StatusServiceModel> GetStatuses()
        {
            _unitOfWork.AddRepository<StatusEntityModel>();
            
            var statussesRepoModel = _unitOfWork.GetRepository<StatusEntityModel>().Get().ToList();

            var statussesServiceModel = _mapper.Map<List<StatusServiceModel>>(statussesRepoModel);

            return statussesServiceModel;
        }

        public IEnumerable<FinancialTransactionTypeServiceModel> GetFinancialTransactionTypes()
        {
            _unitOfWork.AddRepository<TransactionTypeEntityModel>();

            var transactionTypes = _unitOfWork.GetRepository<TransactionTypeEntityModel>().Get().ToList();

            var transactionTypesServiceModel = _mapper.Map<List<FinancialTransactionTypeServiceModel>>(transactionTypes);

            return transactionTypesServiceModel;
        }

        public IEnumerable<TicketTypeServiceModel> GetTicketTypes()
        {
            _unitOfWork.AddRepository<TicketTypeEntityModel>();

            var ticketTypes = _unitOfWork.GetRepository<TicketTypeEntityModel>().Get();

            var ticketTypesServiceModel = _mapper.Map<List<TicketTypeServiceModel>>(ticketTypes);

            return ticketTypesServiceModel;
        }

        public IEnumerable<TicketStatusServiceModel> GetTicketStatuses()
        {
            _unitOfWork.AddRepository<TicketStatusEntityModel>();

            var ticketStatuses = _unitOfWork.GetRepository<TicketTypeEntityModel>().Get();

            var ticketStatusesServiceModel = _mapper.Map<List<TicketStatusServiceModel>>(ticketStatuses);

            return ticketStatusesServiceModel;
        }
    }
}
