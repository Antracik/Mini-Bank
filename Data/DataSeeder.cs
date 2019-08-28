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

        /// <summary>
        /// Don't put param motherOfAllSeeds to true
        /// </summary>
        /// <param name="motherOfAllSeeds"></param>
        public void SeedDatabase(bool motherOfAllSeeds = false)
        {
            if (!_bankContext.Countries.Any())
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

            if (!_bankContext.Status.Any())
            {
                var statuses = new List<StatusDbRepoModel>
                {
                    new StatusDbRepoModel {Name = StatusEnum.Status.Okay.ToString()},
                    new StatusDbRepoModel {Name = StatusEnum.Status.Blocked.ToString()}
                };

                _bankContext.Status.AddRange(statuses);
                _bankContext.SaveChanges();
            }

            if (!_bankContext.Currency.Any())
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

            if (!_bankContext.Users.Any())
            {
                var users = new List<UserDbRepoModel>
                {
                    new UserDbRepoModel { Email = "preslav.miroslavov@gmail.com", DateCreated = DateTime.Now},
                    new UserDbRepoModel { Email = "stefan.dimitrov@abv.bg", DateCreated = DateTime.Now},
                    new UserDbRepoModel { Email = "petar.marchev@mail.bg", DateCreated = DateTime.Now}
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

            if (!_bankContext.Registrants.Any())
            {
                var registrants = new List<RegistrantDbRepoModel>
                {
                    new RegistrantDbRepoModel {FirstName = "Preslav", LastName = "Panayotov", Country = (int)CountryEnum.Countries.Bulgaria, Address = "ul. Street 42", UserId = 3  , DateCreated = DateTime.Now},
                    new RegistrantDbRepoModel {FirstName = "Stefan", LastName = "Dimitrov", Country = (int)CountryEnum.Countries.Germany, Address = "8-mi Primorski", UserId = 4  , DateCreated = DateTime.Now},
                    new RegistrantDbRepoModel {FirstName = "Petar", LastName = "Marchev", Country = (int)CountryEnum.Countries.France, Address = "Liberman 12", UserId = 11  , DateCreated = DateTime.Now}
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

            if (!_bankContext.Wallets.Any())
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

            if (!_bankContext.Accounts.Any())
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
                    _bankContext.Database.ExecuteSqlCommand(@"SET IDENTITY_INSERT [dbo].[Account] OFF;");

                    transaction.Commit();
                }
            }

            //This is called a pro gamer move
            motherOfAllSeeds = false;

            if (motherOfAllSeeds)
            {
                int i = 0;
                var users = new List<UserDbRepoModel>
                {
                    new UserDbRepoModel { Email = $"test{i++}@gmail.com",AccessFailedCount = 0, EmailConfirmed = false ,PhoneNumberConfirmed = false ,LockoutEnabled = false ,TwoFactorEnabled = false, DateCreated = DateTime.Now},
                    new UserDbRepoModel { Email = $"test{i++}@gmail.com",AccessFailedCount = 0, EmailConfirmed = false ,PhoneNumberConfirmed = false ,LockoutEnabled = false ,TwoFactorEnabled = false,DateCreated = DateTime.Now},
                    new UserDbRepoModel { Email = $"test{i++}@gmail.com",AccessFailedCount = 0, EmailConfirmed = false ,PhoneNumberConfirmed = false ,LockoutEnabled = false ,TwoFactorEnabled = false,DateCreated = DateTime.Now},
                    new UserDbRepoModel { Email = $"test{i++}@gmail.com",AccessFailedCount = 0, EmailConfirmed = false ,PhoneNumberConfirmed = false ,LockoutEnabled = false ,TwoFactorEnabled = false,DateCreated = DateTime.Now},
                    new UserDbRepoModel { Email = $"test{i++}@gmail.com",AccessFailedCount = 0, EmailConfirmed = false ,PhoneNumberConfirmed = false ,LockoutEnabled = false ,TwoFactorEnabled = false,DateCreated = DateTime.Now},
                    new UserDbRepoModel { Email = $"test{i++}@gmail.com",AccessFailedCount = 0, EmailConfirmed = false ,PhoneNumberConfirmed = false ,LockoutEnabled = false ,TwoFactorEnabled = false,DateCreated = DateTime.Now},
                    new UserDbRepoModel { Email = $"test{i++}@gmail.com",AccessFailedCount = 0, EmailConfirmed = false ,PhoneNumberConfirmed = false ,LockoutEnabled = false ,TwoFactorEnabled = false,DateCreated = DateTime.Now},
                    new UserDbRepoModel { Email = $"test{i++}@gmail.com",AccessFailedCount = 0, EmailConfirmed = false ,PhoneNumberConfirmed = false ,LockoutEnabled = false ,TwoFactorEnabled = false,DateCreated = DateTime.Now},
                    new UserDbRepoModel { Email = $"test{i++}@gmail.com",AccessFailedCount = 0, EmailConfirmed = false ,PhoneNumberConfirmed = false ,LockoutEnabled = false ,TwoFactorEnabled = false,DateCreated = DateTime.Now},
                    new UserDbRepoModel { Email = $"test{i++}@gmail.com",AccessFailedCount = 0, EmailConfirmed = false ,PhoneNumberConfirmed = false ,LockoutEnabled = false ,TwoFactorEnabled = false,DateCreated = DateTime.Now},
                    new UserDbRepoModel { Email = $"test{i++}@gmail.com",AccessFailedCount = 0, EmailConfirmed = false ,PhoneNumberConfirmed = false ,LockoutEnabled = false ,TwoFactorEnabled = false,DateCreated = DateTime.Now},
                    new UserDbRepoModel { Email = $"test{i++}@gmail.com",AccessFailedCount = 0, EmailConfirmed = false ,PhoneNumberConfirmed = false ,LockoutEnabled = false ,TwoFactorEnabled = false,DateCreated = DateTime.Now},
                    new UserDbRepoModel { Email = $"test{i++}@gmail.com",AccessFailedCount = 0, EmailConfirmed = false ,PhoneNumberConfirmed = false ,LockoutEnabled = false ,TwoFactorEnabled = false,DateCreated = DateTime.Now},
                    new UserDbRepoModel { Email = $"test{i++}@gmail.com",AccessFailedCount = 0, EmailConfirmed = false ,PhoneNumberConfirmed = false ,LockoutEnabled = false ,TwoFactorEnabled = false,DateCreated = DateTime.Now},
                    new UserDbRepoModel { Email = $"test{i++}@gmail.com",AccessFailedCount = 0, EmailConfirmed = false ,PhoneNumberConfirmed = false ,LockoutEnabled = false ,TwoFactorEnabled = false,DateCreated = DateTime.Now},
                    new UserDbRepoModel { Email = $"test{i++}@gmail.com",AccessFailedCount = 0, EmailConfirmed = false ,PhoneNumberConfirmed = false ,LockoutEnabled = false ,TwoFactorEnabled = false,DateCreated = DateTime.Now},
                    new UserDbRepoModel { Email = $"test{i++}@gmail.com",AccessFailedCount = 0, EmailConfirmed = false ,PhoneNumberConfirmed = false ,LockoutEnabled = false ,TwoFactorEnabled = false,DateCreated = DateTime.Now},
                    new UserDbRepoModel { Email = $"test{i++}@gmail.com",AccessFailedCount = 0, EmailConfirmed = false ,PhoneNumberConfirmed = false ,LockoutEnabled = false ,TwoFactorEnabled = false,DateCreated = DateTime.Now},
                };

                using (var transaction = _bankContext.Database.BeginTransaction())
                {
                    _bankContext.Users.AddRange(users);
                    //_bankContext.Database.ExecuteSqlCommand(@"SET IDENTITY_INSERT [User] ON;");
                    _bankContext.SaveChanges();
                    _bankContext.Database.ExecuteSqlCommand(@"SET IDENTITY_INSERT [dbo].[AspNetUsers] OFF;");
                    transaction.Commit();
                }
            }

            if (motherOfAllSeeds)
            {
                int i = 0;
                var registrants = new List<RegistrantDbRepoModel>
                {
                    new RegistrantDbRepoModel {FirstName = $"Test{i++}", LastName = $"Test{i++}", Country = (int)CountryEnum.Countries.Bulgaria, Address = $"Test{i++}", UserId = 24  , DateCreated = DateTime.Now},
                    new RegistrantDbRepoModel {FirstName = $"Test{i++}", LastName = $"Test{i++}", Country = (int)CountryEnum.Countries.Germany, Address = $"Test{i++}",  UserId = 25  , DateCreated = DateTime.Now},
                    new RegistrantDbRepoModel {FirstName = $"Test{i++}", LastName = $"Test{i++}", Country = (int)CountryEnum.Countries.France, Address = $"Test{i++}",   UserId = 26 , DateCreated = DateTime.Now},
                    new RegistrantDbRepoModel {FirstName = $"Test{i++}", LastName = $"Test{i++}", Country = (int)CountryEnum.Countries.France, Address = $"Test{i++}",   UserId = 27 , DateCreated = DateTime.Now},
                    new RegistrantDbRepoModel {FirstName = $"Test{i++}", LastName = $"Test{i++}", Country = (int)CountryEnum.Countries.France, Address = $"Test{i++}",   UserId = 28 , DateCreated = DateTime.Now},
                    new RegistrantDbRepoModel {FirstName = $"Test{i++}", LastName = $"Test{i++}", Country = (int)CountryEnum.Countries.France, Address = $"Test{i++}",   UserId = 29 , DateCreated = DateTime.Now},
                    new RegistrantDbRepoModel {FirstName = $"Test{i++}", LastName = $"Test{i++}", Country = (int)CountryEnum.Countries.France, Address = $"Test{i++}",   UserId = 30 , DateCreated = DateTime.Now},
                    new RegistrantDbRepoModel {FirstName = $"Test{i++}", LastName = $"Test{i++}", Country = (int)CountryEnum.Countries.France, Address = $"Test{i++}",   UserId = 31 , DateCreated = DateTime.Now},
                    new RegistrantDbRepoModel {FirstName = $"Test{i++}", LastName = $"Test{i++}", Country = (int)CountryEnum.Countries.France, Address = $"Test{i++}",   UserId = 32 , DateCreated = DateTime.Now},
                    new RegistrantDbRepoModel {FirstName = $"Test{i++}", LastName = $"Test{i++}", Country = (int)CountryEnum.Countries.France, Address = $"Test{i++}",   UserId = 33 , DateCreated = DateTime.Now},
                    new RegistrantDbRepoModel {FirstName = $"Test{i++}", LastName = $"Test{i++}", Country = (int)CountryEnum.Countries.France, Address = $"Test{i++}",   UserId = 34 , DateCreated = DateTime.Now},
                    new RegistrantDbRepoModel {FirstName = $"Test{i++}", LastName = $"Test{i++}", Country = (int)CountryEnum.Countries.France, Address = $"Test{i++}",   UserId = 35 , DateCreated = DateTime.Now},
                    new RegistrantDbRepoModel {FirstName = $"Test{i++}", LastName = $"Test{i++}", Country = (int)CountryEnum.Countries.France, Address = $"Test{i++}",   UserId = 36 , DateCreated = DateTime.Now},
                    new RegistrantDbRepoModel {FirstName = $"Test{i++}", LastName = $"Test{i++}", Country = (int)CountryEnum.Countries.France, Address = $"Test{i++}",   UserId = 37 , DateCreated = DateTime.Now},
                    new RegistrantDbRepoModel {FirstName = $"Test{i++}", LastName = $"Test{i++}", Country = (int)CountryEnum.Countries.France, Address = $"Test{i++}",   UserId = 38 , DateCreated = DateTime.Now},
                    new RegistrantDbRepoModel {FirstName = $"Test{i++}", LastName = $"Test{i++}", Country = (int)CountryEnum.Countries.France, Address = $"Test{i++}",   UserId = 39 , DateCreated = DateTime.Now},
                    new RegistrantDbRepoModel {FirstName = $"Test{i++}", LastName = $"Test{i++}", Country = (int)CountryEnum.Countries.France, Address = $"Test{i++}",   UserId = 40 , DateCreated = DateTime.Now},
                    new RegistrantDbRepoModel {FirstName = $"Test{i++}", LastName = $"Test{i++}", Country = (int)CountryEnum.Countries.France, Address = $"Test{i++}",   UserId = 41 , DateCreated = DateTime.Now}
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

            if (motherOfAllSeeds)
            {
                Random rand = new Random();

                var wallets = new List<WalletDbRepoModel>
                {
                    new WalletDbRepoModel {Number = rand.Next(1000,9999), RegistrantId = 4, IsVerified = true, WalletStatusId = (int)StatusEnum.Status.Okay  , DateCreated = DateTime.Now},
                    new WalletDbRepoModel {Number = rand.Next(1000,9999), RegistrantId = 4, IsVerified = false, WalletStatusId = (int)StatusEnum.Status.Okay , DateCreated = DateTime.Now},
                    new WalletDbRepoModel {Number = rand.Next(1000,9999), RegistrantId = 4, IsVerified = false, WalletStatusId = (int)StatusEnum.Status.Okay , DateCreated = DateTime.Now},
                    new WalletDbRepoModel {Number = rand.Next(1000,9999), RegistrantId = 5, IsVerified = true, WalletStatusId = (int)StatusEnum.Status.Blocked , DateCreated = DateTime.Now},
                    new WalletDbRepoModel {Number = rand.Next(1000,9999), RegistrantId = 5, IsVerified = true, WalletStatusId = (int)StatusEnum.Status.Okay , DateCreated = DateTime.Now},
                    new WalletDbRepoModel {Number = rand.Next(1000,9999), RegistrantId = 5, IsVerified = false, WalletStatusId = (int)StatusEnum.Status.Blocked , DateCreated = DateTime.Now},
                    new WalletDbRepoModel {Number = rand.Next(1000,9999), RegistrantId = 6, IsVerified = true, WalletStatusId = (int)StatusEnum.Status.Okay , DateCreated = DateTime.Now},
                    new WalletDbRepoModel {Number = rand.Next(1000,9999), RegistrantId = 6, IsVerified = false, WalletStatusId = (int)StatusEnum.Status.Okay , DateCreated = DateTime.Now},
                    new WalletDbRepoModel {Number = rand.Next(1000,9999), RegistrantId = 6, IsVerified = true, WalletStatusId = (int)StatusEnum.Status.Blocked , DateCreated = DateTime.Now},
                    new WalletDbRepoModel {Number = rand.Next(1000,9999), RegistrantId = 7, IsVerified = true, WalletStatusId = (int)StatusEnum.Status.Blocked , DateCreated = DateTime.Now},
                    new WalletDbRepoModel {Number = rand.Next(1000,9999), RegistrantId = 7, IsVerified = true, WalletStatusId = (int)StatusEnum.Status.Blocked , DateCreated = DateTime.Now},
                    new WalletDbRepoModel {Number = rand.Next(1000,9999), RegistrantId = 7, IsVerified = true, WalletStatusId = (int)StatusEnum.Status.Blocked , DateCreated = DateTime.Now},
                    new WalletDbRepoModel {Number = rand.Next(1000,9999), RegistrantId = 8, IsVerified = true, WalletStatusId = (int)StatusEnum.Status.Blocked , DateCreated = DateTime.Now},
                    new WalletDbRepoModel {Number = rand.Next(1000,9999), RegistrantId = 8, IsVerified = true, WalletStatusId = (int)StatusEnum.Status.Blocked , DateCreated = DateTime.Now},
                    new WalletDbRepoModel {Number = rand.Next(1000,9999), RegistrantId = 8, IsVerified = true, WalletStatusId = (int)StatusEnum.Status.Blocked , DateCreated = DateTime.Now},
                    new WalletDbRepoModel {Number = rand.Next(1000,9999), RegistrantId = 9, IsVerified = true, WalletStatusId = (int)StatusEnum.Status.Blocked , DateCreated = DateTime.Now},
                    new WalletDbRepoModel {Number = rand.Next(1000,9999), RegistrantId = 9, IsVerified = true, WalletStatusId = (int)StatusEnum.Status.Blocked , DateCreated = DateTime.Now},
                    new WalletDbRepoModel {Number = rand.Next(1000,9999), RegistrantId = 9, IsVerified = true, WalletStatusId = (int)StatusEnum.Status.Blocked , DateCreated = DateTime.Now},
                    new WalletDbRepoModel {Number = rand.Next(1000,9999), RegistrantId = 10, IsVerified = true, WalletStatusId = (int)StatusEnum.Status.Blocked , DateCreated = DateTime.Now},
                    new WalletDbRepoModel {Number = rand.Next(1000,9999), RegistrantId = 10, IsVerified = true, WalletStatusId = (int)StatusEnum.Status.Blocked , DateCreated = DateTime.Now},
                    new WalletDbRepoModel {Number = rand.Next(1000,9999), RegistrantId = 10, IsVerified = true, WalletStatusId = (int)StatusEnum.Status.Blocked , DateCreated = DateTime.Now},
                    new WalletDbRepoModel {Number = rand.Next(1000,9999), RegistrantId = 11, IsVerified = true, WalletStatusId = (int)StatusEnum.Status.Blocked , DateCreated = DateTime.Now},
                    new WalletDbRepoModel {Number = rand.Next(1000,9999), RegistrantId = 11, IsVerified = true, WalletStatusId = (int)StatusEnum.Status.Blocked , DateCreated = DateTime.Now},
                    new WalletDbRepoModel {Number = rand.Next(1000,9999), RegistrantId = 11, IsVerified = true, WalletStatusId = (int)StatusEnum.Status.Blocked , DateCreated = DateTime.Now},
                    new WalletDbRepoModel {Number = rand.Next(1000,9999), RegistrantId = 12, IsVerified = true, WalletStatusId = (int)StatusEnum.Status.Blocked , DateCreated = DateTime.Now},
                    new WalletDbRepoModel {Number = rand.Next(1000,9999), RegistrantId = 12, IsVerified = true, WalletStatusId = (int)StatusEnum.Status.Blocked , DateCreated = DateTime.Now},
                    new WalletDbRepoModel {Number = rand.Next(1000,9999), RegistrantId = 12, IsVerified = true, WalletStatusId = (int)StatusEnum.Status.Blocked , DateCreated = DateTime.Now},
                    new WalletDbRepoModel {Number = rand.Next(1000,9999), RegistrantId = 13, IsVerified = true, WalletStatusId = (int)StatusEnum.Status.Blocked , DateCreated = DateTime.Now},
                    new WalletDbRepoModel {Number = rand.Next(1000,9999), RegistrantId = 13, IsVerified = true, WalletStatusId = (int)StatusEnum.Status.Blocked , DateCreated = DateTime.Now},
                    new WalletDbRepoModel {Number = rand.Next(1000,9999), RegistrantId = 13, IsVerified = true, WalletStatusId = (int)StatusEnum.Status.Blocked , DateCreated = DateTime.Now},
                    new WalletDbRepoModel {Number = rand.Next(1000,9999), RegistrantId = 14, IsVerified = true, WalletStatusId = (int)StatusEnum.Status.Blocked , DateCreated = DateTime.Now},
                    new WalletDbRepoModel {Number = rand.Next(1000,9999), RegistrantId = 14, IsVerified = true, WalletStatusId = (int)StatusEnum.Status.Blocked , DateCreated = DateTime.Now},
                    new WalletDbRepoModel {Number = rand.Next(1000,9999), RegistrantId = 14, IsVerified = true, WalletStatusId = (int)StatusEnum.Status.Blocked , DateCreated = DateTime.Now},
                    new WalletDbRepoModel {Number = rand.Next(1000,9999), RegistrantId = 15, IsVerified = true, WalletStatusId = (int)StatusEnum.Status.Blocked , DateCreated = DateTime.Now},
                    new WalletDbRepoModel {Number = rand.Next(1000,9999), RegistrantId = 15, IsVerified = true, WalletStatusId = (int)StatusEnum.Status.Blocked , DateCreated = DateTime.Now},
                    new WalletDbRepoModel {Number = rand.Next(1000,9999), RegistrantId = 15, IsVerified = true, WalletStatusId = (int)StatusEnum.Status.Blocked , DateCreated = DateTime.Now},
                    new WalletDbRepoModel {Number = rand.Next(1000,9999), RegistrantId = 16, IsVerified = true, WalletStatusId = (int)StatusEnum.Status.Blocked , DateCreated = DateTime.Now},
                    new WalletDbRepoModel {Number = rand.Next(1000,9999), RegistrantId = 16, IsVerified = true, WalletStatusId = (int)StatusEnum.Status.Blocked , DateCreated = DateTime.Now},
                    new WalletDbRepoModel {Number = rand.Next(1000,9999), RegistrantId = 16, IsVerified = true, WalletStatusId = (int)StatusEnum.Status.Blocked , DateCreated = DateTime.Now},
                    new WalletDbRepoModel {Number = rand.Next(1000,9999), RegistrantId = 17, IsVerified = true, WalletStatusId = (int)StatusEnum.Status.Blocked , DateCreated = DateTime.Now},
                    new WalletDbRepoModel {Number = rand.Next(1000,9999), RegistrantId = 17, IsVerified = true, WalletStatusId = (int)StatusEnum.Status.Blocked , DateCreated = DateTime.Now},
                    new WalletDbRepoModel {Number = rand.Next(1000,9999), RegistrantId = 17, IsVerified = true, WalletStatusId = (int)StatusEnum.Status.Blocked , DateCreated = DateTime.Now},
                    new WalletDbRepoModel {Number = rand.Next(1000,9999), RegistrantId = 18, IsVerified = true, WalletStatusId = (int)StatusEnum.Status.Blocked , DateCreated = DateTime.Now},
                    new WalletDbRepoModel {Number = rand.Next(1000,9999), RegistrantId = 18, IsVerified = true, WalletStatusId = (int)StatusEnum.Status.Blocked , DateCreated = DateTime.Now},
                    new WalletDbRepoModel {Number = rand.Next(1000,9999), RegistrantId = 18, IsVerified = true, WalletStatusId = (int)StatusEnum.Status.Blocked , DateCreated = DateTime.Now},
                    new WalletDbRepoModel {Number = rand.Next(1000,9999), RegistrantId = 19, IsVerified = true, WalletStatusId = (int)StatusEnum.Status.Blocked , DateCreated = DateTime.Now},
                    new WalletDbRepoModel {Number = rand.Next(1000,9999), RegistrantId = 19, IsVerified = true, WalletStatusId = (int)StatusEnum.Status.Blocked , DateCreated = DateTime.Now},
                    new WalletDbRepoModel {Number = rand.Next(1000,9999), RegistrantId = 19, IsVerified = true, WalletStatusId = (int)StatusEnum.Status.Blocked , DateCreated = DateTime.Now},
                    new WalletDbRepoModel {Number = rand.Next(1000,9999), RegistrantId = 20, IsVerified = true, WalletStatusId = (int)StatusEnum.Status.Blocked , DateCreated = DateTime.Now},
                    new WalletDbRepoModel {Number = rand.Next(1000,9999), RegistrantId = 20, IsVerified = true, WalletStatusId = (int)StatusEnum.Status.Blocked , DateCreated = DateTime.Now},
                    new WalletDbRepoModel {Number = rand.Next(1000,9999), RegistrantId = 20, IsVerified = true, WalletStatusId = (int)StatusEnum.Status.Blocked , DateCreated = DateTime.Now},
                    new WalletDbRepoModel {Number = rand.Next(1000,9999), RegistrantId = 21, IsVerified = true, WalletStatusId = (int)StatusEnum.Status.Blocked , DateCreated = DateTime.Now},
                    new WalletDbRepoModel {Number = rand.Next(1000,9999), RegistrantId = 21, IsVerified = true, WalletStatusId = (int)StatusEnum.Status.Blocked , DateCreated = DateTime.Now},
                    new WalletDbRepoModel {Number = rand.Next(1000,9999), RegistrantId = 21, IsVerified = true, WalletStatusId = (int)StatusEnum.Status.Blocked , DateCreated = DateTime.Now},
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

            //162
            if (motherOfAllSeeds)
            {
                Random rand = new Random();

                var accounts = new List<AccountDbRepoModel>
                {
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 10, IBAN = "BG27TTBB94008486163628"  , DateCreated = DateTime.Now},
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.GBP, WalletId = 10, IBAN = "BG77TTBB94006739924496" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 10, IBAN = "BG82BNPA94402678339673" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.GBP, WalletId = 11, IBAN = "BG11TTBB94009636993256" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.USD, WalletId = 11, IBAN = "BG84IORT80944383911889" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 11, IBAN = "BG30STSA93001743638279" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 12, IBAN = "BG61TTBB94002569752388" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.GBP, WalletId = 12, IBAN = "BG79BNPA94401326493795" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.USD, WalletId = 12, IBAN = "BG71BNPA94403364212612" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 13, IBAN = "BE98798249248593"       , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 13, IBAN = "BE39519894248419"       , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.GBP, WalletId = 13, IBAN = "BE51999467219162"       , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 14, IBAN = "BE27812249819173"       , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 14, IBAN = "BE86549411157550"       , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 14, IBAN = "BE45999614884989"       , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.GBP, WalletId = 15, IBAN = "BE08735678488413"       , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 15, IBAN = "BE80978224831777"       , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.GBP, WalletId = 15, IBAN = "BE59549568634626"       , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.GBP, WalletId = 16, IBAN = "DE73500105172747763277" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.USD, WalletId = 16, IBAN = "DE73500105175222722351" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 16, IBAN = "DE19500105179421415465" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 17, IBAN = "DE09500105171626724371" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 17, IBAN = "DE85500105175574577219" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.GBP, WalletId = 17, IBAN = "DE66500105177765152229" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.USD, WalletId = 18, IBAN = "DE69500105171238446744" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 18, IBAN = "DE69500105171238446744" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 18, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 19, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 19, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 19, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 20, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 20, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 20, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 21, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 21, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 21, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 22, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 22, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 22, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 23, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 23, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 23, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 24, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 24, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 24, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 25, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 25, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 25, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 26, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 26, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 26, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 27, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 27, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 27, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 28, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 28, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 28, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 29, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 29, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 29, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 30, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 30, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 30, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 31, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 31, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 31, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 32, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 32, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 32, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 33, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 33, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 33, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 34, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 34, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 34, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 35, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 35, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 35, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 36, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 36, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 36, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 37, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 37, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 37, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 38, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 38, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 38, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 39, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 39, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 39, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 40, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 40, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 40, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 41, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 41, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 41, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 42, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 42, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 42, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 43, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 43, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 43, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 44, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 44, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 44, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 45, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 45, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 45, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 46, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 46, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 46, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 47, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 47, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 47, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 48, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 48, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 48, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 49, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 49, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 49, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 50, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 50, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 50, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 51, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 51, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 51, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 52, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 52, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 52, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 53, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 53, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 53, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 54, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 54, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 54, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 55, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 55, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 55, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 56, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 56, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 56, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 57, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 57, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 57, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 58, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 58, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 58, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 59, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 59, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 59, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 60, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 60, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 60, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 61, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 61, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 61, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 62, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 62, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 62, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 63, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 63, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                    new AccountDbRepoModel {AccountStatusId = (int)StatusEnum.Status.Okay, Balance  = rand.Next(1,9999),CurrencyId = (int)CurrencyEnum.Currency.BGN, WalletId = 63, IBAN = "DE42500105173178734641" , DateCreated = DateTime.Now },
                };
                using (var transaction = _bankContext.Database.BeginTransaction())
                {
                    _bankContext.Accounts.AddRange(accounts);
                    //_bankContext.Database.ExecuteSqlCommand(@"SET IDENTITY_INSERT [dbo].[Account] ON;");
                    _bankContext.SaveChanges();
                    _bankContext.Database.ExecuteSqlCommand(@"SET IDENTITY_INSERT [dbo].[Account] OFF;");

                    transaction.Commit();
                }
            }
        }
    }
}
