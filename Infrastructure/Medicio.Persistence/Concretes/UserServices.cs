using Medicio.Application.Abstractions;
using Medicio.Domain.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Medicio.Persistence.Concretes
{
    public class UserServices : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserServices(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        public async Task Create(User user)
        {
            
            var result = await _userManager.CreateAsync(user,user.);
        }

        

        public async Task CreateRoleAsync()
        {
            foreach (var item in Enum.GetValues(typeof(Role)))
            {
                var roleExists = await _roleManager.RoleExistsAsync(item.ToString());
                if (!roleExists)
                {
                    var newRole = new IdentityRole { Name = item.ToString() };
                    var result = await _roleManager.CreateAsync(newRole);
                }
            }
        }

        

        public async Task SignInAsync(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user != null)
            {
                var signInResult = await _signInManager.CheckPasswordSignInAsync(user, password, lockoutOnFailure: false);

                if (signInResult.Succeeded)
                {
                    
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    
                }
            }
        }
    }
}

