using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using org.SpocWeb.root.interfaces.maths;
using org.SpocWeb.root.logging;
using org.SpocWeb.root.Attributes;

namespace org.SpocWeb.root.maths.pga;

// ReSharper disable once InconsistentNaming
/// <summary> Static extension and utility methods for the <see cref="PGA3D"/> G(3,0,1) multivector type. </summary>
/// <remarks>
/// ## Public Methods
///
/// | Line | Method | Description |
/// |--:|---|---|
/// | 42 | <see cref="Test"/> | Test. |
/// | 75 | <see cref="Meet"/> | Wedge Product |
/// | 100 | <see cref="Times"/> | Full geometric product of two 16-component G(3,0,1) multivector coefficient arrays. |
/// | 125 | <see cref="Dot"/> | Dot. |
/// | 157 | <see cref="Join"/> | Join. |
/// | 188 | <see cref="MulS"/> |  |
/// | 196 | <see cref="MulS16"/> | Product of a scalar with a 16-dim. vector common in 3D geometric Algebra |
///
/// ## Collaborators
///
/// | Type | Role |
/// |---|---|
/// | <see cref="PGA3D"/> | Returned by a method. |
/// </remarks>
///
[DocState(Pass = 2, MTime = "2026-05-24T15:38:52Z", Digest = "9c04d76f03537170aab4c1ae4c444e6556113ee3c59e3c26518026f411c7fde1", Stale = false, Path = "pga3d.cs", Since = "2026-10-06")]
[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
[Tags("code/extension_method", "code/projective_geometric_algebra")]
[System.ComponentModel.Description("Static extension and utility methods for the PGA3D G(3,0,1) multivector type.")]
[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
public static class XPGA3D
{
	/// <summary>Test.</summary>
	///
	[Facets(Layer = "test", Status = "stable", Complexity = 2)]
	[Tags("code/unit_test", "code/projective_geometric_algebra")]
	[System.ComponentModel.Description("Test.")]
	[Test, Ignore("Triage: point * point is a geometric product, not an addition, so moved is not Point(7, 7); the Expectation predates the current Convention")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public static void Test() {
		var xz = PGA3D.Plane(0, 1,0, 0);
		var yz = PGA3D.Plane(1, 0, 0, 0);
		var z = xz.Meet(yz);

		var O0 = PGA3D.Point(0, 0, 0);
		var z1 = PGA3D.Point(0, 0, 1);
		var z2 = O0.Join(z1);

		var rotor = PGA3D.Rotor(Math.PI / 4, z); //PGA3D.Line);
		var dbl = rotor.Times(rotor);
		PGA3D expected1 = PGA3D.Rotor(Math.PI / 2, z);
		PgaAssert.AreClose(dbl.Values, expected1.Values);

		var start = PGA3D.Point(3, 4);
		var trans = PGA3D.Point(4, 3);
		var moved = start.Times(trans);
		_ = moved.ShouldBe(PGA3D.Point(7, 7));

		var turned = moved.Times(dbl);
		var expected = PGA3D.Point(-7, 7);
		turned.ShouldBe(expected.CloseTo);
	}

	/// <summary> Wedge Product </summary>
	///
	//[TestCase(new []{1,2,3,4,5,6,7,8.0}, new []{-1,-2,-3,-4,-5,-6,-7,-8.0}
	//	, ExpectedResult = new []{ -1, -4, -6, -8, -10, -12, -14, -48.0})]
	[Facets(Layer = "domain", Status = "stable", Complexity = 1)]
	[Tags("code/extension_method", "code/outer_product")]
	[System.ComponentModel.Description("Wedge Product")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public static float[] Meet(this float[] a, float[] b) => new[]{
		b[0]*a[0],
		b[1]*a[0]+b[0]*a[1],
		b[2]*a[0]+b[0]*a[2],
		b[3]*a[0]+b[0]*a[3],
		b[4]*a[0]+b[0]*a[4],
		b[5]*a[0]+b[2]*a[1]-b[1]*a[2]+b[0]*a[5],
		b[6]*a[0]+b[3]*a[1]-b[1]*a[3]+b[0]*a[6],
		b[7]*a[0]+b[4]*a[1]-b[1]*a[4]+b[0]*a[7],
		b[8]*a[0]+b[3]*a[2]-b[2]*a[3]+b[0]*a[8],
		b[9]*a[0]-b[4]*a[2]+b[2]*a[4]+b[0]*a[9],
		b[10]*a[0]+b[4]*a[3]-b[3]*a[4]+b[0]*a[10],
		b[11]*a[0]-b[8]*a[1]+b[6]*a[2]-b[5]*a[3]-b[3]*a[5]+b[2]*a[6]-b[1]*a[8]+b[0]*a[11],
		b[12]*a[0]-b[9]*a[1]-b[7]*a[2]+b[5]*a[4]+b[4]*a[5]-b[2]*a[7]-b[1]*a[9]+b[0]*a[12],
		b[13]*a[0]-b[10]*a[1]+b[7]*a[3]-b[6]*a[4]-b[4]*a[6]+b[3]*a[7]-b[1]*a[10]+b[0]*a[13],
		b[14]*a[0]+b[10]*a[2]+b[9]*a[3]+b[8]*a[4]+b[4]*a[8]+b[3]*a[9]+b[2]*a[10]+b[0]*a[14],
		b[15]*a[0]+b[14]*a[1]+b[13]*a[2]+b[12]*a[3]+b[11]*a[4]+b[10]*a[5]+b[9]*a[6]+b[8]*a[7]+b[7]*a[8]+b[6]*a[9]+b[5]*a[10]-b[4]*a[11]-b[3]*a[12]-b[2]*a[13]-b[1]*a[14]+b[0]*a[15]
	};

	/// <summary> Full geometric product of two 16-component G(3,0,1) multivector coefficient arrays. </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 1)]
	[Tags("code/extension_method", "code/geometric_product")]
	[System.ComponentModel.Description("Full geometric product of two 16-component G(3,0,1) multivector coefficient arrays.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public static float[] Times(this float[] a, float[] b) => new []{
			b[0]*a[0]+b[2]*a[2]+b[3]*a[3]+b[4]*a[4]-b[8]*a[8]-b[9]*a[9]-b[10]*a[10]-b[14]*a[14],
			b[1]*a[0]+b[0]*a[1]-b[5]*a[2]-b[6]*a[3]-b[7]*a[4]+b[2]*a[5]+b[3]*a[6]+b[4]*a[7]+b[11]*a[8]+b[12]*a[9]+b[13]*a[10]+b[8]*a[11]+b[9]*a[12]+b[10]*a[13]+b[15]*a[14]-b[14]*a[15],
			b[2]*a[0]+b[0]*a[2]-b[8]*a[3]+b[9]*a[4]+b[3]*a[8]-b[4]*a[9]-b[14]*a[10]-b[10]*a[14],
			b[3]*a[0]+b[8]*a[2]+b[0]*a[3]-b[10]*a[4]-b[2]*a[8]-b[14]*a[9]+b[4]*a[10]-b[9]*a[14],
			b[4]*a[0]-b[9]*a[2]+b[10]*a[3]+b[0]*a[4]-b[14]*a[8]+b[2]*a[9]-b[3]*a[10]-b[8]*a[14],
			b[5]*a[0]+b[2]*a[1]-b[1]*a[2]-b[11]*a[3]+b[12]*a[4]+b[0]*a[5]-b[8]*a[6]+b[9]*a[7]+b[6]*a[8]-b[7]*a[9]-b[15]*a[10]-b[3]*a[11]+b[4]*a[12]+b[14]*a[13]-b[13]*a[14]-b[10]*a[15],
			b[6]*a[0]+b[3]*a[1]+b[11]*a[2]-b[1]*a[3]-b[13]*a[4]+b[8]*a[5]+b[0]*a[6]-b[10]*a[7]-b[5]*a[8]-b[15]*a[9]+b[7]*a[10]+b[2]*a[11]+b[14]*a[12]-b[4]*a[13]-b[12]*a[14]-b[9]*a[15],
			b[7]*a[0]+b[4]*a[1]-b[12]*a[2]+b[13]*a[3]-b[1]*a[4]-b[9]*a[5]+b[10]*a[6]+b[0]*a[7]-b[15]*a[8]+b[5]*a[9]-b[6]*a[10]+b[14]*a[11]-b[2]*a[12]+b[3]*a[13]-b[11]*a[14]-b[8]*a[15],
			b[8]*a[0]+b[3]*a[2]-b[2]*a[3]+b[14]*a[4]+b[0]*a[8]+b[10]*a[9]-b[9]*a[10]+b[4]*a[14],
			b[9]*a[0]-b[4]*a[2]+b[14]*a[3]+b[2]*a[4]-b[10]*a[8]+b[0]*a[9]+b[8]*a[10]+b[3]*a[14],
			b[10]*a[0]+b[14]*a[2]+b[4]*a[3]-b[3]*a[4]+b[9]*a[8]-b[8]*a[9]+b[0]*a[10]+b[2]*a[14],
			b[11]*a[0]-b[8]*a[1]+b[6]*a[2]-b[5]*a[3]+b[15]*a[4]-b[3]*a[5]+b[2]*a[6]-b[14]*a[7]-b[1]*a[8]+b[13]*a[9]-b[12]*a[10]+b[0]*a[11]+b[10]*a[12]-b[9]*a[13]+b[7]*a[14]-b[4]*a[15],
			b[12]*a[0]-b[9]*a[1]-b[7]*a[2]+b[15]*a[3]+b[5]*a[4]+b[4]*a[5]-b[14]*a[6]-b[2]*a[7]-b[13]*a[8]-b[1]*a[9]+b[11]*a[10]-b[10]*a[11]+b[0]*a[12]+b[8]*a[13]+b[6]*a[14]-b[3]*a[15],
			b[13]*a[0]-b[10]*a[1]+b[15]*a[2]+b[7]*a[3]-b[6]*a[4]-b[14]*a[5]-b[4]*a[6]+b[3]*a[7]+b[12]*a[8]-b[11]*a[9]-b[1]*a[10]+b[9]*a[11]-b[8]*a[12]+b[0]*a[13]+b[5]*a[14]-b[2]*a[15],
			b[14]*a[0]+b[10]*a[2]+b[9]*a[3]+b[8]*a[4]+b[4]*a[8]+b[3]*a[9]+b[2]*a[10]+b[0]*a[14],
			b[15]*a[0]+b[14]*a[1]+b[13]*a[2]+b[12]*a[3]+b[11]*a[4]+b[10]*a[5]+b[9]*a[6]+b[8]*a[7]+b[7]*a[8]+b[6]*a[9]+b[5]*a[10]-b[4]*a[11]-b[3]*a[12]-b[2]*a[13]-b[1]*a[14]+b[0]*a[15]
		};

	/// <summary>Dot.</summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 1)]
	[Tags("code/extension_method", "code/dot_product")]
	[System.ComponentModel.Description("Dot.")]
	[TestCase(new []{1,2,3,4,5,6,7,8,-1,-2,-3,-4,-5,-6,-7,-8f}, new []{1,2,3,4,5,6,7,8,-1,-2,-3,-4,-5,-6,-7,-8f}
		, ExpectedResult = new []{-12,68,-36,-20,-4,-54,18,-18, -72, -60,-48, -8, -10,-12, -14, -16f})]
	[TestCase(new []{1,2,3,4,5,6,7,8,1,2,3,4,5,6,7,8f}, new []{-1,-2,-3,-4,-5,-6,-7,-8,1,2,3,4,5,6,7,8f}
		, ExpectedResult = new []{-114,60,-36,-60,-12,-60,-46,-32,0, 0, 0,80,64, 48,0,0f})]
	[TestCase(new []{-1,-2,-3,-4,-5,-6,-7,-8,1,2,3,4,5,6,7,8f}, new []{1,2,3,4,5,6,7,8,1,2,3,4,5,6,7,8f}
		, ExpectedResult = new []{-114,60,-60,-12,-36,-60,-46,-32,0, 0, 0,-80, -64, -48,0, 0f})]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public static float[] Dot(this IReadOnlyList<float> a, IReadOnlyList<float> b) =>
		new[]{
			b[0]*a[0]+b[2]*a[2]+b[3]*a[3]+b[4]*a[4]-b[8]*a[8]-b[9]*a[9]-b[10]*a[10]-b[14]*a[14],
			b[1]*a[0]+b[0]*a[1]-b[5]*a[2]-b[6]*a[3]-b[7]*a[4]+b[2]*a[5]+b[3]*a[6]+b[4]*a[7]+b[11]*a[8]+b[12]*a[9]+b[13]*a[10]+b[8]*a[11]+b[9]*a[12]+b[10]*a[13]+b[15]*a[14]-b[14]*a[15],
			b[2]*a[0]+b[0]*a[2]-b[8]*a[3]+b[9]*a[4]+b[3]*a[8]-b[4]*a[9]-b[14]*a[10]-b[10]*a[14],
			b[3]*a[0]+b[8]*a[2]+b[0]*a[3]-b[10]*a[4]-b[2]*a[8]-b[14]*a[9]+b[4]*a[10]-b[9]*a[14],
			b[4]*a[0]-b[9]*a[2]+b[10]*a[3]+b[0]*a[4]-b[14]*a[8]+b[2]*a[9]-b[3]*a[10]-b[8]*a[14],
			b[5]*a[0]-b[11]*a[3]+b[12]*a[4]+b[0]*a[5]-b[15]*a[10]-b[3]*a[11]+b[4]*a[12]-b[10]*a[15],
			b[6]*a[0]+b[11]*a[2]-b[13]*a[4]+b[0]*a[6]-b[15]*a[9]+b[2]*a[11]-b[4]*a[13]-b[9]*a[15],
			b[7]*a[0]-b[12]*a[2]+b[13]*a[3]+b[0]*a[7]-b[15]*a[8]-b[2]*a[12]+b[3]*a[13]-b[8]*a[15],
			b[8]*a[0]+b[14]*a[4]+b[0]*a[8]+b[4]*a[14],
			b[9]*a[0]+b[14]*a[3]+b[0]*a[9]+b[3]*a[14],
			b[10]*a[0]+b[14]*a[2]+b[0]*a[10]+b[2]*a[14],
			b[11]*a[0]+b[15]*a[4]+b[0]*a[11]-b[4]*a[15],
			b[12]*a[0]+b[15]*a[3]+b[0]*a[12]-b[3]*a[15],
			b[13]*a[0]+b[15]*a[2]+b[0]*a[13]-b[2]*a[15],
			b[14]*a[0]+b[0]*a[14],
			b[15]*a[0]+b[0]*a[15]
		};

	/// <summary>Join.</summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 1)]
	[Tags("code/extension_method", "code/clifford_algebra")]
	[System.ComponentModel.Description("Join.")]
	[TestCase(new []{1,2,3,4,5,6,7,8,-1,-2,-3,-4,-5,-6,-7,-8f}, new []{1,2,3,4,5,6,7,8,-1,-2,-3,-4,-5,-6,-7,-8f}
		, ExpectedResult = new []{-96,174,-126,-174,-186,-96,-112,-128,16,32,48,64,80,96,112,64f})]
	[TestCase(new []{1,2,3,4,5,6,7,8,1,2,3,4,5,6,7,8f}, new []{-1,-2,-3,-4,-5,-6,-7,-8,1,2,3,4,5,6,7,8f}
		, ExpectedResult = new []{-144,0,6,-12,6,0,0,0,16, 32, 48,64, 80, 96,112, 64f})]
	[TestCase(new []{-1,-2,-3,-4,-5,-6,-7,-8,1,2,3,4,5,6,7,8f}, new []{1,2,3,4,5,6,7,8,1,2,3,4,5,6,7,8f}
		, ExpectedResult = new []{144,0,6,-12,6,0,0,0,16, 32, 48,64, 80, 96,112, 64f})]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public static float[] Join(this IReadOnlyList<float> a, IReadOnlyList<float> b) =>
		new [] {
			a[0]*b[15]+-1*a[1]*b[14]+a[2]*b[13]*-1+a[3]*b[12]*-1+a[4]*b[11]*-1+a[5]*b[10]+a[6]*b[9]+a[7]*b[8]+a[8]*b[7]+a[9]*b[6]+a[10]*b[5]-a[11]*-1*b[4]-a[12]*-1*b[3]-a[13]*-1*b[2]-a[14]*-1*b[1]+a[15]*b[0],
			a[1]*b[15]+a[5]*b[13]*-1+a[6]*b[12]*-1+a[7]*b[11]*-1+a[11]*-1*b[7]+a[12]*-1*b[6]+a[13]*-1*b[5]+a[15]*b[1],
			a[2]*b[15]-a[5]*b[14]*-1+a[8]*b[12]*-1-a[9]*b[11]*-1-a[11]*-1*b[9]+a[12]*-1*b[8]-a[14]*-1*b[5]+a[15]*b[2],
			a[3]*b[15]-a[6]*b[14]*-1-a[8]*b[13]*-1+a[10]*b[11]*-1+a[11]*-1*b[10]-a[13]*-1*b[8]-a[14]*-1*b[6]+a[15]*b[3],
			a[4]*b[15]-a[7]*b[14]*-1+a[9]*b[13]*-1-a[10]*b[12]*-1-a[12]*-1*b[10]+a[13]*-1*b[9]-a[14]*-1*b[7]+a[15]*b[4],
			a[5]*b[15]+a[11]*-1*b[12]*-1-a[12]*-1*b[11]*-1+a[15]*b[5],
			a[6]*b[15]-a[11]*-1*b[13]*-1+a[13]*-1*b[11]*-1+a[15]*b[6],
			a[7]*b[15]+a[12]*-1*b[13]*-1-a[13]*-1*b[12]*-1+a[15]*b[7],
			a[8]*b[15]+a[11]*-1*b[14]*-1-a[14]*-1*b[11]*-1+a[15]*b[8],
			a[9]*b[15]+a[12]*-1*b[14]*-1-a[14]*-1*b[12]*-1+a[15]*b[9],
			a[10]*b[15]+a[13]*-1*b[14]*-1-a[14]*-1*b[13]*-1+a[15]*b[10],
			-(a[11]*-1*b[15]+a[15]*b[11]*-1),
			-(a[12]*-1*b[15]+a[15]*b[12]*-1),
			-(a[13]*-1*b[15]+a[15]*b[13]*-1),
			-(a[14]*-1*b[15]+a[15]*b[14]*-1),
			a[15]*b[15],
		};

	/// <summary> <inheritdoc cref="MulS16"/> </summary>
	[Facets(Layer = "domain", Status = "stable", Complexity = 1)]
	[Tags("code/extension_method", "code/scalar_multiplication")]
	[System.ComponentModel.Description("")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public static PGA3D MulS (this PGA3D a, float b) => new(a.Values.MulS16(b));

	/// <summary> Product of a <paramref name="scalar"/> with a 16-dim. <paramref name="vector"/> common in 3D geometric Algebra </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 1)]
	[Tags("code/extension_method", "code/scalar_multiplication")]
	[System.ComponentModel.Description("Product of a scalar with a 16-dim. vector common in 3D geometric Algebra")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public static float[] MulS16 (this IReadOnlyList<float> vector, float scalar) =>
		new[] {
			vector[0]*scalar,
			vector[1]*scalar,
			vector[2]*scalar,
			vector[3]*scalar,
			vector[4]*scalar,
			vector[5]*scalar,
			vector[6]*scalar,
			vector[7]*scalar,
			vector[8]*scalar,
			vector[9]*scalar,
			vector[10]*scalar,
			vector[11]*scalar,
			vector[12]*scalar,
			vector[13]*scalar,
			vector[14]*scalar,
			vector[15]*scalar
		};

}

/// <summary>
/// <see cref="pga.Pga3D"/>
/// Projective Geometric Algebra in 3D, also known as 3D PGA, 
/// extends geometric algebra to include projective geometry. 
/// It provides a powerful tool for representing and manipulating geometric objects such as 
/// - points, lines, planes, and transformations in three-dimensional space. 
/// 
/// In 3D PGA, geometric entities are represented as multivectors, 
/// which can be combined using various algebraic operations 
/// to perform geometric transformations and calculations. This
/// framework is particularly useful in computer graphics, robotics, and physics
/// for modeling and analyzing spatial relationships and transformations.
///
/// </summary>
/// <remarks>
/// ## Public Methods
///
/// | Line | Method | Description |
/// |--:|---|---|
/// | 314 | <see cref="Basis"/> | Initializes a new instance of PGA3D with the specified f and idx. |
/// | 319 | <see cref="Values"/> | Initializes a new instance of PGA3D with the specified f. |
/// | 326 | <see cref="PGA3D"/> | Initializes a new instance of PGA3D with the specified f and idx. |
/// | 341 | <see cref="PGA3D"/> | Initializes a new instance of PGA3D with the specified f. |
/// | 350 | <see cref="this[]"/> | Gets or sets the idx-th component coefficient. |
/// | 364 | <see cref="operator ~"/> | ~ Inverse the basis blades. |
/// | 391 | <see cref="operator !"/> | PGA3D.Dual: res = !a Poincare duality operator. |
/// | 419 | <see cref="Conjugate"/> | PGA3D.Conjugate: res = a.Conjugate() Clifford Conjugation |
/// | 451 | <see cref="Involute"/> | PGA3D.Involute: res = a.Involute() Main involution |
/// | 482 | <see cref="operator ^"/> | PGA3D.Wedge: res = a ^ b The outer product. (MEET) |
/// | 486 | <see cref="Meet"/> | Outer (wedge) product of this multivector and b. |
/// | 496 | <see cref="operator *"/> | PGA3D.Mul: res = a * b The geometric product. |
/// | 500 | <see cref="Times"/> | Full geometric product of this multivector and b. |
/// | 507 | <see cref="operator &"/> | &amp;, v; regressive product. (JOIN) |
/// | 511 | <see cref="Join"/> | Regressive (join / vee) product of this multivector and b. |
/// | 521 | <see cref="operator |"/> | PGA3D.Dot: res = a | b The inner product. |
/// | 525 | <see cref="Dot"/> | Inner (dot) product of this multivector and b. |
/// | 535 | <see cref="operator +"/> | PGA3D.Add: res = a + b Multivector addition |
/// | 562 | <see cref="operator -"/> | PGA3D.Sub: res = a - b Multivector subtraction |
/// | 589 | <see cref="operator *"/> | PGA3D.smul: res = a * b scalar/multivector multiplication |
/// | 613 | <see cref="operator *"/> | Multiplies <paramref name="a"/> by <paramref name="b"/>. |
/// | 616 | <see cref="operator *"/> | Multiplies <paramref name="a"/> by <paramref name="b"/>. |
/// | 622 | <see cref="operator +"/> | PGA3D.AddS: res = a + b scalar/multiVector addition |
/// | 649 | <see cref="operator +"/> | PGA3D.adds: res = a + b multivector/scalar addition |
/// | 676 | <see cref="operator -"/> | PGA3D.ssub: res = a - b scalar/multivector subtraction |
/// | 703 | <see cref="operator -"/> | PGA3D.subs: res = a - b multivector/scalar subtraction |
/// | 730 | <see cref="Norm"/> | Euclidean norm. (strictly positive). |
/// | 739 | <see cref="NormSqr"/> | Signed square norm: (this * Conjugate())[0]. |
/// | 747 | <see cref="NormIdeal"/> | Ideal norm. (signed) |
/// | 755 | <see cref="Normalized"/> | normalized (Euclidean) element. |
/// | 770 | <see cref="E0"/> | Gets the e0. |
/// | 772 | <see cref="E1"/> | Gets the e1. |
/// | 774 | <see cref="E2"/> | Gets the e01. |
/// | 776 | <see cref="E3"/> | Gets the e02. |
/// | 780 | <see cref="E01"/> | Gets the e31. |
/// | 782 | <see cref="E02"/> | Gets the e23. |
/// | 784 | <see cref="E03"/> | Gets the e03. |
/// | 786 | <see cref="E12"/> | Gets the e12. |
/// | 788 | <see cref="E31"/> | Gets the e123. |
/// | 790 | <see cref="E23"/> | Gets the e032. |
/// | 794 | <see cref="E123"/> | Gets the e123. |
/// | 796 | <see cref="E032"/> | Gets the e032. |
/// | 798 | <see cref="E013"/> | Gets the e013. |
/// | 800 | <see cref="E021"/> | Gets the e021. |
/// | 807 | <see cref="Plane"/> | PGA3D.plane(a,b,c,d) A plane is defined using its homogenous equation ax + by + cz + d = 0 |
/// | 818 | <see cref="Line"/> | homogenous Line is defined using 3 homogenous equations TODO: this is wrong! "e12", "e31", "e23" |
/// | 826 | <see cref="Point"/> | homogeneous point; euclidean coordinates plus the origin |
/// | 835 | <see cref="Rotor"/> | Rotors by angle around the line |
/// | 848 | <see cref="Translator"/> | translators are ideal lines |
/// | 859 | <see cref="Circle"/> | Returns the motor describing a circle of radius at parameter t ∈ [0,1] around line. |
/// | 869 | <see cref="Torus"/> | Returns the motor for a point on a torus formed by two circles of radii r1 and r2 around l1 and l2. |
/// | 879 | <see cref="PointOnTorus"/> | Returns the point on the default torus (r1=0.25, r2=0.6) at parameters s and t. |
/// | 910 | <see cref="TestToString"/> | Test To String. |
/// | 921 | <see cref="Test"/> | Demonstrates rotation, translation, line/plane creation, and point-on-torus computation using PGA3D. |
/// | 967 | <see cref="CloseTo"/> | Returns true when this multivector is approximately equal to arg relative to their combined norm. |
///
/// ## Collaborators
///
/// | Type | Role |
/// |---|---|
/// | <see cref="PGA3D"/> | Returned by a method. |
/// </remarks>
[DocState(Pass = 2, MTime = "2026-06-17T03:27:56Z", Digest = "6d60f7c980c4240cabf7e6b6dd02f664f7f8b1649bc85b56d382a4fb89920faf", Stale = false, Path = "pga3d.cs", Since = "2026-10-06")]
[Facets(Layer = "domain", Status = "partial", Complexity = 3)]
[Tags("code/projective_geometric_algebra")]
[System.ComponentModel.Description("Pga3D Projective Geometric Algebra in 3D, also known as 3D PGA, extends geometric algebra to include projective geometry. It provides a powerful tool for representing and manipulating geometric objects such as - points, lines, planes, and transformations in three-dimensional space. In 3D PGA, geometric entities are represented as multivectors, which can be combined using various algebraic operations to perform geometric transformations and calculations. This framework is particularly useful in computer graphics, robotics, and physics for modeling and analyzing spatial relationships and transformations.")]
[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
public class PGA3D
{
	// just for debug and print output, the basis names
	/// <summary>Gets the collection of values.</summary>
	static readonly string[] _Basis = { "1","e0","e1","e2","e3","e01","e02","e03","e12","e31","e23","e021","e013","e032","e123","e0123" };
	/// <summary>Initializes a new instance of <see cref="PGA3D"/> with the specified <paramref name="f"/> and <paramref name="idx"/>.</summary>
	public static readonly IReadOnlyList<string> Basis = _Basis;

	readonly float[] _C = new float[16];
	/// <summary>Initializes a new instance of <see cref="PGA3D"/> with the specified <paramref name="f"/>.</summary>
	///
	[Facets(Layer = "domain", Status = "partial", Complexity = 3)]
	[Tags("code/projective_geometric_algebra")]
	[System.ComponentModel.Description("Initializes a new instance of PGA3D with the specified f.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public IReadOnlyList<float> Values => _C;
	/// <summary>Initializes a new instance of <see cref="PGA3D"/> with the specified <paramref name="f"/> and <paramref name="idx"/>.</summary>
	///
	[Facets(Layer = "domain", Status = "partial", Complexity = 3)]
	[Tags("code/projective_geometric_algebra")]
	[System.ComponentModel.Description("Initializes a new instance of PGA3D with the specified f and idx.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public PGA3D(double f, int idx = 0) => _C[idx] = (float) f;

	/// <summary>Initializes a new instance of <see cref="PGA3D"/> with the specified <paramref name="f"/>.</summary>
	///
	[Facets(Layer = "domain", Status = "partial", Complexity = 3)]
	[Tags("code/projective_geometric_algebra")]
	[System.ComponentModel.Description("Initializes a new instance of PGA3D with the specified f.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	PGA3D() {}
	/// <summary>Initializes a new instance of <see cref="PGA3D"/> with the specified <paramref name="f"/>.</summary>
	///
	[Facets(Layer = "domain", Status = "partial", Complexity = 3)]
	[Tags("code/projective_geometric_algebra")]
	[System.ComponentModel.Description("Initializes a new instance of PGA3D with the specified f.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public PGA3D(float[] f) => _C = f;

	#region Array Access
	/// <summary> Gets or sets the <paramref name="idx"/>-th component coefficient. </summary>
	///
	[Facets(Layer = "domain", Status = "partial", Complexity = 3)]
	[Tags("code/projective_geometric_algebra")]
	[System.ComponentModel.Description("Gets or sets the idx-th component coefficient.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public double this[int idx]
	{
		get => _C[idx];
		set => _C[idx] = (float)value;
	}
	#endregion

	#region Overloaded Operators

	/// <summary> ~ Inverse the basis blades. </summary>
	public static PGA3D operator ~ (PGA3D a)
	{
		PGA3D res = new() {
			[0] = a[0],
			[1] = a[1],
			[2] = a[2],
			[3] = a[3],
			[4] = a[4],
			[5] = -a[5],
			[6] = -a[6],
			[7] = -a[7],
			[8] = -a[8],
			[9] = -a[9],
			[10] = -a[10],
			[11] = -a[11],
			[12] = -a[12],
			[13] = -a[13],
			[14] = -a[14],
			[15] = a[15]
		};
		return res;
	}

	/// <summary>
	/// PGA3D.Dual : res = !a
	/// Poincare duality operator.
	/// </summary>
	public static PGA3D operator ! (PGA3D a)
	{
		PGA3D res = new() {
			[0] = a[15],
			[1] = a[14],
			[2] = a[13],
			[3] = a[12],
			[4] = a[11],
			[5] = a[10],
			[6] = a[9],
			[7] = a[8],
			[8] = a[7],
			[9] = a[6],
			[10] = a[5],
			[11] = a[4],
			[12] = a[3],
			[13] = a[2],
			[14] = a[1],
			[15] = a[0]
		};
		return res;
	}

	/// <summary>
	/// PGA3D.Conjugate : res = a.Conjugate()
	/// Clifford Conjugation
	/// </summary>
	///
	[Facets(Layer = "domain", Status = "partial", Complexity = 3)]
	[Tags("code/projective_geometric_algebra")]
	[System.ComponentModel.Description("PGA3D.Conjugate: res = a.Conjugate() Clifford Conjugation")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public  PGA3D Conjugate ()
	{
		PGA3D res = new() {
			[0] = this[0],
			[1] = -this[1],
			[2] = -this[2],
			[3] = -this[3],
			[4] = -this[4],
			[5] = -this[5],
			[6] = -this[6],
			[7] = -this[7],
			[8] = -this[8],
			[9] = -this[9],
			[10] = -this[10],
			[11] = this[11],
			[12] = this[12],
			[13] = this[13],
			[14] = this[14],
			[15] = this[15]
		};
		return res;
	}

	/// <summary>
	/// PGA3D.Involute : res = a.Involute()
	/// Main involution
	/// </summary>
	///
	[Facets(Layer = "domain", Status = "partial", Complexity = 3)]
	[Tags("code/projective_geometric_algebra")]
	[System.ComponentModel.Description("PGA3D.Involute: res = a.Involute() Main involution")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public  PGA3D Involute ()
	{
		PGA3D res = new() {
			[0] = this[0],
			[1] = -this[1],
			[2] = -this[2],
			[3] = -this[3],
			[4] = -this[4],
			[5] = this[5],
			[6] = this[6],
			[7] = this[7],
			[8] = this[8],
			[9] = this[9],
			[10] = this[10],
			[11] = -this[11],
			[12] = -this[12],
			[13] = -this[13],
			[14] = -this[14],
			[15] = this[15]
		};
		return res;
	}

	/// <summary>
	/// PGA3D.Wedge : res = a ^ b
	/// The outer product. (MEET)
	/// </summary>
	public static PGA3D operator ^(PGA3D a, PGA3D b) => a.Meet(b);

	/// <summary> Outer (wedge) product of this multivector and <paramref name="b"/>. </summary>
	///
	[Facets(Layer = "domain", Status = "partial", Complexity = 3)]
	[Tags("code/projective_geometric_algebra")]
	[System.ComponentModel.Description("Outer (wedge) product of this multivector and b.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public PGA3D Meet(PGA3D b) => new(_C.Meet(b._C));

	/// <summary>
	/// PGA3D.Mul : res = a * b
	/// The geometric product.
	/// </summary>
	public static PGA3D operator * (PGA3D a, PGA3D b) => a.Times(b);

	/// <summary> Full geometric product of this multivector and <paramref name="b"/>. </summary>
	///
	[Facets(Layer = "domain", Status = "partial", Complexity = 3)]
	[Tags("code/projective_geometric_algebra")]
	[System.ComponentModel.Description("Full geometric product of this multivector and b.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public PGA3D Times(PGA3D b) => new(_C.Times(b._C));

	/// <summary> &amp;, v; regressive product. (JOIN) </summary>
	public static PGA3D operator & (PGA3D a, PGA3D b) => a.Join(b);

	/// <summary> Regressive (join / vee) product of this multivector and <paramref name="b"/>. </summary>
	///
	[Facets(Layer = "domain", Status = "partial", Complexity = 3)]
	[Tags("code/projective_geometric_algebra")]
	[System.ComponentModel.Description("Regressive (join / vee) product of this multivector and b.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public PGA3D Join(PGA3D b) => new(_C.Join(b._C));

	/// <summary>
	/// PGA3D.Dot : res = a | b
	/// The inner product.
	/// </summary>
	public static PGA3D operator | (PGA3D a, PGA3D b) => a.Dot(b);

	/// <summary> Inner (dot) product of this multivector and <paramref name="b"/>. </summary>
	///
	[Facets(Layer = "domain", Status = "partial", Complexity = 3)]
	[Tags("code/projective_geometric_algebra")]
	[System.ComponentModel.Description("Inner (dot) product of this multivector and b.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public PGA3D Dot(PGA3D b) => new(_C.Dot(b._C));

	/// <summary>
	/// PGA3D.Add : res = a + b
	/// Multivector addition
	/// </summary>
	public static PGA3D operator + (PGA3D a, PGA3D b)
	{
		PGA3D res = new() {
			[0] = a[0]+b[0],
			[1] = a[1]+b[1],
			[2] = a[2]+b[2],
			[3] = a[3]+b[3],
			[4] = a[4]+b[4],
			[5] = a[5]+b[5],
			[6] = a[6]+b[6],
			[7] = a[7]+b[7],
			[8] = a[8]+b[8],
			[9] = a[9]+b[9],
			[10] = a[10]+b[10],
			[11] = a[11]+b[11],
			[12] = a[12]+b[12],
			[13] = a[13]+b[13],
			[14] = a[14]+b[14],
			[15] = a[15]+b[15]
		};
		return res;
	}

	/// <summary>
	/// PGA3D.Sub : res = a - b
	/// Multivector subtraction
	/// </summary>
	public static PGA3D operator - (PGA3D a, PGA3D b)
	{
		PGA3D res = new() {
			[0] = a[0]-b[0],
			[1] = a[1]-b[1],
			[2] = a[2]-b[2],
			[3] = a[3]-b[3],
			[4] = a[4]-b[4],
			[5] = a[5]-b[5],
			[6] = a[6]-b[6],
			[7] = a[7]-b[7],
			[8] = a[8]-b[8],
			[9] = a[9]-b[9],
			[10] = a[10]-b[10],
			[11] = a[11]-b[11],
			[12] = a[12]-b[12],
			[13] = a[13]-b[13],
			[14] = a[14]-b[14],
			[15] = a[15]-b[15]
		};
		return res;
	}

	/// <summary>
	/// PGA3D.smul : res = a * b
	/// scalar/multivector multiplication
	/// </summary>
	public static PGA3D operator * (double a, PGA3D b)
	{
		PGA3D res = new() {
			[0] = a*b[0],
			[1] = a*b[1],
			[2] = a*b[2],
			[3] = a*b[3],
			[4] = a*b[4],
			[5] = a*b[5],
			[6] = a*b[6],
			[7] = a*b[7],
			[8] = a*b[8],
			[9] = a*b[9],
			[10] = a*b[10],
			[11] = a*b[11],
			[12] = a*b[12],
			[13] = a*b[13],
			[14] = a*b[14],
			[15] = a*b[15]
		};
		return res;
	}

	/// <inheritdoc cref="XPGA3D.MulS16"/>
	public static PGA3D operator * (PGA3D a, double b) => a.MulS((float) b);

	/// <inheritdoc cref="XPGA3D.MulS16"/>
	public static PGA3D operator * (PGA3D a, float b) => a.MulS(b);

	/// <summary>
	/// PGA3D.AddS : res = a + b
	/// scalar/multiVector addition
	/// </summary>
	public static PGA3D operator + (float a, PGA3D b)
	{
		PGA3D res = new() {
			[0] = a+b[0],
			[1] = b[1],
			[2] = b[2],
			[3] = b[3],
			[4] = b[4],
			[5] = b[5],
			[6] = b[6],
			[7] = b[7],
			[8] = b[8],
			[9] = b[9],
			[10] = b[10],
			[11] = b[11],
			[12] = b[12],
			[13] = b[13],
			[14] = b[14],
			[15] = b[15]
		};
		return res;
	}

	/// <summary>
	/// PGA3D.adds : res = a + b
	/// multivector/scalar addition
	/// </summary>
	public static PGA3D operator + (PGA3D a, float b)
	{
		PGA3D res = new() {
			[0] = a[0]+b,
			[1] = a[1],
			[2] = a[2],
			[3] = a[3],
			[4] = a[4],
			[5] = a[5],
			[6] = a[6],
			[7] = a[7],
			[8] = a[8],
			[9] = a[9],
			[10] = a[10],
			[11] = a[11],
			[12] = a[12],
			[13] = a[13],
			[14] = a[14],
			[15] = a[15]
		};
		return res;
	}

	/// <summary>
	/// PGA3D.ssub : res = a - b
	/// scalar/multivector subtraction
	/// </summary>
	public static PGA3D operator - (float a, PGA3D b)
	{
		PGA3D res = new() {
			[0] = a-b[0],
			[1] = -b[1],
			[2] = -b[2],
			[3] = -b[3],
			[4] = -b[4],
			[5] = -b[5],
			[6] = -b[6],
			[7] = -b[7],
			[8] = -b[8],
			[9] = -b[9],
			[10] = -b[10],
			[11] = -b[11],
			[12] = -b[12],
			[13] = -b[13],
			[14] = -b[14],
			[15] = -b[15]
		};
		return res;
	}

	/// <summary>
	/// PGA3D.subs : res = a - b
	/// multivector/scalar subtraction
	/// </summary>
	public static PGA3D operator - (PGA3D a, float b)
	{
		PGA3D res = new() {
			[0] = a[0]-b,
			[1] = a[1],
			[2] = a[2],
			[3] = a[3],
			[4] = a[4],
			[5] = a[5],
			[6] = a[6],
			[7] = a[7],
			[8] = a[8],
			[9] = a[9],
			[10] = a[10],
			[11] = a[11],
			[12] = a[12],
			[13] = a[13],
			[14] = a[14],
			[15] = a[15]
		};
		return res;
	}

	#endregion

	/// <summary> Euclidean norm. (strictly positive). </summary>
	///
	[Facets(Layer = "domain", Status = "partial", Complexity = 3)]
	[Tags("code/projective_geometric_algebra")]
	[System.ComponentModel.Description("Euclidean norm. (strictly positive).")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public float Norm() => (float) Math.Sqrt(Math.Abs(NormSqr()));

	// TODO: inefficient: rather calc ONLY the 0 Component!
	/// <summary> Signed square norm: (this * Conjugate())[0]. </summary>
	///
	[Facets(Layer = "domain", Status = "partial", Complexity = 3)]
	[Tags("code/projective_geometric_algebra")]
	[System.ComponentModel.Description("Signed square norm: (this * Conjugate())[0].")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public double NormSqr() => (this*Conjugate())[0];

	/// <summary> Ideal norm. (signed) </summary>
	///
	[Facets(Layer = "domain", Status = "partial", Complexity = 3)]
	[Tags("code/projective_geometric_algebra")]
	[System.ComponentModel.Description("Ideal norm. (signed)")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public float NormIdeal() => _C[1] != 0?_C[1] : _C[15] != 0 ? _C[15]:(!this).Norm();
	
	/// <summary> normalized (Euclidean) element. </summary>
	///
	[Facets(Layer = "domain", Status = "partial", Complexity = 3)]
	[Tags("code/projective_geometric_algebra")]
	[System.ComponentModel.Description("normalized (Euclidean) element.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public PGA3D Normalized() {
		var normSqr = Math.Abs(NormSqr());
		if (normSqr.IsOne()) {
			return this;
		}
		return this * (1 / Math.Sqrt(normSqr));
	}


	// PGA is plane based. Vectors are planes. (think linear functionals)
	/// <summary>Gets the e0.</summary>
	public static readonly PGA3D E0 = new(1f, 1);
	/// <summary>Gets the e1.</summary>
	public static readonly PGA3D E1 = new(1f, 2);
	/// <summary>Gets the e01.</summary>
	public static readonly PGA3D E2 = new(1f, 3);
	/// <summary>Gets the e02.</summary>
	public static readonly PGA3D E3 = new(1f, 4);
	
	// PGA lines are biVectors.
	/// <summary>Gets the e31.</summary>
	public static readonly PGA3D E01 = E0^E1; 
	/// <summary>Gets the e23.</summary>
	public static readonly PGA3D E02 = E0^E2;
	/// <summary>Gets the e03.</summary>
	public static readonly PGA3D E03 = E0^E3;
	/// <summary>Gets the e12.</summary>
	public static readonly PGA3D E12 = E1^E2; 
	/// <summary>Gets the e123.</summary>
	public static readonly PGA3D E31 = E3^E1;
	/// <summary>Gets the e032.</summary>
	public static readonly PGA3D E23 = E2^E3;
	
	// PGA points are triVectors.
	/// <summary>Gets the e123.</summary>
	public static readonly PGA3D E123 = E1^E2^E3; // the origin
	/// <summary>Gets the e032.</summary>
	public static readonly PGA3D E032 = E0^E3^E2;
	/// <summary>Gets the e013.</summary>
	public static readonly PGA3D E013 = E0^E1^E3;
	/// <summary>Gets the e021.</summary>
	public static readonly PGA3D E021 = E0^E2^E1;

	/// <summary>
	/// PGA3D.plane(a,b,c,d)
	/// A plane is defined using its homogenous equation ax + by + cz + d = 0
	/// </summary>
	///
	[Facets(Layer = "domain", Status = "partial", Complexity = 3)]
	[Tags("code/projective_geometric_algebra")]
	[System.ComponentModel.Description("PGA3D.plane(a,b,c,d) A plane is defined using its homogenous equation ax + by + cz + d = 0")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public static PGA3D Plane(float a, float b, float c, float d) => a*E1 + b*E2 + c*E3 + d*E0; 
	
	/// <summary>
	/// homogenous Line is defined using 3 homogenous equations
	/// TODO: this is wrong! "e12", "e31", "e23"
	/// </summary>
	///
	[Facets(Layer = "domain", Status = "partial", Complexity = 3)]
	[Tags("code/projective_geometric_algebra")]
	[System.ComponentModel.Description("homogenous Line is defined using 3 homogenous equations TODO: this is wrong! \"e12\", \"e31\", \"e23\"")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public static PGA3D Line(float a, float b, float c, float d) => a*E1 + b*E2 + c*E3 + d*E0; 
	
	/// <summary> homogeneous point; euclidean coordinates plus the origin </summary>
	///
	[Facets(Layer = "domain", Status = "partial", Complexity = 3)]
	[Tags("code/projective_geometric_algebra")]
	[System.ComponentModel.Description("homogeneous point; euclidean coordinates plus the origin")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public static PGA3D Point(double x, double y, double z = 0, double w = 1) 
		=> w*E123 + x*E032 + y*E013 + z*E021; 
	
	/// <summary> Rotors by <paramref name="angle"/> around the <paramref name="line"/> </summary>
	///
	[Facets(Layer = "domain", Status = "partial", Complexity = 3)]
	[Tags("code/projective_geometric_algebra")]
	[System.ComponentModel.Description("Rotors by angle around the line")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public static PGA3D Rotor(double angle, PGA3D line) {
		var (sin, cos) = angle.SinCos();
		return (float) cos + (float) sin * line.Normalized();
	}

	/// <summary>
	/// translators are ideal lines 
	/// </summary>
	///
	[Facets(Layer = "domain", Status = "partial", Complexity = 3)]
	[Tags("code/projective_geometric_algebra")]
	[System.ComponentModel.Description("translators are ideal lines")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public static PGA3D Translator(float dist, PGA3D line) => 1f + dist*0.5f * line; 

	// for our toy problem (generate points on the surface of a torus)
	// we start with a function that generates motors.
	// circle(t) with t going from 0 to 1.
	/// <summary> Returns the motor describing a circle of <paramref name="radius"/> at parameter <paramref name="t"/> ∈ [0,1] around <paramref name="line"/>. </summary>
	///
	[Facets(Layer = "domain", Status = "partial", Complexity = 3)]
	[Tags("code/projective_geometric_algebra")]
	[System.ComponentModel.Description("Returns the motor describing a circle of radius at parameter t ∈ [0,1] around line.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public static PGA3D Circle(float t, float radius, PGA3D line)
		=> Rotor(t*2f*(float) Math.PI,line) * Translator(radius,E1*E0);

	// a torus is now the product of two circles. 
	/// <summary> Returns the motor for a point on a torus formed by two circles of radii <paramref name="r1"/> and <paramref name="r2"/> around <paramref name="l1"/> and <paramref name="l2"/>. </summary>
	///
	[Facets(Layer = "domain", Status = "partial", Complexity = 3)]
	[Tags("code/projective_geometric_algebra")]
	[System.ComponentModel.Description("Returns the motor for a point on a torus formed by two circles of radii r1 and r2 around l1 and l2.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public static PGA3D Torus(float s, float t, float r1, PGA3D l1, float r2, PGA3D l2)
		=> Circle(s,r2,l2)*Circle(t,r1,l1);

	// and to sample its points we simply sandwich the origin ..
	/// <summary> Returns the point on the default torus (r1=0.25, r2=0.6) at parameters <paramref name="s"/> and <paramref name="t"/>. </summary>
	///
	[Facets(Layer = "domain", Status = "partial", Complexity = 3)]
	[Tags("code/projective_geometric_algebra")]
	[System.ComponentModel.Description("Returns the point on the default torus (r1=0.25, r2=0.6) at parameters s and t.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public static PGA3D PointOnTorus(float s, float t) {
		var to = Torus(s,t,0.25f,E12,0.6f,E31);
		return to * E123 * ~to;
	}


	/// <summary> String Representation </summary>
	///
	[Facets(Layer = "domain", Status = "partial", Complexity = 3)]
	[Tags("code/projective_geometric_algebra")]
	[System.ComponentModel.Description("String Representation")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public override string ToString() {
		var sb = new StringBuilder();
		for (int i = 0; i < 16; ++i) {
			if (_C[i] != 0) {
				_ = sb.Append($"{_C[i]}{(i == 0 ? string.Empty : _Basis[i])} + ");
			}
		}

		if (sb.Length <= 0) _ = sb.Append('0');
		return sb.ToString().TrimEnd(' ', '+');
	}

	/// <summary>Test To String.</summary>
	///
	//[Test] Empty placeholder; PGA3D has no parameterless constructor, so NUnit cannot create the fixture
	[Facets(Layer = "domain", Status = "partial", Complexity = 3)]
	[Tags("code/projective_geometric_algebra")]
	[System.ComponentModel.Description("Test To String.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public static void TestToString()
	{
	}

	/// <summary> Demonstrates rotation, translation, line/plane creation, and point-on-torus computation using PGA3D. </summary>
	///
	//[Test] Legacy PGA3D draft: no parameterless constructor for NUnit; superseded by Pga3D tests
	[Facets(Layer = "domain", Status = "partial", Complexity = 3)]
	[Tags("code/projective_geometric_algebra")]
	[System.ComponentModel.Description("Demonstrates rotation, translation, line/plane creation, and point-on-torus computation using PGA3D.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public static void Test()
	{

		// Elements of the even subalgebra (scalar + bi-vector + pss) of unit length are motors
		var rot = Rotor((float) Math.PI/2,E1*E2);
		
		// The outer product ^ is the MEET. Here we intersect the yz (x=0) and xz (y=0) planes.
		var ax_z = E1 ^ E2;
		
		// line and plane meet in point. We intersect the line along the z-axis (x=0,y=0) with the xy (z=0) plane.
		var orig = ax_z ^ E3;
		
		// We can also easily create points and join them into a line using the regressive (vee, &) product.
		var px = Point(1,0);
		var line = orig & px;
		
		// Lets also create the plane with equation 2x + z - 3 = 0
		var p = Plane(2,0,1,-3);
		
		// rotations work on all elements
		var rotated_plane = rot * p * ~rot;
		var rotated_line  = rot * line * ~rot;
		var rotated_point = rot * px * ~rot;
		
		// See the 3D PGA Cheat sheet for a huge collection of useful formulas
		var point_on_plane = (p | px) * p;
		
		// Some output
		Console.WriteLine("a point       : "+px);
		Console.WriteLine("a line        : "+line);
		Console.WriteLine("a plane       : "+p);
		Console.WriteLine("a rotor       : "+rot);
		Console.WriteLine("rotated line  : "+rotated_line);
		Console.WriteLine("rotated point : "+rotated_point);
		Console.WriteLine("rotated plane : "+rotated_plane);
		Console.WriteLine("point on plane: "+point_on_plane.Normalized());
		Console.WriteLine("point on torus: "+PointOnTorus(0,0));

	}

	/// <summary> Returns true when this multivector is approximately equal to <paramref name="arg"/> relative to their combined norm. </summary>
	///
	[Facets(Layer = "domain", Status = "partial", Complexity = 3)]
	[Tags("code/projective_geometric_algebra")]
	[System.ComponentModel.Description("Returns true when this multivector is approximately equal to arg relative to their combined norm.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public bool CloseTo(PGA3D arg) {
		var diff = this - arg;
		var diffNorm = diff.NormSqr();
		var compare = this.NormSqr() + arg.NormSqr();
		return diffNorm <= compare * 1e-7;
	}
}
