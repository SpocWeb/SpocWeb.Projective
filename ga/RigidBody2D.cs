using System.Numerics;
using org.SpocWeb.root.interfaces.maths;

namespace org.SpocWeb.root.maths.pga.ga;

/// <summary> A <see cref="RigidBody2D"/> that carries a typed identity payload <typeparamref name="T"/>
/// for association with a game object or scene node. </summary>
///
/// <example>
/// <code language="yaml">
/// pass: 2
/// mtime: 2026-05-24T15:40:19Z
/// digest: 41f5c10232c5e6b8e4e1bf9d7471d17e16f338f2cb51ba68fd5a13bc986a02c7
/// tags: [code/rigid_body_physics, code/typed_wrapper]
/// concepts: [physics_simulation]
/// facets: {layer: domain, status: stable, complexity: 1}
/// </code>
/// </example>
public class RigidBody2D<T> : RigidBody2D
{
	public readonly T? Identity;

	/// <summary>Initializes a new instance of <see cref="RigidBody2D"/> with the specified <paramref name="identity"/>, <paramref name="mass"/> and <paramref name="extension"/>.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/rigid_body_physics, code/typed_wrapper]
	/// concepts: [physics_simulation]
	/// facets: {layer: domain, status: stable, complexity: 1}
	/// </code>
	/// </example>
	public RigidBody2D(T? identity, double mass, float extension = 1) : base(mass, extension) {
		Identity = identity;
	}
}

/// <summary> A rigid Body in 2D has 3 DoF(Degrees of Freedom):
/// 2 for <see cref="Position"/> and
/// 1 for <see cref="Attitude"/>/Rotation Angle </summary>
///
/// <example>
/// <code language="yaml">
/// pass: 2
/// mtime: 2026-05-24T15:40:19Z
/// digest: b99a1ab4a083e82dcba6d7795c6c2337083ead6587261a80d4082196065a5240
/// tags: [code/rigid_body_physics]
/// concepts: [physics_simulation]
/// facets: {layer: domain, status: stable, complexity: 3}
/// </code>
/// </example>
/// <remarks>
/// These are the essential Properties of a rigid Body in 2nd Order Approximation.
/// 0th Order consists only of <see cref="Position"/> Position and is static in Time.
/// 1st Order adds <see cref="Mass"/> and <see cref="Momentum"/>.
/// 2nd Order adds <see cref="Extension"/> and <see cref="Attitude"/>.
///
/// Includes Time Derivatives: <see cref="V"/> and <see cref="L"/>
/// resp. <see cref="Momentum"/> and <see cref="W"/>
///
/// The full Velocity (Translation + Rotation) can be expressed using a single <see cref="R200"/>. 
/// 
/// All higher geometric Momenta depend on the actual Shape and <see cref="Mass"/> Distribution
/// and are accidental and accounted for by a constant Shape-dependent Factor.
///
/// The most simple Body is an empty HyperSphere with uniform Distribution of the Mass on the Surface
/// (to give it 
/// </remarks>
public class RigidBody2D
{
	/// <summary> The Mass/ 0th Inertia-Moment of a Body is a constant, unless it is broken up </summary>
	/// <remarks> The Total Mass is the 0th Moment of the Mass Distribution: Sum(i,m[i]) </remarks>
	public readonly float Mass;

	/// <summary> The Radius of a Body is a constant </summary>
	public readonly float Extension;

	/// <summary> 2nd (angular) Inertia-Moment of a Body is a constant as long as the Body does not deform! </summary>
	/// <remarks>
	/// The angular Inertia is the 2nd Moment of the Mass Distribution: Sum(i,x[i]y[i]m[i])
	/// This is actually a BiVector and in 3D a Tensor formed from the BiVector Components.
	/// This can also result in the angular Momentum <see cref="L"/> and angular Velocity <see cref="W"/>
	/// not being in the same Plane!
	/// 
	/// To apply Torque to a Body it has to have Extension/Geometry.
	/// This generic is the same for every rigid Body except for a constant Factor
	/// dependent on Shape and Mass-Distribution.
	///
	/// This Separation of higher Order Aspects corresponds to the Separation of
	/// Formatting and Styling Text:
	/// Formatting is the Layout/Placing of (repeating) structural Elements.
	///
	/// Styling determines the actual Shape of the Characters,
	/// which is less relevant than the actual Placement and Identity of the Character.
	/// </remarks>
	/// <example>
	/// <code language="yaml">
	/// tags: [code/rigid_body_physics]
	/// concepts: [physics_simulation]
	/// facets: {layer: domain, status: stable, complexity: 3}
	/// </code>
	/// </example>
	public float I => Mass * Extension * Extension;

	/// <summary> AKA R,X, Position/Center of Mass, 1st Moment of Mass Distribution </summary>
	/// <remarks> The Center of Mass is the 1st Moment of the Mass Distribution: Sum(i,x[i]m[i])/<see cref="Mass"/> </remarks>
	public Vector2 Position;

	/// <summary> AKA P, Momentum = Sum(i,v[i]*m[i])</summary>
	public Vector2 Momentum;

	/// <summary> AKA Velocity </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/rigid_body_physics]
	/// concepts: [physics_simulation]
	/// facets: {layer: domain, status: stable, complexity: 3}
	/// </code>
	/// </example>
	public Vector2 V => Momentum * (1 / Mass);

	/// <summary> AKA Omega, Angular Velocity is actual a BiVector, but alternatively only an Angle </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/rigid_body_physics]
	/// concepts: [physics_simulation]
	/// facets: {layer: domain, status: stable, complexity: 3}
	/// </code>
	/// </example>
	public double W => L * (1 / I);

	/// <summary> AKA L, angular Momentum = Sum(i,r[i]^p[i]) = Sum(i,r[i]^v[i]*m[i]) = </summary>
	/// <remarks>
	/// The total angular Momentum is composed of an orbital Part and an relative spin-Part:
	/// By splitting an internal Position up into the orbital <see cref="Position"/> R
	/// and a relative Position r[i], you also split up the angular Momentum:
	/// L = Sum(i,(R + r[i])^v[i]*m[i]) = R^Sum(i,v[i]*m[i]) + Sum(i,r[i]^v[i]*m[i]) = L + l
	/// with l = Sum(i,m[i]*(x[i]�+y[i]�)) = Sum(i,m[i]*r[i]�)
	/// because v[i]=<see cref="W"/>^r[i] and x[i]^y[i]=-y[i]^x[i]
	/// </remarks>
	public double L;

	/// <summary> AKA Attitude to multiply Points with for <see cref="Rotation"/> </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/rigid_body_physics]
	/// concepts: [physics_simulation]
	/// facets: {layer: domain, status: stable, complexity: 3}
	/// </code>
	/// </example>
	public Complex Attitude => _Attitude ??= Polar.ToComplex(Rotation);
	Complex? _Attitude;

	/// <summary> AKA <see cref="Attitude"/>; Current Angle </summary>
	/// <remarks>
	/// Actually this could be represented by a z-Vector.
	/// The Vector-Length is the Rotation Angle. It also contains the Orientation,
	/// which is redundant for negative Length. 
	/// </remarks>
	public double Rotation;

	/// <summary>Initializes a new instance of <see cref="RigidBody2D"/> with the specified <paramref name="mass"/> and <paramref name="extension"/>.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/rigid_body_physics]
	/// concepts: [physics_simulation]
	/// facets: {layer: domain, status: stable, complexity: 3}
	/// </code>
	/// </example>
	public RigidBody2D(double mass, float extension = 1) {
		Extension = extension;
		Mass = (float) mass;
	}

	/// <summary> Moves/Updates/Propagates this Body in Time by <paramref name="dt"/> </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/rigid_body_physics]
	/// concepts: [physics_simulation]
	/// facets: {layer: domain, status: stable, complexity: 3}
	/// </code>
	/// </example>
	public void Move(double dt) {
		Position += Momentum * (float)(dt / Mass);
		var d = L * (dt / I);
		Rotation += d;
		_Attitude = null;// *= Polar.ToComplex(d);
	}
}
