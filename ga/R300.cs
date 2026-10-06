using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using org.SpocWeb.root.Attributes;

namespace org.SpocWeb.root.maths.pga.ga;

/// <summary> 'Ordinary' Vector Space, representing only Vectors/Directions R�, not Points like G�. </summary>
/// <remarks>
/// * The outer Product ^ creates Areas and Volumes:
/// * BiVectors are oriented Planes, associated with Quaternion Coefficients
/// * TriVectors are oriented Volumes
/// * Reflections are defined by their Invariant, the Plane or its Dual, the Normal through the Origin
/// * Rotations are defined by an Angle/Distance, their Invariant: the Line through the Origin or its Dual, the Plane of Rotation.
/// * Translations are neither orthogonal nor linear and thus cannot be represented by R�,
/// only by G�, effectively using homogeneous Coordinates.
/// </remarks>
[DocState(Pass = 2, MTime = "2026-05-24T15:36:37Z", Digest = "81fd4ad0c526bf24d13dac17b74b71c8f09d863f30741f5547bebc833a36a19a", Stale = false, Path = "ga/R300.cs", Since = "2026-10-06")]
[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
[Tags("code/clifford_algebra", "code/vector_math")]
[System.ComponentModel.Description("'Ordinary' Vector Space, representing only Vectors/Directions R�, not Points like G�.")]
[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
public class R300 : AGeoGebra8<R300>
{
	/// <summary> just for debug and print output, the basis names </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/clifford_algebra", "code/vector_math")]
	[System.ComponentModel.Description("just for debug and print output, the basis names")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public override IReadOnlyList<string> Basis => _Basis;
	/// <summary>Gets the _ Basis.</summary>
	static readonly string[] _Basis = { "","x","y","z","k","j","i","I" };
	/// <summary>Gets the _ Basis No.</summary>
	static readonly string[] _BasisNo = { "","e1","e2","e3","e12","e13","e23","e123" };
	public static IReadOnlyList<string> BasisNo = _BasisNo;

	/// <inheritdoc />
	public override R300 Self() => this;

	/// <summary> Creates a new <see cref="R300"/> G(3,0,0) multivector from the given component array. </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/clifford_algebra", "code/vector_math")]
	[System.ComponentModel.Description("Creates a new R300 G(3,0,0) multivector from the given component array.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public static R300 New(params float[] f) => New((IReadOnlyList<float>) f);
	/// <inheritdoc cref="New(float[])"/>
	public static R300 New(IReadOnlyList<float> f) => new(f);
	/// <inheritdoc cref="New(float[])"/>
	public static R300 New(double f = 0, int idx = 0) => new(f, idx);
	/// <inheritdoc cref="New(float[])"/>
	public static R300 New(double f = 0, Base idx = 0) => new(f, idx);

	/// <summary> Base-Blades in 3D, usable as Indices for Components </summary>
	/// <remarks>
	/// ## Public Methods
	///
	/// | Line | Method | Description |
	/// |--:|---|---|
	/// | 64 | <see cref="_1_"/> | [0] Scalar e.g. Dot Product or oriented Volume |
	/// | 67 | <see cref="e1"/> | [1] X-Direction (polar) / yz-Mirror e1� = 1 |
	/// | 70 | <see cref="e2"/> | [2] Y-Direction (polar) / zx-Mirror e2� = 1 |
	/// | 73 | <see cref="e3"/> | [3] Z-Direction (polar) / xy-Mirror e3� = 1 |
	/// | 78 | <see cref="e12"/> | [4] axial/dual Z-BiVector; X-Y-Plane-Unit; e12� = k� = -1 [5] axial Y-BiVector; X-Z-Plane-Unit; e13� = j� = -1 |
	/// | 80 | <see cref="e13"/> | Represents e13. |
	/// | 83 | <see cref="e23"/> | [6] axial X-BiVector; Y-Z-Plane-Unit; e23� = i� = -1 |
	/// | 86 | <see cref="e123"/> | [7] Oriented Volume, a Pseudo-Scalar; e123� = I� = -1 |
	/// | 89 | <see cref="_0"/> | No Component; signals both the End of Components and 0-Elements in the Cayley Tables below |
	/// </remarks>
	[DocState(Pass = 2, MTime = "2026-06-17T05:58:45Z", Digest = "e86c2fda6a58a142d27b566d8f9a88bc30c03e8a4df2deccc8a528e49437ad79", Stale = false, Path = "ga/R300.cs", Since = "2026-10-06")]
	[Facets(Layer = "domain", Status = "stable", Complexity = 1)]
	[Tags("code/enum", "code/clifford_algebra")]
	[System.ComponentModel.Description("Base-Blades in 3D, usable as Indices for Components")]
	[SuppressMessage("ReSharper", "InconsistentNaming")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public enum Base : sbyte
	{
		/// <summary> [0] Scalar e.g. Dot Product or oriented Volume </summary>
		_1_,

		/// <summary> [1] X-Direction (polar) / yz-Mirror e1� = 1 </summary>
		e1,

		/// <summary> [2] Y-Direction (polar) / zx-Mirror e2� = 1 </summary>
		e2,

		/// <summary> [3] Z-Direction (polar) / xy-Mirror e3� = 1 </summary>
		e3,

		/// <summary>[4] axial/dual Z-BiVector; X-Y-Plane-Unit; e12� = k� = -1<br/>
		/// [5] axial Y-BiVector; X-Z-Plane-Unit; e13� = j� = -1</summary>
		/// <remarks> Multiplication rotates by 90� in the X-Y-Plane </remarks>
		e12,
		/// <remarks> Multiplication rotates by 90� in the X-Z-Plane </remarks>
		e13,
		/// <summary> [6] axial X-BiVector; Y-Z-Plane-Unit; e23� = i� = -1 </summary>
		/// <remarks> Multiplication rotates by 90� in the Z-Y-Plane </remarks>
		e23,

		/// <summary> [7] Oriented Volume, a Pseudo-Scalar; e123� = I� = -1 </summary>
		e123,

		/// <summary> No Component; signals both the End of Components and 0-Elements in the Cayley Tables below </summary>
		_0,// = sbyte.MinValue
	}

	#region Cayley Tables for different Products in R3,0,0

	/// <summary>Gets the _ Product Outer.</summary>
	static readonly Base[][] _ProductOuter = {
		new[] {Base._1_, Base.e1, Base.e2, Base.e3, Base.e12, Base.e13, Base.e23, Base.e123},
		new[] {Base.e1, Base._0, Base.e12, Base.e13, Base._0, Base._0, Base.e123, Base._0},
		new[] {Base.e2, ~Base.e12, Base._0, Base.e23, Base._0, ~Base.e123, Base._0, Base._0},
		new[] {Base.e3, ~Base.e13, ~Base.e23, Base._0, Base.e123, Base._0, Base._0, Base._0},
		new[] {Base.e12, Base._0, Base._0, Base.e123, Base._0, Base._0, Base._0, Base._0},
		new[] {Base.e13, Base._0, ~Base.e123, Base._0, Base._0, Base._0, Base._0, Base._0},
		new[] {Base.e23, Base.e123, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0},
		new[] {Base.e123, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0},
	};

	/// <summary>Gets the product Outer.</summary>
	public static readonly IReadOnlyList<IReadOnlyList<Base>> ProductOuter = _ProductOuter;

	/// <summary>Gets the _ Product Geometric.</summary>
	static readonly Base[][] _ProductGeometric = {
		new[] {Base._1_, Base.e1, Base.e2, Base.e3, Base.e12, Base.e13, Base.e23, Base.e123},
		new[] {Base.e1, Base._1_, Base.e12, Base.e13, Base.e2, Base.e3, Base.e123, Base.e23},
		new[] {Base.e2, ~Base.e12, Base._1_, Base.e23, ~Base.e1, ~Base.e123, Base.e3, ~Base.e13},
		new[] {Base.e3, ~Base.e13, ~Base.e23, Base._1_, Base.e123, ~Base.e1, ~Base.e2, Base.e12},
		new[] {Base.e12, ~Base.e2, Base.e1, Base.e123, ~Base._1_, ~Base.e23, Base.e13, ~Base.e3},
		new[] {Base.e13, ~Base.e3, ~Base.e123, Base.e1, Base.e23, ~Base._1_, ~Base.e12, Base.e2},
		new[] {Base.e23, Base.e123, ~Base.e3, Base.e2, ~Base.e13, Base.e12, ~Base._1_, ~Base.e1},
		new[] {Base.e123, Base.e23, ~Base.e13, Base.e12, ~Base.e3, Base.e2, ~Base.e1, ~Base._1_},
	};

	/// <summary>Gets the product Geometric.</summary>
	public static readonly IReadOnlyList<IReadOnlyList<Base>> ProductGeometric = _ProductGeometric;

	/// <summary>Gets the _ Product Dot.</summary>
	static readonly Base[][] _ProductDot = {
		new[] {Base._1_, Base.e1, Base.e2, Base.e3, Base.e12, Base.e13, Base.e23, Base.e123},
		new[] {Base.e1, Base._1_, Base._0, Base._0, Base.e2, Base.e3, Base._0, Base.e23},
		new[] {Base.e2, Base._0, Base._1_, Base._0, ~Base.e1, Base._0, Base.e3, ~Base.e13},
		new[] {Base.e3, Base._0, Base._0, Base._1_, Base._0, ~Base.e1, ~Base.e2, Base.e12},
		new[] {Base.e12, ~Base.e2, Base.e1, Base._0, ~Base._1_, Base._0, Base._0, ~Base.e3},
		new[] {Base.e13, ~Base.e3, Base._0, Base.e1, Base._0, ~Base._1_, Base._0, Base.e2},
		new[] {Base.e23, Base._0, ~Base.e3, Base.e2, Base._0, Base._0, ~Base._1_, ~Base.e1},
		new[] {Base.e123, Base.e23, ~Base.e13, Base.e12, ~Base.e3, Base.e2, ~Base.e1, ~Base._1_},
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
	public static readonly R300 _1_ = new(1, 0);
	/// <summary>Gets the e1.</summary>
	public static readonly R300 e1 = new(1, 1);
	/// <summary>Gets the e2.</summary>
	public static readonly R300 e2 = new(1, 2);
	/// <summary>Gets the e3.</summary>
	public static readonly R300 e3 = new(1, 3);
	/// <summary>Gets the e12.</summary>
	public static readonly R300 e12 = new(1, 4);
	/// <summary>Gets the e13.</summary>
	public static readonly R300 e13 = new(1, 5);
	/// <summary>Gets the e23.</summary>
	public static readonly R300 e23 = new(1, 6);
	/// <summary>Gets the e123.</summary>
	public static readonly R300 e123 = new(1, 7);
	// ReSharper restore InconsistentNaming
	#endregion basis blades

	/// <summary>Gets the _ Blades.<br/>
	/// Gets the blades.</summary>
	static readonly R300[] _Blades = {_1_,e1,e2,e3,e12,e13,e23,e123};
	/// <summary>Gets the blades.</summary>
	public static readonly R300[] Blades = _Blades;

	/// <summary>Gets or sets the element at the specified <paramref name="index"/>.</summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/clifford_algebra", "code/vector_math")]
	[System.ComponentModel.Description("Gets or sets the element at the specified index.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public float this[Base idx] => _C[(int) idx];

	/// <inheritdoc />
	public override R300 Create(IReadOnlyList<float> values) => new(values);
	/// <inheritdoc cref="Create(IReadOnlyList{float})"/>
	public override R300 Create(IList<float> values) => new((IReadOnlyList<float>)values);
	/// <inheritdoc />
	protected override R300 Create_(float[] values) => new(values);

	/// <summary>Initializes a new instance of <see cref="R300"/> with the specified <paramref name="f"/> and <paramref name="idx"/>.<br/>
	/// Initializes a new instance of <see cref="R300"/> with the specified <paramref name="f"/> and <paramref name="idx"/>.</summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/clifford_algebra", "code/vector_math")]
	[System.ComponentModel.Description("Initializes a new instance of R300 with the specified f and idx. Initializes a new instance of R300 with the specified f and idx.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public R300(double f = 0, Base idx = 0) : base(f, (int)idx) {}
	/// <summary>Initializes a new instance of <see cref="R300"/> with the specified <paramref name="f"/> and <paramref name="idx"/>.</summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/clifford_algebra", "code/vector_math")]
	[System.ComponentModel.Description("Initializes a new instance of R300 with the specified f and idx.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public R300(double f = 0, int idx = 0) : base(f, idx) {}

	/// <summary> Unchecked private Constructor for Speed </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/clifford_algebra", "code/vector_math")]
	[System.ComponentModel.Description("Unchecked private Constructor for Speed")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	R300(float[] f) : base(f) { }

	/// <summary> Checked Constructor </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/clifford_algebra", "code/vector_math")]
	[System.ComponentModel.Description("Checked Constructor")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public R300(IReadOnlyList<float> values) : base(values) { }

	/// <inheritdoc />
	public sealed override R300 Dual() => Create_(_C.Dual8());
	/// <inheritdoc />
	public override double NormSqr() => _C.NormSqr6R300();

	/// <summary> Full geometric product: ^ + * </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/clifford_algebra", "code/vector_math")]
	[System.ComponentModel.Description("Full geometric product: ^ + *")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public override R300 Times(IReadOnlyList<float> factor) => new(_C.Times8(factor));
	/// <inheritdoc />
	public override R300 TimesR(IReadOnlyList<float> factor) => new(factor.Times8(_C));

	/// <inheritdoc />
	public override R300 Dot(IReadOnlyList<float> parallel) => new(_C.Dot8(parallel));
	/// <inheritdoc />
	public override R300 Join(IReadOnlyList<float> b) => Create_(_C.Join8(b));
	/// <inheritdoc />
	public override R300 Meet(IReadOnlyList<float> b) => new(_C.Meet8(b));
	/// <inheritdoc />
	public override R300 MeetR(IReadOnlyList<float> b) => new(b.Meet8(_C));

	/// <inheritdoc />
	protected override double[][] Coefficients() {
		var m = new[] {
			new double[] {_C[0], +_C[1], +_C[2], +_C[3], -_C[4], -_C[5], -_C[6], -_C[7]},
			new double[] {_C[1], +_C[0], -_C[4], -_C[5], +_C[2], +_C[3], -_C[7], -_C[6]},
			new double[] {_C[2], +_C[4], +_C[0], -_C[6], -_C[1], +_C[7], +_C[3], +_C[5]},
			new double[] {_C[3], +_C[5], +_C[6], +_C[0], -_C[7], -_C[1], -_C[2], -_C[4]},
			new double[] {_C[4], +_C[2], -_C[1], +_C[7], +_C[0], -_C[6], +_C[5], +_C[3]},
			new double[] {_C[5], +_C[3], -_C[7], -_C[1], +_C[6], +_C[0], -_C[4], -_C[2]},
			new double[] {_C[6], +_C[7], +_C[3], -_C[2], -_C[5], +_C[4], +_C[0], +_C[1]},
			new double[] {_C[7], +_C[6], -_C[5], +_C[4], +_C[3], -_C[2], +_C[1], +_C[0]}
		};
		return m;
	}
}

