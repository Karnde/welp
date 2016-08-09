namespace WelpApp.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WelpApp.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
   

    internal sealed class Configuration : DbMigrationsConfiguration<WelpApp.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        bool AddUserAndRole(WelpApp.Models.ApplicationDbContext context)
        {
            IdentityResult ir;
            var rm = new RoleManager<IdentityRole>
                (new RoleStore<IdentityRole>(context));
            ir = rm.Create(new IdentityRole("canEdit"));
            var um = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));
            var user = new ApplicationUser()
            {
                UserName = "user1@contoso.com",
            };
            ir = um.Create(user, "P_assw0rd1");
            if (ir.Succeeded == false)
                return ir.Succeeded;
            ir = um.AddToRole(user.Id, "canEdit");
            return ir.Succeeded;
        }
        protected override void Seed(WelpApp.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            AddUserAndRole(context);
            context.BusinessTypes.AddOrUpdate(p => p.BusinessTypeID,

                new BusinessType

                {
                    BusinessTypeID = 1,
                    BusinessTypeName ="Restaurant",
                    
                },

                new BusinessType
                {
                    BusinessTypeID = 2, 
                    BusinessTypeName = "Barbershop",
                },

                new BusinessType
                {
                    BusinessTypeID = 3, 
                    BusinessTypeName = "Bar",
                },

                new BusinessType
                {
                    BusinessTypeID = 4, 
                    BusinessTypeName = "Hotel",
                }

                );


            context.Businesses.AddOrUpdate(p => p.BusinessName,

                new Business
                {
                    BusinessName = "Pineappleants",
                    BusinessTypeID = 1,
                    Address = "1001 Euclid Ave, Cleveland, OH",
                    Hours = "4pm - 10pm",
                    Phone = "216 - 543 - 9876",
                    Menu = "image of menu, link to their menu or website",
                   

                },

                new Business
                {
                    BusinessName = "Cutz",
                    BusinessTypeID = 2, 
                    Address = "2345 Rodeo Drive, Los Angeles, CA",
                    Hours = "9am - 9pm",
                    Phone = "198-749-6051",
                    Menu = "Image of services/price menu, link to their menu or website",
                    


                },

                new Business
                {
                    BusinessName = "Drunks",
                    BusinessTypeID = 3, 
                    Address = "666 AA Lane, Penitentiary, OH",
                    Hours = "4pm - 2am",
                    Phone = "614-LUV-BEER",
                    Menu = "JUST DRINKS",
                    

                },

                new Business
                {
                    BusinessName = "Scandal Inn",
                    BusinessTypeID = 4, 
                    Address = "9172 Desperate Lane, Promiscuous, PA",
                    Hours = "24 hours",
                    Phone = "202-NOT-MINE",
                    Menu = "Listing of room packages, prices and availability",
                   

                }

                );
            // Need to figure out how to call Ratings. Icollection is listed in the Business class, but Rating ID is not a column within the class.
            // How can we implement the Icollection to list Ratings as a column on the web app. 
           
               





        }
    }
}
