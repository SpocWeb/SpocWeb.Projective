using System.Collections.Generic;
using System.Numerics;
using org.SpocWeb.root.Attributes;

namespace org.SpocWeb.root.maths.pga;

/// <summary> Extension methods for <see cref="Motor3P"/> and <see cref="Reflector3P"/>
/// implementing the 3D PGA geometric, sandwich, conversion, and inertia-mapping products. </summary>
/// <remarks>
/// ## Public Methods
///
/// | Line | Method | Description |
/// |--:|---|---|
/// | 50 | <see cref="Times"/> | * = geometric/cartesian product. |
/// | 70 | <see cref="Dual"/> | The Dual associates projective Planes with Lines and vice versa |
/// | 78 | <see cref="Involute"/> | Main involution |
/// | 86 | <see cref="Conjugate"/> | Clifford-Conjugate, same as Reverted |
/// | 97 | <see cref="Reverted"/> | ~ Complex Conjugate of the basis blades. |
/// | 206 | <see cref="Sandwich"/> | &lt; AKA Map, 'Sandwich' Product: ~this * trafo * this |
/// | 219 | <see cref="SandwichBy"/> | > AKA Map, 'Sandwich' Product: ~motor * this * motor |
/// | 232 | <see cref="AsPga3D"/> | Embeds this Motor3P into the full Pga3D multi-vector by placing its eight even-grade components at their canonical positions. |
/// | 254 | <see cref="InertiaMap"/> | The Inertia maps between Rotation and Translation BiVectors |
///
/// ## Collaborators
///
/// | Type | Role |
/// |---|---|
/// | <see cref="Motor3P"/> | Returned by a method. |
/// | <see cref="Reflector3P"/> | Returned by a method. |
/// | <see cref="Vector4"/> | Passed as a parameter. |
/// | <see cref="Pga3D"/> | Returned by a method. |
/// </remarks>
///
[DocState(Pass = 2, MTime = "2026-05-24T15:36:37Z", Digest = "35f2ce4ec919f5891a192aa018804c3de82a655e075b52bc9a6d4a26acd3ca04", Stale = false, Path = "pga/XMotor3P.cs", Since = "2026-10-06")]
[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
[Tags("code/extension_method", "code/projective_geometric_algebra")]
[System.ComponentModel.Description("Extension methods for Motor3P and Reflector3P implementing the 3D PGA geometric, sandwich, conversion, and inertia-mapping products.")]
[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
public static class XMotor3P
{
	/// <summary> * = geometric/cartesian product. </summary>
	/// <remarks>
	/// Examples:
	/// Vector * Vector = Versor (defines a Plane with double Reflection)
	/// By Sandwiching this acts like a Rotation or Translation.
	/// 
	/// Normalized Versors are also called Rotors or Spinors.
	/// 
	/// </remarks>
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/extension_method", "code/geometric_product")]
	[System.ComponentModel.Description("* = geometric/cartesian product.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public static Motor3P Times(this Motor3P a, Motor3P b) => new(
		b._1_ * a._1_ - b.RotZ * a.RotZ - b.RotY * a.RotY - b.RotX * a.RotX,

		b.TransX * a._1_ + b._1_ * a.TransX - b.RotZ * a.TransY + b.RotY * a.TransZ + b.TransY * a.RotZ - b.TransZ * a.RotY - b.I * a.RotX - b.RotX * a.I,
		b.TransY * a._1_ + b.RotZ * a.TransX + b._1_ * a.TransY - b.RotX * a.TransZ - b.TransX * a.RotZ - b.I * a.RotY + b.TransZ * a.RotX - b.RotY * a.I,
		b.TransZ * a._1_ - b.RotY * a.TransX + b.RotX * a.TransY + b._1_ * a.TransZ - b.I * a.RotZ + b.TransX * a.RotY - b.TransY * a.RotX - b.RotZ * a.I,

		b.RotZ * a._1_ + b._1_ * a.RotZ + b.RotX * a.RotY - b.RotY * a.RotX,
		b.RotY * a._1_ - b.RotX * a.RotZ + b._1_ * a.RotY + b.RotZ * a.RotX,
		b.RotX * a._1_ + b.RotY * a.RotZ - b.RotZ * a.RotY + b._1_ * a.RotX,

		b.I * a._1_ + b.RotX * a.TransX + b.RotY * a.TransY + b.RotZ * a.TransZ + b.TransZ * a.RotZ + b.TransY * a.RotY + b.TransX * a.RotX + b._1_ * a.I
	);

	/// <summary> The Dual associates projective Planes with Lines and vice versa </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 1)]
	[Tags("code/extension_method", "code/clifford_algebra")]
	[System.ComponentModel.Description("The Dual associates projective Planes with Lines and vice versa")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public static Motor3P Dual(this Motor3P m) => new(m.I, m.RotX, m.RotY, m.RotZ, m.TransZ, m.TransY, m.TransX, m._1_);

	/// <summary> Main involution </summary>
	/// <remarks> Another Involution Operator </remarks>
	[Facets(Layer = "domain", Status = "stable", Complexity = 1)]
	[Tags("code/extension_method", "code/clifford_algebra")]
	[System.ComponentModel.Description("Main involution")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public static Motor3P Involute(this Motor3P m) => m;

	/// <summary> Clifford-Conjugate, same as <see cref="Reverted"/> </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 1)]
	[Tags("code/extension_method", "code/clifford_algebra")]
	[System.ComponentModel.Description("Clifford-Conjugate, same as Reverted")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public static Motor3P Conjugate(this Motor3P m) => Reverted(m);

	/// <summary> ~ Complex Conjugate of the basis blades. </summary>
	/// <remarks>
	/// Creates the Conjugate, which is the Inverse Transformation, except for Normalization 
	/// </remarks>
	/// TODO: bad Naming! Dual should be named that
	[Facets(Layer = "domain", Status = "stable", Complexity = 1)]
	[Tags("code/extension_method", "code/clifford_algebra")]
	[System.ComponentModel.Description("~ Complex Conjugate of the basis blades.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public static Motor3P Reverted(this Motor3P m) => new(m._1_
		, -m.TransX, -m.TransY, -m.TransZ, -m.RotZ, -m.RotY, -m.RotX, m.I);

	/// <summary> * = geometric/cartesian product. </summary>
	/// <remarks>
	/// Does not yield a pure <see cref="Vector4"/>,
	/// because that is no geometric Number and not invertible
	/// </remarks>
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/extension_method", "code/geometric_product")]
	[System.ComponentModel.Description("* = geometric/cartesian product.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public static Reflector3P Times(this Motor3P a, Vector4 b) => new(
		b.Z * a.RotZ + b.Y * a.RotY + b.X * a.RotX - b.W * a.I,
		-b.W * a.RotX,
		-b.W * a.RotY,
		-b.W * a.RotZ,

		b.Z * a._1_ - b.W * a.TransZ + b.X * a.RotY - b.Y * a.RotX,
		b.Y * a._1_ - b.W * a.TransY - b.X * a.RotZ + b.Z * a.RotX,
		b.X * a._1_ - b.W * a.TransX + b.Y * a.RotZ - b.Z * a.RotY,
		b.W * a._1_
	);

	/// <summary> * = geometric/cartesian product. </summary>
	/// <remarks>
	/// Does not yield a pure <see cref="Vector4"/>,
	/// because that is no geometric Number and not invertible
	/// </remarks>
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/extension_method", "code/geometric_product")]
	[System.ComponentModel.Description("* = geometric/cartesian product.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public static Reflector3P Times(this Vector4 a, Motor3P b) => new(
		b.RotZ * a.Z + b.RotY * a.Y + b.RotX * a.X + b.I * a.W,

		-b.RotX * a.W,
		-b.RotY * a.W,
		-b.RotZ * a.W,

		+b._1_ * a.Z + b.RotX * a.Y - b.RotY * a.X + b.TransZ * a.W,
		-b.RotX * a.Z + b._1_ * a.Y + b.RotZ * a.X + b.TransY * a.W,
		+b.RotY * a.Z - b.RotZ * a.Y + b._1_ * a.X + b.TransX * a.W,

		+b._1_ * a.W
	);

	/// <summary> * = geometric/cartesian product. </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/extension_method", "code/geometric_product")]
	[System.ComponentModel.Description("* = geometric/cartesian product.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public static Reflector3P Times(this Motor3P a, Reflector3P b) => new(
		b.Sky * a._1_ + b.YZ * a.TransX + b.ZX * a.TransY + b.XY * a.TransZ + b.Z * a.RotZ + b.Y * a.RotY + b.X * a.RotX - b.W * a.I,

		b.YZ * a._1_ + b.ZX * a.RotZ - b.XY * a.RotY - b.W * a.RotX,
		b.ZX * a._1_ - b.YZ * a.RotZ - b.W * a.RotY + b.XY * a.RotX,
		b.XY * a._1_ - b.W * a.RotZ + b.YZ * a.RotY - b.ZX * a.RotX,

		b.Z * a._1_ - b.ZX * a.TransX + b.YZ * a.TransY - b.W * a.TransZ - b.Sky * a.RotZ + b.X * a.RotY - b.Y * a.RotX - b.XY * a.I,
		b.Y * a._1_ + b.XY * a.TransX - b.W * a.TransY - b.YZ * a.TransZ - b.X * a.RotZ - b.Sky * a.RotY + b.Z * a.RotX - b.ZX * a.I,
		b.X * a._1_ - b.W * a.TransX - b.XY * a.TransY + b.ZX * a.TransZ + b.Y * a.RotZ - b.Z * a.RotY - b.Sky * a.RotX - b.YZ * a.I,

		b.W * a._1_ + b.XY * a.RotZ + b.ZX * a.RotY + b.YZ * a.RotX
	);

	/// <summary> * = geometric/cartesian product. </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/extension_method", "code/geometric_product")]
	[System.ComponentModel.Description("* = geometric/cartesian product.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public static Reflector3P Times(this Reflector3P a, Motor3P b) => new(
		+ b._1_ * a.Sky - b.TransX * a.YZ - b.TransY * a.ZX - b.TransZ * a.XY + b.RotZ * a.Z + b.RotY * a.Y + b.RotX * a.X + b.I * a.W,

		+ b._1_ * a.YZ - b.RotZ * a.ZX + b.RotY * a.XY  - b.RotX * a.W,
		+ b.RotZ * a.YZ + b._1_ * a.ZX - b.RotX * a.XY - b.RotY * a.W,
		- b.RotY * a.YZ + b.RotX * a.ZX + b._1_ * a.XY - b.RotZ * a.W,

		- b.RotZ * a.Sky + b.TransY * a.YZ - b.TransX * a.ZX + b.I * a.XY + b._1_ * a.Z + b.RotX * a.Y - b.RotY * a.X + b.TransZ * a.W,
		- b.RotY * a.Sky - b.TransZ * a.YZ + b.I * a.ZX + b.TransX * a.XY - b.RotX * a.Z + b._1_ * a.Y + b.RotZ * a.X + b.TransY * a.W,
		- b.RotX * a.Sky + b.I * a.YZ + b.TransZ * a.ZX - b.TransY * a.XY+ b.RotY * a.Z - b.RotZ * a.Y + b._1_ * a.X + b.TransX * a.W,

		+ b.RotX * a.YZ + b.RotY * a.ZX + b.RotZ * a.XY + b._1_ * a.W
	);

	/// <summary> &lt; AKA Map, 'Sandwich' Product: ~this * <paramref name="trafo"/> * this </summary>
	/// <remarks>
	/// Applies this Transformation to <paramref name="trafo"/>. 
	/// When the <see cref="Motor3P.NormSqr"/> is not 1, the Result should subsequently be normed! 
	///
	/// The "Sandwich" Product distributes over the geometric Product <see cref="Times(IReadOnlyList{float})"/>.
	/// I.e. Sandwich(a*b) == Sandwich(a)*Sandwich(b).
	/// This makes it so useful, because it can be applied to any geometric Object
	/// and it will not change the 'Character' of its Components.
	///
	/// This makes the Sandwich Product Coordinate-free. 
	/// 
	/// 'this' itself is invariant under this Transformation:
	/// ~this*this*this = this * this.NormSqr()
	///
	/// Since ~this*this = this*~this = this.NormSqr()
	/// 
	/// </remarks>
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/extension_method", "code/transformation")]
	[System.ComponentModel.Description("&lt; AKA Map, 'Sandwich' Product: ~this * trafo * this")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public static Motor3P Sandwich(this Motor3P self, Motor3P trafo) => self.Conjugate().Times(trafo).Times(self);

	/// <summary> > AKA Map, 'Sandwich' Product: ~<paramref name="motor"/> * this * <paramref name="motor"/> </summary>
	/// <remarks>
	/// Applies the Transformation defined by <paramref name="motor"/>. 
	/// When the <see cref="Motor3P.NormSqr"/> is not 1, the Result should subsequently be normed.
	/// 
	/// <paramref name="motor"/> itself is invariant under this Transformation! (prove by inserting into Expression)
	/// </remarks>
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/extension_method", "code/transformation")]
	[System.ComponentModel.Description("> AKA Map, 'Sandwich' Product: ~motor * this * motor")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public static Motor3P SandwichBy(this Motor3P self, Motor3P motor) => motor.Conjugate() * self * motor;

	/// <inheritdoc cref="Sandwich(Motor3P, Motor3P)"/>
	public static Reflector3P Sandwich(this Motor3P motor, Reflector3P reflector) => motor.Conjugate().Times(reflector).Times(motor);
	/// <inheritdoc cref="SandwichBy(Motor3P, Motor3P)"/>
	public static Reflector3P SandwichBy(this Reflector3P reflector, Motor3P motor) => motor.Conjugate().Times(reflector).Times(motor);

	/// <summary> Embeds this <see cref="Motor3P"/> into the full <see cref="Pga3D"/> multi-vector by placing its eight even-grade components at their canonical positions. </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 1)]
	[Tags("code/extension_method", "code/factory_method")]
	[System.ComponentModel.Description("Embeds this Motor3P into the full Pga3D multi-vector by placing its eight even-grade components at their canonical positions.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public static Pga3D AsPga3D(this Motor3P self) => new(self._1_, 0, 0, 0, 0 //1+4
		, self.TransX, self.TransY, self.TransZ, self.RotZ, self.RotY, self.RotX //+6
		, 0, 0, 0, 0, self.I); //+4+1

	//=> new(Pga3D.Base._1_.AsBlade(_1_)
	//, Pga3D.Base.e01.AsBlade(TransX)
	//, Pga3D.Base.e02.AsBlade(TransY)
	//, Pga3D.Base.e02.AsBlade(TransZ)
	//, Pga3D.Base.e12.AsBlade(RotZ)
	//, Pga3D.Base.e31.AsBlade(RotY)
	//, Pga3D.Base.e23.AsBlade(RotX)
	//, Pga3D.Base.e0123.AsBlade(I));

	/// <summary> The Inertia maps between Rotation and Translation BiVectors </summary>
	/// <remarks>
	/// Moments of Inertia are taken in the Principal Axes of the Body.
	/// Actually it is much faster to perform the Inertia-Map directly.
	/// </remarks>
	[Facets(Layer = "domain", Status = "stable", Complexity = 1)]
	[Tags("code/factory_method", "code/matrix_transformation")]
	[System.ComponentModel.Description("The Inertia maps between Rotation and Translation BiVectors")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public static IReadOnlyList<IReadOnlyList<float>> InertiaMap(float mass, float iX, float iY, float iZ) 
		=> new IReadOnlyList<float>[] {
			//    _1_, TransX, Y, Z, RotZ, Y, X, I
			new[] {1	, 0, 0, 0	, 0, 0, 0	, 0f}, //_1_

			new[] {0	, 0, 0, 0	, mass, 0, 0, 0},//TransX
			new[] {0	, 0, 0, 0	, 0, mass, 0, 0},//TransY
			new[] {0	, 0, 0, 0	, 0, 0, mass, 0},//TransZ

			new[] {0	, iZ, 0, 0	, 0, 0, 0	, 0f}, //RotZ
			new[] {0	, 0, iY, 0	, 0, 0, 0	, 0f}, //RotY
			new[] {0	, 0, 0, iX	, 0, 0, 0	, 0f}, //RotX

			new[] {0	, 0, 0, 0	, 0, 0, 0	, 1f}, //I
		};

	/// <summary> Applies the inertia matrix defined by <paramref name="mass"/> and principal moments
	/// <paramref name="iX"/>, <paramref name="iY"/>, <paramref name="iZ"/> to <paramref name="motor"/>. </summary>
	///
	// TODO: LOGIC uses motor.RotX for all three TransX/TransY/TransZ terms and for both iX/iY terms - should be RotX/RotY/RotZ respectively, per the sibling InertiaMap(float,...) matrix's per-axis structure just above.
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/extension_method", "code/transformation")]
	[System.ComponentModel.Description("Applies the inertia matrix defined by mass and principal moments iX, iY, iZ to motor.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public static Motor3P InertiaMap(this Motor3P motor, float mass, float iX, float iY, float iZ) {
		return new Motor3P(motor._1_
			, mass * motor.RotX, mass * motor.RotX, mass * motor.RotX
			, iZ * motor.TransZ, iX * motor.RotX, iY * motor.RotX, motor.I);
	}
}
