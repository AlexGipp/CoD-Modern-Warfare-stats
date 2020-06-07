using System.Collections.Generic;
using System.Linq;
using Discord.WebSocket;

namespace CodMwStats.AccountLogic.UserAccounts
{
    public class UserAccounts
    {
        private static List<UserAccount> _accounts;

        private static string accountsFile = "Resources/UserAccounts.json";

        public static IReadOnlyCollection<UserAccount> GetAllAccounts()
        {
            return UserAccounts._accounts.AsReadOnly();
        }

        static UserAccounts()
        {
            if (UserDataStorage.SaveExists(accountsFile))
            {
                _accounts = UserDataStorage.LoadUserAccounts(accountsFile).ToList();
            }
            else
            {
                _accounts = new List<UserAccount>();
                SaveAccounts();
            }
        }

        public static void SaveAccounts()
        {
            UserDataStorage.SaveUserAccounts(_accounts, accountsFile);
        }

        public static UserAccount GetAccount(SocketUser user)
        {
            return GetOrCreateAccount(user.Id, user.Username);
        }

        private static UserAccount GetOrCreateAccount(ulong id, string username)
        {
            var result = from a in _accounts
                where a.ID == id
                select a;

            var account = result.FirstOrDefault();
            if (account == null) account = CreateUserAccount(id, username);
            return account;
        }

        private static UserAccount CreateUserAccount(ulong id, string username)
        {
            var newAccount = new UserAccount()
            {
                ID = id,
                DiscordUsername = username,
                Platform = null,
                GameUsername = null
            };

            _accounts.Add(newAccount);
            SaveAccounts();
            return newAccount;
        }
    }
}