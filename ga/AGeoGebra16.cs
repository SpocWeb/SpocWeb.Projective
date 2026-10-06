using System;
using System.Collections.Generic;
using org.SpocWeb.root.array;
using org.SpocWeb.root.data.hash;
using org.SpocWeb.root.extensions.enumerables;
using org.SpocWeb.root.logging;
using org.SpocWeb.root.Attributes;

namespace org.SpocWeb.root.maths.pga.ga;

/// <summary> Abstract base for a 4D Clifford algebra G(p,q,r) with DIM=4 and 2⁴=16 components,<br/>
/// used for e.g. G(3,0,1) PGA or G(3,1,0) STA. </summary>
/// <remarks>
/// By implementing <see cref="IReadOnlyList{Single}"/>, Operators would need to be defined only once.
/// But to support Lists from the Left and to resolve the resulting Ambiguity you still have to define all 3 Operators.
/// </remarks>
[DocState(Pass = 2, MTime = "2026-05-24T15:36:37Z", Digest = "6275ed53197fcf9ceca35652aaf078cb4103ccebfa7af002dd36410258a74f7c", Stale = false, Path = "ga/AGeoGebra16.cs", Since = "2026-10-06")]
[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
[Tags("code/abstract_base", "code/clifford_algebra")]
[System.ComponentModel.Description("Abstract base for a 4D Clifford algebra G(p,q,r) with DIM=4 and 2⁴=16 components, used for e.g. G(3,0,1) PGA or G(3,1,0) STA.")]
[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
public abstract class AGeoGebra16<T> : AGeoGebra<T>
	where T : AGeoGebra16<T> 
{
	/// <summary>Specifies the constant dIM.</summary>
	public const int DIM = 4;
	/// <inheritdoc />
	public override byte Dim => DIM;
	/// <summary>Specifies the constant nUM_ COORDS.</summary>
	public const int NUM_COORDS = 1 << DIM;

	/// <summary> Creates a 16-component coefficient array with <paramref name="value"/> at position <paramref name="pos"/> and zeros elsewhere. </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/abstract_base", "code/clifford_algebra")]
	[System.ComponentModel.Description("Creates a 16-component coefficient array with value at position pos and zeros elsewhere.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
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

	//public bool IsApprox(T? that) => ReferenceEquals(that, this) || Equals(that?._C);
	/// <inheritdoc />
	public override bool Equals(T? that) => ReferenceEquals(that, this) || Equals(that?._C);

	/// <inheritdoc />
	public sealed override IEnumerator<float> GetEnumerator() => _C.AsEnumerable().GetEnumerator();

	/// <summary> Unchecked private Constructor for Speed </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/abstract_base", "code/clifford_algebra")]
	[System.ComponentModel.Description("Unchecked private Constructor for Speed")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	protected AGeoGebra16(float[] f) { //: this((IReadOnlyList<float>) f) { }
#if DEBUG
		f.Length.ShouldBe(Count);
#endif //DEBUG
		_C = f;
	}

	/// <summary>Initializes a new instance of <see cref="AGeoGebra16"/> with the specified <paramref name="f"/> and <paramref name="idx"/>.</summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/abstract_base", "code/clifford_algebra")]
	[System.ComponentModel.Description("Initializes a new instance of AGeoGebra16 with the specified f and idx.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	protected AGeoGebra16(double f, int idx = 0) {
		var arr = new float[Count];
		if (idx < 0) {
			arr[-idx] = (float) -f;
		} else {
			arr[idx] = (float) f;
		}

		_C = arr;
	}

	/// <summary> Checked Constructor </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/abstract_base", "code/clifford_algebra")]
	[System.ComponentModel.Description("Checked Constructor")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	protected AGeoGebra16(IReadOnlyList<float> f) {
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

	#region Unary, involutory Functions

	/// <inheritdoc cref="XPga3D.Reverted16"/>
	public sealed override T Reverted() => Create_(_C.Reverted16());

	/// <inheritdoc cref="XPga3D.Involute16"/>
	public sealed override T Involute() => Create_(_C.Involute16());

	/// <inheritdoc cref="XPga3D.CliffCjg16"/>
	public sealed override T Conjugate() => Create_(_C.CliffCjg16());

	#endregion Unary, involutory Functions

	#region Binary Functions

	/// <inheritdoc cref="Plus(IReadOnlyList{float})"/>
	public sealed override T Plus<B>(double scalar, B basis) => Create_(_C.Plus16(scalar, basis));

	/// <inheritdoc cref="XPga3D.Minus16"/>
	public sealed override T Minus(IReadOnlyList<float> b) => Create_(_C.Minus16(b));

	/// <inheritdoc cref="XPga3D.Minus16"/>
	public sealed override T Plus(IReadOnlyList<float> b) => Create_(_C.Plus16(b));

	/// <inheritdoc />
	public sealed override float[] Per(float b) => _C.Times16(1/b);
	/// <inheritdoc cref="XPga3D.Times16"/>
	public sealed override float[] Times(float factor) => _C.Times16(factor);

	/// <inheritdoc cref="XPga3D.Plus16"/>
	public sealed override T Plus<S>(S addend) => Create_(_C.Plus16(addend));

	/// <inheritdoc cref="Minus(IReadOnlyList{float})"/>
	public sealed override IReadOnlyList<float> Minus<P>(P subtrahend) => Minus(subtrahend._C);

	/// <inheritdoc />
	public sealed override T MinusR(IReadOnlyList<float> b) => Create_(b.Minus16(_C));

	/// <inheritdoc />
	protected sealed override float[] Neg_() => _C.Neg16();

	/// <inheritdoc cref="MinusR(IReadOnlyList{float})"/>
	public sealed override T MinusR<B>(double scalar, B basis) => Create_(_C.MinusR16(scalar, basis));

	/// <inheritdoc cref="Minus(IReadOnlyList{float})"/>
	public sealed override T Minus<B>(double scalar, B basis) => Create_(_C.Minus16(scalar, basis));

	#endregion Binary Functions

}
