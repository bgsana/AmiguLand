using System.ComponentModel.DataAnnotations;

namespace AmiguLand.API.Models;

public class Categoria
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "O nome da categoria é obrigatório")]
    [StringLength(50)]
    public string Nome { get; set; }

    [StringLength(300)]
    public string Foto { get; set; }

    [StringLength(26)]
    public string Cor { get; set; } = "rgba(0,0,0,1)";
}
