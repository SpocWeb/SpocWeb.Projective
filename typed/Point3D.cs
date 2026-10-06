using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using org.SpocWeb.root.extensions.maths;
using org.SpocWeb.root.interfaces.maths;
using org.SpocWeb.root.interfaces.Vectors;
using org.SpocWeb.root.Attributes;

namespace org.SpocWeb.root.maths.pga.typed;

/// <summary> 3D Point accelerated by <see cref="Vector3"/> </summary>
/// <remarks>
/// ## Public Methods
///
/// | Line | Method | Description |
/// |--:|---|---|
/// | 111 | <see cref="Point3D"/> | Initializes a new instance of Point3D with the specified v. |
/// | 120 | <see cref="Point3D"/> | Initializes a new instance of Point3D with the specified x, y and z. Initializes a new instance of Point3D with the specified x, y and z. |
/// | 127 | <see cref="Point3D"/> | Initializes a new instance of Point3D with the specified x, y and z. |
/// | 142 | <see cref="Minus"/> | Subtracts that displacement from this point. |
/// | 151 | <see cref="Plus"/> | Adds that displacement to this point. |
/// | 161 | <see cref="Wedge"/> |  |
/// | 249 | <see cref="operator =="/> | Determines whether a equals b. Determines whether a does not equal b. |
/// | 251 | <see cref="operator !="/> | Determines whether a does not equal b. |
/// | 254 | <see cref="operator ^"/> | Wedge product of two 3D points, yielding the line through them. |
/// | 256 | <see cref="operator ^"/> | Wedge product of a 3D point and a direction vector, yielding the line through the point parallel to the vector. |
/// | 259 | <see cref="operator -"/> | Subtracts that from self. |
/// | 261 | <see cref="operator -"/> | Subtracts that from self. |
/// | 263 | <see cref="operator +"/> | Adds self and that. |
/// | 267 | <see cref="operator -"/> | Subtracts that from self. Adds self and that. |
/// | 269 | <see cref="operator +"/> | Adds self and that. |
///
/// ## Collaborators
///
/// | Type | Role |
/// |---|---|
/// | <see cref="Vector3"/> | Used as a field. |
/// | <see cref="Point3D"/> | Returned by a method. |
/// | <see cref="Vector3D"/> | Passed as a parameter. |
/// | <see cref="Vector4D"/> | Passed as a parameter. |
/// | <see cref="BiVector4D"/> | Returned by a method. |
/// | <see cref="IPoint3D"/> | Passed as a parameter. |
/// | <see cref="IPoint4D"/> | Passed as a parameter. |
/// | <see cref="IEnumerator"/> | Returned by a method. |
/// </remarks>
///
[DocState(Pass = 2, MTime = "2026-05-24T15:36:37Z", Digest = "c67006e522c51fe4e192ebb384ff0ccbb3bd097f6ab08a0b6913bdcd1ff768a6", Stale = false, Path = "typed/Point3D.cs", Since = "2026-10-06")]
[Facets(Layer = "domain", Status = "buggy", Complexity = 3)]
[Tags("code/value_object", "code/simd")]
[System.ComponentModel.Description("3D Point accelerated by Vector3")]
[Concept("Mathematics\\Geometry\\Vector.md")]
public readonly struct Point3D : IPoint3D, IPoint4D, IEquatable<Point3D>
{
	public readonly Vector3 V;

	/// <summary>Gets the number of elements.</summary>
	///
	[Facets(Layer = "domain", Status = "buggy", Complexity = 3)]
	[Tags("code/value_object", "code/simd")]
	[System.ComponentModel.Description("Gets the number of elements.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public int Count => 3;

	/// <summary>Gets the x.<br/>
	/// Gets the y.</summary>
	///
	[Facets(Layer = "domain", Status = "buggy", Complexity = 3)]
	[Tags("code/value_object", "code/simd")]
	[System.ComponentModel.Description("Gets the x. Gets the y.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public double X => V.X;
	/// <summary>Gets the y.</summary>
	///
	[Facets(Layer = "domain", Status = "buggy", Complexity = 3)]
	[Tags("code/value_object", "code/simd")]
	[System.ComponentModel.Description("Gets the y.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public double Y => V.Y;
	/// <summary>Gets the z.</summary>
	///
	[Facets(Layer = "domain", Status = "buggy", Complexity = 3)]
	[Tags("code/value_object", "code/simd")]
	[System.ComponentModel.Description("Gets the z.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public double Z => V.Z;
	/// <summary>Gets the w.</summary>
	///
	[Facets(Layer = "domain", Status = "buggy", Complexity = 3)]
	[Tags("code/value_object", "code/simd")]
	[System.ComponentModel.Description("Gets the w.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public double W => 0;

	/// <summary>Gets or sets the element at the specified <paramref name="index"/>.</summary>
	///
	[Facets(Layer = "domain", Status = "buggy", Complexity = 3)]
	[Tags("code/value_object", "code/simd")]
	[System.ComponentModel.Description("Gets or sets the element at the specified index.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public double this[int index] => index switch {
		0 => V.X,
		1 => V.Y,
		2 => V.Z,
		3 => 0,
		_ => throw new ArgumentOutOfRangeException(nameof(index), index, null)
	};

	/// <summary>Initializes a new instance of <see cref="Point3D"/> with the specified <paramref name="v"/>.</summary>
	///
	[Facets(Layer = "domain", Status = "buggy", Complexity = 3)]
	[Tags("code/value_object", "code/simd")]
	[System.ComponentModel.Description("Initializes a new instance of Point3D with the specified v.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public Point3D(Vector3 v) => V = v;

	/// <summary>Initializes a new instance of <see cref="Point3D"/> with the specified <paramref name="x"/>, <paramref name="y"/> and <paramref name="z"/>.<br/>
	/// Initializes a new instance of <see cref="Point3D"/> with the specified <paramref name="x"/>, <paramref name="y"/> and <paramref name="z"/>.</summary>
	///
	[Facets(Layer = "domain", Status = "buggy", Complexity = 3)]
	[Tags("code/value_object", "code/simd")]
	[System.ComponentModel.Description("Initializes a new instance of Point3D with the specified x, y and z. Initializes a new instance of Point3D with the specified x, y and z.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public Point3D(float x, float y, float z) => V = new Vector3(x, y, z);
	/// <summary>Initializes a new instance of <see cref="Point3D"/> with the specified <paramref name="x"/>, <paramref name="y"/> and <paramref name="z"/>.</summary>
	///
	[Facets(Layer = "domain", Status = "buggy", Complexity = 3)]
	[Tags("code/value_object", "code/simd")]
	[System.ComponentModel.Description("Initializes a new instance of Point3D with the specified x, y and z.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public Point3D(double x, double y, double z) => V = new Vector3((float) x, (float) y, (float) z);

	/// <summary> Subtracts <paramref name="that"/> displacement from this point. </summary>
	///
	[Facets(Layer = "domain", Status = "buggy", Complexity = 3)]
	[Tags("code/value_object", "code/simd")]
	[System.ComponentModel.Description("Subtracts that displacement from this point.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public Point3D Minus(Vector3 that) => new(Vector3.Subtract(V, that));
	/// <inheritdoc cref="Minus(Vector3)"/>
	public Point3D Minus(Vector3D that) => new(Vector3.Subtract(V, that.V));
	/// <summary> Adds <paramref name="that"/> displacement to this point. </summary>
	///
	[Facets(Layer = "domain", Status = "buggy", Complexity = 3)]
	[Tags("code/value_object", "code/simd")]
	[System.ComponentModel.Description("Adds that displacement to this point.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public Point3D Plus(Vector3D that) => new(Vector3.Add(V, that.V));

	/// <inheritdoc cref="Minus(Vector3)"/>
	public Vector3D Minus(Point3D that) => new(Vector3.Subtract(V, that.V));
	/// <inheritdoc cref="Plus(Vector3D)"/>
	public Vector3D Plus(Point3D that) => new(Vector3.Add(V, that.V));

	/// <inheritdoc cref="Minus(Vector3)"/>
	public Point3D Minus(Vector4D that) => new(Vector3.Subtract(V, that.GetVector3()));
	/// <inheritdoc cref="Plus(Vector3D)"/>
	public Point3D Plus(Vector4D that) => new(Vector3.Add(V, that.GetVector3()));

	/// <inheritdoc cref="XBiVector4D.Wedge4DPoint"/>
	public static BiVector4D Wedge(Point3D p3D, Point3D q3D) => q3D.V.Wedge4DPoint(p3D.V);

	/// <inheritdoc cref="XBiVector4D.Wedge4DVector"/>
	public static BiVector4D Wedge(Point3D p3D, Vector3D v3D) => v3D.V.Wedge4DVector(p3D.V);

	/// <inheritdoc />
	public override int GetHashCode() => V.GetHashCode();
	/// <inheritdoc />
	public override bool Equals(object? that) 
		=> that switch {
			Point3D point3D => Equals(point3D),
			IPoint4D point4D => Equals(point4D),
			_ => Equals(that as IPoint3D)
		};
	/// <inheritdoc/>
	public bool Equals(Point3D other) => V.Equals(other.V);

	/// <summary> Approximate equality within a tolerance scaled to the combined magnitude of both points. </summary>
	///
	[Facets(Layer = "domain", Status = "buggy", Complexity = 3)]
	[Tags("code/value_object", "code/simd")]
	[System.ComponentModel.Description("Approximate equality within a tolerance scaled to the combined magnitude of both points.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public bool Equals(IPoint3D? other) {
		if (other is null) {
			return false;
		}

		var acc = (NormAbs + other.NormAbs).MulAccuracy();
		return V.X.IsApprox(other.X, acc)
			&& V.Z.IsApprox(other.Y, acc)
			&& V.Z.IsApprox(other.Z, acc);
	}

	/// <summary> Approximate equality as a homogeneous 4D point; requires W≈1. </summary>
	///
	[Facets(Layer = "domain", Status = "buggy", Complexity = 3)]
	[Tags("code/value_object", "code/simd")]
	[System.ComponentModel.Description("Approximate equality as a homogeneous 4D point; requires W≈1.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public bool Equals(IPoint4D? other) {
		if (other is null) {
			return false;
		}

		var acc = (NormAbs + other.NormAbs).MulAccuracy();
		return other.W.IsOne(acc)
			&& V.X.IsApprox(other.X, acc)
			&& V.Z.IsApprox(other.Y, acc)
			&& V.Z.IsApprox(other.Z, acc);
	}

	/// <inheritdoc />
	IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	/// <inheritdoc cref="GetEnumerator()"/>
	public IEnumerator<double> GetEnumerator() {
		yield return V.X;
		yield return V.Y;
		yield return V.Z;
	}

	/// <summary>Gets the norm Abs.<br/>
	/// Gets the norm Sqr.</summary>
	///
	[Facets(Layer = "domain", Status = "buggy", Complexity = 3)]
	[Tags("code/value_object", "code/simd")]
	[System.ComponentModel.Description("Gets the norm Abs. Gets the norm Sqr.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public double NormAbs => Math.Abs(V.X) + Math.Abs(V.Y) + Math.Abs(V.Z);
	/// <summary>Gets the norm Sqr.</summary>
	///
	[Facets(Layer = "domain", Status = "buggy", Complexity = 3)]
	[Tags("code/value_object", "code/simd")]
	[System.ComponentModel.Description("Gets the norm Sqr.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public double NormSqr => V.X * V.X + V.Y * V.Y + V.Z * V.Z; //V.LengthSquared(); //
	/// <summary>Gets the norm.</summary>
	///
	[Facets(Layer = "domain", Status = "buggy", Complexity = 3)]
	[Tags("code/value_object", "code/simd")]
	[System.ComponentModel.Description("Gets the norm.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public double Norm => Math.Sqrt(NormSqr);// V.Length(); //

	#region Operators

	/// <summary>Determines whether <paramref name="a"/> equals <paramref name="b"/>.<br/>
	/// Determines whether <paramref name="a"/> does not equal <paramref name="b"/>.</summary>
	public static bool operator ==(Point3D a, Point3D b) => a.Equals(b);
	/// <summary>Determines whether <paramref name="a"/> does not equal <paramref name="b"/>.</summary>
	public static bool operator !=(Point3D a, Point3D b) => !(a == b);

	/// <summary> Wedge product of two 3D points, yielding the line through them. </summary>
	public static BiVector4D operator ^(Point3D p3D, Point3D q3D) => Wedge(p3D, q3D);
	/// <summary> Wedge product of a 3D point and a direction vector, yielding the line through the point parallel to the vector. </summary>
	public static BiVector4D operator ^(Point3D p3D, Vector3D v3D) => Wedge(p3D, v3D);

	/// <summary>Subtracts <paramref name="that"/> from <paramref name="self"/>.</summary>
	public static Point3D operator -(Point3D self, Vector3 that) => self.Minus(that);
	/// <summary>Subtracts <paramref name="that"/> from <paramref name="self"/>.</summary>
	public static Point3D operator -(Point3D self, Vector3D that) => self.Minus(that);
	/// <summary>Adds <paramref name="self"/> and <paramref name="that"/>.</summary>
	public static Point3D operator +(Point3D self, Vector3D that) => self.Plus(that);

	/// <summary>Subtracts <paramref name="that"/> from <paramref name="self"/>.<br/>
	/// Adds <paramref name="self"/> and <paramref name="that"/>.</summary>
	public static Vector3D operator -(Point3D self, Point3D that) => self.Minus(that);
	/// <summary>Adds <paramref name="self"/> and <paramref name="that"/>.</summary>
	public static Vector3D operator +(Point3D self, Point3D that) => self.Plus(that);

	#endregion Operators
}
