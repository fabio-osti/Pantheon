using System.Numerics;

namespace OmnisExtensionum.Extensions;

/// <summary>
/// 	Extensions of any numeric value.
/// </summary>
public static class NumberExtensions
{
	/// <summary>
	/// 	Converts <paramref name="number"/> to <see cref="double"/>
	/// </summary>
	/// 
	/// <param name="number">
	/// 	Value to be converted.
	/// </param>
	/// 
	/// <returns>
	/// 	A <see cref="double"/> equivalent to <paramref name="number"/>.
	/// </returns>
	public static double ToDouble<TNum>(this TNum number) where TNum : INumber<TNum> =>
		Convert.ToDouble(number);
	
	/// <summary>
	/// 	Converts <paramref name="number"/> to <see cref="sbyte"/>
	/// </summary>
	/// 
	/// <param name="number">
	/// 	Value to be converted.
	/// </param>
	/// 
	/// <returns>
	/// 	A <see cref="sbyte"/> equivalent to <paramref name="number"/>.	
	/// </returns>
	public static sbyte ToSByte<TNum>(this TNum number) where TNum : IConvertible =>
		Convert.ToSByte(number);

	/// <summary>
	/// 	Converts <paramref name="number"/> to <see cref="byte"/>
	/// </summary>
	/// 
	/// <param name="number">
	/// 	Value to be converted.
	/// </param>
	/// 
	/// <returns>
	/// 	A <see cref="byte"/> equivalent to <paramref name="number"/>.
	/// </returns>
	public static byte ToByte<TNum>(this TNum number) where TNum : IConvertible =>
		Convert.ToByte(number);

	/// <summary>
	/// 	Converts <paramref name="number"/> to <see cref="short"/>
	/// </summary>
	/// 
	/// <param name="number">
	/// 	Value to be converted.
	/// </param>
	/// 
	/// <returns>
	/// 	A <see cref="short"/> equivalent to <paramref name="number"/>.	
	/// </returns>	
	public static short ToInt16<TNum>(this TNum number) where TNum : IConvertible =>
		Convert.ToInt16(number);

	/// <summary>
	/// 	Converts <paramref name="number"/> to <see cref="ushort"/>
	/// </summary>
	/// 
	/// <param name="number">
	/// 	Value to be converted.
	/// </param>
	/// 
	/// <returns>
	/// 	A <see cref="ushort"/> equivalent to <paramref name="number"/>.	
	/// </returns>
	public static ushort ToUInt16<TNum>(this TNum number) where TNum : IConvertible =>
		Convert.ToUInt16(number);

	/// <summary>
	/// 	Converts <paramref name="number"/> to <see cref="int"/>
	/// </summary>
	/// 
	/// <param name="number">
	/// 	Value to be converted.
	/// </param>
	/// 
	/// <returns>
	/// 	A <see cref="int"/> equivalent to <paramref name="number"/>.	
	/// </returns>
	public static int ToInt32<TNum>(this TNum number) where TNum : IConvertible =>
		Convert.ToInt32(number);

	/// <summary>
	/// 	Converts <paramref name="number"/> to <see cref="uint"/>
	/// </summary>
	/// 
	/// <param name="number">
	/// 	Value to be converted.
	/// </param>
	/// 
	/// <returns>
	/// 	A <see cref="uint"/> equivalent to <paramref name="number"/>.	
	/// </returns>
	public static uint ToUInt32<TNum>(this TNum number) where TNum : IConvertible =>
		Convert.ToUInt32(number);

	/// <summary>
	/// 	Converts <paramref name="number"/> to <see cref="long"/>
	/// </summary>
	/// 
	/// <param name="number">
	/// 	Value to be converted.
	/// </param>
	/// 
	/// <returns>
	/// 	A <see cref="long"/> equivalent to <paramref name="number"/>.	
	/// </returns>
	public static long ToInt64<TNum>(this TNum number) where TNum : IConvertible =>
		Convert.ToInt64(number);

	/// <summary>
	/// 	Converts <paramref name="number"/> to <see cref="ulong"/>
	/// </summary>
	/// 
	/// <param name="number">
	/// 	Value to be converted.
	/// </param>
	/// 
	/// <returns>
	/// 	A <see cref="ulong"/> equivalent to <paramref name="number"/>.	
	/// </returns>		
	public static ulong ToUInt64<TNum>(this TNum number) where TNum : IConvertible =>
		Convert.ToUInt64(number);
}
