using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaBlazorMaui.Services.Models
{
	/// <summary>
	/// Modelo de dados da consulta de produtos
	/// </summary>
	public class ProdutosGetModel
	{
		public Guid Id { get; set; }
		public string? Name { get; set; }
		public decimal Price { get; set; }
		public string? Description { get; set; }
		public string? PhotoUrl { get; set; }
		public string? Category { get; set; }
	}
}