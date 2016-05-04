using EDNEVENTOS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDNEVENTOS.Models
{
    public class ProdutoEmEvento
    {
        public int IdEvento { get; set; }
        public Eventos Eventos{ get; set; }

        public int IdProduto { get; set; }
        public Produtos Produto { get; set; }
        public int Quantidade {get;set;}


    }

}
