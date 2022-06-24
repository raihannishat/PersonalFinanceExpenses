﻿using PFE.membership.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections;
using System.Collections.Generic;

namespace PFE.membership.Entities
{
    public class Role : IdentityRole<Guid>
    {
        public EnumRoles RoleStatus { get; set; }

        public Guid? CreatedBy { get; set; } 
        public DateTime CreationTime { get; set;}
        public bool IsActiveRole { get; set; }
        public bool IsDeletedRole { get; set; }
        public IList<ApplicationUserRole> UserRoles { get; set; }
        public Role()
            : base()
        {
            this.IsActiveRole = true;
            this.IsDeletedRole = false;
            this.UserRoles = new List<ApplicationUserRole>();
        }

        public Role(string roleName)
            : base(roleName)
        {
            this.IsActiveRole = true;
            this.IsDeletedRole = false;
            this.UserRoles = new List<ApplicationUserRole>();
        }

    }
}
