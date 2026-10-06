using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using org.SpocWeb.root.graphics;
using org.SpocWeb.root.interfaces;
using org.SpocWeb.root.interfaces.maths;
using org.SpocWeb.root.interfaces.Vectors;
using org.SpocWeb.root.Attributes;

namespace org.SpocWeb.root.maths.pga.ga;

/// <summary> Shape adds Geometry to <see cref="RigidBody3D"/> </summary>
/// <remarks>
/// ## Public Methods
///
/// | Line | Method | Description |
/// |--:|---|---|
/// | 47 | <see cref="Points3D"/> | Initializes a new instance of Points3D with the specified points. |
/// | 55 | <see cref="ApplyTo"/> | Transforms all Points by the attitude and position of body. |
///
/// ## Collaborators
///
/// | Type | Role |
/// |---|---|
/// | <see cref="Vector3"/> | Returned by a method. |
/// | <see cref="RigidBody3D"/> | Passed as a parameter. |
/// </remarks>
///
[DocState(Pass = 2, MTime = "2026-05-24T16:03:01Z", Digest = "2ce193e64345b49e4e2c3533deca9411f3994b9645700d06bf801209b011331b", Stale = false, Path = "ga/Shape3D.cs", Since = "2026-10-06")]
[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
[Tags("code/rigid_body_physics", "code/computational_geometry")]
[System.ComponentModel.Description("Shape adds Geometry to RigidBody3D")]
[Concept("physics_simulation")]
public class Points3D
{
	/// <summary> List of <see cref="Points"/> describing a <see cref="Shape3D"/> </summary>
	/// <remarks>
	/// These <see cref="Points"/> are implicitly Positions around the Origin.
	/// This means they are actually NOT Point-'Vectors',
	/// because they don't add, but subtract, yielding proper Vectors.
	/// </remarks>
	public readonly IReadOnlyList<Vector3> Points;

	/// <summary>Initializes a new instance of <see cref="Points3D"/> with the specified <paramref name="points"/>.</summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/rigid_body_physics", "code/computational_geometry")]
	[System.ComponentModel.Description("Initializes a new instance of Points3D with the specified points.")]
	[Concept("physics_simulation")]
	public Points3D(IReadOnlyList<Vector3> points) => Points = points;

	/// <summary> Transforms all <see cref="Points"/> by the attitude and position of <paramref name="body"/>. </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/rigid_body_physics", "code/computational_geometry")]
	[System.ComponentModel.Description("Transforms all Points by the attitude and position of body.")]
	[Concept("physics_simulation")]
	public Vector3[] ApplyTo(RigidBody3D body) {
		var ret = new Vector3[Points.Count];
		for (int i = Points.Count; --i >= 0; ) {
			ret[i] = body.Attitude.Sandwich(Points[i]) + body.Position;
		}
		return ret;
	}
}

/// <summary> Shape adds Geometry to <see cref="RigidBody3D"/> </summary>
///
/// <remarks>
/// This Separation between <see cref="RigidBody3D"/> and <see cref="Shape3D"/>
/// is similar to the Separation of Character and Letter.
/// 
/// Due to the bounded Nature of Rotation,
/// Translation is always applied first. 
/// </remarks>
[DocState(Pass = 2, MTime = "2026-05-24T16:03:01Z", Digest = "ac02ac5a074dd127720d7d9a889410824481f90e923172a95087fa56430e8df1", Stale = false, Path = "ga/Shape3D.cs", Since = "2026-10-06")]
[Facets(Layer = "domain", Status = "stable", Complexity = 1)]
[Tags("code/rigid_body_physics", "code/computational_geometry")]
[System.ComponentModel.Description("Shape adds Geometry to RigidBody3D")]
[Concept("physics_simulation")]
public class Shape3D : Points3D
{
	/// <summary> List of Index Triples into <see cref="Pga3D.Points"/> defining a plane in clockwise Orientation </summary>
	public readonly IReadOnlyList<IReadOnlyList<int>> Planes;

	/// <summary>Initializes a new instance of <see cref="Shape3D"/> with the specified <paramref name="points"/> and <paramref name="planes"/>.</summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 1)]
	[Tags("code/rigid_body_physics", "code/computational_geometry")]
	[System.ComponentModel.Description("Initializes a new instance of Shape3D with the specified points and planes.")]
	[Concept("physics_simulation")]
	public Shape3D(IReadOnlyList<Vector3> points, IReadOnlyList<IReadOnlyList<int>> planes) : base(points)
		=> Planes = planes;
}

/// <summary> Shape with Mass Distribution, total <see cref="Mass"/> and <see cref="Inertia"/> </summary>
/// <remarks>
/// ## Public Methods
///
/// | Line | Method | Description |
/// |--:|---|---|
/// | 126 | <see cref="Masses"/> | Per-point mass values whose total equals Mass. |
/// | 134 | <see cref="MassiveShape3D"/> | Initializes a new instance of MassiveShape3D with the specified points and masses. |
/// | 177 | <see cref="Inertia"/> | Rotational Inertia is a Matrix for 3D |
/// | 186 | <see cref="LinearMomentum"/> | Returns the linear momentum vector for a body with this shape's Mass moving at velocity. |
/// | 203 | <see cref="AngularMomentum"/> | Calculates the AngularMomentum for the angular Speed |
/// | 211 | <see cref="AngularEnergy"/> | Returns the rotational kinetic energy for the given angular velocity using this shape's inertia tensor. |
/// | 219 | <see cref="InertiaAround"/> | The Scalar Inertia around a fixed axis |
///
/// ## Collaborators
///
/// | Type | Role |
/// |---|---|
/// | <see cref="Vector3"/> | Used as a field. |
/// </remarks>
[DocState(Pass = 2, MTime = "2026-06-17T06:01:09Z", Digest = "b44984e560c1fe6138d66f82c799fa2206f67e335b662931393aa703be99c2c4", Stale = false, Path = "ga/Shape3D.cs", Since = "2026-10-06")]
[Facets(Layer = "domain", Status = "stable", Complexity = 3)]
[Tags("code/rigid_body_physics", "code/mass_distribution")]
[System.ComponentModel.Description("Shape with Mass Distribution, total Mass and Inertia")]
[Concept("physics_simulation")]
public class MassiveShape3D : Points3D
{
	/// <summary> Per-point mass values whose total equals <see cref="Mass"/>. </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 3)]
	[Tags("code/rigid_body_physics", "code/mass_distribution")]
	[System.ComponentModel.Description("Per-point mass values whose total equals Mass.")]
	[Concept("physics_simulation")]
	public IReadOnlyList<float> Masses { get; }

	/// <summary>Initializes a new instance of <see cref="MassiveShape3D"/> with the specified <paramref name="points"/> and <paramref name="masses"/>.</summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 3)]
	[Tags("code/rigid_body_physics", "code/mass_distribution")]
	[System.ComponentModel.Description("Initializes a new instance of MassiveShape3D with the specified points and masses.")]
	[Concept("physics_simulation")]
	public MassiveShape3D(IReadOnlyList<Vector3> points, IReadOnlyList<float> masses) : base(points) {
		Masses = masses;
		Mass = (float) masses.Sum();
		var i00 = points.Zip(masses, (p, m) => m * (p.Y * p.Y + p.Z * p.Z)).Sum();
		var i11 = points.Zip(masses, (p, m) => m * (p.X * p.X + p.Z * p.Z)).Sum();
		var i22 = points.Zip(masses, (p, m) => m * (p.Y * p.Y + p.X * p.X)).Sum();

		var i01 =-points.Zip(masses, (p, m) => m * (p.X * p.Y)).Sum();
		var i02 =-points.Zip(masses, (p, m) => m * (p.X * p.Z)).Sum();
		var i12 =-points.Zip(masses, (p, m) => m * (p.Y * p.Z)).Sum();

		_Inertia = new [] {
			new Vector3(i00, i01, i02),
			new Vector3(i01, i11, i12), 
			new Vector3(i02, i12, i22), 
		};
	}

	/// <summary> Total Mass is a Measure of linear Inertia </summary>
	/// <remarks>
	/// Inert Mass is conveyed by Higgs Bosons, very heavy Spin 0 Particles discovered in 2012. 
	/// </remarks>
	public readonly float Mass;

	/// <summary> Rotational Inertia is a Matrix for 3D </summary>
	/// <remarks>
	/// A scalar Inertia can be calculated for a fixed Axis.
	///
	/// This is also the 2nd Derivative of Mass by the Distance from the Axis.
	/// This symmetric Matrix can be transformed into Diagonal Form
	/// along 3 orthogonal EigenVectors with 3 scalar Inertia Values.
	///
	/// Free Rotation is stable along the EigenVectors with the largest and smallest EigenValue.
	/// Along the middle EigenVector it is unstable.
	///
	/// Along any other Axis the angular Momentum is not parallel to the Rotation Axis
	/// so either the Axis continuously varies to yield the constant Momentum
	/// or an external Torque needs to be applied to keep the Axis stable.
	/// </remarks>
	[Facets(Layer = "domain", Status = "stable", Complexity = 3)]
	[Tags("code/rigid_body_physics", "code/mass_distribution")]
	[System.ComponentModel.Description("Rotational Inertia is a Matrix for 3D")]
	[Concept("physics_simulation")]
	public IReadOnlyList<Vector3> Inertia => _Inertia;
	readonly Vector3[] _Inertia;

	/// <summary> Returns the linear momentum vector for a body with this shape's <see cref="Mass"/> moving at <paramref name="velocity"/>. </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 3)]
	[Tags("code/rigid_body_physics", "code/mass_distribution")]
	[System.ComponentModel.Description("Returns the linear momentum vector for a body with this shape's Mass moving at velocity.")]
	[Concept("physics_simulation")]
	public Vector3 LinearMomentum(Vector3 velocity) => Mass * velocity;

	/// <summary>Calculates the <see cref="AngularMomentum"/> for the <paramref name="angular"/> Speed</summary>
	/// <remarks>
	/// <paramref name="angular"/> and the resulting Momentum are in the Reference Frame of this Shape.
	/// 
	/// To transfer them to the external Inertia-Reference Frame, they have to be rotated by the Attitude. 
	///
	/// The Fact that this Transformation is a Function of the Angle itself makes it complicated.
	/// For a free Rotation, the Attitude changes, forcing a change of the Axis
	/// to align with the fixed angular momentum,
	/// resulting in different Changes to the Attitude.
	/// </remarks>
	[Facets(Layer = "domain", Status = "stable", Complexity = 3)]
	[Tags("code/rigid_body_physics", "code/mass_distribution")]
	[System.ComponentModel.Description("Calculates the AngularMomentum for the angular Speed")]
	[Concept("physics_simulation")]
	public Vector3 AngularMomentum(Vector3 angular) => Inertia.Dot3(angular);

	/// <summary> Returns the rotational kinetic energy for the given <paramref name="angular"/> velocity using this shape's inertia tensor. </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 3)]
	[Tags("code/rigid_body_physics", "code/mass_distribution")]
	[System.ComponentModel.Description("Returns the rotational kinetic energy for the given angular velocity using this shape's inertia tensor.")]
	[Concept("physics_simulation")]
	public float AngularEnergy(Vector3 angular) => Inertia.Dot3(angular).Dot(angular);

	/// <summary> The Scalar Inertia around a fixed <paramref name="axis"/> </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 3)]
	[Tags("code/rigid_body_physics", "code/mass_distribution")]
	[System.ComponentModel.Description("The Scalar Inertia around a fixed axis")]
	[Concept("physics_simulation")]
	public double InertiaAround(Vector3 axis) {
		var normSqr = axis.NormSqr();
		if (!normSqr.IsOne()) {
			axis /= (float)Math.Sqrt(normSqr);
		}
		var vector3 = axis.Dot3(Inertia);
		return vector3.Dot(axis);
	}

}
