using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EDNEVENTOS.Models
{
    public class UsuarioSeed
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UsuarioSeed(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async void EnsureData()
      {
            var user = new ApplicationUser
            {
                UserName = "Admin",
                Email = "felipemendesara@gmail.com",
                EmailConfirmed = true
            };
            var role = new IdentityRole
            {
                Name = "Admin"
            };
            var roleUser = new IdentityRole
            {
                Name = "User"
            };
            await _roleManager.CreateAsync(role);
            await _roleManager.CreateAsync(roleUser);
            await _userManager.CreateAsync(user,"Felipe007!");
            await _userManager.AddToRoleAsync(user, role.Name);
            await _userManager.AddClaimAsync(user, new Claim("DisplayName", "Administrador"));
        }
    }
}
