using AmiguLand.UI.DTOs;

namespace AmiguLand.UI.ViewModels;

public class HomeVM
{
    public List<CategoriaDto> Categorias { get; set; } = new();
    public List<ProdutoDto> ProdutosDestaque { get; set; } = new();
}