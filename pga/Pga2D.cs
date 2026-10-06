using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using org.SpocWeb.root.array;
using org.SpocWeb.root.interfaces.maths;
using org.SpocWeb.root.maths.pga.ga;
using org.SpocWeb.root.maths.pga.typed;
using org.SpocWeb.root.Attributes;

namespace org.SpocWeb.root.maths.pga;

/// <summary> R201 = 2D+€ PGA (Euclidean Plane-based projective Geometric Algebra) </summary>
/// <remarks>
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
[DocState(Pass = 2, MTime = "2026-05-24T16:42:31Z", Digest = "3dbdb6533328f883e3443d43e515810ac1b4d1e08c029301ee9e2a25dcf259b5", Stale = false, Path = "pga/Pga2D.cs", Since = "2026-10-06")]
[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
[Tags("code/projective_geometric_algebra")]
[System.ComponentModel.Description("R201 = 2D+€ PGA (Euclidean Plane-based projective Geometric Algebra)")]
[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
public class Pga2D : AGeoGebra8<Pga2D>
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
	/// <summary>Gets the basis2.</summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/projective_geometric_algebra")]
	[System.ComponentModel.Description("Gets the basis2.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public IReadOnlyList<string> Basis2 => _Basis2;
	/// <summary>Gets the _ Basis.</summary>
	static readonly string[] _Basis = {""
		, nameof(Lines)+nameof(Lines.Dist), nameof(Lines)+nameof(Lines.X), nameof(Lines)+nameof(Lines.Y)
		, nameof(Points)+nameof(Points.Y), nameof(Points)+nameof(Points.X), nameof(Points)+nameof(Points.O)
		, nameof(E012)};
	/// <summary>Gets the _ Basis2.</summary>
	static readonly string[] _Basis2 = {"", "e0", "e1", "e2", "e01", "e20", "e12", "e012"};

	/// <inheritdoc />
	public override Pga2D Self() => this;

	/// <summary> Static ordered list of all 8 unit basis blades of the algebra. </summary>
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/projective_geometric_algebra")]
	[System.ComponentModel.Description("Static ordered list of all 8 unit basis blades of the algebra.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public static IReadOnlyList<Pga2D> Blades => _Blades;
	/// <summary>Gets the blades.</summary>
	static readonly Pga2D[] _Blades = {Base._1_
		, Lines.Dist, Lines.X, Lines.Y
		, Points.Y, Points.X, Points.O
		, Base.e012 };

	/// <summary> Factory methods for constructing canonical <see cref="Pga2D"/> geometric objects (points and lines). </summary>
	/// <remarks>
	/// ## Public Methods
	///
	/// | Line | Method | Description |
	/// |--:|---|---|
	/// | 141 | <see cref="Point"/> | Point given by Coordinates X and Y |
	/// | 150 | <see cref="PointPolar"/> | Point given by Polar Coordinates directionRad and radius |
	/// | 165 | <see cref="Line"/> | Line given by slope and intersect |
	///
	/// ## Collaborators
	///
	/// | Type | Role |
	/// |---|---|
	/// | <see cref="Pga2D"/> | Returned by a method. |
	/// | <see cref="Vector2"/> | Passed as a parameter. |
	/// </remarks>
	[DocState(Pass = 2, MTime = "2026-06-17T06:07:14Z", Digest = "d4baf63043cef9f9a0fc770ccdc16fefe4aa2badbf91aa44ca337c1f3bbae1a2", Stale = false, Path = "pga/Pga2D.cs", Since = "2026-10-06")]
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/factory", "code/projective_geometric_algebra")]
	[System.ComponentModel.Description("Factory methods for constructing canonical Pga2D geometric objects (points and lines).")]
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
		[Tags("code/factory_method", "code/projective_geometric_algebra")]
		[System.ComponentModel.Description("Point given by Coordinates X and Y")]
		[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
		public static Pga2D Point(double x, double y, double norm = 1) 
			=> new(0, 0, 0, 0, (float) y, (float) x, (float) norm, 0);

		/// <summary> Point given by Polar Coordinates <see cref="directionRad"/> and <see cref="radius"/> </summary>
		///
		[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
		[Tags("code/factory_method", "code/polar_coordinates")]
		[System.ComponentModel.Description("Point given by Polar Coordinates directionRad and radius")]
		[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
		public static Pga2D PointPolar(double directionRad, double radius) {
			var (sin, cos) = directionRad.SinCos();
			return new Pga2D(0, 0, 0, 0, (float) sin, (float) cos, (float) (1 / radius), 0);
		}

		/// <summary> Line given by <paramref name="slope"/> and <paramref name="intersect"/> </summary>
		/// <remarks>
		/// Lines are Grade 1 Vectors and operate as Reflectors
		/// with themselves as Fixed-Points.
		/// All Points with the same normalized Coordinates are equivalent!
		/// </remarks>
		[Facets(Layer = "domain", Status = "stable", Complexity = 1)]
		[Tags("code/factory_method", "code/projective_geometric_algebra")]
		[System.ComponentModel.Description("Line given by slope and intersect")]
		[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
		public static Pga2D Line(double slope, double intersect) 
			=> new(0, (float) intersect, (float) slope, -1, 0, 0, 0, 0);

		/// <summary> Line given by Point and <paramref name="slope"/>/Direction </summary>
		///
		[Facets(Layer = "domain", Status = "stable", Complexity = 1)]
		[Tags("code/factory_method", "code/projective_geometric_algebra")]
		[System.ComponentModel.Description("Line given by Point and slope/Direction")]
		[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
		public static Pga2D Line(double slope, double y, double x) 
			=> Line(slope, y-x*slope);

		/// <summary> Line given by 2 Points </summary>
		///
		[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
		[Tags("code/factory_method", "code/projective_geometric_algebra")]
		[System.ComponentModel.Description("Line given by 2 Points")]
		[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
		public static Pga2D Line(double x0, double y0, double x1, double y1) {
			var slope = (y1 - y0) / (x1 - x0);
			return Line(slope, y0, x0);
		}

		/// <summary> Line given by 2 Points </summary>
		///
		[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
		[Tags("code/factory_method", "code/projective_geometric_algebra")]
		[System.ComponentModel.Description("Line given by 2 Points")]
		[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
		public static Pga2D Line(Vector2 p0, Vector2 p1) {
			var slope = (p1.Y - p0.Y) / (p1.X - p0.X);
			return Line(slope, p0.Y, p0.X);
		}

	}

	/// <summary> BiVectors in projective 2D are Points </summary>
	/// <remarks>
	/// ## Public Methods
	///
	/// | Line | Method | Description |
	/// |--:|---|---|
	/// | 225 | <see cref="O"/> | Represents o. |
	/// | 235 | <see cref="X"/> | Represents x. |
	/// | 238 | <see cref="Y"/> | Represents y. |
	/// | 241 | <see cref="_1_"/> | Represents 1. |
	/// </remarks>
	///
	[DocState(Pass = 2, MTime = "2026-07-07T17:48:22Z", Digest = "e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855", Stale = false, Path = "pga/Pga2D.cs", Since = "2026-10-06")]
	[Facets(Layer = "domain", Status = "stable", Complexity = 1)]
	[Tags("code/enum", "code/projective_geometric_algebra")]
	[System.ComponentModel.Description("BiVectors in projective 2D are Points")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public enum Points : sbyte
	{
		/// <inheritdoc cref="Base.e12"/>
		O = Base.e12,

		/// <inheritdoc cref="Base.e20"/>
		/// <example>
		/// <code language="yaml">
		/// pass: 2
		/// mtime: 2026-06-17T06:07:14Z
		/// digest: 84f9f8b7636304a82bbb0de8bf871e397c9045f27cde590eb0263fb577c4c5a8
		/// </code>
		/// </example>
		X = Base.e20,

		/// <inheritdoc cref="Base.e01"/>
		Y = Base.e01,

		/// <inheritdoc cref="Base._1_"/>
		_1_ = Base._1_,
	}

	/// <summary> Vectors in projective 2D are Lines </summary>
	/// <remarks>
	/// ## Public Methods
	///
	/// | Line | Method | Description |
	/// |--:|---|---|
	/// | 265 | <see cref="Horizon"/> | Represents horizon. |
	/// | 267 | <see cref="Dist"/> | Represents dist. |
	/// | 270 | <see cref="X"/> | Represents x. |
	/// | 273 | <see cref="Y"/> | Represents y. |
	/// | 276 | <see cref="I"/> | Represents i. |
	/// </remarks>
	///
	[DocState(Pass = 2, MTime = "2026-07-07T17:48:22Z", Digest = "84f9f8b7636304a82bbb0de8bf871e397c9045f27cde590eb0263fb577c4c5a8", Stale = false, Path = "pga/Pga2D.cs", Since = "2026-10-06")]
	[Facets(Layer = "domain", Status = "stable", Complexity = 1)]
	[Tags("code/enum", "code/projective_geometric_algebra")]
	[System.ComponentModel.Description("Vectors in projective 2D are Lines")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public enum Lines : sbyte
	{
		/// <inheritdoc cref="Base.e0"/>
		Horizon = Base.e0,
		/// <summary>Represents dist.</summary>
		Dist = Base.e0,

		/// <inheritdoc cref="Base.e1"/>
		X = Base.e1,

		/// <inheritdoc cref="Base.e2"/>
		Y = Base.e2,

		/// <summary>Represents i.</summary>
		I = Base.e12
	}

	/// <summary> Base-Blades in 3D, usable as Indices for Components </summary>
	///
	[DocState(Pass = 2, MTime = "2026-07-07T17:48:22Z", Digest = "7bf53ac29a107a7b351a128bf2cab339e4db73166d5dd075c48ee93ffa9a9203", Stale = false, Path = "pga/Pga2D.cs", Since = "2026-10-06")]
	[Facets(Layer = "domain", Status = "stable", Complexity = 1)]
	[Tags("code/enum", "code/projective_geometric_algebra")]
	[System.ComponentModel.Description("Base-Blades in 3D, usable as Indices for Components")]
	[SuppressMessage("ReSharper", "InconsistentNaming")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public enum Base : sbyte
	{
		/// <summary>[0] Scalar e.g. Dot Product / oriented Area/Volume Dual</summary>
		_1_,

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

		/// <summary>[4] <see cref="Points.Y"/>-Point-Coordinate </summary>
		e01,

		/// <summary>[5] <see cref="Points.X"/>-Point-Coordinate </summary>
		e20,

		/// <summary>[6] O/W/Origin; 1 for Points, 0 for Vectors; Distance of Projection Plane from the Origin </summary>
		/// <remarks>
		/// A Value of 0 lands the Coordinates on the infinite <see cref="Lines.Horizon"/>.
		/// which is a HyperPlane with 1 Dimension less, since the Length loses Significance at Infinity.
		/// </remarks>
		e12,

		/// <summary>[7] <see cref="e012"/>² = 0 </summary>
		e012,

		/// <summary>Represents i.</summary>
		i= e012,

		/// <summary> No Component; signals both the End of Components and 0-Elements in the Cayley Tables below </summary>
		/// <example>
		/// <code language="yaml">
		/// pass: 2
		/// mtime: 2026-06-17T06:07:14Z
		/// digest: a12a148db2763e22b0e805cebc76a7ef23711c7175878098474930b3027a22d1
		/// </code>
		/// </example>
		_0,
	}

	/// <summary> 'Ideal' Axes for <see cref="Make.Translator"/>/<see cref="Make.Motor"/> </summary>
	/// <remarks>
	/// ## Public Methods
	///
	/// | Line | Method | Description |
	/// |--:|---|---|
	/// | 355 | <see cref="Y"/> | Represents y. |
	/// | 358 | <see cref="X"/> | Represents x. |
	/// | 361 | <see cref="_1_"/> | Represents 1. |
	/// </remarks>
	///
	[DocState(Pass = 2, MTime = "2026-07-07T17:48:22Z", Digest = "a12a148db2763e22b0e805cebc76a7ef23711c7175878098474930b3027a22d1", Stale = false, Path = "pga/Pga2D.cs", Since = "2026-10-06")]
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

	/// <summary> euclidean Axes for <see cref="Make.Rotor"/> </summary>
	/// <remarks>
	/// ## Public Methods
	///
	/// | Line | Method | Description |
	/// |--:|---|---|
	/// | 382 | <see cref="Z"/> | Represents z. |
	/// | 385 | <see cref="_1_"/> | Represents 1. |
	/// </remarks>
	///
	[DocState(Pass = 2, MTime = "2026-07-07T17:48:22Z", Digest = "a12a148db2763e22b0e805cebc76a7ef23711c7175878098474930b3027a22d1", Stale = false, Path = "pga/Pga2D.cs", Since = "2026-10-06")]
	[Facets(Layer = "domain", Status = "stable", Complexity = 1)]
	[Tags("code/enum", "code/projective_geometric_algebra")]
	[System.ComponentModel.Description("euclidean Axes for Rotor")]
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
	/// | 412 | <see cref="Horizon"/> | Represents horizon. |
	/// | 415 | <see cref="Origin"/> | current Position of the Observer |
	/// | 425 | <see cref="Longitude"/> | Represents longitude. |
	/// | 428 | <see cref="Latitude"/> | Represents latitude. |
	/// | 433 | <see cref="West"/> | Represents west. |
	/// | 436 | <see cref="East"/> | Represents east. |
	/// | 439 | <see cref="North"/> | Represents north. |
	/// | 442 | <see cref="South"/> | Represents south. |
	/// </remarks>
	///
	[DocState(Pass = 2, MTime = "2026-07-07T17:48:22Z", Digest = "29c9f3a451af85939d573e784c285baa9191ad285ee19927efe6c2601e336a65", Stale = false, Path = "pga/Pga2D.cs", Since = "2026-10-06")]
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
		/// <example>
		/// <code language="yaml">
		/// pass: 2
		/// mtime: 2026-06-17T06:07:14Z
		/// digest: e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855
		/// </code>
		/// </example>
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
	[DocState(Pass = 2, MTime = "2026-05-24T16:42:31Z", Digest = "e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855", Stale = false, Path = "pga/Pga2D.cs", Since = "2026-10-06")]
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
		e0 = 1 << Base.e0,

		/// <inheritdoc cref="Base.e1"/>
		e1 = 1 << Base.e1,

		/// <inheritdoc cref="Base.e2"/>
		e2 = 1 << Base.e2,

		/// <inheritdoc cref="Base.e01"/>
		e01 = 1 << Base.e01,

		/// <inheritdoc cref="Base.e20"/>
		e20 = 1 << Base.e20,

		/// <inheritdoc cref="Base.e12"/>
		/// <example>
		/// <code language="yaml">
		/// pass: 2
		/// mtime: 2026-06-17T06:07:14Z
		/// digest: ef32482bcb087cf925ddce47224a4c1e96e209a559f012636bff778498fb1887
		/// </code>
		/// </example>
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

	/// <summary>Gets the type By Index.</summary>
	static readonly Types[] TypeByIndex={ 0 //cos in Rotor, 1 in Motor 
		, Types.Distance
		, Types.Motor, Types.Motor, Types.Motor
		, Types.Rotor, Types.Rotor, Types.Rotor
		, Types.Vector, Types.Vector, Types.Vector, Types.Point //non-zero for Points
		, 0};

	/// <summary> Returns the geometric type flags describing which grade components of this multivector are non-zero. </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/projective_geometric_algebra")]
	[System.ComponentModel.Description("Returns the geometric type flags describing which grade components of this multivector are non-zero.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public Types Type {
		get {
			Types ret = 0; //Typ.All;
			for (int j = _C.Length; --j >= 0;) {
				if (_C[j].IsSmallerThanAbs(PgaTolerance.Float)) {
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

	/// <summary> Flags classifying which geometric roles a <see cref="Pga2D"/> multivector's nonzero components play. </summary>
	///
	[DocState(Pass = 2, MTime = "2026-07-07T17:48:22Z", Digest = "ef32482bcb087cf925ddce47224a4c1e96e209a559f012636bff778498fb1887", Stale = false, Path = "pga/Pga2D.cs", Since = "2026-10-06")]
	[Facets(Layer = "domain", Status = "stable", Complexity = 1)]
	[Tags("code/enum", "code/projective_geometric_algebra")]
	[System.ComponentModel.Description("Flags classifying which geometric roles a Pga2D multivector's nonzero components play.")]
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

		/// <summary> <see cref="Pga2D.Points"/>s can be 'real' or 'ideal' (a <see cref="Vector"/></summary>
		Vector = 1 << 5,

		/// <summary> <see cref="Pga2D.Points"/>s are <see cref="Vector"/>s with a nonzero <see cref="Points.O"/> Component</summary>
		Point = 1 << 6,

		/// <summary>Specifies all values.</summary>
		All = Distance | Vector | Point , //(1 << 7) - 1,

		///// <summary> AKA ideal Points are Vectors, the ideal Plane is the Sky Plane </summary>
		//IsIdeal = 1 << 7,
	}

	#region Cayley Tables for different Products in R3,0,0

	/// <summary>Gets the _ Product Outer.</summary>
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

	/// <summary>Gets the _ Product Geometric.</summary>
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

	/// <summary>Gets the _ Product Dot.</summary>
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

	/// <summary>Gets the product Outer.<br/>
	/// Gets the product Geometric.</summary>
	public static readonly IReadOnlyList<IReadOnlyList<Base>> ProductOuter = _ProductOuter;
	/// <summary>Gets the product Geometric.</summary>
	public static readonly IReadOnlyList<IReadOnlyList<Base>> ProductGeometric = _ProductGeometric;
	/// <summary>Gets the product Dot.</summary>
	public static readonly IReadOnlyList<IReadOnlyList<Base>> ProductDot = _ProductDot;

	/// <summary>Gets the _ Products.<br/>
	/// Gets the products.</summary>
	static readonly Base[][][] _Products = { _ProductGeometric, _ProductDot, _ProductOuter};
	/// <summary>Gets the products.</summary>
	public static readonly IReadOnlyList<IReadOnlyList<IReadOnlyList<Base>>> Products = _Products;

	#endregion Cayley Tables for different Products in R3,0,0

	/// <summary>Gets or sets the element at the specified <paramref name="index"/>.</summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/projective_geometric_algebra")]
	[System.ComponentModel.Description("Gets or sets the element at the specified index.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public float this[Base idx] => _C[(int) idx];

	/// <summary>Implicitly converts <paramref name="axis"/> to <see cref="Pga2D"/>.<br/>
	/// Implicitly converts <paramref name="axis"/> to <see cref="Pga2D"/>.</summary>
	public static implicit operator Pga2D(AxisTrans axis) => new(1, axis);
	/// <summary>Implicitly converts <paramref name="axis"/> to <see cref="Pga2D"/>.</summary>
	public static implicit operator Pga2D(AxisRot axis) => new(1, axis);
	/// <summary>Implicitly converts <paramref name="axis"/> to <see cref="Pga2D"/>.</summary>
	public static implicit operator Pga2D(Points axis) => new(1, axis);
	/// <summary>Implicitly converts <paramref name="axis"/> to <see cref="Pga2D"/>.</summary>
	public static implicit operator Pga2D(Lines axis) => new(1, axis);
	/// <summary>Implicitly converts <paramref name="axis"/> to <see cref="Pga2D"/>.</summary>
	public static implicit operator Pga2D(Base axis) => new(1, axis);
	/// <summary>Implicitly converts <paramref name="axis"/> to <see cref="Pga2D"/>.</summary>
	public static implicit operator Pga2D(Geo axis) => new(1, axis);

	/// <summary>Initializes a new instance of <see cref="Pga2D"/> with the specified <paramref name="f"/> and <paramref name="idx"/>.<br/>
	/// Initializes a new instance of <see cref="Pga2D"/> with the specified <paramref name="f"/> and <paramref name="idx"/>.</summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/projective_geometric_algebra")]
	[System.ComponentModel.Description("Initializes a new instance of Pga2D with the specified f and idx. Initializes a new instance of Pga2D with the specified f and idx.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public Pga2D(double f = 0f, int idx = 0) : base(f, idx) { }
	/// <summary>Initializes a new instance of <see cref="Pga2D"/> with the specified <paramref name="values"/>.</summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/projective_geometric_algebra")]
	[System.ComponentModel.Description("Initializes a new instance of Pga2D with the specified values.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public Pga2D(double f = 0f, Geo idx = 0) : base(f, (int) idx) { }
	/// <summary>Initializes a new instance of <see cref="Pga2D"/> with the specified <paramref name="f"/> and <paramref name="idx"/>.</summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/projective_geometric_algebra")]
	[System.ComponentModel.Description("Initializes a new instance of Pga2D with the specified f and idx.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public Pga2D(double f = 0f, Base idx = 0) : base(f, (int) idx) { }
	/// <summary>Initializes a new instance of <see cref="Pga2D"/> with the specified <paramref name="f"/> and <paramref name="idx"/>.</summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/projective_geometric_algebra")]
	[System.ComponentModel.Description("Initializes a new instance of Pga2D with the specified f and idx.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public Pga2D(double f = 0f, Points idx = 0) : base(f, (int) idx) { }
	/// <summary>Initializes a new instance of <see cref="Pga2D"/> with the specified <paramref name="f"/> and <paramref name="idx"/>.</summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/projective_geometric_algebra")]
	[System.ComponentModel.Description("Initializes a new instance of Pga2D with the specified f and idx.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public Pga2D(double f = 0f, Lines idx = 0) : base(f, (int) idx) { }
	/// <summary>Initializes a new instance of <see cref="Pga2D"/> with the specified <paramref name="f"/> and <paramref name="idx"/>.</summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/projective_geometric_algebra")]
	[System.ComponentModel.Description("Initializes a new instance of Pga2D with the specified f and idx.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public Pga2D(double f = 0f, AxisRot idx = 0) : base(f, (int) idx) { }
	/// <summary>Initializes a new instance of <see cref="Pga2D"/> with the specified <paramref name="f"/> and <paramref name="idx"/>.</summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/projective_geometric_algebra")]
	[System.ComponentModel.Description("Initializes a new instance of Pga2D with the specified f and idx.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public Pga2D(double f = 0f, AxisTrans idx = 0) : base(f, (int) idx) { }

	/// <summary>Unchecked private Constructor; requires 8 Components!<br/>
	/// Initializes a new instance of <see cref="Pga2D"/> with the specified <paramref name="values"/>.</summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/projective_geometric_algebra")]
	[System.ComponentModel.Description("Unchecked private Constructor; requires 8 Components! Initializes a new instance of Pga2D with the specified values.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	protected internal Pga2D(params float[] f) : base(f) { }
	/// <summary>Initializes a new instance of <see cref="Pga2D"/> with the specified <paramref name="values"/>.</summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/projective_geometric_algebra")]
	[System.ComponentModel.Description("Initializes a new instance of Pga2D with the specified values.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public Pga2D(IReadOnlyList<float> values) : base(values) { }

	/// <inheritdoc />
	public override Pga2D Create(IReadOnlyList<float> values) => new(values);
	/// <inheritdoc cref="Create(IReadOnlyList{float})"/>
	public override Pga2D Create(IList<float> values) => new((IReadOnlyList<float>)values);
	/// <inheritdoc />
	protected override Pga2D Create_(float[] values) => new(values);

	/// <summary> Creates a new <see cref="Pga2D"/> from a raw coordinate array of 8 floats. </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/projective_geometric_algebra")]
	[System.ComponentModel.Description("Creates a new Pga2D from a raw coordinate array of 8 floats.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public static Pga2D New(params float[] f) => New((IReadOnlyList<float>) f);
	/// <inheritdoc cref="New(float[])"/>
	public static Pga2D New(IReadOnlyList<float> f) => new(f);

	#region Unary Operators

	/// <inheritdoc cref="XPga2D.Dual8P(IReadOnlyList{float})"/>
	public override Pga2D Dual() => new(_C.Dual8P());
	/// <inheritdoc />
	public override double NormSqr() => _C.NormSqr8P();

	#endregion Unary Operators

	#region Binary Operators

	/// <inheritdoc cref="XPga2D.Times8P(IReadOnlyList{float},IReadOnlyList{float})"/>
	public override Pga2D Times(IReadOnlyList<float> factor) => new(_C.Times8P(factor));
	/// <inheritdoc />
	public override Pga2D TimesR(IReadOnlyList<float> factor) => new(factor.Times8P(_C));

	/// <inheritdoc cref="XPga2D.Dot8P(IReadOnlyList{float},IReadOnlyList{float})"/>
	public override Pga2D Dot(IReadOnlyList<float> parallel) => new(_C.Dot8P(parallel));

	/// <inheritdoc cref="XPga2D.Meet8P(IReadOnlyList{float},IReadOnlyList{float})"/>
	public override Pga2D Meet(IReadOnlyList<float> that) => new(_C.Meet8P(that));
	/// <inheritdoc />
	public override Pga2D MeetR(IReadOnlyList<float> that) => new(that.Meet8P(_C));

	/// <inheritdoc cref="XPga2D.Join8P(IReadOnlyList{float},IReadOnlyList{float})"/>
	public override Pga2D Join(IReadOnlyList<float> that) => new(_C.Join8P(that));

	#endregion Binary Operators

	/// <summary> normalized Line Equation: y = <see cref="Horizon"/> + x*<see cref="e1"/> </summary>
	/// <remarks>
	/// intersect = <see cref="Horizon"/>/<see cref="e2"/>
	/// slope = <see cref="e1"/>/<see cref="e2"/>
	/// </remarks>
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/projective_geometric_algebra")]
	[System.ComponentModel.Description("normalized Line Equation: y = Horizon + x*e1")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public Pga2D NormalLine() => this * (-1 / e2);

	/// <summary> [1] Line Intersect y0 for x = 0 (normed) <see cref="Horizon"/> / <see cref="e2"/>. </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/projective_geometric_algebra")]
	[System.ComponentModel.Description("[1] Line Intersect y0 for x = 0 (normed) Horizon / e2.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public float Intersect => Horizon / e2;

	/// <summary> normalized Line Slope <see cref="e1"/> / <see cref="e2"/>. </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/projective_geometric_algebra")]
	[System.ComponentModel.Description("normalized Line Slope e1 / e2.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public float Slope => e1 / e2;

	/// <summary> normalized Point Coordinates. </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/projective_geometric_algebra")]
	[System.ComponentModel.Description("normalized Point Coordinates.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public Pga2D NormalPoint() => this * (1 / e12);

	/// <summary> [5] x Point Coordinate (normed) </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/projective_geometric_algebra")]
	[System.ComponentModel.Description("[5] x Point Coordinate (normed)")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public float X => e20 / e12;

	/// <summary> [4] y Point Coordinate (normed) </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/projective_geometric_algebra")]
	[System.ComponentModel.Description("[4] y Point Coordinate (normed)")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public float Y => e01 / e12;

	#region Static Base Blades

	/// <inheritdoc cref="Base._1_"/>
	public static readonly Pga2D _1_ = Base._1_;

	/// <inheritdoc cref="Base.e0"/>
	public static readonly Pga2D E0 = Base.e0;

	/// <inheritdoc cref="Base.e1"/>
	public static readonly Pga2D E1 = Base.e1;

	/// <inheritdoc cref="Base.e2"/>
	public static readonly Pga2D E2 = Base.e2;

	/// <inheritdoc cref="Base.e01"/>
	public static readonly Pga2D E01 = Base.e01;

	/// <inheritdoc cref="Base.e20"/>
	public static readonly Pga2D E02 = Base.e20;

	/// <inheritdoc cref="Base.e12"/>
	public static readonly Pga2D E12 = Base.e12;

	/// <inheritdoc cref="Base.e012"/>
	public static readonly Pga2D E012 = Base.e012; //e0 ^ e1 ^ e2;

	#endregion Static Base Blades

	/// <inheritdoc cref="Base._1_"/>
	public float Scalar => _C[(int) Base._1_];

	/// <inheritdoc cref="Base.e0"/>
	public float Horizon => _C[(int) Base.e0];

	#region Named Components 
#pragma warning disable IDE1006 // Naming Styles
	// ReSharper disable InconsistentNaming

	/// <inheritdoc cref="Base.e1"/>
	public float e1 => _C[(int) Base.e1];

	/// <inheritdoc cref="Base.e2"/>
	public float e2 => _C[(int) Base.e2];

	/// <inheritdoc cref="Base.e01"/>
	public float e01 => _C[(int) Base.e01];

	/// <inheritdoc cref="Base.e20"/>
	public float e20 => _C[(int) Base.e20];

	/// <inheritdoc cref="Base.e12"/>
	public float e12 => _C[(int) Base.e12];

	/// <inheritdoc cref="Base.e012"/>
	public float e012 => _C[(int) Base.e012];

	/// <inheritdoc cref="Base.e012"/>
	public float i => e012;

	// ReSharper restore InconsistentNaming
#pragma warning restore IDE1006 // Naming Styles
	#endregion Named Components

	/// <inheritdoc />
	protected override double[][] Coefficients() {
		var m = new[] {
			new double[] {_C[0],	  0, +_C[2], +_C[3],	  0,	  0, -_C[6], 	0},
			new double[] {_C[1], +_C[0], -_C[4], +_C[5], +_C[2], -_C[3], -_C[7], -_C[6]},
			new double[] {_C[2],	  0, +_C[0], -_C[6],	  0,	  0, +_C[3], 	0},
			new double[] {_C[3],	  0, +_C[6], +_C[0],	  0,	  0, -_C[2], 	0},
			new double[] {_C[4], +_C[2], -_C[1], +_C[7], +_C[0], +_C[6], -_C[5], +_C[3]},
			new double[] {_C[5], -_C[3], +_C[7], +_C[1], -_C[6], +_C[0], +_C[4], +_C[2]},
			new double[] {_C[6],	  0, +_C[3], -_C[2],	  0,	  0, +_C[0], 	0},
			new double[] {_C[7], +_C[6], +_C[5], +_C[4], +_C[3], +_C[2], +_C[1], +_C[0]},
		};
		return m;
	}

}
