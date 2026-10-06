using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using NUnit.Framework;
using org.SpocWeb.root.interfaces.maths;
using org.SpocWeb.root.Attributes;

namespace org.SpocWeb.root.maths.pga;

/// <summary> Extension methods for <see cref="Motor2P"/> and <see cref="Reflector2P"/>
/// implementing the 2D PGA geometric, sandwich, and conversion products. </summary>
/// <remarks>
/// ## Public Methods
///
/// | Line | Method | Description |
/// |--:|---|---|
/// | 56 | <see cref="Times"/> | * = geometric/cartesian product. |
/// | 71 | <see cref="Dual"/> | The Dual associates projective Planes with Lines and vice versa |
/// | 79 | <see cref="Involute"/> | Main involution |
/// | 87 | <see cref="Conjugate"/> | Clifford-Conjugate, same as Reverted |
/// | 98 | <see cref="Reverted"/> | ~ Complex Conjugate of the basis blades. |
/// | 152 | <see cref="Sandwich"/> | &lt; AKA Map, 'Sandwich' Product: ~this * trafo * this |
/// | 165 | <see cref="SandwichBy"/> | > AKA Map, 'Sandwich' Product: ~motor * this * motor |
/// | 178 | <see cref="op_RightShift"/> | self >> that applies that to self |
/// | 185 | <see cref="op_LeftShift"/> | Applies the sandwich product  ~self * that * self  to transform the reflector. |
/// | 198 | <see cref="AsPga2D"/> | Embeds this Motor2P into the full Pga2D multi-vector by placing its four even-grade components at their canonical positions. |
/// | 211 | <see cref="AsMotor2P"/> | Extracts the even-grade components of self as a Motor2P, throwing if the odd-grade components are non-negligible. |
/// | 225 | <see cref="AsReflector2P"/> | Extracts the odd-grade components of self as a Reflector2P, throwing if the even-grade components are non-negligible. |
/// | 241 | <see cref="TestMotorTrans"/> | Test Motor Trans. |
///
/// ## Collaborators
///
/// | Type | Role |
/// |---|---|
/// | <see cref="Motor2P"/> | Returned by a method. |
/// | <see cref="Reflector2P"/> | Returned by a method. |
/// | <see cref="Pga2D"/> | Returned by a method. |
/// </remarks>
///
[DocState(Pass = 2, MTime = "2026-05-24T15:36:37Z", Digest = "34fde7baa8022786f6a31678af38fe26481ba7081b68e7348aa3b083fe92071c", Stale = false, Path = "pga/XMotor2P.cs", Since = "2026-10-06")]
[Facets(Layer = "domain", Status = "partial", Complexity = 2)]
[Tags("code/extension_method", "code/projective_geometric_algebra")]
[System.ComponentModel.Description("Extension methods for Motor2P and Reflector2P implementing the 2D PGA geometric, sandwich, and conversion products.")]
[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
public static class XMotor2P
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
	public static Motor2P Times(this Motor2P a, Motor2P b) => new(
		b._1_ * a._1_ - b.RotZ * a.RotZ,

		b.TransX * a._1_ + b._1_ * a.TransX - b.RotZ * a.TransY + b.TransY * a.RotZ,
		b.TransY * a._1_ + b.RotZ * a.TransX + b._1_ * a.TransY - b.TransX * a.RotZ,

		b.RotZ * a._1_ + b._1_ * a.RotZ
	);

	/// <summary> The Dual associates projective Planes with Lines and vice versa </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 1)]
	[Tags("code/extension_method", "code/clifford_algebra")]
	[System.ComponentModel.Description("The Dual associates projective Planes with Lines and vice versa")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public static Motor2P Dual(this Motor2P m) => new(m.RotZ, m.TransY, m.TransX, m._1_);

	/// <summary> Main involution </summary>
	/// <remarks> Another Involution Operator </remarks>
	[Facets(Layer = "domain", Status = "stable", Complexity = 1)]
	[Tags("code/extension_method", "code/clifford_algebra")]
	[System.ComponentModel.Description("Main involution")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public static Motor2P Involute(this Motor2P m) => m;

	/// <summary> Clifford-Conjugate, same as <see cref="Reverted"/> </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 1)]
	[Tags("code/extension_method", "code/clifford_algebra")]
	[System.ComponentModel.Description("Clifford-Conjugate, same as Reverted")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public static Motor2P Conjugate(this Motor2P m) => Reverted(m);

	/// <summary> ~ Complex Conjugate of the basis blades. </summary>
	/// <remarks>
	/// Creates the Conjugate, which is the Inverse Transformation, except for Normalization 
	/// </remarks>
	/// TODO: bad Naming! Dual should be named that
	[Facets(Layer = "domain", Status = "stable", Complexity = 1)]
	[Tags("code/extension_method", "code/clifford_algebra")]
	[System.ComponentModel.Description("~ Complex Conjugate of the basis blades.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public static Motor2P Reverted(this Motor2P m) => new(m._1_, -m.TransX, -m.TransY, -m.RotZ);

	/// <summary> * = geometric/cartesian product. </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/extension_method", "code/geometric_product")]
	[System.ComponentModel.Description("* = geometric/cartesian product.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public static Reflector2P Times(this Motor2P a, Reflector2P b) => new(
		b.Horizon * a._1_ + b.AxisY * a.TransX + b.AxisX * a.TransY + b.I * a.RotZ,

		b.AxisY * a._1_ + b.AxisX * a.RotZ,
		b.AxisX * a._1_ - b.AxisY * a.RotZ,

		b.I * a._1_ - b.AxisX * a.TransX + b.AxisY * a.TransY - b.Horizon * a.RotZ
	);

	/// <summary> * = geometric/cartesian product. </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/extension_method", "code/geometric_product")]
	[System.ComponentModel.Description("* = geometric/cartesian product.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public static Reflector2P Times(this Reflector2P a, Motor2P b) => new(
		+ b._1_ * a.Horizon - b.TransX * a.AxisY - b.TransY * a.AxisX- + b.RotZ * a.I,

		+ b._1_ * a.AxisY - b.RotZ * a.AxisX,
		+ b.RotZ * a.AxisY + b._1_ * a.AxisX,

		- b.RotZ * a.Horizon + b.TransY * a.AxisY - b.TransX * a.AxisX + b._1_ * a.I
	);

	/// <summary> &lt; AKA Map, 'Sandwich' Product: ~this * <paramref name="trafo"/> * this </summary>
	/// <remarks>
	/// Applies this Transformation to <paramref name="trafo"/>. 
	/// When the <see cref="Motor2P.NormSqr"/> is not 1, the Result should subsequently be normed! 
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
	public static Motor2P Sandwich(this Motor2P self, Motor2P trafo) => self.Conjugate().Times(trafo).Times(self);

	/// <summary> > AKA Map, 'Sandwich' Product: ~<paramref name="motor"/> * this * <paramref name="motor"/> </summary>
	/// <remarks>
	/// Applies the Transformation defined by <paramref name="motor"/>. 
	/// When the <see cref="Motor2P.NormSqr"/> is not 1, the Result should subsequently be normed.
	/// 
	/// <paramref name="motor"/> itself is invariant under this Transformation! (prove by inserting into Expression)
	/// </remarks>
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/extension_method", "code/transformation")]
	[System.ComponentModel.Description("> AKA Map, 'Sandwich' Product: ~motor * this * motor")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public static Motor2P SandwichBy(this Motor2P self, Motor2P motor) => motor.Conjugate() * self * motor;

	/// <inheritdoc cref="Sandwich(Motor2P, Motor2P)"/>
	public static Reflector2P Sandwich(this Motor2P motor, Reflector2P reflector) => motor.Conjugate().Times(reflector).Times(motor);
	/// <inheritdoc cref="SandwichBy(Motor2P, Motor2P)"/>
	public static Reflector2P SandwichBy(this Reflector2P reflector, Motor2P motor) => motor.Conjugate().Times(reflector).Times(motor);

	/// <summary><paramref name="self"/> >> <paramref name="that"/> applies <paramref name="that"/> to self</summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 1)]
	[Tags("code/operator_overload", "code/transformation")]
	[System.ComponentModel.Description("self >> that applies that to self")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	[SpecialName] public static Reflector2P op_RightShift(Reflector2P self, Motor2P that) => that.Sandwich(self);
	/// <summary> Applies the sandwich product <c>~<paramref name="self"/> * <paramref name="that"/> * <paramref name="self"/></c> to transform the reflector. </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 1)]
	[Tags("code/operator_overload", "code/transformation")]
	[System.ComponentModel.Description("Applies the sandwich product ~self * that * self to transform the reflector.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	[SpecialName] public static Reflector2P op_LeftShift(Motor2P self, Reflector2P that) => self.Sandwich(that);

	/// <inheritdoc cref="op_LeftShift(Motor2P, Reflector2P)"/>
	[SpecialName] public static Motor2P op_LeftShift(Motor2P self, Motor2P that) => self.Sandwich(that);
	/// <inheritdoc cref="op_RightShift(Reflector2P, Motor2P)"/>
	[SpecialName] public static Motor2P op_RightShift(Motor2P self, Motor2P that) => that.Sandwich(self);

	/// <summary> Embeds this <see cref="Motor2P"/> into the full <see cref="Pga2D"/> multi-vector by placing its four even-grade components at their canonical positions. </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 1)]
	[Tags("code/extension_method", "code/factory_method")]
	[System.ComponentModel.Description("Embeds this Motor2P into the full Pga2D multi-vector by placing its four even-grade components at their canonical positions.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public static Pga2D AsPga2D(this Motor2P self) => new(self._1_, 0, 0, 0 //1 + 3
		, self.TransX, self.TransY, self.RotZ, 0); //+3 + 1

	/// <inheritdoc cref="AsPga2D(Motor2P)"/>
	public static Pga2D AsPga2D(this Reflector2P self) => new(0, self.Horizon, self.AxisX, self.AxisY //1 + 3
		, 0, 0, 0, self.I); //+3 + 1

	/// <summary> Extracts the even-grade components of <paramref name="self"/> as a <see cref="Motor2P"/>, throwing if the odd-grade components are non-negligible. </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/extension_method", "code/factory_method", "code/validation")]
	[System.ComponentModel.Description("Extracts the even-grade components of self as a Motor2P, throwing if the odd-grade components are non-negligible.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public static Motor2P AsMotor2P(this Pga2D self) {
		var norm = self.NormAbs().MulAccuracy();
		if (Math.Abs(self[7]) + Math.Abs(self[1]) + Math.Abs(self[2]) + Math.Abs(self[3]) > norm) {
			throw new InvalidOperationException();
		}
		return new(self[0], self[4], self[5], self[6]); //1 + (3) + 3 + (1)
	}

	/// <summary> Extracts the odd-grade components of <paramref name="self"/> as a <see cref="Reflector2P"/>, throwing if the even-grade components are non-negligible. </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/extension_method", "code/factory_method", "code/validation")]
	[System.ComponentModel.Description("Extracts the odd-grade components of self as a Reflector2P, throwing if the even-grade components are non-negligible.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public static Reflector2P AsReflector2P(this Pga2D self) {
		var norm = self.NormAbs().MulAccuracy();
		if (Math.Abs(self[0]) + Math.Abs(self[4]) + Math.Abs(self[5]) + Math.Abs(self[6]) > norm)
		{
			throw new InvalidOperationException();
		}
		return new(self[0], self[4], self[5], self[7]); //1 + (3) + 3 + (1)
	}


	/// <summary>Test Motor Trans.</summary>
	///
	[Facets(Layer = "test", Status = "stub", Complexity = 1)]
	[Tags("code/unit_test")]
	[System.ComponentModel.Description("Test Motor Trans.")]
	[Test]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public static void TestMotorTrans() {
		var m1 = new Motor2P(1,1.1f,2.1f,0);
		var m2 = new Motor2P(1, 3.1f,4.1f,0);
		var m12 = m1 < m2;
		var m21 = m1 > m2;
	}

}
