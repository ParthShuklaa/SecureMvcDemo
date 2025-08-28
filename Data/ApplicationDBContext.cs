// We will be using this file for database interactions
 using Microsoft.EntityFrameworkCore;
 using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
 using SecureMvcDemo.Models;


    namespace SecureMvcDemo.Data
{
    public class ApplicationDbContext : IdentityDbContext
    //identityDbContext will provide the necessary functionality for user authentication and authorization
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {//we are configuring the database context using base for super class constructor
        }

    }

    // Define DbSets for your entities here
}
    
