using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using org.SpocWeb.root.array;
using org.SpocWeb.root.logging;

namespace org.SpocWeb.root.maths.pga.ga;

// ReSharper disable once InconsistentNaming
/// <summary> Static test and utility methods for the R410 G(4,1,0) 3D Conformal Geometric Algebra multivector type. </summary>
/// <remarks>
/// ## Public Methods
///
/// | Line | Method | Description |
/// |--:|---|---|
/// | 24 | <see cref="GetFactor"/> | Returns the canonical positive basis element and its sign factor for e, yielding factor 0 for the zero element. |
/// | 28 | <see cref="Grade"/> | Returns the grade (number of basis vector factors) of the given Base blade value. |
/// | 67 | <see cref="ProductGeometric"/> | Gets the product Geometric. |
/// | 69 | <see cref="ProductDot"/> | Gets the product Dot. |
/// | 71 | <see cref="ProductOuter"/> | Gets the product Outer. |
/// | 81 | <see cref="Products"/> | Gets the products. |
/// | 84 | <see cref="AllProductTests"/> | Generates all Test Pairs for all Products in Products |
/// | 100 | <see cref="BaseVectorPairs"/> | Generates all Pairs of R410 Base Vectors Elements |
/// | 109 | <see cref="TestAllProducts"/> | Test All Products. |
/// | 117 | <see cref="CreateVectorPairs"/> | Creates a three-element test vector array representing operand a, operand b and their expected product result according to products. |
/// | 137 | <see cref="TestJoinMeet"/> | Test Join Meet. |
/// | 159 | <see cref="RandomR410"/> | Generates 99 random R410 multivectors for use as test inputs. |
/// | 170 | <see cref="TestRcp"/> | Test Rcp. |
///
/// ## Collaborators
///
/// | Type | Role |
/// |---|---|
/// | <see cref="Base e, int factor)"/> | Returned by a method. |
/// | <see cref="Base"/> | Passed as a parameter. |
/// | <see cref="(float[][] vectors, Func"/> | Passed as a parameter. |
/// | <see cref="Base y)"/> | Passed as a parameter. |
/// | <see cref="Random"/> | Used as a field. |
/// | <see cref="R410"/> | Passed as a parameter. |
/// </remarks>
///
/// <example>
/// <code language="yaml">
/// pass: 2
/// mtime: 2026-05-24T15:36:37Z
/// digest: db5bb830688329d6bea95803aa343182cc453d90d73245859b22d3567963d58a
/// tags: [code/unit_test, code/conformal_geometric_algebra]
/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
/// facets: {layer: test, status: partial, complexity: 3}
/// </code>
/// </example>
public static class XR410
{
	/// <summary> Returns the canonical positive basis element and its sign factor for <paramref name="e"/>,
	/// yielding factor 0 for the zero element. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/extension_method, code/canonicalization, code/geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: test, status: stable, complexity: 2}
	/// </code>
	/// </example>
	public static (R410.Base e, int factor) GetFactor(this R410.Base e)
		=> e < 0 ? (~e, -1) : e == R410.Base._0 ? (R410.Base._1_, 0) : (e, 1);

	/// <summary> Returns the grade (number of basis vector factors) of the given <see cref="R410.Base"/> blade <paramref name="value"/>. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/extension_method, code/grade_computation]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: test, status: stable, complexity: 2}
	/// </code>
	/// </example>
	public static byte Grade(this R410.Base value)
		=> value switch {
			R410.Base._1_ => 0,
			R410.Base.e1 => 1,
			R410.Base.e2 => 1,
			R410.Base.e3 => 1,
			R410.Base.e4 => 1,
			R410.Base.e5 => 1,
			R410.Base.e12 => 2,
			R410.Base.e13 => 2,
			R410.Base.e14 => 2,
			R410.Base.e15 => 2,
			R410.Base.e23 => 2,
			R410.Base.e24 => 2,
			R410.Base.e25 => 2,
			R410.Base.e34 => 2,
			R410.Base.e35 => 2,
			R410.Base.e45 => 2,
			R410.Base.e123 => 3,
			R410.Base.e124 => 3,
			R410.Base.e125 => 3,
			R410.Base.e134 => 3,
			R410.Base.e135 => 3,
			R410.Base.e145 => 3,
			R410.Base.e234 => 3,
			R410.Base.e235 => 3,
			R410.Base.e245 => 3,
			R410.Base.e345 => 3,
			R410.Base.e1234 => 4,
			R410.Base.e1235 => 4,
			R410.Base.e1245 => 4,
			R410.Base.e1345 => 4,
			R410.Base.e2345 => 4,
			R410.Base.e12345 => 5,
			_ => throw new ArgumentOutOfRangeException(nameof(value), value, null)
		};

	/// <summary>Gets the product Geometric.<br/>
	/// Gets the product Dot.</summary>
	public static readonly Func<IReadOnlyList<float>, IReadOnlyList<float>, float[]> ProductGeometric = XR311.Times32C;
	/// <summary>Gets the product Dot.</summary>
	public static readonly Func<IReadOnlyList<float>, IReadOnlyList<float>, float[]> ProductDot = XR311.Dot32C;
	/// <summary>Gets the product Outer.</summary>
	public static readonly Func<IReadOnlyList<float>, IReadOnlyList<float>, float[]> ProductOuter = XR311.Wedge32;

	/// <summary> Order must conform to the order in <see cref="R410.Products"/> </summary>
	static readonly Func<IReadOnlyList<float>, IReadOnlyList<float>, float[]>[] _Products = {
		ProductGeometric,
		ProductDot,
		ProductOuter,
	};

	/// <summary>Gets the products.</summary>
	public static readonly Func<IReadOnlyList<float>, IReadOnlyList<float>, float[]>[] Products = _Products;

	/// <summary> Generates all Test Pairs for all Products in <see cref="R410.Products"/> </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/test_data_generation, code/test_vector_generation]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: test, status: stable, complexity: 2}
	/// </code>
	/// </example>
	public static IEnumerable<(float[][], Func<IReadOnlyList<float>, IReadOnlyList<float>, float[]> product
		)> AllProductTests() {
		for (var i = Products.Length; --i >= 0; ) {
			foreach (var valueTuple in R410.Products[i].ProductTests(Products[i])) {
				yield return valueTuple;
			}
		}
	}

	/// <summary> Generates all Test Cases for <paramref name="product"/> from <paramref name=""/> Pairs of <see cref="R410"/> Elements </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/extension_method, code/test_data_generation, code/test_vector_generation]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: test, status: stable, complexity: 2}
	/// </code>
	/// </example>
	static IEnumerable<(float[][], Func<IReadOnlyList<float>, IReadOnlyList<float>, float[]> product
		)> ProductTests(this IReadOnlyList<IReadOnlyList<R410.Base>> matrix
		, Func<IReadOnlyList<float>, IReadOnlyList<float>, float[]> product) 
		=> BaseVectorPairs().Select(pair => (matrix.CreateVectorPairs(pair.r, pair.c, 2, 3), product));

	/// <summary> Generates all Pairs of <see cref="R410"/> Base Vectors Elements </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/combinatorial_generation, code/test_data_generation]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: test, status: stable, complexity: 2}
	/// </code>
	/// </example>
	public static IEnumerable<(R410.Base r, R410.Base c)> BaseVectorPairs() {
		for (var r = R410.Base._1_; r != R410.Base._0; ++r) {
			for (var c = R410.Base._1_; c != R410.Base._0; ++c) {
				yield return (r, c);
			}
		}
	}

	/// <summary>Test All Products.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/unit_test, code/property_testing]
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
	public static float[][] CreateVectorPairs(this IReadOnlyList<IReadOnlyList<R410.Base>> products
		, R410.Base a, R410.Base b, double factor1, double factor2) {
		var (e, factor) = products[(int) a][(int) b].GetFactor();
		return CreateVectorPairs(a, b, factor1, factor2, e, factor);
	}

	/// <inheritdoc cref="CreateVectorPairs(IReadOnlyList{IReadOnlyList{R410.Base}}, R410.Base, R410.Base, double, double)"/>
	public static float[][] CreateVectorPairs(R410.Base a, R410.Base b, double factor1, double factor2, R410.Base e, int factor) {
		var vectors = new[] {
			new float[R410.NUM_COORDS],
			new float[R410.NUM_COORDS],
			new float[R410.NUM_COORDS],
		};
		vectors[0][(int) a] = (float) factor1;
		vectors[1][(int) b] = (float) factor2;
		vectors[2][(int) e] = (float) (factor1 * factor2 * factor);
		return vectors;
	}

	/// <summary>Test Join Meet.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/unit_test, code/join_operation, code/algebraic_laws]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: test, status: partial, complexity: 3}
	/// </code>
	/// </example>
	[TestCaseSource(nameof(BaseVectorPairs))]
	public static void TestJoinMeet((R410.Base x, R410.Base y) pair) {
		float[][] arg1Arg2Product = R410.ProductOuter.CreateVectorPairs(pair.x, pair.y, 2, 3);
		var arg1 = arg1Arg2Product[0].Dual32C();
		var arg2 = arg1Arg2Product[1].Dual32C();
		var exp = arg1Arg2Product[2].Dual32C();
		var join = arg1.Join32C(arg2);
		for (int i = join.Length; --i >= 0; ) {
			float expected = exp[i];
			//if (IsOdd(pair.x + (sbyte) pair.y)) {
			if ((pair.x.Grade() * pair.y.Grade()).IsOdd()) {
				expected = -expected;
			}
			_ = Math.Abs(join[i]).ShouldBe(Math.Abs(expected));
			//TODO: join[i].ShouldBe(expected);
		}
	}

	/// <summary>Gets the rANDOM.</summary>
	static readonly Random RANDOM = new();

	/// <summary> Generates 99 random <see cref="R410"/> multivectors for use as test inputs. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/random_data_generation]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: test, status: stable, complexity: 1}
	/// </code>
	/// </example>
	public static IEnumerable<R410> RandomR410() {
		var arr = new float[R410.NUM_COORDS];
		for (int i = 99; --i >= 0;) {
			for (int j = arr.Length; --j >= 0; ) {
				arr[j] = (float) RANDOM.NextDouble();
			}
			yield return new R410(arr);
		}
	}

	/// <summary>Test Rcp.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/unit_test, code/reciprocal, code/algebraic_laws]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: test, status: stable, complexity: 2}
	/// </code>
	/// </example>
	[TestCaseSource(typeof(R410), nameof(R410.Blades))]
	[TestCaseSource(nameof(RandomR410))]
	public static void TestRcp(R410 mv) {
		var rcp = mv.Rcp();
		var r1 = mv.Times(rcp);
		r1.ShouldBeApprox(R410._1_, 5e-5);

		var r2 = mv.Times(rcp);
		r2.ShouldBeApprox(R410._1_, 5e-5);
	}	}

