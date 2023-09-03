using LojaBlazorMaui.Services.Models;
using LojaBlazorMaui.Services.Settings;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaBlazorMaui.Services
{
	/// <summary>
	/// Serviços para consulta de produtos na API
	/// </summary>
	public class ProdutosService
	{
		public async Task<List<ProdutosGetModel>> GetAll()
		{
			using (var httpClient = new HttpClient())
			{
				var result = await httpClient.GetAsync(AppSettings.ProdutosAPI);

				if (result.IsSuccessStatusCode)
				{
					var builder = new StringBuilder();
					using (var r = result.Content)
					{
						//Task<string> task =  r.ReadAsStringAsync();
						// builder.Append(task.Result);
						var produto = await r.ReadAsStringAsync();
						builder.AppendLine(produto);
					}
					return JsonConvert.DeserializeObject<List<ProdutosGetModel>>(builder.ToString());
				}
				else
				{
					throw new ApplicationException("Falha ao obter produtos");
				}
			}
		}

	}
}
