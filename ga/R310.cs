using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using org.SpocWeb.root.array;

namespace org.SpocWeb.root.maths.pga.ga;

/// <summary> R310 AKA 2D CGA (Conformal Geometric Algebra) R^4 Relativistic Vector-Space with Rotations and Reflections </summary>
/// <remarks>
/// Used for the SpaceTime algebra, and 3D Hyperbolic Projective Geometric Algebra.
/// Elements represent points (vectors), point-pairs (biVectors), lines and circles (triVectors).
/// The even subalgebra includes rotations, translations and Dilations as conformal 2D transformations.
/// 
/// circles are primitives. 
/// In CGA/<see cref="R310"/>,there are two null vectors, and they combine to make the pseudo-scalar invertible.
/// In PGA/<see cref="Pga3D"/>, with only one null vector, the pseudo-scalar is a null blade, and not invertible.
/// Rather than division by the pseudo-scalar, a J-map between R*d,0,1 (where the vectors represent hyperplanes)
/// and its dual space Rd,0,1 (where the vectors represent points) is introduced yielding 2 dual Spaces.
/// In Practice this Mapping is rarely needed though. 
/// </remarks>
/// <example>
/// <code language="yaml">
/// pass: 2
/// mtime: 2026-05-24T15:36:37Z
/// digest: 6c1aaee5cad5dc761875b9255d666ed142869aa8eb3ecc760872bda65a9b69f6
/// tags: [code/clifford_algebra, code/conformal_geometric_algebra]
/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
/// facets: {layer: domain, status: stable, complexity: 3}
/// </code>
/// </example>
public class R310 : AGeoGebra16<R310>
{
	// just for debug and print output, the basis names
	/// <summary>Gets the _ Basis.</summary>
	static readonly string[] _Basis = { "","e1","e2","e3","e4","e12","e13","e14","e23","e24","e34","e123","e124","e134","e234","e1234" };
	/// <inheritdoc />
	/// <example>
	/// <code language="yaml">
	/// pass: 2
	/// mtime: 2026-05-24T15:36:37Z
	/// digest: 0b797fffa11d80d71d3b8de1502c95c070dc8d31f07790315e162f492c51e283
	/// </code>
	/// </example>
	public override IReadOnlyList<string> Basis => _Basis;

	/// <inheritdoc />
	public override R310 Self() => this;

	/// <summary> Base-Blades in 3D, usable as Indices for Components </summary>
	/// <example>
	/// <code language="yaml">
	/// pass: 2
	/// mtime: 2026-06-17T05:58:47Z
	/// digest: 0468984f7c2e23d3b138fad394112200b60502b6844b19f136a91ee26852ec32
	/// tags: [code/enum, code/clifford_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 1}
	/// </code>
	/// </example>
	[SuppressMessage("ReSharper", "InconsistentNaming")]
	public enum Base : sbyte
	{
		/// <summary> [0] Scalar e.g. Dot Product or oriented Volume </summary>
		_1_,

		/// <summary>[1] X-Direction (polar) / yz-Mirror e1� = 1<br/>
		/// [2] Y-Direction (polar) / zx-Mirror e2� = 1</summary>
		e1,
		/// <summary>Represents e2.</summary>
		e2,
		/// <summary> [3] Z-Direction (polar) / xy-Mirror e3� = 1 </summary>
		e3,
		/// <summary> [4] T-Direction (polar) / xy-Mirror e4� = -1 </summary>
		e4,

		/// <summary>[5] axial X-BiVector<br/>
		/// [6] axial Y-BiVector</summary>
		e12,
		/// <summary>Represents e13.</summary>
		e13,
		/// <summary> [7] -BiVector </summary>
		e14,
		/// <summary> [8] -BiVector </summary>
		e23,
		/// <summary> [9] -BiVector </summary>
		e24,
		/// <summary> [10] -BiVector </summary>
		e34,

		/// <summary>[11] TriVector<br/>
		/// [12] TriVector</summary>
		e123,
		/// <summary>Represents e124.</summary>
		e124,
		/// <summary> [13] TriVector </summary>
		e134,
		/// <summary> [14] TriVector </summary>
		e234,

		/// <summary> [15] TriVector </summary>
		e1234,

		/// <summary> No Component; signals both the End of Components and 0-Elements in the Cayley Tables below </summary>
		_0,// = sbyte.MinValue
	}

	#region Cayley Tables for different Products in R3,0,0

	/// <summary>Gets the _ Product Outer.</summary>
	static readonly Base[][] _ProductOuter = {
		new[] {Base._1_, Base.e1, Base.e2, Base.e3, Base.e4, Base.e12, Base.e13, Base.e14, Base.e23, Base.e24, Base.e34,
			Base.e123, Base.e124, Base.e134, Base.e234, Base.e1234},
		new[] {Base.e1, Base._0, Base.e12, Base.e13, Base.e14, Base._0, Base._0, Base._0, Base.e123, Base.e124,
			Base.e134, Base._0, Base._0, Base._0, Base.e1234, Base._0},
		new[] {Base.e2, ~Base.e12, Base._0, Base.e23, Base.e24, Base._0, ~Base.e123, ~Base.e124, Base._0, Base._0,
			Base.e234, Base._0, Base._0, ~Base.e1234, Base._0, Base._0},
		new[] {Base.e3, ~Base.e13, ~Base.e23, Base._0, Base.e34, Base.e123, Base._0, ~Base.e134, Base._0, ~Base.e234,
			Base._0, Base._0, Base.e1234, Base._0, Base._0, Base._0},
		new[] {Base.e4, ~Base.e14, ~Base.e24, ~Base.e34, Base._0, Base.e124, Base.e134, Base._0, Base.e234, Base._0,
			Base._0, ~Base.e1234, Base._0, Base._0, Base._0, Base._0},
		new[] {Base.e12, Base._0, Base._0, Base.e123, Base.e124, Base._0, Base._0, Base._0, Base._0, Base._0,
			Base.e1234, Base._0, Base._0, Base._0, Base._0, Base._0},
		new[] {Base.e13, Base._0, ~Base.e123, Base._0, Base.e134, Base._0, Base._0, Base._0, Base._0, ~Base.e1234,
			Base._0, Base._0, Base._0, Base._0, Base._0, Base._0},
		new[] {Base.e14, Base._0, ~Base.e124, ~Base.e134, Base._0, Base._0, Base._0, Base._0, Base.e1234, Base._0,
			Base._0, Base._0, Base._0, Base._0, Base._0, Base._0},
		new[] {Base.e23, Base.e123, Base._0, Base._0, Base.e234, Base._0, Base._0, Base.e1234, Base._0, Base._0,
			Base._0, Base._0, Base._0, Base._0, Base._0, Base._0},
		new[] {Base.e24, Base.e124, Base._0, ~Base.e234, Base._0, Base._0, ~Base.e1234, Base._0, Base._0, Base._0,
			Base._0, Base._0, Base._0, Base._0, Base._0, Base._0},
		new[] {Base.e34, Base.e134, Base.e234, Base._0, Base._0, Base.e1234, Base._0, Base._0, Base._0, Base._0,
			Base._0, Base._0, Base._0, Base._0, Base._0, Base._0},
		new[] {Base.e123, Base._0, Base._0, Base._0, Base.e1234, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0,
			Base._0, Base._0, Base._0, Base._0, Base._0},
		new[] {Base.e124, Base._0, Base._0, ~Base.e1234, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0,
			Base._0, Base._0, Base._0, Base._0, Base._0},
		new[] {Base.e134, Base._0, Base.e1234, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0,
			Base._0, Base._0, Base._0, Base._0, Base._0},
		new[] {Base.e234, ~Base.e1234, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0,
			Base._0, Base._0, Base._0, Base._0, Base._0},
		new[] {Base.e1234, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0,
			Base._0, Base._0, Base._0, Base._0, Base._0},
	};

	/// <summary>Gets the product Outer.</summary>
	public static readonly IReadOnlyList<IReadOnlyList<Base>> ProductOuter = _ProductOuter;

	/// <summary>Gets the _ Product Geometric.</summary>
	static readonly Base[][] _ProductGeometric = {
		new[] {Base._1_, Base.e1, Base.e2, Base.e3, Base.e4, Base.e12, Base.e13, Base.e14, Base.e23, Base.e24, Base.e34,
			Base.e123, Base.e124, Base.e134, Base.e234, Base.e1234},
		new[] {Base.e1, Base._1_, Base.e12, Base.e13, Base.e14, Base.e2, Base.e3, Base.e4, Base.e123, Base.e124,
			Base.e134, Base.e23, Base.e24, Base.e34, Base.e1234, Base.e234},
		new[] {Base.e2, ~Base.e12, Base._1_, Base.e23, Base.e24, ~Base.e1, ~Base.e123, ~Base.e124, Base.e3, Base.e4,
			Base.e234, ~Base.e13, ~Base.e14, ~Base.e1234, Base.e34, ~Base.e134},
		new[] {Base.e3, ~Base.e13, ~Base.e23, Base._1_, Base.e34, Base.e123, ~Base.e1, ~Base.e134, ~Base.e2, ~Base.e234,
			Base.e4, Base.e12, Base.e1234, ~Base.e14, ~Base.e24, Base.e124},
		new[] {Base.e4, ~Base.e14, ~Base.e24, ~Base.e34, ~Base._1_, Base.e124, Base.e134, Base.e1, Base.e234, Base.e2,
			Base.e3, ~Base.e1234, ~Base.e12, ~Base.e13, ~Base.e23, Base.e123},
		new[] {Base.e12, ~Base.e2, Base.e1, Base.e123, Base.e124, ~Base._1_, ~Base.e23, ~Base.e24, Base.e13, Base.e14,
			Base.e1234, ~Base.e3, ~Base.e4, ~Base.e234, Base.e134, ~Base.e34},
		new[] {Base.e13, ~Base.e3, ~Base.e123, Base.e1, Base.e134, Base.e23, ~Base._1_, ~Base.e34, ~Base.e12,
			~Base.e1234, Base.e14, Base.e2, Base.e234, ~Base.e4, ~Base.e124, Base.e24},
		new[] {Base.e14, ~Base.e4, ~Base.e124, ~Base.e134, ~Base.e1, Base.e24, Base.e34, Base._1_, Base.e1234, Base.e12,
			Base.e13, ~Base.e234, ~Base.e2, ~Base.e3, ~Base.e123, Base.e23},
		new[] {Base.e23, Base.e123, ~Base.e3, Base.e2, Base.e234, ~Base.e13, Base.e12, Base.e1234, ~Base._1_, ~Base.e34,
			Base.e24, ~Base.e1, ~Base.e134, Base.e124, ~Base.e4, ~Base.e14},
		new[] {Base.e24, Base.e124, ~Base.e4, ~Base.e234, ~Base.e2, ~Base.e14, ~Base.e1234, ~Base.e12, Base.e34,
			Base._1_, Base.e23, Base.e134, Base.e1, Base.e123, ~Base.e3, ~Base.e13},
		new[] {Base.e34, Base.e134, Base.e234, ~Base.e4, ~Base.e3, Base.e1234, ~Base.e14, ~Base.e13, ~Base.e24,
			~Base.e23, Base._1_, ~Base.e124, ~Base.e123, Base.e1, Base.e2, Base.e12},
		new[] {Base.e123, Base.e23, ~Base.e13, Base.e12, Base.e1234, ~Base.e3, Base.e2, Base.e234, ~Base.e1,
			~Base.e134, Base.e124, ~Base._1_, ~Base.e34, Base.e24, ~Base.e14, ~Base.e4},
		new[] {Base.e124, Base.e24, ~Base.e14, ~Base.e1234, ~Base.e12, ~Base.e4, ~Base.e234, ~Base.e2, Base.e134,
			Base.e1, Base.e123, Base.e34, Base._1_, Base.e23, ~Base.e13, ~Base.e3},
		new[] {Base.e134, Base.e34, Base.e1234, ~Base.e14, ~Base.e13, Base.e234, ~Base.e4, ~Base.e3, ~Base.e124,
			~Base.e123, Base.e1, ~Base.e24, ~Base.e23, Base._1_, Base.e12, Base.e2},
		new[] {Base.e234, ~Base.e1234, Base.e34, ~Base.e24, ~Base.e23, ~Base.e134, Base.e124, Base.e123, ~Base.e4,
			~Base.e3, Base.e2, Base.e14, Base.e13, ~Base.e12, Base._1_, ~Base.e1},
		new[] {Base.e1234, ~Base.e234, Base.e134, ~Base.e124, ~Base.e123, ~Base.e34, Base.e24, Base.e23, ~Base.e14,
			~Base.e13, Base.e12, Base.e4, Base.e3, ~Base.e2, Base.e1, ~Base._1_},
	};

	/// <summary>Gets the product Geometric.</summary>
	public static readonly IReadOnlyList<IReadOnlyList<Base>> ProductGeometric = _ProductGeometric;

	/// <summary>Gets the _ Product Dot.</summary>
	static readonly Base[][] _ProductDot = {
		new[] {Base._1_, Base.e1, Base.e2, Base.e3, Base.e4, Base.e12, Base.e13, Base.e14, Base.e23, Base.e24, Base.e34,
			Base.e123, Base.e124, Base.e134, Base.e234, Base.e1234},
		new[] {Base.e1, Base._1_, Base._0, Base._0, Base._0, Base.e2, Base.e3, Base.e4, Base._0, Base._0, Base._0,
			Base.e23, Base.e24, Base.e34, Base._0, Base.e234},
		new[] {Base.e2, Base._0, Base._1_, Base._0, Base._0, ~Base.e1, Base._0, Base._0, Base.e3, Base.e4, Base._0,
			~Base.e13, ~Base.e14, Base._0, Base.e34, ~Base.e134},
		new[] {Base.e3, Base._0, Base._0, Base._1_, Base._0, Base._0, ~Base.e1, Base._0, ~Base.e2, Base._0, Base.e4,
			Base.e12, Base._0, ~Base.e14, ~Base.e24, Base.e124},
		new[] {Base.e4, Base._0, Base._0, Base._0, ~Base._1_, Base._0, Base._0, Base.e1, Base._0, Base.e2, Base.e3,
			Base._0, ~Base.e12, ~Base.e13, ~Base.e23, Base.e123},
		new[] {Base.e12, ~Base.e2, Base.e1, Base._0, Base._0, ~Base._1_, Base._0, Base._0, Base._0, Base._0, Base._0,
			~Base.e3, ~Base.e4, Base._0, Base._0, ~Base.e34},
		new[] {Base.e13, ~Base.e3, Base._0, Base.e1, Base._0, Base._0, ~Base._1_, Base._0, Base._0, Base._0, Base._0,
			Base.e2, Base._0, ~Base.e4, Base._0, Base.e24},
		new[] {Base.e14, ~Base.e4, Base._0, Base._0, ~Base.e1, Base._0, Base._0, Base._1_, Base._0, Base._0, Base._0,
			Base._0, ~Base.e2, ~Base.e3, Base._0, Base.e23},
		new[] {Base.e23, Base._0, ~Base.e3, Base.e2, Base._0, Base._0, Base._0, Base._0, ~Base._1_, Base._0, Base._0,
			~Base.e1, Base._0, Base._0, ~Base.e4, ~Base.e14},
		new[] {Base.e24, Base._0, ~Base.e4, Base._0, ~Base.e2, Base._0, Base._0, Base._0, Base._0, Base._1_, Base._0,
			Base._0, Base.e1, Base._0, ~Base.e3, ~Base.e13},
		new[] {Base.e34, Base._0, Base._0, ~Base.e4, ~Base.e3, Base._0, Base._0, Base._0, Base._0, Base._0, Base._1_,
			Base._0, Base._0, Base.e1, Base.e2, Base.e12},
		new[] {Base.e123, Base.e23, ~Base.e13, Base.e12, Base._0, ~Base.e3, Base.e2, Base._0, ~Base.e1, Base._0,
			Base._0, ~Base._1_, Base._0, Base._0, Base._0, ~Base.e4},
		new[] {Base.e124, Base.e24, ~Base.e14, Base._0, ~Base.e12, ~Base.e4, Base._0, ~Base.e2, Base._0, Base.e1,
			Base._0, Base._0, Base._1_, Base._0, Base._0, ~Base.e3},
		new[] {Base.e134, Base.e34, Base._0, ~Base.e14, ~Base.e13, Base._0, ~Base.e4, ~Base.e3, Base._0, Base._0,
			Base.e1, Base._0, Base._0, Base._1_, Base._0, Base.e2},
		new[] {Base.e234, Base._0, Base.e34, ~Base.e24, ~Base.e23, Base._0, Base._0, Base._0, ~Base.e4, ~Base.e3,
			Base.e2, Base._0, Base._0, Base._0, Base._1_, ~Base.e1},
		new[] {Base.e1234, ~Base.e234, Base.e134, ~Base.e124, ~Base.e123, ~Base.e34, Base.e24, Base.e23, ~Base.e14,
			~Base.e13, Base.e12, Base.e4, Base.e3, ~Base.e2, Base.e1, ~Base._1_},
	};

	/// <summary>Gets the product Dot.</summary>
	public static readonly IReadOnlyList<IReadOnlyList<Base>> ProductDot = _ProductDot;

	/// <summary>Gets the _ Products.<br/>
	/// Gets the products.</summary>
	static readonly Base[][][] _Products = { _ProductGeometric, _ProductDot, _ProductOuter};
	/// <summary>Gets the products.</summary>
	public static readonly IReadOnlyList<IReadOnlyList<IReadOnlyList<Base>>> Products = _Products;

	#endregion Cayley Tables for different Products in R3,0,0

	#region basis blades
	// ReSharper disable InconsistentNaming
	/// <summary>Gets the _1_.</summary>
	public static readonly R310 _1_ = new(1, Base._1_);
	/// <summary>Gets the e1.</summary>
	public static readonly R310 e1 = new(1, Base.e1);
	/// <summary>Gets the e2.</summary>
	public static readonly R310 e2 = new(1, Base.e2);
	/// <summary>Gets the e3.</summary>
	public static readonly R310 e3 = new(1, Base.e3);
	/// <summary>Gets the e4.</summary>
	public static readonly R310 e4 = new(1, Base.e4);
	/// <summary>Gets the e12.</summary>
	public static readonly R310 e12 = new(1, Base.e12);
	/// <summary>Gets the e13.</summary>
	public static readonly R310 e13 = new(1, Base.e13);
	/// <summary>Gets the e14.</summary>
	public static readonly R310 e14 = new(1, Base.e14);
	/// <summary>Gets the e23.</summary>
	public static readonly R310 e23 = new(1, Base.e23);
	/// <summary>Gets the e24.</summary>
	public static readonly R310 e24 = new(1, Base.e24);
	/// <summary>Gets the e34.</summary>
	public static readonly R310 e34 = new(1, Base.e34);
	/// <summary>Gets the e123.</summary>
	public static readonly R310 e123 = new(1, Base.e123);
	/// <summary>Gets the e234.</summary>
	public static readonly R310 e234 = new(1, Base.e234);
	/// <summary>Gets the e134.</summary>
	public static readonly R310 e134 = new(1, Base.e134);
	/// <summary>Gets the e124.</summary>
	public static readonly R310 e124 = new(1, Base.e124);
	/// <summary>Gets the e1234.</summary>
	public static readonly R310 e1234 = new(1, Base.e1234);
	// ReSharper restore InconsistentNaming
	#endregion basis blades

	/// <summary>Gets the _ Blades.</summary>
	static readonly R310[] _Blades = { _1_
		, e1, e2, e3, e4
		, e12, e13, e14, e23, e24, e34
		, e123, e234, e134, e124
		, e1234};
	public static IReadOnlyList<R310> Blades = _Blades;

	/// <summary> Creates a new <see cref="R310"/> G(3,1,0) multivector from the given component array. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/clifford_algebra, code/conformal_geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 3}
	/// </code>
	/// </example>
	public static R310 New(params float[] f) => New((IReadOnlyList<float>) f);
	/// <inheritdoc cref="New(float[])"/>
	public static R310 New(IReadOnlyList<float> f) => new(f);
	/// <inheritdoc cref="New(float[])"/>
	public static R310 New(double f = 0, int idx = 0) => new(f, idx);
	/// <inheritdoc cref="New(float[])"/>
	public static R310 New(double f = 0, Base idx = 0) => new(f, idx);

	/// <summary>Gets or sets the element at the specified <paramref name="index"/>.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/clifford_algebra, code/conformal_geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 3}
	/// </code>
	/// </example>
	public float this[Base idx] => _C[(int) idx];

	/// <summary>Initializes a new instance of <see cref="R310"/> with the specified <paramref name="f"/> and <paramref name="idx"/>.<br/>
	/// Initializes a new instance of <see cref="R310"/> with the specified <paramref name="f"/> and <paramref name="idx"/>.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/clifford_algebra, code/conformal_geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 3}
	/// </code>
	/// </example>
	public R310(double f = 0, Base idx = 0) : base(f, (int)idx) {}
	/// <summary>Initializes a new instance of <see cref="R310"/> with the specified <paramref name="f"/> and <paramref name="idx"/>.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/clifford_algebra, code/conformal_geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 3}
	/// </code>
	/// </example>
	public R310(double f = 0, int idx = 0) : base(f, idx) {}

	/// <summary> Unchecked private Constructor for Speed </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/clifford_algebra, code/conformal_geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 3}
	/// </code>
	/// </example>
	R310(float[] f) : base(f) {}

	/// <summary> Checked Constructor with Copy </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/clifford_algebra, code/conformal_geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 3}
	/// </code>
	/// </example>
	public R310(IReadOnlyList<float> values) : base(values) {}

	/// <inheritdoc />
	public override R310 Dual() => New(_C.Dual16());
	/// <inheritdoc />
	public override double NormSqr() => _C.NormSqr16R310();

	/// <inheritdoc />
	public override R310 Dot(IReadOnlyList<float> b) => new(_C.Dot16P(b));

	/// <inheritdoc />
	public override R310 Join(IReadOnlyList<float> b) => New(_C.Join16P(b));

	/// <inheritdoc />
	public override R310 Times(IReadOnlyList<float> factor) => new(_C.Times16R(factor));
	/// <inheritdoc />
	public override R310 TimesR(IReadOnlyList<float> factor) => new(factor.Times16R(_C));

	/// <inheritdoc />
	public override R310 Meet(IReadOnlyList<float> that) => new(_C.Meet16P(that));
	/// <inheritdoc />
	public override R310 MeetR(IReadOnlyList<float> that)=> new(that.Meet16P(_C));

	/// <inheritdoc />
	public override R310 Create(IReadOnlyList<float> values) => new(values);
	/// <inheritdoc cref="Create(IReadOnlyList{float})"/>
	public override R310 Create(IList<float> values) => new((IReadOnlyList<float>)values);
	/// <inheritdoc />
	protected override R310 Create_(float[] values) => new(values);

	/// <inheritdoc />
	protected override double[][] Coefficients() => new[] {
			   new double[] { _C[00], _C[01], +_C[02], +_C[03], -_C[04], -_C[05], -_C[06], +_C[07], -_C[08], +_C[09], +_C[10], -_C[11], +_C[12], +_C[13], +_C[14], -_C[15],
			}, new double[] { _C[01], _C[00], -_C[05], -_C[06], +_C[07], +_C[02], +_C[03], -_C[04], -_C[11], +_C[12], +_C[13], -_C[08], +_C[09], +_C[10], -_C[15], +_C[14],
			}, new double[] { _C[02], _C[05], +_C[00], -_C[08], +_C[09], -_C[01], +_C[11], -_C[12], +_C[03], -_C[04], +_C[14], +_C[06], -_C[07], +_C[15], +_C[10], -_C[13],
			}, new double[] { _C[03], _C[06], +_C[08], +_C[00], +_C[10], -_C[11], -_C[01], -_C[13], -_C[02], -_C[14], -_C[04], -_C[05], -_C[15], -_C[07], -_C[09], +_C[12],
			}, new double[] { _C[04], _C[07], +_C[09], +_C[10], +_C[00], -_C[12], -_C[13], -_C[01], -_C[14], -_C[02], -_C[03], -_C[15], -_C[05], -_C[06], -_C[08], +_C[11],
			}, new double[] { _C[05], _C[02], -_C[01], +_C[11], -_C[12], +_C[00], -_C[08], +_C[09], +_C[06], -_C[07], +_C[15], +_C[03], -_C[04], +_C[14], -_C[13], +_C[10],
			}, new double[] { _C[06], _C[03], -_C[11], -_C[01], -_C[13], +_C[08], +_C[00], +_C[10], -_C[05], -_C[15], -_C[07], -_C[02], -_C[14], -_C[04], +_C[12], -_C[09],
			}, new double[] { _C[07], _C[04], -_C[12], -_C[13], -_C[01], +_C[09], +_C[10], +_C[00], -_C[15], -_C[05], -_C[06], -_C[14], -_C[02], -_C[03], +_C[11], -_C[08],
			}, new double[] { _C[08], _C[11], +_C[03], -_C[02], -_C[14], -_C[06], +_C[05], +_C[15], +_C[00], +_C[10], -_C[09], +_C[01], +_C[13], -_C[12], -_C[04], +_C[07],
			}, new double[] { _C[09], _C[12], +_C[04], -_C[14], -_C[02], -_C[07], +_C[15], +_C[05], +_C[10], +_C[00], -_C[08], +_C[13], +_C[01], -_C[11], -_C[03], +_C[06],
			}, new double[] { _C[10], _C[13], +_C[14], +_C[04], -_C[03], -_C[15], -_C[07], +_C[06], -_C[09], +_C[08], +_C[00], -_C[12], +_C[11], +_C[01], +_C[02], -_C[05],
			}, new double[] { _C[11], _C[08], -_C[06], +_C[05], +_C[15], +_C[03], -_C[02], -_C[14], +_C[01], +_C[13], -_C[12], +_C[00], +_C[10], -_C[09], +_C[07], -_C[04],
			}, new double[] { _C[12], _C[09], -_C[07], +_C[15], +_C[05], +_C[04], -_C[14], -_C[02], +_C[13], +_C[01], -_C[11], +_C[10], +_C[00], -_C[08], +_C[06], -_C[03],
			}, new double[] { _C[13], _C[10], -_C[15], -_C[07], +_C[06], +_C[14], +_C[04], -_C[03], -_C[12], +_C[11], +_C[01], -_C[09], +_C[08], +_C[00], -_C[05], +_C[02],
			}, new double[] { _C[14], _C[15], +_C[10], -_C[09], +_C[08], -_C[13], +_C[12], -_C[11], +_C[04], -_C[03], +_C[02], +_C[07], -_C[06], +_C[05], +_C[00], -_C[01],
			}, new double[] { _C[15], _C[14], -_C[13], +_C[12], -_C[11], +_C[10], -_C[09], +_C[08], +_C[07], -_C[06], +_C[05], +_C[04], -_C[03], +_C[02], -_C[01], +_C[00]}};
}

