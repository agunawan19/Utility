using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.ServiceModel.Security;
using AuthenticationClient.ServiceReferenceClient;

namespace AuthenticationClient.Models
{
    public class HelloClient
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public string HelloWorld()
        {
            try
            {
                var helloClientService = new ServiceHelloClient();
                helloClientService.ClientCredentials.ServiceCertificate.Authentication.CertificateValidationMode =
                    X509CertificateValidationMode.None;
                helloClientService.ClientCredentials.UserName.UserName = UserName;
                helloClientService.ClientCredentials.UserName.Password = Password;
                return helloClientService.HelloWorld();
            }
            catch
            {
                return null;
            }
        }
    }
}