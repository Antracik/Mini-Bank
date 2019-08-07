using Mini_Bank.DbRepo.Entities;
using Mini_Bank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mini_Bank.Services
{
    public interface IRegistrantService
    {
        RegistrantDbRepoModel GetRegistrantById(int id, bool includeWallets = false);
        IEnumerable<RegistrantDbRepoModel> GetAllRegistrants();
        int CreateRegistrant(RegistrantModel registrant);
        void UpdateRegistrant(RegistrantModel registrant);
        int DeleteRegistrant(int id);

    }
}
