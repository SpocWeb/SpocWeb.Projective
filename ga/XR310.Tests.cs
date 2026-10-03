using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using NUnit.Framework;
using org.SpocWeb.root.array;

namespace org.SpocWeb.root.maths.pga.ga;

// ReSharper disable once InconsistentNaming
/// <summary>Tests for x R310.</summary>
/// <remarks>
/// ## Public Methods
///
/// | Line | Method | Description |
/// |--:|---|---|
/// | 24 | <see cref="GetFactor"/> | Returns the canonical positive basis element and its sign factor for e, yielding factor 0 for the zero element. |
/// | 30 | <see cref="ProductGeometric"/> | Gets the product Geometric. |
/// | 33 | <see cref="ProductDot"/> | Gets the product Dot. |
/// | 36 | <see cref="ProductOuter"/> | Gets the product Outer. |
/// | 46 | <see cref="Products"/> | Gets the products. |
/// | 49 | <see cref="AllProductTests"/> | Generates all Test Pairs for all Products in Products |
/// | 64 | <see cref="BaseVectorPairs"/> | Generates all Pairs of R310 Base Vectors Elements |
/// | 74 | <see cref="TestAllProducts"/> | Test All Products. |
/// | 82 | <see cref="CreateVectors"/> | Creates a three-element test vector array representing operand a, operand b and their expected product result according to products. |
/// | 105 | <see cref="RandomR310"/> | Generates 99 random R310 multivectors for use as test inputs. |
/// | 116 | <see cref="TestAssociativity"/> | Test Associativity. |
/// | 127 | <see cref="RandomR310Vector"/> | Generates 99 random grade-1 (vector) R310 elements for use as test inputs. |
/// | 138 | <see cref="TestInverseVector"/> | Test Inverse Vector. |
/// | 147 | <see cref="TestRcp"/> | Test Rcp. |
///
/// ## Collaborators
///
/// | Type | Role |
/// |---|---|
/// | <see cref="Base e, int factor)"/> | Returned by a method. |
/// | <see cref="Base"/> | Passed as a parameter. |
/// | <see cref="(float[][] vectors, Func"/> | Passed as a parameter. |
/// | <see cref="Random"/> | Used as a field. |
/// | <see cref="R310"/> | Passed as a parameter. |
/// </remarks>
///
/// <example>
/// <code language="yaml">
/// pass: 2
/// mtime: 2026-05-24T15:36:37Z
/// digest: 4618d39328c48679e763d7c4fef5ef270421633b21fed85e12e53d3af1daf322
/// tags: [code/unit_test, code/conformal_geometric_algebra]
/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
/// facets: {layer: test, status: stable, complexity: 3}
/// </code>
/// </example>
public static partial class XR310
{
	/// <summary> Returns the canonical positive basis element and its sign factor for <paramref name="e"/>,
	/// yielding factor 0 for the zero element. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/extension_method, code/geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: test, status: stable, complexity: 1}
	/// </code>
	/// </example>
	public static (R310.Base e, int factor) GetFactor(this R310.Base e)
		=> e < 0 ? (~e, -1) : e == R310.Base._0 ? (R310.Base._1_, 0) : (e, 1);

	#region Test Pairs for all Products

	/// <summary>Gets the product Geometric.</summary>
	public static readonly Func<IReadOnlyList<float>, IReadOnlyList<float>, float[]> ProductGeometric = Times16R;

	/// <summary>Gets the product Dot.</summary>
	public static readonly Func<IReadOnlyList<float>, IReadOnlyList<float>, float[]> ProductDot = Dot16R;

	/// <summary>Gets the product Outer.</summary>
	public static readonly Func<IReadOnlyList<float>, IReadOnlyList<float>, float[]> ProductOuter = Wedge16R;

	/// <summary> Order must conform to the order in <see cref="R310.Products"/> </summary>
	static readonly Func<IReadOnlyList<float>, IReadOnlyList<float>, float[]>[] _Products = {
		ProductGeometric,
		ProductDot,
		ProductOuter,
	};

	/// <summary>Gets the products.</summary>
	public static readonly Func<IReadOnlyList<float>, IReadOnlyList<float>, float[]>[] Products = _Products;

	/// <summary> Generates all Test Pairs for all Products in <see cref="R310.Products"/> </summary>
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
			foreach (var valueTuple in R310.Products[i].ProductTests(Products[i])) {
				yield return valueTuple;
			}
		}
	}

	/// <summary> Generates all Test Cases for <paramref name="product"/> from <paramref name=""/> Pairs of <see cref="R310"/> Elements </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/extension_method, code/test_vector_generation]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: test, status: stable, complexity: 2}
	/// </code>
	/// </example>
	static IEnumerable<(float[][], Func<IReadOnlyList<float>, IReadOnlyList<float>, float[]> product)
		> ProductTests(this IReadOnlyList<IReadOnlyList<R310.Base>> matrix
		, Func<IReadOnlyList<float>, IReadOnlyList<float>, float[]> product) 
		=> BaseVectorPairs().Select(pair => (matrix.CreateVectors(pair.x, pair.y, 2, 3), product));

	/// <summary> Generates all Pairs of <see cref="R310"/> Base Vectors Elements </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/test_vector_generation, code/geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: test, status: stable, complexity: 2}
	/// </code>
	/// </example>
	public static IEnumerable<(R310.Base x, R310.Base y)> BaseVectorPairs() {
		for (var k = R310.Base._1_; k != R310.Base._0; ++k) {
			for (var i = R310.Base._1_; i != R310.Base._0; ++i) {
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

	/// <summary> Creates a three-element test vector array representing operand <paramref name="a"/>,
	/// operand <paramref name="b"/> and their expected product result according to <paramref name="products"/>. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/extension_method, code/test_vector_generation]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: test, status: stable, complexity: 2}
	/// </code>
	/// </example>
	public static float[][] CreateVectors(this IReadOnlyList<IReadOnlyList<R310.Base>> products, R310.Base a, R310.Base b, double factor1, double factor2) {
		var (e, factor) = products[(int) a][(int) b].GetFactor();
		return CreateVectors(a, b, factor1, factor2, e, factor);
	}

	/// <inheritdoc cref="CreateVectors(IReadOnlyList{IReadOnlyList{R310.Base}}, R310.Base, R310.Base, double, double)"/>
	public static float[][] CreateVectors(R310.Base a, R310.Base b, double factor1, double factor2, R310.Base e, int factor) {
		var vectors = new[] {
			new float[R310.NUM_COORDS],
			new float[R310.NUM_COORDS],
			new float[R310.NUM_COORDS],
		};
		vectors[0][(int) a] = (float) factor1;
		vectors[1][(int) b] = (float) factor2;
		vectors[2][(int) e] = (float) (factor1 * factor2 * factor);
		return vectors;
	}

	#endregion Test Pairs for all Products

	/// <summary>Gets the rANDOM.</summary>
	static readonly Random RANDOM = new();
	/// <summary> Generates 99 random <see cref="R310"/> multivectors for use as test inputs. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/random_data_generation, code/test_vector_generation]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: test, status: stable, complexity: 1}
	/// </code>
	/// </example>
	public static IEnumerable<R310> RandomR310() {
		var arr = new float[R310.NUM_COORDS];
		for (int i = 99; --i >= 0;) {
			for (int j = arr.Length; --j >= 0; ) {
				arr[j] = (float) RANDOM.NextDouble();
			}
			yield return new R310(arr);
		}
	}

	/// <summary>Test Associativity.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/unit_test, code/algebraic_laws]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: test, status: stable, complexity: 2}
	/// </code>
	/// </example>
	[TestCaseSource(nameof(RandomR310))]
	[SuppressMessage("ReSharper", "InconsistentNaming")]
	public static void TestAssociativity(R310 u) {
		var v = RandomR310().First();
		var w = RandomR310().First();
		var uv_w = (u * v) * w;
		var u_vw = u * (v * w);
		uv_w.ShouldBeApprox(u_vw);
	}

	/// <summary> Generates 99 random grade-1 (vector) <see cref="R310"/> elements for use as test inputs. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/random_data_generation, code/test_vector_generation]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: test, status: stable, complexity: 1}
	/// </code>
	/// </example>
	public static IEnumerable<R310> RandomR310Vector() {
		var arr = new float[R310.NUM_COORDS];
		for (int i = 99; --i >= 0;) {
			for (int j = 4; --j > 0; ) {
				arr[j] = (float) RANDOM.NextDouble();
			}
			yield return new R310(arr);
		}
	}

	/// <summary>Test Inverse Vector.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/unit_test, code/inversion, code/property_testing]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: test, status: stable, complexity: 2}
	/// </code>
	/// </example>
	[TestCaseSource(nameof(RandomR310))]
	public static void TestInverseVector(R310 u) {
		var v = RandomR310Vector().First();
		var uv = u * v;
		var uvv = -uv * v / (v.NormSqr());
		uvv.ShouldBeApprox(u);
	}

	/// <summary>Test Rcp.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/unit_test, code/inversion, code/property_testing]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: test, status: stable, complexity: 2}
	/// </code>
	/// </example>
	[TestCaseSource(typeof(R310), nameof(R310.Blades))]
	[TestCaseSource(nameof(RandomR310))]
	public static void TestRcp(R310 mv) {
		var rcp = mv.Rcp();
		var r1 = mv.Times(rcp);
		r1.ShouldBeApprox(R310._1_, 2e-5);

		var r2 = rcp.Times(mv);
		r2.ShouldBeApprox(R310._1_, 2e-5);
	}

}

