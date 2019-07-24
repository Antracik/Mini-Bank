using Mini_Bank.Models.ViewModels;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Mini_Bank.Models.Repository;
using System.Linq;

namespace Mini_Bank.Models
{
    [DataContract]
    public class RegistrantModel : IBaseModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Country { get; set; }

        [DataMember]
        public string Address { get; set; }

        //RELATION
        [DataMember]
        public int UserId { get; set; }

        public RegistrantModel(int id, string name, string country, string address, int userId)
        {
            Id = id;
            Name = name;
            Country = country;
            Address = address;
            UserId = userId;
        }

        //FOR LATER USE
        //public List<WalletModel> Wallets{ get; set; }

        //public RegistrantModel(int id, string name, string country, string address, List<WalletModel> wallets)
        //{
        //    Id = id;
        //    Name = name;
        //    Country = country;
        //    Address = address;
        //    Wallets = wallets;
        //}


    }

    public static class WalletExtension
    {
        public static IEnumerable<WalletModel> GetRegistrantWallets(this RegistrantModel source)
        {
            return from wallets in new FileRepository<WalletModel>().Read()
                    where wallets.ReginstrantId == source.Id
                    select wallets;
            
            //return FileRepository<WalletModel>.Read().Where(w => w.ReginstrantId == source.Id).ToList();
        }
    }
}
