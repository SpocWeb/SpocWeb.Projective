using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using org.SpocWeb.root.Attributes;

namespace org.SpocWeb.root.maths.pga.ga;

/// <summary> Real + Imaginary Complex Number Algebra with (<see cref="E1"/> = <see cref="I"/>)�=-1: Rotation only </summary>
/// <remarks>
/// This is isomorphic to the even subalgebra of <see cref="R200"/>.
/// 
/// </remarks>
[DocState(Pass = 2, MTime = "2026-05-24T15:36:37Z", Digest = "13ac15a49f743a6ffbcde863a4fa1d6f07a74708c550a84572e2315be436e433", Stale = false, Path = "ga/R010.cs", Since = "2026-10-06")]
[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
[Tags("code/clifford_algebra", "code/complex_math")]
[System.ComponentModel.Description("Real + Imaginary Complex Number Algebra with (E1 = I)�=-1: Rotation only")]
[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
public class R010 : AGeoGebra2<R010>
{
	/// <summary> basis names for debug and print output </summary>
	public static string[] _Basis = { "","i" };
	/// <inheritdoc />
	/// <example>
	/// <code language="yaml">
	/// pass: 2
	/// mtime: 2026-05-24T15:36:37Z
	/// digest: a5994f6a714f629b603fb9f06fd798b84e11b88cb796c044f93b42fd776480c5
	/// </code>
	/// </example>
	public override IReadOnlyList<string> Basis => _Basis;

	/// <inheritdoc />
	public override R010 Self() => this;

	/// <summary> Base-Blades in 3D, usable as Indices for Components </summary>
	/// <remarks>
	/// ## Public Methods
	///
	/// | Line | Method | Description |
	/// |--:|---|---|
	/// | 55 | <see cref="_1_"/> | [0] Scalar Part |
	/// | 58 | <see cref="i"/> | [1] AKA e1; imaginary Part i� = -1 |
	/// | 61 | <see cref="_0"/> | No Component; signals both the End of Components and 0-Elements in the Cayley Tables below |
	/// </remarks>
	[DocState(Pass = 2, MTime = "2026-06-17T05:58:36Z", Digest = "a5994f6a714f629b603fb9f06fd798b84e11b88cb796c044f93b42fd776480c5", Stale = false, Path = "ga/R010.cs", Since = "2026-10-06")]
	[Facets(Layer = "domain", Status = "stable", Complexity = 1)]
	[Tags("code/enum", "code/clifford_algebra")]
	[System.ComponentModel.Description("Base-Blades in 3D, usable as Indices for Components")]
	[SuppressMessage("ReSharper", "InconsistentNaming")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public enum Base : sbyte
	{
		/// <summary> [0] Scalar Part </summary>
		_1_,

		/// <summary> [1] AKA e1; imaginary Part i� = -1 </summary>
		i,

		/// <summary> No Component; signals both the End of Components and 0-Elements in the Cayley Tables below </summary>
		_0,// = sbyte.MinValue
	}

	#region basis blades
	public static R010 E1 = new(1, 1);
	public static R010 I = E1;
	public static R010 _1_ = new(1f, 0);

	/// <summary>Gets the _ Blades.<br/>
	/// Gets the blades.</summary>
	static readonly R010[] _Blades = {_1_,I};
	/// <summary>Gets the blades.</summary>
	public static readonly R010[] Blades = _Blades;
	#endregion basis blades


	#region Cayley Tables for different Products in R0, 1, 0

	/// <summary>Gets the _ Product Outer.</summary>
	static readonly Base[][] _ProductOuter = {
		new[] {Base._1_, Base.i},
		new[] {Base.i, Base._0},
	};

	/// <summary>Gets the product Outer.</summary>
	public static readonly IReadOnlyList<IReadOnlyList<Base>> ProductOuter = _ProductOuter;

	/// <summary>Gets the _ Product Geometric.</summary>
	static readonly Base[][] _ProductGeometric = {
		new[] {Base._1_, Base.i},
		new[] {Base.i, ~Base._1_},
	};

	/// <summary>Gets the product Geometric.</summary>
	public static readonly IReadOnlyList<IReadOnlyList<Base>> ProductGeometric = _ProductGeometric;

	/// <summary>Gets the _ Product Dot.</summary>
	static readonly Base[][] _ProductDot = {
		new[] {Base._1_, Base.i}, 
		new[] {Base.i, ~Base._1_},
	};

	/// <summary>Gets the product Dot.</summary>
	public static readonly IReadOnlyList<IReadOnlyList<Base>> ProductDot = _ProductDot;

	/// <summary>Gets the _ Products.<br/>
	/// Gets the products.</summary>
	static readonly Base[][][] _Products = { _ProductGeometric, _ProductDot, _ProductOuter};
	/// <summary>Gets the products.</summary>
	public static readonly IReadOnlyList<IReadOnlyList<IReadOnlyList<Base>>> Products = _Products;

	#endregion Cayley Tables for different Products in R0,1,0

	/// <summary> Creates a new <see cref="R010"/> complex number multivector from the given component array. </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/clifford_algebra", "code/complex_math")]
	[System.ComponentModel.Description("Creates a new R010 complex number multivector from the given component array.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public static R010 New(params float[] f) => New((IReadOnlyList<float>) f);
	/// <inheritdoc cref="New(float[])"/>
	public static R010 New(IReadOnlyList<float> f) => new(f);
	/// <inheritdoc cref="New(float[])"/>
	public static R010 New(double f = 0, int idx = 0) => new(f, idx);
	/// <inheritdoc cref="New(float[])"/>
	public static R010 New(double f = 0, Base idx = 0) => new(f, idx);

	/// <inheritdoc />
	public override R010 Create(IReadOnlyList<float> values) => new(values);
	/// <inheritdoc cref="Create(IReadOnlyList{float})"/>
	public override R010 Create(IList<float> values) => new((IReadOnlyList<float>)values);
	/// <inheritdoc />
	protected override R010 Create_(float[] values) => new(values);

	/// <summary>Gets or sets the element at the specified <paramref name="index"/>.</summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/clifford_algebra", "code/complex_math")]
	[System.ComponentModel.Description("Gets or sets the element at the specified index.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public float this[Base idx] => _C[(int) idx];

	/// <summary>Initializes a new instance of <see cref="R010"/> with the specified <paramref name="f"/> and <paramref name="idx"/>.<br/>
	/// Initializes a new instance of <see cref="R010"/> with the specified <paramref name="f"/> and <paramref name="idx"/>.</summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/clifford_algebra", "code/complex_math")]
	[System.ComponentModel.Description("Initializes a new instance of R010 with the specified f and idx. Initializes a new instance of R010 with the specified f and idx.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public R010(double f = 0, Base idx = 0) : base(f, (int)idx) {}
	/// <summary>Initializes a new instance of <see cref="R010"/> with the specified <paramref name="f"/> and <paramref name="idx"/>.</summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/clifford_algebra", "code/complex_math")]
	[System.ComponentModel.Description("Initializes a new instance of R010 with the specified f and idx.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public R010(double f = 0, int idx = 0) : base(f, idx) {}
	/// <summary>Initializes a new instance of <see cref="R010"/> with the specified <paramref name="c"/>.</summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/clifford_algebra", "code/complex_math")]
	[System.ComponentModel.Description("Initializes a new instance of R010 with the specified c.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public R010(Complex c) : base(new []{ (float)c.Real, (float)c.Imaginary}) {}

	/// <summary> Unchecked private Constructor for Speed </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/clifford_algebra", "code/complex_math")]
	[System.ComponentModel.Description("Unchecked private Constructor for Speed")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	R010(float[] f) : base(f) {}

	/// <summary> Checked Constructor with Copy </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/clifford_algebra", "code/complex_math")]
	[System.ComponentModel.Description("Checked Constructor with Copy")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public R010(IReadOnlyList<float> values) : base(values) {}

	/// <summary> Euclidean norm. (strict positive). </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/clifford_algebra", "code/complex_math")]
	[System.ComponentModel.Description("Euclidean norm. (strict positive).")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public override double NormSqr() => _C.NormSqr2R010();

	/// <summary> Ideal norm. (signed) </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/clifford_algebra", "code/complex_math")]
	[System.ComponentModel.Description("Ideal norm. (signed)")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public override double NormI() => this[1] != 0 ? this[1] : Norm();

	/// <inheritdoc />
	public override R010 Dual() => new(_C.Dual2C());

	/// <inheritdoc />
	public override R010 Dot(IReadOnlyList<float> that) => new(_C.Dot2R010C(that));
	/// <inheritdoc />
	public override R010 Join(IReadOnlyList<float> that) => new(_C.Join2(that));
	/// <inheritdoc />
	public override R010 Meet(IReadOnlyList<float> that) => new(_C.Meet2(that));
	/// <inheritdoc />
	public override R010 MeetR(IReadOnlyList<float> that) => new(that.Meet2(_C));
	/// <inheritdoc />
	public override R010 TimesR(IReadOnlyList<float> that) => new(that.Times2R010C(_C));
	/// <inheritdoc />
	public override R010 Times(IReadOnlyList<float> that) => new(_C.Times2R010C(that));

	/// <inheritdoc />
	protected override double[][] Coefficients() => throw new NotSupportedException();
}

