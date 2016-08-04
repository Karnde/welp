﻿using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WelpApp.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {

        public string ApplicationUserID { get; set; }
        [MaxLength(50)]
        public string ApplicationUsername { get; set; }
        [MaxLength(50)]
        public string Password { get; set; }
        [MaxLength(100)]
        public string Email { get; set; }
        [MaxLength(100)]
        public string Location { get; set; }

        // navigation properties
        public virtual ICollection<Rating> Ratings { get; set; }
        public virtual ICollection<Business> Businesses { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<WelpApp.Models.Rating> Ratings { get; set; }

        public System.Data.Entity.DbSet<WelpApp.Models.Business> Businesses { get; set; }

        public System.Data.Entity.DbSet<WelpApp.Models.ApplicationUser> ApplicationUsers { get; set; }

        public System.Data.Entity.DbSet<WelpApp.Models.BusinessType> BusinessTypes { get; set; }
    }
}