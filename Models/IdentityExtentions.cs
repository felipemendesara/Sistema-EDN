﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace EDNEVENTOS.Models
{
    public static class IdentityExtentions
    {
        public static string GetDisplayName(this IIdentity identity)
        {
            var displayNameClaim = ((ClaimsIdentity)identity).FindFirst("DisplayName").Value;

            return displayNameClaim;
        }
    }
}