using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using org.SpocWeb.root.array;
using org.SpocWeb.root.extensions.maths;
using org.SpocWeb.root.logging;
using org.SpocWeb.root.Attributes;

namespace org.SpocWeb.root.maths.pga.ga;

/// <summary> R^3 Vector-Space with Rotations and Reflections </summary>
/// <remarks>
///
/// </remarks>
// ReSharper disable once InconsistentNaming
[DocState(Pass = 2, MTime = "2026-07-07T17:45:38Z", Digest = "11b9aa382e1ec0c92c74fdd7c62af7ecb2d7cb95533037d9fbe98199b60fb3b1", Stale = false, Path = "ga/XR200.cs", Since = "2026-10-06")]
[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
[Tags("code/extension_method", "code/clifford_algebra")]
[System.ComponentModel.Description("R^3 Vector-Space with Rotations and Reflections")]
[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
public static class XR200
{
	/// <summary> Returns the canonical positive basis element and its sign factor for <paramref name="e"/>,
	/// yielding factor 0 for the zero element. </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/extension_method", "code/canonicalization")]
	[System.ComponentModel.Description("Returns the canonical positive basis element and its sign factor for e, yielding factor 0 for the zero element.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public static (R200.Base e, int factor) GetFactor(this R200.Base e)
		=> e < 0 ? (~e, -1) : e == R200.Base._0 ? (R200.Base._1_, 0) : (e, 1);

	#region unary Operations

	/// <summary> ! Poincare dual; both for <see cref="R200"/> and <see cref="Pga2D"/>. </summary>
	/// <remarks> AKA Transpose; Reverse the order of the basis blades. </remarks>
	[Facets(Layer = "domain", Status = "stable", Complexity = 1)]
	[Tags("code/extension_method", "code/clifford_algebra")]
	[System.ComponentModel.Description("! Poincare dual; both for R200 and Pga2D.")]
	[TestCase(new []{1,2,3,4f}, ExpectedResult = new []{-4, -3, 2, 1f})]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public static float[] Dual4(this IReadOnlyList<float> a) => new[] {-a[3], -a[2], a[1], a[0]};

	/// <summary> Dual for <see cref="R110"/> AND <see cref="R011"/> </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 1)]
	[Tags("code/extension_method", "code/clifford_algebra")]
	[System.ComponentModel.Description("Dual for R110 AND R011")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public static float[] DualR011(this IReadOnlyList<float> a) => new[] {a[3], a[2], a[1], a[0]};

	/// <summary> Involution; identical for Algebras of all Metrics </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 1)]
	[Tags("code/extension_method", "code/clifford_algebra")]
	[System.ComponentModel.Description("Involution; identical for Algebras of all Metrics")]
	[TestCase(new []{1,2,3,4f}, ExpectedResult = new []{1, -2, -3, 4f})]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public static float[] Involute4 (this IReadOnlyList<float> a) => new[] {a[0], -a[1], -a[2], a[3]};

	/// <summary> Negates all four components of a 4-element multivector coordinate array. </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 1)]
	[Tags("code/extension_method", "code/negation")]
	[System.ComponentModel.Description("Negates all four components of a 4-element multivector coordinate array.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public static float[] Neg4(this IReadOnlyList<float> c) => new[] {-c[0], -c[1], -c[2], -c[3]};

	/// <summary> Clifford Conjugate; identical for Algebras of all Metrics </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 1)]
	[Tags("code/extension_method", "code/conjugate")]
	[System.ComponentModel.Description("Clifford Conjugate; identical for Algebras of all Metrics")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public static float[] CliffCjg4(this IReadOnlyList<float> a) => new[] {a[0], -a[1], -a[2], -a[3]};

	/// <summary> ~a; Complex Conjugate; identical for Algebras of all Metrics. </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 1)]
	[Tags("code/extension_method", "code/clifford_algebra")]
	[System.ComponentModel.Description("~a; Complex Conjugate; identical for Algebras of all Metrics.")]
	[TestCase(new []{1,2,3,4f}, ExpectedResult = new []{1, 2, 3, -4f})]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public static float[] Reverted4(this float[] a) => new[] {a[0], a[1], a[2], -a[3]};

	/// <summary> !a; Unscaled Reciprocal; identical for Algebras of all Metrics. </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 1)]
	[Tags("code/extension_method", "code/reciprocal")]
	[System.ComponentModel.Description("!a; Unscaled Reciprocal; identical for Algebras of all Metrics.")]
	[TestCase(new []{1,2,3,4f}, ExpectedResult = new []{1, 2, 3, -4f})]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public static float[] Rcp(this float[] a) => new[] {a[0], a[1], a[2], -a[3]};

	/// <summary>Norm Sqr4 R200 Q.</summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 1)]
	[Tags("code/norm_calculation")]
	[System.ComponentModel.Description("Norm Sqr4 R200 Q.")]
	[TestCase(new []{-1,-2,-3,-4f}, ExpectedResult = 4)]
	[TestCase(new []{-1,-4,-3,-2f}, ExpectedResult = -20)]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public static float NormSqr4R200Q(IReadOnlyList<float> c) => c.Times4(c.CliffCjg4())[0];
	/// <summary>Norm Sqr4 R200.</summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 1)]
	[Tags("code/extension_method", "code/norm_calculation")]
	[System.ComponentModel.Description("Norm Sqr4 R200.")]
	[TestCase(new []{-1,-2,-3,-4f}, ExpectedResult = 4)]
	[TestCase(new []{-1,-4,-3,-2f}, ExpectedResult = -20)]
	[TestCase(new []{1,4,3,2f}, ExpectedResult = -20)]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public static float NormSqr4R200(this IReadOnlyList<float> a) => a[0].Sqr() - a[1].Sqr() - a[2].Sqr() + a[3].Sqr();

	/// <summary>Norm Sqr4 R011 Q.</summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 1)]
	[Tags("code/norm_calculation")]
	[System.ComponentModel.Description("Norm Sqr4 R011 Q.")]
	[TestCase(new []{-1,-2,-3,-4f}, ExpectedResult = 10)]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public static float NormSqr4R011Q(IReadOnlyList<float> c) => c.Times4R011(c.CliffCjg4())[0];
	/// <summary>Norm Sqr4 R011.</summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 1)]
	[Tags("code/extension_method", "code/norm_calculation")]
	[System.ComponentModel.Description("Norm Sqr4 R011.")]
	[TestCase(new []{-1,-2,-3,-4f}, ExpectedResult = 10)]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public static float NormSqr4R011(this IReadOnlyList<float> a) => a[0].Sqr() + a[2].Sqr();

	#endregion unary Operations

	#region binary Operations

	/// <summary> Adds scalar <paramref name="b"/> to the grade-0 component of the 4-element array <paramref name="a"/>. </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 1)]
	[Tags("code/extension_method", "code/scalar_addition")]
	[System.ComponentModel.Description("Adds scalar b to the grade-0 component of the 4-element array a.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public static float[] Plus4(this IReadOnlyList<float> a, double b) => new []{(float)(a[0] + b), a[1], a[2], a[3]};
	/// <summary> Subtracts scalar <paramref name="b"/> from the grade-0 component of the 4-element array <paramref name="a"/>. </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 1)]
	[Tags("code/extension_method", "code/subtraction")]
	[System.ComponentModel.Description("Subtracts scalar b from the grade-0 component of the 4-element array a.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public static float[] Minus4(this IReadOnlyList<float> a, double b) => new []{(float)(a[0] - b), a[1], a[2], a[3]};
	/// <summary> Subtracts the grade-0 component of <paramref name="b"/> from scalar <paramref name="a"/>,
	/// negating all remaining components. </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 1)]
	[Tags("code/extension_method", "code/subtraction", "code/negation")]
	[System.ComponentModel.Description("Subtracts the grade-0 component of b from scalar a, negating all remaining components.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public static float[] Minus4R(this IReadOnlyList<float> b, double a) => new []{(float)(a - b[0]), -b[1], -b[2], -b[3]};

	/// <summary> Full geometric product: ^ + * </summary>
	/// <remarks> <see cref="Dot4R200"/> + e12*(b[2] * a[1] - b[1] * a[2])</remarks>
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/extension_method", "code/geometric_product")]
	[System.ComponentModel.Description("Full geometric product: ^ + *")]
	[TestCase(new []{1,2,3,4f}, new []{ 1, 2, 3, 4f}, ExpectedResult = new []{ -2, 4, 6, 8f})]
	[TestCase(new []{1,2,3,4f}, new []{-1,-2,-3,-4f}, ExpectedResult = new []{  2, -4, -6, -8f})]
	[TestCase(new []{-1,-2,-3,-4f}, new []{1,2,3,4f}, ExpectedResult = new []{  2, -4, -6, -8f})]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public static float[] Times4(this IReadOnlyList<float> a, IReadOnlyList<float> b) => new[] {
		b[0] * a[0] + b[1] * a[1] + b[2] * a[2] - b[3] * a[3],
		b[1] * a[0] + b[0] * a[1] - b[3] * a[2] + b[2] * a[3],
		b[2] * a[0] + b[3] * a[1] + b[0] * a[2] - b[1] * a[3],
		b[3] * a[0] + b[2] * a[1] - b[1] * a[2] + b[0] * a[3]
	};

	/// <summary>Truncate Right.</summary>
	///
	[Facets(Layer = "utility", Status = "stable", Complexity = 1)]
	[Tags("code/string_truncation")]
	[System.ComponentModel.Description("Truncate Right.")]
	[TestCase("brief", ExpectedResult = "brief")]
	[TestCase("long567890", ExpectedResult = "long56789")]
	[Concept("string_manipulation")]
	public static string TruncateRight(string arg) {
		return arg.Substring(0, Math.Min(arg.Length, 9));
	}

	/// <summary>Norm Sqr4 R110 Q.</summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 1)]
	[Tags("code/extension_method", "code/norm_calculation")]
	[System.ComponentModel.Description("Norm Sqr4 R110 Q.")]
	[TestCase(new []{1,2,3,4f}, ExpectedResult = -10)]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public static float NormSqr4R110Q(this IReadOnlyList<float> c) => c.Times4R110(c.CliffCjg4())[0];

	/// <summary>Norm Sqr4 R110.</summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 1)]
	[Tags("code/extension_method", "code/norm_calculation")]
	[System.ComponentModel.Description("Norm Sqr4 R110.")]
	[TestCase(new []{1,2,3,4f}, ExpectedResult = -10)]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public static float NormSqr4R110(this IReadOnlyList<float> a) => a[0].Sqr() - a[1].Sqr() + a[2].Sqr() - a[3].Sqr();

	/// <summary> * Mul/Times; geometric product for <see cref="R110"/>. </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/extension_method", "code/geometric_product")]
	[System.ComponentModel.Description("* Mul/Times; geometric product for R110.")]
	[TestCase(new[] {1, 2, 3, 4f}, new[] {-1, -2, -3, -4f}, ExpectedResult = new[] {-12, -4, -6, -8f})]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public static float[] Times4R110(this IReadOnlyList<float> a, IReadOnlyList<float> b) => new[] {
		b[0] * a[0] + b[1] * a[1] - b[2] * a[2] + b[3] * a[3],
		b[1] * a[0] + b[0] * a[1] + b[3] * a[2] - b[2] * a[3],
		b[2] * a[0] + b[3] * a[1] + b[0] * a[2] - b[1] * a[3],
		b[3] * a[0] + b[2] * a[1] - b[1] * a[2] + b[0] * a[3]
	};

	/// <summary> * Mul/Times; geometric product for <see cref="R011"/>. </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/extension_method", "code/geometric_product")]
	[System.ComponentModel.Description("* Mul/Times; geometric product for R011.")]
	[TestCase(new[] {1, 2, 3, 4f}, new[] {-1, -2, -3, -4f}, ExpectedResult = new[] {8, -4, -6, -8f})]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public static float[] Times4R011(this IReadOnlyList<float> a, IReadOnlyList<float> b) => new[] {
		b[0] * a[0] - b[2] * a[2],
		b[1] * a[0] + b[0] * a[1] + b[3] * a[2] - b[2] * a[3],
		b[2] * a[0] + b[0] * a[2],
		b[3] * a[0] + b[2] * a[1] - b[1] * a[2] + b[0] * a[3]
	};

	/// <summary> ^ MEET/Wedge; outer (Grassmann) product for ALL Algebras </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/extension_method", "code/outer_product")]
	[System.ComponentModel.Description("^ MEET/Wedge; outer (Grassmann) product for ALL Algebras")]
	[TestCase(new[] {1, 2, 3, 4f}, new[] {-1, -2, -3, -4f}, ExpectedResult = new[] {-1, -4, -6, -8f})]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public static float[] Meet4(this IReadOnlyList<float> a, IReadOnlyList<float> b) => new[] {
		b[0] * a[0],
		b[1] * a[0] + b[0] * a[1],
		b[2] * a[0] + b[0] * a[2],
		b[3] * a[0] + b[2] * a[1] - b[1] * a[2] + b[0] * a[3]
	};

	/// <summary> &amp;,v; Vee/Join/regressive symmetric product for ALL Algebras </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/extension_method", "code/clifford_algebra")]
	[System.ComponentModel.Description("&amp;,v; Vee/Join/regressive symmetric product for ALL Algebras")]
	[TestCase(new []{1,2,3,4f}, new []{1,2,3,4f}, ExpectedResult = new []{8, 16, 24, 16f})]
	[TestCase(new []{1,2,3,4f}, new []{-1,-2,-3,-4f}, ExpectedResult = new []{ -8, -16, -24, -16f})]
	[TestCase(new []{-1,-2,-3,-4f}, new []{1,2,3,4f}, ExpectedResult = new []{ -8, -16, -24, -16f})]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public static float[] Join4(this IReadOnlyList<float> a, IReadOnlyList<float> b) => new[] {
		a[0] * b[3] - a[1] * b[2] + a[2] * b[1] + a[3] * b[0],
		a[1]*b[3]+a[3]*b[1],
		a[2] * b[3] + a[3] * b[2],
		a[3] * b[3],
	};

	/// <summary> | inner/Dot product for <see cref="R110"/>. </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/extension_method", "code/dot_product")]
	[System.ComponentModel.Description("| inner/Dot product for R110.")]
	[TestCase(new []{-1,-2,-3,-4f}, new []{1,2,3,4f}, ExpectedResult = new []{-12, -4, -6, -8f})]
	[TestCase(new []{1,2,3,4f}, new []{-1,-2,-3,-4f}, ExpectedResult = new []{-12, -4, -6, -8f})]
	[TestCase(new []{1,2,3,4f}, new []{ 1, 2, 3, 4f}, ExpectedResult = new []{ 12, 4, 6, 8f})]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public static float[] Dot4R110(this IReadOnlyList<float> a, IReadOnlyList<float> b) => new[] {
		b[0]*a[0]+b[1]*a[1]-b[2]*a[2]+b[3]*a[3],
		b[1]*a[0]+b[0]*a[1]+b[3]*a[2]-b[2]*a[3],
		b[2]*a[0]+b[3]*a[1]+b[0]*a[2]-b[1]*a[3],
		b[3]*a[0]+b[0]*a[3]
	};

	/// <summary> | Dot/ inner product for <see cref="R001"/>. </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/extension_method", "code/dot_product")]
	[System.ComponentModel.Description("| Dot/ inner product for R001.")]
	[TestCase(new []{-1,-2,-3,-4f}, new []{1,2,3,4f}, ExpectedResult = new []{ 8, -4, -6, -8f})]
	[TestCase(new []{1,2,3,4f}, new []{-1,-2,-3,-4f}, ExpectedResult = new []{ 8, -4, -6, -8f})]
	[TestCase(new []{1,2,3,4f}, new []{ 1, 2, 3, 4f}, ExpectedResult = new []{-8, 4, 6, 8f})]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public static float[] Dot4R011(this IReadOnlyList<float> a, IReadOnlyList<float> b) => new[] {
		b[0] * a[0] - b[2] * a[2],
		b[1] * a[0] + b[0] * a[1] + b[3] * a[2] - b[2] * a[3],
		b[2] * a[0] + b[0] * a[2],
		b[3] * a[0] + b[0] * a[3]
	};

	/// <summary> | inner/Dot product for <see cref="R200"/>. </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/extension_method", "code/dot_product")]
	[System.ComponentModel.Description("| inner/Dot product for R200.")]
	[TestCase(new []{1,2,3,4f}, new []{ 1, 2, 3, 4f}, ExpectedResult = new []{ -2, 4, 6, 8f})]
	[TestCase(new []{1,2,3,4f}, new []{-1,-2,-3,-4f}, ExpectedResult = new []{  2, -4, -6, -8f})]
	[TestCase(new []{-1,-2,-3,-4f}, new []{1,2,3,4f}, ExpectedResult = new []{  2, -4, -6, -8f})]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public static float[] Dot4R200(this IReadOnlyList<float> a, IReadOnlyList<float> b) => new[] {
		b[0] * a[0] + b[1] * a[1] + b[2] * a[2] - b[3] * a[3],
		b[1] * a[0] + b[0] * a[1] - b[3] * a[2] + b[2] * a[3],
		b[2] * a[0] + b[3] * a[1] + b[0] * a[2] - b[1] * a[3],
		b[3] * a[0] + b[0] * a[3]
	};

	#endregion binary Operations

	#region Test Pairs for all Products

	/// <summary>Gets the product Geometric.</summary>
	public static readonly Func<IReadOnlyList<float>, IReadOnlyList<float>, float[]> ProductGeometric = Times4;
	/// <summary>Gets the product Dot.</summary>
	public static readonly Func<IReadOnlyList<float>, IReadOnlyList<float>, float[]> ProductDot = Dot4R200;
	/// <summary>Gets the product Outer.</summary>
	public static readonly Func<IReadOnlyList<float>, IReadOnlyList<float>, float[]> ProductOuter = Meet4;

	/// <summary> Order must conform to the order in <see cref="R200.Products"/> </summary>
	static readonly Func<IReadOnlyList<float>, IReadOnlyList<float>, float[]>[] _Products = {
		ProductGeometric,
		ProductDot,
		ProductOuter,
	};

	/// <summary>Gets the products.</summary>
	public static readonly Func<IReadOnlyList<float>, IReadOnlyList<float>, float[]>[] Products = _Products;

	/// <summary> Generates all Test Pairs for all Products in <see cref="R200.Products"/> </summary>
	///
	[Facets(Layer = "generator", Status = "stable", Complexity = 2)]
	[Tags("code/test_data_generation")]
	[System.ComponentModel.Description("Generates all Test Pairs for all Products in Products")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public static IEnumerable<(float[][], Func<IReadOnlyList<float>, IReadOnlyList<float>, float[]> product)> AllProductTests() {
		for (var i = Products.Length; --i >= 0; ) {
			foreach (var valueTuple in R200.Products[i].ProductTests(Products[i])) {
				yield return valueTuple;
			}
		}
	}

	/// <summary> Generates all Test Cases for <paramref name="product"/> from Pairs of <see cref="R200"/> Elements </summary>
	///
	[Facets(Layer = "generator", Status = "stable", Complexity = 1)]
	[Tags("code/extension_method", "code/test_data_generation")]
	[System.ComponentModel.Description("Generates all Test Cases for product from Pairs of R200 Elements")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	static IEnumerable<(float[][], Func<IReadOnlyList<float>, IReadOnlyList<float>, float[]> product)
		> ProductTests(this IReadOnlyList<IReadOnlyList<R200.Base>> matrix
		, Func<IReadOnlyList<float>, IReadOnlyList<float>, float[]> product) 
		=> BaseVectorPairs().Select(pair => (matrix.CreateVectors(pair.x, pair.y, 2, 3), product));

	/// <summary> Generates all Pairs of <see cref="R200"/> Base Vectors Elements </summary>
	///
	[Facets(Layer = "generator", Status = "stable", Complexity = 2)]
	[Tags("code/test_data_generation", "code/combinatorial_generation")]
	[System.ComponentModel.Description("Generates all Pairs of R200 Base Vectors Elements")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public static IEnumerable<(R200.Base x, R200.Base y)> BaseVectorPairs() {
		for (var k = R200.Base._1_; k != R200.Base._0; ++k) {
			for (var i = R200.Base._1_; i != R200.Base._0; ++i) {
				yield return (i, k);
			}
			
		}
	}

	/// <summary>Test All Products.</summary>
	///
	[Facets(Layer = "test", Status = "stable", Complexity = 2)]
	[Tags("code/unit_test")]
	[System.ComponentModel.Description("Test All Products.")]
	[TestCaseSource(nameof(AllProductTests))]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public static void TestAllProducts((float[][] vectors, Func<IReadOnlyList<float>, IReadOnlyList<float>, float[]> product) test) {
		var z = test.product(test.vectors[0], test.vectors[1]);
		CollectionAssert.AreEqual(test.vectors[2], z);
	}

	/// <summary> Creates a three-element test vector array representing operand <paramref name="a"/>,
	/// operand <paramref name="b"/> and their expected product result according to <paramref name="products"/>. </summary>
	///
	[Facets(Layer = "generator", Status = "stable", Complexity = 1)]
	[Tags("code/extension_method", "code/test_data_generation")]
	[System.ComponentModel.Description("Creates a three-element test vector array representing operand a, operand b and their expected product result according to products.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public static float[][] CreateVectors(this IReadOnlyList<IReadOnlyList<R200.Base>> products, R200.Base a, R200.Base b, double factor1, double factor2) {
		var (e, factor) = products[(int) a][(int) b].GetFactor();
		return CreateVectors(a, b, factor1, factor2, e, factor);
	}

	/// <inheritdoc cref="CreateVectors(IReadOnlyList{IReadOnlyList{R200.Base}}, R200.Base, R200.Base, double, double)"/>
	public static float[][] CreateVectors(R200.Base a, R200.Base b, double factor1, double factor2, R200.Base e, int factor) {
		var vectors = new[] {
			new float[R200.NUM_COORDS],
			new float[R200.NUM_COORDS],
			new float[R200.NUM_COORDS],
		};
		vectors[0][(int) a] = (float) factor1;
		vectors[1][(int) b] = (float) factor2;
		vectors[2][(int) e] = (float) (factor1 * factor2 * factor);
		return vectors;
	}

	#endregion Test Pairs for all Products

	/// <inheritdoc cref="Plus4(IReadOnlyList{float}, double)"/>
	[TestCase(new []{1,2,3,4f}, new []{1,2,3,4f}, ExpectedResult = new []{2,4,6,8f})]
	[TestCase(new []{1,2,3,4f}, new []{-1,-2,-3,-4f}, ExpectedResult = new []{0,0,0,0f})]
	[TestCase(new []{-1,-2,-3,-4f}, new []{1,2,3,4f}, ExpectedResult = new []{0,0,0,0f})]
	public static float[] Plus4(this IReadOnlyList<float> a, IReadOnlyList<float> b) => new []{
		a[0] + b[0],
		a[1] + b[1],
		a[2] + b[2],
		a[3] + b[3]};

	/// <summary> - Minus, SUB; Vector[8] Subtraction </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 1)]
	[Tags("code/extension_method", "code/vector_subtraction")]
	[System.ComponentModel.Description("- Minus, SUB; Vector[8] Subtraction")]
	[TestCase(new []{1,2,3,4f}, new []{1,2,3,4f}, ExpectedResult = new []{0,0,0,0f})]
	[TestCase(new []{1,2,3,4,1,2,3,4f}, new []{-1,-2,-3,-4f}, ExpectedResult = new []{2,4,6,8f})]
	[TestCase(new []{-1,-2,-3,-4f}, new []{1,2,3,4f}, ExpectedResult = new []{-2,-4,-6,-8f})]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public static float[] Minus4(this IReadOnlyList<float> a, IReadOnlyList<float> b) => new []{
			a[0] - b[0],
			a[1] - b[1],
			a[2] - b[2],
			a[3] - b[3]};

	/// <summary> * sMul / Times : scalar/multi-vector multiplication </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 1)]
	[Tags("code/extension_method", "code/scalar_multiplication")]
	[System.ComponentModel.Description("* sMul / Times: scalar/multi-vector multiplication")]
	[TestCase(new []{1,2,3,4f}, 3, ExpectedResult = new []{3,6,9,12f})]
	[TestCase(new []{-1,-2,-3,-4f}, 3, ExpectedResult = new []{-3,-6,-9,-12f})]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public static float[] Times4(this IReadOnlyList<float> a, float b) => new []{
		a[0] * b,
		a[1] * b,
		a[2] * b,
		a[3] * b};

	/// <summary>Test Pga2 D.</summary>
	///
	[Facets(Layer = "test", Status = "stable", Complexity = 1)]
	[Tags("code/unit_test", "code/string_formatting")]
	[System.ComponentModel.Description("Test Pga2 D.")]
	[TestCase(new []{1,3,4,7f}, ExpectedResult = "1 + 3x + 4y + 7I")]
	[TestCase(new []{1,-3,-4,-7f}, ExpectedResult = "1 - 3x - 4y - 7I")]
	[TestCase(new []{1,1,1,1f}, ExpectedResult = "1 + x + y + I")]
	[TestCase(new []{0,0,0,0f}, ExpectedResult = "0")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public static string TestPga2D(float[] coords) => R200.New(coords).ToString();

	/// <summary>Gets the vector.<br/>
	/// Gets the normal.</summary>
	static readonly R200 Vector = R200.New(0, 1, 2, 0);

	static readonly R200 Normal = R200.RotatedNormal(30 * Math.PI / 180);
	/// <summary>Test Reflection.</summary>
	///
	[Facets(Layer = "test", Status = "stable", Complexity = 2)]
	[Tags("code/unit_test", "code/reflection")]
	[System.ComponentModel.Description("Test Reflection.")]
	[Test, Ignore("Triage: ReflectedByNormal differs from Vector - 2 * projection (-2.232 vs 4.232 in Y); either the Formula or the Convention is wrong")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public static void TestReflection() {
		var projection = Vector.ProjectedOn(Normal);
		var rejection = Vector-projection;
		var reflection = Vector - projection.Times(2);
		rejection.ShouldBeSequence(Vector.RejectedFrom(Normal));
		reflection.ShouldBeSequence(Vector.ReflectedByNormal(Normal));

		var r2 = -Normal * Vector * Normal;
		r2.ShouldBeSequence(reflection);
	}

	/// <summary>Gets the neg Norm Sqr.</summary>
	static readonly R200 NegNormSqr = R200.New(1, 4, 3, 2f);

	/// <summary>Gets the normal2.<br/>
	/// Gets the normal1.</summary>
	static readonly R200 Normal2 = R200.RotatedNormal(45 * Math.PI / 180);

	static readonly R200 Normal1 = R200.RotatedNormal(90 * Math.PI / 180);
	/// <summary>Test Rotation.</summary>
	///
	[Facets(Layer = "test", Status = "stable", Complexity = 2)]
	[Tags("code/unit_test", "code/rotation")]
	[System.ComponentModel.Description("Test Rotation.")]
	[Test]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public static void TestRotation() {
		var r0 = Vector;
		var r1 = -Normal1 * r0 * Normal1;
		var r2 = -Normal2 * r1 * Normal2;

		var rotor = Normal2 * Normal1;
		var r4 = rotor * Vector * rotor.Reverted();
		r4.ShouldBeSequence(r2);
	}

	/// <summary>Gets the rANDOM.</summary>
	static readonly Random RANDOM = new(PgaTolerance.TestSeed); //fixed Seed: reproducible Test-Cases

	/// <summary> Generates 99 random <see cref="R200"/> multivectors for use as test inputs. </summary>
	///
	[Facets(Layer = "generator", Status = "stable", Complexity = 2)]
	[Tags("code/random_number_generator", "code/test_data_generation")]
	[System.ComponentModel.Description("Generates 99 random R200 multivectors for use as test inputs.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public static IEnumerable<R200> RandomR200() {
		var arr = new float[R200.NUM_COORDS];
		for (int i = 99; --i >= 0;) {
			for (int j = arr.Length; --j >= 0; ) {
				arr[j] = (float) RANDOM.NextDouble();
			}
			yield return new R200(arr);
		}
	}

	/// <summary>Gets the _ Rcp Tests.</summary>
	static readonly R200[] _RcpTests = { R200.New(0.35205, 0.1165, 0.33319, 0.013712)};
	/// <summary>Gets the rcp Tests.</summary>
	public static readonly R200[] RcpTests = _RcpTests;

	/// <summary>Test Rcp.</summary>
	///
	[Facets(Layer = "test", Status = "stable", Complexity = 2)]
	[Tags("code/unit_test", "code/reciprocal")]
	[System.ComponentModel.Description("Test Rcp.")]
	[TestCaseSource(nameof(RcpTests))]
	[TestCaseSource(typeof(R200), nameof(R200.Blades))]
	[TestCaseSource(nameof(RandomR200))]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public static void TestRcp(R200 mv) {
		var rcp = mv.Rcp();
		var r1 = mv.Times(rcp);
		r1.ShouldBeApprox(R200._1_, 5e-5);

		var r2 = mv.Times(rcp);
		r2.ShouldBeApprox(R200._1_, 5e-5);
	}
}

