using EDNEVENTOS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EDNEVENTOS.Models
{
    public class ProdutoEmEvento
    {
        [Key]
        public int IdProdutoEvento { get; set; }
        //public int IdEvento { get; set; }
        public Eventos Eventos{ get; set; }

        //public int idproduto { get; set; }
        public Produtos Produto { get; set; }
        public int Quantidade {get;set;}
    }

}
