using EDNEVENTOS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDNEVENTOS.Models
{
    public class ProdutoEmEvento
    {
        public int Id { get; set; }
        public int Quantidade {get;set;}
        public virtual ICollection<Eventos>Evento { get; set; }
        public virtual ICollection <Produtos> Produto { get; set; }
    }
}
