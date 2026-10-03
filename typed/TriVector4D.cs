using System;
using System.Numerics;
using System.Runtime.InteropServices;

namespace org.SpocWeb.root.maths.pga.typed;

/// <summary> 4D tri-vector having floating-point components x, y, z, and w.
/// </summary>
/// <remarks>
/// To be distinguished from Numeric.Vector4D and org.SpocWeb.root.maths.units.Vector4D
/// Operator Overloads are consistent with the <a href='http://c4engine.com/docs/Math/index.html'
/// >C4-Engine </a>
/// </remarks>
/// <example>
/// <code language="yaml">
/// pass: 2
/// mtime: 2026-05-24T15:36:37Z
/// digest: 83369c305b449318903d911cf21a38ebe40afebff113f3d007cdeda63275bf46
/// tags: [code/value_object, code/vector_math]
/// concepts: [Mathematics\Geometry\Vector.md]
/// facets: {layer: domain, status: stable, complexity: 3}
/// </code>
/// </example>
[StructLayout(LayoutKind.Explicit)]
public readonly struct TriVector4D : IEquatable<TriVector4D>
{

	/// <summary>Gets the direction.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/value_object, code/vector_math]
	/// concepts: [Mathematics\Geometry\Vector.md]
	/// facets: {layer: domain, status: stable, complexity: 3}
	/// </code>
	/// </example>
	public Vector3D Direction => new(xyz);

	//[FieldOffset(00)] public readonly Vector4 V4;
	[FieldOffset(00)] public readonly Vector3 xyz; //3 Float = 12 Byte
	[FieldOffset(12)] public readonly float W; //32 Bit = 4 Byte

	/// <summary>Initializes a new instance of <see cref="TriVector4D"/> with the specified <paramref name="x"/>, <paramref name="y"/>, <paramref name="z"/> and <paramref name="w"/>.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/value_object, code/vector_math]
	/// concepts: [Mathematics\Geometry\Vector.md]
	/// facets: {layer: domain, status: stable, complexity: 3}
	/// </code>
	/// </example>
	public TriVector4D(float x, float y, float z, float w) {
		//V4 = new Vector4(x, y, z, w);
		xyz = new Vector3(x, y, z);
		W = w;
	}

	/// <summary>Initializes a new instance of <see cref="TriVector4D"/> with the specified <paramref name="n"/> and <paramref name="d"/>.<br/>
	/// Initializes a new instance of <see cref="TriVector4D"/> with the specified <paramref name="n"/> and <paramref name="d"/>.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/value_object, code/vector_math]
	/// concepts: [Mathematics\Geometry\Vector.md]
	/// facets: {layer: domain, status: stable, complexity: 3}
	/// </code>
	/// </example>
	public TriVector4D(BiVector3D n, float d) : this(n.V3, d){}
	/// <summary>Initializes a new instance of <see cref="TriVector4D"/> with the specified <paramref name="n"/> and <paramref name="d"/>.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/value_object, code/vector_math]
	/// concepts: [Mathematics\Geometry\Vector.md]
	/// facets: {layer: domain, status: stable, complexity: 3}
	/// </code>
	/// </example>
	public TriVector4D(Vector3 n, float d) {
		//V4 = default;
		xyz = n;
		W = d;
	}

	/// <summary> Plane whose normal direction is <paramref name="biNormal"/> and that passes through <paramref name="p"/>. </summary>
	/// <remarks>
	/// w coordinate is given by −(n ∧ p)
	/// </remarks>
	/// <example>
	/// <code language="yaml">
	/// tags: [code/value_object, code/vector_math]
	/// concepts: [Mathematics\Geometry\Vector.md]
	/// facets: {layer: domain, status: stable, complexity: 3}
	/// </code>
	/// </example>
	public TriVector4D(BiVector3D biNormal, Point3D p) {
		xyz = biNormal.V3;
		W = -(biNormal ^ p);
	}

	/// <summary> triple wedge product p1 ∧ p2 ∧ p3. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/value_object, code/vector_math]
	/// concepts: [Mathematics\Geometry\Vector.md]
	/// facets: {layer: domain, status: stable, complexity: 3}
	/// </code>
	/// </example>
	public TriVector4D(Point3D p1, Point3D p2, Point3D p3) {
		var biVector3D = (p2 - p1) ^ (p3 - p1);
		xyz = biVector3D.V3;
		W = -(biVector3D ^ p1);
	}

	#region Operators

	/// <summary> 	Returns a boolean value indicating whether the two tri-vectors a and b are equal.	 </summary>
	public static bool operator ==(TriVector4D a, TriVector4D b) => a.Equals(b);

	/// <summary> 	Returns a boolean value indicating whether the two tri-vectors a and b are not equal.	 </summary>
	public static bool operator !=(TriVector4D a, TriVector4D b) => !(a == b);

	/// <summary> 	Returns the anti-reverse of the tri-vector v (which is just the tri-vector v itself).	 </summary>
	public static TriVector4D operator ~(TriVector4D v) => v.AntiReverse();

	/// <summary> 	Returns the negation of the tri-vector v.	 </summary>
	public static TriVector4D operator -(TriVector4D v) => v.Reverse();

	/// <summary> Returns the additive inverse of this tri-vector. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/value_object, code/vector_math]
	/// concepts: [Mathematics\Geometry\Vector.md]
	/// facets: {layer: domain, status: stable, complexity: 3}
	/// </code>
	/// </example>
	public TriVector4D Neg() => new(-xyz, -W);

	/// <summary> 	Returns the product of the tri-vector v and the scalar s.	 </summary>
	public static TriVector4D operator *(TriVector4D v,  float s) => v.Times(s);

	/// <summary> 	Returns the product of the tri-vector v and the scalar s.	 </summary>
	public static TriVector4D operator *(float s,  TriVector4D v) => v.Times(s);

	/// <summary> 	Returns the product of the tri-vector v and the inverse of the scalar s.	 </summary>
	public static TriVector4D operator /(TriVector4D v,  float s) => v.Per(s);

	/// <summary> 	Returns the anti-wedge product of the vector v and the tri-vector f.	 </summary>
	public static float operator ^(Vector4D v, TriVector4D f) => System.Numerics.Vector4.Dot(v.V, f.xyzw());

	/// <summary> Returns the four components as a <see cref="System.Numerics.Vector4"/> (x, y, z, w). </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/value_object, code/vector_math]
	/// concepts: [Mathematics\Geometry\Vector.md]
	/// facets: {layer: domain, status: stable, complexity: 3}
	/// </code>
	/// </example>
	public System.Numerics.Vector4 xyzw() => new(xyz.X, xyz.Y, xyz.Z, W);

	/// <summary> 	Returns the anti-wedge product of the 3D vector v and the tri-vector f. </summary>
	/// <remarks>
	/// The w coordinate of v is assumed to be 0.
	/// </remarks>
	public static float operator ^(Vector3D v, TriVector4D f) => Vector3.Dot(v.V, f.xyz);

	/// <summary> 	Returns the anti-wedge product of the 3D point p and the tri-vector f. The w coordinate of p is assumed to be 1. This gives the distance from a unitized plane represented by a Trivector4D object to the point p.	 </summary>
	public static float operator ^(Point3D p, TriVector4D f) => Vector3.Dot(p.V, f.xyz) + f.W;

	/// <summary> 	Returns the anti-wedge product of the 2D point p and the tri-vector f. The z coordinate of p is assumed to be 0, and the w coordinate of p is assumed to be 1. This gives the distance from a unitized plane represented by a Trivector4D object to the point p.	 </summary>
	public static float operator ^(Point2D p2D, TriVector4D f4D) {
		var p = p2D.V;
		var f = f4D.xyz;
		return p.X * f.X + p.Y * f.Y + f4D.W;
	}

	/// <summary> 	Returns the anti-wedge product of the TriVectors f and g. The result represents the line where the two planes f and g intersect. The direction of the line is equal to the cross product between the normal component of f and the normal component of g.	 </summary>
	public static BiVector4D operator ^(TriVector4D f4D, TriVector4D g4D) {
		var f = f4D.xyz;
		var g = g4D.xyz;
		return new BiVector4D(f.Z * g.Y - f.Y * g.Z
			, f.X * g.Z - f.Z * g.X, f.Y * g.X - f.X * g.Y
			, f.X * g4D.W - f4D.W * g.X, f.Y * g4D.W - f4D.W * g.Y, f.Z * g4D.W - f4D.W * g.Z);
	}

	#endregion Operators

	/// <inheritdoc />
	public bool Equals(TriVector4D other) => xyz.Equals(other.xyz) && W.Equals(other.W);

	/// <inheritdoc cref="Equals(TriVector4D)"/>
	public override bool Equals(object? obj) => obj is TriVector4D other && Equals(other);

	/// <inheritdoc />
	public override int GetHashCode() => xyz.GetHashCode() ^ W.GetHashCode();

	/// <summary> Grade-reversal of this tri-vector (equivalent to negation for grade-3 elements). </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/value_object, code/vector_math]
	/// concepts: [Mathematics\Geometry\Vector.md]
	/// facets: {layer: domain, status: stable, complexity: 3}
	/// </code>
	/// </example>
	public TriVector4D Reverse() => Neg();

	/// <summary> Anti-reversal of this tri-vector (identity for grade-3 elements in 4D). </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/value_object, code/vector_math]
	/// concepts: [Mathematics\Geometry\Vector.md]
	/// facets: {layer: domain, status: stable, complexity: 3}
	/// </code>
	/// </example>
	public TriVector4D AntiReverse() => this;

	/// <summary> Scales all components by <paramref name="s"/>. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/value_object, code/vector_math]
	/// concepts: [Mathematics\Geometry\Vector.md]
	/// facets: {layer: domain, status: stable, complexity: 3}
	/// </code>
	/// </example>
	public TriVector4D Times(float s) => new(xyz * s, W * s);
	/// <summary> Divides all components by <paramref name="s"/>. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/value_object, code/vector_math]
	/// concepts: [Mathematics\Geometry\Vector.md]
	/// facets: {layer: domain, status: stable, complexity: 3}
	/// </code>
	/// </example>
	public TriVector4D Per(float s) => Times(1 / s);

	/// <summary> 	Returns the bulk norm of the tri-vector v.	 </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/value_object, code/vector_math]
	/// concepts: [Mathematics\Geometry\Vector.md]
	/// facets: {layer: domain, status: stable, complexity: 3}
	/// </code>
	/// </example>
	public float BulkNorm() => Math.Abs(W);

	/// <summary> 	Returns the weight norm of the tri-vector v.	 </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/value_object, code/vector_math]
	/// concepts: [Mathematics\Geometry\Vector.md]
	/// facets: {layer: domain, status: stable, complexity: 3}
	/// </code>
	/// </example>
	// ReSharper disable once PossiblyImpureMethodCallOnReadonlyVariable
	public float WeightNorm() => xyz.Length();

	// ReSharper disable once PossiblyImpureMethodCallOnReadonlyVariable
	/// <summary> Scales this tri-vector so that its xyz part becomes a unit vector. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/value_object, code/vector_math]
	/// concepts: [Mathematics\Geometry\Vector.md]
	/// facets: {layer: domain, status: stable, complexity: 3}
	/// </code>
	/// </example>
	public TriVector4D Unitize() => Per(xyz.Length());
	/// <summary> Returns a unit tri-vector scaled by the inverse total magnitude. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/value_object, code/vector_math]
	/// concepts: [Mathematics\Geometry\Vector.md]
	/// facets: {layer: domain, status: stable, complexity: 3}
	/// </code>
	/// </example>
	public TriVector4D Normalize() => Times(InverseMag());

	/// <summary> 	Returns the magnitude of the tri-vector v.	 </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/value_object, code/vector_math]
	/// concepts: [Mathematics\Geometry\Vector.md]
	/// facets: {layer: domain, status: stable, complexity: 3}
	/// </code>
	/// </example>
	public float Magnitude() => (float) Math.Sqrt(SquaredMag());

	/// <summary> 	Returns the inverse magnitude of the tri-vector v.	 </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/value_object, code/vector_math]
	/// concepts: [Mathematics\Geometry\Vector.md]
	/// facets: {layer: domain, status: stable, complexity: 3}
	/// </code>
	/// </example>
	public float InverseMag() => 1 / Magnitude();

	/// <summary> 	Returns the squared magnitude of the tri-vector v.	 </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/value_object, code/vector_math]
	/// concepts: [Mathematics\Geometry\Vector.md]
	/// facets: {layer: domain, status: stable, complexity: 3}
	/// </code>
	/// </example>
	// ReSharper disable once PossiblyImpureMethodCallOnReadonlyVariable
	public float SquaredMag() => W * W + xyz.LengthSquared();

	/// <summary> 	Returns the projection of the point p onto the plane f under the assumption that the plane is unitized.	 </summary>
	//public static Point3D Project(Point3D p,  TriVector4D f) => new Point3D(p - !f.direction * (p ^ f));

	/// <summary> 	Returns the anti-projection of the plane f onto the point p. </summary>
	/// <remarks>
	/// where p is always unitized because it has an implicit w coordinate of 1
	/// </remarks>
	/// <example>
	/// <code language="yaml">
	/// tags: [code/value_object, code/vector_math]
	/// concepts: [Mathematics\Geometry\Vector.md]
	/// facets: {layer: domain, status: stable, complexity: 3}
	/// </code>
	/// </example>
	public TriVector4D AntiProject( Point3D p) => new(new BiVector3D(xyz), p);
}
