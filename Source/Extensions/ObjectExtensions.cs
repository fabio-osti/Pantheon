using System.Diagnostics.CodeAnalysis;
using System.Dynamic;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace OmnisExtensionum.Extensions;

/// <summary>
/// 	Extensions of any object.
/// </summary>
public static class ObjectExtensions
{
	/// <summary>
	/// 	Calls <paramref name="fn"/> using <paramref name="obj"/>
	/// 	as argument and returns its result.
	/// </summary>
	/// 
	/// <param name="obj">
	/// 	Argument to be "piped".
	/// </param>
	/// 
	/// <param name="fn">
	/// 	Function to be called.
	/// </param>
	/// 
	/// <returns>
	/// 	The return value of <paramref name="fn"/>.
	/// </returns>
	public static TOut Pipe<TIn, TOut>(this TIn obj, Func<TIn, TOut> fn) =>
		fn(obj);

	/// <summary>
	/// 	Throws if <paramref name="obj"/> or any of its members is null.
	/// </summary>
	/// 
	/// <param name="obj">
	/// 	Object that will have its members checked.
	/// </param>
	/// 
	/// <param name="paramName">
	/// 	Name of <paramref name="obj"/>, no need to pass it.
	/// </param>
	/// 
	/// <returns>
	/// 	The same <paramref name="obj"/>.
	/// </returns>
	/// 
	/// <exception cref="ArgumentNullException">
	/// 	If <paramref name="obj"/> or any of its members is null.
	/// </exception>
	public static T ThrowIfMemberNull<T>(
		[NotNull] this T obj,
		[CallerArgumentExpression(nameof(obj))] string? paramName = null
	)
	{
		foreach (
			var prop in
			obj?
				.GetType()
				.GetProperties(BindingFlags.Instance | BindingFlags.Public)
				??
			throw new ArgumentNullException(paramName)
		) {
			_ = prop.GetValue(obj)
				?? throw new ArgumentNullException($"{prop.Name} of {paramName}");
		}
		return obj;
	}

	/// <summary>
	/// 	Throws if <paramref name="obj"/> or any of its members is null.
	/// </summary>
	/// 
	/// <param name="obj">
	/// 	Object that will have its members checked.
	/// </param>
	/// 
	/// <param name="exceptionBuilder">
	/// 	Custom exception builder taking the name of the null member.
	/// </param>
	/// 
	/// <param name="paramName">
	/// 	Name of <paramref name="obj"/>, no need to pass it.
	/// </param>
	/// 
	/// <returns>
	/// 	The same <paramref name="obj"/>.
	/// </returns>
	public static T ThrowIfMemberNull<T>(
		[NotNull] this T obj,
		Func<string, Exception> exceptionBuilder,
		[CallerArgumentExpression(nameof(obj))] string? paramName = null
	)
	{
		foreach (
			var prop in
			obj?
				.GetType()
				.GetProperties(BindingFlags.Instance | BindingFlags.Public)
				??
			throw exceptionBuilder(paramName!)
		) {
			_ = prop.GetValue(obj) 
				?? throw exceptionBuilder($"{prop.Name} of {paramName}");
		}
		return obj;
	}

	/// <summary>
	/// 	Throws if <paramref name="obj"/> is null.
	/// </summary>
	/// 
	/// <param name="obj">
	/// 	Object that will be checked.
	/// </param>
	/// 
	/// <param name="paramName">
	/// 	Name of <paramref name="obj"/>, no need to pass it.
	/// </param>
	/// 
	/// <returns>
	/// 	Not null asserted <paramref name="obj"/>
	/// </returns>
	/// 
	/// <exception cref="ArgumentNullException"/>
	public static T ThrowIfNull<T>(
		[NotNull] this T? obj,
		[CallerArgumentExpression(nameof(obj))] string? paramName = null
	) =>
		obj ?? throw new ArgumentNullException(paramName);

	/// <summary>
	/// 	Throws if <paramref name="obj"/> is null.
	/// </summary>
	/// 
	/// <param name="obj">
	/// 	Object that will be checked.
	/// </param>
	/// 
	/// <param name="exceptionBuilder">
	/// 	Custom exception builder taking the name of <paramref name="obj"/>.
	/// </param>
	/// 
	/// <param name="paramName">
	/// 	Name of <paramref name="obj"/>, no need to pass it.
	/// </param>
	/// 
	/// <returns>
	/// 	Not null asserted <paramref name="obj"/>
	/// </returns>
	/// 
	/// <exception cref="ArgumentNullException"/>
	public static T ThrowIfNull<T>(
		[NotNull] this T? obj,
		Func<string, Exception> exceptionBuilder,
		[CallerArgumentExpression(nameof(obj))] string? paramName = null
	) =>
		obj ?? throw exceptionBuilder(paramName!);
}
