using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace TPMascotas.Models
{
    public class PerdidoContext : IdentityDbContext
    {
        public DbSet<Perdido> Perdidos { get; set; }
        public DbSet<Adoptado> Adoptados { get; set; }
        public DbSet<Encontrado> Encontrados { get; set; }
        // Por lo que lei, las clases AppRole y AppUser, estan ya incluidas en IdentityDbContext             
    }
}