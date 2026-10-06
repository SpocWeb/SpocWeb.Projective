using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using org.SpocWeb.root.interfaces.Vectors;
using org.SpocWeb.root.Attributes;

namespace org.SpocWeb.root.maths.pga.typed;

/// <summary> three floating-point components named x, y, and z of the Cross-Product </summary>
/// <remarks>
/// Represents a 3D Plane though the Origin or a 2D Plane with homogenous Component z.
/// If points p and q are specified, then the BiVector is initialized
/// to the wedge product between homogeneous extensions of p and q with z coordinates set to 1,
/// giving a representation of the 2D line containing both points.
///
/// If the point p and the direction v are specified,
/// then the line contains the point p and runs parallel to the direction v.
/// </remarks>
[DocState(Pass = 2, MTime = "2026-05-24T15:36:37Z", Digest = "d62224abb1fdefbf87d269e67b2f2bd638d1da4c4a64ee9862b33335b05cb847", Stale = false, Path = "typed/BiVector3D.cs", Since = "2026-10-06")]
[Facets(Layer = "domain", Status = "buggy", Complexity = 3)]
[Tags("code/value_object", "code/vector_math")]
[System.ComponentModel.Description("three floating-point components named x, y, and z of the Cross-Product")]
[Concept("Mathematics\\Geometry\\Vector.md")]
public readonly struct BiVector3D : IEquatable<BiVector3D>, IEquatable<Vector3>, IVector3D//, IReadOnlyList<double>
{

	public readonly Vector3 V3;

	/// <summary>Initializes a new instance of <see cref="BiVector3D"/> with the specified <paramref name="vector3"/>.<br/>
	/// Initializes a new instance of <see cref="BiVector3D"/> with the specified <paramref name="e23"/>, <paramref name="e31"/> and <paramref name="e12"/>.</summary>
	///
	[Facets(Layer = "domain", Status = "buggy", Complexity = 3)]
	[Tags("code/value_object", "code/vector_math")]
	[System.ComponentModel.Description("Initializes a new instance of BiVector3D with the specified vector3. Initializes a new instance of BiVector3D with the specified e23, e31 and e12.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public BiVector3D(Vector3 vector3) => V3 = vector3;
	/// <summary>Initializes a new instance of <see cref="BiVector3D"/> with the specified <paramref name="e23"/>, <paramref name="e31"/> and <paramref name="e12"/>.</summary>
	///
	[Facets(Layer = "domain", Status = "buggy", Complexity = 3)]
	[Tags("code/value_object", "code/vector_math")]
	[System.ComponentModel.Description("Initializes a new instance of BiVector3D with the specified e23, e31 and e12.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public BiVector3D(float e23, float e31, float e12) => V3 = new Vector3(e23, e31, e12);

	/// <summary>
	/// wedge product between homogeneous extensions of p and q with z coordinate assumed to 1,
	/// giving a representation of the 2D line containing both points.
	/// </summary>
	///
	[Facets(Layer = "domain", Status = "buggy", Complexity = 3)]
	[Tags("code/value_object", "code/vector_math")]
	[System.ComponentModel.Description("wedge product between homogeneous extensions of p and q with z coordinate assumed to 1, giving a representation of the 2D line containing both points.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public BiVector3D(Point2D p2D, Point2D q2D) {
		var p = p2D.V;
		var q = q2D.V;
		V3 = new Vector3(p.Y - q.Y, q.X - p.X, p.X * q.Y - p.Y * q.X);
	}

	/// <summary>
	/// line contains the point p and runs parallel to the direction v.
	/// </summary>
	///
	[Facets(Layer = "domain", Status = "buggy", Complexity = 3)]
	[Tags("code/value_object", "code/vector_math")]
	[System.ComponentModel.Description("line contains the point p and runs parallel to the direction v.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public BiVector3D(Point2D p2D, Vector2D v2D) {
		var p = p2D.V;
		var v = v2D.V;
		V3 = new Vector3(-v.Y, v.X, p.X * v.Y - p.Y * v.X);
	}

	#region Operators

	/// <summary> 	Returns a boolean value indicating whether the two BiVectors a and b are equal.	 </summary>
	public static bool operator ==(BiVector3D a, BiVector3D b) => a.Equals(b);

	/// <summary> 	Returns a boolean value indicating whether the two BiVectors a and b are not equal.	 </summary>
	public static bool operator !=(BiVector3D a, BiVector3D b) => !(a == b);

	/// <summary> 	Returns the Complement/Dual of the BiVector v.	 </summary>
	public static Vector3D operator !(BiVector3D v) => v.Complement();

	/// <summary> 	Returns the negation of the BiVector v.	 </summary>
	public static BiVector3D operator -(BiVector3D v) => v.Neg();

	/// <summary> 	Returns the sum of the BiVectors a and b.	 </summary>
	public static BiVector3D operator +(BiVector3D a, BiVector3D b) => a.Plus(b);

	/// <summary> 	Returns the difference of the BiVectors a and b.	 </summary>
	public static BiVector3D operator -(BiVector3D a, BiVector3D b) => a.Minus(b);

	/// <summary>Returns the product of the BiVector v and the scalar s.<br/>
	/// Returns the product of the BiVector v and the scalar s.</summary>
	public static BiVector3D operator *(BiVector3D v, double scalar) => v.Times(scalar);
	/// <summary>Multiplies <paramref name="s"/> by <paramref name="v"/>.</summary>
	public static BiVector3D operator *(float s, BiVector3D v) => v.Times(s);

	/// <summary> 	Returns the product of the BiVector v and the inverse of the scalar s.	 </summary>
	public static BiVector3D operator /(BiVector3D v, double scalar) => v.Times(1 / scalar);

	/// <summary> 	Returns the anti-wedge product of the BiVectors a and b.	 </summary>
	public static Vector3D operator ^(BiVector3D a, BiVector3D b)
	{
		var vectorA = a.V3;
		var vectorB = b.V3;
		return new Vector3D(vectorA.Y * vectorB.Z - vectorA.Z * vectorB.Y
			, vectorA.Z * vectorB.X - vectorA.X * vectorB.Z
			, vectorA.X * vectorB.Y - vectorA.Y * vectorB.X);
	}

	/// <summary>Returns the anti-wedge product of the BiVector a and the vector b.</summary>
	public static float operator ^(BiVector3D a, Vector3D b) => Vector3.Dot(a.V3, b.V);
	/// <summary>Returns the anti-wedge product of the BiVector a and the point b.</summary>
	public static float operator ^(BiVector3D a, Point3D b) => Vector3.Dot(a.V3, b.V);

	/// <summary>Returns the anti-wedge product of the vector a and the BiVector b.</summary>
	public static float operator ^(Vector3D a, BiVector3D b) => Vector3.Dot(a.V, b.V3);
	/// <summary>Returns the anti-wedge product of the point a and the BiVector b.</summary>
	public static float operator ^(Point3D a, BiVector3D b) => Vector3.Dot(a.V, b.V3);

	/// <summary> 	Returns (b̲ ∧ a) ∨ b, which is the projection of a onto b under the assumption that the magnitude of b is one.	 </summary>
	///
	[Facets(Layer = "domain", Status = "buggy", Complexity = 3)]
	[Tags("code/value_object", "code/vector_math")]
	[System.ComponentModel.Description("Returns (b̲ ∧ a) ∨ b, which is the projection of a onto b under the assumption that the magnitude of b is one.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public Vector3D Project(Vector3D a) => !this ^ a ^ this;

	/// <summary> Scalar dot product of this bivector and <paramref name="bV3d"/> (sum of component-wise products). </summary>
	///
	[Facets(Layer = "domain", Status = "buggy", Complexity = 3)]
	[Tags("code/value_object", "code/vector_math")]
	[System.ComponentModel.Description("Scalar dot product of this bivector and bV3d (sum of component-wise products).")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public float Dot(BiVector3D bV3d) => V3.Dot(bV3d.V3); // a.X * b.X + a.Y * b.Y + a.Z * b.Z;

	#endregion Operators

	/// <summary> Returns the additive inverse of this bivector. </summary>
	///
	[Facets(Layer = "domain", Status = "buggy", Complexity = 3)]
	[Tags("code/value_object", "code/vector_math")]
	[System.ComponentModel.Description("Returns the additive inverse of this bivector.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public BiVector3D Neg() => new(-V3);

	/// <summary> Returns the Hodge complement (dual) of this bivector as a <see cref="Vector3D"/>. </summary>
	///
	[Facets(Layer = "domain", Status = "buggy", Complexity = 3)]
	[Tags("code/value_object", "code/vector_math")]
	[System.ComponentModel.Description("Returns the Hodge complement (dual) of this bivector as a Vector3D.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public Vector3D Complement() => new(V3);

	/// <summary> Scales all components by <paramref name="scalar"/>. </summary>
	///
	[Facets(Layer = "domain", Status = "buggy", Complexity = 3)]
	[Tags("code/value_object", "code/vector_math")]
	[System.ComponentModel.Description("Scales all components by scalar.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public BiVector3D Times(double scalar) => new(V3 * (float)scalar);

	/// <summary> Returns the component-wise sum of this bivector and <paramref name="that"/>. </summary>
	///
	[Facets(Layer = "domain", Status = "buggy", Complexity = 3)]
	[Tags("code/value_object", "code/vector_math")]
	[System.ComponentModel.Description("Returns the component-wise sum of this bivector and that.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public BiVector3D Plus(BiVector3D that) => new(that.V3 + V3);
	/// <summary> Returns the component-wise difference of this bivector minus <paramref name="that"/>. </summary>
	///
	[Facets(Layer = "domain", Status = "buggy", Complexity = 3)]
	[Tags("code/value_object", "code/vector_math")]
	[System.ComponentModel.Description("Returns the component-wise difference of this bivector minus that.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public BiVector3D Minus(BiVector3D that) => new(V3 - that.V3);

	/// <inheritdoc />
	public bool Equals(BiVector3D other) => V3.Equals(other.V3);

	/// <inheritdoc />
	IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	/// <inheritdoc cref="GetEnumerator()"/>
	public IEnumerator<double> GetEnumerator() {
		yield return V3.X;
		yield return V3.Y;
		yield return V3.Z;
	}

	/// <inheritdoc cref="Equals(BiVector3D)"/>
	public bool Equals(IVector3D? other) {
		if (other is null) {
			return false;
		}

		if (other is BiVector3D biVector)
			return biVector.Equals(V3);

		return other.X.Equals(V3.X) && other.Y.Equals(V3.Y) && other.Z.Equals(V3.Z);
	}

	/// <inheritdoc cref="Equals(BiVector3D)"/>
	public bool Equals(Vector3 other) => V3.Equals(other);
	/// <inheritdoc cref="Equals(BiVector3D)"/>
	public override bool Equals(object? obj) => obj is BiVector3D b && Equals(b);
	/// <inheritdoc />
	public override int GetHashCode() => V3.GetHashCode();

	/// <summary>Gets the norm.<br/>
	/// Gets the norm Abs.</summary>
	///
	[Facets(Layer = "domain", Status = "buggy", Complexity = 3)]
	[Tags("code/value_object", "code/vector_math")]
	[System.ComponentModel.Description("Gets the norm. Gets the norm Abs.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public double Norm => Math.Sqrt(NormSqr);
	/// <summary>Gets the norm Abs.</summary>
	///
	[Facets(Layer = "domain", Status = "buggy", Complexity = 3)]
	[Tags("code/value_object", "code/vector_math")]
	[System.ComponentModel.Description("Gets the norm Abs.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public double NormAbs => Math.Abs(V3.X) + Math.Abs(V3.Y) + Math.Abs(V3.Z);
	/// <summary>Gets the norm Sqr.</summary>
	///
	[Facets(Layer = "domain", Status = "buggy", Complexity = 3)]
	[Tags("code/value_object", "code/vector_math")]
	[System.ComponentModel.Description("Gets the norm Sqr.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public double NormSqr => Vector.IsHardwareAccelerated ? Vector3.Dot(V3, V3)
		: V3.X * V3.X + V3.Y * V3.Y + V3.Z * V3.Z;

	/// <summary>Gets the number of elements.</summary>
	///
	[Facets(Layer = "domain", Status = "buggy", Complexity = 3)]
	[Tags("code/value_object", "code/vector_math")]
	[System.ComponentModel.Description("Gets the number of elements.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public int Count => 3;

	/// <summary>Gets or sets the element at the specified <paramref name="index"/>.</summary>
	///
	[Facets(Layer = "domain", Status = "buggy", Complexity = 3)]
	[Tags("code/value_object", "code/vector_math")]
	[System.ComponentModel.Description("Gets or sets the element at the specified index.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public double this[int index] => index switch {
		0 => V3.X,
		1 => V3.Y,
		2 => V3.Y,
		//3 => 1, homogeneous Component
		_ => throw new IndexOutOfRangeException()
	};

	/// <summary>Gets the x.</summary>
	///
	[Facets(Layer = "domain", Status = "buggy", Complexity = 3)]
	[Tags("code/value_object", "code/vector_math")]
	[System.ComponentModel.Description("Gets the x.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public double X => V3.X;
	/// <summary>Gets the y.</summary>
	[Facets(Layer = "domain", Status = "buggy", Complexity = 3)]
	[Tags("code/value_object", "code/vector_math")]
	[System.ComponentModel.Description("Gets the y.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public double Y => V3.Y;
	/// <summary>Gets the z.</summary>
	///
	[Facets(Layer = "domain", Status = "buggy", Complexity = 3)]
	[Tags("code/value_object", "code/vector_math")]
	[System.ComponentModel.Description("Gets the z.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public double Z => V3.Z;
}

/// <summary> Extension methods for <see cref="BiVector3D"/> and related vector types. </summary>
/// <remarks>
/// ## Public Methods
///
/// | Line | Method | Description |
/// |--:|---|---|
/// | 308 | <see cref="Wedge"/> | Outer/wedge product of a and b, representing the oriented plane they span. |
/// | 327 | <see cref="Cross"/> | Scalar 2D cross product (pseudo-scalar component of the wedge product) of a and b. |
///
/// ## Collaborators
///
/// | Type | Role |
/// |---|---|
/// | <see cref="BiVector3D"/> | Returned by a method. |
/// | <see cref="Vector3D"/> | Passed as a parameter. |
/// | <see cref="Vector3"/> | Passed as a parameter. |
/// | <see cref="Vector2"/> | Passed as a parameter. |
/// </remarks>
[DocState(Pass = 2, MTime = "2026-06-17T05:56:24Z", Digest = "926e1307e16bff028084bde87c32ed6b996fa0e178f14547b813049091df8346", Stale = false, Path = "typed/BiVector3D.cs", Since = "2026-10-06")]
[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
[Tags("code/extension_method", "code/vector_math")]
[System.ComponentModel.Description("Extension methods for BiVector3D and related vector types.")]
[Concept("Mathematics\\Geometry\\Vector.md")]
public static class XBiVector3D
{
	/// <summary> Outer/wedge product of <paramref name="a"/> and <paramref name="b"/>,
	/// representing the oriented plane they span. </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 1)]
	[Tags("code/extension_method", "code/outer_product")]
	[System.ComponentModel.Description("Outer/wedge product of a and b, representing the oriented plane they span.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public static BiVector3D Wedge(this Vector3D a, Vector3D b) => Wedge(a.V, b.V);

	/// <summary> Outer/wedge product of <paramref name="a"/> and <paramref name="b"/>
	/// via the cross product of their underlying <see cref="Vector3"/> values. </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/extension_method", "code/outer_product", "code/cross_product")]
	[System.ComponentModel.Description("Outer/wedge product of a and b via the cross product of their underlying Vector3 values.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public static BiVector3D Wedge(this Vector3 a, Vector3 b)
		=> new(Vector3.Cross(a, b)); //new(a.Y * b.Z - a.Z * b.Y, a.Z * b.X - a.X * b.Z, a.X * b.Y - a.Y * b.X));
	//public static BiVector2D Wedge(this Vector2 a, Vector2 b) => new(a.Cross(b));

	/// <summary> Scalar 2D cross product (pseudo-scalar component of the wedge product) of <paramref name="a"/> and <paramref name="b"/>. </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/extension_method", "code/cross_product")]
	[System.ComponentModel.Description("Scalar 2D cross product (pseudo-scalar component of the wedge product) of a and b.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public static float Cross(this Vector2 a, Vector2 b) => a.X * b.Y - a.Y * b.X;

}
