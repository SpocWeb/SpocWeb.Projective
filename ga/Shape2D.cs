using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using org.SpocWeb.root.extensions.enumerables;
using org.SpocWeb.root.interfaces;
using org.SpocWeb.root.interfaces.Vectors;
using org.SpocWeb.root.maths.pga.typed;

namespace org.SpocWeb.root.maths.pga.ga;

/// <summary> Shape adds Geometry to <see cref="RigidBody2D"/> </summary>
/// <remarks>
/// ## Public Methods
///
/// | Line | Method | Description |
/// |--:|---|---|
/// | 31 | <see cref="Points2D"/> | Initializes a new instance of Points2D with the specified points. |
/// | 34 | <see cref="ApplyTo"/> | Transforms all Points by the attitude and position of body. |
///
/// ## Collaborators
///
/// | Type | Role |
/// |---|---|
/// | <see cref="Vector2"/> | Returned by a method. |
/// | <see cref="RigidBody2D"/> | Passed as a parameter. |
/// </remarks>
///
/// <example>
/// <code language="yaml">
/// pass: 2
/// mtime: 2026-05-24T16:03:01Z
/// digest: 70b84f2d68e1f33adba17c690222d50eacc0946b157aab4122808bc363359609
/// tags: [code/rigid_body_physics, code/computational_geometry]
/// concepts: [physics_simulation]
/// facets: {layer: domain, status: stable, complexity: 2}
/// </code>
/// </example>
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
	/// <example>
	/// <code language="yaml">
	/// tags: [code/rigid_body_physics, code/computational_geometry]
	/// concepts: [physics_simulation]
	/// facets: {layer: domain, status: stable, complexity: 2}
	/// </code>
	/// </example>
	public Points2D(IReadOnlyList<Vector2> points) => Points = points;

	/// <summary> Transforms all <see cref="Points"/> by the attitude and position of <paramref name="body"/>. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/rigid_body_physics, code/computational_geometry]
	/// concepts: [physics_simulation]
	/// facets: {layer: domain, status: stable, complexity: 2}
	/// </code>
	/// </example>
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
/// <example>
/// <code language="yaml">
/// pass: 2
/// mtime: 2026-05-24T16:03:01Z
/// digest: 708afb4e023029acb0a0dbd0c3e574828d6c49d985777bb35c61c9cd3c6e5376
/// tags: [code/rigid_body_physics, code/computational_geometry]
/// concepts: [physics_simulation]
/// facets: {layer: domain, status: stable, complexity: 1}
/// </code>
/// </example>
/// <remarks>
/// This Separation between <see cref="RigidBody2D"/> and <see cref="Shape2D"/>
/// is similar to the Separation of Character and Letter.
/// 
/// Due to the bounded Nature of Rotation,
/// Translation is always applied first. 
/// </remarks>
public class Shape2D : Points2D
{
	/// <summary> List of Index Triples into <see cref="Pga2D.Points"/> defining a plane in clockwise Orientation </summary>
	public readonly IReadOnlyList<IReadOnlyList<int>> Planes;

	/// <summary>Initializes a new instance of <see cref="Shape2D"/> with the specified <paramref name="points"/> and <paramref name="planes"/>.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/rigid_body_physics, code/computational_geometry]
	/// concepts: [physics_simulation]
	/// facets: {layer: domain, status: stable, complexity: 1}
	/// </code>
	/// </example>
	public Shape2D(IReadOnlyList<Vector2> points, IReadOnlyList<IReadOnlyList<int>> planes)
		: base(points) => Planes = planes;
}

/// <summary> Shape with Mass Distribution, total <see cref="Mass"/> and <see cref="Inertia"/> </summary>
/// <remarks>
/// ## Public Methods
///
/// | Line | Method | Description |
/// |--:|---|---|
/// | 81 | <see cref="Masses"/> | Gets the masses. |
/// | 84 | <see cref="MassiveShape2D"/> | Initializes a new instance of MassiveShape2D with the specified points and masses. |
/// </remarks>
///
/// <example>
/// <code language="yaml">
/// pass: 2
/// mtime: 2026-06-17T06:00:51Z
/// digest: 98580e66d49cdf2bcb7281ca2a2490d27f930859f8894de48841cf4c095ca2ea
/// tags: [code/rigid_body_physics, code/mass_distribution]
/// concepts: [physics_simulation]
/// facets: {layer: domain, status: stable, complexity: 3}
/// </code>
/// </example>
public class MassiveShape2D : Points2D
{
	/// <summary>Gets the masses.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/rigid_body_physics, code/mass_distribution]
	/// concepts: [physics_simulation]
	/// facets: {layer: domain, status: stable, complexity: 3}
	/// </code>
	/// </example>
	public IReadOnlyList<float> Masses { get; }

	/// <summary>Initializes a new instance of <see cref="MassiveShape2D"/> with the specified <paramref name="points"/> and <paramref name="masses"/>.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/rigid_body_physics, code/mass_distribution]
	/// concepts: [physics_simulation]
	/// facets: {layer: domain, status: stable, complexity: 3}
	/// </code>
	/// </example>
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
