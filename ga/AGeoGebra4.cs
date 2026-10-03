using System;
using System.Collections.Generic;
using org.SpocWeb.root.array;
using org.SpocWeb.root.data.hash;
using org.SpocWeb.root.extensions.enumerables;

namespace org.SpocWeb.root.maths.pga.ga;

/// <summary> Abstract base for a 2D Clifford algebra G(p,q,r) with DIM=2 and 2²=4 components,
/// used by e.g. <see cref="R110"/>, <see cref="R011"/>. </summary>
/// <remarks>
/// By implementing <see cref="IReadOnlyList{Single}"/>, Operators would need to be defined only once.
/// But to support Lists from the Left and to resolve the resulting Ambiguity you still have to define all 3 Operators.
/// </remarks>
/// <inheritdoc />
/// <example>
/// <code language="yaml">
/// pass: 2
/// mtime: 2026-05-24T15:36:37Z
/// digest: f2722d39b6b986124f56c6acfc07003ef1621738a39b38489b1b2c28801a84be
/// tags: [code/abstract_base, code/clifford_algebra]
/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
/// facets: {layer: domain, status: stable, complexity: 2}
/// </code>
/// </example>
public abstract class AGeoGebra4<T> : AGeoGebra<T>
	where T : AGeoGebra4<T> 
{
	/// <summary>Specifies the constant dIM.</summary>
	public const int DIM = 2;
	/// <summary>Specifies the constant nUM_ COORDS.</summary>
	public const int NUM_COORDS = 1 << DIM;
	/// <inheritdoc />
	public sealed override byte Dim => DIM;

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
	/// Initializes a new instance of <see cref="AGeoGebra4"/> with the specified <paramref name="f"/> and <paramref name="idx"/>.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/abstract_base, code/clifford_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 2}
	/// </code>
	/// </example>
	protected AGeoGebra4(float[] f) => _C = f;//: this((IReadOnlyList<float>) f) { }
	/// <summary>Initializes a new instance of <see cref="AGeoGebra4"/> with the specified <paramref name="f"/> and <paramref name="idx"/>.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/abstract_base, code/clifford_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 2}
	/// </code>
	/// </example>
	protected AGeoGebra4(double f, int idx = 0) {
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
	protected AGeoGebra4(IReadOnlyList<float> f) {
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
	public sealed override T Reverted() => Create_(_C.Reverted4());

	/// <summary> Main involution </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/abstract_base, code/clifford_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 2}
	/// </code>
	/// </example>
	public sealed override T Involute () => Create_(_C.Involute4());

	/// <summary> Clifford Conjugate </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/abstract_base, code/clifford_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 2}
	/// </code>
	/// </example>
	public sealed override T Conjugate () => Create_(_C.CliffCjg4());

	#endregion Unary Functions

	#region Binary Functions

	/// <inheritdoc />
	public sealed override T Plus<S>(S b) => Create_(_C.Plus4(b));

	/// <inheritdoc />
	public sealed override IReadOnlyList<float> Minus<P>(P subtrahend) => Minus(subtrahend._C);

	/// <inheritdoc cref="Minus(P)"/>
	public sealed override T Minus(IReadOnlyList<float> b) => Create_(_C.Minus4(b));
	/// <inheritdoc />
	public sealed override T MinusR(IReadOnlyList<float> b) => Create_(b.Minus4(_C));

	/// <inheritdoc />
	protected sealed override float[] Neg_() => _C.Neg4();

	/// <inheritdoc />
	public sealed override float[] Per(float b) => _C.Times4(1/b);
	/// <inheritdoc />
	public sealed override float[] Times(float b) => _C.Times4(b);

	/// <inheritdoc cref="Plus(S)"/>
	public sealed override T Plus<B>(double scalar, B basis) => Create_(_C.Plus(scalar, basis));

	/// <inheritdoc cref="MinusR(IReadOnlyList{float})"/>
	public sealed override T MinusR<B>(double scalar, B basis) => Create_(_C.MinusR(scalar, basis));

	/// <inheritdoc cref="Minus(P)"/>
	public sealed override T Minus<B>(double scalar, B basis) => Create_(_C.Minus(scalar, basis));

	/// <inheritdoc cref="Minus(P)"/>
	public T Minus(float b) => Create_(_C.Minus4(b));

	#endregion Binary Functions

}
