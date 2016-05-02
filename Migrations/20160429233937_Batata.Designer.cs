using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using EDNEVENTOS.Models;

namespace SistemaEDN.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20160429233937_Batata")]
    partial class Batata
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EDNEVENTOS.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id");

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedUserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasAnnotation("Relational:Name", "EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .HasAnnotation("Relational:Name", "UserNameIndex");

                    b.HasAnnotation("Relational:TableName", "AspNetUsers");
                });

            modelBuilder.Entity("EDNEVENTOS.Models.CaixaEventos", b =>
                {
                    b.Property<int>("IdCaixa")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Caixa");

                    b.Property<decimal>("CaixaInicial");

                    b.Property<bool>("StatusCaixa");

                    b.HasKey("IdCaixa");
                });

            modelBuilder.Entity("EDNEVENTOS.Models.Eventos", b =>
                {
                    b.Property<int>("IdEvento")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BairroEvento")
                        .IsRequired();

                    b.Property<int>("CepEvento");

                    b.Property<string>("CidadeEvento")
                        .IsRequired();

                    b.Property<DateTime>("DataEvento");

                    b.Property<string>("EstadoEvento")
                        .IsRequired();

                    b.Property<string>("ImagemProduto")
                        .IsRequired();

                    b.Property<string>("LocalEvento")
                        .IsRequired();

                    b.Property<string>("NomeEvento")
                        .IsRequired();

                    b.Property<int>("NumeroLocalEvento");

                    b.Property<bool>("Status");

                    b.Property<decimal>("ValorEvento");

                    b.HasKey("IdEvento");
                });

            modelBuilder.Entity("EDNEVENTOS.Models.ProdutoEmEvento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("EventoIdEvento");

                    b.Property<int?>("ProdutoIdProduto");

                    b.Property<int>("Quantidade");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("EDNEVENTOS.Models.Produtos", b =>
                {
                    b.Property<int>("IdProduto")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CaixaEventosIdCaixa");

                    b.Property<string>("CategoriaProduto")
                        .IsRequired();

                    b.Property<string>("NomeProduto")
                        .IsRequired();

                    b.Property<int>("QuantidadeProduto");

                    b.Property<decimal>("ValorProduto");

                    b.HasKey("IdProduto");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRole", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .HasAnnotation("Relational:Name", "RoleNameIndex");

                    b.HasAnnotation("Relational:TableName", "AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasAnnotation("Relational:TableName", "AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasAnnotation("Relational:TableName", "AspNetUserRoles");
                });

            modelBuilder.Entity("EDNEVENTOS.Models.ProdutoEmEvento", b =>
                {
                    b.HasOne("EDNEVENTOS.Models.Eventos")
                        .WithMany()
                        .HasForeignKey("EventoIdEvento");

                    b.HasOne("EDNEVENTOS.Models.Produtos")
                        .WithMany()
                        .HasForeignKey("ProdutoIdProduto");
                });

            modelBuilder.Entity("EDNEVENTOS.Models.Produtos", b =>
                {
                    b.HasOne("EDNEVENTOS.Models.CaixaEventos")
                        .WithMany()
                        .HasForeignKey("CaixaEventosIdCaixa");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNet.Identity.EntityFramework.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("EDNEVENTOS.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("EDNEVENTOS.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNet.Identity.EntityFramework.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId");

                    b.HasOne("EDNEVENTOS.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId");
                });
        }
    }
}
