using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using LojaBlazorMaui.App.Helpers;
using LojaBlazorMaui.App.Models;

namespace LojaBlazorMaui.App.Pages
{
    public partial class ShoppingCart
    {
        [Inject] //injeção de dependência
        public ShoppingCartHelper ShoppingCartHelper { get; set; }

        [Inject] //injeção de dependência
        public IJSRuntime JSRuntime { get; set; }

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

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender) //carregando o datatable
                await JSRuntime.InvokeAsync<object>("TestDataTablesAdd", "#shoppingCartData");
        }

        /// <summary>
        /// Método para adicionar uma unidade de um item do carrinho
        /// </summary>
        protected async Task AdicionarUnidade(Guid id)
        {
            await ShoppingCartHelper.Add(id); //adicionando 1 unidade do item
            await OnInitializedAsync();
        }

        /// <summary>
        /// Método para remover uma unidade de um item do carrinho
        /// </summary>
        protected async Task RemoverUnidade(Guid id)
        {
            await ShoppingCartHelper.Remove(id); //removendo 1 unidade do item
            await OnInitializedAsync();
        }

        /// <summary>
        /// Método para remover um item do carrinho
        /// </summary>
        protected async Task RemoverItem(Guid id)
        {
            var confirm = await JSRuntime.InvokeAsync<bool>
                ("confirm", "Deseja realmente excluir este item do seu carrinho de compras?");

            if (confirm)
            {
                await ShoppingCartHelper.RemoveItem(id); //removendo 1 item do carrinho
                await OnInitializedAsync();
            }
        }

        /// <summary>
        /// Método para limpar o conteúdo do carrinho de compras
        /// </summary>
        protected async Task LimparCarrinho()
        {
            var confirm = await JSRuntime.InvokeAsync<bool>
                ("confirm", "Deseja realmente excluir todos os itens do seu carrinho de compras?");

            if (confirm)
            {
                await ShoppingCartHelper.RemoveAll();
                await OnInitializedAsync();
            }
        }
    }
}


