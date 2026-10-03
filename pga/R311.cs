using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using org.SpocWeb.root.interfaces.Vectors;
using org.SpocWeb.root.maths.pga.ga;

namespace org.SpocWeb.root.maths.pga;

/// <summary> Conformal Geometric Algebra with <see cref="e0"/>� = 0 and <see cref="eN"/>�=-1 </summary>
/// <remarks>
/// ## Public Methods
///
/// | Line | Method | Description |
/// |--:|---|---|
/// | 351 | <see cref="ProductOuter"/> | ^ Meet/Outer/Wedge Product: Intersection |
/// | 540 | <see cref="ProductGeometric"/> | * Full Geometric Product |
/// | 729 | <see cref="ProductDot"/> | Dot/Inner/Scalar Product |
/// | 734 | <see cref="Products"/> | Public read-only view of all three product Cayley tables indexed by product type. |
/// | 741 | <see cref="_1_"/> | Gets the 1. |
/// | 743 | <see cref="e0"/> | Gets the e0. |
/// | 745 | <see cref="e1"/> | Gets the e1. |
/// | 747 | <see cref="e2"/> | Gets the e2. |
/// | 749 | <see cref="e3"/> | Gets the e3. |
/// | 751 | <see cref="eN"/> | Gets the e N. |
/// | 753 | <see cref="e01"/> | Gets the e01. |
/// | 755 | <see cref="e02"/> | Gets the e02. |
/// | 757 | <see cref="e03"/> | Gets the e03. |
/// | 759 | <see cref="e0N"/> | Gets the e0 N. |
/// | 761 | <see cref="e12"/> | Gets the e12. |
/// | 763 | <see cref="e13"/> | Gets the e13. |
/// | 765 | <see cref="e1N"/> | Gets the e1 N. |
/// | 767 | <see cref="e23"/> | Gets the e23. |
/// | 769 | <see cref="e2N"/> | Gets the e2 N. |
/// | 771 | <see cref="e3N"/> | Gets the e3 N. |
/// | 774 | <see cref="e012"/> | Gets the e012. |
/// | 776 | <see cref="e013"/> | Gets the e013. |
/// | 778 | <see cref="e01N"/> | Gets the e01 N. |
/// | 780 | <see cref="e023"/> | Gets the e023. |
/// | 782 | <see cref="e02N"/> | Gets the e02 N. |
/// | 784 | <see cref="e03N"/> | Gets the e03 N. |
/// | 787 | <see cref="e123"/> | Gets the e123. |
/// | 789 | <see cref="e23N"/> | Gets the e23 N. |
/// | 791 | <see cref="e13N"/> | Gets the e13 N. |
/// | 793 | <see cref="e12N"/> | Gets the e12 N. |
/// | 796 | <see cref="e0123"/> | Gets the e0123. |
/// | 798 | <see cref="e012N"/> | Gets the e012 N. |
/// | 800 | <see cref="e013N"/> | Gets the e013 N. |
/// | 802 | <see cref="e023N"/> | Gets the e023 N. |
/// | 804 | <see cref="e123N"/> | Gets the e123 N. |
/// | 807 | <see cref="e0123N"/> | Gets the e0123 N. |
/// | 825 | <see cref="New"/> | Creates a new R311 from the supplied component array, checking the length. |
/// | 834 | <see cref="this[]"/> | Gets or sets the element at the specified index. |
/// | 845 | <see cref="R311"/> | Initializes a new instance of R311 with the specified f and idx. |
/// | 847 | <see cref="R311"/> | Initializes a new instance of R311 with the specified f and idx. |
/// | 849 | <see cref="R311"/> | Initializes a new instance of R311 with the specified values. |
/// | 851 | <see cref="R311"/> | Initializes a new instance of R311 with the specified values. |
/// | 854 | <see cref="AsMultiVector"/> | Converts an array of weighted Base blades into a flat float component array of length NUM_COORDS. |
/// | 861 | <see cref="R311"/> | Checked Constructor |
///
/// ## Collaborators
///
/// | Type | Role |
/// |---|---|
/// | <see cref="Make"/> | Nested type. |
/// | <see cref="R311"/> | Returned by a method. |
/// | <see cref="Base"/> | Nested enum. |
/// </remarks>
///
/// <example>
/// <code language="yaml">
/// pass: 2
/// mtime: 2026-05-24T15:36:37Z
/// digest: 85037b7295e2bd87d147d681d241a3a39e0bb1d51d88933c9a2a8bb12c080f27
/// tags: [code/clifford_algebra, code/conformal_geometric_algebra]
/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
/// facets: {layer: domain, status: stable, complexity: 4}
/// </code>
/// </example>
public class R311 : AGeoGebra32<R311>
{

	/// <summary> Factory methods for constructing conformal primitives (points, planes, spheres, circles) in the R311 algebra. </summary>
	/// <remarks>
	/// ## Public Methods
	///
	/// | Line | Method | Description |
	/// |--:|---|---|
	/// | 33 | <see cref="Point"/> | Creates a conformal point at the given Euclidean point (a zero-radius sphere). |
	/// | 35 | <see cref="Plane"/> | Creates a conformal plane with unit normal at signed distance from the origin. |
	/// | 42 | <see cref="Sphere"/> | Creates a conformal sphere with the given Euclidean center and radius. |
	/// | 51 | <see cref="Circle"/> | A Circle can be computed from three Points on it. |
	///
	/// ## Collaborators
	///
	/// | Type | Role |
	/// |---|---|
	/// | <see cref="R311"/> | Returned by a method. |
	/// | <see cref="Vector3"/> | Passed as a parameter. |
	/// </remarks>
	/// <example>
	/// <code language="yaml">
	/// pass: 2
	/// mtime: 2026-06-17T10:08:27Z
	/// digest: 5c1b2db7f871d0e0f8d41867c0f58a20e7858ef6b80f9777a3910b1ae287b081
	/// tags: [code/factory, code/conformal_geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 3}
	/// </code>
	/// </example>
	public static class Make
	{
		/// <summary> Creates a conformal point at the given Euclidean <paramref name="point"/> (a zero-radius sphere). </summary>
		///
		/// <example>
		/// <code language="yaml">
		/// tags: [code/factory_method, code/conformal_geometric_algebra]
		/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
		/// facets: {layer: domain, status: stable, complexity: 1}
		/// </code>
		/// </example>
		public static R311 Point(Vector3 point) => Sphere(point, 0);
		/// <summary> Creates a conformal plane with unit <paramref name="normal"/> at signed <paramref name="distance"/> from the origin. </summary>
		///
		/// <example>
		/// <code language="yaml">
		/// tags: [code/factory_method, code/conformal_geometric_algebra]
		/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
		/// facets: {layer: domain, status: stable, complexity: 2}
		/// </code>
		/// </example>
		public static R311 Plane(Vector3 normal, double distance)
			=> new(Base.eN.AsBlade(distance)
				, Base.e1.AsBlade(normal.X)
				, Base.e2.AsBlade(normal.Y)
				, Base.e3.AsBlade(normal.Z));

		/// <summary> Creates a conformal sphere with the given Euclidean <paramref name="center"/> and <paramref name="radius"/>. </summary>
		///
		/// <example>
		/// <code language="yaml">
		/// tags: [code/factory_method, code/conformal_geometric_algebra]
		/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
		/// facets: {layer: domain, status: stable, complexity: 2}
		/// </code>
		/// </example>
		public static R311 Sphere(Vector3 center, double radius)
			=> new (Base.e0.AsBlade()
				, Base.e1.AsBlade(center.X)
				, Base.e2.AsBlade(center.Y)
				, Base.e3.AsBlade(center.Z)
				, Base.eN.AsBlade((center.NormSqr() - radius* radius) * 0.5));

		/// <summary> A Circle can be computed from three Points on it. </summary>
		/// <returns> A Line if the Points are collinear or one of the Points are at Infinity </returns>
		/// <example>
		/// <code language="yaml">
		/// tags: [code/factory_method, code/outer_product, code/conformal_geometric_algebra]
		/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
		/// facets: {layer: domain, status: stable, complexity: 3}
		/// </code>
		/// </example>
		public static R311 Circle(Vector3 p1, Vector3 p2, Vector3 p3) => Point(p1) ^ Point(p2) ^ Point(p3);
	}

	/// <summary>Ordered array of basis blade name strings for debug and print output.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/clifford_algebra, code/conformal_geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 4}
	/// </code>
	/// </example>
	public override IReadOnlyList<string> Basis => _Basis;
	/// <summary>Backing array of ordered basis blade name strings.</summary>
	static readonly string[] _Basis = {
		"", "e0", "e1", "e2", "e3", "e4"
		, "e01", "e02", "e03", "e04", "e12", "e13", "e14", "e23", "e24", "e34"
		, "e012", "e013", "e014", "e023", "e024", "e034"
		, "e123", "e124", "e134", "e234"
		, "e0123", "e0124", "e0134", "e0234", "e1234", "e01234"
	};

	/// <inheritdoc />
	public override R311 Self() => this;

	/// <summary> Base-Blades in 3D, usable as Indices for Components </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// pass: 2
	/// mtime: 2026-07-07T17:42:07Z
	/// digest: fbc0add112ebc325e336691922492318288602332913b718d69c2f0ed689a384
	/// tags: [code/enum, code/conformal_geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 1}
	/// </code>
	/// </example>
	[SuppressMessage("ReSharper", "InconsistentNaming")]
	public enum Base : sbyte
	{
		/// <summary> [00] Scalar e.g. Dot Product or oriented Volume </summary>
		_1_,

		/// <summary> [01] homogeneous Component e0� = 0, usually 1 for Points and 0 for Vectors/Origin Vectors </summary>
		e0,

		/// <summary> [02] X-Direction (polar) / yz-Mirror e1� = 1 </summary>
		e1,

		/// <summary> [03] Y-Direction (polar) / zx-Mirror e2� = 1 </summary>
		e2,

		/// <summary> [04] Z-Direction (polar) / xy-Mirror e3� = 1 </summary>
		e3,

		/// <summary> [05] Infinity-Direction (polar) / xy-Mirror eN� = -1 </summary>
		eN,

		/// <summary>[06] BiVector formed by the wedge of e0 and e1 basis blades.</summary>
		e01,
		/// <summary>[07] BiVector formed by the wedge of e0 and e2 basis blades.</summary>
		e02,
		/// <summary> [08] BiVector </summary>
		e03, 
		/// <summary> [09] BiVector </summary>
		e0N, 

		/// <summary> [10] BiVector </summary>
		e12,

		/// <summary> [11] axial Y-BiVector </summary>
		e13,

		/// <summary> [12] axial Y-BiVector </summary>
		e1N,

		/// <summary> [13] axial Z-BiVector </summary>
		e23,

		/// <summary> [14] axial Z-BiVector </summary>
		e2N,

		/// <summary> [15] axial Z-BiVector </summary>
		e3N,

		/// <summary>[16] TriVector (negative orientation) formed by the wedge of e0, e1 and e2.</summary>
		e012,
		/// <summary>[17] TriVector (negative orientation) formed by the wedge of e0, e1 and e3.</summary>
		e013,
		/// <summary> [18] -TriVector </summary>
		e01N, 
		/// <summary> [19] -TriVector </summary>
		e023, 
		/// <summary> [20] -TriVector </summary>
		e02N, 
		/// <summary> [21] -TriVector </summary>
		e03N,

		/// <summary> [22] Oriented TriVector-Volume </summary>
		e123,

		/// <summary> [23] Oriented TriVector-Volume </summary>
		e12N,

		/// <summary> [24] Oriented TriVector-Volume </summary>
		e13N,

		/// <summary> [25] Oriented TriVector-Volume </summary>
		e23N,

		/// <summary>[26] QuadVector hyper-volume formed by e0, e1, e2 and e3.</summary>
		e0123,
		/// <summary>[27] QuadVector hyper-volume formed by e0, e1, e2 and eN.</summary>
		e012N,
		/// <summary> [28] QuadVector-HyperVolume </summary>
		e013N, 
		/// <summary> [29] QuadVector-HyperVolume </summary>
		e023N, 
		/// <summary> [30] QuadVector-HyperVolume </summary>
		e123N,

		/// <summary> [31] Oriented Hyper-Volume, a Pseudo-Scalar </summary>
		e0123N,

		/// <summary> No Component; signals both the End of Components and 0-Elements in the Cayley Tables below </summary>
		_0,// = sbyte.MinValue
	}

	#region Cayley Tables for different Products in R3,1,1

	/// <summary> ^ Meet/Outer/Wedge Product </summary>
	static readonly Base[][] _ProductOuter = {
		new[] {
			Base._1_, Base.e0, Base.e1, Base.e2, Base.e3, Base.eN, Base.e01, Base.e02, Base.e03, Base.e0N, Base.e12,
			Base.e13, Base.e1N, Base.e23, Base.e2N, Base.e3N, Base.e012, Base.e013, Base.e01N, Base.e023, Base.e02N,
			Base.e03N, Base.e123, Base.e12N, Base.e13N, Base.e23N, Base.e0123, Base.e012N, Base.e013N, Base.e023N,
			Base.e123N, Base.e0123N
		},
		new[] {
			Base.e0, Base._0, Base.e01, Base.e02, Base.e03, Base.e0N, Base._0, Base._0, Base._0, Base._0, Base.e012,
			Base.e013, Base.e01N, Base.e023, Base.e02N, Base.e03N, Base._0, Base._0, Base._0, Base._0, Base._0,
			Base._0, Base.e0123, Base.e012N, Base.e013N, Base.e023N, Base._0, Base._0, Base._0, Base._0,
			Base.e0123N, Base._0
		},
		new[] {
			Base.e1, ~Base.e01, Base._0, Base.e12, Base.e13, Base.e1N, Base._0, ~Base.e012, ~Base.e013, ~Base.e01N,
			Base._0, Base._0, Base._0, Base.e123, Base.e12N, Base.e13N, Base._0, Base._0, Base._0, ~Base.e0123,
			~Base.e012N, ~Base.e013N, Base._0, Base._0, Base._0, Base.e123N, Base._0, Base._0, Base._0,
			~Base.e0123N, Base._0, Base._0
		},
		new[] {
			Base.e2, ~Base.e02, ~Base.e12, Base._0, Base.e23, Base.e2N, Base.e012, Base._0, ~Base.e023, ~Base.e02N,
			Base._0, ~Base.e123, ~Base.e12N, Base._0, Base._0, Base.e23N, Base._0, Base.e0123, Base.e012N, Base._0,
			Base._0, ~Base.e023N, Base._0, Base._0, ~Base.e123N, Base._0, Base._0, Base._0, Base.e0123N, Base._0,
			Base._0, Base._0
		},
		new[] {
			Base.e3, ~Base.e03, ~Base.e13, ~Base.e23, Base._0, Base.e3N, Base.e013, Base.e023, Base._0, ~Base.e03N,
			Base.e123, Base._0, ~Base.e13N, Base._0, ~Base.e23N, Base._0, ~Base.e0123, Base._0, Base.e013N, Base._0,
			Base.e023N, Base._0, Base._0, Base.e123N, Base._0, Base._0, Base._0, ~Base.e0123N, Base._0, Base._0,
			Base._0, Base._0
		},
		new[] {
			Base.eN, ~Base.e0N, ~Base.e1N, ~Base.e2N, ~Base.e3N, Base._0, Base.e01N, Base.e02N, Base.e03N, Base._0,
			Base.e12N, Base.e13N, Base._0, Base.e23N, Base._0, Base._0, ~Base.e012N, ~Base.e013N, Base._0,
			~Base.e023N, Base._0, Base._0, ~Base.e123N, Base._0, Base._0, Base._0, Base.e0123N, Base._0, Base._0,
			Base._0, Base._0, Base._0
		},
		new[] {
			Base.e01, Base._0, Base._0, Base.e012, Base.e013, Base.e01N, Base._0, Base._0, Base._0, Base._0,
			Base._0, Base._0, Base._0, Base.e0123, Base.e012N, Base.e013N, Base._0, Base._0, Base._0, Base._0,
			Base._0, Base._0, Base._0, Base._0, Base._0, Base.e0123N, Base._0, Base._0, Base._0, Base._0, Base._0,
			Base._0
		},
		new[] {
			Base.e02, Base._0, ~Base.e012, Base._0, Base.e023, Base.e02N, Base._0, Base._0, Base._0, Base._0,
			Base._0, ~Base.e0123, ~Base.e012N, Base._0, Base._0, Base.e023N, Base._0, Base._0, Base._0, Base._0,
			Base._0, Base._0, Base._0, Base._0, ~Base.e0123N, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0,
			Base._0
		},
		new[] {
			Base.e03, Base._0, ~Base.e013, ~Base.e023, Base._0, Base.e03N, Base._0, Base._0, Base._0, Base._0,
			Base.e0123, Base._0, ~Base.e013N, Base._0, ~Base.e023N, Base._0, Base._0, Base._0, Base._0, Base._0,
			Base._0, Base._0, Base._0, Base.e0123N, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0,
			Base._0
		},
		new[] {
			Base.e0N, Base._0, ~Base.e01N, ~Base.e02N, ~Base.e03N, Base._0, Base._0, Base._0, Base._0, Base._0,
			Base.e012N, Base.e013N, Base._0, Base.e023N, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0,
			Base._0, Base._0, ~Base.e0123N, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0,
			Base._0
		},
		new[] {
			Base.e12, Base.e012, Base._0, Base._0, Base.e123, Base.e12N, Base._0, Base._0, Base.e0123, Base.e012N,
			Base._0, Base._0, Base._0, Base._0, Base._0, Base.e123N, Base._0, Base._0, Base._0, Base._0, Base._0,
			Base.e0123N, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0
		},
		new[] {
			Base.e13, Base.e013, Base._0, ~Base.e123, Base._0, Base.e13N, Base._0, ~Base.e0123, Base._0, Base.e013N,
			Base._0, Base._0, Base._0, Base._0, ~Base.e123N, Base._0, Base._0, Base._0, Base._0, Base._0,
			~Base.e0123N, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0,
			Base._0
		},
		new[] {
			Base.e1N, Base.e01N, Base._0, ~Base.e12N, ~Base.e13N, Base._0, Base._0, ~Base.e012N, ~Base.e013N,
			Base._0, Base._0, Base._0, Base._0, Base.e123N, Base._0, Base._0, Base._0, Base._0, Base._0,
			Base.e0123N, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0,
			Base._0, Base._0
		},
		new[] {
			Base.e23, Base.e023, Base.e123, Base._0, Base._0, Base.e23N, Base.e0123, Base._0, Base._0, Base.e023N,
			Base._0, Base._0, Base.e123N, Base._0, Base._0, Base._0, Base._0, Base._0, Base.e0123N, Base._0,
			Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0,
			Base._0
		},
		new[] {
			Base.e2N, Base.e02N, Base.e12N, Base._0, ~Base.e23N, Base._0, Base.e012N, Base._0, ~Base.e023N, Base._0,
			Base._0, ~Base.e123N, Base._0, Base._0, Base._0, Base._0, Base._0, ~Base.e0123N, Base._0, Base._0,
			Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0,
			Base._0
		},
		new[] {
			Base.e3N, Base.e03N, Base.e13N, Base.e23N, Base._0, Base._0, Base.e013N, Base.e023N, Base._0, Base._0,
			Base.e123N, Base._0, Base._0, Base._0, Base._0, Base._0, Base.e0123N, Base._0, Base._0, Base._0,
			Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0,
			Base._0
		},
		new[] {
			Base.e012, Base._0, Base._0, Base._0, Base.e0123, Base.e012N, Base._0, Base._0, Base._0, Base._0,
			Base._0, Base._0, Base._0, Base._0, Base._0, Base.e0123N, Base._0, Base._0, Base._0, Base._0, Base._0,
			Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0
		},
		new[] {
			Base.e013, Base._0, Base._0, ~Base.e0123, Base._0, Base.e013N, Base._0, Base._0, Base._0, Base._0,
			Base._0, Base._0, Base._0, Base._0, ~Base.e0123N, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0,
			Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0
		},
		new[] {
			Base.e01N, Base._0, Base._0, ~Base.e012N, ~Base.e013N, Base._0, Base._0, Base._0, Base._0, Base._0,
			Base._0, Base._0, Base._0, Base.e0123N, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0,
			Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0
		},
		new[] {
			Base.e023, Base._0, Base.e0123, Base._0, Base._0, Base.e023N, Base._0, Base._0, Base._0, Base._0,
			Base._0, Base._0, Base.e0123N, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0,
			Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0
		},
		new[] {
			Base.e02N, Base._0, Base.e012N, Base._0, ~Base.e023N, Base._0, Base._0, Base._0, Base._0, Base._0,
			Base._0, ~Base.e0123N, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0,
			Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0
		},
		new[] {
			Base.e03N, Base._0, Base.e013N, Base.e023N, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0,
			Base.e0123N, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0,
			Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0
		},
		new[] {
			Base.e123, ~Base.e0123, Base._0, Base._0, Base._0, Base.e123N, Base._0, Base._0, Base._0, ~Base.e0123N,
			Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0,
			Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0
		},
		new[] {
			Base.e12N, ~Base.e012N, Base._0, Base._0, ~Base.e123N, Base._0, Base._0, Base._0, Base.e0123N, Base._0,
			Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0,
			Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0
		},
		new[] {
			Base.e13N, ~Base.e013N, Base._0, Base.e123N, Base._0, Base._0, Base._0, ~Base.e0123N, Base._0, Base._0,
			Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0,
			Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0
		},
		new[] {
			Base.e23N, ~Base.e023N, ~Base.e123N, Base._0, Base._0, Base._0, Base.e0123N, Base._0, Base._0, Base._0,
			Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0,
			Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0
		},
		new[] {
			Base.e0123, Base._0, Base._0, Base._0, Base._0, Base.e0123N, Base._0, Base._0, Base._0, Base._0,
			Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0,
			Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0
		},
		new[] {
			Base.e012N, Base._0, Base._0, Base._0, ~Base.e0123N, Base._0, Base._0, Base._0, Base._0, Base._0,
			Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0,
			Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0
		},
		new[] {
			Base.e013N, Base._0, Base._0, Base.e0123N, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0,
			Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0,
			Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0
		},
		new[] {
			Base.e023N, Base._0, ~Base.e0123N, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0,
			Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0,
			Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0
		},
		new[] {
			Base.e123N, Base.e0123N, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0,
			Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0,
			Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0
		},
		new[] {
			Base.e0123N, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0,
			Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0,
			Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0
		}
	};

	/// <summary> ^ Meet/Outer/Wedge Product: Intersection </summary>
	public static readonly IReadOnlyList<IReadOnlyList<Base>> ProductOuter = _ProductOuter;

	/// <summary>Cayley table encoding the full geometric product of all R311 basis blade pairs.</summary>
	static readonly Base[][] _ProductGeometric = {
		new[] {
			Base._1_, Base.e0, Base.e1, Base.e2, Base.e3, Base.eN, Base.e01, Base.e02, Base.e03, Base.e0N, Base.e12,
			Base.e13, Base.e1N, Base.e23, Base.e2N, Base.e3N, Base.e012, Base.e013, Base.e01N, Base.e023, Base.e02N,
			Base.e03N, Base.e123, Base.e12N, Base.e13N, Base.e23N, Base.e0123, Base.e012N, Base.e013N, Base.e023N,
			Base.e123N, Base.e0123N
		},
		new[] {
			Base.e0, Base._0, Base.e01, Base.e02, Base.e03, Base.e0N, Base._0, Base._0, Base._0, Base._0, Base.e012,
			Base.e013, Base.e01N, Base.e023, Base.e02N, Base.e03N, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0,
			Base.e0123, Base.e012N, Base.e013N, Base.e023N, Base._0, Base._0, Base._0, Base._0, Base.e0123N, Base._0
		},
		new[] {
			Base.e1, ~Base.e01, Base._1_, Base.e12, Base.e13, Base.e1N, ~Base.e0, ~Base.e012, ~Base.e013, ~Base.e01N,
			Base.e2, Base.e3, Base.eN, Base.e123, Base.e12N, Base.e13N, ~Base.e02, ~Base.e03, ~Base.e0N, ~Base.e0123,
			~Base.e012N, ~Base.e013N, Base.e23, Base.e2N, Base.e3N, Base.e123N, ~Base.e023, ~Base.e02N, ~Base.e03N,
			~Base.e0123N, Base.e23N, ~Base.e023N
		},
		new[] {
			Base.e2, ~Base.e02, ~Base.e12, Base._1_, Base.e23, Base.e2N, Base.e012, ~Base.e0, ~Base.e023, ~Base.e02N,
			~Base.e1, ~Base.e123, ~Base.e12N, Base.e3, Base.eN, Base.e23N, Base.e01, Base.e0123, Base.e012N, ~Base.e03,
			~Base.e0N, ~Base.e023N, ~Base.e13, ~Base.e1N, ~Base.e123N, Base.e3N, Base.e013, Base.e01N, Base.e0123N,
			~Base.e03N, ~Base.e13N, Base.e013N
		},
		new[] {
			Base.e3, ~Base.e03, ~Base.e13, ~Base.e23, Base._1_, Base.e3N, Base.e013, Base.e023, ~Base.e0, ~Base.e03N,
			Base.e123, ~Base.e1, ~Base.e13N, ~Base.e2, ~Base.e23N, Base.eN, ~Base.e0123, Base.e01, Base.e013N, Base.e02,
			Base.e023N, ~Base.e0N, Base.e12, Base.e123N, ~Base.e1N, ~Base.e2N, ~Base.e012, ~Base.e0123N, Base.e01N,
			Base.e02N, Base.e12N, ~Base.e012N
		},
		new[] {
			Base.eN, ~Base.e0N, ~Base.e1N, ~Base.e2N, ~Base.e3N, ~Base._1_, Base.e01N, Base.e02N, Base.e03N, Base.e0,
			Base.e12N, Base.e13N, Base.e1, Base.e23N, Base.e2, Base.e3, ~Base.e012N, ~Base.e013N, ~Base.e01, ~Base.e023N,
			~Base.e02, ~Base.e03, ~Base.e123N, ~Base.e12, ~Base.e13, ~Base.e23, Base.e0123N, Base.e012, Base.e013,
			Base.e023, Base.e123, ~Base.e0123
		},
		new[] {
			Base.e01, Base._0, Base.e0, Base.e012, Base.e013, Base.e01N, Base._0, Base._0, Base._0, Base._0, Base.e02,
			Base.e03, Base.e0N, Base.e0123, Base.e012N, Base.e013N, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0,
			Base.e023, Base.e02N, Base.e03N, Base.e0123N, Base._0, Base._0, Base._0, Base._0, Base.e023N, Base._0
		},
		new[] {
			Base.e02, Base._0, ~Base.e012, Base.e0, Base.e023, Base.e02N, Base._0, Base._0, Base._0, Base._0, ~Base.e01,
			~Base.e0123, ~Base.e012N, Base.e03, Base.e0N, Base.e023N, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0,
			~Base.e013, ~Base.e01N, ~Base.e0123N, Base.e03N, Base._0, Base._0, Base._0, Base._0, ~Base.e013N, Base._0
		},
		new[] {
			Base.e03, Base._0, ~Base.e013, ~Base.e023, Base.e0, Base.e03N, Base._0, Base._0, Base._0, Base._0, Base.e0123,
			~Base.e01, ~Base.e013N, ~Base.e02, ~Base.e023N, Base.e0N, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0,
			Base.e012, Base.e0123N, ~Base.e01N, ~Base.e02N, Base._0, Base._0, Base._0, Base._0, Base.e012N, Base._0
		},
		new[] {
			Base.e0N, Base._0, ~Base.e01N, ~Base.e02N, ~Base.e03N, ~Base.e0, Base._0, Base._0, Base._0, Base._0, Base.e012N,
			Base.e013N, Base.e01, Base.e023N, Base.e02, Base.e03, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0,
			~Base.e0123N, ~Base.e012, ~Base.e013, ~Base.e023, Base._0, Base._0, Base._0, Base._0, Base.e0123, Base._0
		},
		new[] {
			Base.e12, Base.e012, ~Base.e2, Base.e1, Base.e123, Base.e12N, ~Base.e02, Base.e01, Base.e0123, Base.e012N,
			~Base._1_, ~Base.e23, ~Base.e2N, Base.e13, Base.e1N, Base.e123N, ~Base.e0, ~Base.e023, ~Base.e02N, Base.e013,
			Base.e01N, Base.e0123N, ~Base.e3, ~Base.eN, ~Base.e23N, Base.e13N, ~Base.e03, ~Base.e0N, ~Base.e023N,
			Base.e013N, ~Base.e3N, ~Base.e03N
		},
		new[] {
			Base.e13, Base.e013, ~Base.e3, ~Base.e123, Base.e1, Base.e13N, ~Base.e03, ~Base.e0123, Base.e01, Base.e013N,
			Base.e23, ~Base._1_, ~Base.e3N, ~Base.e12, ~Base.e123N, Base.e1N, Base.e023, ~Base.e0, ~Base.e03N, ~Base.e012,
			~Base.e0123N, Base.e01N, Base.e2, Base.e23N, ~Base.eN, ~Base.e12N, Base.e02, Base.e023N, ~Base.e0N, ~Base.e012N,
			Base.e2N, Base.e02N
		},
		new[] {
			Base.e1N, Base.e01N, ~Base.eN, ~Base.e12N, ~Base.e13N, ~Base.e1, ~Base.e0N, ~Base.e012N, ~Base.e013N, ~Base.e01,
			Base.e2N, Base.e3N, Base._1_, Base.e123N, Base.e12, Base.e13, Base.e02N, Base.e03N, Base.e0, Base.e0123N,
			Base.e012, Base.e013, ~Base.e23N, ~Base.e2, ~Base.e3, ~Base.e123, ~Base.e023N, ~Base.e02, ~Base.e03,
			~Base.e0123, Base.e23, Base.e023
		},
		new[] {
			Base.e23, Base.e023, Base.e123, ~Base.e3, Base.e2, Base.e23N, Base.e0123, ~Base.e03, Base.e02, Base.e023N,
			~Base.e13, Base.e12, Base.e123N, ~Base._1_, ~Base.e3N, Base.e2N, ~Base.e013, Base.e012, Base.e0123N, ~Base.e0,
			~Base.e03N, Base.e02N, ~Base.e1, ~Base.e13N, Base.e12N, ~Base.eN, ~Base.e01, ~Base.e013N, Base.e012N, ~Base.e0N,
			~Base.e1N, ~Base.e01N
		},
		new[] {
			Base.e2N, Base.e02N, Base.e12N, ~Base.eN, ~Base.e23N, ~Base.e2, Base.e012N, ~Base.e0N, ~Base.e023N, ~Base.e02,
			~Base.e1N, ~Base.e123N, ~Base.e12, Base.e3N, Base._1_, Base.e23, ~Base.e01N, ~Base.e0123N, ~Base.e012, Base.e03N,
			Base.e0, Base.e023, Base.e13N, Base.e1, Base.e123, ~Base.e3, Base.e013N, Base.e01, Base.e0123, ~Base.e03,
			~Base.e13, ~Base.e013
		},
		new[] {
			Base.e3N, Base.e03N, Base.e13N, Base.e23N, ~Base.eN, ~Base.e3, Base.e013N, Base.e023N, ~Base.e0N, ~Base.e03,
			Base.e123N, ~Base.e1N, ~Base.e13, ~Base.e2N, ~Base.e23, Base._1_, Base.e0123N, ~Base.e01N, ~Base.e013,
			~Base.e02N, ~Base.e023, Base.e0, ~Base.e12N, ~Base.e123, Base.e1, Base.e2, ~Base.e012N, ~Base.e0123, Base.e01,
			Base.e02, Base.e12, Base.e012
		},
		new[] {
			Base.e012, Base._0, ~Base.e02, Base.e01, Base.e0123, Base.e012N, Base._0, Base._0, Base._0, Base._0, ~Base.e0,
			~Base.e023, ~Base.e02N, Base.e013, Base.e01N, Base.e0123N, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0,
			~Base.e03, ~Base.e0N, ~Base.e023N, Base.e013N, Base._0, Base._0, Base._0, Base._0, ~Base.e03N, Base._0
		},
		new[] {
			Base.e013, Base._0, ~Base.e03, ~Base.e0123, Base.e01, Base.e013N, Base._0, Base._0, Base._0, Base._0, Base.e023,
			~Base.e0, ~Base.e03N, ~Base.e012, ~Base.e0123N, Base.e01N, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0,
			Base.e02, Base.e023N, ~Base.e0N, ~Base.e012N, Base._0, Base._0, Base._0, Base._0, Base.e02N, Base._0
		},
		new[] {
			Base.e01N, Base._0, ~Base.e0N, ~Base.e012N, ~Base.e013N, ~Base.e01, Base._0, Base._0, Base._0, Base._0,
			Base.e02N, Base.e03N, Base.e0, Base.e0123N, Base.e012, Base.e013, Base._0, Base._0, Base._0, Base._0, Base._0,
			Base._0, ~Base.e023N, ~Base.e02, ~Base.e03, ~Base.e0123, Base._0, Base._0, Base._0, Base._0, Base.e023, Base._0
		},
		new[] {
			Base.e023, Base._0, Base.e0123, ~Base.e03, Base.e02, Base.e023N, Base._0, Base._0, Base._0, Base._0, ~Base.e013,
			Base.e012, Base.e0123N, ~Base.e0, ~Base.e03N, Base.e02N, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0,
			~Base.e01, ~Base.e013N, Base.e012N, ~Base.e0N, Base._0, Base._0, Base._0, Base._0, ~Base.e01N, Base._0
		},
		new[] {
			Base.e02N, Base._0, Base.e012N, ~Base.e0N, ~Base.e023N, ~Base.e02, Base._0, Base._0, Base._0, Base._0,
			~Base.e01N, ~Base.e0123N, ~Base.e012, Base.e03N, Base.e0, Base.e023, Base._0, Base._0, Base._0, Base._0,
			Base._0, Base._0, Base.e013N, Base.e01, Base.e0123, ~Base.e03, Base._0, Base._0, Base._0, Base._0, ~Base.e013,
			Base._0
		},
		new[] {
			Base.e03N, Base._0, Base.e013N, Base.e023N, ~Base.e0N, ~Base.e03, Base._0, Base._0, Base._0, Base._0,
			Base.e0123N, ~Base.e01N, ~Base.e013, ~Base.e02N, ~Base.e023, Base.e0, Base._0, Base._0, Base._0, Base._0,
			Base._0, Base._0, ~Base.e012N, ~Base.e0123, Base.e01, Base.e02, Base._0, Base._0, Base._0, Base._0, Base.e012,
			Base._0
		},
		new[] {
			Base.e123, ~Base.e0123, Base.e23, ~Base.e13, Base.e12, Base.e123N, ~Base.e023, Base.e013, ~Base.e012,
			~Base.e0123N, ~Base.e3, Base.e2, Base.e23N, ~Base.e1, ~Base.e13N, Base.e12N, Base.e03, ~Base.e02, ~Base.e023N,
			Base.e01, Base.e013N, ~Base.e012N, ~Base._1_, ~Base.e3N, Base.e2N, ~Base.e1N, Base.e0, Base.e03N, ~Base.e02N,
			Base.e01N, ~Base.eN, Base.e0N
		},
		new[] {
			Base.e12N, ~Base.e012N, Base.e2N, ~Base.e1N, ~Base.e123N, ~Base.e12, ~Base.e02N, Base.e01N, Base.e0123N,
			Base.e012, ~Base.eN, ~Base.e23N, ~Base.e2, Base.e13N, Base.e1, Base.e123, Base.e0N, Base.e023N, Base.e02,
			~Base.e013N, ~Base.e01, ~Base.e0123, Base.e3N, Base._1_, Base.e23, ~Base.e13, ~Base.e03N, ~Base.e0, ~Base.e023,
			Base.e013, ~Base.e3, Base.e03
		},
		new[] {
			Base.e13N, ~Base.e013N, Base.e3N, Base.e123N, ~Base.e1N, ~Base.e13, ~Base.e03N, ~Base.e0123N, Base.e01N,
			Base.e013, Base.e23N, ~Base.eN, ~Base.e3, ~Base.e12N, ~Base.e123, Base.e1, ~Base.e023N, Base.e0N, Base.e03,
			Base.e012N, Base.e0123, ~Base.e01, ~Base.e2N, ~Base.e23, Base._1_, Base.e12, Base.e02N, Base.e023, ~Base.e0,
			~Base.e012, Base.e2, ~Base.e02
		},
		new[] {
			Base.e23N, ~Base.e023N, ~Base.e123N, Base.e3N, ~Base.e2N, ~Base.e23, Base.e0123N, ~Base.e03N, Base.e02N,
			Base.e023, ~Base.e13N, Base.e12N, Base.e123, ~Base.eN, ~Base.e3, Base.e2, Base.e013N, ~Base.e012N, ~Base.e0123,
			Base.e0N, Base.e03, ~Base.e02, Base.e1N, Base.e13, ~Base.e12, Base._1_, ~Base.e01N, ~Base.e013, Base.e012,
			~Base.e0, ~Base.e1, Base.e01
		},
		new[] {
			Base.e0123, Base._0, Base.e023, ~Base.e013, Base.e012, Base.e0123N, Base._0, Base._0, Base._0, Base._0,
			~Base.e03, Base.e02, Base.e023N, ~Base.e01, ~Base.e013N, Base.e012N, Base._0, Base._0, Base._0, Base._0,
			Base._0, Base._0, ~Base.e0, ~Base.e03N, Base.e02N, ~Base.e01N, Base._0, Base._0, Base._0, Base._0, ~Base.e0N,
			Base._0
		},
		new[] {
			Base.e012N, Base._0, Base.e02N, ~Base.e01N, ~Base.e0123N, ~Base.e012, Base._0, Base._0, Base._0, Base._0,
			~Base.e0N, ~Base.e023N, ~Base.e02, Base.e013N, Base.e01, Base.e0123, Base._0, Base._0, Base._0, Base._0,
			Base._0, Base._0, Base.e03N, Base.e0, Base.e023, ~Base.e013, Base._0, Base._0, Base._0, Base._0, ~Base.e03,
			Base._0
		},
		new[] {
			Base.e013N, Base._0, Base.e03N, Base.e0123N, ~Base.e01N, ~Base.e013, Base._0, Base._0, Base._0, Base._0,
			Base.e023N, ~Base.e0N, ~Base.e03, ~Base.e012N, ~Base.e0123, Base.e01, Base._0, Base._0, Base._0, Base._0,
			Base._0, Base._0, ~Base.e02N, ~Base.e023, Base.e0, Base.e012, Base._0, Base._0, Base._0, Base._0, Base.e02,
			Base._0
		},
		new[] {
			Base.e023N, Base._0, ~Base.e0123N, Base.e03N, ~Base.e02N, ~Base.e023, Base._0, Base._0, Base._0, Base._0,
			~Base.e013N, Base.e012N, Base.e0123, ~Base.e0N, ~Base.e03, Base.e02, Base._0, Base._0, Base._0, Base._0,
			Base._0, Base._0, Base.e01N, Base.e013, ~Base.e012, Base.e0, Base._0, Base._0, Base._0, Base._0, ~Base.e01,
			Base._0
		},
		new[] {
			Base.e123N, Base.e0123N, ~Base.e23N, Base.e13N, ~Base.e12N, ~Base.e123, ~Base.e023N, Base.e013N, ~Base.e012N,
			~Base.e0123, ~Base.e3N, Base.e2N, Base.e23, ~Base.e1N, ~Base.e13, Base.e12, ~Base.e03N, Base.e02N, Base.e023,
			~Base.e01N, ~Base.e013, Base.e012, Base.eN, Base.e3, ~Base.e2, Base.e1, Base.e0N, Base.e03, ~Base.e02, Base.e01,
			~Base._1_, ~Base.e0
		},
		new[] {
			Base.e0123N, Base._0, ~Base.e023N, Base.e013N, ~Base.e012N, ~Base.e0123, Base._0, Base._0, Base._0, Base._0,
			~Base.e03N, Base.e02N, Base.e023, ~Base.e01N, ~Base.e013, Base.e012, Base._0, Base._0, Base._0, Base._0,
			Base._0, Base._0, Base.e0N, Base.e03, ~Base.e02, Base.e01, Base._0, Base._0, Base._0, Base._0, ~Base.e0, Base._0
		}
	};

	/// <summary> * Full Geometric Product </summary>
	public static readonly IReadOnlyList<IReadOnlyList<Base>> ProductGeometric = _ProductGeometric;

	/// <summary> Dot/Inner Product </summary>
	/// <remarks>
	/// ~ Values indicate negative Products.
	/// </remarks>
	static readonly Base[][] _ProductDot = {
		new[] {
			Base._1_, Base.e0, Base.e1, Base.e2, Base.e3, Base.eN, Base.e01, Base.e02, Base.e03, Base.e0N, Base.e12,
			Base.e13, Base.e1N, Base.e23, Base.e2N, Base.e3N, Base.e012, Base.e013, Base.e01N, Base.e023, Base.e02N,
			Base.e03N, Base.e123, Base.e12N, Base.e13N, Base.e23N, Base.e0123, Base.e012N, Base.e013N, Base.e023N,
			Base.e123N, Base.e0123N
		},
		new[] { //e0.dot(x) == 0
			Base.e0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0,
			Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0,
			Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0
		},
		new[] { //e1.Dot(e1) == 1
			Base.e1, Base._0, Base._1_, Base._0, Base._0, Base._0, ~Base.e0, Base._0, Base._0, Base._0, Base.e2, Base.e3,
			Base.eN, Base._0, Base._0, Base._0, ~Base.e02, ~Base.e03, ~Base.e0N, Base._0, Base._0, Base._0, Base.e23,
			Base.e2N, Base.e3N, Base._0, ~Base.e023, ~Base.e02N, ~Base.e03N, Base._0, Base.e23N, ~Base.e023N
		},
		new[] { //e1.Dot(e2) == 1
			Base.e2, Base._0, Base._0, Base._1_, Base._0, Base._0, Base._0, ~Base.e0, Base._0, Base._0, ~Base.e1, Base._0,
			Base._0, Base.e3, Base.eN, Base._0, Base.e01, Base._0, Base._0, ~Base.e03, ~Base.e0N, Base._0, ~Base.e13,
			~Base.e1N, Base._0, Base.e3N, Base.e013, Base.e01N, Base._0, ~Base.e03N, ~Base.e13N, Base.e013N
		},
		new[] { //e1.Dot(e3) == 1
			Base.e3, Base._0, Base._0, Base._0, Base._1_, Base._0, Base._0, Base._0, ~Base.e0, Base._0, Base._0, ~Base.e1,
			Base._0, ~Base.e2, Base._0, Base.eN, Base._0, Base.e01, Base._0, Base.e02, Base._0, ~Base.e0N, Base.e12,
			Base._0, ~Base.e1N, ~Base.e2N, ~Base.e012, Base._0, Base.e01N, Base.e02N, Base.e12N, ~Base.e012N
		},
		new[] { //eN.Dot(eN) == -1
			Base.eN, Base._0, Base._0, Base._0, Base._0, ~Base._1_, Base._0, Base._0, Base._0, Base.e0, Base._0, Base._0,
			Base.e1, Base._0, Base.e2, Base.e3, Base._0, Base._0, ~Base.e01, Base._0, ~Base.e02, ~Base.e03, Base._0,
			~Base.e12, ~Base.e13, ~Base.e23, Base._0, Base.e012, Base.e013, Base.e023, Base.e123, ~Base.e0123
		},

		#region 10 BiVectors

		new[] { //e01.
			Base.e01, Base._0, Base.e0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0,
			Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0,
			Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0
		},
		new[] {
			Base.e02, Base._0, Base._0, Base.e0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0,
			Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0,
			Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0
		},
		new[] {
			Base.e03, Base._0, Base._0, Base._0, Base.e0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0,
			Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0,
			Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0
		},
		new[] {
			Base.e0N, Base._0, Base._0, Base._0, Base._0, ~Base.e0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0,
			Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0,
			Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0
		},

		new[] {
			Base.e12, Base._0, ~Base.e2, Base.e1, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, ~Base._1_, Base._0,
			Base._0, Base._0, Base._0, Base._0, ~Base.e0, Base._0, Base._0, Base._0, Base._0, Base._0, ~Base.e3, ~Base.eN,
			Base._0, Base._0, ~Base.e03, ~Base.e0N, Base._0, Base._0, ~Base.e3N, ~Base.e03N
		},
		new[] {
			Base.e13, Base._0, ~Base.e3, Base._0, Base.e1, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, ~Base._1_,
			Base._0, Base._0, Base._0, Base._0, Base._0, ~Base.e0, Base._0, Base._0, Base._0, Base._0, Base.e2, Base._0,
			~Base.eN, Base._0, Base.e02, Base._0, ~Base.e0N, Base._0, Base.e2N, Base.e02N
		},
		new[] {
			Base.e1N, Base._0, ~Base.eN, Base._0, Base._0, ~Base.e1, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0,
			Base._1_, Base._0, Base._0, Base._0, Base._0, Base._0, Base.e0, Base._0, Base._0, Base._0, Base._0, ~Base.e2,
			~Base.e3, Base._0, Base._0, ~Base.e02, ~Base.e03, Base._0, Base.e23, Base.e023
		},

		new[] {
			Base.e23, Base._0, Base._0, ~Base.e3, Base.e2, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0,
			Base._0, ~Base._1_, Base._0, Base._0, Base._0, Base._0, Base._0, ~Base.e0, Base._0, Base._0, ~Base.e1, Base._0,
			Base._0, ~Base.eN, ~Base.e01, Base._0, Base._0, ~Base.e0N, ~Base.e1N, ~Base.e01N
		},
		new[] {
			Base.e2N, Base._0, Base._0, ~Base.eN, Base._0, ~Base.e2, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0,
			Base._0, Base._0, Base._1_, Base._0, Base._0, Base._0, Base._0, Base._0, Base.e0, Base._0, Base._0, Base.e1,
			Base._0, ~Base.e3, Base._0, Base.e01, Base._0, ~Base.e03, ~Base.e13, ~Base.e013
		},
		new[] {
			Base.e3N, Base._0, Base._0, Base._0, ~Base.eN, ~Base.e3, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0,
			Base._0, Base._0, Base._0, Base._1_, Base._0, Base._0, Base._0, Base._0, Base._0, Base.e0, Base._0, Base._0,
			Base.e1, Base.e2, Base._0, Base._0, Base.e01, Base.e02, Base.e12, Base.e012
		},

		#endregion 10 BiVectors

		#region 10 TriVectors
		new[] {
			Base.e012, Base._0, ~Base.e02, Base.e01, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, ~Base.e0,
			Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0,
			Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0
		},
		new[] {
			Base.e013, Base._0, ~Base.e03, Base._0, Base.e01, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0,
			~Base.e0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0,
			Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0
		},
		new[] {
			Base.e01N, Base._0, ~Base.e0N, Base._0, Base._0, ~Base.e01, Base._0, Base._0, Base._0, Base._0, Base._0,
			Base._0, Base.e0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0,
			Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0
		},
		new[] {
			Base.e023, Base._0, Base._0, ~Base.e03, Base.e02, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0,
			Base._0, ~Base.e0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0,
			Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0
		},
		new[] {
			Base.e02N, Base._0, Base._0, ~Base.e0N, Base._0, ~Base.e02, Base._0, Base._0, Base._0, Base._0, Base._0,
			Base._0, Base._0, Base._0, Base.e0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0,
			Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0
		},
		new[] {
			Base.e03N, Base._0, Base._0, Base._0, ~Base.e0N, ~Base.e03, Base._0, Base._0, Base._0, Base._0, Base._0,
			Base._0, Base._0, Base._0, Base._0, Base.e0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0,
			Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0
		},

		new[] {
			Base.e123, Base._0, Base.e23, ~Base.e13, Base.e12, Base._0, Base._0, Base._0, Base._0, Base._0, ~Base.e3,
			Base.e2, Base._0, ~Base.e1, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, ~Base._1_,
			Base._0, Base._0, Base._0, Base.e0, Base._0, Base._0, Base._0, ~Base.eN, Base.e0N
		},
		new[] {
			Base.e12N, Base._0, Base.e2N, ~Base.e1N, Base._0, ~Base.e12, Base._0, Base._0, Base._0, Base._0, ~Base.eN,
			Base._0, ~Base.e2, Base._0, Base.e1, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0,
			Base._1_, Base._0, Base._0, Base._0, ~Base.e0, Base._0, Base._0, ~Base.e3, Base.e03
		},
		new[] {
			Base.e13N, Base._0, Base.e3N, Base._0, ~Base.e1N, ~Base.e13, Base._0, Base._0, Base._0, Base._0, Base._0,
			~Base.eN, ~Base.e3, Base._0, Base._0, Base.e1, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0,
			Base._0, Base._1_, Base._0, Base._0, Base._0, ~Base.e0, Base._0, Base.e2, ~Base.e02
		},
		new[] {
			Base.e23N, Base._0, Base._0, Base.e3N, ~Base.e2N, ~Base.e23, Base._0, Base._0, Base._0, Base._0, Base._0,
			Base._0, Base._0, ~Base.eN, ~Base.e3, Base.e2, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0,
			Base._0, Base._0, Base._1_, Base._0, Base._0, Base._0, ~Base.e0, ~Base.e1, Base.e01
		},

		#endregion 10 TriVectors

		#region 5 QuadVectors

		new[] {
			Base.e0123, Base._0, Base.e023, ~Base.e013, Base.e012, Base._0, Base._0, Base._0, Base._0, Base._0, ~Base.e03,
			Base.e02, Base._0, ~Base.e01, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, ~Base.e0,
			Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0
		},
		new[] {
			Base.e012N, Base._0, Base.e02N, ~Base.e01N, Base._0, ~Base.e012, Base._0, Base._0, Base._0, Base._0, ~Base.e0N,
			Base._0, ~Base.e02, Base._0, Base.e01, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0,
			Base.e0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0
		},
		new[] {
			Base.e013N, Base._0, Base.e03N, Base._0, ~Base.e01N, ~Base.e013, Base._0, Base._0, Base._0, Base._0, Base._0,
			~Base.e0N, ~Base.e03, Base._0, Base._0, Base.e01, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0,
			Base._0, Base.e0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0
		},
		new[] {
			Base.e023N, Base._0, Base._0, Base.e03N, ~Base.e02N, ~Base.e023, Base._0, Base._0, Base._0, Base._0, Base._0,
			Base._0, Base._0, ~Base.e0N, ~Base.e03, Base.e02, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0,
			Base._0, Base._0, Base.e0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0
		},
		new[] {
			Base.e123N, Base._0, ~Base.e23N, Base.e13N, ~Base.e12N, ~Base.e123, Base._0, Base._0, Base._0, Base._0,
			~Base.e3N, Base.e2N, Base.e23, ~Base.e1N, ~Base.e13, Base.e12, Base._0, Base._0, Base._0, Base._0, Base._0,
			Base._0, Base.eN, Base.e3, ~Base.e2, Base.e1, Base._0, Base._0, Base._0, Base._0, ~Base._1_, ~Base.e0
		},

		#endregion 5 QuadVectors

		new[] { //I the 
			Base.e0123N, Base._0, ~Base.e023N, Base.e013N, ~Base.e012N, ~Base.e0123, Base._0, Base._0, Base._0, Base._0,
			~Base.e03N, Base.e02N, Base.e023, ~Base.e01N, ~Base.e013, Base.e012, Base._0, Base._0, Base._0, Base._0,
			Base._0, Base._0, Base.e0N, Base.e03, ~Base.e02, Base.e01, Base._0, Base._0, Base._0, Base._0, ~Base.e0, Base._0
		}
	};

	/// <summary> Dot/Inner/Scalar Product </summary>
	public static readonly IReadOnlyList<IReadOnlyList<Base>> ProductDot = _ProductDot;

	/// <summary>Ordered array of all three Cayley tables: geometric, dot, and outer; order must match <see cref="Products"/>.</summary>
	static readonly Base[][][] _Products = { _ProductGeometric, _ProductDot, _ProductOuter};
	/// <summary>Public read-only view of all three product Cayley tables indexed by product type.</summary>
	public static readonly IReadOnlyList<IReadOnlyList<IReadOnlyList<Base>>> Products = _Products;

	#endregion Cayley Tables for different Products in R3,0,0

	#region basis blades
	// ReSharper disable InconsistentNaming
	/// <inheritdoc cref="Base._1_"/>
	public static readonly R311 _1_ = new(1, Base._1_);
	/// <inheritdoc cref="Base.e0"/>
	public static readonly R311 e0 = new(1, Base.e0);
	/// <inheritdoc cref="Base.e1"/>
	public static readonly R311 e1 = new(1, Base.e1);
	/// <inheritdoc cref="Base.e2"/>
	public static readonly R311 e2 = new(1, Base.e2);
	/// <inheritdoc cref="Base.e3"/>
	public static readonly R311 e3 = new(1, Base.e3);
	/// <inheritdoc cref="Base.eN"/>
	public static readonly R311 eN = new(1, Base.eN);
	/// <inheritdoc cref="Base.e01"/>
	public static readonly R311 e01 = new(1, Base.e01);
	/// <inheritdoc cref="Base.e02"/>
	public static readonly R311 e02 = new(1, Base.e02);
	/// <inheritdoc cref="Base.e03"/>
	public static readonly R311 e03 = new(1, Base.e03);
	/// <inheritdoc cref="Base.e0N"/>
	public static readonly R311 e0N = new(1, Base.e0N);
	/// <inheritdoc cref="Base.e12"/>
	public static readonly R311 e12 = new(1, Base.e12);
	/// <inheritdoc cref="Base.e13"/>
	public static readonly R311 e13 = new(1, Base.e13);
	/// <inheritdoc cref="Base.e1N"/>
	public static readonly R311 e1N = new(1, Base.e1N);
	/// <inheritdoc cref="Base.e23"/>
	public static readonly R311 e23 = new(1, Base.e23);
	/// <inheritdoc cref="Base.e2N"/>
	public static readonly R311 e2N = new(1, Base.e2N);
	/// <inheritdoc cref="Base.e3N"/>
	public static readonly R311 e3N = new(1, Base.e3N);

	/// <inheritdoc cref="Base.e012"/>
	public static readonly R311 e012 = new(1, Base.e012);
	/// <inheritdoc cref="Base.e013"/>
	public static readonly R311 e013 = new(1, Base.e013);
	/// <inheritdoc cref="Base.e01N"/>
	public static readonly R311 e01N = new(1, Base.e01N);
	/// <inheritdoc cref="Base.e023"/>
	public static readonly R311 e023 = new(1, Base.e023);
	/// <inheritdoc cref="Base.e02N"/>
	public static readonly R311 e02N = new(1, Base.e02N);
	/// <inheritdoc cref="Base.e03N"/>
	public static readonly R311 e03N = new(1, Base.e03N);

	/// <inheritdoc cref="Base.e123"/>
	public static readonly R311 e123 = new(1, Base.e123);
	/// <inheritdoc cref="Base.e23N"/>
	public static readonly R311 e23N = new(1, Base.e23N);
	/// <inheritdoc cref="Base.e13N"/>
	public static readonly R311 e13N = new(1, Base.e13N);
	/// <inheritdoc cref="Base.e12N"/>
	public static readonly R311 e12N = new(1, Base.e12N);

	/// <inheritdoc cref="Base.e0123"/>
	public static readonly R311 e0123 = new(1, Base.e0123);
	/// <inheritdoc cref="Base.e012N"/>
	public static readonly R311 e012N = new(1, Base.e012N);
	/// <inheritdoc cref="Base.e013N"/>
	public static readonly R311 e013N = new(1, Base.e013N);
	/// <inheritdoc cref="Base.e023N"/>
	public static readonly R311 e023N = new(1, Base.e023N);
	/// <inheritdoc cref="Base.e123N"/>
	public static readonly R311 e123N = new(1, Base.e123N);

	/// <inheritdoc cref="Base.e0123N"/>
	public static readonly R311 e0123N = new(1, Base.e0123N);
	// ReSharper restore InconsistentNaming
	#endregion basis blades

	/// <summary>Backing array of all 32 ordered unit basis blades of the R311 algebra.</summary>
	static readonly R311[] _Blades = { _1_,
		e0, e1, e2, e3, eN, 
		e01, e02, e03, e0N,
		e12, e13, e1N, e23, e2N, e3N
		, e012, e013, e01N, e023, e02N, e03N
		, e123, e23N, e13N, e12N
		, e0123, e012N, e013N, e023N
		, e123N
		, e0123N};
	/// <summary>Public read-only view of all 32 ordered unit basis blades.</summary>
	public static R311[] Blades = _Blades;

	/// <summary> Creates a new <see cref="R311"/> from the supplied component array, checking the length. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/clifford_algebra, code/conformal_geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 4}
	/// </code>
	/// </example>
	public static R311 New(params float[] f) => New((IReadOnlyList<float>) f);
	/// <inheritdoc cref="New(float[])"/>
	public static R311 New(IReadOnlyList<float> f) => new(f);
	/// <inheritdoc cref="New(float[])"/>
	public static R311 New(double f = 0, int idx = 0) => new(f, idx);
	/// <inheritdoc cref="New(float[])"/>
	public static R311 New(double f = 0, Base idx = 0) => new(f, idx);

	/// <summary>Gets or sets the element at the specified <paramref name="index"/>.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/clifford_algebra, code/conformal_geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 4}
	/// </code>
	/// </example>
	public float this[Base idx] => _C[(int) idx];

	/// <inheritdoc />
	public override R311 Create(IReadOnlyList<float> values) => new(values);
	/// <inheritdoc cref="Create(IReadOnlyList{float})"/>
	public override R311 Create(IList<float> values) => new((IReadOnlyList<float>)values);
	/// <inheritdoc />
	protected override R311 Create_(float[] values) => new(values);

	/// <summary>Initializes a new instance of <see cref="R311"/> with the specified <paramref name="f"/> and <paramref name="idx"/>.<br/>
	/// Initializes a new instance of <see cref="R311"/> with the specified <paramref name="f"/> and <paramref name="idx"/>.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/clifford_algebra, code/conformal_geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 4}
	/// </code>
	/// </example>
	public R311(double f = 0, Base idx = 0) : base(f, (int)idx) {}
	/// <summary>Initializes a new instance of <see cref="R311"/> with the specified <paramref name="f"/> and <paramref name="idx"/>.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/clifford_algebra, code/conformal_geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 4}
	/// </code>
	/// </example>
	public R311(double f = 0, int idx = 0) : base(f, idx) {}
	/// <summary>Initializes a new instance of <see cref="R311"/> with the specified <paramref name="values"/>.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/clifford_algebra, code/conformal_geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 4}
	/// </code>
	/// </example>
	public R311(IReadOnlyList<Base<Base>> values) : base(AsMultiVector(values)) { }
	/// <summary>Initializes a new instance of <see cref="R311"/> with the specified <paramref name="values"/>.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/clifford_algebra, code/conformal_geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 4}
	/// </code>
	/// </example>
	public R311(params Base<Base>[] values) : base(AsMultiVector(values)) { }

	/// <summary> Converts an array of weighted <see cref="Base{T}"/> blades into a flat float component array of length <see cref="AGeoGebra32{T}.NUM_COORDS"/>. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/clifford_algebra, code/conformal_geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 4}
	/// </code>
	/// </example>
	public static float[] AsMultiVector<T>(IReadOnlyList<Base<T>> values) where T : Enum
		=> values.AsSingles(NUM_COORDS);

	/// <summary> Unchecked private Constructor for Speed </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/clifford_algebra, code/conformal_geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 4}
	/// </code>
	/// </example>
	R311(params float[] f) : base(f) {}

	/// <summary> Checked Constructor </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/clifford_algebra, code/conformal_geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 4}
	/// </code>
	/// </example>
	public R311(IReadOnlyList<float> values) : base(values) {}

	/// <inheritdoc />
	public override R311 Dual() => New(_C.Dual32());
	/// <inheritdoc />
	public override double NormSqr() => _C.NormSqr32R311();

	/// <inheritdoc />
	public override R311 TimesR(IReadOnlyList<float> factor) => new(factor.Times32(_C));
	/// <inheritdoc />
	public override R311 Times(IReadOnlyList<float> factor) => new(_C.Times32(factor));
	/// <inheritdoc />
	public override R311 Meet(IReadOnlyList<float> that) => new(_C.Wedge32(that));
	/// <inheritdoc />
	public override R311 MeetR(IReadOnlyList<float> that) => new(that.Wedge32(_C));

	/// <inheritdoc />
	public override R311 Join(IReadOnlyList<float> that) => New(_C.Join32(that));
	/// <inheritdoc />
	public override R311 Dot(IReadOnlyList<float> that) => new(_C.Dot32(that));

	/// <summary> *; geometric product. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/clifford_algebra, code/conformal_geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 4}
	/// </code>
	/// </example>
	protected override double[][] Coefficients() => new[]
	{  new double[] { _C[00],		0, _C[02], _C[03], _C[04], -_C[05],		0,		0,		0,			0, -_C[10], -_C[11], _C[12], -_C[13], _C[14], _C[15],		0,		0,		0,		0,			0,		0, -_C[22], _C[23], _C[24], _C[25],		0,		0,		0,			0, -_C[30],0,
		}, new double[] { _C[01], _C[00], -_C[06], -_C[07], -_C[08], _C[09], _C[02], _C[03], _C[04],  -_C[05], -_C[16], -_C[17], _C[18], -_C[19], _C[20], _C[21], -_C[10], -_C[11], _C[12], -_C[13], _C[14], _C[15], _C[26], -_C[27], -_C[28], -_C[29], -_C[22], _C[23], _C[24], _C[25], -_C[31], -_C[30],
		}, new double[] { _C[02],		0, _C[00], -_C[10], -_C[11], _C[12],		0,		0,		0,			0, _C[03], _C[04], -_C[05], -_C[22], _C[23], _C[24],		0,		0,		0,		0,			0,		0, -_C[13], _C[14], _C[15], -_C[30],		0,		0,		0,			0, _C[25],0,
		}, new double[] { _C[03],		0, _C[10], _C[00], -_C[13], _C[14],		0,		0,		0,			0, -_C[02], _C[22], -_C[23], _C[04], -_C[05], _C[25],		0,		0,		0,		0,			0,		0, _C[11], -_C[12], _C[30], _C[15],		0,		0,		0,			0, -_C[24],0,
		}, new double[] { _C[04],		0, _C[11], _C[13], _C[00], _C[15],		0,		0,		0,			0, -_C[22], -_C[02], -_C[24], -_C[03], -_C[25], -_C[05],		0,		0,		0,		0,			0,		0, -_C[10], -_C[30], -_C[12], -_C[14],		0,		0,		0,			0, _C[23],0,
		}, new double[] { _C[05],		0, _C[12], _C[14], _C[15], _C[00],		0,		0,		0,			0, -_C[23], -_C[24], -_C[02], -_C[25], -_C[03], -_C[04],		0,		0,		0,		0,			0,		0, -_C[30], -_C[10], -_C[11], -_C[13],		0,		0,		0,			0, _C[22],0,
		}, new double[] { _C[06], _C[02], -_C[01], _C[16], _C[17], -_C[18], _C[00], -_C[10], -_C[11], _C[12], _C[07], _C[08], -_C[09], -_C[26], _C[27], _C[28], _C[03], _C[04], -_C[05], -_C[22], _C[23], _C[24], _C[19], -_C[20], -_C[21], _C[31], -_C[13], _C[14], _C[15], -_C[30], _C[29], _C[25],
		}, new double[] { _C[07], _C[03], -_C[16], -_C[01], _C[19], -_C[20], _C[10], _C[00], -_C[13], _C[14], -_C[06], _C[26], -_C[27], _C[08], -_C[09], _C[29], -_C[02], _C[22], -_C[23], _C[04], -_C[05], _C[25], -_C[17], _C[18], -_C[31], -_C[21], _C[11], -_C[12], _C[30], _C[15], -_C[28], -_C[24],
		}, new double[] { _C[08], _C[04], -_C[17], -_C[19], -_C[01], -_C[21], _C[11], _C[13], _C[00], _C[15], -_C[26], -_C[06], -_C[28], -_C[07], -_C[29], -_C[09], -_C[22], -_C[02], -_C[24], -_C[03], -_C[25], -_C[05], _C[16], _C[31], _C[18], _C[20], -_C[10], -_C[30], -_C[12], -_C[14], _C[27], _C[23],
		}, new double[] { _C[09], _C[05], -_C[18], -_C[20], -_C[21], -_C[01], _C[12], _C[14], _C[15], _C[00], -_C[27], -_C[28], -_C[06], -_C[29], -_C[07], -_C[08], -_C[23], -_C[24], -_C[02], -_C[25], -_C[03], -_C[04], _C[31], _C[16], _C[17], _C[19], -_C[30], -_C[10], -_C[11], -_C[13], _C[26], _C[22],
		}, new double[] { _C[10],		0, _C[03], -_C[02], _C[22], -_C[23],		0,		0,		0,			0, _C[00], -_C[13], _C[14], _C[11], -_C[12], _C[30],		0,		0,		0,		0,			0,		0, _C[04], -_C[05], _C[25], -_C[24],		0,		0,		0,			0, _C[15],0,
		}, new double[] { _C[11],		0, _C[04], -_C[22], -_C[02], -_C[24],		0,		0,		0,			0, _C[13], _C[00], _C[15], -_C[10], -_C[30], -_C[12],		0,		0,		0,		0,			0,		0, -_C[03], -_C[25], -_C[05], _C[23],		0,		0,		0,			0, -_C[14],0,
		}, new double[] { _C[12],		0, _C[05], -_C[23], -_C[24], -_C[02],		0,		0,		0,			0, _C[14], _C[15], _C[00], -_C[30], -_C[10], -_C[11],		0,		0,		0,		0,			0,		0, -_C[25], -_C[03], -_C[04], _C[22],		0,		0,		0,			0, -_C[13],0,
		}, new double[] { _C[13],		0, _C[22], _C[04], -_C[03], -_C[25],		0,		0,		0,			0, -_C[11], _C[10], _C[30], _C[00], _C[15], -_C[14],		0,		0,		0,		0,			0,		0, _C[02], _C[24], -_C[23], -_C[05],		0,		0,		0,			0, _C[12],0,
		}, new double[] { _C[14],		0, _C[23], _C[05], -_C[25], -_C[03],		0,		0,		0,			0, -_C[12], _C[30], _C[10], _C[15], _C[00], -_C[13],		0,		0,		0,		0,			0,		0, _C[24], _C[02], -_C[22], -_C[04],		0,		0,		0,			0, _C[11],0,
		}, new double[] { _C[15],		0, _C[24], _C[25], _C[05], -_C[04],		0,		0,		0,			0, -_C[30], -_C[12], _C[11], -_C[14], _C[13], _C[00],		0,		0,		0,		0,			0,		0, -_C[23], _C[22], _C[02], _C[03],		0,		0,		0,			0, -_C[10],0,
		}, new double[] { _C[16], _C[10], -_C[07], _C[06], -_C[26], _C[27], _C[03], -_C[02], _C[22],  -_C[23], _C[01], -_C[19], _C[20], _C[17], -_C[18], _C[31], _C[00], -_C[13], _C[14], _C[11], -_C[12], _C[30], -_C[08], _C[09], -_C[29], _C[28], _C[04], -_C[05], _C[25], -_C[24], _C[21], _C[15],
		}, new double[] { _C[17], _C[11], -_C[08], _C[26], _C[06], _C[28], _C[04], -_C[22], -_C[02],  -_C[24], _C[19], _C[01], _C[21], -_C[16], -_C[31], -_C[18], _C[13], _C[00], _C[15], -_C[10], -_C[30], -_C[12], _C[07], _C[29], _C[09], -_C[27], -_C[03], -_C[25], -_C[05], _C[23], -_C[20], -_C[14],
		}, new double[] { _C[18], _C[12], -_C[09], _C[27], _C[28], _C[06], _C[05], -_C[23], -_C[24],  -_C[02], _C[20], _C[21], _C[01], -_C[31], -_C[16], -_C[17], _C[14], _C[15], _C[00], -_C[30], -_C[10], -_C[11], _C[29], _C[07], _C[08], -_C[26], -_C[25], -_C[03], -_C[04], _C[22], -_C[19], -_C[13],
		}, new double[] { _C[19], _C[13], -_C[26], -_C[08], _C[07], _C[29], _C[22], _C[04], -_C[03],  -_C[25], -_C[17], _C[16], _C[31], _C[01], _C[21], -_C[20], -_C[11], _C[10], _C[30], _C[00], _C[15], -_C[14], -_C[06], -_C[28], _C[27], _C[09], _C[02], _C[24], -_C[23], -_C[05], _C[18], _C[12],
		}, new double[] { _C[20], _C[14], -_C[27], -_C[09], _C[29], _C[07], _C[23], _C[05], -_C[25],  -_C[03], -_C[18], _C[31], _C[16], _C[21], _C[01], -_C[19], -_C[12], _C[30], _C[10], _C[15], _C[00], -_C[13], -_C[28], -_C[06], _C[26], _C[08], _C[24], _C[02], -_C[22], -_C[04], _C[17], _C[11],
		}, new double[] { _C[21], _C[15], -_C[28], -_C[29], -_C[09], _C[08], _C[24], _C[25], _C[05],  -_C[04], -_C[31], -_C[18], _C[17], -_C[20], _C[19], _C[01], -_C[30], -_C[12], _C[11], -_C[14], _C[13], _C[00], _C[27], -_C[26], -_C[06], -_C[07], -_C[23], _C[22], _C[02], _C[03], -_C[16], -_C[10],
		}, new double[] { _C[22],		0, _C[13], -_C[11], _C[10], _C[30],		0,		0,		0,			0, _C[04], -_C[03], -_C[25], _C[02], _C[24], -_C[23],		0,		0,		0,		0,			0,		0, _C[00], _C[15], -_C[14], _C[12],		0,		0,		0,			0, -_C[05],0,
		}, new double[] { _C[23],		0, _C[14], -_C[12], _C[30], _C[10],		0,		0,		0,			0, _C[05], -_C[25], -_C[03], _C[24], _C[02], -_C[22],		0,		0,		0,		0,			0,		0, _C[15], _C[00], -_C[13], _C[11],		0,		0,		0,			0, -_C[04],0,
		}, new double[] { _C[24],		0, _C[15], -_C[30], -_C[12], _C[11],		0,		0,		0,			0, _C[25], _C[05], -_C[04], -_C[23], _C[22], _C[02],		0,		0,		0,		0,			0,		0, -_C[14], _C[13], _C[00], -_C[10],		0,		0,		0,			0, _C[03],0,
		}, new double[] { _C[25],		0, _C[30], _C[15], -_C[14], _C[13],		0,		0,		0,			0, -_C[24], _C[23], -_C[22], _C[05], -_C[04], _C[03],		0,		0,		0,		0,			0,		0, _C[12], -_C[11], _C[10], _C[00],		0,		0,		0,			0, -_C[02],0,
		}, new double[] { _C[26], _C[22], -_C[19], _C[17], -_C[16], -_C[31], _C[13], -_C[11], _C[10], _C[30], _C[08], -_C[07], -_C[29], _C[06], _C[28], -_C[27], _C[04], -_C[03], -_C[25], _C[02], _C[24], -_C[23], -_C[01], -_C[21], _C[20], -_C[18], _C[00], _C[15], -_C[14], _C[12], -_C[09], -_C[05],
		}, new double[] { _C[27], _C[23], -_C[20], _C[18], -_C[31], -_C[16], _C[14], -_C[12], _C[30], _C[10], _C[09], -_C[29], -_C[07], _C[28], _C[06], -_C[26], _C[05], -_C[25], -_C[03], _C[24], _C[02], -_C[22], -_C[21], -_C[01], _C[19], -_C[17], _C[15], _C[00], -_C[13], _C[11], -_C[08], -_C[04],
		}, new double[] { _C[28], _C[24], -_C[21], _C[31], _C[18], -_C[17], _C[15], -_C[30], -_C[12], _C[11], _C[29], _C[09], -_C[08], -_C[27], _C[26], _C[06], _C[25], _C[05], -_C[04], -_C[23], _C[22], _C[02], _C[20], -_C[19], -_C[01], _C[16], -_C[14], _C[13], _C[00], -_C[10], _C[07], _C[03],
		}, new double[] { _C[29], _C[25], -_C[31], -_C[21], _C[20], -_C[19], _C[30], _C[15], -_C[14], _C[13], -_C[28], _C[27], -_C[26], _C[09], -_C[08], _C[07], -_C[24], _C[23], -_C[22], _C[05], -_C[04], _C[03], -_C[18], _C[17], -_C[16], -_C[01], _C[12], -_C[11], _C[10], _C[00], -_C[06], -_C[02],
		}, new double[] { _C[30],		0, _C[25], -_C[24], _C[23], -_C[22],		0,		0,		0,			0, _C[15], -_C[14], _C[13], _C[12], -_C[11], _C[10],		0,		0,		0,		0,			0,		0, _C[05], -_C[04], _C[03], -_C[02],		0,		0,		0,			0, _C[00],0,
		}, new double[] { _C[31], _C[30], -_C[29], _C[28], -_C[27], _C[26], _C[25], -_C[24], _C[23],  -_C[22], _C[21], -_C[20], _C[19], _C[18], -_C[17], _C[16], _C[15], -_C[14], _C[13], _C[12], -_C[11], _C[10], -_C[09], _C[08], -_C[07], _C[06], _C[05], -_C[04], _C[03], -_C[02], _C[01], _C[00],
		}
	};

}
