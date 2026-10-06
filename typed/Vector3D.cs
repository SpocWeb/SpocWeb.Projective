using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using org.SpocWeb.root.extensions.maths;
using org.SpocWeb.root.interfaces.maths;
using org.SpocWeb.root.interfaces.Vectors;
using org.SpocWeb.root.Attributes;

namespace org.SpocWeb.root.maths.pga.typed;

/// <summary> <see cref="Vector3"/>-backed immutable 3D direction vector that implements <see cref="IVector4D"/>
/// with W = 0, supporting rotations, projection, rejection, and standard arithmetic. </summary>
/// <remarks>
/// ## Public Methods
///
/// | Line | Method | Description |
/// |--:|---|---|
/// | 75 | <see cref="Count"/> | Gets the number of elements. |
/// | 84 | <see cref="X"/> | Gets the x. |
/// | 91 | <see cref="Y"/> | Gets the y. |
/// | 98 | <see cref="Z"/> | Gets the z. |
/// | 105 | <see cref="W"/> | Gets the w. |
/// | 113 | <see cref="this[]"/> | Gets or sets the element at the specified index. |
/// | 127 | <see cref="Vector3D"/> | Initializes a new instance of Vector3D with the specified v. |
/// | 136 | <see cref="Vector3D"/> | Initializes a new instance of Vector3D with the specified x, y and z. |
/// | 143 | <see cref="Vector3D"/> | Initializes a new instance of Vector3D with the specified x, y and z. |
/// | 270 | <see cref="operator !"/> | Returns the Complement/Dual of the vector v. |
/// | 273 | <see cref="operator -"/> | Negates v. |
/// | 280 | <see cref="operator *"/> | Multiplies p by v. |
/// | 282 | <see cref="operator *"/> | Multiplies v by scalar. |
/// | 286 | <see cref="operator *"/> | Multiplies scalar by v. |
/// | 288 | <see cref="operator *"/> | Multiplies v by scalar. |
/// | 290 | <see cref="operator /"/> | Divides v by scalar. |
/// | 294 | <see cref="operator +"/> | Adds p and v. |
/// | 296 | <see cref="operator +"/> | Adds v and p. |
/// | 299 | <see cref="operator +"/> | Adds p and v. |
/// | 303 | <see cref="operator -"/> | Subtracts v from p. |
/// | 305 | <see cref="operator -"/> | Subtracts p from v. |
/// | 308 | <see cref="operator -"/> | Subtracts v from p. |
/// | 315 | <see cref="operator ^"/> | Wedge/Meet/Cross/outer Product |
/// | 318 | <see cref="operator *"/> | Multiplies a by b. |
/// | 323 | <see cref="operator =="/> | Determines whether a equals b. |
/// | 325 | <see cref="operator !="/> | Determines whether a does not equal b. |
/// | 332 | <see cref="NormAbs"/> | Gets the norm Abs. |
/// | 339 | <see cref="NormSqr"/> | Gets the norm Sqr. |
/// | 346 | <see cref="Norm"/> | Gets the norm. |
/// | 370 | <see cref="Normalized"/> | Gets the normalized. |
///
/// ## Collaborators
///
/// | Type | Role |
/// |---|---|
/// | <see cref="Vector3"/> | Used as a field. |
/// | <see cref="Vector3D"/> | Returned by a method. |
/// | <see cref="BiVector3D"/> | Passed as a parameter. |
/// | <see cref="IVector3D"/> | Passed as a parameter. |
/// | <see cref="IVector4D"/> | Passed as a parameter. |
/// | <see cref="IEnumerator"/> | Returned by a method. |
/// | <see cref="Point3D"/> | Returned by a method. |
/// | <see cref="Vector4D"/> | Returned by a method. |
/// </remarks>
///
[DocState(Pass = 2, MTime = "2026-05-24T15:36:37Z", Digest = "1f6e3ce7b150be66688fb0d0e14ea43dbb05aee539ba41baf5e90f3f1b8c7192", Stale = false, Path = "typed/Vector3D.cs", Since = "2026-10-06")]
[Facets(Layer = "domain", Status = "buggy", Complexity = 3)]
[Tags("code/value_object", "code/vector_math")]
[System.ComponentModel.Description("Vector3-backed immutable 3D direction vector that implements IVector4D with W = 0, supporting rotations, projection, rejection, and standard arithmetic.")]
[Concept("Mathematics\\Geometry\\Vector.md")]
public readonly struct Vector3D : IEquatable<Vector3D>, IVector3D, IVector4D
{
	public readonly Vector3 V;

	/// <summary>Gets the number of elements.</summary>
	///
	[Facets(Layer = "domain", Status = "buggy", Complexity = 3)]
	[Tags("code/value_object", "code/vector_math")]
	[System.ComponentModel.Description("Gets the number of elements.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public int Count => 3;

	/// <summary>Gets the x.<br/>
	/// Gets the y.</summary>
	///
	[Facets(Layer = "domain", Status = "buggy", Complexity = 3)]
	[Tags("code/value_object", "code/vector_math")]
	[System.ComponentModel.Description("Gets the x. Gets the y.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public double X => V.X;
	/// <summary>Gets the y.</summary>
	///
	[Facets(Layer = "domain", Status = "buggy", Complexity = 3)]
	[Tags("code/value_object", "code/vector_math")]
	[System.ComponentModel.Description("Gets the y.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public double Y => V.Y;
	/// <summary>Gets the z.</summary>
	///
	[Facets(Layer = "domain", Status = "buggy", Complexity = 3)]
	[Tags("code/value_object", "code/vector_math")]
	[System.ComponentModel.Description("Gets the z.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public double Z => V.Z;
	/// <summary>Gets the w.</summary>
	///
	[Facets(Layer = "domain", Status = "buggy", Complexity = 3)]
	[Tags("code/value_object", "code/vector_math")]
	[System.ComponentModel.Description("Gets the w.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public double W => 0;

	/// <summary>Gets or sets the element at the specified <paramref name="index"/>.</summary>
	///
	[Facets(Layer = "domain", Status = "buggy", Complexity = 3)]
	[Tags("code/value_object", "code/vector_math")]
	[System.ComponentModel.Description("Gets or sets the element at the specified index.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public double this[int index] => index switch {
			0 => V.X,
			1 => V.Y,
			2 => V.Z,
			3 => 0,
			_ => throw new ArgumentOutOfRangeException(nameof(index), index, null)
		};

	/// <summary>Initializes a new instance of <see cref="Vector3D"/> with the specified <paramref name="v"/>.</summary>
	///
	[Facets(Layer = "domain", Status = "buggy", Complexity = 3)]
	[Tags("code/value_object", "code/vector_math")]
	[System.ComponentModel.Description("Initializes a new instance of Vector3D with the specified v.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public Vector3D(Vector3 v) => V = v;

	/// <summary>Initializes a new instance of <see cref="Vector3D"/> with the specified <paramref name="x"/>, <paramref name="y"/> and <paramref name="z"/>.<br/>
	/// Initializes a new instance of <see cref="Vector3D"/> with the specified <paramref name="x"/>, <paramref name="y"/> and <paramref name="z"/>.</summary>
	///
	[Facets(Layer = "domain", Status = "buggy", Complexity = 3)]
	[Tags("code/value_object", "code/vector_math")]
	[System.ComponentModel.Description("Initializes a new instance of Vector3D with the specified x, y and z. Initializes a new instance of Vector3D with the specified x, y and z.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public Vector3D(float x, float y, float z) => V = new Vector3(x, y, z);
	/// <summary>Initializes a new instance of <see cref="Vector3D"/> with the specified <paramref name="x"/>, <paramref name="y"/> and <paramref name="z"/>.</summary>
	///
	[Facets(Layer = "domain", Status = "buggy", Complexity = 3)]
	[Tags("code/value_object", "code/vector_math")]
	[System.ComponentModel.Description("Initializes a new instance of Vector3D with the specified x, y and z.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public Vector3D(double x, double y, double z) => V = new Vector3((float) x, (float) y, (float) z);

	/// <summary> Rotates this vector counter-clockwise by <paramref name="angle"/> radians about the X axis. </summary>
	///
	[Facets(Layer = "domain", Status = "buggy", Complexity = 3)]
	[Tags("code/value_object", "code/vector_math")]
	[System.ComponentModel.Description("Rotates this vector counter-clockwise by angle radians about the X axis.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public Vector3D RotateAboutX(float angle)
	{
		var v = Vector2D.CosSin(angle).V;
		var ny = v.X * V.Y - v.Y * V.Z;
		var nz = v.X * V.Z + v.Y * V.Y;
		return new Vector3D(V.X, ny, nz);
	}

	/// <summary> Rotates this vector counter-clockwise by <paramref name="angle"/> radians about the Y axis. </summary>
	///
	[Facets(Layer = "domain", Status = "buggy", Complexity = 3)]
	[Tags("code/value_object", "code/vector_math")]
	[System.ComponentModel.Description("Rotates this vector counter-clockwise by angle radians about the Y axis.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public Vector3D RotateAboutY(float angle)
	{
		var v = Vector2D.CosSin(angle).V;
		var nx = v.X * V.X + v.Y * V.Z;
		var nz = v.X * V.Z - v.Y * V.X;
		return new Vector3D(nx, V.Y, nz);
	}

	/// <summary> Rotates this vector counter-clockwise by <paramref name="angle"/> radians about the Z axis. </summary>
	///
	[Facets(Layer = "domain", Status = "buggy", Complexity = 3)]
	[Tags("code/value_object", "code/vector_math")]
	[System.ComponentModel.Description("Rotates this vector counter-clockwise by angle radians about the Z axis.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public Vector3D RotateAboutZ(float angle)
	{
		var v = Vector2D.CosSin(angle).V;
		var nx = v.X * V.X - v.Y * V.Y;
		var ny = v.X * V.Y + v.Y * V.X;
		return new Vector3D(nx, ny, V.Z);
	}

	/// <summary> Rotates this vector by <paramref name="angle"/> radians about the arbitrary axis <paramref name="a"/>
	/// using the Rodrigues rotation formula. </summary>
	///
	[Facets(Layer = "domain", Status = "buggy", Complexity = 3)]
	[Tags("code/value_object", "code/vector_math")]
	[System.ComponentModel.Description("Rotates this vector by angle radians about the arbitrary axis a using the Rodrigues rotation formula.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public Vector3D RotateAboutAxis(float angle, BiVector3D a)
	{
		var v = Vector2D.CosSin(angle).V;
		var u = 1.0F - v.X;
		var axis = a.V3;

		var nx = V.X * (v.X + u * axis.X * axis.X) + V.Y * (u * axis.X * axis.Y - v.Y * axis.Z) + V.Z * (u * axis.X * axis.Z + v.Y * axis.Y);
		var ny = V.X * (u * axis.X * axis.Y + v.Y * axis.Z) + V.Y * (v.X + u * axis.Y * axis.Y) + V.Z * (u * axis.Y * axis.Z - v.Y * axis.X);
		var nz = V.X * (u * axis.X * axis.Z - v.Y * axis.Y) + V.Y * (u * axis.Y * axis.Z + v.Y * axis.X) + V.Z * (v.X + u * axis.Z * axis.Z);

		return new Vector3D(nx, ny,nz);
	}

	/// <inheritdoc />
	public override int GetHashCode() => V.GetHashCode();
	/// <inheritdoc />
	public override bool Equals(object? that) 
		=> that switch {
			Vector3D vector3D => Equals(vector3D),
			IVector4D vector4D => Equals(vector4D),
			_ => Equals(that as IVector3D)
		};
	/// <inheritdoc/>
	public bool Equals(Vector3D other) => V.Equals(other.V);

	/// <summary> Approximate equality within a tolerance scaled to the combined magnitude of both vectors. </summary>
	///
	[Facets(Layer = "domain", Status = "buggy", Complexity = 3)]
	[Tags("code/value_object", "code/vector_math")]
	[System.ComponentModel.Description("Approximate equality within a tolerance scaled to the combined magnitude of both vectors.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public bool Equals(IVector3D? other) {
		if (other is null) {
			return false;
		}

		var acc = (NormAbs + other.NormAbs).MulAccuracy();
		return V.X.IsApprox(other.X, acc)
			&& V.Z.IsApprox(other.Y, acc)
			&& V.Z.IsApprox(other.Z, acc);
	}

	/// <summary> Approximate equality; treats a non-zero W component as inequality (direction vs. point). </summary>
	///
	[Facets(Layer = "domain", Status = "buggy", Complexity = 3)]
	[Tags("code/value_object", "code/vector_math")]
	[System.ComponentModel.Description("Approximate equality; treats a non-zero W component as inequality (direction vs. point).")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public bool Equals(IVector4D? other) {
		if (other is null) {
			return false;
		}

		var acc = (NormAbs + other.NormAbs).MulAccuracy();
		return other.W.IsSmallerThan(acc) 
			&& V.X.IsApprox(other.X, acc)
			&& V.Z.IsApprox(other.Y, acc)
			&& V.Z.IsApprox(other.Z, acc);
	}

	/// <inheritdoc />
	IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	/// <inheritdoc cref="GetEnumerator()"/>
	public IEnumerator<double> GetEnumerator() {
		yield return X;
		yield return Y;
		yield return Z;
	}

	#region Operators

	/// <summary> 	Returns the Complement/Dual of the vector v.	 </summary>
	public static BiVector3D operator !(Vector3D v) => v.Complement();

	/// <summary>Negates <paramref name="v"/>.</summary>
	public static Vector3D operator -(Vector3D v) => v.Neg();

	//public static Vector3D operator ~(Vector3D v) => v.Cjg();
	//public static Vector3D operator !(Vector3D v) => v.Rcp();

	/// <summary>Multiplies <paramref name="p"/> by <paramref name="v"/>.<br/>
	/// Multiplies <paramref name="v"/> by <paramref name="p"/>.</summary>
	public static Point3D operator *(Point3D p, Vector3D v) => v.Times(p);
	/// <summary>Multiplies <paramref name="v"/> by <paramref name="scalar"/>.</summary>
	public static Point3D operator *(Vector3D v, Point3D p) => v.Times(p);

	/// <summary>Multiplies <paramref name="scalar"/> by <paramref name="v"/>.<br/>
	/// Multiplies <paramref name="v"/> by <paramref name="scalar"/>.</summary>
	public static Vector3D operator *(double scalar, Vector3D v) => v.Times(scalar);
	/// <summary>Multiplies <paramref name="v"/> by <paramref name="scalar"/>.</summary>
	public static Vector3D operator *(Vector3D v, double scalar) => v.Times(scalar);
	/// <summary>Divides <paramref name="v"/> by <paramref name="scalar"/>.</summary>
	public static Vector3D operator /(Vector3D v, double scalar) => v.Per(scalar);

	/// <summary>Adds <paramref name="p"/> and <paramref name="v"/>.<br/>
	/// Adds <paramref name="v"/> and <paramref name="p"/>.</summary>
	public static Point3D operator +(Point3D p, Vector3D v) => p.Plus(v);
	/// <summary>Adds <paramref name="v"/> and <paramref name="p"/>.</summary>
	public static Point3D operator +(Vector3D v, Point3D p) => p.Plus(v);

	/// <summary>Adds <paramref name="p"/> and <paramref name="v"/>.</summary>
	public static Vector3D operator +(Vector3D p, Vector3D v) => v.Plus(p);

	/// <summary>Subtracts <paramref name="v"/> from <paramref name="p"/>.<br/>
	/// Subtracts <paramref name="p"/> from <paramref name="v"/>.</summary>
	public static Point3D operator -(Point3D p, Vector3D v) => p.Minus(v);
	/// <summary>Subtracts <paramref name="p"/> from <paramref name="v"/>.</summary>
	public static Point3D operator -(Vector3D v, Point3D p) => p.Minus(v);

	/// <summary>Subtracts <paramref name="v"/> from <paramref name="p"/>.</summary>
	public static Vector3D operator -(Vector3D p, Vector3D v) => v.Minus(p);

	/// <summary> Wedge/Meet/Cross/outer Product </summary>
	/// <remarks>
	/// Unfortunately the ^ Operator has the lowest Precedence, so you have to bracket the Product.
	/// </remarks>
	//public static Vector3D operator ^(Vector3D a, Vector3D b) => a.Cross(b);
	public static BiVector3D operator ^(Vector3D a, Vector3D b) => a.Wedge(b);

	/// <summary>Multiplies <paramref name="a"/> by <paramref name="b"/>.</summary>
	public static double operator *(Vector3D a, Vector3D b) => a.Dot(b);
	//public static Vector3D operator *(Vector3D p, Vector3D v) => new(v.V * p.V);

	/// <summary>Determines whether <paramref name="a"/> equals <paramref name="b"/>.<br/>
	/// Determines whether <paramref name="a"/> does not equal <paramref name="b"/>.</summary>
	public static bool operator ==(Vector3D a, Vector3D b) => a.Equals(b);
	/// <summary>Determines whether <paramref name="a"/> does not equal <paramref name="b"/>.</summary>
	public static bool operator !=(Vector3D a, Vector3D b) => !(a == b);

	#endregion Operators

	/// <summary>Gets the norm Abs.<br/>
	/// Gets the norm Sqr.</summary>
	///
	[Facets(Layer = "domain", Status = "buggy", Complexity = 3)]
	[Tags("code/value_object", "code/vector_math")]
	[System.ComponentModel.Description("Gets the norm Abs. Gets the norm Sqr.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public double NormAbs => Math.Abs(V.X) + Math.Abs(V.Y) + Math.Abs(V.Z);
	/// <summary>Gets the norm Sqr.</summary>
	///
	[Facets(Layer = "domain", Status = "buggy", Complexity = 3)]
	[Tags("code/value_object", "code/vector_math")]
	[System.ComponentModel.Description("Gets the norm Sqr.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public double NormSqr => V.X * V.X + V.Y * V.Y + V.Z * V.Z; //V.LengthSquared(); //
	/// <summary>Gets the norm.</summary>
	///
	[Facets(Layer = "domain", Status = "buggy", Complexity = 3)]
	[Tags("code/value_object", "code/vector_math")]
	[System.ComponentModel.Description("Gets the norm.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public double Norm => Math.Sqrt(NormSqr);// V.Length(); //

	/// <summary> Returns the Hodge complement (dual) of this vector as a <see cref="BiVector3D"/>. </summary>
	///
	[Facets(Layer = "domain", Status = "buggy", Complexity = 3)]
	[Tags("code/value_object", "code/vector_math")]
	[System.ComponentModel.Description("Returns the Hodge complement (dual) of this vector as a BiVector3D.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public BiVector3D Complement() => new(V);

	//public Vector3D Cjg() => new(new Vector3(V.X, -V.Y));
	/// <summary> Additive inverse of this vector. </summary>
	///
	[Facets(Layer = "domain", Status = "buggy", Complexity = 3)]
	[Tags("code/value_object", "code/vector_math")]
	[System.ComponentModel.Description("Additive inverse of this vector.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public Vector3D Neg() => new(Vector3.Negate(V));
	/// <summary>Gets the normalized.</summary>
	///
	[Facets(Layer = "domain", Status = "buggy", Complexity = 3)]
	[Tags("code/value_object", "code/vector_math")]
	[System.ComponentModel.Description("Gets the normalized.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public Vector3D Normalized => new(Vector3.Normalize(V));

	/// <summary> Translates <paramref name="that"/> by this direction vector. </summary>
	///
	[Facets(Layer = "domain", Status = "buggy", Complexity = 3)]
	[Tags("code/value_object", "code/vector_math")]
	[System.ComponentModel.Description("Translates that by this direction vector.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public Point3D Plus(Point3D that) => new(Vector3.Add(V, that.V));
	/// <inheritdoc cref="Plus(Point3D)"/>
	public Vector3D Plus(Vector3D that) => new(Vector3.Add(V, that.V));
	/// <inheritdoc cref="Plus(Point3D)"/>
	public Vector4D Plus(Vector4D that) => that.Plus(this);
	/// <summary> Returns the component-wise difference of this vector minus <paramref name="that"/>. </summary>
	///
	[Facets(Layer = "domain", Status = "buggy", Complexity = 3)]
	[Tags("code/value_object", "code/vector_math")]
	[System.ComponentModel.Description("Returns the component-wise difference of this vector minus that.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public Vector3D Minus(Vector3D that) => new(Vector3.Subtract(V, that.V));
	/// <inheritdoc cref="Minus(Vector3D)"/>
	public Vector4D Minus(Vector4D that) => that.MinusR(this);

	/// <summary> Scales this vector by 1/<paramref name="scalar"/>. </summary>
	///
	[Facets(Layer = "domain", Status = "buggy", Complexity = 3)]
	[Tags("code/value_object", "code/vector_math")]
	[System.ComponentModel.Description("Scales this vector by 1/scalar.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public Vector3D Per(double scalar) => new(V * (float) (1 / scalar));

	/// <summary> Scales all components by <paramref name="scalar"/>. </summary>
	///
	[Facets(Layer = "domain", Status = "buggy", Complexity = 3)]
	[Tags("code/value_object", "code/vector_math")]
	[System.ComponentModel.Description("Scales all components by scalar.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public Vector3D Times(double scalar) => new(V * (float) scalar);

	/// <summary> Component-wise Multiplication </summary>
	///
	[Facets(Layer = "domain", Status = "buggy", Complexity = 3)]
	[Tags("code/value_object", "code/vector_math")]
	[System.ComponentModel.Description("Component-wise Multiplication")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public Point3D Times(Point3D p) => new(V * p.V);

	/// <summary> AKA AntiWedge; anti-symmetric Cross Product </summary>
	///
	[Facets(Layer = "domain", Status = "buggy", Complexity = 3)]
	[Tags("code/value_object", "code/vector_math")]
	[System.ComponentModel.Description("AKA AntiWedge; anti-symmetric Cross Product")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public Vector3D Cross(Vector3D that) => new(Vector3.Cross(V, that.V));
		// var b = that.V;
		// return new Vector3D(V.Y * b.Z - V.Z * b.Y, V.Z * b.X - V.X * b.Z, V.X * b.Y - V.Y * b.X);

	/// <summary> symmetric Dot Product, actually a geometric Wedge-Product with the Anti-Vector of <paramref name="that"/> </summary>
	///
	[Facets(Layer = "domain", Status = "buggy", Complexity = 3)]
	[Tags("code/value_object", "code/vector_math")]
	[System.ComponentModel.Description("symmetric Dot Product, actually a geometric Wedge-Product with the Anti-Vector of that")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public double Dot(Vector3D that) => Vector3.Dot(V, that.V);
	/// <inheritdoc cref="Dot(Vector3D)"/>
	public double Dot(Point3D that) => Vector3.Dot(V, that.V);
	/// <inheritdoc cref="Dot(Vector3D)"/>
	public double Dot(Vector4D that) => that.Dot(this);

	/// <summary> Component-wise Multiplication </summary>
	///
	[Facets(Layer = "domain", Status = "buggy", Complexity = 3)]
	[Tags("code/value_object", "code/vector_math")]
	[System.ComponentModel.Description("Component-wise Multiplication")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public Vector3D Times(Vector3D p) => new(V * p.V);

	/// <summary> Non-normalized Projection in <paramref name="that"/> Direction </summary>
	/// <returns>the Projection of this Vector onto <paramref name="that"/></returns>
	/// <remarks>
	/// this == <see cref="ProjectOn"/>(that) + <see cref="RejectFrom"/>(that)
	/// </remarks>
	[Facets(Layer = "domain", Status = "buggy", Complexity = 3)]
	[Tags("code/value_object", "code/vector_math")]
	[System.ComponentModel.Description("Non-normalized Projection in that Direction")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public Vector3D ProjectOn(Vector3D that) => that * Dot(that);

	/// <summary> Non-normalized Rejection from <paramref name="that"/> Direction </summary>
	/// <returns>the orthogonal Component of this Vector from <paramref name="that"/></returns>
	/// <remarks>
	/// this == <see cref="ProjectOn"/>(that) + <see cref="RejectFrom"/>(that)
	/// </remarks>
	[Facets(Layer = "domain", Status = "buggy", Complexity = 3)]
	[Tags("code/value_object", "code/vector_math")]
	[System.ComponentModel.Description("Non-normalized Rejection from that Direction")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public Vector3D RejectFrom(Vector3D that) => new(V - that.V * Vector3.Dot(V, that.V));

	/// <summary> Component-wise floor toward negative infinity. </summary>
	///
	[Facets(Layer = "domain", Status = "buggy", Complexity = 3)]
	[Tags("code/value_object", "code/vector_math")]
	[System.ComponentModel.Description("Component-wise floor toward negative infinity.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public Vector3D Floor() => new(Math.Floor(V.X), Math.Floor(V.Y), Math.Floor(V.Z));

	/// <summary> Component-wise ceiling toward positive infinity. </summary>
	///
	[Facets(Layer = "domain", Status = "buggy", Complexity = 3)]
	[Tags("code/value_object", "code/vector_math")]
	[System.ComponentModel.Description("Component-wise ceiling toward positive infinity.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public Vector3D Ceil() => new(Math.Ceiling(V.X), Math.Ceiling(V.Y), Math.Ceiling(V.Z));

}
