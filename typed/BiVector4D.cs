using System;
using System.Numerics;
using org.SpocWeb.root.Attributes;

namespace org.SpocWeb.root.maths.pga.typed;

/// <summary> Static factory methods constructing <see cref="BiVector4D"/> lines via wedge products
/// of homogeneous 3D points and direction vectors. </summary>
/// <remarks>
/// ## Public Methods
///
/// | Line | Method | Description |
/// |--:|---|---|
/// | 36 | <see cref="Wedge4DPoint"/> | Returns the wedge/outer/progressive product of the points p and q. |
/// | 46 | <see cref="Wedge4DVector"/> | Returns the wedge/outer/progressive product of the point p and Vector v. |
///
/// ## Collaborators
///
/// | Type | Role |
/// |---|---|
/// | <see cref="BiVector4D"/> | Returned by a method. |
/// | <see cref="Vector3"/> | Passed as a parameter. |
/// </remarks>
///
[DocState(Pass = 2, MTime = "2026-05-24T15:36:37Z", Digest = "8431e0f46cb89ce6da929586f5f67cdf43f49a973307705fdbbd137c8ce272e9", Stale = false, Path = "typed/BiVector4D.cs", Since = "2026-10-06")]
[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
[Tags("code/factory", "code/vector_math")]
[System.ComponentModel.Description("Static factory methods constructing BiVector4D lines via wedge products of homogeneous 3D points and direction vectors.")]
[Concept("Mathematics\\Geometry\\Vector.md")]
public static class XBiVector4D
{

	/// <summary> Returns the wedge/outer/progressive product of the points <paramref name="p"/> and <paramref name="q"/>.
	/// The w coordinates of p and q are assumed to be 1.	 </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/extension_method", "code/outer_product", "code/cross_product")]
	[System.ComponentModel.Description("Returns the wedge/outer/progressive product of the points p and q. The w coordinates of p and q are assumed to be 1.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public static BiVector4D Wedge4DPoint(this Vector3 q, Vector3 p) => new(q.X - p.X, q.Y - p.Y, q.Z - p.Z
		, p.Y * q.Z - p.Z * q.Y, p.Z * q.X - p.X * q.Z, p.X * q.Y - p.Y * q.X);

	/// <summary> Returns the wedge/outer/progressive product of the point <paramref name="p"/> and Vector <paramref name="v"/>.
	/// The w coordinates of p and v are assumed to be 1.	 </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/extension_method", "code/outer_product", "code/cross_product")]
	[System.ComponentModel.Description("Returns the wedge/outer/progressive product of the point p and Vector v. The w coordinates of p and v are assumed to be 1.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public static BiVector4D Wedge4DVector(this Vector3 v, Vector3 p) => new(v.X, v.Y, v.Z
		, p.Y * v.Z - p.Z * v.Y, p.Z * v.X - p.X * v.Z, p.X * v.Y - p.Y * v.X);

}

/// <summary> Represents a line in 3D projective space via six Plücker coordinates:<br/>
/// a <see cref="Direction"/> (vector part) and a <see cref="Moment"/> (bivector part). </summary>
///
/// <remarks>
/// It has 6 Components stored in 2 <see cref="Vector3D"/>
/// hardware-accelerated <see cref="System.Numerics.Vector3"/>
///
/// Alternatively represents a Rotor and a Versor in Projective Geometry. 
/// </remarks>
[DocState(Pass = 2, MTime = "2026-05-24T15:36:37Z", Digest = "4978d999b4b3565a5438537eb827da872f660631229a6a947112b63cb9420a40", Stale = false, Path = "typed/BiVector4D.cs", Since = "2026-10-06")]
[Facets(Layer = "domain", Status = "stable", Complexity = 3)]
[Tags("code/value_object", "code/plucker_coordinates")]
[System.ComponentModel.Description("Represents a line in 3D projective space via six Plücker coordinates: a Direction (vector part) and a Moment (bivector part).")]
[Concept("Mathematics\\Geometry\\Vector.md")]
public class BiVector4D : IEquatable<BiVector4D>
{
	/// <summary> AKA Direction/Offset; </summary>
	public readonly Vector3D Direction;//Tangent; 

	public readonly BiVector3D Moment;

	/// <summary>Initializes a new instance of <see cref="BiVector4D"/> with the specified <paramref name="tangent"/> and <paramref name="moment"/>.</summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 3)]
	[Tags("code/value_object", "code/plucker_coordinates")]
	[System.ComponentModel.Description("Initializes a new instance of BiVector4D with the specified tangent and moment.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public BiVector4D(Vector3D tangent, BiVector3D moment)
	{
		Direction = tangent;
		Moment = moment;
	}

	/// <summary>Initializes a new instance of <see cref="BiVector4D"/> with the specified <paramref name="vx"/>, <paramref name="vy"/>, <paramref name="vz"/>, <paramref name="mx"/>, <paramref name="my"/> and <paramref name="mz"/>.</summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 3)]
	[Tags("code/value_object", "code/plucker_coordinates")]
	[System.ComponentModel.Description("Initializes a new instance of BiVector4D with the specified vx, vy, vz, mx, my and mz.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public BiVector4D(float vx, float vy, float vz, float mx, float my, float mz)
	{
		Direction = new Vector3D(vx, vy, vz);
		Moment = new BiVector3D(mx, my, mz);
	}

	/// <summary>
	/// Line runs through points p and q.
	/// initialized to the wedge product between homogeneous extensions of p and q with w coordinates set to 1, giving a representation of the 3D line containing both points. The direction component of the BiVector is assigned the value q − p, and the moment component is assigned the value p ∧ q.
	/// </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 3)]
	[Tags("code/value_object", "code/plucker_coordinates")]
	[System.ComponentModel.Description("Line runs through points p and q. initialized to the wedge product between homogeneous extensions of p and q with w coordinates set to 1, giving a representation of the 3D line containing both points. The direction component of the BiVector is assigned the value q − p, and the moment component is assigned the value p ∧ q.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public BiVector4D(Point3D p3D, Point3D q3D){
		var p = p3D.V;
		var q = q3D.V;
		Direction = new Vector3D(q.X - p.X, q.Y - p.Y, q.Z - p.Z);
		Moment = new BiVector3D(p.Y * q.Z - p.Z * q.Y, p.Z * q.X - p.X * q.Z, p.X * q.Y - p.Y * q.X);
	}

	/// <summary>
	/// Line contains the point p and runs parallel to the direction v.
	/// The BiVector is initialized to the wedge product between the homogeneous extension of p with w coordinate set to 1 and the homogeneous extension of v with w coordinate set to 0. The direction component of the BiVector is set equal to v, and the moment component is assigned the value p ∧ v.
	/// </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 3)]
	[Tags("code/value_object", "code/plucker_coordinates")]
	[System.ComponentModel.Description("Line contains the point p and runs parallel to the direction v. The BiVector is initialized to the wedge product between the homogeneous extension of p with w coordinate set to 1 and the homogeneous extension of v with w coordinate set to 0. The direction component of the BiVector is set equal to v, and the moment component is assigned the value p ∧ v.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public BiVector4D(Point3D p3D, Vector3D v3D){
		Direction = v3D;
		var p = p3D.V;
		var v = v3D.V;
		Moment = new BiVector3D(p.Y * v.Z - p.Z * v.Y, p.Z * v.X - p.X * v.Z, p.X * v.Y - p.Y * v.X);
	}

	/// <summary>
	/// anti-wedge product between the 4D tri-vectors f and g, giving a representation of the line where the planes intersect.
	/// </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 3)]
	[Tags("code/value_object", "code/plucker_coordinates")]
	[System.ComponentModel.Description("anti-wedge product between the 4D tri-vectors f and g, giving a representation of the line where the planes intersect.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public BiVector4D(TriVector4D f4D, TriVector4D g4D){
		var f = f4D.xyz;
		var g = g4D.xyz;
		Direction = new Vector3D(f.Y * g.Z - f.Z * g.Y, f.Z * g.X - f.X * g.Z, f.X * g.Y - f.Y * g.X);
		Moment = new BiVector3D(f4D.W * g.X - f.X * g4D.W, f4D.W * g.Y - f.Y * g4D.W, f4D.W * g.Z - f.Z * g4D.W);
	}

	/// <summary> Returns the support vector: the closest point on the line to the origin. </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 3)]
	[Tags("code/value_object", "code/plucker_coordinates")]
	[System.ComponentModel.Description("Returns the support vector: the closest point on the line to the origin.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public Vector3D GetSupport() => !Direction ^ Moment;

	/// <summary> Scales this line so that its <see cref="Direction"/> component becomes a unit vector. </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 3)]
	[Tags("code/value_object", "code/plucker_coordinates")]
	[System.ComponentModel.Description("Scales this line so that its Direction component becomes a unit vector.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public BiVector4D Unitize() => this / Direction.Norm;

	#region Operators

	/// <summary> 	Returns a boolean value indicating whether the two BiVectors a and b are equal.	 </summary>
	public static bool operator ==(BiVector4D? a, BiVector4D? b) => ReferenceEquals(a, b) || a is not null && a.Equals(b);

	/// <summary> 	Returns a boolean value indicating whether the two BiVectors a and b are not equal.	 </summary>
	public static bool operator !=(BiVector4D? a, BiVector4D? b) => !(a == b);

	/// <summary> 	Returns the anti-reverse of the BiVector <paramref name="v"/> </summary>
	public static BiVector4D operator ~(BiVector4D v) => v.Neg();

	/// <summary> Grade-reverse of this bivector (same as negation for grade-2 elements). </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 3)]
	[Tags("code/value_object", "code/plucker_coordinates")]
	[System.ComponentModel.Description("Grade-reverse of this bivector (same as negation for grade-2 elements).")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public BiVector4D Reverse() => Neg();

	/// <summary> Anti-reverse of this bivector (same as negation for grade-2 elements). </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 3)]
	[Tags("code/value_object", "code/plucker_coordinates")]
	[System.ComponentModel.Description("Anti-reverse of this bivector (same as negation for grade-2 elements).")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public BiVector4D AntiReverse() => Neg();

	/// <summary> Returns the additive inverse of this line bivector. </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 3)]
	[Tags("code/value_object", "code/plucker_coordinates")]
	[System.ComponentModel.Description("Returns the additive inverse of this line bivector.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public BiVector4D Neg() {
		var dir = Direction.V;
		var mom = Moment.V3;
		return new BiVector4D(new Vector3D(-dir), new BiVector3D(-mom));
	}

	/// <summary> 	Returns the negation of the BiVector L.	 </summary>
	public static BiVector4D operator -(BiVector4D v) => v.Neg();

	/// <inheritdoc cref="Times"/>
	public static BiVector4D operator *(BiVector4D biVector, double scalar) => biVector.Times(scalar);

	/// <inheritdoc cref="Times"/>
	public static BiVector4D operator *(double scalar, BiVector4D biVector) => biVector.Times(scalar);

	/// <summary> 	Returns the product of the BiVector L and the Reciprocal of the scalar s.	 </summary>
	public static BiVector4D operator /(BiVector4D biVector, double scalar) => biVector.Times(1 / scalar);

	/// <summary> p ∧ L = L ∧ p. Wedge product of the point p and the BiVector L </summary>
	/// <remarks>
	/// The w coordinate of p is assumed to be 1.
	/// The result represents the plane containing the line L and the point p,
	/// wound from the direction component of L toward the direction to p perpendicular to the line L.
	/// </remarks>
	public static TriVector4D operator ^(BiVector4D v, Point3D p3d) {
		var dir = v.Direction.V;
		var mom = v.Moment.V3;
		var p = p3d.V;
		return new TriVector4D(dir.Y * p.Z - dir.Z * p.Y + mom.X,
			dir.Z * p.X - dir.X * p.Z + mom.Y,
			dir.X * p.Y - dir.Y * p.X + mom.Z,
			-mom.X * p.X - mom.Y * p.Y - mom.Z * p.Z);
	}

	/// <summary> p ∧ L = L ∧ p. Wedge product of the point p and the BiVector L
	/// The w coordinate of p is assumed to be 1.	 </summary>
	public static TriVector4D operator ^(Point3D p, BiVector4D v) => v ^ p;

	/// <summary> 	Returns the wedge product of the BiVector L and the direction v. The w coordinate of v is assumed to be 0. The result represents the plane containing the line L and the direction v, wound from the direction component of L toward the direction v.	 </summary>
	public static TriVector4D operator ^(BiVector4D v4D, Vector3D v3D) {
		var dir = v4D.Direction.V;
		var mom = v4D.Moment.V3;
		var v = v3D.V;
		return new TriVector4D(dir.Y * v.Z - dir.Z * v.Y,
			dir.Z * v.X - dir.X * v.Z,
			dir.X * v.Y - dir.Y * v.X,
			-mom.X * v.X - mom.Y * v.Y - mom.Z * v.Z);
	}

	/// <summary> 	Returns the wedge product of the direction v and the BiVector L, which is the same as L ∧ v. The w coordinate of v is assumed to be 0.	 </summary>
	public static TriVector4D operator ^(Vector3D v, BiVector4D v4D) => v4D ^ v;

	/// <summary> 	Returns the anti-wedge product of the BiVector L and the plane f. The result represents the homogeneous point where the line and plane intersect. The x, y, and z must be divided by the w coordinate to produce a 3D point.	 </summary>
	public static Vector4D operator ^(BiVector4D v, TriVector4D f4D) {
		var mom = v.Moment.V3;
		var dir = v.Direction.V;
		var f = f4D.xyz;
		return new Vector4D(mom.Y * f.Z - mom.Z * f.Y + dir.X * f4D.W,
			mom.Z * f.X - mom.X * f.Z + dir.Y * f4D.W,
			mom.X * f.Y - mom.Y * f.X + dir.Z * f4D.W,
			-dir.X * f.X - dir.Y * f.Y - dir.Z * f.Z);
	}

	/// <summary> 	Returns the anti-wedge product of the plane f and the BiVector L, which is the same as L ∨ f.	 </summary>
	public static Vector4D operator ^(TriVector4D t, BiVector4D b) => b ^ t;

	/// <summary> 	Returns the anti-wedge product of the BiVectors K and L. This gives the crossing relationship between the two lines, with positive values representing clockwise crossings and negative values representing counterclockwise crossings.	 </summary>
	public static float operator ^(BiVector4D k, BiVector4D m) 
		=> -(k.Direction ^ m.Moment) - (k.Moment ^ m.Direction);

	#endregion Operators

	/// <summary> Returns the product of this <see cref="BiVector4D"/> and the <paramref name="scalar"/>.	 </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 3)]
	[Tags("code/value_object", "code/plucker_coordinates")]
	[System.ComponentModel.Description("Returns the product of this BiVector4D and the scalar.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public BiVector4D Times(double scale) => new(Direction.Times(scale), Moment.Times(scale));

	/// <summary> 	Returns the bulk norm of the BiVector L.	 </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 3)]
	[Tags("code/value_object", "code/plucker_coordinates")]
	[System.ComponentModel.Description("Returns the bulk norm of the BiVector L.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public double BulkNorm() => Moment.Norm;

	/// <summary> 	Returns the weight norm of the BiVector L.	 </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 3)]
	[Tags("code/value_object", "code/plucker_coordinates")]
	[System.ComponentModel.Description("Returns the weight norm of the BiVector L.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public double WeightNorm() => Direction.Norm;

	/// <summary> 	Returns the projection of the point p onto the line L under the assumption that the line is unitized.	 </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 3)]
	[Tags("code/value_object", "code/plucker_coordinates")]
	[System.ComponentModel.Description("Returns the projection of the point p onto the line L under the assumption that the line is unitized.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public static Point3D Project(Point3D p, BiVector4D v)
	{
		var dir = v.Direction.V;
		var mom = v.Moment.V3;
		var d = v.Direction.Dot(p);
		return new Point3D(d * dir.X + dir.Y * mom.Z - dir.Z * mom.Y
			, d * dir.Y + dir.Z * mom.X - dir.X * mom.Z
			, d * dir.Z + dir.X * mom.Y - dir.Y * mom.X);
	}


	/// <summary> 	Returns the projection of the line L onto the plane f under the assumption that the plane is unitized.	 </summary>
	//public BiVector4D Project(BiVector4D L, TriVector4D f) 
	//	=> new BiVector4D(L.direction - !f.xyz * (f.xyz ^ L.direction), f.xyz * (!f.xyz ^ L.moment) - (!f.xyz ^ L.direction) * f.w);


	/// <summary> 	Returns the anti-projection of the line L onto the point p (where p is always unitized because it has an implicit w coordinate of 1).	 </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 3)]
	[Tags("code/value_object", "code/plucker_coordinates")]
	[System.ComponentModel.Description("Returns the projection of the line L onto the plane f under the assumption that the plane is unitized.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public BiVector4D AntiProject(Point3D p) => new(p, Direction);

	/// <summary> 	Returns the anti-projection of the plane f onto the line L under the assumption that the line is unitized.	 </summary>
	//public TriVector4D AntiProject(TriVector4D f) 
	//	=> new TriVector4D(f.xyz - !direction * (f.direction ^ direction), moment ^ !direction ^ f.xyz);


	[Facets(Layer = "domain", Status = "stable", Complexity = 3)]
	[Tags("code/value_object", "code/plucker_coordinates")]
	[System.ComponentModel.Description("Returns the anti-projection of the plane f onto the line L under the assumption that the line is unitized.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public bool Equals(BiVector4D? other)
	{
		if (other is null) return false;
		if (ReferenceEquals(this, other)) return true;
		return Direction.Equals(other.Direction) 
		       && Moment.Equals(other.Moment);
	}

	/// <inheritdoc cref="Equals(BiVector4D?)"/>
	public override bool Equals(object? obj) => Equals(obj as BiVector4D);

	/// <inheritdoc />
	public override int GetHashCode() => (Direction.GetHashCode() << 16) ^ Moment.GetHashCode();
}
