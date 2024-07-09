namespace Store.DomainShared;

public class DomainResponseEntity<T>
{
	public bool IsSuccess { get; set; } = false;
	public string ErrorDetail { get; set; } = string.Empty;
	public T? Entity { get; set; }

}