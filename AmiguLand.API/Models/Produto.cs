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

    [Required(ErrorMessage = "A descrição é obrigatória")]
    [StringLength(3000)]
    [Display(Name ="Descrição")]
    public string Descricao { get; set; }
}