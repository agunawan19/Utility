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
        public string HelloWorld()
        {
            try
            {
                var helloClientService = new ServiceHelloClient();
                helloClientService.ClientCredentials.ServiceCertificate.Authentication.CertificateValidationMode =
                    X509CertificateValidationMode.None;
                helloClientService.ClientCredentials.UserName.UserName = "acc1";
                helloClientService.ClientCredentials.UserName.Password = "123";
                return helloClientService.HelloWorld();
            }
            catch
            {
                return null;
            }
        }
    }
}