using DomainModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork.Abstract;

namespace UnitOfWork.Concrete
{
    public class EFDbContext : DbContext, IEFDbContext
    {
        public EFDbContext() : base("name=VideoConference")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Conference> conference { get; set; }
        public DbSet<Messages> message { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Properties<string>().Configure(x => x.IsUnicode(false));
            base.OnModelCreating(modelBuilder);
        }
    }
}
