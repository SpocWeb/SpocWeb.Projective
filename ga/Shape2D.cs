using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using org.SpocWeb.root.extensions.enumerables;
using org.SpocWeb.root.interfaces;
using org.SpocWeb.root.interfaces.Vectors;
using org.SpocWeb.root.maths.pga.typed;
using org.SpocWeb.root.Attributes;

namespace org.SpocWeb.root.maths.pga.ga;

/// <summary> Shape adds Geometry to <see cref="RigidBody2D"/> </summary>
/// <remarks>
/// ## Public Methods
///
/// | Line | Method | Description |
/// |--:|---|---|
/// | 46 | <see cref="Points2D"/> | Initializes a new instance of Points2D with the specified points. |
/// | 54 | <see cref="ApplyTo"/> | Transforms all Points by the attitude and position of body. |
///
/// ## Collaborators
///
/// | Type | Role |
/// |---|---|
/// | <see cref="Vector2"/> | Returned by a method. |
/// | <see cref="RigidBody2D"/> | Passed as a parameter. |
/// </remarks>
///
[DocState(Pass = 2, MTime = "2026-05-24T16:03:01Z", Digest = "70b84f2d68e1f33adba17c690222d50eacc0946b157aab4122808bc363359609", Stale = false, Path = "ga/Shape2D.cs", Since = "2026-10-06")]
[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
[Tags("code/rigid_body_physics", "code/computational_geometry")]
[System.ComponentModel.Description("Shape adds Geometry to RigidBody2D")]
[Concept("physics_simulation")]
public class Points2D
{
	/// <summary> List of <see cref="Points"/> describing a <see cref="Shape2D"/> </summary>
	/// <remarks>
	/// These <see cref="Points"/> are implicitly Positions around the Origin.
	/// This means they are actually NOT Point-'Vectors',
	/// because they don't add, but subtract, yielding proper Vectors.
	/// </remarks>
	public readonly IReadOnlyList<Vector2> Points;

	/// <summary>Initializes a new instance of <see cref="Points2D"/> with the specified <paramref name="points"/>.</summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/rigid_body_physics", "code/computational_geometry")]
	[System.ComponentModel.Description("Initializes a new instance of Points2D with the specified points.")]
	[Concept("physics_simulation")]
	public Points2D(IReadOnlyList<Vector2> points) => Points = points;

	/// <summary> Transforms all <see cref="Points"/> by the attitude and position of <paramref name="body"/>. </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/rigid_body_physics", "code/computational_geometry")]
	[System.ComponentModel.Description("Transforms all Points by the attitude and position of body.")]
	[Concept("physics_simulation")]
	public Vector2[] ApplyTo(RigidBody2D body) {
		var ret = new Vector2[Points.Count];
		for (int i = Points.Count; --i >= 0; ) {
			ret[i] = body.Attitude.Times(Points[i]) + body.Position;
		}
		return ret;
	}
}

/// <summary> Shape adds Geometry to <see cref="RigidBody2D"/> </summary>
///
/// <remarks>
/// This Separation between <see cref="RigidBody2D"/> and <see cref="Shape2D"/>
/// is similar to the Separation of Character and Letter.
/// 
/// Due to the bounded Nature of Rotation,
/// Translation is always applied first. 
/// </remarks>
[DocState(Pass = 2, MTime = "2026-05-24T16:03:01Z", Digest = "708afb4e023029acb0a0dbd0c3e574828d6c49d985777bb35c61c9cd3c6e5376", Stale = false, Path = "ga/Shape2D.cs", Since = "2026-10-06")]
[Facets(Layer = "domain", Status = "stable", Complexity = 1)]
[Tags("code/rigid_body_physics", "code/computational_geometry")]
[System.ComponentModel.Description("Shape adds Geometry to RigidBody2D")]
[Concept("physics_simulation")]
public class Shape2D : Points2D
{
	/// <summary> List of Index Triples into <see cref="Pga2D.Points"/> defining a plane in clockwise Orientation </summary>
	public readonly IReadOnlyList<IReadOnlyList<int>> Planes;

	/// <summary>Initializes a new instance of <see cref="Shape2D"/> with the specified <paramref name="points"/> and <paramref name="planes"/>.</summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 1)]
	[Tags("code/rigid_body_physics", "code/computational_geometry")]
	[System.ComponentModel.Description("Initializes a new instance of Shape2D with the specified points and planes.")]
	[Concept("physics_simulation")]
	public Shape2D(IReadOnlyList<Vector2> points, IReadOnlyList<IReadOnlyList<int>> planes)
		: base(points) => Planes = planes;
}

/// <summary> Shape with Mass Distribution, total <see cref="Mass"/> and <see cref="Inertia"/> </summary>
/// <remarks>
/// ## Public Methods
///
/// | Line | Method | Description |
/// |--:|---|---|
/// | 115 | <see cref="Masses"/> | Gets the masses. |
/// | 123 | <see cref="MassiveShape2D"/> | Initializes a new instance of MassiveShape2D with the specified points and masses. |
/// </remarks>
///
[DocState(Pass = 2, MTime = "2026-06-17T06:00:51Z", Digest = "98580e66d49cdf2bcb7281ca2a2490d27f930859f8894de48841cf4c095ca2ea", Stale = false, Path = "ga/Shape2D.cs", Since = "2026-10-06")]
[Facets(Layer = "domain", Status = "stable", Complexity = 3)]
[Tags("code/rigid_body_physics", "code/mass_distribution")]
[System.ComponentModel.Description("Shape with Mass Distribution, total Mass and Inertia")]
[Concept("physics_simulation")]
public class MassiveShape2D : Points2D
{
	/// <summary>Gets the masses.</summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 3)]
	[Tags("code/rigid_body_physics", "code/mass_distribution")]
	[System.ComponentModel.Description("Gets the masses.")]
	[Concept("physics_simulation")]
	public IReadOnlyList<float> Masses { get; }

	/// <summary>Initializes a new instance of <see cref="MassiveShape2D"/> with the specified <paramref name="points"/> and <paramref name="masses"/>.</summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 3)]
	[Tags("code/rigid_body_physics", "code/mass_distribution")]
	[System.ComponentModel.Description("Initializes a new instance of MassiveShape2D with the specified points and masses.")]
	[Concept("physics_simulation")]
	public MassiveShape2D(IReadOnlyList<Vector2> points, IReadOnlyList<float> masses) : base(points) {
		Masses = masses;
		Mass = (float) masses.Sum();
		//Inertia = (float) points.Select(p => (double)p.LengthSquared()).Dot(masses.Select(m => (double)m));
		Inertia = points.Zip(masses, (point, mass) => point.LengthSquared() * mass).Sum();
	}

	/// <summary> Total Mass is a Measure of linear Inertia </summary>
	/// <remarks>
	/// Inert Mass is conveyed by Higgs Bosons, very heavy Spin 0 Particles discovered in 2012. 
	/// </remarks>
	public readonly float Mass;

	/// <summary> Rotational Inertia is a Scalar for 2D </summary>
	public readonly float Inertia;
}
