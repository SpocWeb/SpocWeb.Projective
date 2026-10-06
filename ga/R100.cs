using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using org.SpocWeb.root.Attributes;

namespace org.SpocWeb.root.maths.pga.ga;

/// <summary> 1D <a href='https://en.wikipedia.org/wiki/Split-complex_number'
/// >Hyperbolic Numbers</a>: Boosting only </summary>
/// <remarks>
/// ## Public Methods
///
/// | Line | Method | Description |
/// |--:|---|---|
/// | 93 | <see cref="Blades"/> | Gets the blades. |
/// | 106 | <see cref="ProductOuter"/> | Gets the product Outer. |
/// | 115 | <see cref="ProductGeometric"/> | Gets the product Geometric. |
/// | 124 | <see cref="ProductDot"/> | Gets the product Dot. |
/// | 130 | <see cref="Products"/> | Gets the products. |
/// | 136 | <see cref="New"/> | Creates a new R100 hyperbolic number multivector from the given component array. |
/// | 157 | <see cref="this[]"/> | Gets or sets the element at the specified index. |
/// | 166 | <see cref="R100"/> | Initializes a new instance of R100 with the specified f and idx. Initializes a new instance of R100 with the specified f and idx. |
/// | 173 | <see cref="R100"/> | Initializes a new instance of R100 with the specified f and idx. |
/// | 189 | <see cref="R100"/> | Checked Constructor with Copy |
///
/// ## Collaborators
///
/// | Type | Role |
/// |---|---|
/// | <see cref="R100"/> | Returned by a method. |
/// | <see cref="Base"/> | Nested enum. |
/// </remarks>
///
[DocState(Pass = 2, MTime = "2026-05-24T15:36:37Z", Digest = "5fefc57fb9037fa2bee617c37d6ea13a04b8e297bca15dfe418323bbd22a5232", Stale = false, Path = "ga/R100.cs", Since = "2026-10-06")]
[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
[Tags("code/clifford_algebra")]
[System.ComponentModel.Description("1D Hyperbolic Numbers: Boosting only")]
[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
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
	/// <remarks>
	/// ## Public Methods
	///
	/// | Line | Method | Description |
	/// |--:|---|---|
	/// | 66 | <see cref="_1_"/> | [0] Scalar Part |
	/// | 69 | <see cref="h"/> | [1] h-Direction h� = 1 |
	/// | 72 | <see cref="_0"/> | No Component; signals both the End of Components and 0-Elements in the Cayley Tables below |
	/// </remarks>
	[DocState(Pass = 2, MTime = "2026-06-17T05:58:40Z", Digest = "2f457a885fc8a8285b2147e0690a162e33cae42bff4b56ee9bc524abbeeca7a4", Stale = false, Path = "ga/R100.cs", Since = "2026-10-06")]
	[Facets(Layer = "domain", Status = "stable", Complexity = 1)]
	[Tags("code/enum", "code/clifford_algebra")]
	[System.ComponentModel.Description("Base-Blades in 1D, usable as Indices for Components")]
	[SuppressMessage("ReSharper", "InconsistentNaming")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
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
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/clifford_algebra")]
	[System.ComponentModel.Description("Creates a new R100 hyperbolic number multivector from the given component array.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
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
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/clifford_algebra")]
	[System.ComponentModel.Description("Gets or sets the element at the specified index.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public float this[Base idx] => _C[(int) idx];

	/// <summary>Initializes a new instance of <see cref="R100"/> with the specified <paramref name="f"/> and <paramref name="idx"/>.<br/>
	/// Initializes a new instance of <see cref="R100"/> with the specified <paramref name="f"/> and <paramref name="idx"/>.</summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/clifford_algebra")]
	[System.ComponentModel.Description("Initializes a new instance of R100 with the specified f and idx. Initializes a new instance of R100 with the specified f and idx.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public R100(double f = 0, Base idx = 0) : base(f, (int)idx) {}
	/// <summary>Initializes a new instance of <see cref="R100"/> with the specified <paramref name="f"/> and <paramref name="idx"/>.</summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/clifford_algebra")]
	[System.ComponentModel.Description("Initializes a new instance of R100 with the specified f and idx.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public R100(double f = 0, int idx = 0) : base(f, idx) {}

	/// <summary> Unchecked private Constructor for Speed </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/clifford_algebra")]
	[System.ComponentModel.Description("Unchecked private Constructor for Speed")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	R100(float[] f) : base(f) {}

	/// <summary> Checked Constructor with Copy </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/clifford_algebra")]
	[System.ComponentModel.Description("Checked Constructor with Copy")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public R100(IReadOnlyList<float> values) : base(values) {}

	/// <summary> Ideal norm. (signed) </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/clifford_algebra")]
	[System.ComponentModel.Description("Ideal norm. (signed)")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
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
