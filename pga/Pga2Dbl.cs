using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using org.SpocWeb.root.array;
using org.SpocWeb.root.extensions.collections;
using org.SpocWeb.root.interfaces.maths;
using org.SpocWeb.root.maths.pga.ga;
using org.SpocWeb.root.maths.pga.typed;
using org.SpocWeb.root.Attributes;

namespace org.SpocWeb.root.maths.pga;

/// <summary> R201 = 2D+€ PGA (Euclidean Plane-based projective Geometric Algebra) </summary>
/// <remarks>
/// <see cref="ga.Pga2Dbl"/>
/// 2 components with Metric 1 (x, y)
/// 1 Component  with Metric 0 (€)
/// 
/// 2^3 = 8 Coefficients to represent basic geometric Objects and Transformations.
/// Has <see cref="Vector2D"/>, <see cref="Complex"/> and <see cref="Dual"/> as Sub-Algebras.
/// <a href='http://projectivegeometricalgebra.org/wiki'>describes it </a>
///
/// PGA defines these Operators:
/// * - is the regular element-wise Negation resp. Subtraction
/// * + is the regular element-wise Addition
/// * * Dot / inner Product: |a|*|b|*cos(phi) symmetric 
/// * ^ Wedge/Meet/Cross/outer product: |a|*|b|*sin(phi) forms an anti-symmetric Bi-Vector: v^v = 0
/// * ~
/// * !
/// * &amp; Join/Vee: the regressive product.
/// * v
/// * Geometric Product a b = a*b + a v b
///  u u = u² = |u|²
///  ei ei = ei² = 1 for i == j
///  ei ej = ei ^ ej for i != j
/// (ei ej)² = ei ej ei ej = - ei ei ej ej = -1  for i != j
/// I := ei ej for i != j is isomorphic to imaginary i
/// BUT i commutes and I is anti-commutative: a I = -I a
///
/// 4D Base of Multi-Vectors: {1, x, y, x ^ y}
/// a+i*b == a*1 + b*x^y
///
/// Bi-Vectors are equivalence-Classes of Areas with same Size and Orientation (just like Vectors).
/// The actual Shape of the Area (round or rect) does not matter.
///
/// BiVectors can be added by Adjusting their Sides to match, keeping the Area and Orientation.
/// 
/// Geometric Product:
/// Scalar	Line:c	+e1*a	+e2*b=0	 e01*x	+e20*y	+e12*1	Area
///  1  	 e0  	 e1 	 e2 	 e01 	 e20 	 e12 	 e012
///	e0  	  0 	 e01	-e20	  0 	  0 	 e012	  0
///	e1  	-e01	  1 	 e12	-e0 	 e012	 e2 	 e20
/// e2  	 e20	-e12	  1  	 e012	 e0 	-e1 	 e01
///	e01 	  0 	 e0  	 e012	  0 	  0 	-e20	  0
///	e20 	  0 	 e021	 e0  	  0 	  0 	-e01	  0
///	e12 	 e012	-e2 	 e1  	 e20	-e01 	 -1 	-e0
///	e012	  0 	 e20	 e01	  0 	  0 	-e0 	  0
/// 
/// </remarks>
[DocState(Pass = 2, MTime = "2026-05-24T16:42:31Z", Digest = "7c928a1302365d7f622dc650c19bbe88220c4912ffcd086827beb0d4e5ad0759", Stale = false, Path = "pga/Pga2Dbl.cs", Since = "2026-10-06")]
[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
[Tags("code/projective_geometric_algebra")]
[System.ComponentModel.Description("R201 = 2D+€ PGA (Euclidean Plane-based projective Geometric Algebra)")]
[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
public class Pga2Dbl : AGeoGebra8Dbl<Pga2Dbl>
{
	/// <summary> just for debug and print output, the basis names </summary>
	/// <remarks>
	/// The BiVector Order is not canonical; other orders are 
	/// </remarks>
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/projective_geometric_algebra")]
	[System.ComponentModel.Description("just for debug and print output, the basis names")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public override IReadOnlyList<string> Basis => _Basis;
	/// <summary>Ordered array of basis blade name strings for debug and print output.</summary>
	static readonly string[] _Basis = {"", "e0", "e1", "e2", "e01", "e20", "e12", "e012"};

	/// <inheritdoc />
	public override Pga2Dbl Self() => this;

	/// <summary> Static ordered list of all 8 unit basis blades of the algebra. </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/projective_geometric_algebra")]
	[System.ComponentModel.Description("Static ordered list of all 8 unit basis blades of the algebra.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public static IReadOnlyList<Pga2Dbl> Blades => _Blades;
	/// <summary>Gets the blades.</summary>
	static readonly Pga2Dbl[] _Blades = {Base._1_
		, AxisTrans.X, AxisTrans.Y, AxisRot.Z
		, Points.Y, Points.X, Points.O
		, Base.e012 };
	/// <summary> Factory methods for constructing geometric primitives (points, lines) in 2D double-precision PGA. </summary>
	/// <remarks>
	/// ## Public Methods
	///
	/// | Line | Method | Description |
	/// |--:|---|---|
	/// | 131 | <see cref="Point"/> | Point given by Coordinates X and Y |
	/// | 140 | <see cref="PointPolar"/> | Point given by Polar Coordinates directionRad and radius |
	/// | 155 | <see cref="Line"/> | Line given by slope and intersect |
	///
	/// ## Collaborators
	///
	/// | Type | Role |
	/// |---|---|
	/// | <see cref="Pga2Dbl"/> | Returned by a method. |
	/// | <see cref="Vector2"/> | Passed as a parameter. |
	/// </remarks>
	[DocState(Pass = 2, MTime = "2026-06-17T10:08:47Z", Digest = "d4baf63043cef9f9a0fc770ccdc16fefe4aa2badbf91aa44ca337c1f3bbae1a2", Stale = false, Path = "pga/Pga2Dbl.cs", Since = "2026-10-06")]
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/factory", "code/projective_geometric_algebra")]
	[System.ComponentModel.Description("Factory methods for constructing geometric primitives (points, lines) in 2D double-precision PGA.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public static class Make
	{
		/// <summary> Point given by Coordinates <see cref="X"/> and <see cref="Y"/> </summary>
		/// <remarks>
		/// Points are Grade 2 BiVectors, the Intersections of 2 HyperPlanes/Lines,
		/// and operate as Reflectors with themselves as Fixed-Points.
		///
		/// Points are expressed with homogeneous Coordinates,
		/// that means a Point needs to be normalized by dividing through <paramref name="norm"/>.
		/// All Points with the same normalized Coordinates are equivalent!
		///
		/// When <paramref name="norm"/> = 0, this is a Vector, a Point at the infinite Horizon.
		/// All parallel Lines meet at the same Point at the Horizon and form a 1D Vector Space of Rotations. 
		/// </remarks>
		[Facets(Layer = "domain", Status = "stable", Complexity = 1)]
		[Tags("code/factory_method", "code/homogeneous_coordinates")]
		[System.ComponentModel.Description("Point given by Coordinates X and Y")]
		[Concept("point_construction")]
		public static Pga2Dbl Point(double x, double y, double norm = 1) 
			=> new(0, 0, 0, 0, y, x, norm, 0);

		/// <summary> Point given by Polar Coordinates <see cref="directionRad"/> and <see cref="radius"/> </summary>
		///
		[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
		[Tags("code/factory_method", "code/polar_coordinates", "code/trigonometry")]
		[System.ComponentModel.Description("Point given by Polar Coordinates directionRad and radius")]
		[Concept("polar_coordinates")]
		public static Pga2Dbl PointPolar(double directionRad, double radius) {
			var (sin, cos) = directionRad.SinCos();
			return new Pga2Dbl(0, 0, 0, 0, sin, cos, 1 / radius, 0);
		}

		/// <summary> Line given by <paramref name="slope"/> and <paramref name="intersect"/> </summary>
		/// <remarks>
		/// Lines are Grade 1 Vectors and operate as Reflectors
		/// with themselves as Fixed-Points.
		/// All Points with the same normalized Coordinates are equivalent!
		/// </remarks>
		[Facets(Layer = "domain", Status = "stable", Complexity = 1)]
		[Tags("code/factory_method", "code/homogeneous_coordinates")]
		[System.ComponentModel.Description("Line given by slope and intersect")]
		[Concept("line_construction")]
		public static Pga2Dbl Line(double slope, double intersect) 
			=> new(0, intersect, slope, -1, 0, 0, 0, 0);

		/// <summary> Line given by Point and <paramref name="slope"/>/Direction </summary>
		///
		[Facets(Layer = "domain", Status = "stable", Complexity = 1)]
		[Tags("code/factory_method", "code/coordinate_conversion")]
		[System.ComponentModel.Description("Line given by Point and slope/Direction")]
		[Concept("line_construction")]
		public static Pga2Dbl Line(double slope, double y, double x) 
			=> Line(slope, y-x*slope);

		/// <summary> Line given by 2 Points </summary>
		///
		[Facets(Layer = "domain", Status = "stable", Complexity = 1)]
		[Tags("code/factory_method", "code/coordinate_conversion")]
		[System.ComponentModel.Description("Line given by 2 Points")]
		[Concept("line_construction")]
		public static Pga2Dbl Line(double x0, double y0, double x1, double y1) {
			var slope = (y1 - y0) / (x1 - x0);
			return Line(slope, y0, x0);
		}

		/// <summary> Line given by 2 Points </summary>
		///
		[Facets(Layer = "domain", Status = "stable", Complexity = 1)]
		[Tags("code/factory_method", "code/coordinate_conversion")]
		[System.ComponentModel.Description("Line given by 2 Points")]
		[Concept("line_construction")]
		public static Pga2Dbl Line(Vector2 p0, Vector2 p1) {
			var slope = (p1.Y - p0.Y) / (p1.X - p0.X);
			return Line(slope, p0.Y, p0.X);
		}

	}

	/// <summary> Bi-Vectors in projective 2D are Points. </summary>
	/// <remarks>
	/// ## Public Methods
	///
	/// | Line | Method | Description |
	/// |--:|---|---|
	/// | 214 | <see cref="O"/> | Represents o. |
	/// | 224 | <see cref="X"/> | Represents x. |
	/// | 227 | <see cref="Y"/> | Represents y. |
	/// </remarks>
	///
	[DocState(Pass = 2, MTime = "2026-07-07T17:42:05Z", Digest = "e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855", Stale = false, Path = "pga/Pga2Dbl.cs", Since = "2026-10-06")]
	[Facets(Layer = "domain", Status = "stable", Complexity = 1)]
	[Tags("code/enum", "code/projective_geometric_algebra")]
	[System.ComponentModel.Description("Bi-Vectors in projective 2D are Points.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public enum Points : sbyte
	{
		/// <inheritdoc cref="Base.e12"/>
		O = Base.e12,

		/// <inheritdoc cref="Base.e20"/>
		/// <example>
		/// <code language="yaml">
		/// pass: 2
		/// mtime: 2026-06-17T10:08:47Z
		/// digest: 9bf404545a72f1a2e866b6e85280b994ea7325ea9dd816aa2d75938bcdd35ccd
		/// </code>
		/// </example>
		X = Base.e20,

		/// <inheritdoc cref="Base.e01"/>
		Y = Base.e01,
	}

	/// <summary> Vectors in projective 2D are Lines </summary>
	/// <remarks>
	/// ## Public Methods
	///
	/// | Line | Method | Description |
	/// |--:|---|---|
	/// | 249 | <see cref="Horizon"/> | Represents horizon. |
	/// | 252 | <see cref="X"/> | Represents x. |
	/// | 255 | <see cref="Y"/> | Represents y. |
	/// </remarks>
	///
	[DocState(Pass = 2, MTime = "2026-07-07T17:42:05Z", Digest = "e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855", Stale = false, Path = "pga/Pga2Dbl.cs", Since = "2026-10-06")]
	[Facets(Layer = "domain", Status = "stable", Complexity = 1)]
	[Tags("code/enum", "code/projective_geometric_algebra")]
	[System.ComponentModel.Description("Vectors in projective 2D are Lines")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public enum Lines : sbyte
	{
		/// <inheritdoc cref="Base.e0"/>
		Horizon = Base.e0,

		/// <inheritdoc cref="Base.e1"/>
		X = Base.e1,

		/// <inheritdoc cref="Base.e2"/>
		Y = Base.e2,
	}

	/// <summary> Base-Blades in 3D, usable as Indices for Components </summary>
	/// <remarks>
	/// ## Public Methods
	///
	/// | Line | Method | Description |
	/// |--:|---|---|
	/// | 285 | <see cref="_1_"/> | [0] Scalar e.g. Dot Product / oriented Area/Volume Dual |
	/// | 290 | <see cref="e0"/> | [1] Horizon-Line; €-Coordinate; Projective/homogeneous |
	/// | 298 | <see cref="e1"/> | [2] X-Line X-Coordinate |
	/// | 301 | <see cref="e2"/> | [3] Y-Line Y-Coordinate |
	/// | 315 | <see cref="e01"/> | [4] Y-Point-Coordinate |
	/// | 325 | <see cref="e20"/> | [5] X-Point-Coordinate |
	/// | 328 | <see cref="e12"/> | [6] Origin; 1 for Points, 0 for Vectors |
	/// | 334 | <see cref="e012"/> | [7] e012² = 0 Represents i. |
	/// | 336 | <see cref="i"/> | Represents i. |
	/// | 339 | <see cref="_0"/> | No Component; signals both the End of Components and 0-Elements in the Cayley Tables below |
	/// </remarks>
	///
	[DocState(Pass = 2, MTime = "2026-07-07T17:42:05Z", Digest = "3c73246de95cd052c34231e1378c7eac6254ac844825cc25c98c0a340361c81e", Stale = false, Path = "pga/Pga2Dbl.cs", Since = "2026-10-06")]
	[Facets(Layer = "domain", Status = "stable", Complexity = 1)]
	[Tags("code/enum", "code/projective_geometric_algebra")]
	[System.ComponentModel.Description("Base-Blades in 3D, usable as Indices for Components")]
	[SuppressMessage("ReSharper", "InconsistentNaming")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public enum Base : sbyte
	{
		/// <summary>[0] Scalar e.g. Dot Product / oriented Area/Volume Dual</summary>
		_1_,

		#region Line Coordinates: a*e0 + b*e1 + c*e2=0 <=> 0 = e0 + x*e1 + y*c2

		/// <summary>[1] <see cref="Lines.Horizon"/>-Line; €-Coordinate; Projective/homogeneous </summary>
		e0,

		/// <summary>[2] <see cref="Lines.X"/>-Line X-Coordinate </summary>
		/// <remarks>
		/// Vectors have a Length and Direction (but no Origin).
		/// Scalars can be added, subtracted, multiplied by a Scalar.
		/// Vectors can be represented as Differences of Points
		/// </remarks>
		e1,

		/// <summary>[3] <see cref="Lines.Y"/>-Line Y-Coordinate </summary>
		e2,

		#endregion Line Coordinates: a*e0 + b*e1 + c*e2 = 0 <=> 0 = e0 + x*e1 + y*c2

		#region Point Coordinates: e12 + y*e01 + x*e20 = 0

		/// <summary>[4] <see cref="Points.Y"/>-Point-Coordinate </summary>
		/// <example>
		/// <code language="yaml">
		/// pass: 2
		/// mtime: 2026-06-17T10:08:47Z
		/// digest: a12a148db2763e22b0e805cebc76a7ef23711c7175878098474930b3027a22d1
		/// </code>
		/// </example>
		e01,

		/// <summary>[5] <see cref="Points.X"/>-Point-Coordinate </summary>
		/// <example>
		/// <code language="yaml">
		/// pass: 2
		/// mtime: 2026-06-17T10:08:47Z
		/// digest: a12a148db2763e22b0e805cebc76a7ef23711c7175878098474930b3027a22d1
		/// </code>
		/// </example>
		e20,

		/// <summary>[6] Origin; 1 for Points, 0 for Vectors </summary>
		e12,

		#endregion Point Coordinates: e12 + y*e01 + x*e20 = 0

		/// <summary>[7] <see cref="e012"/>² = 0<br/>
		/// Represents i.</summary>
		e012,
		/// <summary>Represents i.</summary>
		i = e012,

		/// <summary> No Component; signals both the End of Components and 0-Elements in the Cayley Tables below </summary>
		_0,// = sbyte.MinValue
	}

	/// <summary> 'Ideal' Axes for <see cref="Make.Translator"/>/<see cref="Make.Motor"/> </summary>
	/// <remarks>
	/// ## Public Methods
	///
	/// | Line | Method | Description |
	/// |--:|---|---|
	/// | 361 | <see cref="Y"/> | Represents y. |
	/// | 364 | <see cref="X"/> | Represents x. |
	/// | 367 | <see cref="_1_"/> | Represents 1. |
	/// </remarks>
	///
	[DocState(Pass = 2, MTime = "2026-07-07T17:42:05Z", Digest = "a12a148db2763e22b0e805cebc76a7ef23711c7175878098474930b3027a22d1", Stale = false, Path = "pga/Pga2Dbl.cs", Since = "2026-10-06")]
	[Facets(Layer = "domain", Status = "stable", Complexity = 1)]
	[Tags("code/enum", "code/projective_geometric_algebra")]
	[System.ComponentModel.Description("'Ideal' Axes for Translator/Motor")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public enum AxisTrans
	{
		/// <inheritdoc cref="Base.e01"/>
		Y = Base.e01,

		/// <inheritdoc cref="Base.e02"/>
		X = Base.e20,

		/// <summary>Represents 1.</summary>
		_1_ = Base._1_,
	}

	/// <summary> Euclidean rotation axes for <see cref="Make.Rotor"/>. </summary>
	/// <remarks>
	/// ## Public Methods
	///
	/// | Line | Method | Description |
	/// |--:|---|---|
	/// | 387 | <see cref="Z"/> | Represents z. |
	/// | 390 | <see cref="_1_"/> | Represents 1. |
	/// </remarks>
	[DocState(Pass = 2, MTime = "2026-06-17T10:08:47Z", Digest = "a12a148db2763e22b0e805cebc76a7ef23711c7175878098474930b3027a22d1", Stale = false, Path = "pga/Pga2Dbl.cs", Since = "2026-10-06")]
	[Facets(Layer = "domain", Status = "stable", Complexity = 1)]
	[Tags("code/enum", "code/projective_geometric_algebra")]
	[System.ComponentModel.Description("Euclidean rotation axes for Rotor.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public enum AxisRot : sbyte
	{
		/// <inheritdoc cref="Base.e12"/>
		Z = Base.e12,

		/// <summary>Represents 1.</summary>
		_1_ = Base._1_,
	}

	/// <summary> Polar Coordinates match projective Geometry </summary>
	/// <remarks>
	/// ## Public Methods
	///
	/// | Line | Method | Description |
	/// |--:|---|---|
	/// | 417 | <see cref="Horizon"/> | Represents horizon. |
	/// | 420 | <see cref="Origin"/> | current Position of the Observer |
	/// | 423 | <see cref="Longitude"/> | Represents longitude. |
	/// | 426 | <see cref="Latitude"/> | Represents latitude. |
	/// | 431 | <see cref="West"/> | Represents west. |
	/// | 434 | <see cref="East"/> | Represents east. |
	/// | 437 | <see cref="North"/> | Represents north. |
	/// | 440 | <see cref="South"/> | Represents south. |
	/// </remarks>
	///
	[DocState(Pass = 2, MTime = "2026-07-07T17:42:05Z", Digest = "29c9f3a451af85939d573e784c285baa9191ad285ee19927efe6c2601e336a65", Stale = false, Path = "pga/Pga2Dbl.cs", Since = "2026-10-06")]
	[Facets(Layer = "domain", Status = "stable", Complexity = 1)]
	[Tags("code/enum", "code/polar_coordinates")]
	[System.ComponentModel.Description("Polar Coordinates match projective Geometry")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public enum Geo : sbyte
	{
		/// <inheritdoc cref="Base.e0"/>
		Horizon = Lines.Horizon,

		/// <summary> current Position of the Observer </summary>
		Origin = Points.O,

		/// <inheritdoc cref="Base.e01"/>
		Longitude = AxisTrans.X,

		/// <inheritdoc cref="Base.e20"/>
		Latitude = AxisTrans.Y,

		#region antipodal 'Points' (TriPlanes) can be distinguished by Sign

		/// <inheritdoc cref="Base.e032"/>
		West = Points.X,

		/// <inheritdoc cref="Base.e032"/>
		East = -Points.X,

		/// <inheritdoc cref="Base.e032"/>
		North = Points.Y,

		/// <inheritdoc cref="Base.e032"/>
		South = -Points.Y,

		#endregion antipodal 'Points' (TriPlanes) can be distinguished by Sign
	}

	/// <summary> Bits for each non-zero Component of a Multi-Vector </summary>
	/// <remarks>
	/// ## Public Methods
	///
	/// | Line | Method | Description |
	/// |--:|---|---|
	/// | 472 | <see cref="_1_"/> | Represents 1. |
	/// | 482 | <see cref="e0"/> | Represents e0. |
	/// | 485 | <see cref="e1"/> | Represents e1. |
	/// | 488 | <see cref="e2"/> | Represents e2. |
	/// | 491 | <see cref="e01"/> | Represents e01. |
	/// | 502 | <see cref="e20"/> | Represents e20. |
	/// | 505 | <see cref="e12"/> | Represents e12. |
	/// | 508 | <see cref="e012"/> | Represents e012. |
	/// | 511 | <see cref="_0"/> | Represents 0. |
	/// </remarks>
	///
	[DocState(Pass = 2, MTime = "2026-07-07T17:42:05Z", Digest = "e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855", Stale = false, Path = "pga/Pga2Dbl.cs", Since = "2026-10-06")]
	[Facets(Layer = "domain", Status = "stable", Complexity = 1)]
	[Tags("code/enum", "code/projective_geometric_algebra")]
	[System.ComponentModel.Description("Bits for each non-zero Component of a Multi-Vector")]
	[Flags]
	[SuppressMessage("ReSharper", "InconsistentNaming")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public enum Bases
	{
		/// <inheritdoc cref="Base._1_"/>
		_1_ = 1 << Base._1_,

		/// <inheritdoc cref="Base.e0"/>
		/// <example>
		/// <code language="yaml">
		/// pass: 2
		/// mtime: 2026-05-24T16:42:31Z
		/// digest: 4b426c2aa734f94acd6af6865c4f60a186b9a36ae984816b5217485294d5187f
		/// </code>
		/// </example>
		e0 = 1 << Base.e0,

		/// <inheritdoc cref="Base.e1"/>
		e1 = 1 << Base.e1,

		/// <inheritdoc cref="Base.e2"/>
		e2 = 1 << Base.e2,

		/// <inheritdoc cref="Base.e01"/>
		e01 = 1 << Base.e01,

		/// <inheritdoc cref="Base.e20"/>
		/// <example>
		/// <code language="yaml">
		/// pass: 2
		/// mtime: 2026-06-17T10:08:47Z
		/// digest: 9dde2fc92f1c207e6d738ba5f9c0a375cbf79db02154176bbda79bbe0f1e8945
		/// </code>
		/// </example>

		e20 = 1 << Base.e20,

		/// <inheritdoc cref="Base.e12"/>
		e12 = 1 << Base.e12,

		/// <inheritdoc cref="Base.e012"/>
		e012 = 1 << Base.e012,

		/// <inheritdoc cref="Base.e"/>
		_0 = 1 << Base._0,// = sbyte.MinValue
	}

	/// <summary>Gets the components.</summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/projective_geometric_algebra")]
	[System.ComponentModel.Description("Gets the components.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public Bases Components => (Bases) this.GetComponents();

	/// <summary>Maps each component index to its geometric <see cref="Types"/> classification.</summary>
	static readonly Types[] TypeByIndex={ 0 //cos in Rotor, 1 in Motor
		, Types.Distance
		, Types.Motor, Types.Motor, Types.Motor
		, Types.Rotor, Types.Rotor, Types.Rotor
		, Types.Vector, Types.Vector, Types.Vector, Types.Point //non-zero for Points
		, 0};

	/// <summary> Classifies the non-zero components of this multi-vector as a combination of geometric <see cref="Types"/>. </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/projective_geometric_algebra")]
	[System.ComponentModel.Description("Classifies the non-zero components of this multi-vector as a combination of geometric Types.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public Types Type {
		get {
			Types ret = 0; //Typ.All;
			for (int j = _C.Length; --j >= 0;) {
				if (_C[j].IsSmallerThanAbs(PgaTolerance.Double)) {
					continue;
				}

				Types typ = TypeByIndex[j];
				if (typ == 0) {
					continue;
				}

				ret |= typ;
			}

			return ret;
		}
	}

	/// <summary> Geometric type flags classifying which grade components a multi-vector contains. </summary>
	/// <remarks>
	/// ## Public Methods
	///
	/// | Line | Method | Description |
	/// |--:|---|---|
	/// | 580 | <see cref="Scalar"/> | Scale-Factor, used in Combination with Motor and Rotor where it is Cos |
	/// | 586 | <see cref="Distance"/> | Distance of the Plane from the Origin (scaled by the Plane-Coordinates) |
	/// | 590 | <see cref="Rotor"/> | AxisRot are Rotation Axes |
	/// | 593 | <see cref="Motor"/> | AxisTrans are ideal Translation Axes |
	/// | 596 | <see cref="Vector"/> | Pointss can be 'real' or 'ideal' (a Vector |
	/// | 599 | <see cref="Point"/> | Pointss are Vectors with a nonzero Origin Component |
	/// | 602 | <see cref="All"/> | Specifies all values. |
	/// </remarks>
	///
	[DocState(Pass = 2, MTime = "2026-07-07T17:42:05Z", Digest = "9dde2fc92f1c207e6d738ba5f9c0a375cbf79db02154176bbda79bbe0f1e8945", Stale = false, Path = "pga/Pga2Dbl.cs", Since = "2026-10-06")]
	[Facets(Layer = "domain", Status = "stable", Complexity = 1)]
	[Tags("code/enum", "code/projective_geometric_algebra")]
	[System.ComponentModel.Description("Geometric type flags classifying which grade components a multi-vector contains.")]
	[Flags]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public enum Types : byte
	{
		/// <summary> Scale-Factor, used in Combination with <see cref="Motor"/> and <see cref="Rotor"/> where it is Cos </summary>
		Scalar = 0, //1 << 0,

		/// <summary> Distance of the <see cref="Plane"/> from the Origin (scaled by the <see cref="Plane"/>-Coordinates) </summary>
		/// <remarks>
		/// When 0, this is a Plane through the Origin.
		/// </remarks>
		Distance = 1 << 1,

		/// <summary> <see cref="AxisRot"/> are Rotation Axes </summary>
		/// <remarks>Lines are <see cref="Plane"/> Intersections</remarks>
		Rotor = 1 << 3,

		/// <summary> <see cref="AxisTrans"/> are ideal Translation Axes </summary>
		Motor = 1 << 4,

		/// <summary> <see cref="Pga2Dbl.Points"/>s can be 'real' or 'ideal' (a <see cref="Vector"/></summary>
		Vector = 1 << 5,

		/// <summary> <see cref="Pga2Dbl.Points"/>s are <see cref="Vector"/>s with a nonzero <see cref="Points.Origin"/> Component</summary>
		Point = 1 << 6,

		/// <summary>Specifies all values.</summary>
		All = Distance | Vector | Point , //(1 << 7) - 1,

		///// <summary> AKA ideal Points are Vectors, the ideal Plane is the Sky Plane </summary>
		//IsIdeal = 1 << 7,
	}

	#region Cayley Tables for different Products in R3,0,0

	/// <summary>Cayley table encoding the outer (meet/wedge) product of all basis blade pairs.</summary>
	static readonly Base[][] _ProductOuter = {
		new[] {Base._1_, Base.e0, Base.e1, Base.e2, Base.e01, Base.e20, Base.e12, Base.e012},
		new[] {Base.e0, Base._0, Base.e01, ~Base.e20, Base._0, Base._0, Base.e012, Base._0},
		new[] {Base.e1, ~Base.e01, Base._0, Base.e12, Base._0, Base.e012, Base._0, Base._0},
		new[] {Base.e2, Base.e20, ~Base.e12, Base._0, Base.e012, Base._0, Base._0, Base._0},
		new[] {Base.e01, Base._0, Base._0, Base.e012, Base._0, Base._0, Base._0, Base._0},
		new[] {Base.e20, Base._0, Base.e012, Base._0, Base._0, Base._0, Base._0, Base._0},
		new[] {Base.e12, Base.e012, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0},
		new[] {Base.e012, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0},
	};

	/// <summary>Cayley table encoding the full geometric product of all basis blade pairs.</summary>
	static readonly Base[][] _ProductGeometric = {
		new[] {Base._1_, Base.e0, Base.e1, Base.e2, Base.e01, Base.e20, Base.e12, Base.e012},
		new[] {Base.e0, Base._0, Base.e01, ~Base.e20, Base._0, Base._0, Base.e012, Base._0},
		new[] {Base.e1, ~Base.e01, Base._1_, Base.e12, ~Base.e0, Base.e012, Base.e2, Base.e20},
		new[] {Base.e2, Base.e20, ~Base.e12, Base._1_, Base.e012, Base.e0, ~Base.e1, Base.e01},
		new[] {Base.e01, Base._0, Base.e0, Base.e012, Base._0, Base._0, ~Base.e20, Base._0},
		new[] {Base.e20, Base._0, Base.e012, ~Base.e0, Base._0, Base._0, Base.e01, Base._0},
		new[] {Base.e12, Base.e012, ~Base.e2, Base.e1, Base.e20, ~Base.e01, ~Base._1_, ~Base.e0},
		new[] {Base.e012, Base._0, Base.e20, Base.e01, Base._0, Base._0, ~Base.e0, Base._0},
	};

	/// <summary>Cayley table encoding the inner (dot) product of all basis blade pairs.</summary>
	static readonly Base[][] _ProductDot = {
		new[] {Base._1_, Base.e0, Base.e1, Base.e2, Base.e01, Base.e20, Base.e12, Base.e012},
		new[] {Base.e0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0},
		new[] {Base.e1, Base._0, Base._1_, Base._0, ~Base.e0, Base._0, Base.e2, Base.e20},
		new[] {Base.e2, Base._0, Base._0, Base._1_, Base._0, Base.e0, ~Base.e1, Base.e01},
		new[] {Base.e01, Base._0, Base.e0, Base._0, Base._0, Base._0, Base._0, Base._0},
		new[] {Base.e20, Base._0, Base._0, ~Base.e0, Base._0, Base._0, Base._0, Base._0},
		new[] {Base.e12, Base._0, ~Base.e2, Base.e1, Base._0, Base._0, ~Base._1_, ~Base.e0},
		new[] {Base.e012, Base._0, Base.e20, Base.e01, Base._0, Base._0, ~Base.e0, Base._0},
	};

	/// <summary>Public read-only view of the outer product Cayley table <see cref="_ProductOuter"/>.</summary>
	public static readonly IReadOnlyList<IReadOnlyList<Base>> ProductOuter = _ProductOuter;
	/// <summary>Public read-only view of the geometric product Cayley table <see cref="_ProductGeometric"/>.</summary>
	public static readonly IReadOnlyList<IReadOnlyList<Base>> ProductGeometric = _ProductGeometric;
	/// <summary>Public read-only view of the inner product Cayley table <see cref="_ProductDot"/>.</summary>
	public static readonly IReadOnlyList<IReadOnlyList<Base>> ProductDot = _ProductDot;

	/// <summary>Ordered array of all three Cayley tables: geometric, dot, and outer; order must match <see cref="Products"/>.</summary>
	static readonly Base[][][] _Products = { _ProductGeometric, _ProductDot, _ProductOuter};
	/// <summary>Public read-only view of all three product Cayley tables indexed by product type.</summary>
	public static readonly IReadOnlyList<IReadOnlyList<IReadOnlyList<Base>>> Products = _Products;

	#endregion Cayley Tables for different Products in R3,0,0

	/// <summary>Gets or sets the element at the specified <paramref name="index"/>.</summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/projective_geometric_algebra")]
	[System.ComponentModel.Description("Gets or sets the element at the specified index.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public double this[Base idx] => _C[(int) idx];

	/// <summary>Implicitly converts <paramref name="axis"/> to <see cref="Pga2Dbl"/>.<br/>
	/// Implicitly converts <paramref name="axis"/> to <see cref="Pga2Dbl"/>.</summary>
	public static implicit operator Pga2Dbl(AxisTrans axis) => new(1, axis);
	/// <summary>Implicitly converts <paramref name="axis"/> to <see cref="Pga2Dbl"/>.</summary>
	public static implicit operator Pga2Dbl(AxisRot axis) => new(1, axis);
	/// <summary>Implicitly converts <paramref name="axis"/> to <see cref="Pga2Dbl"/>.</summary>
	public static implicit operator Pga2Dbl(Points axis) => new(1, axis);
	/// <summary>Implicitly converts <paramref name="axis"/> to <see cref="Pga2Dbl"/>.</summary>
	public static implicit operator Pga2Dbl(Base axis) => new(1, axis);
	/// <summary>Implicitly converts <paramref name="axis"/> to <see cref="Pga2Dbl"/>.</summary>
	public static implicit operator Pga2Dbl(Geo axis) => new(1, axis);

	/// <summary>Initializes a new instance of <see cref="Pga2Dbl"/> with the specified <paramref name="f"/> and <paramref name="idx"/>.<br/>
	/// Initializes a new instance of <see cref="Pga2Dbl"/> with the specified <paramref name="f"/> and <paramref name="idx"/>.</summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/projective_geometric_algebra")]
	[System.ComponentModel.Description("Initializes a new instance of Pga2Dbl with the specified f and idx. Initializes a new instance of Pga2Dbl with the specified f and idx.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public Pga2Dbl(double f = 0f, int idx = 0) : base(f, idx) { }
	/// <summary>Initializes a new instance of <see cref="Pga2Dbl"/> with the specified <paramref name="values"/>.</summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/projective_geometric_algebra")]
	[System.ComponentModel.Description("Initializes a new instance of Pga2Dbl with the specified values.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public Pga2Dbl(double f = 0f, Geo idx = 0) : base(f, (int) idx) { }
	/// <summary>Initializes a new instance of <see cref="Pga2Dbl"/> with the specified <paramref name="f"/> and <paramref name="idx"/>.</summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/projective_geometric_algebra")]
	[System.ComponentModel.Description("Initializes a new instance of Pga2Dbl with the specified f and idx.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public Pga2Dbl(double f = 0f, Base idx = 0) : base(f, (int) idx) { }
	/// <summary>Initializes a new instance of <see cref="Pga2Dbl"/> with the specified <paramref name="f"/> and <paramref name="idx"/>.</summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/projective_geometric_algebra")]
	[System.ComponentModel.Description("Initializes a new instance of Pga2Dbl with the specified f and idx.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public Pga2Dbl(double f = 0f, Points idx = 0) : base(f, (int) idx) { }
	/// <summary>Initializes a new instance of <see cref="Pga2Dbl"/> with the specified <paramref name="f"/> and <paramref name="idx"/>.</summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/projective_geometric_algebra")]
	[System.ComponentModel.Description("Initializes a new instance of Pga2Dbl with the specified f and idx.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public Pga2Dbl(double f = 0f, Lines idx = 0) : base(f, (int) idx) { }
	/// <summary>Initializes a new instance of <see cref="Pga2Dbl"/> with the specified <paramref name="f"/> and <paramref name="idx"/>.</summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/projective_geometric_algebra")]
	[System.ComponentModel.Description("Initializes a new instance of Pga2Dbl with the specified f and idx.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public Pga2Dbl(double f = 0f, AxisRot idx = 0) : base(f, (int) idx) { }
	/// <summary>Initializes a new instance of <see cref="Pga2Dbl"/> with the specified <paramref name="f"/> and <paramref name="idx"/>.</summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/projective_geometric_algebra")]
	[System.ComponentModel.Description("Initializes a new instance of Pga2Dbl with the specified f and idx.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public Pga2Dbl(double f = 0f, AxisTrans idx = 0) : base(f, (int) idx) { }

	/// <summary>Unchecked private Constructor requires 8 Components<br/>
	/// Initializes a new instance of <see cref="Pga2Dbl"/> with the specified <paramref name="values"/>.</summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/projective_geometric_algebra")]
	[System.ComponentModel.Description("Unchecked private Constructor requires 8 Components Initializes a new instance of Pga2Dbl with the specified values.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	Pga2Dbl(params double[] f) : base(f) { }
	/// <summary>Initializes a new instance of <see cref="Pga2Dbl"/> with the specified <paramref name="values"/>.</summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/projective_geometric_algebra")]
	[System.ComponentModel.Description("Initializes a new instance of Pga2Dbl with the specified values.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public Pga2Dbl(IReadOnlyList<double> values) : base(values) { }

	/// <inheritdoc />
	public override Pga2Dbl Create(IReadOnlyList<double> values) => new(values);
	/// <inheritdoc cref="Create(IReadOnlyList{double})"/>
	public override Pga2Dbl Create(IList<double> values) => new((IReadOnlyList<double>)values);
	/// <inheritdoc />
	protected override Pga2Dbl Create_(double[] values) => new(values);

	/// <summary> Creates a new <see cref="Pga2Dbl"/> from the supplied component array, checking the length. </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/projective_geometric_algebra")]
	[System.ComponentModel.Description("Creates a new Pga2Dbl from the supplied component array, checking the length.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public static Pga2Dbl New(params double[] f) => New((IReadOnlyList<double>) f);
	/// <inheritdoc cref="New(double[])"/>
	public static Pga2Dbl New(IReadOnlyList<double> f) => new(f);

	#region Unary Operators

	/// <inheritdoc cref="XPga2D.Dual8P"/>
	public override Pga2Dbl Dual() => new(_C.Dual8P());
	/// <inheritdoc />
	public override double NormSqr() => _C.NormSqr8P();

	#endregion Unary Operators

	#region Binary Operators

	/// <inheritdoc cref="XPga2D.Times8P"/>
	public override Pga2Dbl Times(IReadOnlyList<double> factor) => new(_C.Times8P(factor));
	/// <inheritdoc />
	public override Pga2Dbl TimesR(IReadOnlyList<double> factor) => new(factor.Times8P(_C));

	/// <inheritdoc cref="XPga2D.Dot8P"/>
	public override Pga2Dbl Dot(IReadOnlyList<double> parallel) => new(_C.Dot8P(parallel));

	/// <inheritdoc cref="XPga2D.Meet8P"/>
	public override Pga2Dbl Meet(IReadOnlyList<double> that) => new(_C.Meet8P(that));
	/// <inheritdoc />
	public override Pga2Dbl MeetR(IReadOnlyList<double> that) => new(that.Meet8P(_C));

	/// <inheritdoc cref="XPga2D.Join8P"/>
	public override Pga2Dbl Join(IReadOnlyList<double> that) => new(_C.Join8P(that));

	#endregion Binary Operators

	/// <summary> normalized Line Equation: y = <see cref="Horizon"/> + x*<see cref="e1"/> </summary>
	/// <remarks>
	/// intersect = <see cref="Horizon"/>
	/// slope = <see cref="e1"/>
	/// </remarks>
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/projective_geometric_algebra")]
	[System.ComponentModel.Description("normalized Line Equation: y = Horizon + x*e1")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public Pga2Dbl NormalLine() => this * (-1 / e2);

	/// <summary> normalized Line Intersect y0 for x = 0 <see cref="Horizon"/> / <see cref="e2"/>. </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/projective_geometric_algebra")]
	[System.ComponentModel.Description("normalized Line Intersect y0 for x = 0 Horizon / e2.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public double Intersect => Horizon / e2;

	/// <summary> normalized Line Slope <see cref="e1"/> / <see cref="e2"/>. </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/projective_geometric_algebra")]
	[System.ComponentModel.Description("normalized Line Slope e1 / e2.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public double Slope => e1 / e2;

	/// <summary> normalized Point Coordinates. </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/projective_geometric_algebra")]
	[System.ComponentModel.Description("normalized Point Coordinates.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public Pga2Dbl NormalPoint() => this * (1 / e12);

	/// <summary>Normalized X point coordinate, computed as the e20 component divided by the e12 (origin) component.</summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/projective_geometric_algebra")]
	[System.ComponentModel.Description("Normalized X point coordinate, computed as the e20 component divided by the e12 (origin) component.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public double X => e20 / e12;
	/// <summary>Normalized Y point coordinate, computed as the e01 component divided by the e12 (origin) component.</summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/projective_geometric_algebra")]
	[System.ComponentModel.Description("Normalized Y point coordinate, computed as the e01 component divided by the e12 (origin) component.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public double Y => e01 / e12;

	#region Static Base Blades

	/// <inheritdoc cref="Base._1_"/>
	public static readonly Pga2Dbl _1_ = Base._1_;

	/// <inheritdoc cref="Base.e0"/>
	public static readonly Pga2Dbl E0 = Base.e0;

	/// <inheritdoc cref="Base.e1"/>
	public static readonly Pga2Dbl E1 = Base.e1;

	/// <inheritdoc cref="Base.e2"/>
	public static readonly Pga2Dbl E2 = Base.e2;

	/// <inheritdoc cref="Base.e01"/>
	public static readonly Pga2Dbl E01 = Base.e01;

	/// <inheritdoc cref="Base.e20"/>
	public static readonly Pga2Dbl E02 = Base.e20;

	/// <inheritdoc cref="Base.e12"/>
	public static readonly Pga2Dbl E12 = Base.e12;

	/// <inheritdoc cref="Base.e012"/>
	public static readonly Pga2Dbl E012 = Base.e012; //e0 ^ e1 ^ e2;

	#endregion Static Base Blades

	/// <inheritdoc cref="Base._1_"/>
	public double Scalar => _C[(int) Base._1_];

	/// <inheritdoc cref="Base.e0"/>
	public double Horizon => _C[(int) Base.e0];

	#region Named Components 
#pragma warning disable IDE1006 // Naming Styles
	// ReSharper disable InconsistentNaming

	/// <inheritdoc cref="Base.e1"/>
	public double e1 => _C[(int) Base.e1];

	/// <inheritdoc cref="Base.e2"/>
	public double e2 => _C[(int) Base.e2];

	/// <inheritdoc cref="Base.e01"/>
	public double e01 => _C[(int) Base.e01];

	/// <inheritdoc cref="Base.e20"/>
	public double e20 => _C[(int) Base.e20];

	/// <inheritdoc cref="Base.e12"/>
	public double e12 => _C[(int) Base.e12];

	/// <inheritdoc cref="Base.e012"/>
	public double e012 => _C[(int) Base.e012];

	/// <inheritdoc cref="Base.e012"/>
	public double i => e012;

	// ReSharper restore InconsistentNaming
#pragma warning restore IDE1006 // Naming Styles
	#endregion Named Components

	/// <inheritdoc />
	protected override double[][] Coefficients() => new[] {
			new[] {_C[0],	  0, +_C[2], +_C[3],	  0,	  0, -_C[6], 	0},
			new[] {_C[1], +_C[0], -_C[4], +_C[5], +_C[2], -_C[3], -_C[7], -_C[6]},
			new[] {_C[2],	  0, +_C[0], -_C[6],	  0,	  0, +_C[3], 	0},
			new[] {_C[3],	  0, +_C[6], +_C[0],	  0,	  0, -_C[2], 	0},
			new[] {_C[4], +_C[2], -_C[1], +_C[7], +_C[0], +_C[6], -_C[5], +_C[3]},
			new[] {_C[5], -_C[3], +_C[7], +_C[1], -_C[6], +_C[0], +_C[4], +_C[2]},
			new[] {_C[6],	  0, +_C[3], -_C[2],	  0,	  0, +_C[0], 	0},
			new[] {_C[7], +_C[6], +_C[5], +_C[4], +_C[3], +_C[2], +_C[1], +_C[0]},
		};
}
