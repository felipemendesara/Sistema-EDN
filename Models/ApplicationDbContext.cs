﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;
using EDNEVENTOS.Models;
using EDNEVENTOS.Controllers;

namespace EDNEVENTOS.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            //builder.Entity<ProdutoEmEvento>().HasKey(x => new { x.IdEvento, x.IdProduto });
        }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<Produtos> Produtos { get; set; }
        public DbSet<Eventos> Eventos { get; set; }
        public DbSet<CaixaEventos> CaixaEventos { get; set; }
        public DbSet<ProdutoEmEvento> ProdutoEmEvento { get; set; }
        public DbSet<ItemVenda> ItemVenda { get; set; }

    }
}
