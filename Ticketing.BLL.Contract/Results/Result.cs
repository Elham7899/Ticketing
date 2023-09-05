using Ticketing.Models.Core;

namespace Ticketing.BLL.Contract.Results;

public class Result
{
	public bool Status { get; set; }

	public ErrorModel ErrorModel { get; set; }

	public List<string> Error { get; private set; } = new List<string>();

	public object Data { get; set; }

	public Result() => Status = true;

	public Result(List<string> error)
	{
		Status = false;
		Error = error;
	}

	public Result(object data)
	{
		Status = true;
		Data = data;
	}

	public Result(ErrorModel errorModel)
	{
		Status = false;
		ErrorModel = errorModel;
	}
}

public class Result<T>
{
	public bool Status { get; private set; }

	public ErrorModel ErrorModel { get; set; }

	public T Data { get; set; }

	public Result() => Status = true;

	public Result(ErrorModel errorModel)
	{
		Status = false;
		ErrorModel = errorModel;

	}

	public Result(T data)
	{
		Status = true;
		Data = data;
	}
}
