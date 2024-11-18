namespace HotellApp.Server.Models;

public class ServiceResult
{
	public bool Success { get; set; }
	public string ErrorMessage { get; set; }

	public static ServiceResult SuccessResult() => new ServiceResult { Success = true };
	public static ServiceResult Failure(string errorMessage) => new ServiceResult { Success = false, ErrorMessage = errorMessage };
}

public class ServiceResult<T> : ServiceResult
{
	public T Data { get; set; }

	public static new ServiceResult<T> SuccessResult(T data) => new ServiceResult<T> { Success = true, Data = data };
	public static new ServiceResult<T> Failure(string errorMessage) => new ServiceResult<T> { Success = false, ErrorMessage = errorMessage };
}
