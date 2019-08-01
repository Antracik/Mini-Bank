using Mini_Bank.Models.ViewModels;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mini_Bank.FileRepo.Models
{
    [DataContract]
    public class RegistrantRepoModel : IBaseModel
    {
        [DataMember]
        public int Id { get; set; }

        [Required]
        [DataMember]
        public string FirstName { get; set; }

        [Required]
        [DataMember]
        public string LastName { get; set; }

        [Required]
        [DataMember]
        public string Country { get; set; }

        [Required]
        [DataMember]
        public string Address { get; set; }

        //RELATION
        [DataMember]
        public int UserId { get; set; }

        public RegistrantRepoModel(int id, string firstName, string lastName, string country, string address, int userId)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Country = country;
            Address = address;
            UserId = userId;
        }

        public RegistrantRepoModel() {}
    }

    public static class RegistrantExtension
    {
        public static IEnumerable<WalletRepoModel> GetRegistrantWallets(this RegistrantRepoModel source, IRepository<WalletRepoModel> fileRepository)
        {
            return from wallets in fileRepository.Get()
                   where wallets.RegistrantId == source.Id
                    select wallets;
        }
    }
}
