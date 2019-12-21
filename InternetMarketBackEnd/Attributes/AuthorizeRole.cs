using InternetMarketBackEnd.Shared.Enums;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Linq;

namespace InternetMarketBackEnd.Attributes
{
    public class AuthorizeRole : AuthorizeAttribute
    {
        public AuthorizeRole(params UserRoleEnum[] allowedRoles) : base()
        {
            var allowedRolesAsStrings = allowedRoles.Select(x => Enum.GetName(typeof(UserRoleEnum), x));
            Roles = string.Join(",", allowedRolesAsStrings);
        }
    }
}
