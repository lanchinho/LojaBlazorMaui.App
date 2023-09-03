using LojaBlazorMaui.Services.Models;
using LojaBlazorMaui.Services;
using Microsoft.AspNetCore.Components;
using LojaBlazorMaui.App.Helpers;
using LojaBlazorMaui.App.Models;

namespace LojaBlazorMaui.App.Pages
{
    public partial class Index
    {
        /// <summary>
        /// Produtos exibidos na p�gina inicial da loja
        /// </summary>
        private List<ProdutosGetModel> produtos = new();

        /// <summary>
        /// Dados do produto selecionado pelo usu�rio
        /// </summary>
        private ProdutosGetModel produtoSelecionado = new();

        [Inject]
        public ShoppingCartHelper ShoppingCartHelper { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        /// <summary>
        /// M�todo executado quando a p�gina � carregada
        /// </summary>		
        protected override async Task OnInitializedAsync()
        {
            var produtosService = new ProdutosService();
            produtos = await produtosService.GetAll();
        }

        /// <summary>
        /// M�todo para capturar 1 produto selecionado pelo usu�rio
        /// </summary>
        /// <param name="item"></param>		
        protected async Task SelecionarProduto(ProdutosGetModel item)
        {
            produtoSelecionado = item;
        }

        protected async Task AdicionarAoCarrinho(ProdutosGetModel item)
        {
            var shoppingCartItem = new ShoppingCartItemModel
            {
                Qtd = 1,
                Produto = item
            };

            await ShoppingCartHelper.Add(shoppingCartItem);

            //redirecionar para a p�gina do carrinho de compras
            NavigationManager.NavigateTo("/shopping-cart", true);
        }
    }
}