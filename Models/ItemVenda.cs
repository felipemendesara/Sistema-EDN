using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EDNEVENTOS.Models
{
    public class ItemVenda
    {
        [Key]
        public int NumeroVenda { get; set; }
        public int IdProduto { get; set; }
        public Produtos Produto { get;set;}
        public int IdEvento { get; set; }
        public Eventos Evento { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorUnit { get; set; }
        public decimal ValorTotal { get; set; }
    }
}
