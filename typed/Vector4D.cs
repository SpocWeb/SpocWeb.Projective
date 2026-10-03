using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using org.SpocWeb.root.interfaces.Vectors;

namespace org.SpocWeb.root.maths.pga.typed;

/// <summary> single-precision Point-/Place-Vector in 3D, used for (Position-)Vectors in homogeneous Coordinates </summary>
/// <remarks>
/// Could also be (mis-) used to store relativistic Coordinates, but the <see cref="Norm"/> and <see cref="NormSqr"/> has to be modified then!
/// 
/// <see cref="Vector4D"/> can be scaled (unlike <see cref="IPoint4D"/>).
/// </remarks>
/// <example>
/// <code language="yaml">
/// pass: 2
/// mtime: 2026-05-24T15:36:37Z
/// digest: 8dac1d0ea6917dd16c9e77a09b23116ea052517968eb65257fb6b56760d49945
/// tags: [code/value_object, code/homogeneous_coordinates]
/// concepts: [Mathematics\Geometry\Vector.md]
/// facets: {layer: domain, status: stable, complexity: 3}
/// </code>
/// </example>
public readonly struct Vector4D : IEquatable<Vector4D>, IVector4D
{
	public readonly Vector4 V;
	/// <summary>Initializes a new instance of <see cref="Vector4D"/> with the specified <paramref name="v"/>.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/value_object, code/homogeneous_coordinates]
	/// concepts: [Mathematics\Geometry\Vector.md]
	/// facets: {layer: domain, status: stable, complexity: 3}
	/// </code>
	/// </example>
	public Vector4D(Vector4 v) => V = v;

	/// <summary>Gets the number of elements.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/value_object, code/homogeneous_coordinates]
	/// concepts: [Mathematics\Geometry\Vector.md]
	/// facets: {layer: domain, status: stable, complexity: 3}
	/// </code>
	/// </example>
	public int Count => 4;

	/// <summary>Gets the x.<br/>
	/// Gets the y.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/value_object, code/homogeneous_coordinates]
	/// concepts: [Mathematics\Geometry\Vector.md]
	/// facets: {layer: domain, status: stable, complexity: 3}
	/// </code>
	/// </example>
	public double X => V.X;
	/// <summary>Gets the y.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/value_object, code/homogeneous_coordinates]
	/// concepts: [Mathematics\Geometry\Vector.md]
	/// facets: {layer: domain, status: stable, complexity: 3}
	/// </code>
	/// </example>
	public double Y => V.Y;
	/// <summary>Gets the z.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/value_object, code/homogeneous_coordinates]
	/// concepts: [Mathematics\Geometry\Vector.md]
	/// facets: {layer: domain, status: stable, complexity: 3}
	/// </code>
	/// </example>
	public double Z => V.Z;

	/// <summary> Homogeneous Component; scales all others which can be interpreted as a Projection to the Hyper-Plane at Distance W </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/value_object, code/homogeneous_coordinates]
	/// concepts: [Mathematics\Geometry\Vector.md]
	/// facets: {layer: domain, status: stable, complexity: 3}
	/// </code>
	/// </example>
	public double W => V.W;

	/// <summary>Gets or sets the element at the specified <paramref name="index"/>.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/value_object, code/homogeneous_coordinates]
	/// concepts: [Mathematics\Geometry\Vector.md]
	/// facets: {layer: domain, status: stable, complexity: 3}
	/// </code>
	/// </example>
	public double this[int index] => index switch {
		0 => V.X,
		1 => V.Y,
		2 => V.Z,
		3 => V.W,
		_ => throw new ArgumentOutOfRangeException(nameof(index), index, null)
	};

	/// <summary>Initializes a new instance of <see cref="Vector4D"/> with the specified <paramref name="x"/>, <paramref name="y"/>, <paramref name="z"/> and <paramref name="w"/>.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/value_object, code/homogeneous_coordinates]
	/// concepts: [Mathematics\Geometry\Vector.md]
	/// facets: {layer: domain, status: stable, complexity: 3}
	/// </code>
	/// </example>
	public Vector4D(float x, float y, float z, float w) => V = new Vector4(x, y, z, w);

	/// <summary>Initializes a new instance of <see cref="Vector4D"/> with the specified <paramref name="x"/>, <paramref name="y"/>, <paramref name="z"/> and <paramref name="w"/>.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/value_object, code/homogeneous_coordinates]
	/// concepts: [Mathematics\Geometry\Vector.md]
	/// facets: {layer: domain, status: stable, complexity: 3}
	/// </code>
	/// </example>
	public Vector4D(double x, double y, double z, double w) 
		=> V = new Vector4((float) x, (float) y, (float) z, (float) w);

	/// <summary>Initializes a new instance of <see cref="Vector4D"/> with the specified <paramref name="v"/> and <paramref name="w"/>.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/value_object, code/homogeneous_coordinates]
	/// concepts: [Mathematics\Geometry\Vector.md]
	/// facets: {layer: domain, status: stable, complexity: 3}
	/// </code>
	/// </example>
	public Vector4D(Vector3D v, float w = 0) {
		V.X = v.V.X;
		V.Y = v.V.Y;
		V.Z = v.V.Z;
		V.W = w;
	}

	/// <summary>Initializes a new instance of <see cref="Vector4D"/> with the specified <paramref name="v1"/> and <paramref name="v2"/>.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/value_object, code/homogeneous_coordinates]
	/// concepts: [Mathematics\Geometry\Vector.md]
	/// facets: {layer: domain, status: stable, complexity: 3}
	/// </code>
	/// </example>
	public Vector4D(Vector2D v1, Vector2D v2) {
		V.X = v1.V.X;
		V.Y = v1.V.Y;
		V.Z = v2.V.X;
		V.W = v2.V.Y;
	}

	/// <summary>Initializes a new instance of <see cref="Vector4D"/> with the specified <paramref name="p"/>.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/value_object, code/homogeneous_coordinates]
	/// concepts: [Mathematics\Geometry\Vector.md]
	/// facets: {layer: domain, status: stable, complexity: 3}
	/// </code>
	/// </example>
	public Vector4D(Point3D p) {
		V.X = p.V.X;
		V.Y = p.V.Y;
		V.Z = p.V.Z;
		V.W = 1;
	}

	/// <summary>Initializes a new instance of <see cref="Vector4D"/> with the specified <paramref name="p"/>.<br/>
	/// Initializes a new instance of <see cref="Vector4D"/> with the specified <paramref name="p"/>.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/value_object, code/homogeneous_coordinates]
	/// concepts: [Mathematics\Geometry\Vector.md]
	/// facets: {layer: domain, status: stable, complexity: 3}
	/// </code>
	/// </example>
	public Vector4D(Vector3D p) : this(p.V){}
	/// <summary>Initializes a new instance of <see cref="Vector4D"/> with the specified <paramref name="p"/>.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/value_object, code/homogeneous_coordinates]
	/// concepts: [Mathematics\Geometry\Vector.md]
	/// facets: {layer: domain, status: stable, complexity: 3}
	/// </code>
	/// </example>
	public Vector4D(Vector3 p) {
		V.X = p.X;
		V.Y = p.Y;
		V.Z = p.Z;
		V.W = 0;
	}

	/// <summary>Initializes a new instance of <see cref="Vector4D"/> with the specified <paramref name="v"/>.<br/>
	/// Initializes a new instance of <see cref="Vector4D"/> with the specified <paramref name="v"/>.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/value_object, code/homogeneous_coordinates]
	/// concepts: [Mathematics\Geometry\Vector.md]
	/// facets: {layer: domain, status: stable, complexity: 3}
	/// </code>
	/// </example>
	public Vector4D(Vector2D v) : this(v.V) {}
	/// <summary>Initializes a new instance of <see cref="Vector4D"/> with the specified <paramref name="v"/>.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/value_object, code/homogeneous_coordinates]
	/// concepts: [Mathematics\Geometry\Vector.md]
	/// facets: {layer: domain, status: stable, complexity: 3}
	/// </code>
	/// </example>
	public Vector4D(Vector2 v) {
		V.X = v.X;
		V.Y = v.Y;
		V.Z = V.W = 0.0F;
	}

	/// <summary>Initializes a new instance of <see cref="Vector4D"/> with the specified <paramref name="p"/>.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/value_object, code/homogeneous_coordinates]
	/// concepts: [Mathematics\Geometry\Vector.md]
	/// facets: {layer: domain, status: stable, complexity: 3}
	/// </code>
	/// </example>
	public Vector4D(Point2D p) {
		V.X = p.V.X;
		V.Y = p.V.Y;
		V.Z = 0;
		V.W = 1;
	}

	/// <summary> Projects the homogeneous vector to a 3D point by dividing by W. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/value_object, code/homogeneous_coordinates]
	/// concepts: [Mathematics\Geometry\Vector.md]
	/// facets: {layer: domain, status: stable, complexity: 3}
	/// </code>
	/// </example>
	public Point3D GetPoint3D() => new(GetVector3());

	/// <summary> Divides X, Y, Z by W to obtain the equivalent affine <see cref="Vector3"/>. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/value_object, code/homogeneous_coordinates]
	/// concepts: [Mathematics\Geometry\Vector.md]
	/// facets: {layer: domain, status: stable, complexity: 3}
	/// </code>
	/// </example>
	public Vector3 GetVector3() {
		var s = 1 / V.W;
		return new Vector3(V.X * s, V.Y * s, V.Z * s);
	}

	/// <summary> Rotates this vector counter-clockwise by <paramref name="angle"/> radians about the X axis. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/value_object, code/homogeneous_coordinates]
	/// concepts: [Mathematics\Geometry\Vector.md]
	/// facets: {layer: domain, status: stable, complexity: 3}
	/// </code>
	/// </example>
	public Vector4D RotateAboutX(float angle) {
		var v = Vector2D.CosSin(angle).V;
		var ny = v.X * V.Y - v.Y * V.Z;
		var nz = v.X * V.Z + v.Y * V.Y;
		return new Vector4D(V.X, ny, nz, V.W);
	}

	/// <summary> Rotates this vector counter-clockwise by <paramref name="angle"/> radians about the Y axis. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/value_object, code/homogeneous_coordinates]
	/// concepts: [Mathematics\Geometry\Vector.md]
	/// facets: {layer: domain, status: stable, complexity: 3}
	/// </code>
	/// </example>
	public Vector4D RotateAboutY(float angle) {
		var v = Vector2D.CosSin(angle).V;
		var nx = v.X * V.X + v.Y * V.Z;
		var nz = v.X * V.Z - v.Y * V.X;
		return new Vector4D(nx, V.Y, nz, V.W);
	}

	/// <summary> Rotates this vector counter-clockwise by <paramref name="angle"/> radians about the Z axis. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/value_object, code/homogeneous_coordinates]
	/// concepts: [Mathematics\Geometry\Vector.md]
	/// facets: {layer: domain, status: stable, complexity: 3}
	/// </code>
	/// </example>
	public Vector4D RotateAboutZ(float angle) {
		var v = Vector2D.CosSin(angle).V;
		var nx = v.X * V.X - v.Y * V.Y;
		var ny = v.X * V.Y + v.Y * V.X;
		return new Vector4D(nx, ny, V.Z, V.W);
	}

	/// <summary> Rotates this vector by <paramref name="angle"/> radians about the arbitrary axis <paramref name="a"/>
	/// using the Rodrigues rotation formula. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/value_object, code/homogeneous_coordinates]
	/// concepts: [Mathematics\Geometry\Vector.md]
	/// facets: {layer: domain, status: stable, complexity: 3}
	/// </code>
	/// </example>
	public Vector4D RotateAboutAxis(float angle, BiVector3D a) {
		var v = Vector2D.CosSin(angle).V;
		var u = 1.0F - v.X;
		var axis = a.V3;

		var nx = V.X * (v.X + u * axis.X * axis.X) + V.Y * (u * axis.X * axis.Y - v.Y * axis.Z) +
		         V.Z * (u * axis.X * axis.Z + v.Y * axis.Y);
		var ny = V.X * (u * axis.X * axis.Y + v.Y * axis.Z) + V.Y * (v.X + u * axis.Y * axis.Y) +
		         V.Z * (u * axis.Y * axis.Z - v.Y * axis.X);
		var nz = V.X * (u * axis.X * axis.Z - v.Y * axis.Y) + V.Y * (u * axis.Y * axis.Z + v.Y * axis.X) +
		         V.Z * (v.X + u * axis.Z * axis.Z);

		return new Vector4D(nx, ny, nz, V.W);
	}

	/// <inheritdoc />
	public bool Equals(Vector4D other) => V.Equals(other.V);

	/// <summary> Enumerates the four components X, Y, Z, W in order. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/value_object, code/homogeneous_coordinates]
	/// concepts: [Mathematics\Geometry\Vector.md]
	/// facets: {layer: domain, status: stable, complexity: 3}
	/// </code>
	/// </example>
	public IEnumerator<double> GetEnumerator() {
		yield return V.X;
		yield return V.Y;
		yield return V.Z;
		yield return V.W;
	}

	/// <inheritdoc cref="Equals(Vector4D)"/>
	public override bool Equals(object? obj) => obj is Vector4D other && Equals(other);

	/// <inheritdoc cref="GetEnumerator()"/>
	IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	/// <inheritdoc />
	public override int GetHashCode() => V.GetHashCode();

	#region Operators

	/// <summary>Determines whether <paramref name="a"/> equals <paramref name="b"/>.<br/>
	/// Determines whether <paramref name="a"/> does not equal <paramref name="b"/>.</summary>
	public static bool operator ==(Vector4D a, Vector4D b) => a.Equals(b);
	/// <summary>Determines whether <paramref name="a"/> does not equal <paramref name="b"/>.</summary>
	public static bool operator !=(Vector4D a, Vector4D b) => !(a == b);

	/// <summary>Negates <paramref name="v"/>.</summary>
	public static Vector4D operator -(Vector4D v) => v.Neg();

	//public static Vector4D operator ~(Vector4D v) => v.Cjg();
	//public static Vector4D operator !(Vector4D v) => v.Rcp();

	//public static Point3D operator *(Point3D p, Vector4D v) => v.Times(p);
	//public static Point3D operator *(Vector4D v, Point3D p) => v.Times(p);

	/// <summary>Multiplies <paramref name="scalar"/> by <paramref name="v"/>.<br/>
	/// Multiplies <paramref name="v"/> by <paramref name="scalar"/>.</summary>
	public static Vector4D operator *(double scalar, Vector4D v) => v.Times(scalar);
	/// <summary>Multiplies <paramref name="v"/> by <paramref name="scalar"/>.</summary>
	public static Vector4D operator *(Vector4D v, double scalar) => v.Times(scalar);
	/// <summary>Divides <paramref name="v"/> by <paramref name="scalar"/>.</summary>
	public static Vector4D operator /(Vector4D v, double scalar) => v.Per(scalar);

	/// <summary>Adds <paramref name="p"/> and <paramref name="v"/>.</summary>
	public static Vector4D operator +(Vector4D p, Vector4D v) => v.Plus(p);

	/// <summary>Adds <paramref name="p"/> and <paramref name="v"/>.<br/>
	/// Adds <paramref name="v"/> and <paramref name="p"/>.</summary>
	public static Vector4D operator +(Vector3D p, Vector4D v) => p.Plus(v);
	/// <summary>Adds <paramref name="v"/> and <paramref name="p"/>.</summary>
	public static Vector4D operator +(Vector4D v, Vector3D p) => p.Plus(v);

	//public static Point3D operator +(Point3D p, Vector4D v) => p.Plus(v);
	//public static Point3D operator +(Vector4D v, Point3D p) => p.Plus(v);

	/// <summary>Subtracts <paramref name="v"/> from <paramref name="p"/>.</summary>
	public static Vector4D operator -(Vector4D p, Vector4D v) => v.Minus(p);

	/// <summary>Subtracts <paramref name="v"/> from <paramref name="p"/>.<br/>
	/// Subtracts <paramref name="p"/> from <paramref name="v"/>.</summary>
	public static Vector4D operator -(Vector3D p, Vector4D v) => p.Minus(v);
	/// <summary>Subtracts <paramref name="p"/> from <paramref name="v"/>.</summary>
	public static Vector4D operator -(Vector4D v, Vector3D p) => p.Minus(v);

	//public static Point3D operator -(Point3D p, Vector4D v) => p.Minus(v);
	//public static Point3D operator -(Vector4D v, Point3D p) => p.Minus(v);

	///// <summary> Wedge/Meet/Cross/outer Product </summary>
	///// <remarks>
	///// Unfortunately the ^ Operator has the lowest Precedence, so you have to bracket the Product.
	///// </remarks>
	//public static Vector4D operator ^(Vector4D a, Vector4D b) => a.Cross(b);
	/// <summary>Multiplies <paramref name="a"/> by <paramref name="b"/>.</summary>
	public static double operator *(Vector4D a, Vector4D b) => a.Dot(b);
	//public static Vector4D operator *(Vector4D p, Vector4D v) => new(v.V * p.V);

	#endregion Operators

	/// <summary>Gets the norm Abs.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/value_object, code/homogeneous_coordinates]
	/// concepts: [Mathematics\Geometry\Vector.md]
	/// facets: {layer: domain, status: stable, complexity: 3}
	/// </code>
	/// </example>
	public double NormAbs => V.NormAbs();
	/// <inheritdoc />
	double INormed.NormSqr => NormSqr;

	/// <summary>Gets the norm Sqr.<br/>
	/// Gets the norm.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/value_object, code/homogeneous_coordinates]
	/// concepts: [Mathematics\Geometry\Vector.md]
	/// facets: {layer: domain, status: stable, complexity: 3}
	/// </code>
	/// </example>
	public float NormSqr => V.NormSqr();
	/// <summary>Gets the norm.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/value_object, code/homogeneous_coordinates]
	/// concepts: [Mathematics\Geometry\Vector.md]
	/// facets: {layer: domain, status: stable, complexity: 3}
	/// </code>
	/// </example>
	public double Norm => V.Norm();

	/// <summary> Squared Euclidean length of the bulk (X, Y, Z) components only. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/value_object, code/homogeneous_coordinates]
	/// concepts: [Mathematics\Geometry\Vector.md]
	/// facets: {layer: domain, status: stable, complexity: 3}
	/// </code>
	/// </example>
	public double BulkNormSqr() => V.X * V.X + V.Y * V.Y + V.Z * V.Z;

	/// <summary> Euclidean length of the bulk (X, Y, Z) components only. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/value_object, code/homogeneous_coordinates]
	/// concepts: [Mathematics\Geometry\Vector.md]
	/// facets: {layer: domain, status: stable, complexity: 3}
	/// </code>
	/// </example>
	public double BulkNorm() => Math.Sqrt(BulkNormSqr());

	/// <summary> Absolute value of the homogeneous weight component W. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/value_object, code/homogeneous_coordinates]
	/// concepts: [Mathematics\Geometry\Vector.md]
	/// facets: {layer: domain, status: stable, complexity: 3}
	/// </code>
	/// </example>
	public float WeightNorm() => Math.Abs(V.W);


	//public Vector4D Cjg() => new(new Vector4(V.X, -V.Y));
	/// <summary> Additive inverse of this vector. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/value_object, code/homogeneous_coordinates]
	/// concepts: [Mathematics\Geometry\Vector.md]
	/// facets: {layer: domain, status: stable, complexity: 3}
	/// </code>
	/// </example>
	public Vector4D Neg() => new(Vector4.Negate(V));
	/// <summary>Gets the normalized.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/value_object, code/homogeneous_coordinates]
	/// concepts: [Mathematics\Geometry\Vector.md]
	/// facets: {layer: domain, status: stable, complexity: 3}
	/// </code>
	/// </example>
	public Vector4D Normalized => new(Vector4.Normalize(V));

	/// <summary> Divides X, Y, Z by W so that the homogeneous weight equals 1. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/value_object, code/homogeneous_coordinates]
	/// concepts: [Mathematics\Geometry\Vector.md]
	/// facets: {layer: domain, status: stable, complexity: 3}
	/// </code>
	/// </example>
	public Vector4D Unitized() => new(GetPoint3D());

	/// <summary> Grade-reverse of this vector (identity for grade-1 elements). </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/value_object, code/homogeneous_coordinates]
	/// concepts: [Mathematics\Geometry\Vector.md]
	/// facets: {layer: domain, status: stable, complexity: 3}
	/// </code>
	/// </example>
	public Vector4D Reverse() => this;

	/// <summary> Anti-reverse of this vector (negation for grade-1 elements). </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/value_object, code/homogeneous_coordinates]
	/// concepts: [Mathematics\Geometry\Vector.md]
	/// facets: {layer: domain, status: stable, complexity: 3}
	/// </code>
	/// </example>
	public Vector4D AntiReverse() => Neg();


	/// <summary> Returns the component-wise sum of this vector and <paramref name="that"/>. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/value_object, code/homogeneous_coordinates]
	/// concepts: [Mathematics\Geometry\Vector.md]
	/// facets: {layer: domain, status: stable, complexity: 3}
	/// </code>
	/// </example>
	public Vector4D Plus(Vector4D that) => new(Vector4.Add(V, that.V));

	//public Point3D Plus(Point3D that) => new(Plus(that.V));
	/// <inheritdoc cref="Plus(Vector4D)"/>
	public Vector4D Plus(Vector3D that) => new(Plus(that.V));
	/// <inheritdoc cref="Plus(Vector4D)"/>
	public Vector4 Plus(Vector3 that) => new(V.X + that.X, V.Y + that.Y, V.Z + that.Z, V.W);
	/// <inheritdoc cref="Plus(Vector4D)"/>
	public Vector4D Plus(Vector2D that) => new(Plus(that.V));
	/// <inheritdoc cref="Plus(Vector4D)"/>
	public Vector4 Plus(Vector2 that) => new(V.X + that.X, V.Y + that.Y, V.Z, V.W);

	/// <summary> Returns the component-wise difference of this vector minus <paramref name="that"/>. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/value_object, code/homogeneous_coordinates]
	/// concepts: [Mathematics\Geometry\Vector.md]
	/// facets: {layer: domain, status: stable, complexity: 3}
	/// </code>
	/// </example>
	public Vector4D Minus(Vector4D that) => new(Vector4.Subtract(V, that.V));

	//public Point3D Minus(Point3D that) => new(Minus(that.V));
	/// <summary> Returns <paramref name="that"/> minus this vector (reversed subtraction). </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/value_object, code/homogeneous_coordinates]
	/// concepts: [Mathematics\Geometry\Vector.md]
	/// facets: {layer: domain, status: stable, complexity: 3}
	/// </code>
	/// </example>
	public Vector4D MinusR(Vector3D that) => new(MinusR(that.V));
	/// <inheritdoc cref="Minus(Vector4D)"/>
	public Vector4D Minus(Vector3D that) => new(Minus(that.V));
	/// <inheritdoc cref="Minus(Vector4D)"/>
	public Vector4D Minus(Vector2D that) => new(Minus(that.V));
	/// <inheritdoc cref="MinusR(Vector3D)"/>
	public Vector4 MinusR(Vector3 that) => new(that.X - V.X, that.Y - V.Y, that.Z - V.Z, -V.W);
	/// <inheritdoc cref="Minus(Vector4D)"/>
	public Vector4 Minus(Vector3 that) => new(V.X - that.X, V.Y - that.Y, V.Z - that.Z, V.W);
	/// <inheritdoc cref="Minus(Vector4D)"/>
	public Vector4 Minus(Vector2 that) => new(V.X - that.X, V.Y - that.Y, V.Z, V.W);

	/// <summary> Returns this vector divided by <paramref name="scalar"/>. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/value_object, code/homogeneous_coordinates]
	/// concepts: [Mathematics\Geometry\Vector.md]
	/// facets: {layer: domain, status: stable, complexity: 3}
	/// </code>
	/// </example>
	public Vector4D Per(double scalar) => new(V * (float) (1 / scalar));

	/// <summary> Returns this vector scaled by <paramref name="scalar"/>. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/value_object, code/homogeneous_coordinates]
	/// concepts: [Mathematics\Geometry\Vector.md]
	/// facets: {layer: domain, status: stable, complexity: 3}
	/// </code>
	/// </example>
	public Vector4D Times(double scalar) => new(V * (float) scalar);

	///// <summary> Component-wise Multiplication </summary>
	//public Point3D Times(Point3D p) => new(V * p.V);

	///// <summary> AKA AntiWedge; anti-symmetric Cross Product </summary>
	//public Vector4D Cross(Vector4D that) => new(Vector4.Cross(V, that.V));
	// var b = that.V;
	// return new Vector4D(V.Y * b.Z - V.Z * b.Y, V.Z * b.X - V.X * b.Z, V.X * b.Y - V.Y * b.X);

	/// <summary> symmetric Dot Product, actually a geometric Wedge-Product with the Anti-Vector of <paramref name="that"/> </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/value_object, code/homogeneous_coordinates]
	/// concepts: [Mathematics\Geometry\Vector.md]
	/// facets: {layer: domain, status: stable, complexity: 3}
	/// </code>
	/// </example>
	public double Dot(Vector4D that) => Dot(that.V);

	/// <inheritdoc cref="Dot(Vector4D)"/>
	public double Dot(Vector3D that) => Dot(that.V);
	/// <inheritdoc cref="Dot(Vector4D)"/>
	public double Dot(Vector2D that) => Dot(that.V);
	/// <inheritdoc cref="Dot(Vector4D)"/>
	public double Dot(Point3D that) => Dot(that.V);
	/// <inheritdoc cref="Dot(Vector4D)"/>
	public double Dot(Point2D that) => Dot(that.V);
	/// <inheritdoc cref="Dot(Vector4D)"/>
	public double Dot(Vector4 that) => Vector4.Dot(V, that);
	/// <inheritdoc cref="Dot(Vector4D)"/>
	public double Dot(Vector3 that) => V.X * that.X + V.Y * that.Y + V.Z * that.Z;
	/// <inheritdoc cref="Dot(Vector4D)"/>
	public double Dot(Vector2 that) => V.X * that.X + V.Y * that.Y;

	/// <summary> Component-wise Multiplication </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/value_object, code/homogeneous_coordinates]
	/// concepts: [Mathematics\Geometry\Vector.md]
	/// facets: {layer: domain, status: stable, complexity: 3}
	/// </code>
	/// </example>
	public Vector4D Times(Vector4D p) => new(V * p.V);

	/// <summary> Non-normalized Projection in <paramref name="that"/> Direction </summary>
	/// <returns>the Projection of this Vector onto <paramref name="that"/></returns>
	/// <remarks>
	/// this == <see cref="ProjectOn"/>(that) + <see cref="RejectFrom"/>(that)
	/// </remarks>
	/// <example>
	/// <code language="yaml">
	/// tags: [code/value_object, code/homogeneous_coordinates]
	/// concepts: [Mathematics\Geometry\Vector.md]
	/// facets: {layer: domain, status: stable, complexity: 3}
	/// </code>
	/// </example>
	public Vector4D ProjectOn(Vector4D that) => that * Dot(that);

	/// <summary> Non-normalized Rejection from <paramref name="that"/> Direction </summary>
	/// <returns>the orthogonal Component of this Vector from <paramref name="that"/></returns>
	/// <remarks>
	/// this == <see cref="ProjectOn"/>(that) + <see cref="RejectFrom"/>(that)
	/// </remarks>
	/// <example>
	/// <code language="yaml">
	/// tags: [code/value_object, code/homogeneous_coordinates]
	/// concepts: [Mathematics\Geometry\Vector.md]
	/// facets: {layer: domain, status: stable, complexity: 3}
	/// </code>
	/// </example>
	public Vector4D RejectFrom(Vector4D that) => new(V - that.V * Vector4.Dot(V, that.V));

	/// <summary> Returns a new vector with each component rounded down to the nearest integer. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/value_object, code/homogeneous_coordinates]
	/// concepts: [Mathematics\Geometry\Vector.md]
	/// facets: {layer: domain, status: stable, complexity: 3}
	/// </code>
	/// </example>
	public Vector4D Floor() => new(Math.Floor(V.X), Math.Floor(V.Y), Math.Floor(V.Z), Math.Floor(V.W));
	/// <summary> Returns a new vector with each component rounded up to the nearest integer. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/value_object, code/homogeneous_coordinates]
	/// concepts: [Mathematics\Geometry\Vector.md]
	/// facets: {layer: domain, status: stable, complexity: 3}
	/// </code>
	/// </example>
	public Vector4D Ceil() => new(Math.Ceiling(V.X), Math.Ceiling(V.Y), Math.Ceiling(V.Z), Math.Ceiling(V.W));

}
