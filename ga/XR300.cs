using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using NUnit.Framework;
using org.SpocWeb.root.array;
using org.SpocWeb.root.extensions.maths;

namespace org.SpocWeb.root.maths.pga.ga;

/// <summary> R^3 Vector-Space with Rotations and Reflections </summary>
/// <remarks>
///
/// </remarks>
/// <example>
/// <code language="yaml">
/// pass: 2
/// mtime: 2026-07-07T17:45:52Z
/// digest: 94e855737d5e656acba751198878b6e35e7f073927132e63e817b8046d2e05d3
/// tags: [code/extension_method, code/clifford_algebra]
/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
/// facets: {layer: domain, status: stable, complexity: 2}
/// </code>
/// </example>
// ReSharper disable once InconsistentNaming
public static class XR300
{
	/// <summary> Returns the canonical positive basis element and its sign factor for <paramref name="e"/>,
	/// yielding factor 0 for the zero element. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/extension_method, code/canonicalization]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 2}
	/// </code>
	/// </example>
	public static (R300.Base e, int factor) GetFactor(this R300.Base e)
		=> e < 0 ? (~e, -1) : e == R300.Base._0 ? (R300.Base._1_, 0) : (e, 1);

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
	[TestCase(new []{1,2,3,4,5,6,7,8f}, ExpectedResult = new []{1, 2, 3, 4, -5, -6, -7, -8f})]
	public static float[] Reverted8(this IReadOnlyList<float> a) => new []{a[0], a[1], a[2], a[3], -a[4], -a[5], -a[6], -a[7]};

	/// <summary> !a; Poincare duality operator. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/extension_method, code/clifford_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 1}
	/// </code>
	/// </example>
	[TestCase(new []{1,2,3,4,5,6,7,8f}, ExpectedResult = new []{-8, -7, 6, -5, 4, -3, 2, 1f})]
	public static float[] Dual8(this IReadOnlyList<float> a) => new []{-a[7], -a[6], a[5], -a[4], a[3], -a[2], a[1], a[0]};

	/// <summary> Involution both for <see cref="R300"/> and <see cref="Pga2D"/> </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/extension_method, code/clifford_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 1}
	/// </code>
	/// </example>
	[TestCase(new []{1,2,3,4,5,6,7,8f}, ExpectedResult = new []{1, -2, -3, -4, 5, 6, 7, -8f})]
	public static float[] Involute8(this IReadOnlyList<float> a) => new []{a[0], -a[1], -a[2], -a[3], a[4], a[5], a[6], -a[7]};

	/// <summary> Negates all eight components of an 8-element multivector coordinate array. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/extension_method, code/negation]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 1}
	/// </code>
	/// </example>
	public static float[] Neg8(this IReadOnlyList<float> c) => new[] {-c[0], -c[1], -c[2], -c[3], -c[4], -c[5], -c[6], -c[7]};

	/// <summary> Clifford Conjugate both for <see cref="Pga2D"/> and <see cref="R300"/></summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/extension_method, code/conjugate]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 1}
	/// </code>
	/// </example>
	[TestCase(new []{1,2,3,4,5,6,7,8f}, ExpectedResult = new []{1, -2, -3, -4, -5, -6, -7, 8f})]
	public static float[] CliffCjg8(this IReadOnlyList<float> a) => new []{a[0], -a[1], -a[2], -a[3], -a[4], -a[5], -a[6], a[7]};

	/// <summary>Norm Sqr6 R300 Q.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/norm_calculation]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 1}
	/// </code>
	/// </example>
	[TestCase(new []{1,2,3,4,5,6,7,8f}, ExpectedResult = 18)]
	[TestCase(new []{1,8,7,6,5,4,3,2f}, ExpectedResult = -102)]
	public static float NormSqr6R300Q(IReadOnlyList<float> c) => c.Times8(c.CliffCjg8())[0];
	/// <summary>Norm Sqr6 R300.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/extension_method, code/norm_calculation]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 1}
	/// </code>
	/// </example>
	[TestCase(new []{1,2,3,4,5,6,7,8f}, ExpectedResult = 18)]
	[TestCase(new []{1,8,7,6,5,4,3,2f}, ExpectedResult = -102)]
	public static float NormSqr6R300(this IReadOnlyList<float> a) => a[0].Sqr()
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
	[TestCase(new []{1,2,3,4,5,6,7,8f}, new []{-1,-2,-3,-4,-5,-6,-7,-8f}
		, ExpectedResult = new []{144, 108, -102, 72, -74, 36, -46, -48f})]
	public static float[] Times8(this IReadOnlyList<float> a, IReadOnlyList<float> b) =>
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
	[TestCase(new[] {1, 2, 3, 4, 5, 6, 7, 8f}, new[] {-1, -2, -3, -4, -5, -6, -7, -8f}
		, ExpectedResult = new[] {-1, -4, -6, -8, -10, -12, -14, -48f})]
	public static float[] Meet8(this IReadOnlyList<float> a, IReadOnlyList<float> b) => new[] {
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
	[TestCase(new []{1,2,3,4,5,6,7,8f}, new []{1,2,3,4,5,6,7,8f}, ExpectedResult = new []{48,32,48,64,80,96,112,64f})]
	[TestCase(new []{1,2,3,4,5,6,7,8f}, new []{-1,-2,-3,-4,-5,-6,-7,-8f}, ExpectedResult = new []{  -48, -32, -48, -64, -80, -96, -112, -64f})]
	[TestCase(new []{-1,-2,-3,-4,-5,-6,-7,-8f}, new []{1,2,3,4,5,6,7,8f}, ExpectedResult = new []{  -48, -32, -48, -64, -80, -96, -112, -64f})]
	public static float[] Join8(this IReadOnlyList<float> a, IReadOnlyList<float> b) =>
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
	[TestCase(new []{1,2,3,4,5,6,7,8f}, new []{ 1, 2, 3, 4, 5, 6, 7, 8f}, ExpectedResult = new []{ -144, -108,  102, -72, 74, -36, 46, 16f})]
	[TestCase(new []{1,2,3,4,5,6,7,8f}, new []{-1,-2,-3,-4,-5,-6,-7,-8f}, ExpectedResult = new []{  144,  108, -102, 72, -74, 36, -46, -16f})]
	[TestCase(new []{-1,-2,-3,-4,-5,-6,-7,-8f}, new []{1,2,3,4,5,6,7,8f}, ExpectedResult = new []{  144,  108, -102, 72, -74, 36, -46, -16f})]
	public static float[] Dot8(this IReadOnlyList<float> a, IReadOnlyList<float> b) =>
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
	public static readonly Func<IReadOnlyList<float>, IReadOnlyList<float>, float[]> ProductGeometric = Times8;
	/// <summary>Gets the product Dot.</summary>
	public static readonly Func<IReadOnlyList<float>, IReadOnlyList<float>, float[]> ProductDot = Dot8;
	/// <summary>Gets the product Outer.</summary>
	public static readonly Func<IReadOnlyList<float>, IReadOnlyList<float>, float[]> ProductOuter = Meet8;

	/// <summary> Order must conform to the order in <see cref="R300.Products"/> </summary>
	static readonly Func<IReadOnlyList<float>, IReadOnlyList<float>, float[]>[] _Products = {
		ProductGeometric,
		ProductDot,
		ProductOuter,
	};

	/// <summary>Gets the products.</summary>
	public static readonly Func<IReadOnlyList<float>, IReadOnlyList<float>, float[]>[] Products = _Products;

	/// <summary> Generates all Test Pairs for all Products in <see cref="R300.Products"/> </summary>
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
			foreach (var valueTuple in R300.Products[i].ProductTests(Products[i])) {
				yield return valueTuple;
			}
		}
	}

	/// <summary> Generates all Test Cases for <paramref name="product"/> from Pairs of <see cref="R300"/> Elements </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/extension_method, code/test_data_generation]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: generator, status: stable, complexity: 1}
	/// </code>
	/// </example>
	static IEnumerable<(float[][], Func<IReadOnlyList<float>, IReadOnlyList<float>, float[]> product)
		> ProductTests(this IReadOnlyList<IReadOnlyList<R300.Base>> matrix
		, Func<IReadOnlyList<float>, IReadOnlyList<float>, float[]> product) 
		=> BaseVectorPairs().Select(pair => (matrix.CreateVectors(pair.x, pair.y, 2, 3), product));

	/// <summary> Generates all Pairs of <see cref="R300"/> Base Vectors Elements </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/test_data_generation, code/combinatorial_generation]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: generator, status: stable, complexity: 2}
	/// </code>
	/// </example>
	public static IEnumerable<(R300.Base x, R300.Base y)> BaseVectorPairs() {
		for (var k = R300.Base._1_; k != R300.Base._0; ++k) {
			for (var i = R300.Base._1_; i != R300.Base._0; ++i) {
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

	/// <summary> Creates a three-element test vector array representing operand <paramref name="a"/>,
	/// operand <paramref name="b"/> and their expected product result according to <paramref name="products"/>. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/extension_method, code/test_data_generation]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: generator, status: stable, complexity: 1}
	/// </code>
	/// </example>
	public static float[][] CreateVectors(this IReadOnlyList<IReadOnlyList<R300.Base>> products, R300.Base a, R300.Base b, double factor1, double factor2) {
		var (e, factor) = products[(int) a][(int) b].GetFactor();
		return CreateVectors(a, b, factor1, factor2, e, factor);
	}

	/// <inheritdoc cref="CreateVectors(IReadOnlyList{IReadOnlyList{R300.Base}}, R300.Base, R300.Base, double, double)"/>
	public static float[][] CreateVectors(R300.Base a, R300.Base b, double factor1, double factor2, R300.Base e, int factor) {
		var vectors = new[] {
			new float[R300.NUM_COORDS],
			new float[R300.NUM_COORDS],
			new float[R300.NUM_COORDS],
		};
		vectors[0][(int) a] = (float) factor1;
		vectors[1][(int) b] = (float) factor2;
		vectors[2][(int) e] = (float) (factor1 * factor2 * factor);
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
	[TestCase(new []{1,2,3,4,5,6,7,8f}, new []{1,2,3,4,5,6,7,8f}
		, ExpectedResult = new []{2,4,6,8,10,12,14,16f})]
	[TestCase(new []{1,2,3,4,5,6,7,8,1,2,3,4,5,6,7,8f}, new []{-1,-2,-3,-4,-5,-6,-7,-8f}
		, ExpectedResult = new []{0,0,0,0,0,0,0,0f})]
	[TestCase(new []{-1,-2,-3,-4,-5,-6,-7,-8f}, new []{1,2,3,4,5,6,7,8f}
		, ExpectedResult = new []{0,0,0,0,0,0,0,0f})]
	public static float[] Plus8(this IReadOnlyList<float> a, IReadOnlyList<float> b) => new []{
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
	[TestCase(new []{1,2,3,4,5,6,7,8f}, new []{1,2,3,4,5,6,7,8f}
		, ExpectedResult = new []{0,0,0,0,0,0,0,0f})]
	[TestCase(new []{1,2,3,4,5,6,7,8,1,2,3,4,5,6,7,8f}, new []{-1,-2,-3,-4,-5,-6,-7,-8f}
		, ExpectedResult = new []{2,4,6,8,10,12,14,16f})]
	[TestCase(new []{-1,-2,-3,-4,-5,-6,-7,-8f}, new []{1,2,3,4,5,6,7,8f}
		, ExpectedResult = new []{-2,-4,-6,-8,-10,-12,-14,-16f})]
	public static float[] Minus8(this IReadOnlyList<float> a, IReadOnlyList<float> b) => new []{
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
	[TestCase(new []{1,2,3,4,5,6,7,8f}, 3
		, ExpectedResult = new []{3,6,9,12,15,18,21,24f})]
	[TestCase(new []{-1,-2,-3,-4,-5,-6,-7,-8f}, 3
		, ExpectedResult = new []{-3,-6,-9,-12,-15,-18,-21,-24f})]
	public static float[] Times8(this IReadOnlyList<float> a, float b) => new []{
		a[0] * b,
		a[1] * b,
		a[2] * b,
		a[3] * b,
		a[4] * b,
		a[5] * b,
		a[6] * b,
		a[7] * b};

	/// <summary>Gets the rANDOM.</summary>
	static readonly Random RANDOM = new(PgaTolerance.TestSeed); //fixed Seed: reproducible Test-Cases

	/// <summary> Generates 99 random <see cref="R300"/> multivectors for use as test inputs. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/random_number_generator, code/test_data_generation]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: generator, status: stable, complexity: 2}
	/// </code>
	/// </example>
	public static IEnumerable<R300> RandomR300() {
		var arr = new float[R300.NUM_COORDS];
		for (int i = 99; --i >= 0;) {
			for (int j = arr.Length; --j >= 0; ) {
				arr[j] = (float) RANDOM.NextDouble();
			}
			yield return new R300(arr);
		}
	}

	/// <summary> Generates 99 random grade-1 (vector) <see cref="R300"/> elements for use as test inputs. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/random_number_generator, code/test_data_generation]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: generator, status: stable, complexity: 2}
	/// </code>
	/// </example>
	public static IEnumerable<R300> RandomR300Vector() {
		var arr = new float[R300.NUM_COORDS];
		for (int i = 99; --i >= 0;) {
			for (int j = 4; --j > 0; ) {
				arr[j] = (float) RANDOM.NextDouble();
			}
			yield return new R300(arr);
		}
	}

	/// <summary>Test Associativity.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/unit_test, code/algebraic_properties]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: test, status: stable, complexity: 2}
	/// </code>
	/// </example>
	[TestCaseSource(nameof(RandomR300))]
	[SuppressMessage("ReSharper", "InconsistentNaming")]
	public static void TestAssociativity(R300 u) {
		var v = RandomR300().First();
		var w = RandomR300().First();
		var uv_w = (u * v) * w;
		var u_vw = u * (v * w);
		uv_w.ShouldBeApprox(u_vw);
	}

	/// <summary>Test Inverse Vector.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/unit_test, code/reciprocal]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: test, status: stable, complexity: 2}
	/// </code>
	/// </example>
	[TestCaseSource(nameof(RandomR300))]
	public static void TestInverseVector(R300 u) {
		var v = RandomR300Vector().First();
		var uv = u * v;
		var uvv = -uv * v / (v.NormSqr());
		uvv.ShouldBeApprox(u);
	}

	/// <summary>Test Rcp.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/unit_test, code/reciprocal]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: test, status: stable, complexity: 2}
	/// </code>
	/// </example>
	[TestCaseSource(typeof(R300), nameof(R300.Blades))]
	[TestCaseSource(nameof(RandomR300))]
	public static void TestRcp(R300 mv) {
		var rcp = mv.Rcp();
		var r1 = mv.Times(rcp);
		r1.ShouldBeApprox(R300._1_, 5e-6);

		var r2 = rcp.Times(mv);
		r2.ShouldBeApprox(R300._1_, 5e-6);
	}

}

