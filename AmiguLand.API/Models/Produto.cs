using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AmiguLand.API.Models;
public class Produto
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "A categoria é obrigatória")]
    public int CategoriaId { get; set; }
    [ForeignKey("CategoriaId")]
    [Display(Name = "Categoria")]
    public Categoria Categoria { get; set; }

    [Required(ErrorMessage = "O nome do produto é obrigatório")]
    [StringLength(100)]
    public string Nome { get; set; }

    [StringLength(3000)]
    [Display(Name ="Descrição")]
    public string Descricao { get; set; }

    [Required(ErrorMessage = "A quantidade é obrigatória")]
    [Display(Name ="Quantidade")]
    public int Qtde { get; set; }

    [Required(ErrorMessage = "O valor do custo é obrigatório")]
    [Column(TypeName = "decimal(12,2)")]
    public decimal ValorCusto { get; set; } = 0;

    [Required(ErrorMessage = "O valor da venda é obrigatória")]
    [Column(TypeName = "decimal(12,2)")]
    public decimal ValorVenda { get; set; }

    [Required(ErrorMessage = "O status do destaque é obrigatório")]
    public bool Destaque { get; set; } = false;

    [StringLength(300)]
    public string Foto { get; set; }
}