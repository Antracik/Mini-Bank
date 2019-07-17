using System;
using System.Collections.Generic;

namespace Mini_Bank.Models
{
    /// <summary>
    /// Static class used for testing. Generates nonsensical data for the supported models 
    /// </summary>
    public static class Generate
    {
        private static List<UserModel> _users = null;
        private static List<RegistrantModel> _registrants = null;
        private static List<WalletModel> _wallets = null;
        private static List<AccountModel> _accounts = null;

        public static List<AccountModel> GetAccounts()
        {
            if (_accounts != null)
                return _accounts;

            Random random = new Random();

            /// GENERATE stuff for testing purposes
            /// GENERATE Accounts if not yet generate
            _accounts = new List<AccountModel>();

            for (int i = 0; i < 3; i++)
                _accounts.Add(new AccountModel(random.Next(0, 999), "IBAN" + random.Next(), random.Next(0, 9999), (CurrencyModel.Currency)random.Next(0, 2), (StatusModel.Status)random.Next(0, 2)));

            return _accounts;
        }

        public static List<WalletModel> GetWallets()
        {
            if (_wallets != null)
                return _wallets;

            Random random = new Random();

            /// GENERATE Accounts if not yet generated
            _accounts = GetAccounts();

            /// GENERATE Wallets if not yet generated
            _wallets = new List<WalletModel>();

            for (int i = 0; i < 5; i++)
                _wallets.Add(new WalletModel(random.Next(0,9999), random.Next(0, 9999), (StatusModel.Status)random.Next(0, 2), _accounts));

            return _wallets;
        }

        public static List<RegistrantModel> GetRegistrants()
        {
            if (_registrants != null)
                return _registrants;

            Random random = new Random();
            /// GENERATE Wallets AND Accounts if not yet generated
            _wallets = GetWallets();

            /// GENERATE Registrants if not yet generated
            _registrants = new List<RegistrantModel>();

            for (int i = 0; i < 10; i++)
                _registrants.Add(new RegistrantModel(random.Next(0, 9999), "Registrant Name " + random.Next(0, 9999), "Registrant Country " + random.Next(0, 9999), "Registrant Address " + random.Next(0, 9999), _wallets));

            return _registrants;
        }

        public static List<UserModel> GetUsers()
        {
            if (_users != null)
                return _users;

            Random random = new Random();
            
            /// GENERATE Wallets AND Accounts AND Registrants if not yet generated
            _registrants = GetRegistrants();

            /// GENERATE Users if not yet generated;
            _users = new List<UserModel>();

            for (int i = 0; i < 10; i++)
                _users.Add(new UserModel(random.Next(0, 9999), "user" + i + "@domain.com", "totally a password", _registrants[i]));

            return _users;
        }
    }
}
