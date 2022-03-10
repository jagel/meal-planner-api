using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace MealPlanner.Domain.Auth.Interfaces
{
    public interface IExternalAuthorization
    {
        AuthenticationProperties GenerateAuthenticationProperties(string returnUrl, string urlAPICallback);


    }
}
