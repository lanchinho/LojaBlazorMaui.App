using Microsoft.AspNetCore.Components;
using LojaBlazorMaui.App.Helpers;
using LojaBlazorMaui.App.Models;
using Microsoft.JSInterop;

namespace LojaBlazorMaui.App.Pages
{
    public partial class ShoppingCart
    {
        [Inject] //inje��o de depend�ncia
        public ShoppingCartHelper ShoppingCartHelper { get; set; }

        [Inject] //IoC
        public IJSRuntime JSRuntime { get; set; }

        /// <summary>
        /// Objeto para exibir as informa��es do carrinho de compras
        /// </summary>
        private ShoppingCartModel ShoppingCartModel = new();

        /// <summary>
        /// M�todo executado ao abrir o componente
        /// </summary>
        protected override async Task OnInitializedAsync()
        {
            //capturar os dados do carrinho de compras gravado na local storage
            ShoppingCartModel = await ShoppingCartHelper.Get();
        }

        /// <summary>
        /// M�todo para adicionar uma unidade de um item do carrinho
        /// </summary>        
        protected async Task AdicionarUnidade(Guid id)
        {
            await ShoppingCartHelper.Add(id);
            //recarrega carrinho, atualizando visualiza��o...
            await OnInitializedAsync();
        }

        /// <summary>
        /// M�todo para remover uma unidade do carrinho
        /// </summary>        
        protected async Task RemoverUnidade(Guid id)
        {
            await ShoppingCartHelper.Remove(id);
            await OnInitializedAsync();
        }

        /// <summary>
        /// M�todo para limpar o conte�do do carrinho de compras
        /// </summary>
        protected async Task LimparCarrinho()
        {
            var confirm = await JSRuntime.InvokeAsync<bool>("confirm", "Deseja realmente excluir todos os itens do seu carrinho de compras?");

            if (confirm)
            {
                await ShoppingCartHelper.RemoveAll();
                await OnInitializedAsync();
            }
        }
    }
}