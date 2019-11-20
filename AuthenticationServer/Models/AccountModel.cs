using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuthenticationServer.Models
{
    public class AccountModel
    {
        private readonly List<Account> accounts = new List<Account>();

        public AccountModel()
        {
            accounts.Add(new Account { Username = "acc1", Password = "123" });
            accounts.Add(new Account { Username = "acc2", Password = "123" });
            accounts.Add(new Account { Username = "acc3", Password = "123" });
        }

        public bool IsAuthenticated(string username, string password)
        {
            return accounts.Any(account => account.Username.Equals(username)
                && account.Password.Equals(password));
        }
    }
}