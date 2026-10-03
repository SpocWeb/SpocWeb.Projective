using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using org.SpocWeb.root.array;
using org.SpocWeb.root.extensions;

namespace org.SpocWeb.root.maths.pga.ga;

/// <summary> 5D CGA (3D Conformal Geometric Algebra) with Line, Circle, Plane and Sphere Primitives </summary>
/// <remarks>
/// CGA extends R� by 2 Dimensions:
/// * a Dimension <see cref="Base.e4"/> with e4� = 1 used for Projections and 
/// * a Dimension <see cref="Base.e5"/> with e5� = -1
/// representing the Sphere at Infinity; the Dual to the Origin for Point Coordinates.
///
/// All conformal (i.e., angle-preserving) transformations
/// can be represented as orthogonal transformations in this R^4+1
///
/// Its Elements are:
/// * Vectors are Points, i.e. Spheres with Radius 0
/// * The outer Product of tree Points forms an oriented Circle
///   (or Line if they are collinear or one is at Infinity which is collinear with any Line)
/// * The outer Product of four Points forms an oriented Sphere
///   (or Plane if they are coplanar or one is at Infinity which is coplanar with any Plane)
/// *
///
/// Orthogonal Operators are Quotients of the geometric Product: 
/// * Translations can be defined as the Quotient of 2 Points
/// * Rotations as the Quotient of 2 Planes
/// * Screw Motions are the Quotient of 2 Lines in 3D 
/// </remarks>
/// <example>
/// <code language="yaml">
/// pass: 2
/// mtime: 2026-05-24T16:03:01Z
/// digest: dcffc4d0584896351376f30bfd1af590c3294213cae9290d868807a65e224e57
/// tags: [code/clifford_algebra, code/conformal_geometric_algebra]
/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
/// facets: {layer: domain, status: stable, complexity: 3}
/// </code>
/// </example>
public class R410 : AGeoGebra32<R410>
{
	// just for debug and print output, the basis names
	/// <summary>Gets the _ Basis.</summary>
	static readonly string[] _Basis = { "","e1","e2","e3","e4","e5" // 1 Scalar & 5 Base Vectors
		,"e12","e13","e14","e15","e23","e24","e25","e34","e35","e45" // 10 BiVectors
		,"e123","e124","e125","e134","e135","e145","e234","e235","e245","e345" // 10 TriVectors
		,"e1234","e1235","e1245","e1345","e2345","e12345" }; //5 QuadVectors & 1 Pseudo-Scalar
	/// <inheritdoc />
	/// <example>
	/// <code language="yaml">
	/// pass: 2
	/// mtime: 2026-05-24T16:03:01Z
	/// digest: 07349e24754527c22059659b0bc3b0d768c8c9f9f19a59cf47bcce46b4162274
	/// </code>
	/// </example>
	public override IReadOnlyList<string> Basis => _Basis;

	/// <inheritdoc />
	public override R410 Self() => this;

	/// <summary> 32 = 2^5 Base-Blades in 4+1D, usable as Indices for Components </summary>
	/// <example>
	/// <code language="yaml">
	/// pass: 2
	/// mtime: 2026-06-17T05:58:58Z
	/// digest: 53dd8b312ddbd22bf90abb9f526ca548e54afc550a4271a65c3a407f310932a9
	/// tags: [code/enum, code/clifford_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 1}
	/// </code>
	/// </example>
	[SuppressMessage("ReSharper", "InconsistentNaming")]
	public enum Base : sbyte
	{
		/// <summary> [0] Scalar </summary>
		_1_,

		/// <summary> [0] x Base Vector; e1� = 1 </summary>
		e1,

		/// <summary> [0] y Base Vector; e2� = 1 </summary>
		e2,

		/// <summary> [0] z Base Vector; e3� = 1 </summary>
		e3,

		/// <summary> [0] w Base Vector; e4� = 1 </summary>
		e4,

		/// <summary>[0] i*t Base Vector; e5�=-1<br/>
		/// Represents e45.<br/>
		/// Represents e35.<br/>
		/// Represents e34.<br/>
		/// Represents e25.<br/>
		/// Represents e24.<br/>
		/// Represents e23.<br/>
		/// Represents e15.<br/>
		/// Represents e14.<br/>
		/// Represents e13.</summary>
		e5,

		/// <summary>[0] BiVector: Point-Pair<br/>
		/// Represents e345.<br/>
		/// Represents e245.<br/>
		/// Represents e235.<br/>
		/// Represents e234.<br/>
		/// Represents e145.<br/>
		/// Represents e135.<br/>
		/// Represents e134.<br/>
		/// Represents e125.<br/>
		/// Represents e124.<br/>
		/// Represents e45.<br/>
		/// Represents e35.<br/>
		/// Represents e34.<br/>
		/// Represents e25.<br/>
		/// Represents e24.<br/>
		/// Represents e23.<br/>
		/// Represents e15.<br/>
		/// Represents e14.<br/>
		/// Represents e13.</summary>
		e12,

		/// <summary>Represents e13.</summary>
		e13,

		/// <summary>Represents e14.</summary>
		e14,

		/// <summary>Represents e15.</summary>
		e15,

		/// <summary>Represents e23.</summary>
		e23,

		/// <summary>Represents e24.</summary>
		e24,

		/// <summary>Represents e25.</summary>
		e25,

		/// <summary>Represents e34.</summary>
		e34,

		/// <summary>Represents e35.</summary>
		e35,

		/// <summary>Represents e45.</summary>
		e45,

		/// <summary>[0] TriVector Point-Triple defining a Line: Circles and Lines (when collinear)<br/>
		/// Represents e2345.<br/>
		/// Represents e1345.<br/>
		/// Represents e1245.<br/>
		/// Represents e1235.<br/>
		/// Represents e345.<br/>
		/// Represents e245.<br/>
		/// Represents e235.<br/>
		/// Represents e234.<br/>
		/// Represents e145.<br/>
		/// Represents e135.<br/>
		/// Represents e134.<br/>
		/// Represents e125.<br/>
		/// Represents e124.</summary>
		e123,

		/// <summary>Represents e124.</summary>
		e124,

		/// <summary>Represents e125.</summary>
		e125,

		/// <summary>Represents e134.</summary>
		e134,

		/// <summary>Represents e135.</summary>
		e135,

		/// <summary>Represents e145.</summary>
		e145,

		/// <summary>Represents e234.</summary>
		e234,

		/// <summary>Represents e235.</summary>
		e235,

		/// <summary>Represents e245.</summary>
		e245,

		/// <summary>Represents e345.</summary>
		e345,

		/// <summary>[0] QuadVector Point-Quadruple defining Spheres and Planes (when coplanar)<br/>
		/// Represents e2345.<br/>
		/// Represents e1345.<br/>
		/// Represents e1245.<br/>
		/// Represents e1235.</summary>
		e1234,

		/// <summary>Represents e1235.</summary>
		e1235,

		/// <summary>Represents e1245.</summary>
		e1245,

		/// <summary>Represents e1345.</summary>
		e1345,

		/// <summary>Represents e2345.</summary>
		e2345,

		/// <summary> [0] <see cref="e12345"/>� = -1 because <see cref="e5"/>� = -1 </summary>
		e12345,

		/// <summary> No Component; signals both the End of Components and 0-Elements in the Cayley Tables below </summary>
		_0,
	}

	#region Cayley Tables for different Products in R4,1,0

	/// <summary> Meet/Outer/Wedge Product </summary>
	static readonly Base[][] _ProductOuter = {
	new[] {Base._1_, Base.e1, Base.e2, Base.e3, Base.e4, Base.e5, Base.e12, Base.e13, Base.e14, Base.e15, Base.e23, Base.e24, Base.e25, Base.e34, Base.e35, Base.e45, Base.e123, Base.e124, Base.e125, Base.e134, Base.e135, Base.e145, Base.e234, Base.e235, Base.e245, Base.e345, Base.e1234, Base.e1235, Base.e1245, Base.e1345, Base.e2345, Base.e12345
	}, new[] {Base.e1, Base._0, Base.e12, Base.e13, Base.e14, Base.e15, Base._0, Base._0, Base._0, Base._0, Base.e123, Base.e124, Base.e125, Base.e134, Base.e135, Base.e145, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base.e1234, Base.e1235, Base.e1245, Base.e1345, Base._0, Base._0, Base._0, Base._0, Base.e12345, Base._0
	}, new[] {Base.e2, ~Base.e12, Base._0, Base.e23, Base.e24, Base.e25, Base._0, ~Base.e123, ~Base.e124, ~Base.e125, Base._0, Base._0, Base._0, Base.e234, Base.e235, Base.e245, Base._0, Base._0, Base._0, ~Base.e1234, ~Base.e1235, ~Base.e1245, Base._0, Base._0, Base._0, Base.e2345, Base._0, Base._0, Base._0, ~Base.e12345, Base._0, Base._0
	}, new[] {Base.e3, ~Base.e13, ~Base.e23, Base._0, Base.e34, Base.e35, Base.e123, Base._0, ~Base.e134, ~Base.e135, Base._0, ~Base.e234, ~Base.e235, Base._0, Base._0, Base.e345, Base._0, Base.e1234, Base.e1235, Base._0, Base._0, ~Base.e1345, Base._0, Base._0, ~Base.e2345, Base._0, Base._0, Base._0, Base.e12345, Base._0, Base._0, Base._0
	}, new[] {Base.e4, ~Base.e14, ~Base.e24, ~Base.e34, Base._0, Base.e45, Base.e124, Base.e134, Base._0, ~Base.e145, Base.e234, Base._0, ~Base.e245, Base._0, ~Base.e345, Base._0, ~Base.e1234, Base._0, Base.e1245, Base._0, Base.e1345, Base._0, Base._0, Base.e2345, Base._0, Base._0, Base._0, ~Base.e12345, Base._0, Base._0, Base._0, Base._0
	}, new[] {Base.e5, ~Base.e15, ~Base.e25, ~Base.e35, ~Base.e45, Base._0, Base.e125, Base.e135, Base.e145, Base._0, Base.e235, Base.e245, Base._0, Base.e345, Base._0, Base._0, ~Base.e1235, ~Base.e1245, Base._0, ~Base.e1345, Base._0, Base._0, ~Base.e2345, Base._0, Base._0, Base._0, Base.e12345, Base._0, Base._0, Base._0, Base._0, Base._0
	}, new[] {Base.e12, Base._0, Base._0, Base.e123, Base.e124, Base.e125, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base.e1234, Base.e1235, Base.e1245, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base.e12345, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0
	}, new[] {Base.e13, Base._0, ~Base.e123, Base._0, Base.e134, Base.e135, Base._0, Base._0, Base._0, Base._0, Base._0, ~Base.e1234, ~Base.e1235, Base._0, Base._0, Base.e1345, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, ~Base.e12345, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0
	}, new[] {Base.e14, Base._0, ~Base.e124, ~Base.e134, Base._0, Base.e145, Base._0, Base._0, Base._0, Base._0, Base.e1234, Base._0, ~Base.e1245, Base._0, ~Base.e1345, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base.e12345, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0
	}, new[] {Base.e15, Base._0, ~Base.e125, ~Base.e135, ~Base.e145, Base._0, Base._0, Base._0, Base._0, Base._0, Base.e1235, Base.e1245, Base._0, Base.e1345, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, ~Base.e12345, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0
	}, new[] {Base.e23, Base.e123, Base._0, Base._0, Base.e234, Base.e235, Base._0, Base._0, Base.e1234, Base.e1235, Base._0, Base._0, Base._0, Base._0, Base._0, Base.e2345, Base._0, Base._0, Base._0, Base._0, Base._0, Base.e12345, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0
	}, new[] {Base.e24, Base.e124, Base._0, ~Base.e234, Base._0, Base.e245, Base._0, ~Base.e1234, Base._0, Base.e1245, Base._0, Base._0, Base._0, Base._0, ~Base.e2345, Base._0, Base._0, Base._0, Base._0, Base._0, ~Base.e12345, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0
	}, new[] {Base.e25, Base.e125, Base._0, ~Base.e235, ~Base.e245, Base._0, Base._0, ~Base.e1235, ~Base.e1245, Base._0, Base._0, Base._0, Base._0, Base.e2345, Base._0, Base._0, Base._0, Base._0, Base._0, Base.e12345, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0
	}, new[] {Base.e34, Base.e134, Base.e234, Base._0, Base._0, Base.e345, Base.e1234, Base._0, Base._0, Base.e1345, Base._0, Base._0, Base.e2345, Base._0, Base._0, Base._0, Base._0, Base._0, Base.e12345, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0
	}, new[] {Base.e35, Base.e135, Base.e235, Base._0, ~Base.e345, Base._0, Base.e1235, Base._0, ~Base.e1345, Base._0, Base._0, ~Base.e2345, Base._0, Base._0, Base._0, Base._0, Base._0, ~Base.e12345, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0
	}, new[] {Base.e45, Base.e145, Base.e245, Base.e345, Base._0, Base._0, Base.e1245, Base.e1345, Base._0, Base._0, Base.e2345, Base._0, Base._0, Base._0, Base._0, Base._0, Base.e12345, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0
	}, new[] {Base.e123, Base._0, Base._0, Base._0, Base.e1234, Base.e1235, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base.e12345, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0
	}, new[] {Base.e124, Base._0, Base._0, ~Base.e1234, Base._0, Base.e1245, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, ~Base.e12345, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0
	}, new[] {Base.e125, Base._0, Base._0, ~Base.e1235, ~Base.e1245, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base.e12345, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0
	}, new[] {Base.e134, Base._0, Base.e1234, Base._0, Base._0, Base.e1345, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base.e12345, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0
	}, new[] {Base.e135, Base._0, Base.e1235, Base._0, ~Base.e1345, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, ~Base.e12345, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0
	}, new[] {Base.e145, Base._0, Base.e1245, Base.e1345, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base.e12345, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0
	}, new[] {Base.e234, ~Base.e1234, Base._0, Base._0, Base._0, Base.e2345, Base._0, Base._0, Base._0, ~Base.e12345, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0
	}, new[] {Base.e235, ~Base.e1235, Base._0, Base._0, ~Base.e2345, Base._0, Base._0, Base._0, Base.e12345, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0
	}, new[] {Base.e245, ~Base.e1245, Base._0, Base.e2345, Base._0, Base._0, Base._0, ~Base.e12345, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0
	}, new[] {Base.e345, ~Base.e1345, ~Base.e2345, Base._0, Base._0, Base._0, Base.e12345, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0
	}, new[] {Base.e1234, Base._0, Base._0, Base._0, Base._0, Base.e12345, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0
	}, new[] {Base.e1235, Base._0, Base._0, Base._0, ~Base.e12345, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0
	}, new[] {Base.e1245, Base._0, Base._0, Base.e12345, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0
	}, new[] {Base.e1345, Base._0, ~Base.e12345, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0
	}, new[] {Base.e2345, Base.e12345, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0
	}, new[] {Base.e12345, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0}
	};

	/// <summary> Meet/Outer/Wedge Product </summary>
	public static readonly IReadOnlyList<IReadOnlyList<Base>> ProductOuter = _ProductOuter;

	/// <summary>Gets the _ Product Geometric.</summary>
	static readonly Base[][] _ProductGeometric = {
	new[] {Base._1_, Base.e1, Base.e2, Base.e3, Base.e4, Base.e5, Base.e12, Base.e13, Base.e14, Base.e15, Base.e23, Base.e24, Base.e25, Base.e34, Base.e35, Base.e45, Base.e123, Base.e124, Base.e125, Base.e134, Base.e135, Base.e145, Base.e234, Base.e235, Base.e245, Base.e345, Base.e1234, Base.e1235, Base.e1245, Base.e1345, Base.e2345, Base.e12345
	}, new[] {Base.e1, Base._1_, Base.e12, Base.e13, Base.e14, Base.e15, Base.e2, Base.e3, Base.e4, Base.e5, Base.e123, Base.e124, Base.e125, Base.e134, Base.e135, Base.e145, Base.e23, Base.e24, Base.e25, Base.e34, Base.e35, Base.e45, Base.e1234, Base.e1235, Base.e1245, Base.e1345, Base.e234, Base.e235, Base.e245, Base.e345, Base.e12345, Base.e2345
	}, new[] {Base.e2, ~Base.e12, Base._1_, Base.e23, Base.e24, Base.e25, ~Base.e1, ~Base.e123, ~Base.e124, ~Base.e125, Base.e3, Base.e4, Base.e5, Base.e234, Base.e235, Base.e245, ~Base.e13, ~Base.e14, ~Base.e15, ~Base.e1234, ~Base.e1235, ~Base.e1245, Base.e34, Base.e35, Base.e45, Base.e2345, ~Base.e134, ~Base.e135, ~Base.e145, ~Base.e12345, Base.e345, ~Base.e1345
	}, new[] {Base.e3, ~Base.e13, ~Base.e23, Base._1_, Base.e34, Base.e35, Base.e123, ~Base.e1, ~Base.e134, ~Base.e135, ~Base.e2, ~Base.e234, ~Base.e235, Base.e4, Base.e5, Base.e345, Base.e12, Base.e1234, Base.e1235, ~Base.e14, ~Base.e15, ~Base.e1345, ~Base.e24, ~Base.e25, ~Base.e2345, Base.e45, Base.e124, Base.e125, Base.e12345, ~Base.e145, ~Base.e245, Base.e1245
	}, new[] {Base.e4, ~Base.e14, ~Base.e24, ~Base.e34, Base._1_, Base.e45, Base.e124, Base.e134, ~Base.e1, ~Base.e145, Base.e234, ~Base.e2, ~Base.e245, ~Base.e3, ~Base.e345, Base.e5, ~Base.e1234, Base.e12, Base.e1245, Base.e13, Base.e1345, ~Base.e15, Base.e23, Base.e2345, ~Base.e25, ~Base.e35, ~Base.e123, ~Base.e12345, Base.e125, Base.e135, Base.e235, ~Base.e1235
	}, new[] {Base.e5, ~Base.e15, ~Base.e25, ~Base.e35, ~Base.e45, ~Base._1_, Base.e125, Base.e135, Base.e145, Base.e1, Base.e235, Base.e245, Base.e2, Base.e345, Base.e3, Base.e4, ~Base.e1235, ~Base.e1245, ~Base.e12, ~Base.e1345, ~Base.e13, ~Base.e14, ~Base.e2345, ~Base.e23, ~Base.e24, ~Base.e34, Base.e12345, Base.e123, Base.e124, Base.e134, Base.e234, ~Base.e1234
	}, new[] {Base.e12, ~Base.e2, Base.e1, Base.e123, Base.e124, Base.e125, ~Base._1_, ~Base.e23, ~Base.e24, ~Base.e25, Base.e13, Base.e14, Base.e15, Base.e1234, Base.e1235, Base.e1245, ~Base.e3, ~Base.e4, ~Base.e5, ~Base.e234, ~Base.e235, ~Base.e245, Base.e134, Base.e135, Base.e145, Base.e12345, ~Base.e34, ~Base.e35, ~Base.e45, ~Base.e2345, Base.e1345, ~Base.e345
	}, new[] {Base.e13, ~Base.e3, ~Base.e123, Base.e1, Base.e134, Base.e135, Base.e23, ~Base._1_, ~Base.e34, ~Base.e35, ~Base.e12, ~Base.e1234, ~Base.e1235, Base.e14, Base.e15, Base.e1345, Base.e2, Base.e234, Base.e235, ~Base.e4, ~Base.e5, ~Base.e345, ~Base.e124, ~Base.e125, ~Base.e12345, Base.e145, Base.e24, Base.e25, Base.e2345, ~Base.e45, ~Base.e1245, Base.e245
	}, new[] {Base.e14, ~Base.e4, ~Base.e124, ~Base.e134, Base.e1, Base.e145, Base.e24, Base.e34, ~Base._1_, ~Base.e45, Base.e1234, ~Base.e12, ~Base.e1245, ~Base.e13, ~Base.e1345, Base.e15, ~Base.e234, Base.e2, Base.e245, Base.e3, Base.e345, ~Base.e5, Base.e123, Base.e12345, ~Base.e125, ~Base.e135, ~Base.e23, ~Base.e2345, Base.e25, Base.e35, Base.e1235, ~Base.e235
	}, new[] {Base.e15, ~Base.e5, ~Base.e125, ~Base.e135, ~Base.e145, ~Base.e1, Base.e25, Base.e35, Base.e45, Base._1_, Base.e1235, Base.e1245, Base.e12, Base.e1345, Base.e13, Base.e14, ~Base.e235, ~Base.e245, ~Base.e2, ~Base.e345, ~Base.e3, ~Base.e4, ~Base.e12345, ~Base.e123, ~Base.e124, ~Base.e134, Base.e2345, Base.e23, Base.e24, Base.e34, Base.e1234, ~Base.e234
	}, new[] {Base.e23, Base.e123, ~Base.e3, Base.e2, Base.e234, Base.e235, ~Base.e13, Base.e12, Base.e1234, Base.e1235, ~Base._1_, ~Base.e34, ~Base.e35, Base.e24, Base.e25, Base.e2345, ~Base.e1, ~Base.e134, ~Base.e135, Base.e124, Base.e125, Base.e12345, ~Base.e4, ~Base.e5, ~Base.e345, Base.e245, ~Base.e14, ~Base.e15, ~Base.e1345, Base.e1245, ~Base.e45, ~Base.e145
	}, new[] {Base.e24, Base.e124, ~Base.e4, ~Base.e234, Base.e2, Base.e245, ~Base.e14, ~Base.e1234, Base.e12, Base.e1245, Base.e34, ~Base._1_, ~Base.e45, ~Base.e23, ~Base.e2345, Base.e25, Base.e134, ~Base.e1, ~Base.e145, ~Base.e123, ~Base.e12345, Base.e125, Base.e3, Base.e345, ~Base.e5, ~Base.e235, Base.e13, Base.e1345, ~Base.e15, ~Base.e1235, Base.e35, Base.e135
	}, new[] {Base.e25, Base.e125, ~Base.e5, ~Base.e235, ~Base.e245, ~Base.e2, ~Base.e15, ~Base.e1235, ~Base.e1245, ~Base.e12, Base.e35, Base.e45, Base._1_, Base.e2345, Base.e23, Base.e24, Base.e135, Base.e145, Base.e1, Base.e12345, Base.e123, Base.e124, ~Base.e345, ~Base.e3, ~Base.e4, ~Base.e234, ~Base.e1345, ~Base.e13, ~Base.e14, ~Base.e1234, Base.e34, Base.e134
	}, new[] {Base.e34, Base.e134, Base.e234, ~Base.e4, Base.e3, Base.e345, Base.e1234, ~Base.e14, Base.e13, Base.e1345, ~Base.e24, Base.e23, Base.e2345, ~Base._1_, ~Base.e45, Base.e35, ~Base.e124, Base.e123, Base.e12345, ~Base.e1, ~Base.e145, Base.e135, ~Base.e2, ~Base.e245, Base.e235, ~Base.e5, ~Base.e12, ~Base.e1245, Base.e1235, ~Base.e15, ~Base.e25, ~Base.e125
	}, new[] {Base.e35, Base.e135, Base.e235, ~Base.e5, ~Base.e345, ~Base.e3, Base.e1235, ~Base.e15, ~Base.e1345, ~Base.e13, ~Base.e25, ~Base.e2345, ~Base.e23, Base.e45, Base._1_, Base.e34, ~Base.e125, ~Base.e12345, ~Base.e123, Base.e145, Base.e1, Base.e134, Base.e245, Base.e2, Base.e234, ~Base.e4, Base.e1245, Base.e12, Base.e1234, ~Base.e14, ~Base.e24, ~Base.e124
	}, new[] {Base.e45, Base.e145, Base.e245, Base.e345, ~Base.e5, ~Base.e4, Base.e1245, Base.e1345, ~Base.e15, ~Base.e14, Base.e2345, ~Base.e25, ~Base.e24, ~Base.e35, ~Base.e34, Base._1_, Base.e12345, ~Base.e125, ~Base.e124, ~Base.e135, ~Base.e134, Base.e1, ~Base.e235, ~Base.e234, Base.e2, Base.e3, ~Base.e1235, ~Base.e1234, Base.e12, Base.e13, Base.e23, Base.e123
	}, new[] {Base.e123, Base.e23, ~Base.e13, Base.e12, Base.e1234, Base.e1235, ~Base.e3, Base.e2, Base.e234, Base.e235, ~Base.e1, ~Base.e134, ~Base.e135, Base.e124, Base.e125, Base.e12345, ~Base._1_, ~Base.e34, ~Base.e35, Base.e24, Base.e25, Base.e2345, ~Base.e14, ~Base.e15, ~Base.e1345, Base.e1245, ~Base.e4, ~Base.e5, ~Base.e345, Base.e245, ~Base.e145, ~Base.e45
	}, new[] {Base.e124, Base.e24, ~Base.e14, ~Base.e1234, Base.e12, Base.e1245, ~Base.e4, ~Base.e234, Base.e2, Base.e245, Base.e134, ~Base.e1, ~Base.e145, ~Base.e123, ~Base.e12345, Base.e125, Base.e34, ~Base._1_, ~Base.e45, ~Base.e23, ~Base.e2345, Base.e25, Base.e13, Base.e1345, ~Base.e15, ~Base.e1235, Base.e3, Base.e345, ~Base.e5, ~Base.e235, Base.e135, Base.e35
	}, new[] {Base.e125, Base.e25, ~Base.e15, ~Base.e1235, ~Base.e1245, ~Base.e12, ~Base.e5, ~Base.e235, ~Base.e245, ~Base.e2, Base.e135, Base.e145, Base.e1, Base.e12345, Base.e123, Base.e124, Base.e35, Base.e45, Base._1_, Base.e2345, Base.e23, Base.e24, ~Base.e1345, ~Base.e13, ~Base.e14, ~Base.e1234, ~Base.e345, ~Base.e3, ~Base.e4, ~Base.e234, Base.e134, Base.e34
	}, new[] {Base.e134, Base.e34, Base.e1234, ~Base.e14, Base.e13, Base.e1345, Base.e234, ~Base.e4, Base.e3, Base.e345, ~Base.e124, Base.e123, Base.e12345, ~Base.e1, ~Base.e145, Base.e135, ~Base.e24, Base.e23, Base.e2345, ~Base._1_, ~Base.e45, Base.e35, ~Base.e12, ~Base.e1245, Base.e1235, ~Base.e15, ~Base.e2, ~Base.e245, Base.e235, ~Base.e5, ~Base.e125, ~Base.e25
	}, new[] {Base.e135, Base.e35, Base.e1235, ~Base.e15, ~Base.e1345, ~Base.e13, Base.e235, ~Base.e5, ~Base.e345, ~Base.e3, ~Base.e125, ~Base.e12345, ~Base.e123, Base.e145, Base.e1, Base.e134, ~Base.e25, ~Base.e2345, ~Base.e23, Base.e45, Base._1_, Base.e34, Base.e1245, Base.e12, Base.e1234, ~Base.e14, Base.e245, Base.e2, Base.e234, ~Base.e4, ~Base.e124, ~Base.e24
	}, new[] {Base.e145, Base.e45, Base.e1245, Base.e1345, ~Base.e15, ~Base.e14, Base.e245, Base.e345, ~Base.e5, ~Base.e4, Base.e12345, ~Base.e125, ~Base.e124, ~Base.e135, ~Base.e134, Base.e1, Base.e2345, ~Base.e25, ~Base.e24, ~Base.e35, ~Base.e34, Base._1_, ~Base.e1235, ~Base.e1234, Base.e12, Base.e13, ~Base.e235, ~Base.e234, Base.e2, Base.e3, Base.e123, Base.e23
	}, new[] {Base.e234, ~Base.e1234, Base.e34, ~Base.e24, Base.e23, Base.e2345, ~Base.e134, Base.e124, ~Base.e123, ~Base.e12345, ~Base.e4, Base.e3, Base.e345, ~Base.e2, ~Base.e245, Base.e235, Base.e14, ~Base.e13, ~Base.e1345, Base.e12, Base.e1245, ~Base.e1235, ~Base._1_, ~Base.e45, Base.e35, ~Base.e25, Base.e1, Base.e145, ~Base.e135, Base.e125, ~Base.e5, Base.e15
	}, new[] {Base.e235, ~Base.e1235, Base.e35, ~Base.e25, ~Base.e2345, ~Base.e23, ~Base.e135, Base.e125, Base.e12345, Base.e123, ~Base.e5, ~Base.e345, ~Base.e3, Base.e245, Base.e2, Base.e234, Base.e15, Base.e1345, Base.e13, ~Base.e1245, ~Base.e12, ~Base.e1234, Base.e45, Base._1_, Base.e34, ~Base.e24, ~Base.e145, ~Base.e1, ~Base.e134, Base.e124, ~Base.e4, Base.e14
	}, new[] {Base.e245, ~Base.e1245, Base.e45, Base.e2345, ~Base.e25, ~Base.e24, ~Base.e145, ~Base.e12345, Base.e125, Base.e124, Base.e345, ~Base.e5, ~Base.e4, ~Base.e235, ~Base.e234, Base.e2, ~Base.e1345, Base.e15, Base.e14, Base.e1235, Base.e1234, ~Base.e12, ~Base.e35, ~Base.e34, Base._1_, Base.e23, Base.e135, Base.e134, ~Base.e1, ~Base.e123, Base.e3, ~Base.e13
	}, new[] {Base.e345, ~Base.e1345, ~Base.e2345, Base.e45, ~Base.e35, ~Base.e34, Base.e12345, ~Base.e145, Base.e135, Base.e134, ~Base.e245, Base.e235, Base.e234, ~Base.e5, ~Base.e4, Base.e3, Base.e1245, ~Base.e1235, ~Base.e1234, Base.e15, Base.e14, ~Base.e13, Base.e25, Base.e24, ~Base.e23, Base._1_, ~Base.e125, ~Base.e124, Base.e123, ~Base.e1, ~Base.e2, Base.e12
	}, new[] {Base.e1234, ~Base.e234, Base.e134, ~Base.e124, Base.e123, Base.e12345, ~Base.e34, Base.e24, ~Base.e23, ~Base.e2345, ~Base.e14, Base.e13, Base.e1345, ~Base.e12, ~Base.e1245, Base.e1235, Base.e4, ~Base.e3, ~Base.e345, Base.e2, Base.e245, ~Base.e235, ~Base.e1, ~Base.e145, Base.e135, ~Base.e125, Base._1_, Base.e45, ~Base.e35, Base.e25, ~Base.e15, Base.e5
	}, new[] {Base.e1235, ~Base.e235, Base.e135, ~Base.e125, ~Base.e12345, ~Base.e123, ~Base.e35, Base.e25, Base.e2345, Base.e23, ~Base.e15, ~Base.e1345, ~Base.e13, Base.e1245, Base.e12, Base.e1234, Base.e5, Base.e345, Base.e3, ~Base.e245, ~Base.e2, ~Base.e234, Base.e145, Base.e1, Base.e134, ~Base.e124, ~Base.e45, ~Base._1_, ~Base.e34, Base.e24, ~Base.e14, Base.e4
	}, new[] {Base.e1245, ~Base.e245, Base.e145, Base.e12345, ~Base.e125, ~Base.e124, ~Base.e45, ~Base.e2345, Base.e25, Base.e24, Base.e1345, ~Base.e15, ~Base.e14, ~Base.e1235, ~Base.e1234, Base.e12, ~Base.e345, Base.e5, Base.e4, Base.e235, Base.e234, ~Base.e2, ~Base.e135, ~Base.e134, Base.e1, Base.e123, Base.e35, Base.e34, ~Base._1_, ~Base.e23, Base.e13, ~Base.e3
	}, new[] {Base.e1345, ~Base.e345, ~Base.e12345, Base.e145, ~Base.e135, ~Base.e134, Base.e2345, ~Base.e45, Base.e35, Base.e34, ~Base.e1245, Base.e1235, Base.e1234, ~Base.e15, ~Base.e14, Base.e13, Base.e245, ~Base.e235, ~Base.e234, Base.e5, Base.e4, ~Base.e3, Base.e125, Base.e124, ~Base.e123, Base.e1, ~Base.e25, ~Base.e24, Base.e23, ~Base._1_, ~Base.e12, Base.e2
	}, new[] {Base.e2345, Base.e12345, ~Base.e345, Base.e245, ~Base.e235, ~Base.e234, ~Base.e1345, Base.e1245, ~Base.e1235, ~Base.e1234, ~Base.e45, Base.e35, Base.e34, ~Base.e25, ~Base.e24, Base.e23, ~Base.e145, Base.e135, Base.e134, ~Base.e125, ~Base.e124, Base.e123, Base.e5, Base.e4, ~Base.e3, Base.e2, Base.e15, Base.e14, ~Base.e13, Base.e12, ~Base._1_, ~Base.e1
	}, new[] {Base.e12345, Base.e2345, ~Base.e1345, Base.e1245, ~Base.e1235, ~Base.e1234, ~Base.e345, Base.e245, ~Base.e235, ~Base.e234, ~Base.e145, Base.e135, Base.e134, ~Base.e125, ~Base.e124, Base.e123, ~Base.e45, Base.e35, Base.e34, ~Base.e25, ~Base.e24, Base.e23, Base.e15, Base.e14, ~Base.e13, Base.e12, Base.e5, Base.e4, ~Base.e3, Base.e2, ~Base.e1, ~Base._1_
	}
	};

	/// <summary>Gets the product Geometric.</summary>
	public static readonly IReadOnlyList<IReadOnlyList<Base>> ProductGeometric = _ProductGeometric;

	/// <summary> Dot/Inner Product </summary>
	static readonly Base[][] _ProductDot = {
	new[] {Base._1_, Base.e1, Base.e2, Base.e3, Base.e4, Base.e5, Base.e12, Base.e13, Base.e14, Base.e15, Base.e23, Base.e24, Base.e25, Base.e34, Base.e35, Base.e45, Base.e123, Base.e124, Base.e125, Base.e134, Base.e135, Base.e145, Base.e234, Base.e235, Base.e245, Base.e345, Base.e1234, Base.e1235, Base.e1245, Base.e1345, Base.e2345, Base.e12345
	}, new[] {Base.e1, Base._1_, Base._0, Base._0, Base._0, Base._0, Base.e2, Base.e3, Base.e4, Base.e5, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base.e23, Base.e24, Base.e25, Base.e34, Base.e35, Base.e45, Base._0, Base._0, Base._0, Base._0, Base.e234, Base.e235, Base.e245, Base.e345, Base._0, Base.e2345
	}, new[] {Base.e2, Base._0, Base._1_, Base._0, Base._0, Base._0, ~Base.e1, Base._0, Base._0, Base._0, Base.e3, Base.e4, Base.e5, Base._0, Base._0, Base._0, ~Base.e13, ~Base.e14, ~Base.e15, Base._0, Base._0, Base._0, Base.e34, Base.e35, Base.e45, Base._0, ~Base.e134, ~Base.e135, ~Base.e145, Base._0, Base.e345, ~Base.e1345
	}, new[] {Base.e3, Base._0, Base._0, Base._1_, Base._0, Base._0, Base._0, ~Base.e1, Base._0, Base._0, ~Base.e2, Base._0, Base._0, Base.e4, Base.e5, Base._0, Base.e12, Base._0, Base._0, ~Base.e14, ~Base.e15, Base._0, ~Base.e24, ~Base.e25, Base._0, Base.e45, Base.e124, Base.e125, Base._0, ~Base.e145, ~Base.e245, Base.e1245
	}, new[] {Base.e4, Base._0, Base._0, Base._0, Base._1_, Base._0, Base._0, Base._0, ~Base.e1, Base._0, Base._0, ~Base.e2, Base._0, ~Base.e3, Base._0, Base.e5, Base._0, Base.e12, Base._0, Base.e13, Base._0, ~Base.e15, Base.e23, Base._0, ~Base.e25, ~Base.e35, ~Base.e123, Base._0, Base.e125, Base.e135, Base.e235, ~Base.e1235
	}, new[] {Base.e5, Base._0, Base._0, Base._0, Base._0, ~Base._1_, Base._0, Base._0, Base._0, Base.e1, Base._0, Base._0, Base.e2, Base._0, Base.e3, Base.e4, Base._0, Base._0, ~Base.e12, Base._0, ~Base.e13, ~Base.e14, Base._0, ~Base.e23, ~Base.e24, ~Base.e34, Base._0, Base.e123, Base.e124, Base.e134, Base.e234, ~Base.e1234
	}, new[] {Base.e12, ~Base.e2, Base.e1, Base._0, Base._0, Base._0, ~Base._1_, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, ~Base.e3, ~Base.e4, ~Base.e5, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, ~Base.e34, ~Base.e35, ~Base.e45, Base._0, Base._0, ~Base.e345
	}, new[] {Base.e13, ~Base.e3, Base._0, Base.e1, Base._0, Base._0, Base._0, ~Base._1_, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base.e2, Base._0, Base._0, ~Base.e4, ~Base.e5, Base._0, Base._0, Base._0, Base._0, Base._0, Base.e24, Base.e25, Base._0, ~Base.e45, Base._0, Base.e245
	}, new[] {Base.e14, ~Base.e4, Base._0, Base._0, Base.e1, Base._0, Base._0, Base._0, ~Base._1_, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base.e2, Base._0, Base.e3, Base._0, ~Base.e5, Base._0, Base._0, Base._0, Base._0, ~Base.e23, Base._0, Base.e25, Base.e35, Base._0, ~Base.e235
	}, new[] {Base.e15, ~Base.e5, Base._0, Base._0, Base._0, ~Base.e1, Base._0, Base._0, Base._0, Base._1_, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, ~Base.e2, Base._0, ~Base.e3, ~Base.e4, Base._0, Base._0, Base._0, Base._0, Base._0, Base.e23, Base.e24, Base.e34, Base._0, ~Base.e234
	}, new[] {Base.e23, Base._0, ~Base.e3, Base.e2, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, ~Base._1_, Base._0, Base._0, Base._0, Base._0, Base._0, ~Base.e1, Base._0, Base._0, Base._0, Base._0, Base._0, ~Base.e4, ~Base.e5, Base._0, Base._0, ~Base.e14, ~Base.e15, Base._0, Base._0, ~Base.e45, ~Base.e145
	}, new[] {Base.e24, Base._0, ~Base.e4, Base._0, Base.e2, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, ~Base._1_, Base._0, Base._0, Base._0, Base._0, Base._0, ~Base.e1, Base._0, Base._0, Base._0, Base._0, Base.e3, Base._0, ~Base.e5, Base._0, Base.e13, Base._0, ~Base.e15, Base._0, Base.e35, Base.e135
	}, new[] {Base.e25, Base._0, ~Base.e5, Base._0, Base._0, ~Base.e2, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._1_, Base._0, Base._0, Base._0, Base._0, Base._0, Base.e1, Base._0, Base._0, Base._0, Base._0, ~Base.e3, ~Base.e4, Base._0, Base._0, ~Base.e13, ~Base.e14, Base._0, Base.e34, Base.e134
	}, new[] {Base.e34, Base._0, Base._0, ~Base.e4, Base.e3, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, ~Base._1_, Base._0, Base._0, Base._0, Base._0, Base._0, ~Base.e1, Base._0, Base._0, ~Base.e2, Base._0, Base._0, ~Base.e5, ~Base.e12, Base._0, Base._0, ~Base.e15, ~Base.e25, ~Base.e125
	}, new[] {Base.e35, Base._0, Base._0, ~Base.e5, Base._0, ~Base.e3, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._1_, Base._0, Base._0, Base._0, Base._0, Base._0, Base.e1, Base._0, Base._0, Base.e2, Base._0, ~Base.e4, Base._0, Base.e12, Base._0, ~Base.e14, ~Base.e24, ~Base.e124
	}, new[] {Base.e45, Base._0, Base._0, Base._0, ~Base.e5, ~Base.e4, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._1_, Base._0, Base._0, Base._0, Base._0, Base._0, Base.e1, Base._0, Base._0, Base.e2, Base.e3, Base._0, Base._0, Base.e12, Base.e13, Base.e23, Base.e123
	}, new[] {Base.e123, Base.e23, ~Base.e13, Base.e12, Base._0, Base._0, ~Base.e3, Base.e2, Base._0, Base._0, ~Base.e1, Base._0, Base._0, Base._0, Base._0, Base._0, ~Base._1_, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, ~Base.e4, ~Base.e5, Base._0, Base._0, Base._0, ~Base.e45
	}, new[] {Base.e124, Base.e24, ~Base.e14, Base._0, Base.e12, Base._0, ~Base.e4, Base._0, Base.e2, Base._0, Base._0, ~Base.e1, Base._0, Base._0, Base._0, Base._0, Base._0, ~Base._1_, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base.e3, Base._0, ~Base.e5, Base._0, Base._0, Base.e35
	}, new[] {Base.e125, Base.e25, ~Base.e15, Base._0, Base._0, ~Base.e12, ~Base.e5, Base._0, Base._0, ~Base.e2, Base._0, Base._0, Base.e1, Base._0, Base._0, Base._0, Base._0, Base._0, Base._1_, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, ~Base.e3, ~Base.e4, Base._0, Base._0, Base.e34
	}, new[] {Base.e134, Base.e34, Base._0, ~Base.e14, Base.e13, Base._0, Base._0, ~Base.e4, Base.e3, Base._0, Base._0, Base._0, Base._0, ~Base.e1, Base._0, Base._0, Base._0, Base._0, Base._0, ~Base._1_, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, ~Base.e2, Base._0, Base._0, ~Base.e5, Base._0, ~Base.e25
	}, new[] {Base.e135, Base.e35, Base._0, ~Base.e15, Base._0, ~Base.e13, Base._0, ~Base.e5, Base._0, ~Base.e3, Base._0, Base._0, Base._0, Base._0, Base.e1, Base._0, Base._0, Base._0, Base._0, Base._0, Base._1_, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base.e2, Base._0, ~Base.e4, Base._0, ~Base.e24
	}, new[] {Base.e145, Base.e45, Base._0, Base._0, ~Base.e15, ~Base.e14, Base._0, Base._0, ~Base.e5, ~Base.e4, Base._0, Base._0, Base._0, Base._0, Base._0, Base.e1, Base._0, Base._0, Base._0, Base._0, Base._0, Base._1_, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base.e2, Base.e3, Base._0, Base.e23
	}, new[] {Base.e234, Base._0, Base.e34, ~Base.e24, Base.e23, Base._0, Base._0, Base._0, Base._0, Base._0, ~Base.e4, Base.e3, Base._0, ~Base.e2, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, ~Base._1_, Base._0, Base._0, Base._0, Base.e1, Base._0, Base._0, Base._0, ~Base.e5, Base.e15
	}, new[] {Base.e235, Base._0, Base.e35, ~Base.e25, Base._0, ~Base.e23, Base._0, Base._0, Base._0, Base._0, ~Base.e5, Base._0, ~Base.e3, Base._0, Base.e2, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._1_, Base._0, Base._0, Base._0, ~Base.e1, Base._0, Base._0, ~Base.e4, Base.e14
	}, new[] {Base.e245, Base._0, Base.e45, Base._0, ~Base.e25, ~Base.e24, Base._0, Base._0, Base._0, Base._0, Base._0, ~Base.e5, ~Base.e4, Base._0, Base._0, Base.e2, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._1_, Base._0, Base._0, Base._0, ~Base.e1, Base._0, Base.e3, ~Base.e13
	}, new[] {Base.e345, Base._0, Base._0, Base.e45, ~Base.e35, ~Base.e34, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, ~Base.e5, ~Base.e4, Base.e3, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._1_, Base._0, Base._0, Base._0, ~Base.e1, ~Base.e2, Base.e12
	}, new[] {Base.e1234, ~Base.e234, Base.e134, ~Base.e124, Base.e123, Base._0, ~Base.e34, Base.e24, ~Base.e23, Base._0, ~Base.e14, Base.e13, Base._0, ~Base.e12, Base._0, Base._0, Base.e4, ~Base.e3, Base._0, Base.e2, Base._0, Base._0, ~Base.e1, Base._0, Base._0, Base._0, Base._1_, Base._0, Base._0, Base._0, Base._0, Base.e5
	}, new[] {Base.e1235, ~Base.e235, Base.e135, ~Base.e125, Base._0, ~Base.e123, ~Base.e35, Base.e25, Base._0, Base.e23, ~Base.e15, Base._0, ~Base.e13, Base._0, Base.e12, Base._0, Base.e5, Base._0, Base.e3, Base._0, ~Base.e2, Base._0, Base._0, Base.e1, Base._0, Base._0, Base._0, ~Base._1_, Base._0, Base._0, Base._0, Base.e4
	}, new[] {Base.e1245, ~Base.e245, Base.e145, Base._0, ~Base.e125, ~Base.e124, ~Base.e45, Base._0, Base.e25, Base.e24, Base._0, ~Base.e15, ~Base.e14, Base._0, Base._0, Base.e12, Base._0, Base.e5, Base.e4, Base._0, Base._0, ~Base.e2, Base._0, Base._0, Base.e1, Base._0, Base._0, Base._0, ~Base._1_, Base._0, Base._0, ~Base.e3
	}, new[] {Base.e1345, ~Base.e345, Base._0, Base.e145, ~Base.e135, ~Base.e134, Base._0, ~Base.e45, Base.e35, Base.e34, Base._0, Base._0, Base._0, ~Base.e15, ~Base.e14, Base.e13, Base._0, Base._0, Base._0, Base.e5, Base.e4, ~Base.e3, Base._0, Base._0, Base._0, Base.e1, Base._0, Base._0, Base._0, ~Base._1_, Base._0, Base.e2
	}, new[] {Base.e2345, Base._0, ~Base.e345, Base.e245, ~Base.e235, ~Base.e234, Base._0, Base._0, Base._0, Base._0, ~Base.e45, Base.e35, Base.e34, ~Base.e25, ~Base.e24, Base.e23, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base.e5, Base.e4, ~Base.e3, Base.e2, Base._0, Base._0, Base._0, Base._0, ~Base._1_, ~Base.e1
	}, new[] {Base.e12345, Base.e2345, ~Base.e1345, Base.e1245, ~Base.e1235, ~Base.e1234, ~Base.e345, Base.e245, ~Base.e235, ~Base.e234, ~Base.e145, Base.e135, Base.e134, ~Base.e125, ~Base.e124, Base.e123, ~Base.e45, Base.e35, Base.e34, ~Base.e25, ~Base.e24, Base.e23, Base.e15, Base.e14, ~Base.e13, Base.e12, Base.e5, Base.e4, ~Base.e3, Base.e2, ~Base.e1, ~Base._1_}
	};

	/// <summary> Dot/Inner Product </summary>
	public static readonly IReadOnlyList<IReadOnlyList<Base>> ProductDot = _ProductDot;

	/// <summary>Gets the _ Products.<br/>
	/// Gets the products.</summary>
	static readonly Base[][][] _Products = { _ProductGeometric, _ProductDot, _ProductOuter};
	/// <summary>Gets the products.</summary>
	public static readonly IReadOnlyList<IReadOnlyList<IReadOnlyList<Base>>> Products = _Products;

	#endregion Cayley Tables for different Products in R3,0,0

	/// <summary> Creates a new <see cref="R410"/> G(4,1,0) CGA multivector from the given component array. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/clifford_algebra, code/conformal_geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 3}
	/// </code>
	/// </example>
	public static R410 New(params float[] f) => New((IReadOnlyList<float>) f);
	/// <inheritdoc cref="New(float[])"/>
	public static R410 New(IReadOnlyList<float> f) => new(f);
	/// <inheritdoc cref="New(float[])"/>
	public static R410 New(double f = 0, int idx = 0) => new(f, idx);
	/// <inheritdoc cref="New(float[])"/>
	public static R410 New(double f = 0, Base idx = 0) => new(f, idx);

	/// <summary>Gets or sets the element at the specified <paramref name="index"/>.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/clifford_algebra, code/conformal_geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 3}
	/// </code>
	/// </example>
	public float this[Base idx] => _C[(int) idx];

	/// <summary>Initializes a new instance of <see cref="R410"/> with the specified <paramref name="f"/> and <paramref name="idx"/>.<br/>
	/// Initializes a new instance of <see cref="R410"/> with the specified <paramref name="f"/> and <paramref name="idx"/>.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/clifford_algebra, code/conformal_geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 3}
	/// </code>
	/// </example>
	public R410(double f = 0, Base idx = 0) : base(f, (int)idx) {}
	/// <summary>Initializes a new instance of <see cref="R410"/> with the specified <paramref name="f"/> and <paramref name="idx"/>.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/clifford_algebra, code/conformal_geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 3}
	/// </code>
	/// </example>
	public R410(double f = 0, int idx = 0) : base(f, idx) {}

	/// <inheritdoc />
	public override R410 Create(IReadOnlyList<float> values) => new(values);
	/// <inheritdoc cref="Create(IReadOnlyList{float})"/>
	public override R410 Create(IList<float> values) => new((IReadOnlyList<float>)values);
	/// <inheritdoc />
	protected override R410 Create_(float[] values) => new (values);

	/// <summary> Unchecked private Constructor for Speed </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/clifford_algebra, code/conformal_geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 3}
	/// </code>
	/// </example>
	R410(float[] f) : base(f) {}

	/// <summary> Checked Constructor with Copy </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/clifford_algebra, code/conformal_geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 3}
	/// </code>
	/// </example>
	public R410(IReadOnlyList<float> values) : base(values) {}

	#region Overloaded Operators

	/// <inheritdoc />
	public override R410 Dual() => new(_C.Dual32C());
	/// <inheritdoc />
	public override double NormSqr() => _C.NormSqr32R410();

	/// <summary> * geometric product. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/clifford_algebra, code/conformal_geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 3}
	/// </code>
	/// </example>
	public override R410 Times(IReadOnlyList<float> factor) => new(_C.Times32C(factor));
	/// <inheritdoc />
	public override R410 TimesR(IReadOnlyList<float> factor) => new(factor.Times32C(_C));

	/// <summary> ^ Meet/Wedge/ outer product. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/clifford_algebra, code/conformal_geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 3}
	/// </code>
	/// </example>
	public override R410 Meet(IReadOnlyList<float> that) => new(_C.Wedge32(that));
	/// <inheritdoc />
	public override R410 MeetR(IReadOnlyList<float> that) => new(that.Wedge32(_C));

	/// <summary> &amp; Join/V/ regressive product. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/clifford_algebra, code/conformal_geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 3}
	/// </code>
	/// </example>
	public override R410 Join(IReadOnlyList<float> that) => new(_C.Join32C(that));

	/// <summary> | Dot/ inner product. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/clifford_algebra, code/conformal_geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 3}
	/// </code>
	/// </example>
	public override R410 Dot(IReadOnlyList<float> that)=> new(_C.Dot32C(that));

	#endregion

	#region basis blades
	// ReSharper disable InconsistentNaming
	public static R410 _1_ = new(1, Base._1_);
	public static R410 e1 = new(1, Base.e1);
	public static R410 e2 = new(1, Base.e2);
	public static R410 e3 = new(1, Base.e3);
	public static R410 e4 = new(1, Base.e4);
	public static R410 e5 = new(1, Base.e5);
	public static R410 e12 = new(1, Base.e12);
	public static R410 e13 = new(1, Base.e13);
	public static R410 e14 = new(1, Base.e14);
	public static R410 e15 = new(1, Base.e15);
	public static R410 e23 = new(1, Base.e23);
	public static R410 e24 = new(1, Base.e24);
	public static R410 e25 = new(1, Base.e25);
	public static R410 e34 = new(1, Base.e34);
	public static R410 e35 = new(1, Base.e35);
	public static R410 e45 = new(1, Base.e45);
	public static R410 e123 = new(1, Base.e123);
	public static R410 e124 = new(1, Base.e124);
	public static R410 e125 = new(1, Base.e125);
	public static R410 e134 = new(1, Base.e134);
	public static R410 e135 = new(1, Base.e135);
	public static R410 e145 = new(1, Base.e145);
	public static R410 e234 = new(1, Base.e234);
	public static R410 e235 = new(1, Base.e235);
	public static R410 e245 = new(1, Base.e245);
	public static R410 e345 = new(1, Base.e345);
	public static R410 e1234 = new(1, Base.e1234);
	public static R410 e1235 = new(1, Base.e1235);
	public static R410 e1245 = new(1, Base.e1245);
	public static R410 e1345 = new(1, Base.e1345);
	public static R410 e2345 = new(1, Base.e2345);
	public static R410 e12345 = new(1, Base.e12345);
	// ReSharper restore InconsistentNaming
	#endregion basis blades

	/// <summary>Gets the _ Blades.</summary>
	static readonly R410[] _Blades = {_1_,
		e1, e2, e3, e4, e5,
		e12, e13, e14, e15, e23, e24, e25, e34, e35, e45,
		e123, e124, e125, e134, e135, e145, e234, e235, e245, e345,
		e1234, e1235, e1245, e1345, e2345
		, e12345};
	public static IReadOnlyList<R410> Blades = _Blades;

	/// <inheritdoc />
	protected override double[][] Coefficients() => new[] {
			new double[] {_C[00], +_C[01], +_C[02], +_C[03], +_C[04], -_C[05], -_C[06], -_C[07], -_C[08], +_C[09], -_C[10], -_C[11], +_C[12], -_C[13], +_C[14], +_C[15], -_C[16], -_C[17], +_C[18], -_C[19], +_C[20], +_C[21], -_C[22], +_C[23], +_C[24], +_C[25], +_C[26], -_C[27], -_C[28], -_C[29], -_C[30], -_C[31]},
			new double[] {_C[01], +_C[00], -_C[06], -_C[07], -_C[08], +_C[09], +_C[02], +_C[03], +_C[04], -_C[05], -_C[16], -_C[17], +_C[18], -_C[19], +_C[20], +_C[21], -_C[10], -_C[11], +_C[12], -_C[13], +_C[14], +_C[15], +_C[26], -_C[27], -_C[28], -_C[29], -_C[22], +_C[23], +_C[24], +_C[25], -_C[31], -_C[30]},
			new double[] {_C[02], +_C[06], +_C[00], -_C[10], -_C[11], +_C[12], -_C[01], +_C[16], +_C[17], -_C[18], +_C[03], +_C[04], -_C[05], -_C[22], +_C[23], +_C[24], +_C[07], +_C[08], -_C[09], -_C[26], +_C[27], +_C[28], -_C[13], +_C[14], +_C[15], -_C[30], +_C[19], -_C[20], -_C[21], +_C[31], +_C[25], +_C[29]},
			new double[] {_C[03], +_C[07], +_C[10], +_C[00], -_C[13], +_C[14], -_C[16], -_C[01], +_C[19], -_C[20], -_C[02], +_C[22], -_C[23], +_C[04], -_C[05], +_C[25], -_C[06], +_C[26], -_C[27], +_C[08], -_C[09], +_C[29], +_C[11], -_C[12], +_C[30], +_C[15], -_C[17], +_C[18], -_C[31], -_C[21], -_C[24], -_C[28]},
			new double[] {_C[04], +_C[08], +_C[11], +_C[13], +_C[00], +_C[15], -_C[17], -_C[19], -_C[01], -_C[21], -_C[22], -_C[02], -_C[24], -_C[03], -_C[25], -_C[05], -_C[26], -_C[06], -_C[28], -_C[07], -_C[29], -_C[09], -_C[10], -_C[30], -_C[12], -_C[14], +_C[16], +_C[31], +_C[18], +_C[20], +_C[23], +_C[27]},
			new double[] {_C[05], +_C[09], +_C[12], +_C[14], +_C[15], +_C[00], -_C[18], -_C[20], -_C[21], -_C[01], -_C[23], -_C[24], -_C[02], -_C[25], -_C[03], -_C[04], -_C[27], -_C[28], -_C[06], -_C[29], -_C[07], -_C[08], -_C[30], -_C[10], -_C[11], -_C[13], +_C[31], +_C[16], +_C[17], +_C[19], +_C[22], +_C[26]},
			new double[] {_C[06], +_C[02], -_C[01], +_C[16], +_C[17], -_C[18], +_C[00], -_C[10], -_C[11], +_C[12], +_C[07], +_C[08], -_C[09], -_C[26], +_C[27], +_C[28], +_C[03], +_C[04], -_C[05], -_C[22], +_C[23], +_C[24], +_C[19], -_C[20], -_C[21], +_C[31], -_C[13], +_C[14], +_C[15], -_C[30], +_C[29], +_C[25]},
			new double[] {_C[07], +_C[03], -_C[16], -_C[01], +_C[19], -_C[20], +_C[10], +_C[00], -_C[13], +_C[14], -_C[06], +_C[26], -_C[27], +_C[08], -_C[09], +_C[29], -_C[02], +_C[22], -_C[23], +_C[04], -_C[05], +_C[25], -_C[17], +_C[18], -_C[31], -_C[21], +_C[11], -_C[12], +_C[30], +_C[15], -_C[28], -_C[24]},
			new double[] {_C[08], +_C[04], -_C[17], -_C[19], -_C[01], -_C[21], +_C[11], +_C[13], +_C[00], +_C[15], -_C[26], -_C[06], -_C[28], -_C[07], -_C[29], -_C[09], -_C[22], -_C[02], -_C[24], -_C[03], -_C[25], -_C[05], +_C[16], +_C[31], +_C[18], +_C[20], -_C[10], -_C[30], -_C[12], -_C[14], +_C[27], +_C[23]},
			new double[] {_C[09], +_C[05], -_C[18], -_C[20], -_C[21], -_C[01], +_C[12], +_C[14], +_C[15], +_C[00], -_C[27], -_C[28], -_C[06], -_C[29], -_C[07], -_C[08], -_C[23], -_C[24], -_C[02], -_C[25], -_C[03], -_C[04], +_C[31], +_C[16], +_C[17], +_C[19], -_C[30], -_C[10], -_C[11], -_C[13], +_C[26], +_C[22]},
			new double[] {_C[10], +_C[16], +_C[03], -_C[02], +_C[22], -_C[23], -_C[07], +_C[06], -_C[26], +_C[27], +_C[00], -_C[13], +_C[14], +_C[11], -_C[12], +_C[30], +_C[01], -_C[19], +_C[20], +_C[17], -_C[18], +_C[31], +_C[04], -_C[05], +_C[25], -_C[24], -_C[08], +_C[09], -_C[29], +_C[28], +_C[15], +_C[21]},
			new double[] {_C[11], +_C[17], +_C[04], -_C[22], -_C[02], -_C[24], -_C[08], +_C[26], +_C[06], +_C[28], +_C[13], +_C[00], +_C[15], -_C[10], -_C[30], -_C[12], +_C[19], +_C[01], +_C[21], -_C[16], -_C[31], -_C[18], -_C[03], -_C[25], -_C[05], +_C[23], +_C[07], +_C[29], +_C[09], -_C[27], -_C[14], -_C[20]},
			new double[] {_C[12], +_C[18], +_C[05], -_C[23], -_C[24], -_C[02], -_C[09], +_C[27], +_C[28], +_C[06], +_C[14], +_C[15], +_C[00], -_C[30], -_C[10], -_C[11], +_C[20], +_C[21], +_C[01], -_C[31], -_C[16], -_C[17], -_C[25], -_C[03], -_C[04], +_C[22], +_C[29], +_C[07], +_C[08], -_C[26], -_C[13], -_C[19]},
			new double[] {_C[13], +_C[19], +_C[22], +_C[04], -_C[03], -_C[25], -_C[26], -_C[08], +_C[07], +_C[29], -_C[11], +_C[10], +_C[30], +_C[00], +_C[15], -_C[14], -_C[17], +_C[16], +_C[31], +_C[01], +_C[21], -_C[20], +_C[02], +_C[24], -_C[23], -_C[05], -_C[06], -_C[28], +_C[27], +_C[09], +_C[12], +_C[18]},
			new double[] {_C[14], +_C[20], +_C[23], +_C[05], -_C[25], -_C[03], -_C[27], -_C[09], +_C[29], +_C[07], -_C[12], +_C[30], +_C[10], +_C[15], +_C[00], -_C[13], -_C[18], +_C[31], +_C[16], +_C[21], +_C[01], -_C[19], +_C[24], +_C[02], -_C[22], -_C[04], -_C[28], -_C[06], +_C[26], +_C[08], +_C[11], +_C[17]},
			new double[] {_C[15], +_C[21], +_C[24], +_C[25], +_C[05], -_C[04], -_C[28], -_C[29], -_C[09], +_C[08], -_C[30], -_C[12], +_C[11], -_C[14], +_C[13], +_C[00], -_C[31], -_C[18], +_C[17], -_C[20], +_C[19], +_C[01], -_C[23], +_C[22], +_C[02], +_C[03], +_C[27], -_C[26], -_C[06], -_C[07], -_C[10], -_C[16]},
			new double[] {_C[16], +_C[10], -_C[07], +_C[06], -_C[26], +_C[27], +_C[03], -_C[02], +_C[22], -_C[23], +_C[01], -_C[19], +_C[20], +_C[17], -_C[18], +_C[31], +_C[00], -_C[13], +_C[14], +_C[11], -_C[12], +_C[30], -_C[08], +_C[09], -_C[29], +_C[28], +_C[04], -_C[05], +_C[25], -_C[24], +_C[21], +_C[15]},
			new double[] {_C[17], +_C[11], -_C[08], +_C[26], +_C[06], +_C[28], +_C[04], -_C[22], -_C[02], -_C[24], +_C[19], +_C[01], +_C[21], -_C[16], -_C[31], -_C[18], +_C[13], +_C[00], +_C[15], -_C[10], -_C[30], -_C[12], +_C[07], +_C[29], +_C[09], -_C[27], -_C[ 3], -_C[25], -_C[05], +_C[23], -_C[20], -_C[14]},
			new double[] {_C[18], +_C[12], -_C[09], +_C[27], +_C[28], +_C[06], +_C[05], -_C[23], -_C[24], -_C[02], +_C[20], +_C[21], +_C[01], -_C[31], -_C[16], -_C[17], +_C[14], +_C[15], +_C[00], -_C[30], -_C[10], -_C[11], +_C[29], +_C[07], +_C[08], -_C[26], -_C[25], -_C[ 3], -_C[04], +_C[22], -_C[19], -_C[13]},
			new double[] {_C[19], +_C[13], -_C[26], -_C[08], +_C[07], +_C[29], +_C[22], +_C[04], -_C[03], -_C[25], -_C[17], +_C[16], +_C[31], +_C[01], +_C[21], -_C[20], -_C[11], +_C[10], +_C[30], +_C[00], +_C[15], -_C[14], -_C[06], -_C[28], +_C[27], +_C[09], +_C[ 2], +_C[24], -_C[23], -_C[05], +_C[18], +_C[12]},
			new double[] {_C[20], +_C[14], -_C[27], -_C[09], +_C[29], +_C[07], +_C[23], +_C[05], -_C[25], -_C[03], -_C[18], +_C[31], +_C[16], +_C[21], +_C[01], -_C[19], -_C[12], +_C[30], +_C[10], +_C[15], +_C[00], -_C[13], -_C[28], -_C[06], +_C[26], +_C[08], +_C[24], +_C[ 2], -_C[22], -_C[04], +_C[17], +_C[11]},
			new double[] {_C[21], +_C[15], -_C[28], -_C[29], -_C[09], +_C[08], +_C[24], +_C[25], +_C[05], -_C[04], -_C[31], -_C[18], +_C[17], -_C[20], +_C[19], +_C[01], -_C[30], -_C[12], +_C[11], -_C[14], +_C[13], +_C[00], +_C[27], -_C[26], -_C[06], -_C[07], -_C[23], +_C[22], +_C[ 2], +_C[03], -_C[16], -_C[10]},
			new double[] {_C[22], +_C[26], +_C[13], -_C[11], +_C[10], +_C[30], -_C[19], +_C[17], -_C[16], -_C[31], +_C[04], -_C[03], -_C[25], +_C[02], +_C[24], -_C[23], +_C[08], -_C[07], -_C[29], +_C[06], +_C[28], -_C[27], +_C[00], +_C[15], -_C[14], +_C[12], -_C[ 1], -_C[21], +_C[20], -_C[18], -_C[05], -_C[09]},
			new double[] {_C[23], +_C[27], +_C[14], -_C[12], +_C[30], +_C[10], -_C[20], +_C[18], -_C[31], -_C[16], +_C[05], -_C[25], -_C[03], +_C[24], +_C[02], -_C[22], +_C[09], -_C[29], -_C[07], +_C[28], +_C[06], -_C[26], +_C[15], +_C[00], -_C[13], +_C[11], -_C[21], -_C[ 1], +_C[19], -_C[17], -_C[04], -_C[08]},
			new double[] {_C[24], +_C[28], +_C[15], -_C[30], -_C[12], +_C[11], -_C[21], +_C[31], +_C[18], -_C[17], +_C[25], +_C[05], -_C[04], -_C[23], +_C[22], +_C[02], +_C[29], +_C[09], -_C[08], -_C[27], +_C[26], +_C[06], -_C[14], +_C[13], +_C[00], -_C[10], +_C[20], -_C[19], -_C[ 1], +_C[16], +_C[03], +_C[07]},
			new double[] {_C[25], +_C[29], +_C[30], +_C[15], -_C[14], +_C[13], -_C[31], -_C[21], +_C[20], -_C[19], -_C[24], +_C[23], -_C[22], +_C[05], -_C[04], +_C[03], -_C[28], +_C[27], -_C[26], +_C[09], -_C[08], +_C[07], +_C[12], -_C[11], +_C[10], +_C[00], -_C[18], +_C[17], -_C[16], -_C[01], -_C[02], -_C[06]},
			new double[] {_C[26], +_C[22], -_C[19], +_C[17], -_C[16], -_C[31], +_C[13], -_C[11], +_C[10], +_C[30], +_C[08], -_C[07], -_C[29], +_C[06], +_C[28], -_C[27], +_C[04], -_C[03], -_C[25], +_C[02], +_C[24], -_C[23], -_C[01], -_C[21], +_C[20], -_C[18], +_C[ 0], +_C[15], -_C[14], +_C[12], -_C[09], -_C[05]},
			new double[] {_C[27], +_C[23], -_C[20], +_C[18], -_C[31], -_C[16], +_C[14], -_C[12], +_C[30], +_C[10], +_C[09], -_C[29], -_C[07], +_C[28], +_C[06], -_C[26], +_C[05], -_C[25], -_C[03], +_C[24], +_C[02], -_C[22], -_C[21], -_C[01], +_C[19], -_C[17], +_C[15], +_C[ 0], -_C[13], +_C[11], -_C[08], -_C[04]},
			new double[] {_C[28], +_C[24], -_C[21], +_C[31], +_C[18], -_C[17], +_C[15], -_C[30], -_C[12], +_C[11], +_C[29], +_C[09], -_C[08], -_C[27], +_C[26], +_C[06], +_C[25], +_C[05], -_C[04], -_C[23], +_C[22], +_C[02], +_C[20], -_C[19], -_C[01], +_C[16], -_C[14], +_C[13], +_C[ 0], -_C[10], +_C[07], +_C[ 3]},
			new double[] {_C[29], +_C[25], -_C[31], -_C[21], +_C[20], -_C[19], +_C[30], +_C[15], -_C[14], +_C[13], -_C[28], +_C[27], -_C[26], +_C[09], -_C[08], +_C[07], -_C[24], +_C[23], -_C[22], +_C[05], -_C[04], +_C[03], -_C[18], +_C[17], -_C[16], -_C[01], +_C[12], -_C[11], +_C[10], +_C[00], -_C[06], -_C[ 2]},
			new double[] {_C[30], +_C[31], +_C[25], -_C[24], +_C[23], -_C[22], -_C[29], +_C[28], -_C[27], +_C[26], +_C[15], -_C[14], +_C[13], +_C[12], -_C[11], +_C[10], +_C[21], -_C[20], +_C[19], +_C[18], -_C[17], +_C[16], +_C[05], -_C[04], +_C[03], -_C[02], -_C[09], +_C[08], -_C[07], +_C[06], +_C[00], +_C[ 1]},
			new double[] {_C[31], +_C[30], -_C[29], +_C[28], -_C[27], +_C[26], +_C[25], -_C[24], +_C[23], -_C[22], +_C[21], -_C[20], +_C[19], +_C[18], -_C[17], +_C[16], +_C[15], -_C[14], +_C[13], +_C[12], -_C[11], +_C[10], -_C[09], +_C[08], -_C[07], +_C[06], +_C[05], -_C[04], +_C[ 3], -_C[02], +_C[01], +_C[ 0]},
		};

}

