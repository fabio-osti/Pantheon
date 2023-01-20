namespace OmnisExtensionum.Wrappers;

/// <summary>
/// 	Represents a wrapper that may or may not
///		contain a <typeparamref name="TValue"/>. 	
/// </summary>
/// 
/// <typeparam name="TValue">
/// 	Type of the <see cref="Value"/>.
/// </typeparam>
public struct Result<TValue>
{
	/// <summary>
	/// 	Initializes a failed <see cref="Result{TValue}"/>
	/// 	with <paramref name="exception"/>.
	/// </summary>
	/// 
	/// <param name="exception">
	/// 	Cause of failure.
	/// </param>
	public Result(Exception exception)
	{
		_exception = exception;
	}

	/// <summary>
	/// 	Initializes a successful <see cref="Result{TValue}"/>
	/// 	with <paramref name="value"/>.
	/// </summary>
	/// 
	/// <param name="value">
	/// 	Successful object.
	/// </param>
	public Result(TValue value)
	{
		_value = value;
	}

	private TValue? _value;
	/// <summary>
	/// 	Gets the value or throws <see cref="Exception"/> if
	/// 	<see cref="IsSuccessful"/> is false.
	/// </summary>
	public TValue Value => _value ?? throw Exception;

	private Exception? _exception;
	/// <summary>
	/// 	Gets the cause of failure or throws if 
	/// 	<see cref="IsSuccessful"/> is true.
	/// </summary>
	/// 
	///	<exception cref="InvalidOperationException">
	/// 	If <see cref="IsSuccessful"/> is true.
	/// </exception>
	public Exception Exception =>
		_exception
			??
		throw new InvalidOperationException(
			$"{nameof(Value)} is not null."
		);

	/// <summary>
	/// 	Gets wether this <see cref="Result{TValue}"/>
	/// 	is successful (<see cref="Value"/> is not null).
	/// </summary>
	public bool IsSuccessful => _value is not null;
}