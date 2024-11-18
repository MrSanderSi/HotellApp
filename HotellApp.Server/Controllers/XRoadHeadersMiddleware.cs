namespace HotellApp.Server.Controllers;

public class XRoadHeadersMiddleware
{
	private readonly RequestDelegate _next;

	public XRoadHeadersMiddleware(RequestDelegate next)
	{
		_next = next;
	}

	public async Task InvokeAsync(HttpContext context)
	{
		context.Response.OnStarting(() =>
		{
			context.Response.Headers.Add("X-Road-Client", "YOUR_CLIENT_IDENTIFIER");
			context.Response.Headers.Add("X-Road-Id", "YOUR_ID");
			// Add other necessary headers
			return Task.CompletedTask;
		});

		await _next(context);
	}
}

