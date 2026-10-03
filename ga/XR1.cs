using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using org.SpocWeb.root.array;
using org.SpocWeb.root.extensions.maths;

namespace org.SpocWeb.root.maths.pga.ga;

/// <summary> Static Methods for Algebras generated from R^1 Vector-Spaces </summary>
/// <remarks>
/// In R^1 Geometric and Dot Product are the same.
/// </remarks>
/// <example>
/// <code language="yaml">
/// pass: 2
/// mtime: 2026-07-07T17:45:08Z
/// digest: 648ac1c40e72a16f28df3997dd82651898185777aec00960d4484bfc496254ec
/// tags: [code/extension_method, code/clifford_algebra]
/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
/// facets: {layer: domain, status: stable, complexity: 2}
/// </code>
/// </example>
// ReSharper disable once InconsistentNaming
public static class XR1
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
	public static (R001.Base e, int factor) GetFactor(this R001.Base e)
		=> e < 0 ? (~e, -1) : e == R001.Base._0 ? (R001.Base._1_, 0) : (e, 1);

	/// <inheritdoc cref="GetFactor(R001.Base)"/>
	public static (R011.Base e, int factor) GetFactor(this R011.Base e)
		=> e < 0 ? (~e, -1) : e == R011.Base._0 ? (R011.Base._1_, 0) : (e, 1);

	/// <inheritdoc cref="GetFactor(R001.Base)"/>
	public static (R010.Base e, int factor) GetFactor(this R010.Base e)
		=> e < 0 ? (~e, -1) : e == R010.Base._0 ? (R010.Base._1_, 0) : (e, 1);

	/// <inheritdoc cref="GetFactor(R001.Base)"/>
	public static (R100.Base e, int factor) GetFactor(this R100.Base e)
		=> e < 0 ? (~e, -1) : e == R100.Base._0 ? (R100.Base._1_, 0) : (e, 1);

	#region unary Operations

	/// <summary> Negates both components of a 2-element multivector coordinate array. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/extension_method, code/negation]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 1}
	/// </code>
	/// </example>
	public static float[] Neg2(this IReadOnlyList<float> c) => new[] {-c[0], -c[1]};

	/// <summary> ~a; Revert the blades both for <see cref="R001"/> and <see cref="Pga2D"/>. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/extension_method, code/clifford_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 1}
	/// </code>
	/// </example>
	[TestCase(new []{1,2f}, ExpectedResult = new []{1, 2f})]
	public static float[] Reverted2(this IReadOnlyList<float> a) => new[] {a[0], a[1]};

	/// <summary> ! Complex Poincare dual for R010. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/extension_method, code/clifford_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 1}
	/// </code>
	/// </example>
	[TestCase(new []{1,2f}, ExpectedResult = new []{-2, 1f})]
	public static float[] Dual2C(this IReadOnlyList<float> a) => new[] {-a[1], a[0]};

	/// <summary> ! R001 Poincare Dual for R100 and R001 </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/extension_method, code/clifford_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 1}
	/// </code>
	/// </example>
	public static float[] Dual2(this IReadOnlyList<float> a) => new[] {a[1], a[0]};

	/// <summary> Clifford Conjugate for all 2D Algebras </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/extension_method, code/conjugate]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 1}
	/// </code>
	/// </example>
	public static float[] CliffCjg2(this IReadOnlyList<float> a) => new[] {a[0], -a[1]};

	/// <summary>Norm Sqr2 R010 Q.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/norm_calculation]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 1}
	/// </code>
	/// </example>
	[TestCase(new []{1,2f}, ExpectedResult = 5)]
	public static float NormSqr2R010Q(IReadOnlyList<float> c) => c.Times2R010C(c.CliffCjg2())[0];
	/// <summary>Norm Sqr2 R010.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/extension_method, code/norm_calculation]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 1}
	/// </code>
	/// </example>
	[TestCase(new []{1,2f}, ExpectedResult = 5)]
	public static float NormSqr2R010(this IReadOnlyList<float> a) => a[0].Sqr() + a[1].Sqr();

	/// <summary> Involution for all 2D Algebras </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/extension_method, code/clifford_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 1}
	/// </code>
	/// </example>
	[TestCase(new []{1,2f}, ExpectedResult = new []{1, -2f})]
	public static float[] Involute2(this IReadOnlyList<float> a) => new[] {a[0], -a[1]};

	#endregion unary Operations

	#region Binary Operators

	/// <summary> ^ Meet/Wedge/outer/Grassmann Product for all Geometries: R010, R001, R100 </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/extension_method, code/outer_product]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 1}
	/// </code>
	/// </example>
	public static float[] Meet2(this IReadOnlyList<float> a, IReadOnlyList<float> b) => new[] {
		b[0]*a[0],
		b[1]*a[0]+b[0]*a[1]
	};

	/// <summary> &amp; v; Join/Vee/regressive Product for all Geometries: R010, R001, R100 </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/extension_method, code/clifford_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 1}
	/// </code>
	/// </example>
	[TestCase(new []{1,2f}, new []{1,2f}, ExpectedResult = new []{ 4, 4f})]
	[TestCase(new []{1,2f}, new []{-1,-2f}, ExpectedResult = new []{ -4, -4f})]
	[TestCase(new []{-1,-2f}, new []{1,2f}, ExpectedResult = new []{ -4, -4f})]
	public static float[] Join2(this IReadOnlyList<float> a, IReadOnlyList<float> b) => new[] {
		a[0]*b[1]+a[1]*b[0],
		a[1]*b[1],
	};


	/// <summary> ^ + *; Full geometric product for Complex R010 </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/extension_method, code/geometric_product]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 1}
	/// </code>
	/// </example>
	[TestCase(new []{1,2f}, new []{-1,-2f}, ExpectedResult = new []{ 3f, -4.0f})]
	public static float[] Times2R010C(this IReadOnlyList<float> a, IReadOnlyList<float> b) => a.Dot2R010C(b);
	/// <summary> | Dot/inner product for Complex R010. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/extension_method, code/dot_product]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 1}
	/// </code>
	/// </example>
	[TestCase(new []{-1,-2f}, new []{1,2f}, ExpectedResult = new []{ 3f, -4.0f})]
	[TestCase(new []{1,2f}, new []{-1,-2f}, ExpectedResult = new []{ 3f, -4.0f})]
	[TestCase(new []{1,2f}, new []{ 1, 2f}, ExpectedResult = new []{-3f,  4.0f})]
	public static float[] Dot2R010C(this IReadOnlyList<float> a, IReadOnlyList<float> b) => new[] {
		b[0]*a[0]-b[1]*a[1],
		b[1]*a[0]+b[0]*a[1]
	};

	/// <summary>Norm Sqr2 R100 Q.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/norm_calculation]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 1}
	/// </code>
	/// </example>
	[TestCase(new []{1,2f}, ExpectedResult = -3)]
	public static float NormSqr2R100Q(IReadOnlyList<float> c) => c.Times2R010H(c.CliffCjg2())[0];
	/// <summary>Norm Sqr2 R100.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/extension_method, code/norm_calculation]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 1}
	/// </code>
	/// </example>
	[TestCase(new []{1,2f}, ExpectedResult = -3)]
	public static float NormSqr2R100(this IReadOnlyList<float> a) => a[0].Sqr() - a[1].Sqr();

	/// <summary> ^ + *; Full geometric product for Hyperbolic <see cref="R010"/> </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/extension_method, code/geometric_product]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 1}
	/// </code>
	/// </example>
	[TestCase(new []{1,2f}, new []{-1,-2f}, ExpectedResult = new []{-5f, -4.0f})]
	public static float[] Times2R010H(this IReadOnlyList<float> a, IReadOnlyList<float> b) => a.Dot2R010H(b);
	/// <summary> | Dot/inner product for Hyperbolic R100. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/extension_method, code/dot_product]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 1}
	/// </code>
	/// </example>
	[TestCase(new []{-1,-2f}, new []{1,2f}, ExpectedResult = new []{ -5f, -4.0f})]
	[TestCase(new []{1,2f}, new []{-1,-2f}, ExpectedResult = new []{ -5f, -4.0f})]
	[TestCase(new []{1,2f}, new []{ 1, 2f}, ExpectedResult = new []{  5f,  4.0f})]
	public static float[] Dot2R010H(this IReadOnlyList<float> a, IReadOnlyList<float> b) => new[] {
		b[0]*a[0]+b[1]*a[1],
		b[1]*a[0]+b[0]*a[1]
	};

	/// <summary>Norm Sqr2 R001.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/extension_method, code/norm_calculation]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 1}
	/// </code>
	/// </example>
	[TestCase(new []{8f}, ExpectedResult = 64)]
	public static float NormSqr2R001(this IReadOnlyList<float> c) => c[0].Sqr();

	/// <summary> ^ + *; Full geometric product for Projective/Dual <see cref="R001"/> </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/extension_method, code/geometric_product]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 1}
	/// </code>
	/// </example>
	[TestCase(new []{1,2f}, new []{-1,-2f}, ExpectedResult = new []{-1, -4f})]
	public static float[] Times2R001P(this IReadOnlyList<float> a, IReadOnlyList<float> b) => a.Dot2R001P(b);
	/// <summary> inner/Dot product for Projective/Dual R001. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/extension_method, code/dot_product]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 1}
	/// </code>
	/// </example>
	[TestCase(new []{-1,-2f}, new []{1,2f}, ExpectedResult = new []{ -1,-4f})]
	[TestCase(new []{1,2f}, new []{-1,-2f}, ExpectedResult = new []{ -1,-4f})]
	[TestCase(new []{1,2f}, new []{ 1, 2f}, ExpectedResult = new []{  1, 4f})]
	public static float[] Dot2R001P(this IReadOnlyList<float> a, IReadOnlyList<float> b) => new[] {
		b[0]*a[0],
		b[1]*a[0]+b[0]*a[1]
	};

	#endregion Binary Operators

	#region Test Pairs for all Products

	/// <summary>Gets the product2 R011 Geometric.</summary>
	public static readonly Func<IReadOnlyList<float>, IReadOnlyList<float>, float[]> Product2R011Geometric = XR200.Times4R011;
	/// <summary>Gets the product2 R011 Dot.</summary>
	public static readonly Func<IReadOnlyList<float>, IReadOnlyList<float>, float[]> Product2R011Dot = XR200.Dot4R011;
	/// <summary>Gets the product2 R011 Outer.</summary>
	public static readonly Func<IReadOnlyList<float>, IReadOnlyList<float>, float[]> Product2R011Outer = XR200.Meet4;

	/// <summary> Order must conform to the order in <see cref="R001.Products"/> </summary>
	static readonly Func<IReadOnlyList<float>, IReadOnlyList<float>, float[]>[] _Products2R011 = {
		Product2R011Geometric,
		Product2R011Dot,
		Product2R011Outer,
	};

	/// <summary>Gets the product2 R010 CGeometric.</summary>
	public static readonly Func<IReadOnlyList<float>, IReadOnlyList<float>, float[]> Product2R010CGeometric = Times2R010C;
	/// <summary>Gets the product2 R010 CDot.</summary>
	public static readonly Func<IReadOnlyList<float>, IReadOnlyList<float>, float[]> Product2R010CDot = Dot2R010C;
	/// <summary>Gets the product2 R010 COuter.</summary>
	public static readonly Func<IReadOnlyList<float>, IReadOnlyList<float>, float[]> Product2R010COuter = Meet2;

	/// <summary> Order must conform to the order in <see cref="R001.Products"/> </summary>
	static readonly Func<IReadOnlyList<float>, IReadOnlyList<float>, float[]>[] _Products2R010C = {
		Product2R010CGeometric,
		Product2R010CDot,
		Product2R010COuter,
	};

	/// <summary>Gets the product2 R001 PGeometric.</summary>
	public static readonly Func<IReadOnlyList<float>, IReadOnlyList<float>, float[]> Product2R001PGeometric = Times2R001P;
	/// <summary>Gets the product2 R001 PDot.</summary>
	public static readonly Func<IReadOnlyList<float>, IReadOnlyList<float>, float[]> Product2R001PDot = Dot2R001P;
	/// <summary>Gets the product2 POuter.</summary>
	public static readonly Func<IReadOnlyList<float>, IReadOnlyList<float>, float[]> Product2POuter = Meet2;

	/// <summary> Order must conform to the order in <see cref="R001.Products"/> </summary>
	static readonly Func<IReadOnlyList<float>, IReadOnlyList<float>, float[]>[] _Products2R001P = {
		Product2R001PGeometric,
		Product2R001PDot,
		// TODO: LOGIC bug - uses Product2R010COuter instead of Product2R001POuter, likely copy-pasted from the R010C block.
		Product2R010COuter,
	};

	/// <summary>Gets the product2 R010 HGeometric.</summary>
	public static readonly Func<IReadOnlyList<float>, IReadOnlyList<float>, float[]> Product2R010HGeometric = Times2R010H;
	/// <summary>Gets the product2 R010 HDot.</summary>
	public static readonly Func<IReadOnlyList<float>, IReadOnlyList<float>, float[]> Product2R010HDot = Dot2R010H;
	/// <summary>Gets the product2 R010 HOuter.</summary>
	public static readonly Func<IReadOnlyList<float>, IReadOnlyList<float>, float[]> Product2R010HOuter = Meet2;

	/// <summary> Order must conform to the order in <see cref="R001.Products"/> </summary>
	static readonly Func<IReadOnlyList<float>, IReadOnlyList<float>, float[]>[] _Products2R010H = {
		Product2R010HGeometric,
		Product2R010HDot,
		// TODO: LOGIC bug - uses Product2R010COuter instead of Product2R010HOuter, likely copy-pasted from the R001P block above.
		Product2R010COuter,
	};

	/// <summary>Gets the products2 R011.</summary>
	public static readonly Func<IReadOnlyList<float>, IReadOnlyList<float>, float[]>[] Products2R011 = _Products2R011;
	/// <summary>Gets the products2 R010 C.</summary>
	public static readonly Func<IReadOnlyList<float>, IReadOnlyList<float>, float[]>[] Products2R010C = _Products2R010C;
	/// <summary>Gets the products2 R010 H.</summary>
	public static readonly Func<IReadOnlyList<float>, IReadOnlyList<float>, float[]>[] Products2R010H = _Products2R010H;
	/// <summary>Gets the products2 R001 P.</summary>
	public static readonly Func<IReadOnlyList<float>, IReadOnlyList<float>, float[]>[] Products2R001P = _Products2R001P;

	/// <summary> Generates all Test Pairs for all Products in <see cref="R100.Products"/> </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/test_data_generation]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: generator, status: stable, complexity: 2}
	/// </code>
	/// </example>
	public static IEnumerable<(float[][], Func<IReadOnlyList<float>, IReadOnlyList<float>, float[]> product
		)> AllProduct2R010HTests() {
		for (var i = Products2R010H.Length; --i >= 0; ) {
			foreach (var valueTuple in R100.Products[i].Product2R100HTests(Products2R010H[i])) {
				yield return valueTuple;
			}
		}
	}

	/// <summary> Generates all Test Pairs for all Products in <see cref="R010.Products"/> </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/test_data_generation]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: generator, status: stable, complexity: 2}
	/// </code>
	/// </example>
	public static IEnumerable<(float[][], Func<IReadOnlyList<float>, IReadOnlyList<float>, float[]> product
		)> AllProduct2R010CTests() {
		for (var i = Products2R010C.Length; --i >= 0; ) {
			foreach (var valueTuple in R010.Products[i].Product2R010CTests(Products2R010C[i])) {
				yield return valueTuple;
			}
		}
	}

	/// <summary> Generates all Test Pairs for all Products in <see cref="R011.Products"/> </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/test_data_generation]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: generator, status: stable, complexity: 2}
	/// </code>
	/// </example>
	public static IEnumerable<(float[][], Func<IReadOnlyList<float>, IReadOnlyList<float>, float[]> product
		)> AllProductR011Tests() {
		for (var i = Products2R011.Length; --i >= 0; ) {
			foreach (var valueTuple in R011.Products[i].Product4R011CTests(Products2R011[i])) {
				yield return valueTuple;
			}
		}
	}

	/// <summary> Generates all Test Pairs for all Projective/Dual Products in <see cref="R001.Products"/> </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/test_data_generation]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: generator, status: stable, complexity: 2}
	/// </code>
	/// </example>
	public static IEnumerable<(float[][], Func<IReadOnlyList<float>, IReadOnlyList<float>, float[]> product
		)> AllProduct2R001PTests() {
		for (var i = Products2R001P.Length; --i >= 0; ) {
			foreach (var valueTuple in R001.Products[i].ProductDTests(Products2R001P[i])) {
				yield return valueTuple;
			}
		}
	}

	/// <summary> Generates all Test Cases for <paramref name="product"/> from <see cref="R001.Products"/> Pairs of <see cref="R001"/> Elements </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/extension_method, code/test_data_generation]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: generator, status: stable, complexity: 1}
	/// </code>
	/// </example>
	static IEnumerable<(float[][], Func<IReadOnlyList<float>, IReadOnlyList<float>, float[]> product
		)> ProductDTests(this IReadOnlyList<IReadOnlyList<R001.Base>> matrix
		, Func<IReadOnlyList<float>, IReadOnlyList<float>, float[]> product) 
		=> Base2VectorPairs().Select(pair => (matrix.CreateVectors(pair.x, pair.y, 2, 3), product));

	/// <summary> Generates all Test Cases for <paramref name="product"/> from <see cref="R010.Products"/> Pairs of <see cref="R001"/> Elements </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/extension_method, code/test_data_generation]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: generator, status: stable, complexity: 1}
	/// </code>
	/// </example>
	static IEnumerable<(float[][], Func<IReadOnlyList<float>, IReadOnlyList<float>, float[]> product
		)> Product4R011CTests(this IReadOnlyList<IReadOnlyList<R011.Base>> matrix
		, Func<IReadOnlyList<float>, IReadOnlyList<float>, float[]> product) 
		=> Base4VectorPairs().Select(pair => (matrix.CreateVectorsR011(pair.x, pair.y, 2, 3), product));

	/// <summary> Generates all Test Cases for <paramref name="product"/> from <see cref="R010.Products"/> Pairs of <see cref="R001"/> Elements </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/extension_method, code/test_data_generation]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: generator, status: stable, complexity: 1}
	/// </code>
	/// </example>
	static IEnumerable<(float[][], Func<IReadOnlyList<float>, IReadOnlyList<float>, float[]> product
		)> Product2R010CTests(this IReadOnlyList<IReadOnlyList<R010.Base>> matrix
		, Func<IReadOnlyList<float>, IReadOnlyList<float>, float[]> product) 
		=> Base2VectorPairs().Select(pair => (matrix.CreateVectors(pair.x, pair.y, 2, 3), product));

	/// <summary> Generates all Test Cases for <paramref name="product"/> from <see cref="R010.Products"/> Pairs of <see cref="R010"/> Elements </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/extension_method, code/test_data_generation]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: generator, status: stable, complexity: 1}
	/// </code>
	/// </example>
	static IEnumerable<(float[][], Func<IReadOnlyList<float>, IReadOnlyList<float>, float[]> product
		)> Product2R100HTests(this IReadOnlyList<IReadOnlyList<R100.Base>> matrix
		, Func<IReadOnlyList<float>, IReadOnlyList<float>, float[]> product) 
		=> Base2VectorPairs().Select(pair => (matrix.CreateVectors(pair.x, pair.y, 2, 3), product));

	/// <summary> Generates all Pairs of <see cref="R001"/> Base Vectors Elements </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/test_data_generation, code/combinatorial_generation]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: generator, status: stable, complexity: 2}
	/// </code>
	/// </example>
	public static IEnumerable<(R001.Base x, R001.Base y)> Base2VectorPairs() {
		for (var k = R001.Base._1_; k != R001.Base._0; ++k) {
			for (var i = R001.Base._1_; i != R001.Base._0; ++i) {
				yield return (i, k);
			}
		}
	}

	/// <summary> Generates all Pairs of <see cref="R011"/> Base Vectors Elements </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/test_data_generation, code/combinatorial_generation]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: generator, status: stable, complexity: 2}
	/// </code>
	/// </example>
	public static IEnumerable<(R011.Base x, R011.Base y)> Base4VectorPairs() {
		for (var k = R011.Base._1_; k != R011.Base._0; ++k) {
			for (var i = R011.Base._1_; i != R011.Base._0; ++i) {
				yield return (i, k);
			}
		}
	}

	/// <summary>Test All Products R011.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/unit_test]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: test, status: stable, complexity: 2}
	/// </code>
	/// </example>
	[TestCaseSource(nameof(AllProduct2R010HTests))]
	[TestCaseSource(nameof(AllProduct2R001PTests))]
	[TestCaseSource(nameof(AllProduct2R010CTests))]
	[TestCaseSource(nameof(AllProductR011Tests))]
	public static void TestAllProductsR011((float[][] vectors, Func<IReadOnlyList<float>, IReadOnlyList<float>, float[]> product) test) {
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
	public static float[][] CreateVectors(this IReadOnlyList<IReadOnlyList<R001.Base>> products, R001.Base a, R001.Base b, double factor1, double factor2) {
		var (e, factor) = products[(int) a][(int) b].GetFactor();
		return CreateVectors(R001.NUM_COORDS, (int) a, (int) b, factor1, factor2, (int) e, factor);
	}

	/// <summary> Creates a three-element test vector array for <see cref="R011"/> operands using the product table. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/extension_method, code/test_data_generation]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: generator, status: stable, complexity: 1}
	/// </code>
	/// </example>
	public static float[][] CreateVectorsR011(this IReadOnlyList<IReadOnlyList<R011.Base>> products
		, R011.Base a, R011.Base b, double factor1, double factor2) { //, double factor3, double factor4) {
		var (e, factor) = products[(int) a][(int) b].GetFactor();
		return CreateVectors(R011.NUM_COORDS, (int) a, (int) b, factor1, factor2, (int) e, factor);
	}

	/// <inheritdoc cref="CreateVectors(IReadOnlyList{IReadOnlyList{R001.Base}}, R001.Base, R001.Base, double, double)"/>
	public static float[][] CreateVectors(this IReadOnlyList<IReadOnlyList<R010.Base>> products, R001.Base a, R001.Base b, double factor1, double factor2) {
		var (e, factor) = products[(int) a][(int) b].GetFactor();
		return CreateVectors(R010.NUM_COORDS, (int) a, (int) b, factor1, factor2, (int) e, factor);
	}

	/// <inheritdoc cref="CreateVectors(IReadOnlyList{IReadOnlyList{R001.Base}}, R001.Base, R001.Base, double, double)"/>
	public static float[][] CreateVectors(this IReadOnlyList<IReadOnlyList<R100.Base>> products, R001.Base a, R001.Base b, double factor1, double factor2) {
		var (e, factor) = products[(int) a][(int) b].GetFactor();
		return CreateVectors(R100.NUM_COORDS, (int) a, (int) b, factor1, factor2, (int) e, factor);
	}

	/// <inheritdoc cref="CreateVectors(IReadOnlyList{IReadOnlyList{R001.Base}}, R001.Base, R001.Base, double, double)"/>
	static float[][] CreateVectors(int numCoords, int a, int b, double factor1, double factor2, int e, int factor) {
		var vectors = new[] {
			new float[numCoords],
			new float[numCoords],
			new float[numCoords],
		};
		vectors[0][a] = (float) factor1;
		vectors[1][b] = (float) factor2;
		vectors[2][e] = (float) (factor1 * factor2 * factor);
		return vectors;
	}

	#endregion Test Pairs for all Products

	#region binary Scalar Operations

	/// <summary> Adds scalar <paramref name="b"/> to the grade-0 component of the 2-element array <paramref name="a"/>. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/extension_method, code/scalar_addition]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 1}
	/// </code>
	/// </example>
	public static float[] Plus2(this IReadOnlyList<float> a, double b) => new []{(float)(a[0] + b), a[1]};
	/// <summary> Subtracts scalar <paramref name="b"/> from the grade-0 component of the 2-element array <paramref name="a"/>. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/extension_method, code/subtraction]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 1}
	/// </code>
	/// </example>
	public static float[] Minus2(this IReadOnlyList<float> a, double b) => new []{(float)(a[0] - b), a[1]};
	/// <summary> Subtracts the grade-0 component of <paramref name="b"/> from scalar <paramref name="a"/>,
	/// negating the remaining component. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/extension_method, code/subtraction, code/negation]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 1}
	/// </code>
	/// </example>
	public static float[] MinusR2(this IReadOnlyList<float> b, double a) => new []{(float)(a - b[0]), -b[1]};

	/// <inheritdoc cref="Plus2(IReadOnlyList{float}, double)"/>
	public static float[] Plus2<B>(this IReadOnlyList<float> a, double b, B basis) where B : Enum, IConvertible
		=> basis.ToInt32(null) == 0 ? a.Plus2(b) : new []{a[0], (float)(a[1] + b)};
	/// <inheritdoc cref="Minus2(IReadOnlyList{float}, double)"/>
	public static float[] Minus2<B>(this IReadOnlyList<float> a, double b, B basis)  where B : Enum, IConvertible
		=> basis.ToInt32(null) == 0 ? a.Minus2(b) : new []{a[0], (float)(a[1] - b)};
	/// <inheritdoc cref="MinusR2(IReadOnlyList{float}, double)"/>
	public static float[] MinusR2<B>(this IReadOnlyList<float> b, double a, B basis)  where B : Enum, IConvertible
		=> basis.ToInt32(null) == 0 ? b.MinusR2(a) : new []{b[0], (float)(a - b[1])};

	/// <inheritdoc cref="Plus2(IReadOnlyList{float}, double)"/>
	[TestCase(new []{ 1, 2f}, new []{ 1, 2f}, ExpectedResult = new []{2,4f})]
	[TestCase(new []{ 1, 2f}, new []{-1,-2f}, ExpectedResult = new []{0,0f})]
	[TestCase(new []{-1,-2f}, new []{ 1, 2f}, ExpectedResult = new []{0,0f})]
	public static float[] Plus2(this IReadOnlyList<float> a, IReadOnlyList<float> b) => new []{a[0] + b[0], a[1] + b[1]};

	/// <summary> - Minus, SUB; Vector[8] Subtraction </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/extension_method, code/vector_subtraction]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 1}
	/// </code>
	/// </example>
	[TestCase(new []{ 1, 2f}, new []{ 1, 2f}, ExpectedResult = new []{0,0f})]
	[TestCase(new []{ 1, 2f}, new []{-1,-2f}, ExpectedResult = new []{2,4f})]
	[TestCase(new []{-1,-2f}, new []{ 1, 2f}, ExpectedResult = new []{-2,-4f})]
	public static float[] Minus2(this IReadOnlyList<float> a, IReadOnlyList<float> b) => new []{a[0] - b[0], a[1] - b[1]};

	/// <summary> * sMul / Times : scalar/multi-vector multiplication </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/extension_method, code/scalar_multiplication]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 1}
	/// </code>
	/// </example>
	[TestCase(new[] {1, 2f}, 3, ExpectedResult = new[] {3, 6f})]
	[TestCase(new[] {-1, -2f}, 3, ExpectedResult = new[] {-3, -6f})]
	public static float[] Times2(this IReadOnlyList<float> a, float b) => new[] {a[0] * b, a[1] * b};

	#endregion binary Scalar Operations

	/// <summary>Gets the rANDOM.</summary>
	static readonly Random RANDOM = new();

	/// <summary> Generates 99 random <see cref="R100"/> multivectors for use as test inputs. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/random_number_generator, code/test_data_generation]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: generator, status: stable, complexity: 2}
	/// </code>
	/// </example>
	public static IEnumerable<R100> RandomR100() {
		var arr = new float[R100.NUM_COORDS];
		for (int i = 99; --i >= 0;) {
			for (int j = arr.Length; --j >= 0; ) {
				arr[j] = (float) RANDOM.NextDouble();
			}
			yield return new R100(arr);
		}
	}

	/// <summary>Test R100 Rcp.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/unit_test, code/reciprocal]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: test, status: stable, complexity: 2}
	/// </code>
	/// </example>
	[TestCaseSource(typeof(R100), nameof(R100.Blades))]
	[TestCaseSource(nameof(RandomR100))]
	public static void TestR100Rcp(R100 mv) {
		var rcp = mv.Rcp();
		var r1 = mv.Times(rcp);
		r1.ShouldBeApprox(R100._1_, 5e-5);

		var r2 = mv.Times(rcp);
		r2.ShouldBeApprox(R100._1_, 5e-5);
	}

	/// <summary> Generates 99 random <see cref="R010"/> multivectors for use as test inputs. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/random_number_generator, code/test_data_generation]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: generator, status: stable, complexity: 2}
	/// </code>
	/// </example>
	public static IEnumerable<R010> RandomR010() {
		var arr = new float[R010.NUM_COORDS];
		for (int i = 99; --i >= 0;) {
			for (int j = arr.Length; --j >= 0; ) {
				arr[j] = (float) RANDOM.NextDouble();
			}
			yield return new R010(arr);
		}
	}

	/// <summary>Test R010 Rcp.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/unit_test, code/reciprocal]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: test, status: stable, complexity: 2}
	/// </code>
	/// </example>
	[TestCaseSource(typeof(R010), nameof(R010.Blades))]
	[TestCaseSource(nameof(RandomR010))]
	public static void TestR010Rcp(R010 mv) {
		var rcp = mv.Rcp();
		var r1 = mv.Times(rcp);
		r1.ShouldBeApprox(R010._1_, 5e-5);

		var r2 = mv.Times(rcp);
		r2.ShouldBeApprox(R010._1_, 5e-5);
	}

	/// <summary> Generates 99 random <see cref="R001"/> multivectors for use as test inputs. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/random_number_generator, code/test_data_generation]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: generator, status: stable, complexity: 2}
	/// </code>
	/// </example>
	public static IEnumerable<R001> RandomR001() {
		var arr = new float[R001.NUM_COORDS];
		for (int i = 99; --i >= 0;) {
			for (int j = arr.Length; --j >= 0; ) {
				arr[j] = (float) RANDOM.NextDouble();
			}
			yield return new R001(arr);
		}
	}

	//[TestCaseSource(typeof(R001), nameof(R001.Blades))] only _1_ works, E1�=0
	/// <summary>Test R001 Rcp.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/unit_test, code/reciprocal]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: test, status: stable, complexity: 2}
	/// </code>
	/// </example>
	[TestCaseSource(nameof(RandomR001))]
	public static void TestR001Rcp(R001 mv) {
		var rcp = mv.Rcp();
		var r1 = mv.Times(rcp);
		r1.ShouldBeApprox(R001._1_, 5e-5);

		var r2 = mv.Times(rcp);
		r2.ShouldBeApprox(R001._1_, 5e-5);
	}

	/// <summary> Generates 99 random <see cref="R011"/> multivectors for use as test inputs. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/random_number_generator, code/test_data_generation]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: generator, status: stable, complexity: 2}
	/// </code>
	/// </example>
	public static IEnumerable<R011> RandomR011() {
		var arr = new float[R011.NUM_COORDS];
		for (int i = 99; --i >= 0;) {
			for (int j = arr.Length; --j >= 0; ) {
				arr[j] = (float) RANDOM.NextDouble();
			}
			yield return new R011(arr);
		}
	}

	//[TestCaseSource(typeof(R011), nameof(R011.Blades))] only _1_ and I work
	/// <summary>Test R011 Rcp.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/unit_test, code/reciprocal]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: test, status: stable, complexity: 2}
	/// </code>
	/// </example>
	[TestCaseSource(nameof(RandomR011))]
	public static void TestR011Rcp(R011 mv) {
		var rcp = mv.Rcp();
		var r1 = mv.Times(rcp);
		r1.ShouldBeApprox(R011._1_, 5e-5);

		var r2 = mv.Times(rcp);
		r2.ShouldBeApprox(R011._1_, 5e-5);
	}

	/// <summary> Generates 99 random <see cref="R110"/> multivectors for use as test inputs. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/random_number_generator, code/test_data_generation]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: generator, status: stable, complexity: 2}
	/// </code>
	/// </example>
	public static IEnumerable<R110> RandomR110() {
		var arr = new float[R110.NUM_COORDS];
		for (int i = 99; --i >= 0;) {
			for (int j = arr.Length; --j >= 0; ) {
				arr[j] = (float) RANDOM.NextDouble();
			}
			yield return new R110(arr);
		}
	}

	/// <summary>Test R110 Rcp.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/unit_test, code/reciprocal]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: test, status: stable, complexity: 2}
	/// </code>
	/// </example>
	[TestCaseSource(typeof(R110), nameof(R110.Blades))]
	[TestCaseSource(nameof(RandomR110))]
	public static void TestR110Rcp(R110 mv) {
		var rcp = mv.Rcp();
		var r1 = mv.Times(rcp);
		r1.ShouldBeApprox(R110._1_, 2e-4);

		var r2 = mv.Times(rcp);
		r2.ShouldBeApprox(R110._1_, 2e-4);
	}

	/*public static IEnumerable<R101> RandomR101() {
		var arr = new float[R101.NUM_COORDS];
		for (int i = 99; --i >= 0;) {
			for (int j = arr.Length; --j >= 0; ) {
				arr[j] = (float) RANDOM.NextDouble();
			}
			yield return new R101(arr);
		}
	}

	[TestCaseSource(typeof(R101), nameof(R101.Blades))]
	[TestCaseSource(nameof(RandomR101))]
	public static void TestR101Rcp(R101 mv) {
		var rcp = mv.Rcp();
		var r1 = mv.Times(rcp);
		r1.ShouldBeApprox(R101._1_, 5e-5);

		var r2 = mv.Times(rcp);
		r2.ShouldBeApprox(R101._1_, 5e-5);
	}*/

}
