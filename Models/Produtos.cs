using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EDNEVENTOS.Models
{
    public class Produtos
    {
        [Key]
        [ScaffoldColumn(false)]
        [Display(Name = "Código do Produto")]
        public int IdProduto { get; set; }
        [Required]
        [Display(Name = "Valor do Produto")]
        public decimal ValorProduto { get; set; }

        [Required]
        [Display(Name = "Imagem")]
        public string Imagem { get; set; }
        [Required]
        [Display(Name = "Quantidade")]
        public int QuantidadeProduto { get; set; }
        [Required]
        [Display(Name = "Categoria")]
        public string CategoriaProduto { get; set; }
        [Required]
        [Display(Name = "Nome do Produto")]
        public string NomeProduto { get; set; }
        //public ICollection<ProdutoEmEvento> ProdutoEmeEvento { get; set; }

    }
}
