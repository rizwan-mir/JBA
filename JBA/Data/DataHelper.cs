using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace JBA.Data
{
    class DataHelper : DbContext
    {
        public DataHelper() : base("name=Rents") { }

        public virtual DbSet<Rainfall> RainData { get; set; }

    }
}
