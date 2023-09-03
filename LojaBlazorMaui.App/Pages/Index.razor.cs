using LojaBlazorMaui.Services.Models;
using LojaBlazorMaui.Services;

namespace LojaBlazorMaui.App.Pages
{
	public partial class Index
	{
		private List<ProdutosGetModel> produtos = new();

		/// <summary>
		/// Método executado quando a página é carregada
		/// </summary>
		/// <returns></returns>
		protected override async Task OnInitializedAsync()
		{
			var produtosService = new ProdutosService();
			produtos = await produtosService.GetAll();
		}
	}
}