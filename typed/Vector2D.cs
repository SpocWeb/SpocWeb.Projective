using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using org.SpocWeb.root.extensions.maths;
using org.SpocWeb.root.interfaces.maths;
using org.SpocWeb.root.interfaces.Vectors;
using org.SpocWeb.root.Attributes;

namespace org.SpocWeb.root.maths.pga.typed;

/// <summary>Provides extension methods for <see cref="Complex"/>.</summary>
/// <remarks>
/// ## Public Methods
///
/// | Line | Method | Description |
/// |--:|---|---|
/// | 40 | <see cref="Times"/> | Rotates and Scales the vector by scaleRot |
///
/// ## Collaborators
///
/// | Type | Role |
/// |---|---|
/// | <see cref="Vector2"/> | Returned by a method. |
/// | <see cref="Complex"/> | Passed as a parameter. |
/// </remarks>
///
[DocState(Pass = 2, MTime = "2026-05-24T15:40:20Z", Digest = "9b1e17dd8d922bb8cd498f75da9fc1f5ba40d88d35129375aba5cb50b26bfb1a", Stale = false, Path = "typed/Vector2D.cs", Since = "2026-10-06")]
[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
[Tags("code/extension_method", "code/complex_math")]
[System.ComponentModel.Description("Provides extension methods for Complex.")]
[Concept("Mathematics\\Geometry\\Vector.md")]
public static class XVector2
{

	/// <summary> Rotates and Scales the <paramref name="vector"/> by <paramref name="scaleRot"/> </summary>
	/// <remarks>Multiplication from the Left results in opposite Rotation.
	/// Unlike the Sandwich Product, this performs only a single Rotation.
	/// </remarks>
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/extension_method", "code/vector_rotation", "code/complex_math")]
	[System.ComponentModel.Description("Rotates and Scales the vector by scaleRot")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public static Vector2 Times(this Complex scaleRot, Vector2 vector) => new(
		(float) (vector.X * scaleRot.Real - scaleRot.Imaginary * vector.Y),
		(float) (vector.Y * scaleRot.Real + scaleRot.Imaginary * vector.X));

	/// <summary> Rotates and Scales the <paramref name="vector"/> by <paramref name="scaleRot"/> from the Right </summary>
	/// <remarks>Ported from the former XPoint2Dbl (single precision like the left-hand overload);
	/// for double precision use <see cref="XSize2Dbl.Times(Size2Dbl, Complex)"/> .</remarks>
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/extension_method", "code/vector_rotation", "code/complex_math")]
	[System.ComponentModel.Description("Rotates and Scales the vector by scaleRot from the Right")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public static Vector2 Times(this Vector2 vector, Complex scaleRot) => new(
		(float) (vector.X * scaleRot.Real + scaleRot.Imaginary * vector.Y),
		(float) (vector.Y * scaleRot.Real - scaleRot.Imaginary * vector.X));

}

/// <summary> <see cref="Vector2"/>-backed struct impl. up to <see cref="IVector4D"/> </summary>
/// <remarks>
/// ## Public Methods
///
/// | Line | Method | Description |
/// |--:|---|---|
/// | 101 | <see cref="Vector2D"/> | Initializes a new instance of Vector2D with the specified x and y. Initializes a new instance of Vector2D with the specified v. |
/// | 108 | <see cref="Vector2D"/> | Initializes a new instance of Vector2D with the specified x and y. |
/// | 115 | <see cref="Vector2D"/> | Initializes a new instance of Vector2D with the specified v. |
/// | 156 | <see cref="operator -"/> | Negates v. |
/// | 159 | <see cref="operator ~"/> | returns the boolean Complement 1-this or the complex Conjugate/Transpose |
/// | 164 | <see cref="operator *"/> | Multiplies v by p. Multiplies v by p. |
/// | 166 | <see cref="operator *"/> | Multiplies v by scalar. |
/// | 170 | <see cref="operator *"/> | Multiplies v by scalar. Divides v by scalar. |
/// | 172 | <see cref="operator *"/> | Multiplies v by scalar. |
/// | 174 | <see cref="operator /"/> | Divides v by scalar. |
/// | 178 | <see cref="operator +"/> | Adds v and p. Adds v and p. |
/// | 180 | <see cref="operator +"/> | Adds v and p. |
/// | 183 | <see cref="operator +"/> | Adds p and v. |
/// | 191 | <see cref="operator ^"/> | Wedge/Meet/Cross/outer Product Multiplies a by b. Multiplies a by b. |
/// | 193 | <see cref="operator *"/> | Multiplies a by b. |
/// | 216 | <see cref="Normalized"/> | Gets the normalized. |
/// | 254 | <see cref="Cjg"/> | Returns the complex conjugate of this 2D vector (negates the Y component). |
/// | 262 | <see cref="Neg"/> | Returns the additive inverse of this vector. |
/// | 269 | <see cref="Plus"/> |  |
/// | 275 | <see cref="Per"/> | Divides all components by scalar. |
/// | 283 | <see cref="Times"/> | Scales all components by scalar. |
/// | 309 | <see cref="Cross"/> | AKA AntiWedge; anti-symmetric Cross Product |
/// | 319 | <see cref="Dot"/> | symmetric Dot Product, actually a geometric Wedge-Product with the Anti-Vector of that |
/// | 334 | <see cref="ProjectOn"/> | Non-normalized Projection in normed Direction |
/// | 345 | <see cref="RejectFrom"/> | Non-normalized Rejection from normed Direction |
/// | 360 | <see cref="ReflectAt"/> | Reflects this at normed |
/// | 370 | <see cref="Floor"/> | Component-wise floor toward negative infinity. |
/// | 378 | <see cref="Ceil"/> | Component-wise ceiling toward positive infinity. |
/// | 386 | <see cref="CosSin"/> | Returns a unit vector whose X = cos(angle) and Y = sin(angle). |
/// | 398 | <see cref="RotateBy"/> | Rotates this vector counter-clockwise by angle radians around the origin. |
/// </remarks>
///
[DocState(Pass = 2, MTime = "2026-06-17T05:57:36Z", Digest = "0da81f3edacab246e9009bcd38de6c530ff9bffb5d8386fc5870b29e3bc9f5bb", Stale = false, Path = "typed/Vector2D.cs", Since = "2026-10-06")]
[Facets(Layer = "domain", Status = "stable", Complexity = 3)]
[Tags("code/value_object", "code/vector_math")]
[System.ComponentModel.Description("Vector2-backed struct impl. up to IVector4D")]
[Replaces("../../_org.structs/maths/scalars/Vector2D.cs")]
[Concept("Mathematics\\Geometry\\Vector.md")]
public readonly struct Vector2D : IVector2D, IVector3D, IVector4D
{
	public readonly Vector2 V;

	/// <summary>Initializes a new instance of <see cref="Vector2D"/> with the specified <paramref name="x"/> and <paramref name="y"/>.<br/>
	/// Initializes a new instance of <see cref="Vector2D"/> with the specified <paramref name="v"/>.</summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 3)]
	[Tags("code/value_object", "code/vector_math")]
	[System.ComponentModel.Description("Initializes a new instance of Vector2D with the specified x and y. Initializes a new instance of Vector2D with the specified v.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public Vector2D(float x, float y) => V = new Vector2(x, y);
	/// <summary>Initializes a new instance of <see cref="Vector2D"/> with the specified <paramref name="x"/> and <paramref name="y"/>.</summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 3)]
	[Tags("code/value_object", "code/vector_math")]
	[System.ComponentModel.Description("Initializes a new instance of Vector2D with the specified x and y.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public Vector2D(double x, double y) => V = new Vector2((float) x, (float) y);
	/// <summary>Initializes a new instance of <see cref="Vector2D"/> with the specified <paramref name="v"/>.</summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 3)]
	[Tags("code/value_object", "code/vector_math")]
	[System.ComponentModel.Description("Initializes a new instance of Vector2D with the specified v.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public Vector2D(Vector2 v) => V = v;

	/// <summary> AKA Length/Longitude </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 3)]
	[Tags("code/value_object", "code/vector_math")]
	[System.ComponentModel.Description("AKA Length/Longitude")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public double X => V.X;

	/// <summary> AKA Height/Latitude </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 3)]
	[Tags("code/value_object", "code/vector_math")]
	[System.ComponentModel.Description("AKA Height/Latitude")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public double Y => V.Y;

	/// <summary>Gets the w.<br/>
	/// Gets the w.</summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 3)]
	[Tags("code/value_object", "code/vector_math")]
	[System.ComponentModel.Description("Gets the w. Gets the w.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public double Z => 0;
	/// <summary>Gets the w.</summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 3)]
	[Tags("code/value_object", "code/vector_math")]
	[System.ComponentModel.Description("Gets the w.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public double W => 0;

	#region Operators

	/// <summary>Negates <paramref name="v"/>.</summary>
	public static Vector2D operator -(Vector2D v) => v.Neg();

	/// <summary> returns the boolean Complement 1-this or the complex Conjugate/Transpose </summary>
	public static Vector2D operator ~(Vector2D v) => v.Cjg();
	//public static Vector2D operator !(Vector2D v) => v.Rcp();

	/// <summary>Multiplies <paramref name="v"/> by <paramref name="p"/>.<br/>
	/// Multiplies <paramref name="v"/> by <paramref name="p"/>.</summary>
	public static Point2D operator *(Point2D p, Vector2D v) => v.Times(p);
	/// <summary>Multiplies <paramref name="v"/> by <paramref name="scalar"/>.</summary>
	public static Point2D operator *(Vector2D v, Point2D p) => v.Times(p);

	/// <summary>Multiplies <paramref name="v"/> by <paramref name="scalar"/>.<br/>
	/// Divides <paramref name="v"/> by <paramref name="scalar"/>.</summary>
	public static Vector2D operator *(double scalar, Vector2D v) => v.Times(scalar);
	/// <summary>Multiplies <paramref name="v"/> by <paramref name="scalar"/>.</summary>
	public static Vector2D operator *(Vector2D v, double scalar) => v.Times(scalar);
	/// <summary>Divides <paramref name="v"/> by <paramref name="scalar"/>.</summary>
	public static Vector2D operator /(Vector2D v, double scalar) => v.Per(scalar);

	/// <summary>Adds <paramref name="v"/> and <paramref name="p"/>.<br/>
	/// Adds <paramref name="v"/> and <paramref name="p"/>.</summary>
	public static Point2D operator +(Point2D p, Vector2D v) => p.Plus(v);
	/// <summary>Adds <paramref name="v"/> and <paramref name="p"/>.</summary>
	public static Point2D operator +(Vector2D v, Point2D p) => p.Plus(v);

	/// <summary>Adds <paramref name="p"/> and <paramref name="v"/>.</summary>
	public static Point2D operator +(Vector2D p, Vector2D v) => v.Plus(p);

	/// <summary>Wedge/Meet/Cross/outer Product<br/>
	/// Multiplies <paramref name="a"/> by <paramref name="b"/>.<br/>
	/// Multiplies <paramref name="a"/> by <paramref name="b"/>.</summary>
	/// <remarks>
	/// Unfortunately the ^ Operator has the lowest Precedence, so you have to bracket the Product.
	/// </remarks>
	public static double operator ^(Vector2D a, Vector2D b) => a.Cross(b);
	/// <summary>Multiplies <paramref name="a"/> by <paramref name="b"/>.</summary>
	public static double operator *(Vector2D a, Vector2D b) => a.Dot(b);
	//public static Vector2D operator *(Vector2D p, Vector2D v) => new(v.V * p.V);

	#endregion Operators

	/// <summary>Gets the norm.<br/>
	/// Gets the norm.</summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 3)]
	[Tags("code/value_object", "code/vector_math")]
	[System.ComponentModel.Description("Gets the norm. Gets the norm.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public double NormSqr => V.NormSqr();
	/// <summary>Gets the norm.</summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 3)]
	[Tags("code/value_object", "code/vector_math")]
	[System.ComponentModel.Description("Gets the norm.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public double Norm => V.Norm();

	/// <summary>Gets the normalized.</summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 3)]
	[Tags("code/value_object", "code/vector_math")]
	[System.ComponentModel.Description("Gets the normalized.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public Vector2D Normalized => new(V.Normalized());

	/// <summary>Gets the number of elements.</summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 3)]
	[Tags("code/value_object", "code/vector_math")]
	[System.ComponentModel.Description("Gets the number of elements.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public int Count => 2;

	/// <summary>Gets the norm Abs.</summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 3)]
	[Tags("code/value_object", "code/vector_math")]
	[System.ComponentModel.Description("Gets the norm Abs.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public double NormAbs => V.NormAbs();

	/// <summary>Gets or sets the element at the specified <paramref name="index"/>.</summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 3)]
	[Tags("code/value_object", "code/vector_math")]
	[System.ComponentModel.Description("Gets or sets the element at the specified index.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public double this[int index] => index switch {
			0 => X,
			1 => Y,
			2 => 0,
			3 => 0,
			_ => throw new ArgumentOutOfRangeException(nameof(index), index, null)
		};

	/// <summary> Returns the complex conjugate of this 2D vector (negates the Y component). </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 3)]
	[Tags("code/value_object", "code/vector_math")]
	[System.ComponentModel.Description("Returns the complex conjugate of this 2D vector (negates the Y component).")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public Vector2D Cjg() => new(V.Cjg());

	/// <summary> Returns the additive inverse of this vector. </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 3)]
	[Tags("code/value_object", "code/vector_math")]
	[System.ComponentModel.Description("Returns the additive inverse of this vector.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public Vector2D Neg() => new(V.Minus());

	/// <inheritdoc cref="Plus(Point2D)"/>
	public Point2D Plus(Point2D that) => new(Vector2.Add(V, that.V));
	/// <inheritdoc cref="Plus(Point2D)"/>
	public Point2D Plus(Vector2D that) => new(Vector2.Add(V, that.V));

	/// <summary> Divides all components by <paramref name="scalar"/>. </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 3)]
	[Tags("code/value_object", "code/vector_math")]
	[System.ComponentModel.Description("Divides all components by scalar.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public Vector2D Per(double scalar) => new(V * (float) (1 / scalar));

	/// <summary> Scales all components by <paramref name="scalar"/>. </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 3)]
	[Tags("code/value_object", "code/vector_math")]
	[System.ComponentModel.Description("Scales all components by scalar.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public Vector2D Times(double scalar) => new(V * (float) scalar);

	/// <summary> Component-wise Multiplication </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 3)]
	[Tags("code/value_object", "code/vector_math")]
	[System.ComponentModel.Description("Component-wise Multiplication")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public Point2D Times(Point2D p) => new(V * p.V);

	/// <summary> Component-wise Multiplication! </summary>
	/// <inheritdoc cref="Times(double)"/>
	[Facets(Layer = "domain", Status = "stable", Complexity = 3)]
	[Tags("code/value_object", "code/vector_math")]
	[System.ComponentModel.Description("Component-wise Multiplication!")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public Vector2D Times(Vector2D p) => new(V * p.V);
	/// <inheritdoc cref="Times(double)"/>
	public Vector2D Times(Vector2 p) => new(V * p);

	/// <summary> AKA AntiWedge; anti-symmetric Cross Product </summary>
	/// <inheritdoc cref="Cross(Vector2D)"/>
	[Facets(Layer = "domain", Status = "stable", Complexity = 3)]
	[Tags("code/value_object", "code/vector_math")]
	[System.ComponentModel.Description("AKA AntiWedge; anti-symmetric Cross Product")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public float Cross(Vector2D that) => V.MulCross(that.V);
	/// <inheritdoc cref="Cross(Vector2D)"/>
	public float Cross(Vector2 that) => V.MulCross(that);

	/// <summary> symmetric Dot Product, actually a geometric Wedge-Product with the Anti-Vector of <paramref name="that"/> </summary>
	/// <inheritdoc cref="Dot(Vector2D)"/>
	[Facets(Layer = "domain", Status = "stable", Complexity = 3)]
	[Tags("code/value_object", "code/vector_math")]
	[System.ComponentModel.Description("symmetric Dot Product, actually a geometric Wedge-Product with the Anti-Vector of that")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public float Dot(Vector2D that) => Vector2.Dot(V, that.V);
	/// <inheritdoc cref="Dot(Vector2D)"/>
	public float Dot(Vector2 that) => Vector2.Dot(V, that);

	#region Project, Reflect, Reject

	/// <summary> Non-normalized Projection in <paramref name="normed"/> Direction </summary>
	/// <returns>the Projection of this Vector onto <paramref name="normed"/></returns>
	/// <remarks>
	/// this == <see cref="ProjectOn"/>(normed) + <see cref="RejectFrom"/>(normed)
	/// </remarks>
	[Facets(Layer = "domain", Status = "stable", Complexity = 3)]
	[Tags("code/value_object", "code/vector_math")]
	[System.ComponentModel.Description("Non-normalized Projection in normed Direction")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public Vector2D ProjectOn(Vector2D normed) => new(V.ProjectOn(normed.V));

	/// <summary> Non-normalized Rejection from <paramref name="normed"/> Direction </summary>
	/// <returns>the orthogonal Component of this Vector from <paramref name="normed"/></returns>
	/// <remarks>
	/// this == <see cref="ProjectOn"/>(normed) + <see cref="RejectFrom"/>(normed)
	/// </remarks>
	[Facets(Layer = "domain", Status = "stable", Complexity = 3)]
	[Tags("code/value_object", "code/vector_math")]
	[System.ComponentModel.Description("Non-normalized Rejection from normed Direction")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public Vector2D RejectFrom(Vector2D normed) => new(V.RejectFrom(normed.V)); //this - ProjectOn(normed);

	/// <summary> Reflects this at <paramref name="normed"/> </summary>
	/// <remarks>
	/// <paramref name="normed"/> must be normed!
	/// 
	/// Reflect = Project - Reject with
	/// Project = a*(a.Dot(b))
	/// Reject  = b - Project yields
	/// Reflect = Project*2 - b
	/// </remarks>
	[Facets(Layer = "domain", Status = "stable", Complexity = 3)]
	[Tags("code/value_object", "code/vector_math")]
	[System.ComponentModel.Description("Reflects this at normed")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public Vector2D ReflectAt(Vector2D normed) => new(V.ReflectAt(normed.V));// normed.V * 2 *Dot(normed) - V);

	#endregion Project, Reflect, Reject

	/// <summary> Component-wise floor toward negative infinity. </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 3)]
	[Tags("code/value_object", "code/vector_math")]
	[System.ComponentModel.Description("Component-wise floor toward negative infinity.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public Vector2D Floor() => new(Math.Floor(V.X), Math.Floor(V.Y));

	/// <summary> Component-wise ceiling toward positive infinity. </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 3)]
	[Tags("code/value_object", "code/vector_math")]
	[System.ComponentModel.Description("Component-wise ceiling toward positive infinity.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public Vector2D Ceil() => new(Math.Ceiling(V.X), Math.Ceiling(V.Y));

	/// <summary> Returns a unit vector whose X = cos(<paramref name="angle"/>) and Y = sin(<paramref name="angle"/>). </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 3)]
	[Tags("code/value_object", "code/vector_math")]
	[System.ComponentModel.Description("Returns a unit vector whose X = cos(angle) and Y = sin(angle).")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public static Vector2D CosSin(float angle) {
		var sin = Math.Sin(angle); //Math.SinCos(angle);
		var cos = Math.Cos(angle); //Math.Sqrt(1-sin*sin);
		return new Vector2D(cos, sin);
	}

	/// <summary> Rotates this vector counter-clockwise by <paramref name="angle"/> radians around the origin. </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 3)]
	[Tags("code/value_object", "code/vector_math")]
	[System.ComponentModel.Description("Rotates this vector counter-clockwise by angle radians around the origin.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public Vector2D RotateBy(float angle) {
		Vector2 t = CosSin(angle).V;
		var nx = t.X * V.X - t.Y * V.Y;
		var ny = t.Y * V.X + t.X * V.Y;
		return new Vector2D(nx, ny);
	}

	/// <summary> Approximate equality within a tolerance scaled to the combined magnitude of both vectors. </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 3)]
	[Tags("code/value_object", "code/vector_math")]
	[System.ComponentModel.Description("Approximate equality within a tolerance scaled to the combined magnitude of both vectors.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public bool Equals(IVector2D? other)
	{
		if (other is null) return false;
		var norm = (NormAbs + other.NormAbs).MulAccuracy();
		return other.X.IsApprox(X, norm)
			&& other.Y.IsApprox(Y, norm);
	}

	/// <summary> Enumerates the X and Y coordinates as doubles. </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 3)]
	[Tags("code/value_object", "code/vector_math")]
	[System.ComponentModel.Description("Enumerates the X and Y coordinates as doubles.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public IEnumerator<double> GetEnumerator() {
		yield return X;
		yield return Y;
	}

	/// <inheritdoc cref="GetEnumerator()"/>
	IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
