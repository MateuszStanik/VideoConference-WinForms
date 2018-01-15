using DomainModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitOfWork.Abstract
{
    public interface IEFDbContext : IDisposable
    {
        DbSet<Conference> conference { get; set; }

    }
}
