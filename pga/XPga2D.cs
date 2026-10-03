using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using org.SpocWeb.root.array;
using org.SpocWeb.root.extensions.collections;
using org.SpocWeb.root.extensions.maths;
using org.SpocWeb.root.interfaces.maths;
using org.SpocWeb.root.logging;
using org.SpocWeb.root.maths.pga.ga;

namespace org.SpocWeb.root.maths.pga;

/// <summary> Extension Methods on <see cref="IReadOnlyList{Single}"/> </summary>
/// <remarks>
/// Geometric Algebra = Clifford Algebra which unifies Hamilton Quaternions and Grassmann Product.
/// 
/// </remarks>
/// <example>
/// <code language="yaml">
/// pass: 2
/// mtime: 2026-05-24T16:42:31Z
/// digest: 25f5128c829047c7915237e66c7efbfd6f70905c5031594bb0f75143db799547
/// tags: [code/extension_method, code/projective_geometric_algebra]
/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
/// facets: {layer: test, status: stable, complexity: 2}
/// </code>
/// </example>
public static class XPga2D
{

	/// <summary> Creates a <see cref="Pga2D"/> with coefficient <paramref name="f"/> at basis blade <paramref name="idx"/>. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/extension_method, code/factory_method]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 1}
	/// </code>
	/// </example>
	public static Pga2D AsPga2D(this Pga2D.Base idx, double f = 1) => new(f, idx);
	/// <inheritdoc cref="AsPga2D(Pga2D.Base,double)"/>
	public static Pga2D AsPga2D(this Pga2D.AxisTrans idx, double f = 1) => new(f, idx);
	/// <inheritdoc cref="AsPga2D(Pga2D.Base,double)"/>
	public static Pga2D AsPga2D(this Pga2D.AxisRot idx, double f = 1) => new(f, idx);
	/// <inheritdoc cref="AsPga2D(Pga2D.Base,double)"/>
	public static Pga2D AsPga2D(this Pga2D.Points idx, double f = 1) => new(f, idx);
	/// <inheritdoc cref="AsPga2D(Pga2D.Base,double)"/>
	public static Pga2D AsPga2D(this Pga2D.Lines idx, double f = 1) => new(f, idx);

	/// <summary> Decomposes a signed blade index into its positive form and sign factor (+1, −1, or 0). </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/extension_method, code/canonicalization]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 2}
	/// </code>
	/// </example>
	public static (Pga2D.Base e, int factor) GetFactor(this Pga2D.Base e)
		=> e < 0 ? (~e, -1) : e == Pga2D.Base._0 ? (Pga2D.Base._1_, 0) : (e, 1);

	/// <summary> Returns the grade (0 = scalar, 1 = vector, 2 = bivector, 3 = pseudoscalar) of a basis blade. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/extension_method, code/enum_conversion]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 2}
	/// </code>
	/// </example>
	public static byte Grade(this Pga2D.Base value) 
		=> value switch {
			Pga2D.Base._1_ => 0,
			Pga2D.Base.e0 => 1,
			Pga2D.Base.e1 => 1,
			Pga2D.Base.e2 => 1,
			Pga2D.Base.e01 => 2,
			Pga2D.Base.e12 => 2,
			Pga2D.Base.e20 => 2,
			Pga2D.Base.i => 3,
			_ => throw new ArgumentOutOfRangeException(nameof(value), value, null)
		};

	/// <summary> Demonstrates the <see cref="Pga2D.Dual"/> Operation on <see cref="Pga2D.Base"/> Components </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/unit_test, code/clifford_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: test, status: stable, complexity: 1}
	/// </code>
	/// </example>
	#region TestCase
	[TestCase(Pga2D.Base._1_, ExpectedResult = Pga2D.Bases.e012)]

	[TestCase((Pga2D.Base)Pga2D.AxisTrans.X, ExpectedResult = (Pga2D.Bases)(1 << (int)Pga2D.Lines.X))]
	[TestCase((Pga2D.Base)Pga2D.AxisTrans.Y, ExpectedResult = (Pga2D.Bases)(1 << (int)Pga2D.Lines.Y))]
	[TestCase((Pga2D.Base)Pga2D.AxisRot.Z, ExpectedResult = (Pga2D.Bases)(1 << (int)Pga2D.Lines.Horizon))]

	[TestCase((Pga2D.Base)Pga2D.Lines.X, ExpectedResult = (Pga2D.Bases)(1 << (int)Pga2D.AxisTrans.X))]
	[TestCase((Pga2D.Base)Pga2D.Lines.Y, ExpectedResult = (Pga2D.Bases)(1 << (int)Pga2D.AxisTrans.Y))]
	[TestCase((Pga2D.Base)Pga2D.Lines.Horizon, ExpectedResult = (Pga2D.Bases)(1 << (int)Pga2D.AxisRot.Z))]

	[TestCase(Pga2D.Base.e012, ExpectedResult = Pga2D.Bases._1_)]
	#endregion TestCase
	public static Pga2D.Bases Dual(Pga2D.Base b) {
		var p = b.AsPga2D();
		var d = p.Dual().Components;
		return d;
	}

	/// <summary> Demonstrates the <see cref="Pga2D.Reverted"/> Operation on <see cref="Pga2D.Base"/> Components </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/unit_test, code/clifford_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: test, status: stable, complexity: 2}
	/// </code>
	/// </example>
	#region TestCase
	[TestCase(Pga2D.Base._1_, ExpectedResult = 1f)]

	[TestCase((Pga2D.Base)Pga2D.Lines.Horizon, ExpectedResult = 1f)]

	[TestCase((Pga2D.Base)Pga2D.Lines.X, ExpectedResult = 1f)]
	[TestCase((Pga2D.Base)Pga2D.Lines.Y, ExpectedResult = 1f)]

	[TestCase((Pga2D.Base)Pga2D.Points.X, ExpectedResult = -1f)]
	[TestCase((Pga2D.Base)Pga2D.Points.Y, ExpectedResult = -1f)]

	[TestCase((Pga2D.Base)Pga2D.Points.O, ExpectedResult = -1f)]

	[TestCase(Pga2D.Base.e012, ExpectedResult = -1f)]
	#endregion TestCase
	public static float Reverted(Pga2D.Base b) {
		var p = b.AsPga2D();
		var r = p.Reverted();
		var d = r.Components;
		_ = d.ShouldBe((Pga2D.Bases)(1 << (int)b));
		return r.Single(v => !v.IsSmallerThanAbs(PgaTolerance.Float));
	}

	/// <summary> Demonstrates the <see cref="Pga2D.Involute"/> Operation on <see cref="Pga2D.Base"/> Components </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/unit_test, code/clifford_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: test, status: stable, complexity: 2}
	/// </code>
	/// </example>
	#region TestCase
	[TestCase(Pga2D.Base._1_, ExpectedResult = 1f)]

	[TestCase((Pga2D.Base)Pga2D.Lines.Horizon, ExpectedResult = -1f)]

	[TestCase((Pga2D.Base)Pga2D.Lines.X, ExpectedResult = -1f)]
	[TestCase((Pga2D.Base)Pga2D.Lines.Y, ExpectedResult = -1f)]

	[TestCase((Pga2D.Base)Pga2D.Points.X, ExpectedResult = 1f)]
	[TestCase((Pga2D.Base)Pga2D.Points.Y, ExpectedResult = 1f)]

	[TestCase((Pga2D.Base)Pga2D.Points.O, ExpectedResult = 1f)]

	[TestCase(Pga2D.Base.e012, ExpectedResult = -1f)]
	#endregion TestCase
	public static float Involute(Pga2D.Base b) {
		var p = b.AsPga2D();
		var d = p.Involute();
		var c = d.Components;
		_ = c.ShouldBe((Pga2D.Bases)(1 << (int)b));
		return d.Single(v => !v.IsSmallerThanAbs(PgaTolerance.Float));
	}

	/// <summary> Demonstrates the Signs of the <see cref="Pga2D.Conjugate"/> Operation on <see cref="Pga2D.Base"/> Components </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/unit_test, code/clifford_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: test, status: stable, complexity: 2}
	/// </code>
	/// </example>
	#region TestCase
	[TestCase(Pga2D.Base._1_, ExpectedResult = 1f)]

	[TestCase((Pga2D.Base)Pga2D.Lines.Horizon, ExpectedResult = -1f)]

	[TestCase((Pga2D.Base)Pga2D.Lines.X, ExpectedResult = -1f)]
	[TestCase((Pga2D.Base)Pga2D.Lines.Y, ExpectedResult = -1f)]

	[TestCase((Pga2D.Base)Pga2D.Points.X, ExpectedResult = -1f)]
	[TestCase((Pga2D.Base)Pga2D.Points.Y, ExpectedResult = -1f)]

	[TestCase((Pga2D.Base)Pga2D.Points.O, ExpectedResult = -1f)]

	[TestCase(Pga2D.Base.e012, ExpectedResult = 1f)]
	#endregion TestCase
	public static float Conjugate(Pga2D.Base b) {
		var p = b.AsPga2D();
		var d = p.Conjugate();
		_ = d.Components.ShouldBe((Pga2D.Bases)(1 << (int)b));
		return d.Single(v => !v.IsSmallerThanAbs(PgaTolerance.Float));
	}

	#region Unary Operators

	/// <summary> ! Dual; Poincare duality operator. </summary>
	/// <remarks>
	/// * Scalar {=} Pseudo-Scalar,
	/// * Point {=} Line/Vector,
	/// </remarks>
	/// <example>
	/// <code language="yaml">
	/// tags: [code/extension_method, code/clifford_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 1}
	/// </code>
	/// </example>
	[TestCase(new []{1,2,3,4,5,6,7,8f}, ExpectedResult = new []{8, 7, 6, 5, 4, 3, 2, 1f})]
	public static float[] Dual8P(this IReadOnlyList<float> a) => new []{a[7], a[6], a[5], a[4], a[3], a[2], a[1], a[0]};
	/// <inheritdoc cref="Dual8P(IReadOnlyList{float})"/>
	public static double[] Dual8P(this IReadOnlyList<double> a) => new []{a[7], a[6], a[5], a[4], a[3], a[2], a[1], a[0]};

	#region TestCase
	/// <summary>Test Dual.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/unit_test, code/clifford_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: test, status: stable, complexity: 1}
	/// </code>
	/// </example>
	[TestCase(Pga2D.Base._1_, ExpectedResult = Pga2D.Bases.e012)]

	[TestCase((Pga2D.Base)Pga2D.Points.O, ExpectedResult = (Pga2D.Bases)(1 << (int)Pga2D.Lines.Horizon))]

	[TestCase((Pga2D.Base)Pga2D.Points.X, ExpectedResult = (Pga2D.Bases)(1 << (int)Pga2D.Lines.X))]
	[TestCase((Pga2D.Base)Pga2D.Points.Y, ExpectedResult = (Pga2D.Bases)(1 << (int)Pga2D.Lines.Y))]

	[TestCase((Pga2D.Base)Pga2D.Lines.X, ExpectedResult = (Pga2D.Bases)(1 << (int)Pga2D.Points.X))]
	[TestCase((Pga2D.Base)Pga2D.Lines.Y, ExpectedResult = (Pga2D.Bases)(1 << (int)Pga2D.Points.Y))]

	[TestCase((Pga2D.Base)Pga2D.Lines.Horizon, ExpectedResult = (Pga2D.Bases)(1 << (int)Pga2D.Points.O))]

	[TestCase(Pga2D.Base.e012, ExpectedResult = Pga2D.Bases._1_)]
	#endregion TestCase
	public static Pga2D.Bases TestDual(Pga2D.Base b) {
		var p = b.AsPga2D();
		//var c = p.Components;
		var d = p.Dual().Components;
		return d;
	}

	#endregion Unary Operators

	#region Binary Operators

	/// <summary>Norm Sqr2 Q.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/norm_calculation]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 1}
	/// </code>
	/// </example>
	[TestCase(new []{1,2,3,4,5,6,7,8f}, ExpectedResult = 25)]
	public static float NormSqr2Q(IReadOnlyList<float> c) => c.Times8P(c.CliffCjg8())[0];
	/// <summary>Norm Sqr8 P.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/extension_method, code/norm_calculation]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 1}
	/// </code>
	/// </example>
	[TestCase(new []{1,2,3,4,5,6,7,8f}, ExpectedResult = 25)]
	public static float NormSqr8P(this IReadOnlyList<float> a) => a[0].Sqr() 
		- a[2].Sqr() - a[3].Sqr() + a[6].Sqr();
	/// <inheritdoc cref="NormSqr8P(IReadOnlyList{float})"/>
	public static double NormSqr8P(this IReadOnlyList<double> a) => a[0].Sqr() 
		- a[2].Sqr() - a[3].Sqr() + a[6].Sqr();

	/// <summary> Full geometric product: ^ + * </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/extension_method, code/geometric_product]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 1}
	/// </code>
	/// </example>
	[TestCase(new []{1,2,3,4,5,6,7,8f}, new []{-1,-2,-3,-4,-5,-6,-7,-8f}
		, ExpectedResult = new []{23,108, -6, -8, -74, -60, -14, -120f})]
	public static float[] Times8P(this IReadOnlyList<float> a, IReadOnlyList<float> b) => new []{
		b[0] * a[0] + b[2] * a[2] + b[3] * a[3] - b[6] * a[6],
		b[1] * a[0] + b[0] * a[1] - b[4] * a[2] + b[5] * a[3] + b[2] * a[4] - b[3] * a[5] - b[7] * a[6] - b[6] * a[7],
		b[2] * a[0] + b[0] * a[2] - b[6] * a[3] + b[3] * a[6],
		b[3] * a[0] + b[6] * a[2] + b[0] * a[3] - b[2] * a[6],
		b[4] * a[0] + b[2] * a[1] - b[1] * a[2] + b[7] * a[3] + b[0] * a[4] + b[6] * a[5] - b[5] * a[6] + b[3] * a[7],
		b[5] * a[0] - b[3] * a[1] + b[7] * a[2] + b[1] * a[3] - b[6] * a[4] + b[0] * a[5] + b[4] * a[6] + b[2] * a[7],
		b[6] * a[0] + b[3] * a[2] - b[2] * a[3] + b[0] * a[6],
		b[7] * a[0] + b[6] * a[1] + b[5] * a[2] + b[4] * a[3] + b[3] * a[4] + b[2] * a[5] + b[1] * a[6] + b[0] * a[7]
	};

	/// <inheritdoc cref="Times8P(IReadOnlyList{float}, IReadOnlyList{float})"/>
	public static double[] Times8P(this IReadOnlyList<double> a, IReadOnlyList<double> b) => new []{
		b[0] * a[0] + b[2] * a[2] + b[3] * a[3] - b[6] * a[6],
		b[1] * a[0] + b[0] * a[1] - b[4] * a[2] + b[5] * a[3] + b[2] * a[4] - b[3] * a[5] - b[7] * a[6] - b[6] * a[7],
		b[2] * a[0] + b[0] * a[2] - b[6] * a[3] + b[3] * a[6],
		b[3] * a[0] + b[6] * a[2] + b[0] * a[3] - b[2] * a[6],
		b[4] * a[0] + b[2] * a[1] - b[1] * a[2] + b[7] * a[3] + b[0] * a[4] + b[6] * a[5] - b[5] * a[6] + b[3] * a[7],
		b[5] * a[0] - b[3] * a[1] + b[7] * a[2] + b[1] * a[3] - b[6] * a[4] + b[0] * a[5] + b[4] * a[6] + b[2] * a[7],
		b[6] * a[0] + b[3] * a[2] - b[2] * a[3] + b[0] * a[6],
		b[7] * a[0] + b[6] * a[1] + b[5] * a[2] + b[4] * a[3] + b[3] * a[4] + b[2] * a[5] + b[1] * a[6] + b[0] * a[7]
	};

	/// <summary> ^ Wedge/Meet : outer/exterior/progressive antisymmetric 'Grassmann' product; Dual to <see cref="Join8P"/>. </summary>
	/// <remarks>
	/// Dual Operation to v / <see cref="Join8P"/>: a ^ b = !a v !b 
	/// 
	/// Anti-Symmetric: v^v = 0 eqv. a^b = -b^a
	/// Proof:
	/// 0 = (a+b)^(a+b) = a² + a^b + b^a + b² = a^b + b^a
	///
	/// |a^b| = |a|*|b|*sin(phi)
	///
	/// In Projective Geometry this calculates the Point where two or more HyperPlanes 'meet'. 
	/// 
	/// Components are the regular Cross.Product:
	/// a^b=[a1,a2,a3]^[b1,b2,b3]=[a2*b3-a3*b2, a3*b1-a1*b3, a1*b2-a2*b1]
	/// expressed as contraVariant Coefficients of coVariant Base Vectors (e1,e2,e3)
	/// and Bi-Vectors (e2^e3, e3^e1, e1^e2) = (e23, e31, e12)
	///
	/// This also calculates the oriented Volume/Area:
	/// (a^b)^c = det([a,b,c]) * e1^e2^e3 = (a x b) * c * e123
	///
	/// Advantages of the Wedge Product:
	/// Associative: (a^b)^c = a^(b^c)  unlike Cross Product: (a x b)x c != a x (b x c)
	/// Anti-commutative: a^b = -b^a
	///
	/// <inheritdoc cref="XPga2D.Meet16P"/>
	/// </remarks>
	/// <example>
	/// <code language="yaml">
	/// tags: [code/extension_method, code/outer_product]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 1}
	/// </code>
	/// </example>
	#region TestCases
	[TestCase(new []{1,2,3,4,5,6,7,8f}, new []{-1,-2,-3,-4,-5,-6,-7,-8f}
		, ExpectedResult = new []{ -1, -4, -6, -8, -10, -12, -14, -120f})]
	[TestCase(new []{0,0,1,0,0,0,0,0f}, new []{0,0,1,0,0,0,0,0f}
		, ExpectedResult = new []{ 0, 0, 0, 0, 0, 0, 0, 0f}
		, TestName = "e1 ^ e1 = 0")]
	[TestCase(new []{0,0,1,0,0,0,0,0f}, new []{0,0,0,1,0,0,0,0f}
		, ExpectedResult = new []{ 0, 0, 0, 0, 0, 0, 1, 0f}
		, TestName = "e1 ^ e2 = e12")]
	[TestCase(new []{0,1,0,0,0,0,0,0f}, new []{0,0,0,1,0,0,0,0f}
		, ExpectedResult = new []{ 0, 0, 0, 0, 0, -1, 0, 0f}
		, TestName = "e0 ^ e2 = e02 = -e20")]
	[TestCase(new []{0,1,0,0,0,0,0,0f}, new []{0,0,1,0,0,0,0,0f}
		, ExpectedResult = new []{ 0, 0, 0, 0, 1, 0, 0, 0f}
		, TestName = "e0 ^ e1 = e01")]
	#endregion TestCases
	public static float[] Meet8P(this IReadOnlyList<float> a, IReadOnlyList<float> b) => new []{
			b[0] * a[0],
			b[1] * a[0] + b[0] * a[1],
			b[2] * a[0] + b[0] * a[2],
			b[3] * a[0] + b[0] * a[3],
			b[4] * a[0] + b[2] * a[1] - b[1] * a[2] + b[0] * a[4],
			b[5] * a[0] - b[3] * a[1] + b[1] * a[3] + b[0] * a[5],
			b[6] * a[0] + b[3] * a[2] - b[2] * a[3] + b[0] * a[6],
			b[7] * a[0] + b[6] * a[1] + b[5] * a[2] + b[4] * a[3] 
		  + b[3] * a[4] + b[2] * a[5] + b[1] * a[6] + b[0] * a[7]};

	/// <inheritdoc cref="Meet8P(IReadOnlyList{float}, IReadOnlyList{float})"/>
	public static double[] Meet8P(this IReadOnlyList<double> a, IReadOnlyList<double> b) => new []{
		b[0] * a[0],
		b[1] * a[0] + b[0] * a[1],
		b[2] * a[0] + b[0] * a[2],
		b[3] * a[0] + b[0] * a[3],
		b[4] * a[0] + b[2] * a[1] - b[1] * a[2] + b[0] * a[4],
		b[5] * a[0] - b[3] * a[1] + b[1] * a[3] + b[0] * a[5],
		b[6] * a[0] + b[3] * a[2] - b[2] * a[3] + b[0] * a[6],
		b[7] * a[0] + b[6] * a[1] + b[5] * a[2] + b[4] * a[3] 
		+ b[3] * a[4] + b[2] * a[5] + b[1] * a[6] + b[0] * a[7]};

	/// <summary> &amp;/v Join/Vee: regressive/interior product; Dual to <see cref="Meet8P"/>. </summary>
	/// <remarks>
	/// 'Joins' Point-Multi-Vectors to Lines and Hyper-Plane-Vectors.
	/// 
	/// Duality is also expressed in the Fact that the Vectors and Bi-Vectors
	/// can simply be swapped between <see cref="Join8P"/> and <see cref="Meet8P"/>.
	///
	/// </remarks>
	/// <example>
	/// <code language="yaml">
	/// tags: [code/extension_method, code/clifford_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 1}
	/// </code>
	/// </example>
	#region TestCases
	[TestCase(new []{1,2,3,4,5,6,7,8f}, new []{-1,-2,-3,-4,-5,-6,-7,-8f}
		, ExpectedResult = new []{ -120, -32, -48, -64, -80, -96, -112, -64f})]
	[TestCase(new []{0,0,0,0,0,1,0,0f}, new []{0,0,0,0,0,1,0,0f}
		, ExpectedResult = new []{ 0, 0, 0, 0, 0, 0, 0, 0f}
		, TestName = "e20 v e20 = 0")]
	[TestCase(new []{0,0,0,0,0,1,0,0f}, new []{0,0,0,0,0,0,1,0f}
		, ExpectedResult = new []{ 0, 0, 0, 1, 0, 0, 0, 0f}
		, TestName = "e20 v e12 = e2")]
	[TestCase(new []{0,0,0,0,1,0,0,0f}, new []{0,0,0,0,0,0,1,0f}
		, ExpectedResult = new []{ 0, 0, -1, 0, 0, 0, 0, 0f}
		, TestName = "e01 v e12 = -e1")]
	[TestCase(new []{0,0,0,0,1,0,0,0f}, new []{0,0,0,0,0,1,0,0f}
		, ExpectedResult = new []{ 0, 1, 0, 0, 0, 0, 0, 0f}
		, TestName = "e01 v e20 = e0")]
	[TestCase(new []{0,0,0,0,0,0,1,0f}, new []{0,0,0,0,1,0,0,0f}
		, ExpectedResult = new []{ 0, 0, 1, 0, 0, 0, 0, 0f}
		, TestName = "e12 v e01 = e1")]
	[TestCase(new []{0,0,0,0,0,0,1,0f}, new []{0,0,0,0,-0.65f,0.1f,1,0f}
		, ExpectedResult = new []{ 0, 0, -0.65f, -0.1f, 0, 0, 0, 0f}
		, TestName = "e12 v P = e1")]
	#endregion TestCases
	public static float[] Join8P(this IReadOnlyList<float> a, IReadOnlyList<float> b) => new []{
		a[0] * b[7] + a[1] * b[6] + a[2] * b[5] + a[3] * b[4] 
		+ a[4] * b[3] + a[5] * b[2] + a[6] * b[1] + a[7] * b[0],
		a[1] * b[7] + a[4] * b[5] - a[5] * b[4] + a[7] * b[1],
		a[2] * b[7] - a[4] * b[6] + a[6] * b[4] + a[7] * b[2],
		a[3] * b[7] + a[5] * b[6] - a[6] * b[5] + a[7] * b[3],
		a[4] * b[7] + a[7] * b[4],
		a[5] * b[7] + a[7] * b[5],
		a[6] * b[7] + a[7] * b[6],
		a[7] * b[7]};

	/// <inheritdoc cref="Join8P(IReadOnlyList{float}, IReadOnlyList{float})"/>
	public static double[] Join8P(this IReadOnlyList<double> a, IReadOnlyList<double> b) => new []{
		a[0] * b[7] + a[1] * b[6] + a[2] * b[5] + a[3] * b[4] 
		+ a[4] * b[3] + a[5] * b[2] + a[6] * b[1] + a[7] * b[0],
		a[1] * b[7] + a[4] * b[5] - a[5] * b[4] + a[7] * b[1],
		a[2] * b[7] - a[4] * b[6] + a[6] * b[4] + a[7] * b[2],
		a[3] * b[7] + a[5] * b[6] - a[6] * b[5] + a[7] * b[3],
		a[4] * b[7] + a[7] * b[4],
		a[5] * b[7] + a[7] * b[5],
		a[6] * b[7] + a[7] * b[6],
		a[7] * b[7]};

	/// <summary>Test Paraxial Optic.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/unit_test, code/paraxial_optics]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: test, status: stable, complexity: 2}
	/// </code>
	/// </example>
	[Test]
	public static void TestParaxialOptic() {
		var point = Pga2D.Make.Point(-0.65, 0.1);
		var origin = Pga2D.Make.Point(0, 0);
		var project = Pga2D.Make.Point(0, 0.1);
		var focus = Pga2D.Make.Point(0.5, 0);

		var rayO = point.Join(origin); var rayONormed = rayO.NormalLine();
		var rayP = point.Join(project); var rayPNormed = rayP.NormalLine();
		var rayPFrac = project.Join(focus); var rayPFracNormed = rayPFrac.NormalLine();
		_ = rayONormed.ShouldBe(Pga2D.Make.Line(-1 / 6.5f, 0));
		var image = rayPFrac.Meet(rayO); var imageNormed = image.NormalPoint();
		PgaAssert.AreClose(imageNormed, Pga2D.Make.Point(13 / 6f, -1 / 3f));
	}

	/// <summary>
	/// Due to the Outer-Morphism of the Products,
	/// the Ray-Matrix Operations can be applied to the k-Blades directly,
	/// resulting in a Matrix Multiplication of the Multi-Vector,
	/// which solves the Construction directly:
	/// 
	/// </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/unit_test, code/paraxial_optics]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: test, status: stable, complexity: 1}
	/// </code>
	/// </example>
	[Test]
	public static void TestParaxialOptic2() {
		var point = Pga2D.Make.Point(-0.65, 0.1);
		var image = Pga2D.Make.Point(-0.65, 0.1, -0.3);
		var imageNormed = image.NormalPoint();
		PgaAssert.AreClose(imageNormed, Pga2D.Make.Point(13 / 6f, -1 / 3f));
	}

	/// <summary>Dot8 P.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/extension_method, code/dot_product]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 1}
	/// </code>
	/// </example>
	[TestCase(new []{1,2,3,4,5,6,7,8f}, new []{ 1, 2, 3, 4, 5, 6, 7, 8f}, ExpectedResult = new []{ -23, -108,  6,  8,  74,  60,  14,  16f})]
	[TestCase(new []{1,2,3,4,5,6,7,8f}, new []{-1,-2,-3,-4,-5,-6,-7,-8f}, ExpectedResult = new []{  23,  108, -6, -8, -74, -60, -14, -16f})]
	[TestCase(new []{-1,-2,-3,-4,-5,-6,-7,-8f}, new []{1,2,3,4,5,6,7,8f}, ExpectedResult = new []{  23,  108, -6, -8, -74, -60, -14, -16f})]
	public static float[] Dot8P(this IReadOnlyList<float> a, IReadOnlyList<float> b) => new []{
		b[0] * a[0] + b[2] * a[2] + b[3] * a[3] - b[6] * a[6],
		b[1] * a[0] + b[0] * a[1] - b[4] * a[2] + b[5] * a[3] + b[2] * a[4] - b[3] * a[5] - b[7] * a[6] - b[6] * a[7],
		b[2] * a[0] + b[0] * a[2] - b[6] * a[3] + b[3] * a[6],
		b[3] * a[0] + b[6] * a[2] + b[0] * a[3] - b[2] * a[6],
		b[4] * a[0] + b[7] * a[3] + b[0] * a[4] + b[3] * a[7],
		b[5] * a[0] + b[7] * a[2] + b[0] * a[5] + b[2] * a[7],
		b[6] * a[0] + b[0] * a[6],
		b[7] * a[0] + b[0] * a[7]};

	/// <inheritdoc cref="Dot8P(IReadOnlyList{float}, IReadOnlyList{float})"/>
	public static double[] Dot8P(this IReadOnlyList<double> a, IReadOnlyList<double> b) => new []{
		b[0] * a[0] + b[2] * a[2] + b[3] * a[3] - b[6] * a[6],
		b[1] * a[0] + b[0] * a[1] - b[4] * a[2] + b[5] * a[3] + b[2] * a[4] - b[3] * a[5] - b[7] * a[6] - b[6] * a[7],
		b[2] * a[0] + b[0] * a[2] - b[6] * a[3] + b[3] * a[6],
		b[3] * a[0] + b[6] * a[2] + b[0] * a[3] - b[2] * a[6],
		b[4] * a[0] + b[7] * a[3] + b[0] * a[4] + b[3] * a[7],
		b[5] * a[0] + b[7] * a[2] + b[0] * a[5] + b[2] * a[7],
		b[6] * a[0] + b[0] * a[6],
		b[7] * a[0] + b[0] * a[7]};

	/* duplicate scalar components
	[TestCase(new []{1,2,3,4,5,6,7,8f}, new []{ 1, 2, 3, 4, 5, 6, 7, 8f})]
	[TestCase(new []{1,2,3,4,5,6,7,8f}, new []{-1,-2,-3,-4,-5,-6,-7,-8f})]
	[TestCase(new []{-1,-2,-3,-4,-5,-6,-7,-8f}, new []{1,2,3,4,5,6,7,8f})]
	public static void TestTimesEqualsDotPlusWedge(IReadOnlyList<float> a, IReadOnlyList<float> b) {
		var times = a.TimesP8(b);
		var dotPlusWedge = a.DotP8(b).Plus8(a.WedgeP8(b));
		CollectionAssert.AreEqual(times, dotPlusWedge);
	}*/

	#endregion Binary Operators

	#region Test Pairs for all Products

	/// <summary>Delegate wrapping the geometric product operation for use in product test pipelines.</summary>
	public static readonly Func<IReadOnlyList<float>, IReadOnlyList<float>, float[]> ProductGeometric = Times8P;
	/// <summary>Delegate wrapping the inner (dot) product operation for use in product test pipelines.</summary>
	public static readonly Func<IReadOnlyList<float>, IReadOnlyList<float>, float[]> ProductDot = Dot8P;
	/// <summary>Delegate wrapping the outer (meet) product operation for use in product test pipelines.</summary>
	public static readonly Func<IReadOnlyList<float>, IReadOnlyList<float>, float[]> ProductOuter = Meet8P;

	/// <summary> Order must conform to the order in <see cref="Dim.Products"/> </summary>
	static readonly Func<IReadOnlyList<float>, IReadOnlyList<float>, float[]>[] _Products = {
		ProductGeometric,
		ProductDot,
		ProductOuter,
	};

	/// <summary>Public read-only view of all three product delegate functions indexed by product type.</summary>
	public static readonly Func<IReadOnlyList<float>, IReadOnlyList<float>, float[]>[] Products = _Products;

	/// <summary> Generates all Test Pairs for all Products in <see cref="Pga2D.Products"/> </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/test_data_generation]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: generator, status: stable, complexity: 2}
	/// </code>
	/// </example>
	public static IEnumerable<(float[][], Func<IReadOnlyList<float>, IReadOnlyList<float>, float[]> product)> AllProductTests() {
		for (var i = Products.Length; --i >= 0; ) {
			foreach (var valueTuple in Pga2D.Products[i].ProductTests(Products[i])) {
				yield return valueTuple;
			}
		}
	}

	/// <summary> Generates all Test Cases for <paramref name="product"/> from <paramref name=""/> Pairs of <see cref="Pga2D"/> Elements </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/extension_method, code/test_data_generation]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: generator, status: stable, complexity: 1}
	/// </code>
	/// </example>
	static IEnumerable<(float[][], Func<IReadOnlyList<float>, IReadOnlyList<float>, float[]> product)
		> ProductTests(this IReadOnlyList<IReadOnlyList<Pga2D.Base>> matrix
		, Func<IReadOnlyList<float>, IReadOnlyList<float>, float[]> product) 
		=> BaseVectorPairs().Select(pair => (matrix.CreateVectors(pair.x, pair.y, 2, 3), product));

	/// <summary> Generates all Pairs of <see cref="Pga2D"/> Base Vectors Elements </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/test_data_generation, code/combinatorial_generation]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: generator, status: stable, complexity: 2}
	/// </code>
	/// </example>
	public static IEnumerable<(Pga2D.Base x, Pga2D.Base y)> BaseVectorPairs() {
		for (var k = Pga2D.Base._1_; k != Pga2D.Base._0; ++k) {
			for (var i = Pga2D.Base._1_; i != Pga2D.Base._0; ++i) {
				yield return (i, k);
			}
			
		}
	}

	/// <summary>Test All Products.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/unit_test]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: test, status: stable, complexity: 2}
	/// </code>
	/// </example>
	[TestCaseSource(nameof(AllProductTests))]
	public static void TestAllProducts((float[][] vectors, Func<IReadOnlyList<float>, IReadOnlyList<float>, float[]> product) test) {
		var z = test.product(test.vectors[0], test.vectors[1]);
		CollectionAssert.AreEqual(test.vectors[2], z);
	}

	/// <summary> Builds a triple of float arrays representing two input basis blades and their expected product result from the given Cayley <paramref name="products"/> table. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/extension_method, code/test_data_generation]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: generator, status: stable, complexity: 1}
	/// </code>
	/// </example>
	public static float[][] CreateVectors(this IReadOnlyList<IReadOnlyList<Pga2D.Base>> products, Pga2D.Base a, Pga2D.Base b, double factor1, double factor2) {
		var (e, factor) = products[(int) a][(int) b].GetFactor();
		return CreateVectors(a, b, factor1, factor2, e, factor);
	}

	/// <inheritdoc cref="CreateVectors(IReadOnlyList{IReadOnlyList{Pga2D.Base}}, Pga2D.Base, Pga2D.Base, double, double)"/>
	public static float[][] CreateVectors(Pga2D.Base a, Pga2D.Base b, double factor1, double factor2, Pga2D.Base e, int factor) {
		var vectors = new[] {
			new float[Pga2D.NUM_COORDS],
			new float[Pga2D.NUM_COORDS],
			new float[Pga2D.NUM_COORDS],
		};
		vectors[0][(int) a] = (float) factor1;
		vectors[1][(int) b] = (float) factor2;
		vectors[2][(int) e] = (float) (factor1 * factor2 * factor);
		return vectors;
	}

	#endregion Test Pairs for all Products

	/// <summary> Returns all values of the <see cref="Pga2D.Base"/> enum as an array for use as NUnit test-case sources. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/enum_values, code/test_case_data_source]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: generator, status: stable, complexity: 1}
	/// </code>
	/// </example>
	public static Pga2D.Base[] GetBases() => (Pga2D.Base[])Enum.GetValues(typeof(Pga2D.Base));

	/// <summary>Test Clifford Is Reversion Of Involution.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/unit_test, code/clifford_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: test, status: stable, complexity: 2}
	/// </code>
	/// </example>
	[TestCaseSource(typeof(XPga2D), nameof(GetBases))]
	public static void TestCliffordIsReversionOfInvolution(Pga2D.Base b) {
		if (b == Pga2D.Base._0) {
			return;
		}
		var involute = Involute(b);
		var reverted = Reverted(b);
		var conjugate = Conjugate(b);
		_ = conjugate.ShouldBe(involute * reverted);
	}

	/// <summary> <see cref="Involute"/> and <see cref="Reverted"/> violate NormSqr when e0 is missing </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/unit_test, code/norm_calculation]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: test, status: stable, complexity: 2}
	/// </code>
	/// </example>
	[TestCaseSource(typeof(XPga2D), nameof(GetBases))]
	public static void TestNormUsesConjugate(Pga2D.Base b) {
		if (b == Pga2D.Base._0) {
			return;
		}

		Pga2D v = b;
		var normSqr = v.NormSqr();
		//var involute = v*v.Involute();
		//var reverted = v*v.Reverted();
		var conjugate = v*v.Conjugate();
		Pga2D expected = Pga2D.Blades[0] * normSqr;
		_ = conjugate.ShouldBe(expected);
		//reverted.ShouldBe(expected); 4 Violations
		//involute.ShouldBe(expected); 4 Violations
	}

	/// <summary>Test Pga2 D.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/unit_test, code/enum_to_string_conversion]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: test, status: stable, complexity: 1}
	/// </code>
	/// </example>
	[TestCase(new []{1,2,3,4,5,6,7,8f}, ExpectedResult = "1 + 2LinesDist + 3LinesX + 4LinesY + 5PointsY + 6PointsX + 7PointsO + 8E012")] //"1 + 2e0 + 3e1 + 4e2 + 5e01 + 6e20 + 7e12 + 8e012")]
	[TestCase(new []{1,-2,-3,-4,-5,-6,-7,-8f}, ExpectedResult = "1 - 2LinesDist - 3LinesX - 4LinesY - 5PointsY - 6PointsX - 7PointsO - 8E012")] //"1 - 2e0 - 3e1 - 4e2 - 5e01 - 6e20 - 7e12 - 8e012")]
	[TestCase(new []{1,1,1,1,1,1,1,1f}, ExpectedResult = "1 + LinesDist + LinesX + LinesY + PointsY + PointsX + PointsO + E012")] //"1 + e0 + e1 + e2 + e01 + e20 + e12 + e012")]
	[TestCase(new []{0,0,0,0,0,0,0,0f}, ExpectedResult = "0")]
	public static string TestPga2D(float[] coords) => Pga2D.New(coords).ToString();

	/// <summary>Shared random number generator for property-based test data.</summary>
	static readonly Random RANDOM = new(PgaTolerance.TestSeed); //fixed Seed: reproducible Test-Cases

	/// <summary> Generates 99 random <see cref="Pga2D"/> multi-vectors with uniformly distributed components for property-based tests. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/random_number_generator, code/test_data_generation]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: generator, status: stable, complexity: 2}
	/// </code>
	/// </example>
	public static IEnumerable<Pga2D> RandomPga2D() {
		var arr = new float[Pga2D.NUM_COORDS];
		for (int i = 99; --i >= 0;) {
			for (int j = arr.Length; --j >= 0; ) {
				arr[j] = (float) RANDOM.NextDouble();
			}
			yield return new Pga2D(arr);
		}
	}

	/// <summary> Generates 99 random <see cref="Pga2Dbl"/> multi-vectors with uniformly distributed components for property-based tests. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/random_number_generator, code/test_data_generation]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: generator, status: stable, complexity: 2}
	/// </code>
	/// </example>
	public static IEnumerable<Pga2Dbl> RandomPga2Dbl() {
		var arr = new double[Pga2Dbl.NUM_COORDS];
		for (int i = 99; --i >= 0;) {
			for (int j = arr.Length; --j >= 0; ) {
				arr[j] = (float) RANDOM.NextDouble();
			}
			yield return new Pga2Dbl(arr);
		}
	}

	//public static Pga2D V = Pga2D.New(0.3930514f, 0.34103f, 0.33337f, 0.86646f, 0.53839f, 0.43939f, 0.82422f, 0.17893f);
	//public static Pga2D W = Pga2D.New(0.09676535f, 0.0069433f, 0.58293f, 0.32796f, 0.94353f, 0.86537f, 0.65967f, 0.65629f);
	/// <summary>Fixed sample <see cref="Pga2Dbl"/> multi-vector used as a property-based test input.</summary>
	public static Pga2Dbl W = Pga2Dbl.New(0.09676535, 0.0069433, 0.58293, 0.32796, 0.94353, 0.86537, 0.65967, 0.65629);
	/// <summary>Fixed sample <see cref="Pga2Dbl"/> multi-vector used as a property-based test input.</summary>
	public static Pga2Dbl V = Pga2Dbl.New(0.17532667517662, 0.97128, 0.2935, 0.14408, 0.3228,0.99319, 0.27686, 0.016684);

	/// <summary>Fixed invertible <see cref="Pga2Dbl"/> multi-vectors used as static test cases.</summary>
	static readonly Pga2Dbl[] _Tests = { Pga2Dbl._1_//, Pga2Dbl.E012 MVs containing E0
		, Pga2Dbl.E12//, Pga2Dbl.E01, Pga2Dbl.E02, Pga2Dbl.E0 ...don't invert properly!
		, Pga2Dbl.E1, Pga2Dbl.E2, V, W };
	/// <summary>Public read-only view of all fixed invertible <see cref="Pga2Dbl"/> test cases.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/test_fixture_data]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: generator, status: stable, complexity: 1}
	/// </code>
	/// </example>
	public static IReadOnlyList<Pga2Dbl> Tests => _Tests;

	/// <summary>Test Rcp.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/unit_test, code/reciprocal]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: test, status: stable, complexity: 2}
	/// </code>
	/// </example>
	[TestCaseSource(nameof(Tests))]
	[TestCaseSource(nameof(RandomPga2Dbl))]
	public static void TestRcp(Pga2Dbl mv) {
		var rcp = mv.Rcp();
		var r1 = mv.Times(rcp);
		r1.ShouldBeApprox(Pga2Dbl._1_, 1e-4); //3e-6 fails for ill-conditioned random Inputs (Residual 1.7e-5 with Seed TestSeed)

		var r2 = mv.Times(rcp);
		r2.ShouldBeApprox(Pga2Dbl._1_, 1e-4);
	}

	//[TestCaseSource(nameof(Tests))]
	/// <inheritdoc cref="TestRcp(Pga2Dbl)"/>
	[TestCaseSource(nameof(RandomPga2D))]
	public static void TestRcp(Pga2D mv) {
		var rcp = mv.Rcp();
		var r1 = mv.Times(rcp);
		r1.ShouldBeApprox(Pga2D._1_, 1e-3); //5e-2

		var r2 = mv.Times(rcp);
		r2.ShouldBeApprox(Pga2D._1_, 1e-3);
	}
}
