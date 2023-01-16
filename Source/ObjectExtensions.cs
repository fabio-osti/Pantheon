using System.Diagnostics.CodeAnalysis;
using System.Dynamic;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace OmnisExtensionum;

static public class ObjectExtensions
{
	static public T Pipe<T>(this T obj, Func<T, T> destination) =>
		destination(obj);

	public static dynamic ThrowIfMemberNull(this object obj)
	{
		var result = new ExpandoObject();
		foreach (
			var prop in
			obj
				.GetType()
				.GetProperties(BindingFlags.Instance | BindingFlags.Public)
		) {
			result.TryAdd(
				prop.Name,
				prop.GetValue(obj)
					?? throw new ArgumentNullException(prop.Name)
			);
		}
		return result;
	}

	public static dynamic ThrowIfMemberNull(
		this object obj,
		Func<Exception> exceptionBuilder
	)
	{
		var result = new ExpandoObject();
		foreach (
			var prop in
			obj
				.GetType()
				.GetProperties(BindingFlags.Instance | BindingFlags.Public)
		) {
			result.TryAdd(
				prop.Name,
				prop.GetValue(obj) ?? throw exceptionBuilder()
			);
		}
		return result;
	}

	public static T ThrowIfNull<T>(
		[NotNull] this T? obj,
		[CallerArgumentExpression(nameof(obj))] string? paramName = null
	) =>
		obj ?? throw new ArgumentNullException(paramName);

	public static T ThrowIfNull<T>(
		[NotNull] this T? obj,
		Func<Exception> exceptionBuilder
	) =>
		obj ?? throw exceptionBuilder();
}