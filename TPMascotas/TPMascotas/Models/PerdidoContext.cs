using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace TPMascotas.Models
{
    public class PerdidoContext : DbContext
    {
        public DbSet<Perdido> perdidos;
    }
}