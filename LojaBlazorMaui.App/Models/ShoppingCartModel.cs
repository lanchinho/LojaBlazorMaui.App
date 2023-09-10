namespace LojaBlazorMaui.App.Models
{
    /// <summary>
    /// Modelo de dados do carrinho de compras
    /// </summary>
    public class ShoppingCartModel
    {
        public int QtdItens
        {
            get => Itens != null && Itens.Any() ? Itens.Sum(item => item.Qtd) : 0;
        }

        public decimal ValorTotal
        {
            get
            {
                if (QtdItens > 0)
                {
                    var valorTotal = 0m;
                    foreach (var item in Itens)
                    {
                        if (item.Produto != null && item.Produto.Price > 0)
                            valorTotal += item.Qtd * item.Produto.Price;
                    }

                    return valorTotal;
                }
                else
                    return 0m;
            }
        }

        public List<ShoppingCartItemModel> Itens { get; set; }
    }
}
