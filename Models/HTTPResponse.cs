using System;
namespace dotnet_crud_api.Models
{
	public class HTTPResponse
	{
		public string Code { get; set; } = string.Empty;
		public string Message { get; set; } = string.Empty;
		public object? ResponseData { get; set; }
	}

	public enum ResponseType
	{
		Success,
		NotFound,
		Failure,
	}
}

