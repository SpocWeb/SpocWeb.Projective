using System.Collections.Generic;
using System.Numerics;
using org.SpocWeb.root.graphics;
using org.SpocWeb.root.interfaces.Vectors;
using org.SpocWeb.root.Attributes;

namespace org.SpocWeb.root.maths.pga.ga;

/// <summary> A <see cref="RigidBody3D"/> that carries a typed identity payload <typeparamref name="T"/>
/// for association with a game object or scene node. </summary>
///
[DocState(Pass = 2, MTime = "2026-05-24T15:40:19Z", Digest = "84411742196ceb35fb33cda2e959c60220bde7f002219dd59a490eb1b45e28ca", Stale = false, Path = "ga/RigidBody3D.cs", Since = "2026-10-06")]
[Facets(Layer = "domain", Status = "stable", Complexity = 1)]
[Tags("code/rigid_body_physics", "code/typed_wrapper")]
[System.ComponentModel.Description("A RigidBody3D that carries a typed identity payload for association with a game object or scene node.")]
[Concept("physics_simulation")]
public class RigidBody3D<T> : RigidBody3D
{
	public readonly T? Identity;

	/// <summary>Initializes a new instance of <see cref="RigidBody3D"/> with the specified <paramref name="identity"/>, <paramref name="mass"/> and <paramref name="extension"/>.</summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 1)]
	[Tags("code/rigid_body_physics", "code/typed_wrapper")]
	[System.ComponentModel.Description("Initializes a new instance of RigidBody3D with the specified identity, mass and extension.")]
	[Concept("physics_simulation")]
	public RigidBody3D(T? identity, double mass, float extension = 1) : base(mass, extension) {
		Identity = identity;
	}
}

/// <summary> A rigid Body in 3D has 6 DoF(Degrees of Freedom):
/// 3 for <see cref="Position"/> and
/// 3 in <see cref="Attitude"/> </summary>
///
/// <remarks>
/// These are the essential Properties of a rigid Body in 2nd Order Approximation.
/// 0th Order consists only of <see cref="Position"/> Position and is static in Time.
/// 1st Order adds <see cref="Mass"/> and <see cref="Momentum"/>.
/// 2nd Order adds <see cref="Extension"/> and <see cref="Attitude"/>. 
///
/// The full Velocity (Translation + Rotation) can be expressed using a single <see cref="R200"/>. 
/// 
/// All higher geometric Momenta depend on the actual Shape and <see cref="Mass"/> Distribution
/// and are accidental and accounted for by a constant Shape-dependent Factor.
///
/// The most simple Body is an empty HyperSphere with uniform Distribution of the Mass on the Surface
/// (to give it 
/// </remarks>
[DocState(Pass = 2, MTime = "2026-05-24T15:40:19Z", Digest = "33788c20cde0042b5ff18bce6dd1fa3ef11fc0f39bbef44af2be26e4ac9a6a1e", Stale = false, Path = "ga/RigidBody3D.cs", Since = "2026-10-06")]
[Facets(Layer = "domain", Status = "stable", Complexity = 3)]
[Tags("code/rigid_body_physics")]
[System.ComponentModel.Description("A rigid Body in 3D has 6 DoF(Degrees of Freedom): 3 for Position and 3 in Attitude")]
[Concept("physics_simulation")]
public class RigidBody3D
{
	/// <summary> The Mass/ 0th Inertia-Moment of a Body is a constant, unless it is broken up </summary>
	/// <remarks> The Total Mass is the 0th Moment of the Mass Distribution: Sum(i,m[i]) </remarks>
	public readonly float Mass;

	/// <summary> The Radius of a Body is a constant </summary>
	public readonly float Extension;

	/// <summary> 2nd (angular) Inertia-Moment of a Body is a constant as long as the Body does not deform! </summary>
	/// <remarks>
	/// The angular Inertia is the 2nd Moment of the Mass Distribution: Sum(i,x[i]y[i]m[i])
	/// 
	/// This is actually a BiVector and in 3D a Tensor formed from the BiVector Components.
	/// This can also result in the angular Momentum <see cref="AngularMomentum"/> and angular Velocity <see cref="AngularVelocity"/>
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
	///
	/// Inertia is actually a Tensor: 
	/// I[i,j] = Sum(k, m[k]*(r[k]�*d[i,j] - r[k,i]*r[k,j]) with d[i,i] = 1 and 0 otherwise the Kronecker Delta.
	///
	/// I[x,x] = Sum(k, m[k]*(x�+y�+z�-x�)) = Sum(k, m[k]*(y[k]�+z[k]�)) etc. for diagonal Elements and
	/// I[x,y] =-Sum(k, m[k]*x[k]*y[k]) etc. for off-diagonal Elements
	/// 
	/// When rotating around a fixed Axis A, a scalar Inertia can be determined:
	/// I = A[i]I[i,j]A[j]
	///
	/// Usually you need the Inverse to calculate the current angular Velocity
	/// given a constant angular Momentum.
	/// </remarks>
	public IReadOnlyList<Vector3>? InertiaInverse;

	/// <summary> AKA R,X, Position/Center of Mass, 1st Moment of Mass Distribution </summary>
	/// <remarks> The Center of Mass is the 1st Moment of the Mass Distribution: Sum(i,x[i]m[i])/<see cref="Mass"/> </remarks>
	public Vector3 Position;

	/// <summary> AKA P, Momentum = Sum(i,v[i]*m[i])</summary>
	public Vector3 Momentum;

	/// <summary> AKA Velocity </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 3)]
	[Tags("code/rigid_body_physics")]
	[System.ComponentModel.Description("AKA Velocity")]
	[Concept("physics_simulation")]
	public Vector3 Velocity => Momentum * (1 / Mass);

	/// <summary> AKA Omega, Angular Velocity is actual a BiVector </summary>
	/// <remarks>
	/// Due to the Rotation Axis not being aligned with the angular Momentum,
	/// the Axis constantly changes and with it the angular Velocity Vector.
	/// </remarks>
	[Facets(Layer = "domain", Status = "stable", Complexity = 3)]
	[Tags("code/rigid_body_physics")]
	[System.ComponentModel.Description("AKA Omega, Angular Velocity is actual a BiVector")]
	[Concept("physics_simulation")]
	public Vector3? AngularVelocity() => InertiaInverse?.Dot3(AngularMomentum);

	/// <summary> Acceleration is proportional to the applied <paramref name="torque"/> </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 3)]
	[Tags("code/rigid_body_physics")]
	[System.ComponentModel.Description("Acceleration is proportional to the applied torque")]
	[Concept("physics_simulation")]
	public Vector3? AngularAcceleration(Vector3 torque) => InertiaInverse?.Dot3(torque);

	/// <summary> AKA L, angular Momentum = Sum(i,r[i]^p[i]) = Sum(i,r[i]^v[i]*m[i]) = </summary>
	/// <remarks>
	/// The total angular Momentum is composed of an orbital Part and an relative spin-Part:
	/// 
	/// By splitting an internal Position up into the orbital <see cref="Position"/> R
	/// and a relative Position r[i], you also split up the angular Momentum:
	/// 
	/// L = Sum(i,(R + r[i])^v[i]*m[i]) = R^Sum(i,v[i]*m[i]) + Sum(i,r[i]^v[i]*m[i]) = L + s
	/// with s = Sum(i,m[i]*(x[i]�+y[i]�)) = Sum(i,m[i]*r[i]�) the Spin
	/// because v[i]=<see cref="AngularVelocity"/>^r[i] and x[i]^y[i]=-y[i]^x[i]
	///
	/// </remarks>
	public Vector3 AngularMomentum;

	/// <summary>AKA R/Attitude/Rotation; Normalized Rotation<br/>
	/// Gets the attitude.</summary>
	/// <remarks>
	/// By Definition the Length is the Rotation Angle in rad(Radians).
	/// It also defines the Orientation.
	/// 
	/// Assumption: Rotation around the Origin of the Body,
	/// typically placed in the CoM(Center of Mass),
	/// because that is the intersection of the free rotating Axes.
	///
	/// The Angle is coded into the Ratio between real and Vector Part.
	/// An un-normalized Quaternion results in (exponential) Growth of the Vector,
	/// a non-euclidean Transformation.
	///
	/// By encoding the Angle in the Vector Size as in <see cref="graphics.PolarQ"/> you save one Component,
	/// just like in normed <see cref="Complex"/>, where the Angle is a Scalar.
	/// 
	/// But lose the fast Operations possible with <see cref="Complex"/> and <see cref="Quaternion"/>.
	/// The Savings in Space are even less significant for <see cref="Quaternion"/>.
	/// 
	/// </remarks>
	public Vector3 Rotation;
	/// <summary> Lazily-computed <see cref="Quaternion"/> equivalent of <see cref="Rotation"/>. </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 3)]
	[Tags("code/rigid_body_physics")]
	[System.ComponentModel.Description("Lazily-computed Quaternion equivalent of Rotation.")]
	[Concept("physics_simulation")]
	public Quaternion Attitude => _Attitude ??= Rotation.AsQuaternion();
	Quaternion? _Attitude;

	/// <summary>Initializes a new instance of <see cref="RigidBody3D"/> with the specified <paramref name="mass"/> and <paramref name="extension"/>.</summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 3)]
	[Tags("code/rigid_body_physics")]
	[System.ComponentModel.Description("Initializes a new instance of RigidBody3D with the specified mass and extension.")]
	[Concept("physics_simulation")]
	public RigidBody3D(double mass, float extension = 1) {
		Extension = extension;
		Mass = (float) mass;
	}

	/// <summary> Moves/Updates/Propagates this Body in Time by <paramref name="dt"/> </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 3)]
	[Tags("code/rigid_body_physics")]
	[System.ComponentModel.Description("Moves/Updates/Propagates this Body in Time by dt")]
	[Concept("physics_simulation")]
	public void Move(float dt) {
		var angularVelocity = AngularVelocity();
		if (angularVelocity is not null) {
			Rotation += dt * angularVelocity.Value;
		}
		Position += Momentum * (dt / Mass);
		_Attitude = null;
	}
}
