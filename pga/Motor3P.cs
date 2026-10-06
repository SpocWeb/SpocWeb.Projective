using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using org.SpocWeb.root.expressions;
using org.SpocWeb.root.extensions.maths;
using org.SpocWeb.root.interfaces;
using org.SpocWeb.root.Attributes;

namespace org.SpocWeb.root.maths.pga;

/// <summary> AKA Motor/Trafo; 3D Projective Transformations; Even Sub-Algebra of <see cref="Pga3D"/> representing only Motors </summary>
/// <remarks>
/// Contains basically all BiVectors:
/// 3*Translations and
/// 3*Rotations plus the necessary Scalar and Imaginary Elements.
///
/// 8 * 4 Bytes = 32 Bytes, still OK for a struct.
/// 
/// Saves half of both Memory and CPU.
/// Does not allocate on the Heap, but the Stack, which further improves Speed.
///
/// Any Number of successive Transformations combines to another Transformation,
/// that represents a Screw-Motion:
/// * a rotation around the Axis preceded or followed by
/// * a translation along the Axis
/// 
/// </remarks>
[DocState(Pass = 2, MTime = "2026-05-24T15:36:37Z", Digest = "47cc38147d6338c7e4a94528e472b5e2ccf507f937f21573d10ae0cd22b001c3", Stale = false, Path = "pga/Motor3P.cs", Since = "2026-10-06")]
[Facets(Layer = "domain", Status = "stable", Complexity = 3)]
[Tags("code/projective_geometric_algebra", "code/rigid_body_physics")]
[System.ComponentModel.Description("AKA Motor/Trafo; 3D Projective Transformations; Even Sub-Algebra of Pga3D representing only Motors")]
[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
public readonly struct Motor3P : //IGeoGebra<Pga3DTrafo, float>, 
	IEquatable<Motor3P>, //AGeoGebra16<Pga3D>,
	IExpression<Motor3P>, //AGeoGebra16<Pga3D>,
	IReadOnlyList<float>
{
	/// <summary>Gets the basis.</summary>
	public static readonly IReadOnlyList<string> Basis = new[] {"" //1 Scalar 
		, "e01", "e02", "e03" //3 Circles on the Sphere at Infinity, for Translation
		, "e12", "e31", "e23" //3 BiPlanes/Axis-Lines, for Rotation 
		, "e0123"}; //1 Dual Pseudo-Scalar

	/// <inheritdoc cref="Pga3D.Base._1_"/>
	/// <remarks> cos(phi) for Rotations, 1 for Translations = cos(0) </remarks>
	public readonly float _1_; //1 Scalar 


	/// <inheritdoc cref="Pga3D.Base.e01"/>
	public readonly float TransX;

	/// <inheritdoc cref="Pga3D.Base.e02"/>
	public readonly float TransY;

	/// <inheritdoc cref="Pga3D.Base.e03"/>
	public readonly float TransZ;


	/// <inheritdoc cref="Pga3D.Base.e12"/>
	public readonly float RotZ;

	/// <inheritdoc cref="Pga3D.Base.e31"/>
	public readonly float RotY;

	/// <inheritdoc cref="Pga3D.Base.e23"/>
	public readonly float RotX;


	/// <inheritdoc cref="Pga3D.Base.e0123"/>
	public readonly float I;

	/// <summary>Initializes a new instance of <see cref="Motor3P"/> with the specified <paramref name="scale"/>, <paramref name="transX"/>, <paramref name="transY"/>, <paramref name="transZ"/>, <paramref name="rotZ"/>, <paramref name="rotY"/>, <paramref name="rotX"/> and <paramref name="i"/>.</summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 3)]
	[Tags("code/projective_geometric_algebra", "code/rigid_body_physics")]
	[System.ComponentModel.Description("Initializes a new instance of Motor3P with the specified scale, transX, transY, transZ, rotZ, rotY, rotX and i.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public Motor3P(float scale
		, float transX, float transY, float transZ
		, float rotZ, float rotY, float rotX, float i)
	{
		_1_ = scale;
		TransX = transX;
		TransY = transY;
		TransZ = transZ;
		RotZ = rotZ;
		RotY = rotY;
		RotX = rotX;
		I = i;
	}

	/// <summary>Gets the dim.<br/>
	/// Gets the number of elements.</summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 3)]
	[Tags("code/projective_geometric_algebra", "code/rigid_body_physics")]
	[System.ComponentModel.Description("Gets the dim. Gets the number of elements.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public byte Dim => 4;
	/// <summary>Gets the number of elements.</summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 3)]
	[Tags("code/projective_geometric_algebra", "code/rigid_body_physics")]
	[System.ComponentModel.Description("Gets the number of elements.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public int Count => 16;

	/// <inheritdoc />
	IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	/// <summary> yields 0s for the odd Grades </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 3)]
	[Tags("code/projective_geometric_algebra", "code/rigid_body_physics")]
	[System.ComponentModel.Description("yields 0s for the odd Grades")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public IEnumerator<float> GetEnumerator() {
		yield return _1_;

		yield return 0;
		yield return 0;
		yield return 0;
		yield return 0;

		yield return TransX;
		yield return TransY;
		yield return TransZ;
		yield return RotZ;
		yield return RotY;
		yield return RotX;

		yield return 0;
		yield return 0;
		yield return 0;
		yield return 0;

		yield return I;
	}

	/// <summary>Gets or sets the element at the specified <paramref name="index"/>.<br/>
	/// Gets or sets the element at the specified <paramref name="index"/>.</summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 3)]
	[Tags("code/projective_geometric_algebra", "code/rigid_body_physics")]
	[System.ComponentModel.Description("Gets or sets the element at the specified index. Gets or sets the element at the specified index.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public float this[int index] => this[(Pga3D.Base)index];
	/// <summary>Gets or sets the element at the specified <paramref name="index"/>.</summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 3)]
	[Tags("code/projective_geometric_algebra", "code/rigid_body_physics")]
	[System.ComponentModel.Description("Gets or sets the element at the specified index.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public float this[Pga3D.Base index] => index switch
	{
		Pga3D.Base._1_ => _1_,
		Pga3D.Base.e01 => TransX,
		Pga3D.Base.e02 => TransY,
		Pga3D.Base.e03 => TransZ,
		Pga3D.Base.e12 => RotZ,
		Pga3D.Base.e31 => RotY,
		Pga3D.Base.e23 => RotX,
		Pga3D.Base.e0123 => I,
		_ => 0
	};

	/// <summary> Returns this motor as its own evaluated form (identity for <see cref="IExpression{T}"/>). </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 3)]
	[Tags("code/projective_geometric_algebra", "code/rigid_body_physics")]
	[System.ComponentModel.Description("Returns this motor as its own evaluated form (identity for IExpression).")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public Motor3P Evaluate() => this;
	/// <summary> Returns this motor as its own canonical form (identity for <see cref="IExpression{T}"/>). </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 3)]
	[Tags("code/projective_geometric_algebra", "code/rigid_body_physics")]
	[System.ComponentModel.Description("Returns this motor as its own canonical form (identity for IExpression).")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public Motor3P Self() => this;

	/// <summary> Returns the hash code of this motor's coordinate values for use in expression caching. </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 3)]
	[Tags("code/projective_geometric_algebra", "code/rigid_body_physics")]
	[System.ComponentModel.Description("Returns the hash code of this motor's coordinate values for use in expression caching.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public int ValueHash() => GetHashCode();
	/// <inheritdoc />
	public override int GetHashCode() {
		unchecked {
			var hashCode = _1_.GetHashCode();
			hashCode = (hashCode << 1) ^ TransX.GetHashCode();
			hashCode = (hashCode << 1) ^ TransY.GetHashCode();
			hashCode = (hashCode << 1) ^ TransZ.GetHashCode();
			hashCode = (hashCode << 1) ^ RotZ.GetHashCode();
			hashCode = (hashCode << 1) ^ RotY.GetHashCode();
			hashCode = (hashCode << 1) ^ RotX.GetHashCode();
			hashCode = (hashCode << 1) ^ I.GetHashCode();
			return hashCode;
		}
	}

	/// <inheritdoc />
	public override bool Equals(object obj) => obj is Motor3P trafo && Equals(trafo);
	/// <summary>Determines whether equal To.</summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 3)]
	[Tags("code/projective_geometric_algebra", "code/rigid_body_physics")]
	[System.ComponentModel.Description("Determines whether equal To.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public bool IsEqualTo(Motor3P that) => Equals(that);

	/// <inheritdoc cref="Equals(object)"/>
	public bool Equals(Motor3P other) => _1_.IsApprox(other._1_, PgaTolerance.Float)
		&& TransX.Equals(other.TransX) && TransY.IsApprox(other.TransY, PgaTolerance.Float) && TransZ.IsApprox(other.TransZ, PgaTolerance.Float)
		&& RotZ.IsApprox(other.RotZ, PgaTolerance.Float) && RotY.IsApprox(other.RotY, PgaTolerance.Float) && RotX.IsApprox(other.RotX, PgaTolerance.Float) && I.IsApprox(other.I, PgaTolerance.Float);

	/// <summary> Scales all components of this motor by the given scalar <paramref name="factor"/>. </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 3)]
	[Tags("code/projective_geometric_algebra", "code/rigid_body_physics")]
	[System.ComponentModel.Description("Scales all components of this motor by the given scalar factor.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public Motor3P Times(double factor) => Times((float)factor);
	/// <inheritdoc cref="Times(double)"/>
	public Motor3P Times(float factor) => new(factor * _1_
		, factor * TransX, factor * TransY, factor * TransZ
		, factor * RotZ, factor * RotY, factor * RotX, factor * I);

	/// <inheritdoc cref="Times(double)"/>
	public Motor3P Times<S>(S multiplicand) where S : IIMeasureAble => Times((float)multiplicand.AsDouble());

	public static string Infix = ", ";
	/// <summary> Writes all eight motor components to <paramref name="writer"/> separated by <see cref="Infix"/>. </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 3)]
	[Tags("code/projective_geometric_algebra", "code/rigid_body_physics")]
	[System.ComponentModel.Description("Writes all eight motor components to writer separated by Infix.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public long WriteTo(TextWriter writer, long lengthLeft) {
		//new Pga3D().WriteTo(writer, lengthLeft);
		//MemoryMarshal.Cast< Trafo3P, float >(this);
		writer.Write(_1_);
		writer.Write(Infix); writer.Write(TransX);
		writer.Write(Infix); writer.Write(TransY);
		writer.Write(Infix); writer.Write(TransZ);
		writer.Write(Infix); writer.Write(RotZ);
		writer.Write(Infix); writer.Write(RotY);
		writer.Write(Infix); writer.Write(RotX);
		writer.Write(Infix); writer.Write(I);
		return lengthLeft;
	}

	/// <summary>Determines whether zero.</summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 3)]
	[Tags("code/projective_geometric_algebra", "code/rigid_body_physics")]
	[System.ComponentModel.Description("Determines whether zero.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public bool IsZero() => _1_.IsSmall() && TransX.IsSmall() && TransY.IsSmall() && TransZ.IsSmall()
		&& RotZ.IsSmall() && RotY.IsSmall() && RotX.IsSmall() && I.IsSmall();

	/// <summary> Returns the squared norm of this motor's rotational part (scalar² + rotZ² + rotY² + rotX²). </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 3)]
	[Tags("code/projective_geometric_algebra", "code/rigid_body_physics")]
	[System.ComponentModel.Description("Returns the squared norm of this motor's rotational part (scalar² + rotZ² + rotY² + rotX²).")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public double NormSqr() => _1_.Sqr() + RotZ.Sqr() + RotY.Sqr() + RotX.Sqr();

	/// <summary> Returns this motor with all components negated. </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 3)]
	[Tags("code/projective_geometric_algebra", "code/rigid_body_physics")]
	[System.ComponentModel.Description("Returns this motor with all components negated.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public Motor3P Neg() => new(-_1_, -TransX, -TransY, -TransZ, -RotZ, -RotY, -RotX, -I);
	/// <summary> Returns the Poincaré dual of this motor by swapping scalar/I and translation/rotation components. </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 3)]
	[Tags("code/projective_geometric_algebra", "code/rigid_body_physics")]
	[System.ComponentModel.Description("Returns the Poincaré dual of this motor by swapping scalar/I and translation/rotation components.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public Motor3P Dual() => new(I, RotX, RotY, RotZ, TransZ, TransY, TransX, _1_);

	/// <inheritdoc cref="Plus(Motor3P)"/>
	public Motor3P Plus(double value, Pga3D.Base basis) => basis switch {
		Pga3D.Base._1_ => new(_1_ + (float) value, TransX, TransY, TransZ, RotZ, RotY, RotX, I),
		Pga3D.Base.e01 => new(_1_, TransX + (float) value, TransY, TransZ, RotZ, RotY, RotX, I),
		Pga3D.Base.e02 => new(_1_, TransX, TransY + (float) value, TransZ, RotZ, RotY, RotX, I),
		Pga3D.Base.e03 => new(_1_, TransX, TransY, TransZ + (float) value, RotZ, RotY, RotX, I),
		Pga3D.Base.e12 => new(_1_, TransX, TransY, TransZ, RotZ + (float) value, RotY, RotX, I),
		Pga3D.Base.e31 => new(_1_, TransX, TransY, TransZ, RotZ, RotY + (float) value, RotX, I),
		Pga3D.Base.e23 => new(_1_, TransX, TransY, TransZ, RotZ, RotY, RotX + (float) value, I),
		Pga3D.Base.e0123 => new(_1_, TransX, TransY, TransZ, RotZ, RotY, RotX, I + (float) value),
		_ => throw new ArgumentOutOfRangeException(nameof(basis), basis, null)
	};

	/// <inheritdoc cref="Minus(Motor3P)"/>
	public Motor3P Minus(double value, Pga3D.Base basis) => basis switch {
		Pga3D.Base._1_ => new(_1_ - (float) value, TransX, TransY, TransZ, RotZ, RotY, RotX, I),
		Pga3D.Base.e01 => new(_1_, TransX - (float) value, TransY, TransZ, RotZ, RotY, RotX, I),
		Pga3D.Base.e02 => new(_1_, TransX, TransY - (float) value, TransZ, RotZ, RotY, RotX, I),
		Pga3D.Base.e03 => new(_1_, TransX, TransY, TransZ - (float) value, RotZ, RotY, RotX, I),
		Pga3D.Base.e12 => new(_1_, TransX, TransY, TransZ, RotZ - (float) value, RotY, RotX, I),
		Pga3D.Base.e31 => new(_1_, TransX, TransY, TransZ, RotZ, RotY - (float) value, RotX, I),
		Pga3D.Base.e23 => new(_1_, TransX, TransY, TransZ, RotZ, RotY, RotX - (float) value, I),
		Pga3D.Base.e0123 => new(_1_, TransX, TransY, TransZ, RotZ, RotY, RotX, I - (float) value),
		_ => throw new ArgumentOutOfRangeException(nameof(basis), basis, null)
	};

	/// <inheritdoc cref="MinusR(Motor3P)"/>
	public Motor3P MinusR(double value, Pga3D.Base basis) => basis switch {
		Pga3D.Base._1_ => new((float)value - _1_, -TransX, -TransY, -TransZ, -RotZ, -RotY, -RotX, -I),
		Pga3D.Base.e01 => new(-_1_, (float)value - TransX, -TransY, -TransZ, -RotZ, -RotY, -RotX, -I),
		Pga3D.Base.e02 => new(-_1_, -TransX, (float)value - TransY, -TransZ, -RotZ, -RotY, -RotX, -I),
		Pga3D.Base.e03 => new(-_1_, -TransX, -TransY, (float)value - TransZ, -RotZ, -RotY, -RotX, -I),
		Pga3D.Base.e12 => new(-_1_, -TransX, -TransY, -TransZ, (float)value - RotZ, -RotY, -RotX, -I),
		Pga3D.Base.e31 => new(-_1_, -TransX, -TransY, -TransZ, -RotZ, (float)value - RotY, -RotX, -I),
		Pga3D.Base.e23 => new(-_1_, -TransX, -TransY, -TransZ, -RotZ, -RotY, (float)value - RotX, -I),
		Pga3D.Base.e0123=> new(-_1_, -TransX, -TransY, -TransZ, -RotZ, -RotY, -RotX, (float)value - I),
		_ => throw new ArgumentOutOfRangeException(nameof(basis), basis, null)
	};

	/// <summary> Subtracts <paramref name="subtrahend"/> component-wise from this motor. </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 3)]
	[Tags("code/projective_geometric_algebra", "code/rigid_body_physics")]
	[System.ComponentModel.Description("Subtracts subtrahend component-wise from this motor.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public Motor3P Minus(Motor3P subtrahend) => new(
		_1_ - subtrahend._1_,
		TransX - subtrahend.TransX,
		TransY - subtrahend.TransY,
		TransZ - subtrahend.TransZ,
		RotZ - subtrahend.RotZ,
		RotY - subtrahend.RotY,
		RotX - subtrahend.RotX,
		I - subtrahend.I);

	/// <summary> Adds <paramref name="addend"/> component-wise to this motor. </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 3)]
	[Tags("code/projective_geometric_algebra", "code/rigid_body_physics")]
	[System.ComponentModel.Description("Adds addend component-wise to this motor.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public Motor3P Plus(Motor3P addend) => new(
		addend._1_ + _1_,
		addend.TransX + TransX,
		addend.TransY + TransY,
		addend.TransZ + TransZ,
		addend.RotZ + RotZ,
		addend.RotY + RotY,
		addend.RotX + RotX,
		addend.I + I);

	/// <summary> Returns <paramref name="minuend"/> minus this motor (reversed subtraction). </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 3)]
	[Tags("code/projective_geometric_algebra", "code/rigid_body_physics")]
	[System.ComponentModel.Description("Returns minuend minus this motor (reversed subtraction).")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public Motor3P MinusR(Motor3P minuend) => new(
		minuend._1_ + _1_,
		minuend.TransX + TransX,
		minuend.TransY + TransY,
		minuend.TransZ + TransZ,
		minuend.RotZ + RotZ,
		minuend.RotY + RotY,
		minuend.RotX + RotX,
		minuend.I + I);

	///// <inheritdoc cref="XPga3D.Times16"/>
	//public Trafo3P Times(Trafo3P factor) => this.Times16P(factor);

	/// <inheritdoc cref="XPga3D.Times16"/>
	public Motor3P TimesR(Motor3P factor) => factor.Times(this);

	/// <inheritdoc cref="XPga3D.Dot16P"/>
	public Motor3P Dot(Motor3P b) => new(
		b._1_ * _1_ - b.RotZ * RotZ - b.RotY * RotY - b.RotX * RotX,
		b.TransX * _1_ + b._1_ * TransX - b.I * RotX - b.RotX * I,
		b.TransY * _1_ + b._1_ * TransY - b.I * RotY - b.RotY * I,
		b.TransZ * _1_ + b._1_ * TransZ - b.I * RotZ - b.RotZ * I,
		b.RotZ * _1_ + b._1_ * RotZ,
		b.RotY * _1_ + b._1_ * RotY,
		b.RotX * _1_ + b._1_ * RotX,
		b.I * _1_ + b._1_ * I);

	/// <inheritdoc cref="XPga3D.Meet16P"/>
	public Motor3P Meet(Motor3P b) => new(b._1_ * _1_,
		b.TransX * _1_ + b._1_ * TransX,
		b.TransY * _1_ + b._1_ * TransY,
		b.TransZ * _1_ + b._1_ * TransZ,
		b.RotZ * _1_ + b._1_ * RotZ,
		b.RotY * _1_ + b._1_ * RotY,
		b.RotX * _1_ + b._1_ * RotX,
		b.I * _1_ + b.RotX * TransX + b.RotY * TransY + b.RotZ * TransZ
		+ b.TransZ * RotZ + b.TransY * RotY + b.TransX * RotX + b._1_ * I
	);

	/// <summary> Returns the outer (Meet) product with the operands swapped: <paramref name="that"/> Meet this. </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 3)]
	[Tags("code/projective_geometric_algebra", "code/rigid_body_physics")]
	[System.ComponentModel.Description("Returns the outer (Meet) product with the operands swapped: that Meet this.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public Motor3P MeetR(Motor3P that) => that.Meet(this);

	/// <inheritdoc cref="XPga3D.Join16P"/>
	public Motor3P Join(Motor3P b) => new(
		_1_ * b.I + TransX * b.RotX + TransY * b.RotY + TransZ * b.RotZ + RotZ * b.TransZ
		+ RotY * b.TransY + RotX * b.TransX + I * b._1_,
		TransX * b.I + I * b.TransX,
		TransY * b.I + I * b.TransY,
		TransZ * b.I + I * b.TransZ,
		RotZ * b.I + I * b.RotZ,
		RotY * b.I + I * b.RotY,
		RotX * b.I + I * b.RotX,
		I * b.I
	);

	/// <summary>Multiplies <paramref name="versor"/> by <paramref name="v"/>.<br/>
	/// Multiplies <paramref name="versor"/> by <paramref name="reflector"/>.</summary>
	public static Motor3P operator *(Motor3P versor, Motor3P v) => versor.Times(v);
	/// <summary>Multiplies <paramref name="versor"/> by <paramref name="reflector"/>.</summary>
	public static Reflector3P operator *(Motor3P versor, Reflector3P reflector) => versor.Times(reflector);
	/// <summary>Multiplies <paramref name="reflector"/> by <paramref name="versor"/>.</summary>
	public static Reflector3P operator *(Reflector3P reflector, Motor3P versor) => reflector.Times(versor);

	/// <inheritdoc cref="XMotor3P.Sandwich(Motor3P,Motor3P)"/>
	public static Motor3P operator <(Motor3P versor, Motor3P v) => versor.Sandwich(v);
	//public static IEnumerable<Motor3P> operator <(Motor3P versor, IEnumerable<Motor3P> motors) => motors.Select(m => m.Sandwich(versor));
	//public static IEnumerable<Motor3P> operator >(Motor3P vector, IEnumerable<Motor3P> motors) => motors.Select(m => m.Sandwich(vector));

	/// <inheritdoc cref="XMotor3P.Sandwich(Motor3P,Motor3P)"/>
	public static Motor3P operator >(Motor3P v, Motor3P versor) => versor.Sandwich(v);
	//public static IEnumerable<Motor3P> operator >(IEnumerable<Motor3P> motors, Motor3P versor) => motors.Select(versor.Sandwich);
	//public static IEnumerable<Motor3P> operator <(IEnumerable<Motor3P> motors, Motor3P vector) => motors.Select(m => m.Sandwich(vector));

}
