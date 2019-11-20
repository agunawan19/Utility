using AuthenticationServer.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Web;

namespace AuthenticationServer.App_Code.Authentication
{
    public class CustomValidator : UserNamePasswordValidator
    {
        public override void Validate(string userName, string password)
        {
            var accountModel = new AccountModel();

            if (accountModel.IsAuthenticated(userName, password)) {
                return;
            }

            throw new SecurityTokenException("Invalid account");
        }
    }
}