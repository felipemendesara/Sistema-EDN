using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EDNEVENTOS.Models
{
    public class CaixaEventos
    {
        [Key]
        [ScaffoldColumn(false)]
        [Display(Name = "Chave do Caixa")]
        public int IdCaixa { get; set; }
        [Required]
        [Display(Name = "Caixa inicial")]
        public decimal CaixaInicial { get; set; }
        [Required]
        [Display(Name = "Caixa")]
        public decimal Caixa { get; set; }
        [Required]
        [Display(Name = "Status do Caixa")]
        public bool StatusCaixa { get; set; }
        public virtual ICollection<Produtos> Produtos { get; set; }
    }
}
