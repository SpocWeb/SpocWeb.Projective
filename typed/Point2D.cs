using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using org.SpocWeb.root.extensions.maths;
using org.SpocWeb.root.interfaces.maths;
using org.SpocWeb.root.interfaces.Vectors;
using org.SpocWeb.root.Attributes;

namespace org.SpocWeb.root.maths.pga.typed;

/// <summary> <see cref="Vector2"/>-backed immutable 2D affine point with homogeneous W = 1,<br/>
/// supporting addition/subtraction with <see cref="Vector2D"/> and wedge products that produce lines. </summary>
/// <remarks>
/// ## Public Methods
///
/// | Line | Method | Description |
/// |--:|---|---|
/// | 127 | <see cref="Point2D"/> | Initializes a new instance of Point2D with the specified v. |
/// | 134 | <see cref="operator *"/> | Multiplies scalar by point2D. |
/// | 145 | <see cref="Minus"/> | Subtracts that displacement from this point. |
/// | 145 | <see cref="Plus"/> | Adds that displacement to this point. |
/// | 226 | <see cref="operator ^"/> | Returns the wedge product of the 2D points p and q. The z coordinates of p and q are assumed to be 1. |
/// | 233 | <see cref="operator ^"/> | Returns the wedge product of the 2D point p and the 2D vector v. The z coordinate of p is assumed to be 1. |
///
/// ## Collaborators
///
/// | Type | Role |
/// |---|---|
/// | <see cref="Vector2"/> | Used as a field. |
/// | <see cref="Point2D"/> | Returned by a method. |
/// | <see cref="Vector2D"/> | Passed as a parameter. |
/// | <see cref="IPoint2D"/> | Passed as a parameter. |
/// | <see cref="IVector2D"/> | Returned by a method. |
/// | <see cref="IPoint4D"/> | Passed as a parameter. |
/// | <see cref="IPoint3D"/> | Passed as a parameter. |
/// | <see cref="IEnumerator"/> | Returned by a method. |
/// </remarks>
///
[DocState(Pass = 2, MTime = "2026-05-24T15:36:37Z", Digest = "45dfe294652032a800df2d168f03696930a308929023ab7840b7fe2600cd2cc3", Stale = false, Path = "typed/Point2D.cs", Since = "2026-10-06")]
[Facets(Layer = "domain", Status = "stable", Complexity = 3)]
[Tags("code/value_object", "code/affine_geometry")]
[System.ComponentModel.Description("Vector2-backed immutable 2D affine point with homogeneous W = 1, supporting addition/subtraction with Vector2D and wedge products that produce lines.")]
[Concept("Mathematics\\Geometry\\Vector.md")]
public readonly struct Point2D : IPoint2D, IPoint3D, IPoint4D//, IVector2D, IVector3D
{
	public readonly Vector2 V;

	/// <summary>Gets the x.<br/>
	/// Gets the y.</summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 3)]
	[Tags("code/value_object", "code/affine_geometry")]
	[System.ComponentModel.Description("Gets the x. Gets the y.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public double X => V.X;
	/// <summary>Gets the y.</summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 3)]
	[Tags("code/value_object", "code/affine_geometry")]
	[System.ComponentModel.Description("Gets the y.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public double Y => V.Y;
	/// <summary>Gets the z.</summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 3)]
	[Tags("code/value_object", "code/affine_geometry")]
	[System.ComponentModel.Description("Gets the z.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public double Z => 0;
	/// <summary>Gets the w.</summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 3)]
	[Tags("code/value_object", "code/affine_geometry")]
	[System.ComponentModel.Description("Gets the w.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public double W => 1;

	/// <summary>Gets the number of elements.</summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 3)]
	[Tags("code/value_object", "code/affine_geometry")]
	[System.ComponentModel.Description("Gets the number of elements.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public int Count => 2;

	/// <summary>Gets the norm Abs.</summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 3)]
	[Tags("code/value_object", "code/affine_geometry")]
	[System.ComponentModel.Description("Gets the norm Abs.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public double NormAbs => Math.Abs(X) + Math.Abs(Y);

	/// <summary>Gets the norm Sqr.</summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 3)]
	[Tags("code/value_object", "code/affine_geometry")]
	[System.ComponentModel.Description("Gets the norm Sqr.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public double NormSqr => X*X + Y*Y;

	/// <summary>Gets the norm.</summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 3)]
	[Tags("code/value_object", "code/affine_geometry")]
	[System.ComponentModel.Description("Gets the norm.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public double Norm =>  Math.Sqrt(NormSqr);

	/// <summary>Gets or sets the element at the specified <paramref name="index"/>.</summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 3)]
	[Tags("code/value_object", "code/affine_geometry")]
	[System.ComponentModel.Description("Gets or sets the element at the specified index.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public double this[int index] => index switch {
		0 => X,
		1 => Y,
		2 => 0,
		3 => 0,
		_ => throw new ArgumentOutOfRangeException(nameof(index), index, null)
	};

	/// <summary>Initializes a new instance of <see cref="Point2D"/> with the specified <paramref name="v"/>.</summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 3)]
	[Tags("code/value_object", "code/affine_geometry")]
	[System.ComponentModel.Description("Initializes a new instance of Point2D with the specified v.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public Point2D(Vector2 v) => V = v;

	/// <summary>Multiplies <paramref name="scalar"/> by <paramref name="point2D"/>.</summary>
	public static Vector2D operator *(double scalar, Point2D point2D) => new(point2D.V * (float)scalar);

	/// <summary> Subtracts <paramref name="that"/> displacement from this point. </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 3)]
	[Tags("code/value_object", "code/affine_geometry")]
	[System.ComponentModel.Description("Subtracts that displacement from this point.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public Point2D Minus(Vector2D that) => new(Vector2.Subtract(V, that.V));
	/// <summary> Adds <paramref name="that"/> displacement to this point. </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 3)]
	[Tags("code/value_object", "code/affine_geometry")]
	[System.ComponentModel.Description("Adds that displacement to this point.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public Point2D Plus(Vector2D that) => new(Vector2.Add(V, that.V));

	/// <inheritdoc cref="Minus(Vector2D)"/>
	public Vector2D Minus(Point2D subtrahend) => new(V - subtrahend.V);
	/// <inheritdoc cref="Minus(Vector2D)"/>
	public Vector2D Minus(IPoint2D subtrahend) => new(X - subtrahend.X, Y - subtrahend.Y);
	/// <inheritdoc cref="Minus(Vector2D)"/>
	IVector2D IPoint2D.Minus(IPoint2D subtrahend) => Minus(subtrahend);

	/// <summary> Approximate equality as a homogeneous 4D point; requires W≈1 and Z≈0. </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 3)]
	[Tags("code/value_object", "code/affine_geometry")]
	[System.ComponentModel.Description("Approximate equality as a homogeneous 4D point; requires W≈1 and Z≈0.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public bool Equals(IPoint4D? that)
	{
		if (that is null) {
			return false;
		}

		var acc = (NormAbs + that.NormAbs).MulAccuracy();
		return that.W.IsOne(acc)
		       && that.Z.IsSmallerThanAbs(acc)
		       && X.IsApprox(that.X, acc)
		       && Y.IsApprox(that.Y, acc);
	}

	/// <summary> Approximate equality as a 3D point; requires Z≈0. </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 3)]
	[Tags("code/value_object", "code/affine_geometry")]
	[System.ComponentModel.Description("Approximate equality as a 3D point; requires Z≈0.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public bool Equals(IPoint3D? that)
	{
		if (that is null) {
			return false;
		}

		var acc = (NormAbs + that.NormAbs).MulAccuracy();
		return that.Z.IsSmallerThanAbs(acc)
			&& X.IsApprox(that.X, acc)
			&& Y.IsApprox(that.Y, acc);
	}

	/// <summary> Approximate equality within a tolerance scaled to the combined magnitude of both points. </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 3)]
	[Tags("code/value_object", "code/affine_geometry")]
	[System.ComponentModel.Description("Approximate equality within a tolerance scaled to the combined magnitude of both points.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public bool Equals(IPoint2D? that) {
		if (that is null) {
			return false;
		}

		var acc = (NormAbs + that.NormAbs).MulAccuracy();
		return X.IsApprox(that.X, acc)
		       && Y.IsApprox(that.Y, acc);
	}

	/// <summary> Enumerates the X and Y coordinates as doubles. </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 3)]
	[Tags("code/value_object", "code/affine_geometry")]
	[System.ComponentModel.Description("Enumerates the X and Y coordinates as doubles.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public IEnumerator<double> GetEnumerator() {
		yield return X;
		yield return Y;
	}

	/// <inheritdoc cref="GetEnumerator()"/>
	IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

	/// <summary> 	Returns the wedge product of the 2D points p and q. The z coordinates of p and q are assumed to be 1.	 </summary>
	public static BiVector3D operator ^(Point2D p2D, Point2D q2D) {
		var p = p2D.V;
		var q = q2D.V;
		return new BiVector3D(p.Y - q.Y, q.X - p.X, p.X * q.Y - p.Y * q.X);
	}

	/// <summary> 	Returns the wedge product of the 2D point p and the 2D vector v. The z coordinate of p is assumed to be 1.	 </summary>
	public static BiVector3D operator ^(Point2D p2D, Vector2D v2D) {
		var p = p2D.V;
		var v = v2D.V;
		return new BiVector3D(-v.Y, v.X, p.X * v.Y - p.Y * v.X);
	}

}
