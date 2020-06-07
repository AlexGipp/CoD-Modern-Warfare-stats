using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodMwStats.AccountLogic.ServerAccounts
{
    public static class ServerAccounts
    {
        private static  List<ServerAccount> _accounts;
        private static string _accountsFile = "Resources/ServerAccounts.json";

        public static IReadOnlyCollection<ServerAccount> GetAllAccounts()
        {
            return ServerAccounts._accounts.AsReadOnly();
        }

        static ServerAccounts()
        {
            if (ServerDataStorage.SaveExists(_accountsFile))
            {
                _accounts = ServerDataStorage.LoadServerAccounts(_accountsFile).ToList();
            }
            else
            {
                _accounts = new List<ServerAccount>();
                SaveAccounts();
            }
        }

        public static void SaveAccounts()
        {
            ServerDataStorage.SaveServerAccounts(_accounts, _accountsFile);
        }

        public static ServerAccount GetAccount(SocketGuild guild)
        {
            return GetOrCreateAccount(guild.Id, guild.Name, guild.MemberCount);
        }

        private static ServerAccount GetOrCreateAccount(ulong id, string username, int memberCount)
        {
            var result = from a in _accounts
                where a.ID == id
                select a;

            var account = result.FirstOrDefault();
            if (account == null) account = CreateUserAccount(id, username, memberCount);
            return account;
        }

        private static ServerAccount CreateUserAccount(ulong id, string username, int memberCount)
        {
            var newAccount = new ServerAccount()
            {
                ID = id,
                ServerName = username,
                Prefix = ">",
                Joined = DateTimeOffset.UtcNow.ToString("d.MM.yyyy HH:mm:ss"),
                MemberCount = memberCount
            };

            _accounts.Add(newAccount);
            SaveAccounts();
            return newAccount;
        }
    }
}
