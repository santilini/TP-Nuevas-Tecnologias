using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace TPMascotas.Models
{
    public class PerdidoContext : DbContext
    {
        public DbSet<Perdido> Perdidos { get; set; }
        public DbSet<Adoptado> Adoptados { get; set; }
        public DbSet<Encontrado> Encontrados { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
             
    }
}