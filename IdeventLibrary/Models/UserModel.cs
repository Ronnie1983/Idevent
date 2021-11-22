using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeventLibrary.Models
{
    public class UserModel : IdentityUser<int>
    {
        // IndentityUser<int> properties:
        // Id, UserName, NormalizedUserName, Email, NormalizedEmail, EmailConfirmed, PasswordHash, SecurityStamp, ConcurrencyStamp, PhoneNumber,
        // PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnd, LockoutEnabled, AccessFailedCount

        public string Role { get; set; }
        public CompanyModel Company { get; set; }
        public AddressModel Address { get; set; }
        public AddressModel InvoiceAddress { get; set; } 
    }
}
