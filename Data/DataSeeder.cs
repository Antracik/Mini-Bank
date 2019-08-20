using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data
{ 
    public class DataSeeder
    {
        private readonly BankContext _bankContext;

        public DataSeeder(BankContext bankContext)
        {
            _bankContext = bankContext;
        }

        public void SeedDatabase()
        {
            if(!_bankContext.Countries.Any())
            {
                var countries = new List<CountryDbRepoModel>
                {
                    new CountryDbRepoModel { Name = CountryEnum.Countries.Bulgaria.ToString() },
                    new CountryDbRepoModel { Name = CountryEnum.Countries.Romania.ToString()},
                    new CountryDbRepoModel { Name = CountryEnum.Countries.Germany.ToString()},
                    new CountryDbRepoModel { Name = CountryEnum.Countries.Greece.ToString()},
                    new CountryDbRepoModel { Name = CountryEnum.Countries.England.ToString()},
                    new CountryDbRepoModel { Name = CountryEnum.Countries.France.ToString()},
                    new CountryDbRepoModel { Name = CountryEnum.Countries.Italy.ToString()}
                };

                _bankContext.Countries.AddRange(countries);
                _bankContext.SaveChanges();
            }
           
            if(!_bankContext.Status.Any())
            {
                var statuses = new List<StatusDbRepoModel>
                {
                    new StatusDbRepoModel {Name = StatusEnum.Status.Okay.ToString()},
                    new StatusDbRepoModel {Name = StatusEnum.Status.Blocked.ToString()}
                };

                _bankContext.Status.AddRange(statuses);
                _bankContext.SaveChanges();
            }

            if(!_bankContext.Currency.Any())
            {
                var currencies = new List<CurrencyDbRepoModel>
                {
                    new CurrencyDbRepoModel { Name = CurrencyEnum.Currency.BGN.ToString()},
                    new CurrencyDbRepoModel { Name = CurrencyEnum.Currency.USD.ToString()},
                    new CurrencyDbRepoModel { Name = CurrencyEnum.Currency.GBP.ToString()}
                };

                _bankContext.Currency.AddRange(currencies);
                _bankContext.SaveChanges();
            }

            if(!_bankContext.Users.Any())
            {
                var users = new List<UserDbRepoModel>
                {
                    new UserDbRepoModel { Email = "preslav.miroslavov@gmail.com",  IsAdmin = true , DateCreated = DateTime.Now},
                    new UserDbRepoModel { Email = "stefan.dimitrov@abv.bg",  IsAdmin = false , DateCreated = DateTime.Now},
                    new UserDbRepoModel { Email = "petar.marchev@mail.bg",  IsAdmin = false , DateCreated = DateTime.Now}
                };

                using (var transaction = _bankContext.Database.BeginTransaction())
                {
                    _bankContext.Users.AddRange(users);
                    //_bankContext.Database.ExecuteSqlCommand(@"SET IDENTITY_INSERT [User] ON;");
                    _bankContext.SaveChanges();
                    _bankContext.Database.ExecuteSqlCommand(@"SET IDENTITY_INSERT [dbo].[User] OFF;");
                    transaction.Commit();
                }
            }

            if(!_bankContext.Registrants.Any())
            {
                var registrants = new List<RegistrantDbRepoModel>
                {
                    new RegistrantDbRepoModel {FirstName = "Preslav", LastName = "Panayotov", Country = (int)CountryEnum.Countries.Bulgaria, Address = "ul. Street 42", UserId = 1  , DateCreated = DateTime.Now},
                    new RegistrantDbRepoModel {FirstName = "Stefan", LastName = "Dimitrov", Country = (int)CountryEnum.Countries.Germany, Address = "8-mi Primorski", UserId = 2  , DateCreated = DateTime.Now},
                    new RegistrantDbRepoModel {FirstName = "Petar", LastName = "Marchev", Country = (int)CountryEnum.Countries.France, Address = "Liberman 12", UserId = 3  , DateCreated = DateTime.Now}
                };

                using (var transaction = _bankContext.Database.BeginTransaction())
                {
                    _bankContext.Registrants.AddRange(registrants);
                    //_bankContext.Database.ExecuteSqlCommand(@"SET IDENTITY_INSERT [dbo].[Registrant] ON;");
                    _bankContext.SaveChanges();
                    _bankContext.Database.ExecuteSqlCommand(@"SET IDENTITY_INSERT [dbo].[Registrant] OFF;");

                    transaction.Commit();
                }
            }

            if(!_bankContext.Wallets.Any())
            {
                var wallets = new List<WalletDbRepoModel>
                {
                    new WalletDbRepoModel {Number = 4188, RegistrantId = 1, IsVerified = true, WalletStatusId = (int)StatusEnum.Status.Okay  , DateCreated = DateTime.Now},
                    new WalletDbRepoModel {Number = 948, RegistrantId = 1, IsVerified = false, WalletStatusId = (int)StatusEnum.Status.Okay , DateCreated = DateTime.Now},
                    new WalletDbRepoModel {Number = 9809, RegistrantId = 1, IsVerified = false, WalletStatusId = (int)StatusEnum.Status.Okay , DateCreated = DateTime.Now},
                    new WalletDbRepoModel {Number = 9458, RegistrantId = 2, IsVerified = true, WalletStatusId = (int)StatusEnum.Status.Blocked , DateCreated = DateTime.Now},
                    new WalletDbRepoModel {Number = 1889, RegistrantId = 2, IsVerified = true, WalletStatusId = (int)StatusEnum.Status.Okay , DateCreated = DateTime.Now},
                    new WalletDbRepoModel {Number = 6703, RegistrantId = 2, IsVerified = false, WalletStatusId = (int)StatusEnum.Status.Blocked , DateCreated = DateTime.Now},
                    new WalletDbRepoModel {Number = 9890, RegistrantId = 3, IsVerified = true, WalletStatusId = (int)StatusEnum.Status.Okay , DateCreated = DateTime.Now},
                    new WalletDbRepoModel {Number = 1018, RegistrantId = 3, IsVerified = false, WalletStatusId = (int)StatusEnum.Status.Okay , DateCreated = DateTime.Now},
                    new WalletDbRepoModel {Number = 9066, RegistrantId = 3, IsVerified = true, WalletStatusId = (int)StatusEnum.Status.Blocked , DateCreated = DateTime.Now},
                };

                using (var transaction = _bankContext.Database.BeginTransaction())
                {
                    _bankContext.Wallets.AddRange(wallets);
                   // _bankContext.Database.ExecuteSqlCommand(@"SET IDENTITY_INSERT [dbo].[Wallet] ON;");
                    _bankContext.SaveChanges();
                    _bankContext.Database.ExecuteSqlCommand(@"SET IDENTITY_INSERT [dbo].[Wallet] OFF;");

                    transaction.Commit();
                }
            }

            if(!_bankContext.Accounts.Any())
            {
                var accounts = new List<AccountDbRepoModel>
                {
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 1, IBAN = "BG27TTBB94008486163628"  , DateCreated = DateTime.Now},
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Blocked, CurrencyId = (int)CurrencyEnum.Currency.GBP, WalletId = 1, IBAN = "BG77TTBB94006739924496" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 1, IBAN = "BG82BNPA94402678339673" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, CurrencyId = (int)CurrencyEnum.Currency.GBP, WalletId = 2, IBAN = "BG11TTBB94009636993256" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, CurrencyId = (int)CurrencyEnum.Currency.USD, WalletId = 2, IBAN = "BG84IORT80944383911889" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Blocked, CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 2, IBAN = "BG30STSA93001743638279" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 3, IBAN = "BG61TTBB94002569752388" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, CurrencyId = (int)CurrencyEnum.Currency.GBP, WalletId = 3, IBAN = "BG79BNPA94401326493795" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, CurrencyId = (int)CurrencyEnum.Currency.USD, WalletId = 3, IBAN = "BG71BNPA94403364212612" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 4, IBAN = "BE98798249248593" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Blocked, CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 4, IBAN = "BE39519894248419" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, CurrencyId = (int)CurrencyEnum.Currency.GBP, WalletId = 4, IBAN = "BE51999467219162" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 5, IBAN = "BE27812249819173" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Blocked, CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 5, IBAN = "BE86549411157550" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Blocked, CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 5, IBAN = "BE45999614884989" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, CurrencyId = (int)CurrencyEnum.Currency.GBP, WalletId = 6, IBAN = "BE08735678488413" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 6, IBAN = "BE80978224831777" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Blocked, CurrencyId = (int)CurrencyEnum.Currency.GBP, WalletId = 6, IBAN = "BE59549568634626" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, CurrencyId = (int)CurrencyEnum.Currency.GBP, WalletId = 7, IBAN = "DE73500105172747763277" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, CurrencyId = (int)CurrencyEnum.Currency.USD, WalletId = 7, IBAN = "DE73500105175222722351" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 7, IBAN = "DE19500105179421415465" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Blocked, CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 8, IBAN = "DE09500105171626724371" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 8, IBAN = "DE85500105175574577219" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, CurrencyId = (int)CurrencyEnum.Currency.GBP, WalletId = 8, IBAN = "DE66500105177765152229" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, CurrencyId = (int)CurrencyEnum.Currency.USD, WalletId = 9, IBAN = "DE69500105171238446744" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 9, IBAN = "DE69500105171238446744" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 9, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                };
                using (var transaction = _bankContext.Database.BeginTransaction())
                {
                    _bankContext.Accounts.AddRange(accounts);
                    //_bankContext.Database.ExecuteSqlCommand(@"SET IDENTITY_INSERT [dbo].[Account] ON;");
                    _bankContext.SaveChanges();
                    _bankContext.Database.ExecuteSqlCommand(@"SET IDENTITY_INSERT [dbo].[User] OFF;");

                    transaction.Commit();
                }
            }
        }
    }
}
