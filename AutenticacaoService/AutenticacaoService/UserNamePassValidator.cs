using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IdentityModel.Selectors;
using System.ServiceModel;

namespace AutenticacaoService
{
    public class UserNamePassValidator : UserNamePasswordValidator
    {
        public override void Validate(string userName, string password)
        {
            if (userName == null || password == null)
            {
                throw new ArgumentException();
            }

            if (!(userName == "oi" && password == "oi"))
            {
                throw new FaultException("Incorrect username or password");
            }
        }
    }
}
