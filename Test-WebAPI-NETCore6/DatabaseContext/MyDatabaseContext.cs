
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Test_WebAPI_NETCore6.DataModel;

namespace Test_WebAPI_NETCore6.DatabaseContext
{
    public class MyDatabaseContext: DbContext
    {
      


        protected override void OnConfiguring
       (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "BookDb");


        }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

       

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

      

    }
}
