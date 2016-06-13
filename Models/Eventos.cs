 using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EDNEVENTOS.Models
{
    public class Eventos
    {
        [Key]
        [ScaffoldColumn(false)]
        [Display(Name = "Código do Evento")]
        public int IdEvento { get; set; }
        [Required]
        [Display(Name = "Cidade")]
        public string CidadeEvento { get; set; }
        [Required]
        [Display(Name = "Bairro")]
        public string BairroEvento { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Data do Evento")]
        public DateTime DataEvento { get; set; }
        [Required]
        [Display(Name = "CEP")]
        public int CepEvento { get; set; }
        [Required]
        [Display(Name = "Imagem")]
        public string ImagemProduto { get; set; }
        [Required]
        [Display(Name = "Status do Evento")]
        public bool Status { get; set; }
        [Required]
        [Display(Name = "Valor do Evento")]
        public decimal ValorEvento { get; set; }
        [Required]
        [Display(Name = "Nome do Evento")]
        public string NomeEvento { get; set; }
        [Required]
        [Display(Name = "Nº")]
        public int NumeroLocalEvento { get; set; }
        [Required]
        [Display(Name = "Local do Evento")]
        public string LocalEvento { get; set; }
        [Required]
        [Display(Name = "Caixa do evento")]
        public decimal Caixa { get; set; }
        //public ICollection <ProdutoEmEvento> ProdutoEmEvento{ get; set; }
        public TimeSpan Hora { get; set; }


    }
}
