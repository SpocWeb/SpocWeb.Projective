using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using org.SpocWeb.root.array;

namespace org.SpocWeb.root.maths.pga;

// ReSharper disable once InconsistentNaming
/// <summary> Test utilities and random generators for the <see cref="R311"/> conformal algebra extension methods. </summary>
/// <remarks>
/// ## Public Methods
///
/// | Line | Method | Description |
/// |--:|---|---|
/// | 22 | <see cref="GetFactor"/> | Returns the canonical positive basis element and sign factor (+1, 0, or -1) corresponding to the given (possibly negated) e. |
/// | 26 | <see cref="ProductGeometric"/> | Delegate wrapping the geometric product operation for use in product test pipelines. |
/// | 28 | <see cref="ProductDot"/> | Delegate wrapping the inner (dot) product operation for use in product test pipelines. |
/// | 30 | <see cref="ProductOuter"/> | Delegate wrapping the outer (wedge) product operation for use in product test pipelines. |
/// | 40 | <see cref="Products"/> | Public read-only view of all three product delegate functions indexed by product type. |
/// | 43 | <see cref="AllProductTests"/> | Generates all Test Pairs for all Products in Products |
/// | 58 | <see cref="BaseVectorPairs"/> | Generates all Pairs of R311 Base Vectors Elements |
/// | 68 | <see cref="TestAllProducts"/> | Test All Products. |
/// | 75 | <see cref="CreateVectors"/> | Builds a triple of float arrays representing two input basis blades and their expected product result from the given Cayley products table. |
/// | 97 | <see cref="RandomR311"/> | Generates 99 random R311 multi-vectors with uniformly distributed components for property-based tests. |
/// | 119 | <see cref="Invertibles"/> | Public read-only view of the invertible R311 basis blades used as test cases. |
/// | 122 | <see cref="TestRcp"/> | Test Rcp. |
///
/// ## Collaborators
///
/// | Type | Role |
/// |---|---|
/// | <see cref="Base e, int factor)"/> | Returned by a method. |
/// | <see cref="Base"/> | Passed as a parameter. |
/// | <see cref="(float[][] vectors, Func"/> | Passed as a parameter. |
/// | <see cref="Random"/> | Used as a field. |
/// | <see cref="R311"/> | Used as a field. |
/// </remarks>
///
/// <example>
/// <code language="yaml">
/// pass: 2
/// mtime: 2026-05-24T15:36:37Z
/// digest: ec6031dd845286abd7ee6bf48333ffcea65737ea620c3bc6896443425d9202c4
/// tags: [code/unit_test, code/test_data_generation, code/conformal_geometric_algebra]
/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
/// facets: {layer: test, status: stable, complexity: 2}
/// </code>
/// </example>
public static partial class XR311
{
	/// <summary> Returns the canonical positive basis element and sign factor (+1, 0, or -1) corresponding to the given (possibly negated) <paramref name="e"/>. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/extension_method, code/geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: test, status: stable, complexity: 1}
	/// </code>
	/// </example>
	public static (R311.Base e, int factor) GetFactor(this R311.Base e)
		=> e < 0 ? (~e, -1) : e == R311.Base._0 ? (R311.Base._1_, 0) : (e, 1);

	/// <summary>Delegate wrapping the geometric product operation for use in product test pipelines.</summary>
	public static readonly Func<IReadOnlyList<float>, IReadOnlyList<float>, float[]> ProductGeometric = Times32;
	/// <summary>Delegate wrapping the inner (dot) product operation for use in product test pipelines.</summary>
	public static readonly Func<IReadOnlyList<float>, IReadOnlyList<float>, float[]> ProductDot = Dot32;
	/// <summary>Delegate wrapping the outer (wedge) product operation for use in product test pipelines.</summary>
	public static readonly Func<IReadOnlyList<float>, IReadOnlyList<float>, float[]> ProductOuter = Wedge32;

	/// <summary> Order must conform to the order in <see cref="R311.Products"/> </summary>
	static readonly Func<IReadOnlyList<float>, IReadOnlyList<float>, float[]>[] _Products = {
		ProductGeometric,
		ProductDot,
		ProductOuter,
	};

	/// <summary>Public read-only view of all three product delegate functions indexed by product type.</summary>
	public static readonly Func<IReadOnlyList<float>, IReadOnlyList<float>, float[]>[] Products = _Products;

	/// <summary> Generates all Test Pairs for all Products in <see cref="R311.Products"/> </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/test_data_generation, code/geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: test, status: stable, complexity: 2}
	/// </code>
	/// </example>
	public static IEnumerable<(float[][], Func<IReadOnlyList<float>, IReadOnlyList<float>, float[]> product)> AllProductTests() {
		for (var i = Products.Length; --i >= 0; ) {
			foreach (var valueTuple in R311.Products[i].ProductTests(Products[i])) {
				yield return valueTuple;
			}
		}
	}

	/// <summary> Generates all Test Cases for <paramref name="product"/> from <paramref name=""/> Pairs of <see cref="R311"/> Elements </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/extension_method, code/test_vector_generation]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: test, status: stable, complexity: 2}
	/// </code>
	/// </example>
	static IEnumerable<(float[][], Func<IReadOnlyList<float>, IReadOnlyList<float>, float[]> product)
		> ProductTests(this IReadOnlyList<IReadOnlyList<R311.Base>> matrix
		, Func<IReadOnlyList<float>, IReadOnlyList<float>, float[]> product) 
		=> BaseVectorPairs().Select(pair => (matrix.CreateVectors(pair.x, pair.y, 2, 3), product));

	/// <summary> Generates all Pairs of <see cref="R311"/> Base Vectors Elements </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/test_vector_generation, code/geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: test, status: stable, complexity: 2}
	/// </code>
	/// </example>
	public static IEnumerable<(R311.Base x, R311.Base y)> BaseVectorPairs() {
		for (var k = R311.Base._1_; k != R311.Base._0; ++k) {
			for (var i = R311.Base._1_; i != R311.Base._0; ++i) {
				yield return (i, k);
			}
			
		}
	}

	/// <summary>Test All Products.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/unit_test, code/geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: test, status: stable, complexity: 1}
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
	/// tags: [code/extension_method, code/test_vector_generation]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: test, status: stable, complexity: 2}
	/// </code>
	/// </example>
	public static float[][] CreateVectors(this IReadOnlyList<IReadOnlyList<R311.Base>> products, R311.Base a, R311.Base b, double factor1, double factor2) {
		var (e, factor) = products[(int) a][(int) b].GetFactor();
		return CreateVectors(a, b, factor1, factor2, e, factor);
	}

	/// <inheritdoc cref="CreateVectors(IReadOnlyList{IReadOnlyList{R311.Base}}, R311.Base, R311.Base, double, double)"/>
	public static float[][] CreateVectors(R311.Base a, R311.Base b, double factor1, double factor2, R311.Base e, int factor) {
		var vectors = new[] {
			new float[R311.NUM_COORDS],
			new float[R311.NUM_COORDS],
			new float[R311.NUM_COORDS],
		};
		vectors[0][(int) a] = (float) factor1;
		vectors[1][(int) b] = (float) factor2;
		vectors[2][(int) e] = (float) (factor1 * factor2 * factor);
		return vectors;
	}

	/// <summary>Shared random number generator for property-based test data.</summary>
	static readonly Random RANDOM = new();

	/// <summary> Generates 99 random <see cref="R311"/> multi-vectors with uniformly distributed components for property-based tests. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/random_data_generation, code/test_vector_generation]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: test, status: stable, complexity: 1}
	/// </code>
	/// </example>
	public static IEnumerable<R311> RandomR311() {
		var arr = new float[R311.NUM_COORDS];
		for (int i = 99; --i >= 0;) {
			for (int j = arr.Length; --j >= 0; ) {
				arr[j] = (float) RANDOM.NextDouble();
			}
			yield return new R311(arr);
		}
	}

	/// <summary>Fixed set of invertible <see cref="R311"/> basis blades used as static test cases.</summary>
	static readonly R311[] _Invertibles = {R311._1_//, R311.e0
		, R311.e1, R311.e2, R311.e3, R311.eN 
		//, R311.e01, R311.e02, R311.e03, R311.e04,
		, R311.e12, R311.e13, R311.e1N, R311.e23, R311.e2N, R311.e3N
		//, R311.e012, R311.e013, R311.e014, R311.e023, R311.e024, R311.e034
		, R311.e123, R311.e23N, R311.e13N, R311.e12N
		, R311.e123N//, R311.e0123, R311.e0124, R311.e0134, R311.e0234
		//, R311.e01234
	};

	/// <summary>Public read-only view of the invertible <see cref="R311"/> basis blades used as test cases.</summary>
	public static readonly IReadOnlyList<R311> Invertibles = _Invertibles;

	/// <summary>Test Rcp.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/unit_test, code/reciprocal, code/algebraic_laws]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: test, status: stable, complexity: 2}
	/// </code>
	/// </example>
	[TestCaseSource(nameof(Invertibles))]
	[TestCaseSource(nameof(RandomR311))]
	public static void TestRcp(R311 mv) {
		var rcp = mv.Rcp();
		var r1 = mv.Times(rcp);
		r1.ShouldBeApprox(R311._1_, 9e-3); //

		var r2 = mv.Times(rcp);
		r2.ShouldBeApprox(R311._1_, 9e-3);
	}

}

