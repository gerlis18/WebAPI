namespace WebAPI.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class SugerencesContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Sugerence> Sugerence { get; set; }
        public DbSet<UserSugerence> UserSugerence { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<SugerencesPost> SugerencesPost { get; set; }
        public SugerencesContext()
            : base("name=SugerencesContext")
        {
        }

        
    }
}