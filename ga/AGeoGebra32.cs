using System;
using System.Collections.Generic;
using org.SpocWeb.root.array;
using org.SpocWeb.root.data.hash;
using org.SpocWeb.root.extensions.enumerables;

namespace org.SpocWeb.root.maths.pga.ga;

/// <summary> Abstract base for a 5D Clifford algebra G(p,q,r) with DIM=5 and 2⁵=32 components,<br/>
/// used for e.g. G(4,1,0) CGA. </summary>
/// <remarks>
/// By implementing <see cref="IReadOnlyList{Single}"/>, Operators would need to be defined only once.
/// But to support Lists from the Left and to resolve the resulting Ambiguity you still have to define all 3 Operators.
/// </remarks>
/// <example>
/// <code language="yaml">
/// pass: 2
/// mtime: 2026-05-24T15:36:37Z
/// digest: 0f1f4e19b76f3099322e7421d691d955ae8bc3fb3f0325161c0f70d2f8f012a5
/// tags: [code/abstract_base, code/clifford_algebra]
/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
/// facets: {layer: domain, status: stable, complexity: 2}
/// </code>
/// </example>
public abstract class AGeoGebra32<T> : AGeoGebra<T>
	where T : AGeoGebra32<T>
{
	/// <summary>Specifies the constant dIM.</summary>
	public const int DIM = 5;
	/// <inheritdoc />
	public override byte Dim => DIM;
	/// <summary>Specifies the constant nUM_ COORDS.</summary>
	public const int NUM_COORDS = 1 << DIM;

	/// <summary> Creates a 32-component coefficient array with <paramref name="value"/> at position <paramref name="pos"/> and zeros elsewhere. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/abstract_base, code/clifford_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 2}
	/// </code>
	/// </example>
	public static float[] NEW(int pos, float value = 1) {
		var ret = new float[NUM_COORDS];
		ret[pos] = value;
		return ret;
	}

	/// <inheritdoc cref="NEW(int, float)"/>
	public static float[] NEW(int pos, double value) {
		var ret = new float[NUM_COORDS];
		ret[pos] = (float) value;
		return ret;
	}

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
	/// Initializes a new instance of <see cref="AGeoGebra32"/> with the specified <paramref name="f"/> and <paramref name="idx"/>.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/abstract_base, code/clifford_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 2}
	/// </code>
	/// </example>
	protected AGeoGebra32(float[] f) => _C = f;//: this((IReadOnlyList<float>) f) { }
	/// <summary>Initializes a new instance of <see cref="AGeoGebra32"/> with the specified <paramref name="f"/> and <paramref name="idx"/>.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/abstract_base, code/clifford_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 2}
	/// </code>
	/// </example>
	protected AGeoGebra32(double f, int idx = 0) {
		var arr = new float[Count];
		arr[idx] = (float) f;
		_C = arr;
	}

	/// <summary> Checked Constructor </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/abstract_base, code/clifford_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 2}
	/// </code>
	/// </example>
	protected AGeoGebra32(IReadOnlyList<float> f) {
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

	/// <inheritdoc cref="XPga3D.Reverted32"/>
	public sealed override T Reverted() => Create_(_C.Reverted32());

	/// <inheritdoc cref="XPga3D.Involute32"/>
	public sealed override T Involute () => Create_(_C.Involute32());

	/// <inheritdoc cref="XPga3D.Conjugate32"/>
	public sealed override T Conjugate () => Create_(_C.CliffCjg32());

	#endregion Unary Functions

	#region Binary Functions

	/// <inheritdoc cref="XR311.Minus32"/>
	public sealed override T Minus(IReadOnlyList<float> b) => Create_(_C.Minus32(b));

	/// <inheritdoc />
	public sealed override float[] Per(float b) => _C.Times32(1/b);
	/// <inheritdoc cref="XR311.Times32"/>
	public sealed override float[] Times(float scalar) => _C.Times32(scalar);

	/// <inheritdoc cref="XR311.Plus32"/>
	public sealed override T Plus<S>(S b) => Create_(_C.Plus32(b));

	/// <inheritdoc cref="Minus(IReadOnlyList{float})"/>
	public sealed override IReadOnlyList<float> Minus<P>(P subtrahend) => Minus(subtrahend._C);

	/// <inheritdoc />
	public sealed override T MinusR(IReadOnlyList<float> b) => Create_(b.Minus32(_C));

	/// <inheritdoc />
	protected sealed override float[] Neg_() => _C.Neg32();

	/// <inheritdoc cref="Plus(S)"/>
	public sealed override T Plus<B>(double scalar, B basis) => Create_(_C.Plus(scalar, basis));

	/// <inheritdoc cref="MinusR(IReadOnlyList{float})"/>
	public sealed override T MinusR<B>(double scalar, B basis) => Create_(_C.MinusR(scalar, basis));

	/// <inheritdoc cref="Minus(IReadOnlyList{float})"/>
	public sealed override T Minus<B>(double scalar, B basis) => Create_(_C.Minus(scalar, basis));

	#endregion Binary Functions

}
