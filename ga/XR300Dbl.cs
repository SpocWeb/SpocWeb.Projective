using System;
using System.Collections.Generic;
using NUnit.Framework;
using org.SpocWeb.root.extensions.maths;

namespace org.SpocWeb.root.maths.pga.ga;

/// <summary> R^3 Vector-Space with Rotations and Reflections </summary>
/// <remarks>
///
/// </remarks>
/// <example>
/// <code language="yaml">
/// pass: 2
/// mtime: 2026-07-07T17:46:00Z
/// digest: 4606df1b40259b4a1937914cbde72c0a02470164e71b07c0adfe2b737dbaf4af
/// tags: [code/extension_method, code/clifford_algebra]
/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
/// facets: {layer: domain, status: stable, complexity: 2}
/// </code>
/// </example>
// ReSharper disable once InconsistentNaming
public static class XR300Dbl
{
	#region unary Operations

	/// <summary> ~a; Complex/Quaternion Conjugate for <see cref="R300"/> and <see cref="Pga2D"/>. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/extension_method, code/clifford_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 1}
	/// </code>
	/// </example>
	[TestCase(new []{1,2,3,4,5,6,7,8.0}, ExpectedResult = new []{1, 2, 3, 4, -5, -6, -7, -8.0})]
	public static double[] Reverted8(this IReadOnlyList<double> a) => new []{a[0], a[1], a[2], a[3], -a[4], -a[5], -a[6], -a[7]};

	/// <summary> !a; Poincare duality operator. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/extension_method, code/clifford_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 1}
	/// </code>
	/// </example>
	[TestCase(new []{1,2,3,4,5,6,7,8.0}, ExpectedResult = new []{-8, -7, 6, -5, 4, -3, 2, 1.0})]
	public static double[] Dual8(this IReadOnlyList<double> a) => new []{-a[7], -a[6], a[5], -a[4], a[3], -a[2], a[1], a[0]};

	/// <summary> Involution both for <see cref="R300"/> and <see cref="Pga2D"/> </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/extension_method, code/clifford_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 1}
	/// </code>
	/// </example>
	[TestCase(new []{1,2,3,4,5,6,7,8.0}, ExpectedResult = new []{1, -2, -3, -4, 5, 6, 7, -8.0})]
	public static double[] Involute8(this IReadOnlyList<double> a) => new []{a[0], -a[1], -a[2], -a[3], a[4], a[5], a[6], -a[7]};

	/// <summary> Negates all eight components of an 8-element double-precision multivector coordinate array. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/extension_method, code/negation]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 1}
	/// </code>
	/// </example>
	public static double[] Neg8(this IReadOnlyList<double> c) => new[] {-c[0], -c[1], -c[2], -c[3], -c[4], -c[5], -c[6], -c[7]};

	/// <summary> Clifford Conjugate both for <see cref="Pga2D"/> and <see cref="R300"/></summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/extension_method, code/conjugate]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 1}
	/// </code>
	/// </example>
	[TestCase(new []{1,2,3,4,5,6,7,8.0}, ExpectedResult = new []{1, -2, -3, -4, -5, -6, -7, 8.0})]
	public static double[] CliffCjg8(this IReadOnlyList<double> a) => new []{a[0], -a[1], -a[2], -a[3], -a[4], -a[5], -a[6], a[7]};

	/// <summary>Norm Sqr6 R300 Q.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/norm_calculation]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 1}
	/// </code>
	/// </example>
	[TestCase(new []{1,2,3,4,5,6,7,8.0}, ExpectedResult = 18)]
	[TestCase(new []{1,8,7,6,5,4,3,2.0}, ExpectedResult = -102)]
	public static double NormSqr6R300Q(IReadOnlyList<double> c) => c.Times8(c.CliffCjg8())[0];
	/// <summary>Norm Sqr6 R300.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/extension_method, code/norm_calculation]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 1}
	/// </code>
	/// </example>
	[TestCase(new []{1,2,3,4,5,6,7,8.0}, ExpectedResult = 18)]
	[TestCase(new []{1,8,7,6,5,4,3,2.0}, ExpectedResult = -102)]
	public static double NormSqr6R300(this IReadOnlyList<double> a) => a[0].Sqr()
		- a[1].Sqr() - a[2].Sqr() - a[3].Sqr() + a[4].Sqr() + a[5].Sqr() + a[6].Sqr() - a[7].Sqr();

	#endregion unary Operations

	#region binary Operations

	/// <summary> Full geometric product: ^ + * </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/extension_method, code/geometric_product]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 2}
	/// </code>
	/// </example>
	[TestCase(new []{1,2,3,4,5,6,7,8.0}, new []{-1,-2,-3,-4,-5,-6,-7,-8.0}
		, ExpectedResult = new []{144, 108, -102, 72, -74, 36, -46, -48.0})]
	public static double[] Times8(this IReadOnlyList<double> a, IReadOnlyList<double> b) =>
		new []{
			b[0] * a[0] + b[1] * a[1] + b[2] * a[2] + b[3] * a[3] - b[4] * a[4] - b[5] * a[5] - b[6] * a[6] - b[7] * a[7],
			b[1] * a[0] + b[0] * a[1] - b[4] * a[2] - b[5] * a[3] + b[2] * a[4] + b[3] * a[5] - b[7] * a[6] - b[6] * a[7],
			b[2] * a[0] + b[4] * a[1] + b[0] * a[2] - b[6] * a[3] - b[1] * a[4] + b[7] * a[5] + b[3] * a[6] + b[5] * a[7],
			b[3] * a[0] + b[5] * a[1] + b[6] * a[2] + b[0] * a[3] - b[7] * a[4] - b[1] * a[5] - b[2] * a[6] - b[4] * a[7],
			b[4] * a[0] + b[2] * a[1] - b[1] * a[2] + b[7] * a[3] + b[0] * a[4] - b[6] * a[5] + b[5] * a[6] + b[3] * a[7],
			b[5] * a[0] + b[3] * a[1] - b[7] * a[2] - b[1] * a[3] + b[6] * a[4] + b[0] * a[5] - b[4] * a[6] - b[2] * a[7],
			b[6] * a[0] + b[7] * a[1] + b[3] * a[2] - b[2] * a[3] - b[5] * a[4] + b[4] * a[5] + b[0] * a[6] + b[1] * a[7],
			b[7] * a[0] + b[6] * a[1] - b[5] * a[2] + b[4] * a[3] + b[3] * a[4] - b[2] * a[5] + b[1] * a[6] + b[0] * a[7]
		};

	/// <summary> ^ MEET/Wedge; outer (Grassmann) product </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/extension_method, code/outer_product]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 2}
	/// </code>
	/// </example>
	[TestCase(new[] {1, 2, 3, 4, 5, 6, 7, 8.0}, new[] {-1, -2, -3, -4, -5, -6, -7, -8.0}
		, ExpectedResult = new[] {-1, -4, -6, -8, -10, -12, -14, -48.0})]
	public static double[] Meet8(this IReadOnlyList<double> a, IReadOnlyList<double> b) => new[] {
			b[0] * a[0],
			b[1] * a[0] + b[0] * a[1],
			b[2] * a[0] + b[0] * a[2],
			b[3] * a[0] + b[0] * a[3],
			b[4] * a[0] + b[2] * a[1] - b[1] * a[2] + b[0] * a[4],
			b[5] * a[0] + b[3] * a[1] - b[1] * a[3] + b[0] * a[5],
			b[6] * a[0] + b[3] * a[2] - b[2] * a[3] + b[0] * a[6],
			b[7] * a[0] + b[6] * a[1] - b[5] * a[2] + b[4] * a[3]
		  + b[3] * a[4] - b[2] * a[5] + b[1] * a[6] + b[0] * a[7]
		};

	/// <summary> regressive product. (JOIN) symmetric </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/extension_method, code/clifford_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 2}
	/// </code>
	/// </example>
	[TestCase(new []{1,2,3,4,5,6,7,8.0}, new []{1,2,3,4,5,6,7,8.0}, ExpectedResult = new []{48,32,48,64,80,96,112,64.0})]
	[TestCase(new []{1,2,3,4,5,6,7,8.0}, new []{-1,-2,-3,-4,-5,-6,-7,-8.0}, ExpectedResult = new []{  -48, -32, -48, -64, -80, -96, -112, -64.0})]
	[TestCase(new []{-1,-2,-3,-4,-5,-6,-7,-8.0}, new []{1,2,3,4,5,6,7,8.0}, ExpectedResult = new []{  -48, -32, -48, -64, -80, -96, -112, -64.0})]
	public static double[] Join8(this IReadOnlyList<double> a, IReadOnlyList<double> b) =>
		new []{
			a[0] * b[7] + a[1] * b[6] - a[2] * b[5] + a[3] * b[4] + a[4] * b[3] - a[5] * b[2] +
			a[6] * b[1] + a[7] * b[0],
			a[7] * b[1] + a[1] * b[7] - a[4] * b[5] + a[5] * b[4],
			a[2] * b[7] - a[4] * b[6] + a[6] * b[4] + a[7] * b[2],
			a[3] * b[7] - a[5] * b[6] + a[6] * b[5] + a[7] * b[3],
			a[4] * b[7] + a[7] * b[4],
			a[5] * b[7] + a[7] * b[5],
			a[6] * b[7] + a[7] * b[6],
			a[7] * b[7]
		};

	/// <summary> inner/Dot product. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/extension_method, code/dot_product]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 2}
	/// </code>
	/// </example>
	[TestCase(new []{1,2,3,4,5,6,7,8.0}, new []{ 1, 2, 3, 4, 5, 6, 7, 8.0}, ExpectedResult = new []{ -144, -108,  102, -72, 74, -36, 46, 16.0})]
	[TestCase(new []{1,2,3,4,5,6,7,8.0}, new []{-1,-2,-3,-4,-5,-6,-7,-8.0}, ExpectedResult = new []{  144,  108, -102, 72, -74, 36, -46, -16.0})]
	[TestCase(new []{-1,-2,-3,-4,-5,-6,-7,-8.0}, new []{1,2,3,4,5,6,7,8.0}, ExpectedResult = new []{  144,  108, -102, 72, -74, 36, -46, -16.0})]
	public static double[] Dot8(this IReadOnlyList<double> a, IReadOnlyList<double> b) =>
		new []{
			b[0] * a[0] + b[1] * a[1] + b[2] * a[2] + b[3] * a[3] - b[4] * a[4] - b[5] * a[5] - b[6] * a[6] - b[7] * a[7],
			b[1] * a[0] + b[0] * a[1] - b[4] * a[2] - b[5] * a[3] + b[2] * a[4] + b[3] * a[5] - b[7] * a[6] - b[6] * a[7],
			b[2] * a[0] + b[4] * a[1] + b[0] * a[2] - b[6] * a[3] - b[1] * a[4] + b[7] * a[5] + b[3] * a[6] + b[5] * a[7],
			b[3] * a[0] + b[5] * a[1] + b[6] * a[2] + b[0] * a[3] - b[7] * a[4] - b[1] * a[5] - b[2] * a[6] - b[4] * a[7],
			b[4] * a[0] + b[7] * a[3] + b[0] * a[4] + b[3] * a[7],
			b[5] * a[0] - b[7] * a[2] + b[0] * a[5] - b[2] * a[7],
			b[6] * a[0] + b[7] * a[1] + b[0] * a[6] + b[1] * a[7],
			b[7] * a[0] + b[0] * a[7]
		};

	#endregion binary Operations

	#region Test Pairs for all Products

	/// <summary>Gets the product Geometric.</summary>
	public static readonly Func<IReadOnlyList<double>, IReadOnlyList<double>, double[]> ProductGeometric = Times8;
	/// <summary>Gets the product Dot.</summary>
	public static readonly Func<IReadOnlyList<double>, IReadOnlyList<double>, double[]> ProductDot = Dot8;
	/// <summary>Gets the product Outer.</summary>
	public static readonly Func<IReadOnlyList<double>, IReadOnlyList<double>, double[]> ProductOuter = Meet8;

	/// <summary> Order must conform to the order in <see cref="R300.Products"/> </summary>
	static readonly Func<IReadOnlyList<double>, IReadOnlyList<double>, double[]>[] _Products = {
		ProductGeometric,
		ProductDot,
		ProductOuter,
	};

	/// <summary>Gets the products.</summary>
	public static readonly Func<IReadOnlyList<double>, IReadOnlyList<double>, double[]>[] Products = _Products;

	/// <summary> Generates all Pairs of <see cref="R300"/> Base Vectors Elements </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/test_data_generation, code/combinatorial_generation]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 2}
	/// </code>
	/// </example>
	public static IEnumerable<(R300.Base x, R300.Base y)> BaseVectorPairs() {
		for (var k = R300.Base._1_; k != R300.Base._0; ++k) {
			for (var i = R300.Base._1_; i != R300.Base._0; ++i) {
				yield return (i, k);
			}
			
		}
	}

	/// <summary> Creates a three-element double-precision test vector array representing operands and their expected
	/// product result for the given basis elements and scale factors. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/test_data_generation]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 1}
	/// </code>
	/// </example>
	public static double[][] CreateVectors(R300.Base a, R300.Base b, double factor1, double factor2, R300.Base e, int factor) {
		var vectors = new[] {
			new double[R300.NUM_COORDS],
			new double[R300.NUM_COORDS],
			new double[R300.NUM_COORDS],
		};
		vectors[0][(int) a] = factor1;
		vectors[1][(int) b] = factor2;
		vectors[2][(int) e] = (factor1 * factor2 * factor);
		return vectors;
	}

	#endregion Test Pairs for all Products

	/// <summary>Plus8.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/extension_method, code/vector_addition]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 1}
	/// </code>
	/// </example>
	[TestCase(new []{1,2,3,4,5,6,7,8.0}, new []{1,2,3,4,5,6,7,8.0}
		, ExpectedResult = new []{2,4,6,8,10,12,14,16.0})]
	[TestCase(new []{1,2,3,4,5,6,7,8,1,2,3,4,5,6,7,8.0}, new []{-1,-2,-3,-4,-5,-6,-7,-8.0}
		, ExpectedResult = new []{0,0,0,0,0,0,0,0.0})]
	[TestCase(new []{-1,-2,-3,-4,-5,-6,-7,-8.0}, new []{1,2,3,4,5,6,7,8.0}
		, ExpectedResult = new []{0,0,0,0,0,0,0,0.0})]
	public static double[] Plus8(this IReadOnlyList<double> a, IReadOnlyList<double> b) => new []{
		a[0] + b[0],
		a[1] + b[1],
		a[2] + b[2],
		a[3] + b[3],
		a[4] + b[4],
		a[5] + b[5],
		a[6] + b[6],
		a[7] + b[7]};

	/// <summary> - Minus, SUB; Vector[8] Subtraction </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/extension_method, code/vector_subtraction]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 1}
	/// </code>
	/// </example>
	[TestCase(new []{1,2,3,4,5,6,7,8.0}, new []{1,2,3,4,5,6,7,8.0}
		, ExpectedResult = new []{0,0,0,0,0,0,0,0.0})]
	[TestCase(new []{1,2,3,4,5,6,7,8,1,2,3,4,5,6,7,8.0}, new []{-1,-2,-3,-4,-5,-6,-7,-8.0}
		, ExpectedResult = new []{2,4,6,8,10,12,14,16.0})]
	[TestCase(new []{-1,-2,-3,-4,-5,-6,-7,-8.0}, new []{1,2,3,4,5,6,7,8.0}
		, ExpectedResult = new []{-2,-4,-6,-8,-10,-12,-14,-16.0})]
	public static double[] Minus8(this IReadOnlyList<double> a, IReadOnlyList<double> b) => new []{
			a[0] - b[0],
			a[1] - b[1],
			a[2] - b[2],
			a[3] - b[3],
			a[4] - b[4],
			a[5] - b[5],
			a[6] - b[6],
			a[7] - b[7]};

	/// <summary> * sMul / Times : scalar/multi-vector multiplication </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/extension_method, code/scalar_multiplication]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 1}
	/// </code>
	/// </example>
	[TestCase(new []{1,2,3,4,5,6,7,8.0}, 3
		, ExpectedResult = new []{3,6,9,12,15,18,21,24.0})]
	[TestCase(new []{-1,-2,-3,-4,-5,-6,-7,-8.0}, 3
		, ExpectedResult = new []{-3,-6,-9,-12,-15,-18,-21,-24.0})]
	public static double[] Times8(this IReadOnlyList<double> a, double b) => new []{
		a[0] * b,
		a[1] * b,
		a[2] * b,
		a[3] * b,
		a[4] * b,
		a[5] * b,
		a[6] * b,
		a[7] * b};

	/// <summary>Gets the neg Norm Sqr.<br/>
	/// Gets the _ Test Cases.</summary>
	static readonly R300 NegNormSqr = new(new[] {1, 8, 7, 6, 5, 4, 3, 2f});

	static readonly R300[] _TestCases = {NegNormSqr};
	/// <summary>Gets the test Cases.</summary>
	public static readonly IReadOnlyList<R300> TestCases = _TestCases;

}

