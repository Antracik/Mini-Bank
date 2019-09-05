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
            _unitOfWork.Add<CountryEntityModel>();
            
            var countriesRepoModel = _unitOfWork.GetRepository<CountryEntityModel>().Get().ToList();

            var countriesServiceModel = _mapper.Map<List<CountryServiceModel>>(countriesRepoModel);

            return countriesServiceModel;
        }

        public IEnumerable<CurrencyServiceModel> GetCurrencies()
        {
            _unitOfWork.Add<CurrencyEntityModel>();
            
            var currenciesRepoModel = _unitOfWork.GetRepository<CurrencyEntityModel>().Get().ToList();

            var currenciesServiceModel = _mapper.Map<List<CurrencyServiceModel>>(currenciesRepoModel);

            return currenciesServiceModel;
        }

        public IEnumerable<StatusServiceModel> GetStatuses()
        {
            _unitOfWork.Add<StatusEntityModel>();
            
            var statussesRepoModel = _unitOfWork.GetRepository<StatusEntityModel>().Get().ToList();

            var statussesServiceModel = _mapper.Map<List<StatusServiceModel>>(statussesRepoModel);

            return statussesServiceModel;
        }
    }
}
