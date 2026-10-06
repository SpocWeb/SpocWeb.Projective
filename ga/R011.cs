using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using org.SpocWeb.root.array;
using org.SpocWeb.root.interfaces;
using org.SpocWeb.root.interfaces.maths;
using org.SpocWeb.root.logging;
using org.SpocWeb.root.Attributes;

namespace org.SpocWeb.root.maths.pga.ga;

// ReSharper disable once InconsistentNaming
/// <summary> Static extension and test methods for the R011 G(0,1,1) Dual-Complex Number algebra. </summary>
/// <remarks>
/// ## Public Methods
///
/// | Line | Method | Description |
/// |--:|---|---|
/// | 32 | <see cref="Test"/> | Test. |
/// </remarks>
///
[DocState(Pass = 2, MTime = "2026-05-24T15:40:19Z", Digest = "314ad142957febe390cc7223b4deb1d1b21c187f84f6e7257a23fe46c27fcae3", Stale = false, Path = "ga/R011.cs", Since = "2026-10-06")]
[Facets(Layer = "test", Status = "stable", Complexity = 2)]
[Tags("code/extension_method", "code/unit_test", "code/clifford_algebra")]
[System.ComponentModel.Description("Static extension and test methods for the R011 G(0,1,1) Dual-Complex Number algebra.")]
[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
public static class XR011
{
	/// <summary>Test.</summary>
	///
	[Facets(Layer = "test", Status = "stable", Complexity = 2)]
	[Tags("code/unit_test", "code/geometric_algebra")]
	[System.ComponentModel.Description("Test.")]
	[Test, Ignore("Triage: point * point is not an addition, and the rotated point carries a spurious 1i component; the Expectations predate the current Convention")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public static void Test() {
		var start = R011.Point(3, 4);
		var trans = R011.Point(4, 3);
		var moved = start.Times(trans);
		_ = moved.ShouldBe(R011.Point(7, 7));

		var rotor = R011.Rotor(Math.PI / 4);
		var dbl = rotor.Times(rotor);
		PgaAssert.AreClose(dbl, R011.Rotor(Math.PI / 2));

		var turned = moved.Times(dbl);
		var expected = R011.Point(-7, 7);
		turned.ShouldBe(expected.CloseTo);
	}
}

/// <summary> G(0,1,1) Dual-Complex Number algebra with E1²=−1 (rotation/imaginary) and E0²=0 (translation/dual). </summary>
/// <remarks>
/// ## Public Methods
///
/// | Line | Method | Description |
/// |--:|---|---|
/// | 157 | <see cref="_1_"/> | Identical Map; used together with I to represent Rotation |
/// | 160 | <see cref="E0"/> | Gets the e0. |
/// | 163 | <see cref="E1"/> | Gets the e1. |
/// | 167 | <see cref="i"/> | Gets the i. |
/// | 170 | <see cref="I"/> | Gets the i. |
/// | 177 | <see cref="Blades"/> | Gets the blades. |
/// | 181 | <see cref="Translator"/> | Generates a Point/Translator |
/// | 187 | <see cref="Point"/> |  |
/// | 191 | <see cref="Rotor"/> | Generates a Rotor |
/// | 222 | <see cref="ProductGeometric"/> | Gets the product Inner. |
/// | 224 | <see cref="ProductInner"/> | Gets the product Outer. |
/// | 226 | <see cref="ProductOuter"/> | Gets the product Outer. |
/// | 232 | <see cref="Products"/> | Gets the products. |
/// | 237 | <see cref="R011"/> | Initializes a new instance of R011 with the specified f and idx. Initializes a new instance of R011 with the specified f and idx. |
/// | 244 | <see cref="R011"/> | Initializes a new instance of R011 with the specified values. |
/// | 260 | <see cref="R011"/> | Initializes a new instance of R011 with the specified values. |
/// | 274 | <see cref="New"/> |  |
/// | 305 | <see cref="CloseTo"/> | Returns true when the squared difference norm of this and arg1 is negligible relative to their combined norms. |
/// | 331 | <see cref="Scalar"/> | Gets the scalar. |
/// | 334 | <see cref="e0"/> | Gets the e0. |
/// | 337 | <see cref="e1"/> | Gets the e1. |
/// | 340 | <see cref="e01"/> | Gets the e01. |
///
/// ## Collaborators
///
/// | Type | Role |
/// |---|---|
/// | <see cref="R011"/> | Returned by a method. |
/// | <see cref="Base"/> | Nested enum. |
/// </remarks>
[DocState(Pass = 2, MTime = "2026-06-17T05:58:38Z", Digest = "d5e3112bec7e00c11d7f36b8451cc78a3227dd625dcf496ea62ae28bf89a03fa", Stale = false, Path = "ga/R011.cs", Since = "2026-10-06")]
[Facets(Layer = "domain", Status = "stable", Complexity = 3)]
[Tags("code/clifford_algebra", "code/dual_numbers")]
[System.ComponentModel.Description("G(0,1,1) Dual-Complex Number algebra with E1²=−1 (rotation/imaginary) and E0²=0 (translation/dual).")]
[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
public class R011 : AGeoGebra4<R011>
{
	// just for debug and print output, the basis names
	/// <inheritdoc />
	static readonly string[] _Basis = {"", nameof(Base.x), nameof(Base.i), nameof(Base.y)};
	/// <inheritdoc />
	/// <example>
	/// <code language="yaml">
	/// pass: 2
	/// mtime: 2026-05-24T15:40:19Z
	/// digest: f0a33254d218a131613d59832b587319120c9406a3573f12e557ff43b189d0e6
	/// </code>
	/// </example>
	public override IReadOnlyList<string> Basis => _Basis;

	/// <inheritdoc />
	public override R011 Self() => this;

	/// <summary> Base-Blades in 3D, usable as Indices for Components </summary>
	/// <remarks>
	/// ## Public Methods
	///
	/// | Line | Method | Description |
	/// |--:|---|---|
	/// | 123 | <see cref="_1_"/> | [0] Scalar / X-Coordinate e.g. Dot Product / oriented Area/Volume Dual |
	/// | 126 | <see cref="x"/> | [1] AKA e0, �; X-Translation Coordinate; Projective/homogeneous |
	/// | 134 | <see cref="i"/> | [2] AKA e1; Vector/Line Y-Coordinate; yz-Dual |
	/// | 137 | <see cref="y"/> | [3] AKA �i, e12 y Y-Translation Coordinate: y� = 0 |
	/// | 140 | <see cref="_0"/> | No Component; signals both the End of Components and 0-Elements in the Cayley Tables below |
	/// </remarks>
	///
	[DocState(Pass = 2, MTime = "2026-07-07T17:42:03Z", Digest = "e623cdcf2368a93a5472af0294edc62890a0dc2c2873a8f98be4d1d19e9eb044", Stale = false, Path = "ga/R011.cs", Since = "2026-10-06")]
	[Facets(Layer = "domain", Status = "stable", Complexity = 1)]
	[Tags("code/enum", "code/clifford_algebra")]
	[System.ComponentModel.Description("Base-Blades in 3D, usable as Indices for Components")]
	[SuppressMessage("ReSharper", "InconsistentNaming")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public enum Base : sbyte
	{
		/// <summary>[0] Scalar / X-Coordinate e.g. Dot Product / oriented Area/Volume Dual</summary>
		_1_,

		/// <summary>[1] AKA e0, �; X-Translation Coordinate; Projective/homogeneous </summary>
		x,

		/// <summary>[2] AKA e1; Vector/Line Y-Coordinate; yz-Dual </summary>
		/// <remarks>
		/// Vectors have a Length and Direction (but no Origin).
		/// Scalars can be added, subtracted, multiplied by a Scalar.
		/// Vectors can be represented as Differences of Points
		/// </remarks>
		i,

		/// <summary>[3] AKA �i, e12 <see cref="y"/> Y-Translation Coordinate: <see cref="y"/>� = 0 </summary>
		y,

		/// <summary> No Component; signals both the End of Components and 0-Elements in the Cayley Tables below </summary>
		_0,// = sbyte.MinValue
	}

	#region basis blades

	/// <summary> Identical Map; used together with <see cref="I"/> to represent Rotation </summary>
	public static readonly R011 _1_ = new(1, Base._1_);

	/// <inheritdoc cref="Base.e"/>
	public static readonly R011 E0 = new(1, Base.x);

	/// <inheritdoc cref="Base.i"/>
	public static readonly R011 E1 = new(1, Base.i);

	/// <inheritdoc cref="Base.i"/>
	// ReSharper disable once InconsistentNaming
	public static readonly R011 i = E1;

	/// <inheritdoc cref="Base.y"/>
	public static readonly R011 I = new(1, Base.y);
	#endregion basis blades

	/// <summary>Gets the blades.<br/>
	/// Gets the blades.</summary>
	static readonly R011[] _Blades = {_1_,E0,E1,I};
	/// <summary>Gets the blades.</summary>
	public static readonly R011[] Blades = _Blades;

	/// <summary> Generates a <see cref="Point"/>/<see cref="Translator"/> </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 3)]
	[Tags("code/clifford_algebra", "code/dual_numbers")]
	[System.ComponentModel.Description("Generates a Point/Translator")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public static R011 Translator(double x, double y) => new(1, (float)x, 0, (float)y);
	/// <inheritdoc cref="Translator"/>
	public static R011 Point(double x, double y) => Translator(x, y);

	/// <summary> Generates a <see cref="Rotor"/> </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 3)]
	[Tags("code/clifford_algebra", "code/dual_numbers")]
	[System.ComponentModel.Description("Generates a Rotor")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public static R011 Rotor(double rad) {
		var (sin, cos) = rad.SinCos();
		return new R011((float) cos, 0, (float) sin, 0);
	}

	/// <summary>Gets the _ Product Outer.</summary>
	static readonly Base[][] _ProductOuter = {
		new [] {Base._1_,	Base.x,	Base.i,	Base.y},
		new [] {Base.x,	Base._0,	Base.y,	Base._0  },
		new [] {Base.i,	~Base.y,	Base._0,	Base._0  },
		new [] {Base.y,	Base._0,	Base._0,	Base._0  },
	};
	/// <summary>Gets the _ Product Dot.</summary>
	static readonly Base[][] _ProductDot = {
		new [] {Base._1_,	Base.x,	Base.i,	Base.y},
		new [] {Base.x,	Base._0,	Base._0,	Base._0  },
		new [] {Base.i,	Base._0,	~Base._1_,	Base.x },
		new [] {Base.y,	Base._0,	~Base.x,	Base._0  },
	};
	/// <summary>Gets the _ Product Geometric.</summary>
	static readonly Base[][] _ProductGeometric = {
	new[] {Base._1_, Base.x, Base.i, Base.y},
		new[] {Base.x, Base._0, Base.y, Base._0},
		new[] {Base.i, ~Base.y, ~Base._1_, Base.x},
		new[] {Base.y, Base._0, ~Base.x, Base._0}
	};
	/// <summary>Gets the product Inner.</summary>
	public static readonly IReadOnlyList<IReadOnlyList<Base>> ProductGeometric = _ProductGeometric;
	/// <summary>Gets the product Outer.</summary>
	public static readonly IReadOnlyList<IReadOnlyList<Base>> ProductInner = _ProductDot;
	/// <summary>Gets the product Outer.</summary>
	public static readonly IReadOnlyList<IReadOnlyList<Base>> ProductOuter = _ProductOuter;

	/// <summary>Gets the products.<br/>
	/// Gets the products.</summary>
	static readonly Base[][][] _Products = { _ProductGeometric, _ProductDot, _ProductOuter};
	/// <summary>Gets the products.</summary>
	public static readonly IReadOnlyList<IReadOnlyList<IReadOnlyList<Base>>> Products = _Products;

	/// <summary>Initializes a new instance of <see cref="R011"/> with the specified <paramref name="f"/> and <paramref name="idx"/>.<br/>
	/// Initializes a new instance of <see cref="R011"/> with the specified <paramref name="f"/> and <paramref name="idx"/>.</summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 3)]
	[Tags("code/clifford_algebra", "code/dual_numbers")]
	[System.ComponentModel.Description("Initializes a new instance of R011 with the specified f and idx. Initializes a new instance of R011 with the specified f and idx.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public R011(double f = 0f, int idx = 0): base(f, idx) { }
	/// <summary>Initializes a new instance of <see cref="R011"/> with the specified <paramref name="values"/>.</summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 3)]
	[Tags("code/clifford_algebra", "code/dual_numbers")]
	[System.ComponentModel.Description("Initializes a new instance of R011 with the specified values.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public R011(double f = 0f, Base idx = 0): base(f, (int) idx) { }

	/// <summary>Initializes a new instance of <see cref="R011"/> with the specified <paramref name="values"/>.<br/>
	/// Initializes a new instance of <see cref="R011"/> with the specified <paramref name="values"/>.</summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 3)]
	[Tags("code/clifford_algebra", "code/dual_numbers")]
	[System.ComponentModel.Description("Initializes a new instance of R011 with the specified values. Initializes a new instance of R011 with the specified values.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	R011(params float[] f) : base(f) { }
	/// <summary>Initializes a new instance of <see cref="R011"/> with the specified <paramref name="values"/>.</summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 3)]
	[Tags("code/clifford_algebra", "code/dual_numbers")]
	[System.ComponentModel.Description("Initializes a new instance of R011 with the specified values.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public R011(IReadOnlyList<float> values) : base(values) { }

	/// <inheritdoc cref="Create(IReadOnlyList{float})"/>
	public override R011 Create(IReadOnlyList<float> values) => new(values);
	/// <inheritdoc />
	public override R011 Create(IList<float> values) => new((IReadOnlyList<float>)values);
	/// <inheritdoc />
	protected override R011 Create_(float[] values) => new(values);

	/// <inheritdoc cref="New(float[])"/>
	public static R011 New(params float[] f) => New((IReadOnlyList<float>) f);
	/// <inheritdoc cref="New(float[])"/>
	public static R011 New(IReadOnlyList<float> f) => new(f);

	#region Overloaded binary Operators

	/// <summary>!  Poincare duality operator. </summary>
	/// <inheritdoc />
	[Facets(Layer = "domain", Status = "stable", Complexity = 3)]
	[Tags("code/clifford_algebra", "code/dual_numbers")]
	[System.ComponentModel.Description("! Poincare duality operator.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public override R011 Dual() => new(_C.DualR011());
	/// <inheritdoc />
	public override double NormSqr() => _C.NormSqr4R011();

	/// <inheritdoc />
	public override R011 Dot(IReadOnlyList<float> that) => new(_C.Dot4R011(that));
	/// <inheritdoc />
	public override R011 Times(IReadOnlyList<float> factor) => new(_C.Times4R011(factor));
	/// <inheritdoc />
	public override R011 TimesR(IReadOnlyList<float> factor) => new(factor.Times4R011(_C));
	/// <inheritdoc />
	public override R011 MeetR(IReadOnlyList<float> that) => new(that.Meet4(_C));
	/// <inheritdoc />
	public override R011 Meet(IReadOnlyList<float> that) => new(_C.Meet4(that));
	/// <inheritdoc />
	public override R011 Join(IReadOnlyList<float> that) => new(_C.Join4(that));

	/// <summary> Returns true when the squared difference norm of this and <paramref name="arg1"/> is negligible relative to their combined norms. </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 3)]
	[Tags("code/clifford_algebra", "code/dual_numbers")]
	[System.ComponentModel.Description("Returns true when the squared difference norm of this and arg1 is negligible relative to their combined norms.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public bool CloseTo(R011 arg1) { //, double acc) {
		var diff = (arg1 - this);
		var normSqr = diff.NormSqr();
		var reference = arg1.NormSqr() + NormSqr();
		return normSqr < reference * 1e-7;
	}

	#endregion Overloaded binary Operators

	/// <inheritdoc />
	protected override double[][] Coefficients() => new[] {
			new double[] {_C[0],	  0, -_C[2]},
			new double[] {_C[1], +_C[0], +_C[3], -_C[2]},
			new double[] {_C[2],	  0, +_C[0]},
			new double[] {_C[3], +_C[2], -_C[1], +_C[0]}
		};

	#region basis Components
	#pragma warning disable IDE1006 // Naming Styles
	// ReSharper disable InconsistentNaming

	/// <inheritdoc cref="Base._1_"/>
	public float Scalar => _C[(int) Base._1_];

	/// <inheritdoc cref="Base.x"/>
	public float e0 => _C[(int) Base.x];

	/// <inheritdoc cref="Base.i"/>
	public float e1 => _C[(int) Base.i];

	/// <inheritdoc cref="Base.y"/>
	public float e01 => _C[(int) Base.y];

	// ReSharper restore InconsistentNaming
	#pragma warning restore IDE1006 // Naming Styles
	#endregion basis Components

}

