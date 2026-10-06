using System;
using System.Collections.Generic;
using org.SpocWeb.root.array;
using org.SpocWeb.root.data.hash;
using org.SpocWeb.root.extensions.collections;
using org.SpocWeb.root.extensions.enumerables;
using org.SpocWeb.root.Attributes;

namespace org.SpocWeb.root.maths.pga.ga;

/// <summary> R^3 Vector-Space with Rotations and Reflections </summary>
/// <remarks>
/// By implementing <see cref="IReadOnlyList{Double}"/>,
/// Operators would need to be defined only once.
/// 
/// But to support Lists from the Left and to resolve the resulting Ambiguity
/// you still have to define all 4 Operators for <see cref="IReadOnlyList{T}"/>,
/// <see cref="IList{T}"/>, <see cref="List{T}"/> and Array.
/// </remarks>
/// <inheritdoc />
[DocState(Pass = 2, MTime = "2026-07-07T17:43:09Z", Digest = "43a6598edcf3650557ee941bf014ec16f687e3a072429e0e4ad5ee53007e6d1a", Stale = false, Path = "ga/AGeoGebra8Dbl.cs", Since = "2026-10-06")]
[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
[Tags("code/abstract_base", "code/clifford_algebra")]
[System.ComponentModel.Description("R^3 Vector-Space with Rotations and Reflections")]
[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
public abstract class AGeoGebra8Dbl<T> : AGeoGebraDbl<T>
	where T : AGeoGebra8Dbl<T>
{
	/// <summary>Specifies the constant dIM.</summary>
	public const int DIM = 3;
	/// <summary>Specifies the constant nUM_ COORDS.</summary>
	public const int NUM_COORDS = 1 << DIM;
	/// <inheritdoc />
	public override byte Dim => DIM;

	/// <summary> Array with MultiVector-Coefficients </summary>
	/// <remarks>
	/// using Span&lt;double> = stackalloc double[8]; is only possible in struct!
	/// TODO: Use 8 direct Members to save another Stack Allocation for _C
	/// Since allocated anyway, we can as well use double
	/// </remarks>
	protected readonly double[] _C;
	//public IReadOnlyList<double> C => _C;
	/// <inheritdoc />
	public sealed override double this[int idx] => _C[idx];
	//set => C[idx] = value;

	/// <inheritdoc />
	public override bool Equals(T? that) => ReferenceEquals(that, this) || Equals(that?._C);

	/// <inheritdoc />
	public sealed override IEnumerator<double> GetEnumerator() => _C.AsEnumerable().GetEnumerator();

	/// <summary> Unchecked private Constructor for Speed </summary>
	///
	//[Obsolete("Unchecked private Constructor for Speed")]
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/abstract_base", "code/clifford_algebra")]
	[System.ComponentModel.Description("Unchecked private Constructor for Speed")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	protected AGeoGebra8Dbl(double[] f) => _C = f;//: this((IReadOnlyList<double>) f) { }
	/// <summary>Initializes a new instance of <see cref="AGeoGebra8Dbl"/> with the specified <paramref name="f"/> and <paramref name="pos"/>.</summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/abstract_base", "code/clifford_algebra")]
	[System.ComponentModel.Description("Initializes a new instance of AGeoGebra8Dbl with the specified f and pos.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	protected AGeoGebra8Dbl(double f, int pos = 0) => _C = NEW(pos, f);

	/// <summary> Creates a coefficient array of length <see cref="NUM_COORDS"/> with <paramref name="value"/> at index <paramref name="pos"/> and zero elsewhere. </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/abstract_base", "code/clifford_algebra")]
	[System.ComponentModel.Description("Creates a coefficient array of length NUM_COORDS with value at index pos and zero elsewhere.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public static double[] NEW(int pos, double value = 1) {
		var ret = new double[NUM_COORDS];
		ret[pos] = value;
		return ret;
	}

	/// <inheritdoc cref="NEW(int, double)"/>
	public static double[] NEW(int pos, float value) {
		var ret = new double[NUM_COORDS];
		ret[pos] = value;
		return ret;
	}

	/// <summary> Checked Constructor </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/abstract_base", "code/clifford_algebra")]
	[System.ComponentModel.Description("Checked Constructor")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	protected AGeoGebra8Dbl(IReadOnlyList<double> f) {
		if (f.Count != Count) {
			throw new ArgumentOutOfRangeException("Must have " + Count + " Components, but has " + f.Count);
		}
		_C = f.ToArray();
	}

	/// <inheritdoc />
	public sealed override int ValueHash() => _C.BuildHashCode();
	/// <inheritdoc cref="Equals(T?)"/>
	public override bool Equals(IReadOnlyList<double>? that) {
		if (ReferenceEquals(that, _C)) return true;
		if (that is null) return false;
		return that.IsCloseTo(this);
		//return that.IsEqualTo(this);
	}

	#region Unary Functions

	/// <inheritdoc />
	public sealed override T Reverted() => Create_(_C.Reverted8());

	/// <summary> Main involution </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/abstract_base", "code/clifford_algebra")]
	[System.ComponentModel.Description("Main involution")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public sealed override T Involute () => Create_(_C.Involute8());

	/// <summary> Clifford Conjugate </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/abstract_base", "code/clifford_algebra")]
	[System.ComponentModel.Description("Clifford Conjugate")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public sealed override T Conjugate () => Create_(_C.CliffCjg8());

	#endregion Unary Functions

	#region Binary Functions

	/// <inheritdoc />
	public sealed override T Plus<S>(S addend) => Create_(_C.Plus8(addend));

	/// <inheritdoc />
	public sealed override IReadOnlyList<double> Minus<P>(P subtrahend) => Minus(subtrahend._C);

	/// <inheritdoc cref="Minus(P)"/>
	public sealed override T Minus(IReadOnlyList<double> b) => Create_(_C.Minus8(b));
	/// <inheritdoc />
	public sealed override T MinusR(IReadOnlyList<double> b) => Create_(b.Minus8(_C));

	/// <inheritdoc />
	protected override double[] Neg_() => _C.Neg8();

	/// <inheritdoc />
	public sealed override T Times(double factor) => Create_(_C.Times8(factor));

	/// <inheritdoc cref="Plus(S)"/>
	public sealed override T Plus<B>(double scalar, B basis) => Create_(_C.Plus(scalar, basis));

	/// <inheritdoc cref="MinusR(IReadOnlyList{double})"/>
	public sealed override T MinusR<B>(double scalar, B basis) => Create_(_C.MinusR(scalar, basis));

	/// <inheritdoc cref="Minus(P)"/>
	public sealed override T Minus<B>(double scalar, B basis) => Create_(_C.Minus(scalar, basis));

	#endregion Binary Functions

}
