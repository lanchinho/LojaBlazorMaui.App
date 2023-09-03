using LojaBlazorMaui.Services.Models;

namespace LojaBlazorMaui.App.Models
{
    /// <summary>
    /// Modelo de dados do item contido no carrinho de compras.
    /// </summary>
    public class ShoppingCartItemModel
    {
        public ProdutosGetModel  Produto { get; set; }
        public int Qtd { get; set; }
    }
}
