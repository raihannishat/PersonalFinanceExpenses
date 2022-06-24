﻿using PFE.Data;
using PFE.membership.Contexts;
using PFE.membership.Entities;
using PFE.membership.Services;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PFE.membership.Data
{
    public class AccountSeed : DataSeed
    {
        private readonly UserManager _userManager;
        private readonly RoleManager _roleManager;

        private readonly ApplicationUser _superAdminUser, _adminUser;
        private readonly Role _superAdminRole, _adminRole;

        public AccountSeed(UserManager userManager, RoleManager roleManager, ApplicationDbContext context)
            : base(context)
        {
            _userManager = userManager; 
            _roleManager = roleManager;

            _superAdminUser = new ApplicationUser("superadmin", "Raihan Nishat", "01710512211", "raihannishat.swe@gmail.com");
            _adminUser = new ApplicationUser("admin", "Raihan Nishat", "01710512211", "raihannishat.swe@gmail.com");
           

            _superAdminRole = new Role("SuperAdmin");
            _adminRole = new Role("Administrator");
           
        }

        private async Task<bool> CheckAndCreateRoleAsync(Role role)
        {
            if((await _roleManager.FindByNameAsync(role.Name)) == null)
            {
                var result = await _roleManager.CreateAsync(role);
                return result.Succeeded;
            }
            return true;
        }

        private async Task SeedUserAsync()
        {
            IdentityResult result = null;
            if((await _userManager.FindByNameAsync(_superAdminUser.UserName.ToUpper())) == null)
            {
                result = await _userManager.CreateAsync(_superAdminUser, "asd123!@#");
                if (result.Succeeded)
                {
                    if (await CheckAndCreateRoleAsync(_superAdminRole))
                    {
                        await _userManager.AddToRoleAsync(_superAdminUser, _superAdminRole.Name);
                    }
                }
            }

            if ((await _userManager.FindByNameAsync(_adminUser.UserName.ToUpper())) == null)
            {
                result = await _userManager.CreateAsync(_adminUser, "123456aA.");
                if (result.Succeeded)
                {
                    if (await CheckAndCreateRoleAsync(_adminRole))
                    {
                        await _userManager.AddToRoleAsync(_adminUser, _adminRole.Name);
                    }
                }
            }

        }

        public override async Task SeedAsync()
        {
            await SeedUserAsync();
        }

    }
}
