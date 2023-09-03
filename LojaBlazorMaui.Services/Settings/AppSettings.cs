using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaBlazorMaui.Services.Settings
{
	/// <summary>
	/// Mapeamentos das APIs acessadas pelo aplicativo
	/// </summary>
	public class AppSettings
	{
		/// <summary>
		/// API para consulta de produtos
		/// </summary>
		public static string ProdutosAPI 
			=> "http://apiprodutosmaui-001-site1.etempurl.com/api/produtos";
    }
}
