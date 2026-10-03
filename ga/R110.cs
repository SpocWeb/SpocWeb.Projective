using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using org.SpocWeb.root.array;

namespace org.SpocWeb.root.maths.pga.ga;

/// <summary> G(1,1,0) Split-Complex (Hyperbolic) Number algebra with e1²=+1 (real) and e2²=−1 (imaginary). </summary>
/// <remarks>
/// ## Public Methods
///
/// | Line | Method | Description |
/// |--:|---|---|
/// | 65 | <see cref="R110"/> | Initializes a new instance of R110 with the specified f and idx. |
/// | 67 | <see cref="R110"/> | Initializes a new instance of R110 with the specified values. |
/// | 73 | <see cref="R110"/> | Initializes a new instance of R110 with the specified values. |
/// | 83 | <see cref="New"/> | Creates a new R110 G(1,1,0) multivector from the given component array. |
/// | 123 | <see cref="Scalar"/> | Gets the scalar. |
/// | 126 | <see cref="e1"/> | Gets the e1. |
/// | 129 | <see cref="e2"/> | Gets the e2. |
/// | 132 | <see cref="e12"/> | Gets the e12. |
/// | 150 | <see cref="Blades"/> | Gets the blades. |
///
/// ## Collaborators
///
/// | Type | Role |
/// |---|---|
/// | <see cref="R110"/> | Returned by a method. |
/// | <see cref="Base"/> | Nested enum. |
/// </remarks>
///
/// <example>
/// <code language="yaml">
/// pass: 2
/// mtime: 2026-05-24T15:36:37Z
/// digest: fc5ceb03e3051a383b8c4688a18a6d352fafd55a841f9a8397742f20026fe190
/// tags: [code/clifford_algebra, code/split_complex]
/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
/// facets: {layer: domain, status: stable, complexity: 2}
/// </code>
/// </example>
public class R110 : AGeoGebra4<R110>
{
	// just for debug and print output, the basis names
	/// <summary>Gets the _ Basis.</summary>
	static readonly string[] _Basis = { "","re","im","e12" };
	/// <inheritdoc />
	/// <example>
	/// <code language="yaml">
	/// pass: 2
	/// mtime: 2026-05-24T15:36:37Z
	/// digest: 26503888b6121e5e4ed37e13956351fa0ad87252f10d3ec1dc8b6374e004fd4b
	/// </code>
	/// </example>
	public override IReadOnlyList<string> Basis => _Basis;

	/// <inheritdoc />
	public override R110 Self() => this;

	/// <summary> Base-Blades in 3D, usable as Indices for Components </summary>
	/// <example>
	/// <code language="yaml">
	/// pass: 2
	/// mtime: 2026-06-17T05:58:42Z
	/// digest: 26503888b6121e5e4ed37e13956351fa0ad87252f10d3ec1dc8b6374e004fd4b
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

		/// <summary> [1] AKA e1; real Part re� = 1 </summary>
		re,

		/// <summary> [2] AKA i, e1; imaginary Part im� = -1 </summary>
		im,

		/// <summary>[3] <see cref="e12"/> is the Pseudo-Scalar: <see cref="e12"/>� = -1 </summary>
		e12,

		/// <summary> No Component; signals both the End of Components and 0-Elements in the Cayley Tables below </summary>
		_0,// = sbyte.MinValue
	}

	/// <summary>Initializes a new instance of <see cref="R110"/> with the specified <paramref name="f"/> and <paramref name="idx"/>.<br/>
	/// Initializes a new instance of <see cref="R110"/> with the specified <paramref name="f"/> and <paramref name="idx"/>.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/clifford_algebra, code/split_complex]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 2}
	/// </code>
	/// </example>
	public R110(float f = 0f, int idx = 0) : base(f, idx) { }
	/// <summary>Initializes a new instance of <see cref="R110"/> with the specified <paramref name="values"/>.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/clifford_algebra, code/split_complex]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 2}
	/// </code>
	/// </example>
	public R110(float f = 0f, Base idx = 0) : base(f, (int) idx) { }

	/// <summary>Initializes a new instance of <see cref="R110"/> with the specified <paramref name="f"/>.<br/>
	/// Initializes a new instance of <see cref="R110"/> with the specified <paramref name="values"/>.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/clifford_algebra, code/split_complex]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 2}
	/// </code>
	/// </example>
	R110(params float[] f) : base(f) { }
	/// <summary>Initializes a new instance of <see cref="R110"/> with the specified <paramref name="values"/>.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/clifford_algebra, code/split_complex]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 2}
	/// </code>
	/// </example>
	public R110(IReadOnlyList<float> values) : base(values) { }

	/// <inheritdoc />
	public override R110 Create(IReadOnlyList<float> values) => new(values);
	/// <inheritdoc cref="Create(IReadOnlyList{float})"/>
	public override R110 Create(IList<float> values) => new((IReadOnlyList<float>)values);
	/// <inheritdoc />
	protected override R110 Create_(float[] values) => new(values);

	/// <summary> Creates a new <see cref="R110"/> G(1,1,0) multivector from the given component array. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/clifford_algebra, code/split_complex]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 2}
	/// </code>
	/// </example>
	public static R110 New(params float[] f) => New((IReadOnlyList<float>) f);
	/// <inheritdoc cref="New(float[])"/>
	public static R110 New(IReadOnlyList<float> f) => new(f);

	/// <inheritdoc />
	protected override double[][] Coefficients() => new[] {
		new double[] {_C[0], _C[1], -_C[2], +_C[3]},
		new double[] {_C[1], _C[0], +_C[3], -_C[2]},
		new double[] {_C[2], _C[3], +_C[0], -_C[1]},
		new double[] {_C[3], _C[2], -_C[1], +_C[0]}
	};

	#region Overloaded Operators

	/// <summary> ! Dual; Poincare duality operator. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/clifford_algebra, code/split_complex]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 2}
	/// </code>
	/// </example>
	public override R110 Dual() => new(_C.DualR011());
	/// <inheritdoc />
	public override double NormSqr() => _C.NormSqr4R110();
	/// <inheritdoc />
	public override double NormSqrI() => 1;

	/// <inheritdoc />
	public override R110 Dot(IReadOnlyList<float> that) => new(_C.Dot4R110(that));
	/// <inheritdoc />
	public override R110 Join(IReadOnlyList<float> that) => new(_C.Join4(that));
	/// <inheritdoc />
	public override R110 MeetR(IReadOnlyList<float> that) => new(that.Meet4(_C));
	/// <inheritdoc />
	public override R110 Meet(IReadOnlyList<float> that) => new(_C.Meet4(that));
	/// <inheritdoc />
	public override R110 Times(IReadOnlyList<float> factor) => new(_C.Times4R110(factor));
	/// <inheritdoc />
	public override R110 TimesR(IReadOnlyList<float> factor) => new(factor.Times4R110(_C));

	#endregion

	#region basis Components
	// ReSharper disable InconsistentNaming

	/// <inheritdoc cref="Base._1_"/>
	public float Scalar => _C[(int) Base._1_];

	/// <inheritdoc cref="Base.e1"/>
	public float e1 => _C[(int) Base.re];

	/// <inheritdoc cref="Base.e2"/>
	public float e2 => _C[(int) Base.im];

	/// <inheritdoc cref="Base.e12"/>
	public float e12 => _C[(int) Base.e12];

	// ReSharper restore InconsistentNaming
	#endregion basis Components

	#region basis blades

	public static R110 _1_ = new(1f, 0);
	public static R110 E1 = new(1f, 1);
	public static R110 E2 = new(1f, 2);
	public static R110 I = new(1f, 3);

	#endregion basis blades

	/// <summary>Gets the _ Blades.<br/>
	/// Gets the blades.</summary>
	static readonly R110[] _Blades = {_1_,E1,E2,I};
	/// <summary>Gets the blades.</summary>
	public static readonly R110[] Blades = _Blades;

}

