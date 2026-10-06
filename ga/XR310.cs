using System.Collections.Generic;
using NUnit.Framework;
using org.SpocWeb.root.extensions;
using org.SpocWeb.root.extensions.maths;
using org.SpocWeb.root.Attributes;

namespace org.SpocWeb.root.maths.pga.ga;

// ReSharper disable once InconsistentNaming
/// <summary> Static extension and utility methods for the R310 G(3,1,0) SpaceTime / 2D Conformal Geometric Algebra
/// multivector type. </summary>
/// <remarks>
/// ## Public Methods
///
/// | Line | Method | Description |
/// |--:|---|---|
/// | 39 | <see cref="Neg16"/> | Negates all sixteen components of a 16-element multivector coordinate array. |
/// | 50 | <see cref="Dual16R"/> | ! relativistic R3+iT Poincare Dual. |
/// | 64 | <see cref="CliffCjg16R"/> | R3+iT relativistic Clifford Conjugation |
/// | 78 | <see cref="Involute"/> | R310.Involute: res = a.Involute() Main involution |
/// | 91 | <see cref="NormSqr16R310Q"/> | Norm Sqr16 R310 Q. |
/// | 99 | <see cref="NormSqr16R310"/> | Norm Sqr16 R310. |
/// | 111 | <see cref="Times16R"/> | * Mul/Times relativistic geometric product. |
/// | 136 | <see cref="Wedge16R"/> | ^ Wedge/MEET; relativistic outer product |
/// | 161 | <see cref="Join16R"/> | v,&amp;; JOIN/Vee; relativistic regressive product. |
/// | 192 | <see cref="Dot16R"/> | | Dot; relativistic inner product. |
/// </remarks>
///
[DocState(Pass = 2, MTime = "2026-05-24T15:36:37Z", Digest = "f3e8aee6f0cf8b04f3b3a09bc89dfd510ef6f16a5a39c139dadd48a89a279256", Stale = false, Path = "ga/XR310.cs", Since = "2026-10-06")]
[Facets(Layer = "domain", Status = "stable", Complexity = 1)]
[Tags("code/extension_method", "code/conformal_geometric_algebra")]
[System.ComponentModel.Description("Static extension and utility methods for the R310 G(3,1,0) SpaceTime / 2D Conformal Geometric Algebra multivector type.")]
[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
public static partial class XR310
{

	/// <summary> Negates all sixteen components of a 16-element multivector coordinate array. </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 1)]
	[Tags("code/extension_method", "code/negation")]
	[System.ComponentModel.Description("Negates all sixteen components of a 16-element multivector coordinate array.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public static float[] Neg16(this IReadOnlyList<float> c) => new[] {
		-c[0], -c[1], -c[2], -c[3], -c[4], -c[5], -c[6], -c[7],
		-c[8], -c[9], -c[10], -c[11], -c[12], -c[13], -c[14], -c[15]
	};

	/// <summary> ! relativistic R3+iT Poincare Dual. </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 1)]
	[Tags("code/extension_method", "code/clifford_algebra")]
	[System.ComponentModel.Description("! relativistic R3+iT Poincare Dual.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public static float[] Dual16R (this float[] a) => new [] {-a[15], -a[14],
			a[13], -a[12], -a[11],
			a[10], -a[9], -a[8],
			a[7], a[6], -a[5],
			a[4], a[3], -a[2],
			a[1], a[0]
		};

	/// <summary> R3+iT relativistic Clifford Conjugation </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 1)]
	[Tags("code/extension_method", "code/conjugate")]
	[System.ComponentModel.Description("R3+iT relativistic Clifford Conjugation")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public static float[] CliffCjg16R (this float[] a) => new [] {a[0],
			-a[1], -a[2], -a[3], -a[4], -a[5], -a[6], -a[7], -a[8], -a[9], -a[10],
			a[11], a[12], a[13], a[14], a[15]
		};

	/// <summary>
	/// R310.Involute : res = a.Involute()
	/// Main involution
	/// </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 1)]
	[Tags("code/extension_method", "code/clifford_algebra")]
	[System.ComponentModel.Description("R310.Involute: res = a.Involute() Main involution")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public static float[] Involute (this float[] a) => new [] {a[0],
			-a[1], -a[2], -a[3], -a[4],
			a[5], a[6], a[7], a[8], a[9], a[10],
			-a[11], -a[12], -a[13], -a[14],
			a[15]
		};

	/// <summary>Norm Sqr16 R310 Q.</summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 1)]
	[Tags("code/norm_calculation")]
	[System.ComponentModel.Description("Norm Sqr16 R310 Q.")]
	[TestCase(new []{-1,-2,-3,-4,-5,-6,-7,-8,1,2,3,4,5,6,7,8f}, ExpectedResult = 36)]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public static float NormSqr16R310Q(IReadOnlyList<float> c) => c.Times16R(c.CliffCjg16())[0];
	/// <summary>Norm Sqr16 R310.</summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 1)]
	[Tags("code/extension_method", "code/norm_calculation")]
	[System.ComponentModel.Description("Norm Sqr16 R310.")]
	[TestCase(new []{-1,-2,-3,-4,-5,-6,-7,-8,1,2,3,4,5,6,7,8f}, ExpectedResult = 36)]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public static float NormSqr16R310(this IReadOnlyList<float> a) => a[0].Sqr()
		- a[1].Sqr() - a[2].Sqr() - a[3].Sqr() + a[4].Sqr() + a[5].Sqr()
		+ a[6].Sqr() - a[7].Sqr() + a[8].Sqr() - a[9].Sqr() - a[10].Sqr()
		- a[11].Sqr() + a[12].Sqr() + a[13].Sqr() + a[14].Sqr() - a[15].Sqr();

	/// <summary> * Mul/Times relativistic geometric product. </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 1)]
	[Tags("code/extension_method", "code/geometric_product")]
	[System.ComponentModel.Description("* Mul/Times relativistic geometric product.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public static float[] Times16R(this IReadOnlyList<float> a, IReadOnlyList<float>  b) => new [] {
			b[0]*a[0]+b[1]*a[1]+b[2]*a[2]+b[3]*a[3]-b[4]*a[4]-b[5]*a[5]-b[6]*a[6]+b[7]*a[7]-b[8]*a[8]+b[9]*a[9]+b[10]*a[10]-b[11]*a[11]+b[12]*a[12]+b[13]*a[13]+b[14]*a[14]-b[15]*a[15],
			b[1]*a[0]+b[0]*a[1]-b[5]*a[2]-b[6]*a[3]+b[7]*a[4]+b[2]*a[5]+b[3]*a[6]-b[4]*a[7]-b[11]*a[8]+b[12]*a[9]+b[13]*a[10]-b[8]*a[11]+b[9]*a[12]+b[10]*a[13]-b[15]*a[14]+b[14]*a[15],
			b[2]*a[0]+b[5]*a[1]+b[0]*a[2]-b[8]*a[3]+b[9]*a[4]-b[1]*a[5]+b[11]*a[6]-b[12]*a[7]+b[3]*a[8]-b[4]*a[9]+b[14]*a[10]+b[6]*a[11]-b[7]*a[12]+b[15]*a[13]+b[10]*a[14]-b[13]*a[15],
			b[3]*a[0]+b[6]*a[1]+b[8]*a[2]+b[0]*a[3]+b[10]*a[4]-b[11]*a[5]-b[1]*a[6]-b[13]*a[7]-b[2]*a[8]-b[14]*a[9]-b[4]*a[10]-b[5]*a[11]-b[15]*a[12]-b[7]*a[13]-b[9]*a[14]+b[12]*a[15],
			b[4]*a[0]+b[7]*a[1]+b[9]*a[2]+b[10]*a[3]+b[0]*a[4]-b[12]*a[5]-b[13]*a[6]-b[1]*a[7]-b[14]*a[8]-b[2]*a[9]-b[3]*a[10]-b[15]*a[11]-b[5]*a[12]-b[6]*a[13]-b[8]*a[14]+b[11]*a[15],
			b[5]*a[0]+b[2]*a[1]-b[1]*a[2]+b[11]*a[3]-b[12]*a[4]+b[0]*a[5]-b[8]*a[6]+b[9]*a[7]+b[6]*a[8]-b[7]*a[9]+b[15]*a[10]+b[3]*a[11]-b[4]*a[12]+b[14]*a[13]-b[13]*a[14]+b[10]*a[15],
			b[6]*a[0]+b[3]*a[1]-b[11]*a[2]-b[1]*a[3]-b[13]*a[4]+b[8]*a[5]+b[0]*a[6]+b[10]*a[7]-b[5]*a[8]-b[15]*a[9]-b[7]*a[10]-b[2]*a[11]-b[14]*a[12]-b[4]*a[13]+b[12]*a[14]-b[9]*a[15],
			b[7]*a[0]+b[4]*a[1]-b[12]*a[2]-b[13]*a[3]-b[1]*a[4]+b[9]*a[5]+b[10]*a[6]+b[0]*a[7]-b[15]*a[8]-b[5]*a[9]-b[6]*a[10]-b[14]*a[11]-b[2]*a[12]-b[3]*a[13]+b[11]*a[14]-b[8]*a[15],
			b[8]*a[0]+b[11]*a[1]+b[3]*a[2]-b[2]*a[3]-b[14]*a[4]-b[6]*a[5]+b[5]*a[6]+b[15]*a[7]+b[0]*a[8]+b[10]*a[9]-b[9]*a[10]+b[1]*a[11]+b[13]*a[12]-b[12]*a[13]-b[4]*a[14]+b[7]*a[15],
			b[9]*a[0]+b[12]*a[1]+b[4]*a[2]-b[14]*a[3]-b[2]*a[4]-b[7]*a[5]+b[15]*a[6]+b[5]*a[7]+b[10]*a[8]+b[0]*a[9]-b[8]*a[10]+b[13]*a[11]+b[1]*a[12]-b[11]*a[13]-b[3]*a[14]+b[6]*a[15],
			b[10]*a[0]+b[13]*a[1]+b[14]*a[2]+b[4]*a[3]-b[3]*a[4]-b[15]*a[5]-b[7]*a[6]+b[6]*a[7]-b[9]*a[8]+b[8]*a[9]+b[0]*a[10]-b[12]*a[11]+b[11]*a[12]+b[1]*a[13]+b[2]*a[14]-b[5]*a[15],
			b[11]*a[0]+b[8]*a[1]-b[6]*a[2]+b[5]*a[3]+b[15]*a[4]+b[3]*a[5]-b[2]*a[6]-b[14]*a[7]+b[1]*a[8]+b[13]*a[9]-b[12]*a[10]+b[0]*a[11]+b[10]*a[12]-b[9]*a[13]+b[7]*a[14]-b[4]*a[15],
			b[12]*a[0]+b[9]*a[1]-b[7]*a[2]+b[15]*a[3]+b[5]*a[4]+b[4]*a[5]-b[14]*a[6]-b[2]*a[7]+b[13]*a[8]+b[1]*a[9]-b[11]*a[10]+b[10]*a[11]+b[0]*a[12]-b[8]*a[13]+b[6]*a[14]-b[3]*a[15],
			b[13]*a[0]+b[10]*a[1]-b[15]*a[2]-b[7]*a[3]+b[6]*a[4]+b[14]*a[5]+b[4]*a[6]-b[3]*a[7]-b[12]*a[8]+b[11]*a[9]+b[1]*a[10]-b[9]*a[11]+b[8]*a[12]+b[0]*a[13]-b[5]*a[14]+b[2]*a[15],
			b[14]*a[0]+b[15]*a[1]+b[10]*a[2]-b[9]*a[3]+b[8]*a[4]-b[13]*a[5]+b[12]*a[6]-b[11]*a[7]+b[4]*a[8]-b[3]*a[9]+b[2]*a[10]+b[7]*a[11]-b[6]*a[12]+b[5]*a[13]+b[0]*a[14]-b[1]*a[15],
			b[15]*a[0]+b[14]*a[1]-b[13]*a[2]+b[12]*a[3]-b[11]*a[4]+b[10]*a[5]-b[9]*a[6]+b[8]*a[7]+b[7]*a[8]-b[6]*a[9]+b[5]*a[10]+b[4]*a[11]-b[3]*a[12]+b[2]*a[13]-b[1]*a[14]+b[0]*a[15]
		};

	/// <summary> ^ Wedge/MEET; relativistic outer product </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 1)]
	[Tags("code/extension_method", "code/outer_product")]
	[System.ComponentModel.Description("^ Wedge/MEET; relativistic outer product")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public static float[] Wedge16R(this IReadOnlyList<float> a, IReadOnlyList<float>  b) => new [] {
			b[0]*a[0],
			b[1]*a[0]+b[0]*a[1],
			b[2]*a[0]+b[0]*a[2],
			b[3]*a[0]+b[0]*a[3],
			b[4]*a[0]+b[0]*a[4],
			b[5]*a[0]+b[2]*a[1]-b[1]*a[2]+b[0]*a[5],
			b[6]*a[0]+b[3]*a[1]-b[1]*a[3]+b[0]*a[6],
			b[7]*a[0]+b[4]*a[1]-b[1]*a[4]+b[0]*a[7],
			b[8]*a[0]+b[3]*a[2]-b[2]*a[3]+b[0]*a[8],
			b[9]*a[0]+b[4]*a[2]-b[2]*a[4]+b[0]*a[9],
			b[10]*a[0]+b[4]*a[3]-b[3]*a[4]+b[0]*a[10],
			b[11]*a[0]+b[8]*a[1]-b[6]*a[2]+b[5]*a[3]+b[3]*a[5]-b[2]*a[6]+b[1]*a[8]+b[0]*a[11],
			b[12]*a[0]+b[9]*a[1]-b[7]*a[2]+b[5]*a[4]+b[4]*a[5]-b[2]*a[7]+b[1]*a[9]+b[0]*a[12],
			b[13]*a[0]+b[10]*a[1]-b[7]*a[3]+b[6]*a[4]+b[4]*a[6]-b[3]*a[7]+b[1]*a[10]+b[0]*a[13],
			b[14]*a[0]+b[10]*a[2]-b[9]*a[3]+b[8]*a[4]+b[4]*a[8]-b[3]*a[9]+b[2]*a[10]+b[0]*a[14],
			b[15]*a[0]+b[14]*a[1]-b[13]*a[2]+b[12]*a[3]-b[11]*a[4]+b[10]*a[5]-b[9]*a[6]+b[8]*a[7]+b[7]*a[8]-b[6]*a[9]+b[5]*a[10]+b[4]*a[11]-b[3]*a[12]+b[2]*a[13]-b[1]*a[14]+b[0]*a[15]
		};

	/// <summary> v,&amp;; JOIN/Vee; relativistic regressive product. </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 1)]
	[Tags("code/extension_method", "code/clifford_algebra")]
	[System.ComponentModel.Description("v,&amp;; JOIN/Vee; relativistic regressive product.")]
	[TestCase(new []{-1,-2,-3,-4,-5,-6,-7,-8,1,2,3,4,5,6,7,8f}, new []{1,2,3,4,5,6,7,8,1,2,3,4,5,6,7,8f}
		, ExpectedResult = new[]{-8, 0, 6, 12, 6, 0, 0, 0, 16, 32, 48, 64, 80, 96, 112, 64f})]
	[TestCase(new []{1,2,3,4,5,6,7,8,1,2,3,4,5,6,7,8f}, new []{-1,-2,-3,-4,-5,-6,-7,-8,1,2,3,4,5,6,7,8f}
		, ExpectedResult = new[]{ 8, 0, 6, 12, 6, 0, 0, 0, 16, 32, 48, 64, 80, 96, 112, 64f})]
	[TestCase(new []{1,2,3,4,5,6,7,8,-1,-2,-3,-4,-5,-6,-7,-8f}, new []{1,2,3,4,5,6,7,8,-1,-2,-3,-4,-5,-6,-7,-8f}
		, ExpectedResult = new[]{ -40, -98, -126, -150, -186, -96, -112, -128, 16, 32, 48, 64, 80, 96, 112, 64f})]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public static float[] Join16R(this IReadOnlyList<float> a, IReadOnlyList<float>  b) => new [] {
			1*(a[0]*b[15]+a[1]*b[14]*-1-a[2]*-1*b[13]+a[3]*b[12]*-1-a[4]*-1*b[11]+a[5]*b[10]-a[6]*-1*b[9]*-1+a[7]*b[8]+a[8]*b[7]-a[9]*-1*b[6]*-1+a[10]*b[5]+a[11]*b[4]*-1-a[12]*-1*b[3]+a[13]*b[2]*-1-a[14]*-1*b[1]+a[15]*b[0]),
			1*(a[1]*b[15]+a[5]*b[13]-a[6]*-1*b[12]*-1+a[7]*b[11]+a[11]*b[7]-a[12]*-1*b[6]*-1+a[13]*b[5]+a[15]*b[1]),
			-1*(a[2]*-1*b[15]+a[5]*b[14]*-1-a[8]*b[12]*-1+a[9]*-1*b[11]+a[11]*b[9]*-1-a[12]*-1*b[8]+a[14]*-1*b[5]+a[15]*b[2]*-1),
			1*(a[3]*b[15]+a[6]*-1*b[14]*-1-a[8]*b[13]+a[10]*b[11]+a[11]*b[10]-a[13]*b[8]+a[14]*-1*b[6]*-1+a[15]*b[3]),
			-1*(a[4]*-1*b[15]+a[7]*b[14]*-1-a[9]*-1*b[13]+a[10]*b[12]*-1+a[12]*-1*b[10]-a[13]*b[9]*-1+a[14]*-1*b[7]+a[15]*b[4]*-1),
			1*(a[5]*b[15]+a[11]*b[12]*-1-a[12]*-1*b[11]+a[15]*b[5]),
			-1*(a[6]*-1*b[15]+a[11]*b[13]-a[13]*b[11]+a[15]*b[6]*-1),
			1*(a[7]*b[15]+a[12]*-1*b[13]-a[13]*b[12]*-1+a[15]*b[7]),
			1*(a[8]*b[15]+a[11]*b[14]*-1-a[14]*-1*b[11]+a[15]*b[8]),
			-1*(a[9]*-1*b[15]+a[12]*-1*b[14]*-1-a[14]*-1*b[12]*-1+a[15]*b[9]*-1),
			1*(a[10]*b[15]+a[13]*b[14]*-1-a[14]*-1*b[13]+a[15]*b[10]),
			1*(a[11]*b[15]+a[15]*b[11]),
			-1*(a[12]*-1*b[15]+a[15]*b[12]*-1),
			1*(a[13]*b[15]+a[15]*b[13]),
			-1*(a[14]*-1*b[15]+a[15]*b[14]*-1),
			1*(a[15]*b[15]),
		};

	/// <summary> | Dot; relativistic inner product. </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 1)]
	[Tags("code/extension_method", "code/dot_product")]
	[System.ComponentModel.Description("| Dot; relativistic inner product.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public static float[] Dot16R(this IReadOnlyList<float> a, IReadOnlyList<float>  b) => new [] {
			b[0]*a[0]+b[1]*a[1]+b[2]*a[2]+b[3]*a[3]-b[4]*a[4]-b[5]*a[5]-b[6]*a[6]+b[7]*a[7]-b[8]*a[8]+b[9]*a[9]+b[10]*a[10]-b[11]*a[11]+b[12]*a[12]+b[13]*a[13]+b[14]*a[14]-b[15]*a[15],
			b[1]*a[0]+b[0]*a[1]-b[5]*a[2]-b[6]*a[3]+b[7]*a[4]+b[2]*a[5]+b[3]*a[6]-b[4]*a[7]-b[11]*a[8]+b[12]*a[9]+b[13]*a[10]-b[8]*a[11]+b[9]*a[12]+b[10]*a[13]-b[15]*a[14]+b[14]*a[15],
			b[2]*a[0]+b[5]*a[1]+b[0]*a[2]-b[8]*a[3]+b[9]*a[4]-b[1]*a[5]+b[11]*a[6]-b[12]*a[7]+b[3]*a[8]-b[4]*a[9]+b[14]*a[10]+b[6]*a[11]-b[7]*a[12]+b[15]*a[13]+b[10]*a[14]-b[13]*a[15],
			b[3]*a[0]+b[6]*a[1]+b[8]*a[2]+b[0]*a[3]+b[10]*a[4]-b[11]*a[5]-b[1]*a[6]-b[13]*a[7]-b[2]*a[8]-b[14]*a[9]-b[4]*a[10]-b[5]*a[11]-b[15]*a[12]-b[7]*a[13]-b[9]*a[14]+b[12]*a[15],
			b[4]*a[0]+b[7]*a[1]+b[9]*a[2]+b[10]*a[3]+b[0]*a[4]-b[12]*a[5]-b[13]*a[6]-b[1]*a[7]-b[14]*a[8]-b[2]*a[9]-b[3]*a[10]-b[15]*a[11]-b[5]*a[12]-b[6]*a[13]-b[8]*a[14]+b[11]*a[15],
			b[5]*a[0]+b[11]*a[3]-b[12]*a[4]+b[0]*a[5]+b[15]*a[10]+b[3]*a[11]-b[4]*a[12]+b[10]*a[15],
			b[6]*a[0]-b[11]*a[2]-b[13]*a[4]+b[0]*a[6]-b[15]*a[9]-b[2]*a[11]-b[4]*a[13]-b[9]*a[15],
			b[7]*a[0]-b[12]*a[2]-b[13]*a[3]+b[0]*a[7]-b[15]*a[8]-b[2]*a[12]-b[3]*a[13]-b[8]*a[15],
			b[8]*a[0]+b[11]*a[1]-b[14]*a[4]+b[15]*a[7]+b[0]*a[8]+b[1]*a[11]-b[4]*a[14]+b[7]*a[15],
			b[9]*a[0]+b[12]*a[1]-b[14]*a[3]+b[15]*a[6]+b[0]*a[9]+b[1]*a[12]-b[3]*a[14]+b[6]*a[15],
			b[10]*a[0]+b[13]*a[1]+b[14]*a[2]-b[15]*a[5]+b[0]*a[10]+b[1]*a[13]+b[2]*a[14]-b[5]*a[15],
			b[11]*a[0]+b[15]*a[4]+b[0]*a[11]-b[4]*a[15],
			b[12]*a[0]+b[15]*a[3]+b[0]*a[12]-b[3]*a[15],
			b[13]*a[0]-b[15]*a[2]+b[0]*a[13]+b[2]*a[15],
			b[14]*a[0]+b[15]*a[1]+b[0]*a[14]-b[1]*a[15],
			b[15]*a[0]+b[0]*a[15]
		};

}

