using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;
using Microsoft.Extensions.DependencyInjection;


namespace EDNEVENTOS.Models
{
    public class SampleData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<ApplicationDbContext>();
            context.Database.Migrate();

            if (!context.Eventos.Any())
            {
                var prod = context.Produtos.Add(new Produtos
                {
                    NomeProduto = "Coca Cola",
                    CategoriaProduto = "Bebida",
                    ValorProduto = 200,
                    QuantidadeProduto = 80,
                }).Entity;
                context.Eventos.AddRange(
                    new Eventos()
                    {
                        NomeEvento = "Glow Party",
                        ValorEvento = 80.00m,
                        CepEvento = 06787360,
                        CidadeEvento = "SAO PAULO",
                        BairroEvento = "Jd Salete",
                        LocalEvento = "PORS",
                        NumeroLocalEvento = 800,
                        Status = true

                    });
            }
        }
    }
}
