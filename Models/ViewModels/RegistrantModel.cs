using Mini_Bank.Models.ViewModels;
using System.Collections.Generic;
using System.Runtime.Serialization;

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
}
