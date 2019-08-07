using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mini_Bank.DbRepo;
using Mini_Bank.Models.EnumModels;

namespace Mini_Bank.Services
{
    public class NomenclatureService : INomenclatureService
    {
        private readonly UnitOfWork _unitOfWork;

        public NomenclatureService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<CountryModel> GetCountries()
        {
            _unitOfWork.Add<CountryModel>();
            
            var countries = _unitOfWork.GetRepository<CountryModel>().Get().ToList();
            
            return countries;
        }

        public IEnumerable<CurrencyModel> GetCurrencies()
        {
            _unitOfWork.Add<CurrencyModel>();
            
            var currencies = _unitOfWork.GetRepository<CurrencyModel>().Get().ToList();

            return currencies;
        }

        public IEnumerable<StatusModel> GetStatuses()
        {
            _unitOfWork.Add<StatusModel>();
            
            var statusses = _unitOfWork.GetRepository<StatusModel>().Get().ToList();
            

            return statusses;
        }
    }
}
