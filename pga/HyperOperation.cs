using org.SpocWeb.root.Attributes;
namespace org.SpocWeb.root.maths.pga;

/// <summary> <a href='https://en.wikipedia.org/wiki/Hyperoperation'
/// >Hyper-operations</a> are an infinite Sequence of binary Operations building upon each other. </summary>
/// <remarks>
/// There are different Notations for Hyper-Operations,
/// e.g Infix Operator with the [Degree in square Brackets]
/// or Donald Knuths arrow Notation which can be extended down to '+':
/// a[1]n = a+n
/// a[2]n = a*n = a++n
/// a[3]n = a^n = a**n = a+++n
/// a[4]n = a^^n = a***n = a++++n
/// 
/// </remarks>
[DocState(Pass = 2, MTime = "2026-05-17T11:57:30Z", Digest = "444c6db96256077620782254c547be085f380531f220231a2c77dc4d62d0cf88", Stale = false, Path = "pga/HyperOperation.cs", Since = "2026-10-06")]
[Facets(Layer = "domain", Status = "stable", Complexity = 1)]
[Tags("code/hyperoperation", "code/recursive_sequence")]
[System.ComponentModel.Description("Hyper-operations are an infinite Sequence of binary Operations building upon each other.")]
[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
public enum HyperOperation
{
	/// <summary> Increment by 1, starting at 0: a[0]n = n = 0(+1)^n </summary>
	Inc = 0,

	/// <summary> Addition; Repeated Increment by 1: a[1]n = a + n = a(+1)^n </summary>
	Plus = 1,

	/// <summary> Multiplication; Repeated Increment by the Argument: a[2]n = a * n = a(+a)^n </summary>
	Times, 

	/// <summary> Exponentiation; Repeated Multiplication by the Argument: a[3]n = a ^ n = a*a*...*a = a(*a)^n</summary>
	Pow,

	/// <summary> Tetration; Repeated Power by the Argument: a[4]n = a(^a)^n </summary>
	Tetra,
}