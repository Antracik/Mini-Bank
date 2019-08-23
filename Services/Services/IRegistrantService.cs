using Services.Models;
using System.Collections.Generic;

namespace Services.Services
{
    public interface IRegistrantService
    {
        RegistrantServiceModel GetRegistrantById(int id, bool includeWallets = false);
        IEnumerable<RegistrantServiceModel> GetAllRegistrants();
        int CreateRegistrant(RegistrantServiceModel registrant);
        void UpdateRegistrant(RegistrantServiceModel registrant);
        int DeleteRegistrant(int id);

    }
}
