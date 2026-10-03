using System;
using System.Collections.Generic;
using org.SpocWeb.root.array;
using org.SpocWeb.root.data.hash;
using org.SpocWeb.root.extensions.collections;
using org.SpocWeb.root.extensions.enumerables;

namespace org.SpocWeb.root.maths.pga.ga;

/// <summary> Abstract double-precision base for the 8-component multi-vector of G(2,0,1)<br/>
/// (2D Projective Geometric Algebra), shared by <see cref="pga.Pga2Dbl"/>. </summary>
/// <remarks>
/// DIM = 3 reflects the three generators of G(2,0,1), yielding 2^3 = 8 coefficients stored in
/// <see cref="_C"/>.<br/>
/// By implementing <see cref="IReadOnlyList{Double}"/>, binary operators can be defined once; however,
/// to support list arguments on the left and avoid ambiguity you still need all four overloads for
/// <see cref="IReadOnlyList{T}"/>, <see cref="IList{T}"/>, <see cref="List{T}"/>, and array.
/// </remarks>
/// <example>
/// <code language="yaml">
/// pass: 2
/// mtime: 2026-05-24T15:36:37Z
/// digest: 2b24803985e32f128f66755aff062eed90d230ed428b471567956610aaf4b781
/// tags: [code/abstract_base, code/projective_geometric_algebra]
/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
/// facets: {layer: domain, status: stable, complexity: 2}
/// </code>
/// </example>
public abstract class Pga2Dbl : AGeoGebraDbl<Pga2Dbl>
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
	/// Use 8 direct Members to save another Stack Allocation for _C
	/// Since allocated anyway, we can as well use double
	/// </remarks>
	protected readonly double[] _C;
	//public IReadOnlyList<double> C => _C;
	/// <inheritdoc />
	public sealed override double this[int idx] => _C[idx];
	//set => C[idx] = value;

	/// <inheritdoc />
	public override bool Equals(Pga2Dbl? that) => ReferenceEquals(that, this) || Equals(that?._C);

	/// <inheritdoc />
	public sealed override IEnumerator<double> GetEnumerator() => _C.AsEnumerable().GetEnumerator();

	/// <summary> Unchecked private Constructor for Speed </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/abstract_base, code/projective_geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 2}
	/// </code>
	/// </example>
	//[Obsolete("Unchecked private Constructor for Speed")]
	protected Pga2Dbl(double[] f) => _C = f;//: this((IReadOnlyList<double>) f) { }
	/// <summary>Initializes a new instance of <see cref="Pga2Dbl"/> with the specified <paramref name="f"/> and <paramref name="pos"/>.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/abstract_base, code/projective_geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 2}
	/// </code>
	/// </example>
	protected Pga2Dbl(double f, int pos = 0) => _C = NEW(pos, f);

	/// <summary> Creates a zero coefficient array with <paramref name="value"/> at blade index <paramref name="pos"/>. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/abstract_base, code/projective_geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 2}
	/// </code>
	/// </example>
	public static double[] NEW(int pos, double value = 1) {
		var ret = new double[NUM_COORDS];
		ret[pos] = value;
		return ret;
	}

	/// <inheritdoc cref="NEW(int,double)"/>
	public static double[] NEW(int pos, float value) {
		var ret = new double[NUM_COORDS];
		ret[pos] = value;
		return ret;
	}

	/// <summary> Checked Constructor </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/abstract_base, code/projective_geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 2}
	/// </code>
	/// </example>
	protected Pga2Dbl(IReadOnlyList<double> f) {
		if (f.Count != Count) {
			throw new ArgumentOutOfRangeException("Must have " + Count + " Components, but has " + f.Count);
		}
		_C = f.ToArray();
	}

	/// <inheritdoc />
	public sealed override int ValueHash() => _C.BuildHashCode();
	/// <inheritdoc cref="Equals(Pga2Dbl?)"/>
	public override bool Equals(IReadOnlyList<double>? that) {
		if (ReferenceEquals(that, _C)) return true;
		if (that is null) return false;
		return that.IsCloseTo(this);
		//return that.IsEqualTo(this);
	}

	#region Unary Functions

	/// <inheritdoc />
	public sealed override Pga2Dbl Reverted() => Create_(_C.Reverted8());

	/// <summary> Main involution </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/abstract_base, code/projective_geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 2}
	/// </code>
	/// </example>
	public sealed override Pga2Dbl Involute () => Create_(_C.Involute8());

	/// <summary> Clifford Conjugate </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/abstract_base, code/projective_geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 2}
	/// </code>
	/// </example>
	public sealed override Pga2Dbl Conjugate () => Create_(_C.CliffCjg8());

	#endregion Unary Functions

	#region Binary Functions

	/// <inheritdoc />
	public sealed override Pga2Dbl Plus<S>(S addend) => Create_(_C.Plus8(addend));

	/// <inheritdoc />
	public sealed override IReadOnlyList<double> Minus<P>(P subtrahend) => Minus(subtrahend._C);

	/// <inheritdoc cref="Minus(P)"/>
	public sealed override Pga2Dbl Minus(IReadOnlyList<double> b) => Create_(_C.Minus8(b));
	/// <inheritdoc />
	public sealed override Pga2Dbl MinusR(IReadOnlyList<double> b) => Create_(b.Minus8(_C));

	/// <inheritdoc />
	protected override double[] Neg_() => _C.Neg8();

	/// <inheritdoc />
	public sealed override Pga2Dbl Times(double factor) => Create_(_C.Times8(factor));

	/// <inheritdoc cref="Plus(S)"/>
	public sealed override Pga2Dbl Plus<B>(double scalar, B basis) => Create_(_C.Plus(scalar, basis));

	/// <inheritdoc cref="MinusR(IReadOnlyList{double})"/>
	public sealed override Pga2Dbl MinusR<B>(double scalar, B basis) => Create_(_C.MinusR(scalar, basis));

	/// <inheritdoc cref="Minus(P)"/>
	public sealed override Pga2Dbl Minus<B>(double scalar, B basis) => Create_(_C.Minus(scalar, basis));

	#endregion Binary Functions

}
