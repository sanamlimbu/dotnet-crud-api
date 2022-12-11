using System;
namespace dotnet_crud_api.Models
{
	public class ProductModel
	{
		public string id { get; set; } = string.Empty;
		public string name { get; set; } = string.Empty;
		public string slug { get; set; } = string.Empty;
		public string? description { get; set; }
		public int quantity { get; set; } = 0;
		public decimal price { get; set; } = 0;
		public DateTime? manufactured_date { get; set; }
	}
}

