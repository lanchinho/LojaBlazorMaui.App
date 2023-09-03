using Microsoft.AspNetCore.Components;
using LojaBlazorMaui.App.Helpers;
using LojaBlazorMaui.App.Models;

namespace LojaBlazorMaui.App.Pages
{
    public partial class ShoppingCart
    {
        [Inject] //injeção de dependência
        public ShoppingCartHelper ShoppingCartHelper { get; set; }

        /// <summary>
        /// Objeto para exibir as informações do carrinho de compras
        /// </summary>
        private ShoppingCartModel ShoppingCartModel = new();

        /// <summary>
        /// Método executado ao abrir o componente
        /// </summary>
        protected override async Task OnInitializedAsync()
        {
            //capturar os dados do carrinho de compras gravado na local storage
            ShoppingCartModel = await ShoppingCartHelper.Get();
        }

        /// <summary>
        /// Método para limpar o conteúdo do carrinho de compras
        /// </summary>
        protected async Task LimparCarrinho()
        {
            await ShoppingCartHelper.RemoveAll();
            await OnInitializedAsync();
        }
    }
}