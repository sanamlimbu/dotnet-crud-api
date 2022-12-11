using System;
namespace dotnet_crud_api.Models
{
	public class HTTPResponseHandler
	{
		public static HTTPResponse GetExceptionResponse(Exception ex)
		{
			HTTPResponse resp = new HTTPResponse();
			resp.Code = "500";
			resp.Message = ex.Message;
			return resp;
		}
		public static HTTPResponse GetHTTPResponse(ResponseType type, object? contract)
		{
			HTTPResponse resp = new HTTPResponse { ResponseData = contract };
			switch (type)
			{
				case ResponseType.Success:
					resp.Code = "200";
					resp.Message = "Success";
					break;
				case ResponseType.NotFound:
					resp.Code = "404";
					resp.Message = "Not found";
					break;
			}
			return resp;
		}
		
	}
}

