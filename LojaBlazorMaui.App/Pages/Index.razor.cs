using LojaBlazorMaui.Services.Models;
using LojaBlazorMaui.Services;

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
    }
}