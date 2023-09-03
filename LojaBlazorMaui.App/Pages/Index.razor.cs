using LojaBlazorMaui.Services.Models;
using LojaBlazorMaui.Services;

namespace LojaBlazorMaui.App.Pages
{
    public partial class Index
    {
        /// <summary>
        /// Produtos exibidos na página inicial da loja
        /// </summary>
        private List<ProdutosGetModel> produtos = new();

        /// <summary>
        /// Dados do produto selecionado pelo usuário
        /// </summary>
        private ProdutosGetModel produtoSelecionado = new();

        /// <summary>
        /// Método executado quando a página é carregada
        /// </summary>		
        protected override async Task OnInitializedAsync()
        {
            var produtosService = new ProdutosService();
            produtos = await produtosService.GetAll();
        }

        /// <summary>
        /// Método para capturar 1 produto selecionado pelo usuário
        /// </summary>
        /// <param name="item"></param>		
        protected async Task SelecionarProduto(ProdutosGetModel item)
        {
            produtoSelecionado = item;
        }
    }
}