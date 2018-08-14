using Somar.DTO;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Somar.DAL.Repository
{
    public partial class Entitiesa : DbContext
    {
        public Entitiesa()
            : base("name=SomarDatabase")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }

        public DbSet<GeneroDTO> listGeneros { get; set; }
    }
}
