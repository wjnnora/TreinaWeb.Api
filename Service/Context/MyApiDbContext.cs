using _0_Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Context
{
    public class MyApiDbContext : DbContext
    {
        public DbSet<Aluno> MyProperty { get; set; }

        public MyApiDbContext()
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }
    }
}
