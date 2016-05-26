using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PetaPoco;

namespace MacroMachine.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    //DELETE FROM [dbo].[__MigrationHistory] to clear The model backing the 'ApplicationDbContext' context has changed 
    [TableName("AspNetUsers")]
    [PrimaryKey("Id", AutoIncrement = false)]
    public class ApplicationUser : IdentityUser
    {
        //TODO add new properties here
        public bool Metric { get; set; }
        public bool BiologicalSex { get; set; } //0 is female, 1 is male
                                                //https://docs.google.com/spreadsheets/d/1WD4VPR0REqK5LndP564fFPYAU1HUXruXVGAKqCCkWIg/edit#gid=1209178080
                                                //See MacroMachine.Models.IdentityModel
                                                //Metric Height - stored
                                                //Imperial Height - calculated [ignore]
                                                //Birthdate
                                                //Age - calcualted [ignore]
                                                //Metric BMR kilajoules - calculated [ignore]
                                                //Imperial BMR calories - calculated [ignore]
                                                //ActivityLevel - needs to be FK to other table
                                                //Metric Estimated Maintenance kilajoules using start weight
                                                //Target change in kilos can be positive and negative
                                                //Target change in lbs - calculated [ignore]

        //not sures: Protein/lb/kilo, fat%, 
        //        1 Calorie = 4.18 kilojoules

        //Or
        //1 kilojoule = 0.24 Calories(about ¼)

        //So to convert Calories to kilojoules, multiply the number of Calories by 4.

        //And to convert kilojoules to Calories, divide the number of kilojoules by 4.

        //TODO after registration, redirect to profile page
        //TODO Figure out minimum viable records for profile, add them to DB
        //, , birthday, , starting weight,
        //activity level (need from greg 

        //Metric vs Imperial
        //affects height (store as CM), weight (store as kg), protein per lb/kilo (store as kg)
        //lbs/kils gain or lose per week

        public static ApplicationUser Get(string userName)
        {
            userName = UserNameHelper(userName);
            var query = $"SELECT * FROM AspNetUsers WHERE UserName='{userName}'";
            //return GetCoach(query);
            using (var db = new Database("db"))
            {
                var user = db.SingleOrDefault<ApplicationUser>(query);
                //var clientsQuery = String.Format("SELECT * FROM Clients WHERE UserId='{0}'", coach.Id);
                //coach.Clients = db.Fetch<Client>(clientsQuery);
                //var planQuery = String.Format("SELECT * FROM Plans WHERE Id='{0}'", coach.PlanId);
                //coach.Plan = db.SingleOrDefault<Plan>(planQuery);
                return user;
            }
        }

        private static string UserNameHelper(string userName)
        {
            int index = userName.IndexOf("@", StringComparison.Ordinal);
            userName = userName.Insert(index + "@".Length, "@");
            return userName;
        }

        //https://github.com/cmgross/Dauber/blob/master/DAL/Coach.cs
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
            : base("db", throwIfV1Schema: false)
        {
            //PM> sqllocaldb.exe stop MSSQLLocalDB
//            LocalDB instance "MSSQLLocalDB" stopped.

//            PM > sqllocaldb.exe delete MSSQLLocalDB
//LocalDB instance "MSSQLLocalDB" deleted.
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}