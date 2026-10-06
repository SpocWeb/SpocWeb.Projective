using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using org.SpocWeb.root.array;
using org.SpocWeb.root.interfaces.maths;
using org.SpocWeb.root.Attributes;

namespace org.SpocWeb.root.maths.pga.ga;

/// <summary> 2D Geometric Algebra: only Rotations </summary>
/// <remarks>
/// Apart from the Scalar, it has Vectors (Lines through the origin) and a single Rotation in the 2D Plane.
/// The even-Grade subalgebra formed by <see cref="_1_"/> and <see cref="I"/> is isomorphic to the complex numbers <see cref="R010"/>.
/// The odd-Grade sub-algebra represents a Translation.
/// 
/// The full <see cref="R200"/> can represent a full euclidean Transformation in 2D
/// by first performing a pure Rotation and then a pure Translation by the Vector.
/// This is not a geometric Algebra Operation though.
/// </remarks>
/// <inheritdoc />
[DocState(Pass = 2, MTime = "2026-05-24T15:36:37Z", Digest = "11990ae2cf6ff53abbd70c38fa724e000f9781251b5d7969612b15ee17d0f9b7", Stale = false, Path = "ga/R200.cs", Since = "2026-10-06")]
[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
[Tags("code/clifford_algebra")]
[System.ComponentModel.Description("2D Geometric Algebra: only Rotations")]
[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
public class R200 : AGeoGebra4<R200>
{
	// just for debug and print output, the basis names
	/// <inheritdoc />
	public override IReadOnlyList<string> Basis => _Basis;
	/// <summary>Gets the _ Basis.</summary>
	static readonly string[] _Basis = { "","x","y","I" };
	/// <summary>Gets the _ Basis No.</summary>
	static readonly string[] _BasisNo = { "","e1","e2","e12" };
	public static IReadOnlyList<string> BasisNo = _BasisNo;

	/// <inheritdoc />
	public override R200 Self() => this;

	/// <summary> Base-Blades in 3D, usable as Indices for Components </summary>
	///
	/// <remarks>
	/// The Value of the <see cref="Base"/> also represents the Grade.
	/// For Processing it would actually be better
	/// to group the even and the odd Grades,
	/// because they will typically be used together.
	/// Mixed Grades are only intermediary. 
	/// </remarks>
	[DocState(Pass = 2, MTime = "2026-05-24T15:36:37Z", Digest = "8368fe411343467d8d1e0f0b4b97907e945cdc795126cdaa4a7ed69c2b74a80f", Stale = false, Path = "ga/R200.cs", Since = "2026-10-06")]
	[Facets(Layer = "domain", Status = "stable", Complexity = 1)]
	[Tags("code/enum", "code/clifford_algebra")]
	[System.ComponentModel.Description("Base-Blades in 3D, usable as Indices for Components")]
	[SuppressMessage("ReSharper", "InconsistentNaming")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public enum Base : sbyte
	{
		/// <summary> [0] Scalar e.g. Dot Product or oriented Volume </summary>
		_1_,

		/// <summary> [1] X-Direction; e1� = 1 </summary>
		e1,

		/// <summary> [2] Y-Direction; e2� = 1 </summary>
		e2,

		/// <summary> [3] AKA i; Pseudo-Scalar; i� = -1 </summary>
		e12,

		/// <summary> No Component; signals both the End of Components and 0-Elements in the Cayley Tables below </summary>
		_0,// = sbyte.MinValue
	}

	#region basis blades
	/// <summary> Identical Map; used together with <see cref="I"/> to represent Rotation </summary>
	public static readonly R200 _1_ = new(1, Base._1_);

	/// <summary>Gets the e1.<br/>
	/// Gets the e2.</summary>
	public static readonly R200 E1 = new(1, 1);
	/// <summary>Gets the e2.</summary>
	public static readonly R200 E2 = new(1, 2);

	/// <summary> AKA I, E12; represents Rotation </summary>
	public static readonly R200 I = new(1, Base.e12);
	#endregion basis blades

	/// <summary>Gets the _ Blades.<br/>
	/// Gets the blades.</summary>
	static readonly R200[] _Blades = {_1_,E1,E2,I};
	/// <summary>Gets the blades.</summary>
	public static readonly R200[] Blades = _Blades;

	#region Cayley Tables for different Products in R3,0,0

	/// <summary>Gets the _ Product Outer.</summary>
	static readonly Base[][] _ProductOuter = {
		new[] {Base._1_, Base.e1, Base.e2, Base.e12},
		new[] {Base.e1, Base._0, Base.e12, Base._0},
		new[] {Base.e2, ~Base.e12, Base._0, Base._0},
		new[] {Base.e12, Base._0, Base._0, Base._0}
	};

	/// <summary>Gets the product Outer.</summary>
	public static readonly IReadOnlyList<IReadOnlyList<Base>> ProductOuter = _ProductOuter;

	/// <summary>Gets the _ Product Geometric.</summary>
	static readonly Base[][] _ProductGeometric = {
		new[] {Base._1_, Base.e1, Base.e2, Base.e12},
		new[] {Base.e1, Base._1_, Base.e12, Base.e2},
		new[] {Base.e2, ~Base.e12, Base._1_, ~Base.e1},
		new[] {Base.e12, ~Base.e2, Base.e1, ~Base._1_}
	};

	/// <summary>Gets the product Geometric.</summary>
	public static readonly IReadOnlyList<IReadOnlyList<Base>> ProductGeometric = _ProductGeometric;

	/// <summary>Gets the _ Product Dot.</summary>
	static readonly Base[][] _ProductDot = {
		new[] {Base._1_, Base.e1, Base.e2, Base.e12}, 
		new[] {Base.e1, Base._1_, Base._0, Base.e2},
		new[] {Base.e2, Base._0, Base._1_, ~Base.e1},
		new[] {Base.e12, ~Base.e2, Base.e1, ~Base._1_}
	};

	/// <summary>Gets the product Dot.</summary>
	public static readonly IReadOnlyList<IReadOnlyList<Base>> ProductDot = _ProductDot;

	/// <summary>Gets the _ Products.<br/>
	/// Gets the products.</summary>
	static readonly Base[][][] _Products = { _ProductGeometric, _ProductDot, _ProductOuter};
	/// <summary>Gets the products.</summary>
	public static readonly IReadOnlyList<IReadOnlyList<IReadOnlyList<Base>>> Products = _Products;

	#endregion Cayley Tables for different Products in R3,0,0

	/// <summary> Creates a new <see cref="R200"/> G(2,0,0) multivector from the given double-precision component array. </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/clifford_algebra")]
	[System.ComponentModel.Description("Creates a new R200 G(2,0,0) multivector from the given double-precision component array.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public static R200 New(params double[] f) => New(f.AsFloat());
	/// <inheritdoc cref="New(double[])"/>
	public static R200 New(params float[] f) => New((IReadOnlyList<float>) f);
	/// <inheritdoc cref="New(double[])"/>
	public static R200 New(IReadOnlyList<float> f) => new(f);
	/// <inheritdoc cref="New(double[])"/>
	public static R200 New(double f = 0, int idx = 0) => new(f, idx);
	/// <inheritdoc cref="New(double[])"/>
	public static R200 New(double f = 0, Base idx = 0) => new(f, idx);

	/// <inheritdoc />
	public override R200 Create(IList<float> values) => new((IReadOnlyList<float>)values);
	/// <inheritdoc cref="Create(IList{float})"/>
	public override R200 Create(IReadOnlyList<float> values) => new(values);
	/// <inheritdoc />
	protected override R200 Create_(float[] values) => new(values);

	/// <summary>Gets or sets the element at the specified <paramref name="index"/>.</summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/clifford_algebra")]
	[System.ComponentModel.Description("Gets or sets the element at the specified index.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public float this[Base idx] => _C[(int) idx];

	/// <summary>Initializes a new instance of <see cref="R200"/> with the specified <paramref name="f"/> and <paramref name="idx"/>.<br/>
	/// Initializes a new instance of <see cref="R200"/> with the specified <paramref name="f"/> and <paramref name="idx"/>.</summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/clifford_algebra")]
	[System.ComponentModel.Description("Initializes a new instance of R200 with the specified f and idx. Initializes a new instance of R200 with the specified f and idx.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public R200(double f = 0, Base idx = 0) : base(f, (int)idx) {}
	/// <summary>Initializes a new instance of <see cref="R200"/> with the specified <paramref name="f"/> and <paramref name="idx"/>.</summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/clifford_algebra")]
	[System.ComponentModel.Description("Initializes a new instance of R200 with the specified f and idx.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public R200(double f = 0, int idx = 0) : base(f, idx) {}

	/// <summary> Unchecked private Constructor for Speed </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/clifford_algebra")]
	[System.ComponentModel.Description("Unchecked private Constructor for Speed")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	R200(float[] f) : base(f) {}

	/// <summary> Checked Constructor with Copy </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/clifford_algebra")]
	[System.ComponentModel.Description("Checked Constructor with Copy")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public R200(IReadOnlyList<float> values) : base(values) {}

	#region Overloaded Operators

	/// <inheritdoc />
	public override R200 Dual() => new(_C.Dual4());

	/// <summary> * geometric product. </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/clifford_algebra")]
	[System.ComponentModel.Description("* geometric product.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public override R200 Times(IReadOnlyList<float> that) => new(_C.Times4(that));
	/// <inheritdoc />
	public override R200 TimesR(IReadOnlyList<float> that) => new(that.Times4(_C));

	/// <inheritdoc />
	protected override double[][] Coefficients() {
		var m = new[] {
			new double[] {_C[0], _C[1], + _C[2], - _C[3]},
			new double[] {_C[1], _C[0], - _C[3], + _C[2]},
			new double[] {_C[2], _C[3], + _C[0], - _C[1]},
			new double[] {_C[3], _C[2], - _C[1], + _C[0]}
		};
		return m;
	}

	/// <summary> ^ outer product. (MEET) </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/clifford_algebra")]
	[System.ComponentModel.Description("^ outer product. (MEET)")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public override R200 Meet(IReadOnlyList<float> that) => new(_C.Meet4(that));

	/// <inheritdoc />
	public override R200 MeetR(IReadOnlyList<float> that) => new(that.Meet4(_C));

	/// <inheritdoc />
	public override R200 Join(IReadOnlyList<float> that) => new(_C.Join4(that));

	/// <inheritdoc />
	public override R200 Dot(IReadOnlyList<float> that) => new(_C.Dot4R200(that));

	#endregion

	/// <summary> Squared Euclidean norm. </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/clifford_algebra")]
	[System.ComponentModel.Description("Squared Euclidean norm.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public override double NormSqr() => _C.NormSqr4R200();

	/// <summary>Ideal norm. (signed) </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/clifford_algebra")]
	[System.ComponentModel.Description("Ideal norm. (signed)")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public override double NormI() => _C[1]!=0?_C[1]:Norm();

	/// <summary> Returns the normalized <see cref="R200.E1"/> Vector rotated by <paramref name="angle"/> </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/clifford_algebra")]
	[System.ComponentModel.Description("Returns the normalized E1 Vector rotated by angle")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public static R200 RotatedNormal(double angle) {
		var sinCos = angle.SinCos();
		return New(0, (float) sinCos.cos, (float) sinCos.sin, 0);
	}
}

