using System;
using System.Collections.Generic;
using org.SpocWeb.root.array;
using org.SpocWeb.root.data.hash;
using org.SpocWeb.root.extensions.enumerables;
using org.SpocWeb.root.Attributes;

namespace org.SpocWeb.root.maths.pga.ga;

/// <summary> Abstract base for a 1D Clifford algebra G(p,q,r) with DIM=1 and 2¹=2 components
/// (scalar + one basis blade), used by <see cref="R001"/>, <see cref="R010"/>, <see cref="R100"/>. </summary>
/// <remarks>
/// By implementing <see cref="IReadOnlyList{Single}"/>, operators need only be defined once;<br/>
/// however, to support list arguments on the left and resolve ambiguity,
/// all three operator overloads are still required.
/// </remarks>
[DocState(Pass = 2, MTime = "2026-05-24T15:36:37Z", Digest = "02bbefd031b5de1e23cab1c76caa4ce0da83652f124d8f12389b219001ffe0b0", Stale = false, Path = "ga/AGeoGebra2.cs", Since = "2026-10-06")]
[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
[Tags("code/abstract_base", "code/clifford_algebra")]
[System.ComponentModel.Description("Abstract base for a 1D Clifford algebra G(p,q,r) with DIM=1 and 2¹=2 components (scalar + one basis blade), used by R001, R010, R100.")]
[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
public abstract class AGeoGebra2<T> : AGeoGebra<T>
	where T : AGeoGebra2<T> 
{
	/// <summary> Dimensionality of the R^3 Basis-Vector-Space </summary>
	public const int DIM = 1;
	/// <summary> Dimensionality of the E(3) euclidean Multi-Vector-Space </summary>
	public const int NUM_COORDS = 1 << DIM;
	/// <inheritdoc />
	public override byte Dim => DIM;

	protected readonly float[] _C;
	//public IReadOnlyList<float> C => _C;
	/// <inheritdoc />
	public sealed override float this[int idx] => _C[idx];
	//set => C[idx] = value;

	/// <inheritdoc />
	public override bool Equals(T? that) => ReferenceEquals(that, this) || Equals(that?._C);

	/// <inheritdoc />
	public sealed override IEnumerator<float> GetEnumerator() => _C.AsEnumerable().GetEnumerator();

	/// <summary>Unchecked private Constructor for Speed<br/>
	/// Initializes a new instance of <see cref="AGeoGebra2"/> with the specified <paramref name="f"/> and <paramref name="idx"/>.</summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/abstract_base", "code/clifford_algebra")]
	[System.ComponentModel.Description("Unchecked private Constructor for Speed Initializes a new instance of AGeoGebra2 with the specified f and idx.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	protected AGeoGebra2(float[] f) => _C = f;//: this((IReadOnlyList<float>) f) { }
	/// <summary>Initializes a new instance of <see cref="AGeoGebra2"/> with the specified <paramref name="f"/> and <paramref name="idx"/>.</summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/abstract_base", "code/clifford_algebra")]
	[System.ComponentModel.Description("Initializes a new instance of AGeoGebra2 with the specified f and idx.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	protected AGeoGebra2(double f, int idx = 0) {
		var arr = new float[Count];
		arr[idx] = (float) f;
		_C = arr;
	}

	/// <summary> Checked Constructor </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/abstract_base", "code/clifford_algebra")]
	[System.ComponentModel.Description("Checked Constructor")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	protected AGeoGebra2(IReadOnlyList<float> f) {
		if (f.Count != Count) {
			throw new ArgumentOutOfRangeException("Must have " + Count + " Components, but has " + f.Count);
		}
		_C = f.ToArray();
	}

	/// <inheritdoc />
	public sealed override int ValueHash() => _C.BuildHashCode();
	/// <inheritdoc cref="Equals(T?)"/>
	public override bool Equals(IReadOnlyList<float>? that) {
		if (ReferenceEquals(that, _C)) return true;
		if (that is null) return false;
		return that.IsCloseTo(this);
		//return that.IsEqualTo(this);
	}

	#region Unary Functions

	/// <inheritdoc />
	public sealed override T Reverted() => Create_(_C.Reverted2());

	/// <summary> Main involution </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/abstract_base", "code/clifford_algebra")]
	[System.ComponentModel.Description("Main involution")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public sealed override T Involute () => Create_(_C.Involute2());

	/// <summary> Clifford Conjugate </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/abstract_base", "code/clifford_algebra")]
	[System.ComponentModel.Description("Clifford Conjugate")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public sealed override T Conjugate () => Create_(_C.CliffCjg2());

	#endregion Unary Functions

	#region Binary Functions

	/// <inheritdoc />
	public sealed override T Plus<S>(S b) => Create_(_C.Plus2(b));

	/// <inheritdoc />
	public sealed override IReadOnlyList<float> Minus<P>(P subtrahend) => Minus(subtrahend._C);

	/// <inheritdoc cref="Minus(P)"/>
	public sealed override T Minus(IReadOnlyList<float> b) => Create_(_C.Minus2(b));
	/// <inheritdoc />
	public sealed override T MinusR(IReadOnlyList<float> b) => Create_(b.Minus2(_C));

	/// <inheritdoc />
	protected sealed override float[] Neg_() => _C.Neg2();

	/// <inheritdoc />
	public sealed override float[] Per(float b) => _C.Times2(1/b);
	/// <inheritdoc />
	public sealed override float[] Times(float b) => _C.Times2(b);

	/// <inheritdoc cref="Plus(S)"/>
	public sealed override T Plus<B>(double scalar, B basis) => Create_(_C.Plus2(scalar, basis));

	/// <inheritdoc cref="MinusR(IReadOnlyList{float})"/>
	public sealed override T MinusR<B>(double scalar, B basis) => Create_(_C.MinusR2(scalar, basis));

	/// <inheritdoc cref="Minus(P)"/>
	public sealed override T Minus<B>(double scalar, B basis) => Create_(_C.Minus2(scalar, basis));

	/// <inheritdoc cref="Minus(P)"/>
	public T Minus(float b) => Create_(_C.Minus2(b));

	#endregion Binary Functions

}
