using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace org.SpocWeb.root.maths.pga.ga;

/// <summary> 1D <a href='https://en.wikipedia.org/wiki/Split-complex_number'
/// >Hyperbolic Numbers</a>: Boosting only </summary>
/// <remarks>
/// ## Public Methods
///
/// | Line | Method | Description |
/// |--:|---|---|
/// | 64 | <see cref="Blades"/> | Gets the blades. |
/// | 77 | <see cref="ProductOuter"/> | Gets the product Outer. |
/// | 86 | <see cref="ProductGeometric"/> | Gets the product Geometric. |
/// | 95 | <see cref="ProductDot"/> | Gets the product Dot. |
/// | 101 | <see cref="Products"/> | Gets the products. |
/// | 106 | <see cref="New"/> | Creates a new R100 hyperbolic number multivector from the given component array. |
/// | 122 | <see cref="this[]"/> | Gets or sets the element at the specified index. |
/// | 126 | <see cref="R100"/> | Initializes a new instance of R100 with the specified f and idx. |
/// | 128 | <see cref="R100"/> | Initializes a new instance of R100 with the specified f and idx. |
/// | 134 | <see cref="R100"/> | Checked Constructor with Copy |
///
/// ## Collaborators
///
/// | Type | Role |
/// |---|---|
/// | <see cref="R100"/> | Returned by a method. |
/// | <see cref="Base"/> | Nested enum. |
/// </remarks>
///
/// <example>
/// <code language="yaml">
/// pass: 2
/// mtime: 2026-05-24T15:36:37Z
/// digest: 5fefc57fb9037fa2bee617c37d6ea13a04b8e297bca15dfe418323bbd22a5232
/// tags: [code/clifford_algebra]
/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
/// facets: {layer: domain, status: stable, complexity: 2}
/// </code>
/// </example>
public class R100 : AGeoGebra2<R100>
{
	/// <summary> basis names for debug and print output </summary>
	public static string[] _Basis = { "","h" };
	/// <inheritdoc />
	/// <example>
	/// <code language="yaml">
	/// pass: 2
	/// mtime: 2026-05-24T15:36:37Z
	/// digest: 2f457a885fc8a8285b2147e0690a162e33cae42bff4b56ee9bc524abbeeca7a4
	/// </code>
	/// </example>
	public override IReadOnlyList<string> Basis => _Basis;

	/// <inheritdoc />
	public override R100 Self() => this;

	/// <summary> Base-Blades in 1D, usable as Indices for Components </summary>
	/// <example>
	/// <code language="yaml">
	/// pass: 2
	/// mtime: 2026-06-17T05:58:40Z
	/// digest: 2f457a885fc8a8285b2147e0690a162e33cae42bff4b56ee9bc524abbeeca7a4
	/// tags: [code/enum, code/clifford_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 1}
	/// </code>
	/// </example>
	[SuppressMessage("ReSharper", "InconsistentNaming")]
	public enum Base : sbyte
	{
		/// <summary> [0] Scalar Part </summary>
		_1_,

		/// <summary> [1] h-Direction h� = 1 </summary>
		h,

		/// <summary> No Component; signals both the End of Components and 0-Elements in the Cayley Tables below </summary>
		_0,// = sbyte.MinValue
	}

	#region basis blades
	public static R100 _1_ = new(1f, Base._1_);
	public static R100 E1 = new(1, Base.h);
	public static R100 I = E1;

	/// <summary>Gets the _ Blades.<br/>
	/// Gets the blades.</summary>
	static readonly R100[] _Blades = {_1_,E1};
	/// <summary>Gets the blades.</summary>
	public static readonly R100[] Blades = _Blades;
	#endregion basis blades


	#region Cayley Tables for different Products in R1,0,0

	/// <summary>Gets the _ Product Outer.</summary>
	static readonly Base[][] _ProductOuter = {
		new[] {Base._1_, Base.h},
		new[] {Base.h, Base._0},
	};

	/// <summary>Gets the product Outer.</summary>
	public static readonly IReadOnlyList<IReadOnlyList<Base>> ProductOuter = _ProductOuter;

	/// <summary>Gets the _ Product Geometric.</summary>
	static readonly Base[][] _ProductGeometric = {
		new[] {Base._1_, Base.h},
		new[] {Base.h, Base._1_},
	};

	/// <summary>Gets the product Geometric.</summary>
	public static readonly IReadOnlyList<IReadOnlyList<Base>> ProductGeometric = _ProductGeometric;

	/// <summary>Gets the _ Product Dot.</summary>
	static readonly Base[][] _ProductDot = {
		new[] {Base._1_, Base.h}, 
		new[] {Base.h, Base._1_},
	};

	/// <summary>Gets the product Dot.</summary>
	public static readonly IReadOnlyList<IReadOnlyList<Base>> ProductDot = _ProductDot;

	/// <summary>Gets the _ Products.<br/>
	/// Gets the products.</summary>
	static readonly Base[][][] _Products = { _ProductGeometric, _ProductDot, _ProductOuter};
	/// <summary>Gets the products.</summary>
	public static readonly IReadOnlyList<IReadOnlyList<IReadOnlyList<Base>>> Products = _Products;

	#endregion Cayley Tables for different Products in R3,0,0

	/// <summary> Creates a new <see cref="R100"/> hyperbolic number multivector from the given component array. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/clifford_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 2}
	/// </code>
	/// </example>
	public static R100 New(params float[] f) => New((IReadOnlyList<float>) f);
	/// <inheritdoc cref="New(float[])"/>
	public static R100 New(IReadOnlyList<float> f) => new(f);
	/// <inheritdoc cref="New(float[])"/>
	public static R100 New(double f = 0, int idx = 0) => new(f, idx);
	/// <inheritdoc cref="New(float[])"/>
	public static R100 New(double f = 0, Base idx = 0) => new(f, idx);

	/// <inheritdoc />
	public override R100 Create(IReadOnlyList<float> values) => new(values);
	/// <inheritdoc cref="Create(IReadOnlyList{float})"/>
	public override R100 Create(IList<float> values) => new((IReadOnlyList<float>)values);
	/// <inheritdoc />
	protected override R100 Create_(float[] values) => new(values);

	/// <summary>Gets or sets the element at the specified <paramref name="index"/>.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/clifford_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 2}
	/// </code>
	/// </example>
	public float this[Base idx] => _C[(int) idx];

	/// <summary>Initializes a new instance of <see cref="R100"/> with the specified <paramref name="f"/> and <paramref name="idx"/>.<br/>
	/// Initializes a new instance of <see cref="R100"/> with the specified <paramref name="f"/> and <paramref name="idx"/>.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/clifford_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 2}
	/// </code>
	/// </example>
	public R100(double f = 0, Base idx = 0) : base(f, (int)idx) {}
	/// <summary>Initializes a new instance of <see cref="R100"/> with the specified <paramref name="f"/> and <paramref name="idx"/>.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/clifford_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 2}
	/// </code>
	/// </example>
	public R100(double f = 0, int idx = 0) : base(f, idx) {}

	/// <summary> Unchecked private Constructor for Speed </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/clifford_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 2}
	/// </code>
	/// </example>
	R100(float[] f) : base(f) {}

	/// <summary> Checked Constructor with Copy </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/clifford_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 2}
	/// </code>
	/// </example>
	public R100(IReadOnlyList<float> values) : base(values) {}

	/// <summary> Ideal norm. (signed) </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/clifford_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 2}
	/// </code>
	/// </example>
	public override double NormI() => this[1] != 0 ? this[1] : Norm();

	/// <inheritdoc />
	protected override double[][] Coefficients() => throw new NotSupportedException();

	/// <inheritdoc />
	public override R100 Dual() => new(_C.Dual2());
	/// <inheritdoc />
	public override double NormSqr() => _C.NormSqr2R100();

	/// <inheritdoc />
	public override R100 Dot(IReadOnlyList<float> that) => new(_C.Dot2R010H(that));
	/// <inheritdoc />
	public override R100 Join(IReadOnlyList<float> that) => new(_C.Join2(that));
	/// <inheritdoc />
	public override R100 Meet(IReadOnlyList<float> that) => new(_C.Meet2(that));
	/// <inheritdoc />
	public override R100 MeetR(IReadOnlyList<float> that) => new(that.Meet2(_C));
	/// <inheritdoc />
	public override R100 Times(IReadOnlyList<float> that) => new(_C.Times2R010H(that));
	/// <inheritdoc />
	public override R100 TimesR(IReadOnlyList<float> that) => new(that.Times2R010H(_C));
}
