namespace CodMwStats.AccountLogic.ServerAccounts
{
    public class ServerAccount
    {
        public string ServerName { get; set; }

        public ulong ID { get; set; }

        public string Prefix { get; set; }

        public string Joined { get; set; }

        public int MemberCount { get; set; }
    }
}
