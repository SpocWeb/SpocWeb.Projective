using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using NUnit.Framework;
using org.SpocWeb.root.array;
using org.SpocWeb.root.interfaces.maths;
using org.SpocWeb.root.interfaces.Vectors;
using org.SpocWeb.root.logging;
using org.SpocWeb.root.maths.pga.ga;
using org.SpocWeb.root.maths.pga.typed;

namespace org.SpocWeb.root.maths.pga;

// ReSharper disable once InconsistentNaming
/// <summary> Extension Methods and Tests for <see cref="Pga3D"/>. </summary>
/// <remarks>
/// ## Public Methods
///
/// | Line | Method | Description |
/// |--:|---|---|
/// | 28 | <see cref="V"/> | Converts the Base enum value axis to a Pga3D unit blade. |
/// | 41 | <see cref="AsBlade"/> | Wraps blade and value into a typed Base pair. |
/// | 52 | <see cref="TestComponents"/> | Test Components. |
/// | 74 | <see cref="TestMake"/> | Test Make. |
/// | 132 | <see cref="TestPrimitives"/> | Test Primitives. |
/// | 209 | <see cref="Test"/> | Test. |
///
/// ## Collaborators
///
/// | Type | Role |
/// |---|---|
/// | <see cref="Pga3D"/> | Returned by a method. |
/// | <see cref="Base"/> | Passed as a parameter. |
/// | <see cref="AxisTrans"/> | Passed as a parameter. |
/// | <see cref="AxisRot"/> | Passed as a parameter. |
/// | <see cref="Geo"/> | Passed as a parameter. |
/// | <see cref="Planes"/> | Passed as a parameter. |
/// | <see cref="Points"/> | Passed as a parameter. |
/// | <see cref="Bases"/> | Returned by a method. |
/// </remarks>
///
/// <example>
/// <code language="yaml">
/// pass: 2
/// mtime: 2026-05-24T16:03:01Z
/// digest: 9bd9ca078c68d5feefcaa36b0d6176d45138f13cb3f5422ce9c79f070ff5655d
/// tags: [code/extension_method, code/projective_geometric_algebra]
/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
/// facets: {layer: domain, status: stable, complexity: 2}
/// </code>
/// </example>
public static partial class XPga3D
{
	/// <summary> Converts the <see cref="Pga3D.Base"/> enum value <paramref name="axis"/> to a <see cref="Pga3D"/> unit blade. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/extension_method, code/implicit_conversion, code/projective_geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 1}
	/// </code>
	/// </example>
	public static Pga3D V(this Pga3D.Base axis) => axis;
	/// <inheritdoc cref="V(Pga3D.Base)"/>
	public static Pga3D V(this Pga3D.AxisTrans axis) => axis;
	/// <inheritdoc cref="V(Pga3D.Base)"/>
	public static Pga3D V(this Pga3D.AxisRot axis) => axis;
	/// <inheritdoc cref="V(Pga3D.Base)"/>
	public static Pga3D V(this Pga3D.Geo axis) => axis;
	/// <inheritdoc cref="V(Pga3D.Base)"/>
	public static Pga3D V(this Pga3D.Planes plane) => plane;
	/// <inheritdoc cref="V(Pga3D.Base)"/>
	public static Pga3D V(this Pga3D.Points point) => point;

	/// <summary> Wraps <paramref name="blade"/> and <paramref name="value"/> into a typed <see cref="Base{T}"/> pair. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/extension_method, code/factory, code/projective_geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 1}
	/// </code>
	/// </example>
	public static Base<Pga3D.Base> AsBlade(this Pga3D.Base blade, double value = 1) => new(value, blade);
	/// <inheritdoc cref="AsBlade(Pga3D.Base,double)"/>
	public static Base<Pga3D.Points> AsBlade(this Pga3D.Points blade, double value = 1) => new(value, blade);
	/// <inheritdoc cref="AsBlade(Pga3D.Base,double)"/>
	public static Base<Pga3D.Planes> AsBlade(this Pga3D.Planes blade, double value = 1) => new(value, blade);
	/// <inheritdoc cref="AsBlade(Pga3D.Base,double)"/>
	public static Base<Pga3D.AxisTrans> AsBlade(this Pga3D.AxisTrans blade, double value = 1) => new(value, blade);
	/// <inheritdoc cref="AsBlade(Pga3D.Base,double)"/>
	public static Base<Pga3D.AxisRot> AsBlade(this Pga3D.AxisRot blade, double value = 1) => new(value, blade);

	/// <summary>Test Components.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/unit_test, code/projective_geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: test, status: stable, complexity: 1}
	/// </code>
	/// </example>
	[TestCase(Pga3D.Base._1_, ExpectedResult = Pga3D.Bases._1_)]
	[TestCase(Pga3D.Base.e0, ExpectedResult = Pga3D.Bases.e0)]
	[TestCase(Pga3D.Base.e01, ExpectedResult = Pga3D.Bases.e01)]
	[TestCase(Pga3D.Base.e0123, ExpectedResult = Pga3D.Bases.e0123)]
	[TestCase(Pga3D.Base.e013, ExpectedResult = Pga3D.Bases.e013)]
	[TestCase(Pga3D.Base.e02, ExpectedResult = Pga3D.Bases.e02)]
	[TestCase(Pga3D.Base.e021, ExpectedResult = Pga3D.Bases.e021)]
	[TestCase(Pga3D.Base.e03, ExpectedResult = Pga3D.Bases.e03)]
	[TestCase(Pga3D.Base.e032, ExpectedResult = Pga3D.Bases.e032)]
	[TestCase(Pga3D.Base.e1, ExpectedResult = Pga3D.Bases.e1)]
	[TestCase(Pga3D.Base.e12, ExpectedResult = Pga3D.Bases.e12)]
	[TestCase(Pga3D.Base.e123, ExpectedResult = Pga3D.Bases.e123)]
	[TestCase(Pga3D.Base.e23, ExpectedResult = Pga3D.Bases.e23)]
	[TestCase(Pga3D.Base.e2, ExpectedResult = Pga3D.Bases.e2)]
	[TestCase(Pga3D.Base.e3, ExpectedResult = Pga3D.Bases.e3)]
	[TestCase(Pga3D.Base.e31, ExpectedResult = Pga3D.Bases.e31)]
	public static Pga3D.Bases TestComponents(Pga3D.Base b) {
		var p = b.AsPga3D();
		return p.Components;
	}

	/// <summary>Test Make.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/unit_test, code/projective_geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: test, status: stable, complexity: 2}
	/// </code>
	/// </example>
	[Test]
	public static void TestMake()
	{
		var point = Pga3D.Make.Point(2,3,4,5);
		_ = point.Type.ShouldBe(Pga3D.Types.Vector | Pga3D.Types.Point);

		var rotor = Pga3D.Make.Rotor(2,3,4,5);
		_ = rotor.Type.ShouldBe(Pga3D.Types.Rotor);

		var motor = Pga3D.Make.Motor(3,4,5);
		_ = motor.Type.ShouldBe(Pga3D.Types.Motor);

		var plane = Pga3D.Make.Plane(3,4,5,6);
		_ = plane.Type.ShouldBe(Pga3D.Types.Plane | Pga3D.Types.Distance);

		var vector = Pga3D.Make.Vector(4,5,6);
		_ = vector.Type.ShouldBe(Pga3D.Types.Vector);

		_ = Pga3D.Planes.Dist.V().Type.ShouldBe(Pga3D.Types.Distance);
		_ = Pga3D.Planes.XY.V().Type.ShouldBe(Pga3D.Types.Plane);
		_ = Pga3D.Planes.YZ.V().Type.ShouldBe(Pga3D.Types.Plane);
		_ = Pga3D.Planes.ZX.V().Type.ShouldBe(Pga3D.Types.Plane);

		_ = Pga3D.Points.X.V().Type.ShouldBe(Pga3D.Types.Vector);
		_ = Pga3D.Points.Y.V().Type.ShouldBe(Pga3D.Types.Vector);
		_ = Pga3D.Points.Z.V().Type.ShouldBe(Pga3D.Types.Vector);

		_ = Pga3D.Points.Dist.V().Type.ShouldBe(Pga3D.Types.Point);
		_ = Pga3D.Points.Origin.V().Type.ShouldBe(Pga3D.Types.Point);

		_ = Pga3D.Geo.Origin.V().Type.ShouldBe(Pga3D.Types.Point);

		_ = Pga3D.Geo.East.V().Type.ShouldBe(Pga3D.Types.Vector);
		_ = Pga3D.Geo.Nadir.V().Type.ShouldBe(Pga3D.Types.Vector);
		_ = Pga3D.Geo.North.V().Type.ShouldBe(Pga3D.Types.Vector);
		_ = Pga3D.Geo.South.V().Type.ShouldBe(Pga3D.Types.Vector);
		_ = Pga3D.Geo.West.V().Type.ShouldBe(Pga3D.Types.Vector);

		_ = Pga3D.Geo.Sky.V().Type.ShouldBe(Pga3D.Types.Distance);

		_ = Pga3D.Geo.Meridian.V().Type.ShouldBe(Pga3D.Types.Motor);
		_ = Pga3D.Geo.PrimeVertical.V().Type.ShouldBe(Pga3D.Types.Motor);
		_ = Pga3D.Geo.Horizon.V().Type.ShouldBe(Pga3D.Types.Motor);

		_ = Pga3D.AxisTrans.X.V().Type.ShouldBe(Pga3D.Types.Motor);
		_ = Pga3D.AxisTrans.Y.V().Type.ShouldBe(Pga3D.Types.Motor);
		_ = Pga3D.AxisTrans.Z.V().Type.ShouldBe(Pga3D.Types.Motor);

		_ = Pga3D.AxisRot.X.V().Type.ShouldBe(Pga3D.Types.Rotor);
		_ = Pga3D.AxisRot.Y.V().Type.ShouldBe(Pga3D.Types.Rotor);
		_ = Pga3D.AxisRot.Z.V().Type.ShouldBe(Pga3D.Types.Rotor);

		_ = Pga3D.AxisRot._1_.V().Type.ShouldBe((Pga3D.Types)0);
		_ = Pga3D.AxisTrans._1_.V().Type.ShouldBe((Pga3D.Types)0);

	}

	/// <summary>Test Primitives.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/unit_test, code/projective_geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: test, status: stable, complexity: 3}
	/// </code>
	/// </example>
	[Test]
	public static void TestPrimitives() {
		//var dt = new DateTime(1970,1,1,0,0,0, DateTimeKind.Utc).AddSeconds(1516057200);

		// Elements of the even sub-algebra (scalar + biVector + pss) of unit length are motors
		Pga3D axisZ = (Pga3D)Pga3D.Planes.YZ * (Pga3D)Pga3D.Planes.ZX;
		_ = axisZ.ShouldBe(new Pga3D(1, Pga3D.AxisRot.Z));

		var axisZNorm = axisZ.NormSqr(); _ = axisZNorm.ShouldBe(1);

		var rotor = Pga3D.Make.Rotor(Math.PI / 2, axisZ);
		var rotor2 = Pga3D.Make.Rotor(Math.PI / 2, 0,0,3);
		_ = rotor2.ShouldBe(rotor);

		var motorX = Pga3D.Make.Motor(2, Pga3D.AxisTrans.X);
		var motorY = Pga3D.Make.Motor(3, Pga3D.AxisTrans.Y);
		var motorZ = Pga3D.Make.Motor(4, Pga3D.AxisTrans.Z);
		var motorXYZ = Pga3D.Make.Motor(1,1.5,2);

		MakeMotor(Pga3D.AxisTrans.X, 2.0);

		var motorXNorm = motorX.NormSqr(); _ = motorXNorm.ShouldBe(1);
		var motorYNorm = motorY.NormSqr(); _ = motorYNorm.ShouldBe(1);
		var motorZNorm = motorZ.NormSqr(); _ = motorZNorm.ShouldBe(1);
		var motorXyzNorm = motorXYZ.NormSqr(); _ = motorXyzNorm.ShouldBe(1);
		
		// The outer product ^ is the MEET. Here we intersect the yz (x=0) and xz (y=0) planes.
		var axZ = (Pga3D)Pga3D.Planes.YZ ^ (Pga3D)Pga3D.Planes.ZX;
		_ = axZ.ShouldBe(Pga3D.AxisRot.Z);

		// line and plane meet in point. We intersect the line along the z-axis (x=0,y=0) with the xy (z=0) plane.
		Pga3D origin = axZ ^ (Pga3D)Pga3D.Planes.XY;
		_ = origin.ShouldBe(Pga3D.Points.Origin);
		var originNorm = origin.NormSqr(); _ = originNorm.ShouldBe(-1);

		// We can also easily create points and join them into a line using the regressive (vee, &) product.
		var pointX = Pga3D.Make.Point(1,0);
		var line = origin & pointX;
		
		// Lets also create the plane parallel to Y with equation 2x + z - 3 = 0
		var plane = Pga3D.Make.Plane(2,0,1,-3);
		var planeNorm = plane.NormSqr(); _ = planeNorm.ShouldBe(-5);
		
		// rotations work on all elements
		var rotatedPlane = rotor * plane * ~rotor;
		var rotatedLine  = rotor * line * ~rotor;
		var rotatedPoint = rotor * pointX * ~rotor;

		var movedPoint = pointX;
		movedPoint = movedPoint > motorY;
		movedPoint = ~motorZ * movedPoint * motorZ;
		movedPoint = ~motorX * movedPoint * motorX;
		
		var movedPoint2 = motorXYZ<pointX;
		_ = movedPoint2.ShouldBe(movedPoint);
		_ = movedPoint2.ShouldBe(Pga3D.Make.Point(3, 3, 4));
		var restoredPoint = ~motorXYZ < movedPoint2;
		_ = restoredPoint.ShouldBe(pointX);

		// See the 3D PGA Cheat sheet for a huge collection of useful formulas
		var pointOnPlane = (plane | pointX) * plane;

		// Some output
		_ = pointX.ToString("*").ShouldBe("1*X + 1*Origin");
		_ = line.ToString("*").ShouldBe("1*AxisRotX");
		_ = plane.ToString("*").ShouldBe("-3*PlanesDist + 2*PlanesYZ + 1*PlanesXY");
		_ = rotor.ToString("*").ShouldBe("0.70711 + 0.70711*AxisRotZ");
		_ = rotatedLine.ToString("*").ShouldBe("-1*AxisRotY");
		_ = rotatedPoint.ToString("*").ShouldBe("-1*Y + 1*Origin");
		_ = movedPoint.ToString("*").ShouldBe("4*Z + 3*Y + 3*X + 1*Origin");
		_ = rotatedPlane.ToString("*").ShouldBe("-3*PlanesDist + -2*PlanesZX + 1*PlanesXY");
		var normalized = pointOnPlane.Normalized();
		_ = normalized.Normalized().ToString("*").ShouldBe("0.2*Z + 1.4*X + 1*Origin");
		_ = Point_on_torus(0, 0).ToString("*").ShouldBe("-0.85*X + 1*Origin");
	}

	/// <summary>Test.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/unit_test, code/projective_geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: test, status: stable, complexity: 2}
	/// </code>
	/// </example>
	[Test]
	public static void Test() {
		var xz = Pga3D.Make.Plane(0, 1,0, 0);
		var yz = Pga3D.Make.Plane(1, 0, 0, 0);
		var z = -xz.Meet(yz);
		_ = z.ShouldBe(Pga3D.AxisRot.Z);

		var o0 = Pga3D.Make.Point(0, 0);
		var z1 = Pga3D.Make.Point(0, 0, 1);
		var z2 = -o0.Join(z1);
		_ = z2.ShouldBe(Pga3D.AxisRot.Z);

		var rotor = Pga3D.Make.Rotor(Math.PI / 4, z);
		var dbl = rotor.Times(rotor);
		Pga3D expected1 = Pga3D.Make.Rotor(Math.PI / 2, z);
		_ = dbl.ShouldBe(expected1);

		var start = Pga3D.Make.Point(3, 4);
		var trans = Pga3D.Make.Translator(4, 3);
		var moved = start > trans;
		_ = moved.ShouldBe(Pga3D.Make.Point(11, 10));
		var moved2 = start.Times(trans);
		moved2 *= trans; //Translations commute!
		_ = moved.ShouldBe(Pga3D.Make.Point(11, 10));
		moved2 *= trans;
		_ = moved.ShouldBe(Pga3D.Make.Point(11, 10));

		var turned = moved.Times(dbl);
		var expected = Pga3D.Make.Point(-7, 7);
		turned.ShouldBe(expected.CloseTo);
	}

}

/// <summary> R301 = 3D+€ PGA (Euclidean Plane-Based Geometric Algebra) </summary>
///
/// <example>
/// <code language="yaml">
/// pass: 2
/// mtime: 2026-05-24T16:03:01Z
/// digest: cf9218219207f1fe6ea6b1955c17c06b81e59a06fa84a3c4194bca7af267e79e
/// tags: [code/projective_geometric_algebra]
/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
/// facets: {layer: domain, status: partial, complexity: 2}
/// </code>
/// </example>
/// <remarks>
/// <see cref="pga.PGA3D"/>
/// 
/// PGA is plane/Mirror-based: Vectors are Planes, BiPlanes are Lines, TriPlanes are Points.
/// PGA extends R³ by a homogeneous w-Dimension <see cref="Base.e0"/> with e0² = 0
/// representing the Sphere at Infinity; the Dual to the Origin for Point Coordinates.
///
/// (w,x,y,z)*(e0,e1,e2,e3) are the Coordinates.
/// 
/// 2^4 = 16 Coefficients to represent most simple geometric Objects and Transformations in 3D.
///
/// This can be refactored into 4 <see cref="Vector4D"/> structs or better:
/// dedicated Vector(<see cref="e032"/>..<see cref="e021"/>),
/// Point(<see cref="e123"/>..<see cref="e021"/>),
/// Rotor(<see cref="e23"/><see cref="e31"/>, <see cref="e12"/> and <see cref="s"/>),
/// Motor(<see cref="e01"/><see cref="e02"/>, <see cref="e03"/> and <see cref="e0123"/>),
/// and Plane(<see cref="e0"/>..<see cref="e3"/>)Structs.
/// 
/// This groups Fields together,
/// avoids duplicate Heap Allocation for Array and this Structure
/// and allows for dedicated Methods with statically typed Results.
/// 
/// PGA is an algebra in which the 1-Vectors represent Euclidean planes(!),
/// and it describes Euclidean Transformations as Reflections.
/// <a href='http://projectivegeometricalgebra.org/wiki'>describes it </a>
/// 
/// It is a subalgebra of CGA/<see cref="R410"/> which has more Operations. 
/// In CGA, there are two null vectors, and they combine to make the pseudo-scalar invertible.
/// In PGA, with only one null vector e0=€, the pseudo-scalar is a null blade, and not invertible.
/// Has Vectors, Quaternions and duals as Sub-Algebras.
/// <a href='https://BiVector.net/'></a>
///
/// All Motors/Rotors/Spinors/Versors are represented as continuous Transformation(t) = exp(t*Invariant)
/// with the Invariant not changed by the Transformation can be a Point (Rotation)
/// , Line (Translation) or Screw ().
///
/// R{3,0,1}* is known as 3D Euclidean Projective Geometric Algebra.
/// It has:
/// 3 positive Metrics (x,y,z with x²=y²=z² = 1)
/// 0 negative Metrics (unlike ict in relativistic Coordinates with (ict)² = -1) and
/// 1 zero Metric (homogeneous Coordinate with €² = 0)
/// Elements represent planes (vectors), lines (biVectors), points (triVectors).
/// 
/// The even sub-algebra is isomorphic to the dual quaternions and includes all isometries
/// (metric preserving translations and rotations) in 3D.
/// 
/// So it pays off to extract this Sub-Algebra into a Group of Transformations.
/// </remarks>
public class Pga3D : AGeoGebra16<Pga3D>
{
	/// <summary> just for debug and print output, the basis names </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/projective_geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: partial, complexity: 2}
	/// </code>
	/// </example>
	public override IReadOnlyList<string> Basis => _Basis;

	/// <summary>Ordered array of basis blade name strings for debug and print output.</summary>
	static readonly IReadOnlyList<string> _Basis = new[] {"" //1 Scalar
		, nameof(Planes)+nameof(Planes.Dist) //Sphere) // Sphere/Plane at Infinity
		, nameof(Planes)+nameof(Planes.YZ), nameof(Planes)+nameof(Planes.ZX), nameof(Planes)+nameof(Planes.XY) //4 Plane-Vectors, and 3 at the Origin
		, nameof(AxisTrans)+nameof(AxisTrans.X), nameof(AxisTrans)+nameof(AxisTrans.Y), nameof(AxisTrans)+nameof(AxisTrans.Z) //3 Circles on the Sphere at Infinity
		, nameof(AxisRot)+nameof(AxisRot.Z), nameof(AxisRot)+nameof(AxisRot.Y), nameof(AxisRot)+nameof(AxisRot.X) //3 BiPlanes/Axis-Lines 
		, nameof(Points.Z), nameof(Points.Y), nameof(Points.X), nameof(Points.Origin) //4 Point-Coordinates / Dual Pseudo-Vectors
		, nameof(E0123)}; //1 Dual Pseudo-Scalar

	/// <inheritdoc />
	public override Pga3D Self() => this;

	/// <summary>Alternative basis blade name strings using canonical e-notation for debug output.</summary>
	public static readonly IReadOnlyList<string> Basis2 = new[] {"" //1 Scalar
		, "e0" // Sphere/Plane at Infinity
		, "e1", "e2", "e3" //4 Plane-Vectors, and 3 at the Origin
		, "e01", "e02", "e03" //3 Circles on the Sphere at Infinity, for Translation
		, "e12", "e31", "e23" //3 BiPlanes/Axis-Lines, for Rotation 
		, "e021", "e013", "e032", "e123" //4 Point-Coordinates / Dual Pseudo-Vectors
		, "e0123"}; //1 Dual Pseudo-Scalar

	/// <summary>Maps each component index to its geometric <see cref="Types"/> classification.</summary>
	static readonly Types[] TypeByIndex={ 0 //Scalar, cos in Rotor, 1 in Motor
			, Types.Distance //Offset from Origin
			, Types.Plane, Types.Plane, Types.Plane
			, Types.Motor, Types.Motor, Types.Motor
			, Types.Rotor, Types.Rotor, Types.Rotor
			, Types.Vector, Types.Vector, Types.Vector
			, Types.Point //non-zero for Points
			, 0};

	/// <summary> Bits for each non-zero Component of a Multi-Vector </summary>
	/// <example>
	/// <code language="yaml">
	/// pass: 2
	/// mtime: 2026-06-17T10:09:57Z
	/// digest: e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855
	/// tags: [code/enum, code/projective_geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 1}
	/// </code>
	/// </example>
	[Flags]
	[SuppressMessage("ReSharper", "InconsistentNaming")]
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

		/// <inheritdoc cref="Base.e3"/>
		e3 = 1 << Base.e3,

		/// <inheritdoc cref="Base.e01"/>
		e01 = 1 << Base.e01,

		/// <inheritdoc cref="Base.e02"/>
		e02 = 1 << Base.e02,

		/// <inheritdoc cref="Base.e03"/>
		e03 = 1 << Base.e03,

		/// <inheritdoc cref="Base.e12"/>
		e12 = 1 << Base.e12,

		/// <inheritdoc cref="Base.e31"/>
		e31 = 1 << Base.e31,

		/// <inheritdoc cref="Base.e23"/>
		e23 = 1 << Base.e23,

		/// <inheritdoc cref="Base.e021"/>
		e021 = 1 << Base.e021,

		/// <inheritdoc cref="Base.e013"/>
		e013 = 1 << Base.e013,

		/// <inheritdoc cref="Base.e032"/>
		e032 = 1 << Base.e032,

		/// <inheritdoc cref="Base.e123"/>
		e123 = 1 << Base.e123,

		/// <inheritdoc cref="Base.e0123"/>
		/// <example>
		/// <code language="yaml">
		/// pass: 2
		/// mtime: 2026-05-24T16:03:01Z
		/// digest: 06f85fecffe6d46b48398a8a9975cbfc11a68e0f5ef9587eebe204ed66116b98
		/// </code>
		/// </example>
		e0123 = 1 << Base.e0123,

		/// <inheritdoc cref="Base._0"/>
		_0 = 1 << Base._0,// = sbyte.MinValue
	}

	/// <summary>Gets the components.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/projective_geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: partial, complexity: 2}
	/// </code>
	/// </example>
	public Bases Components => (Bases) this.GetComponents();

	/// <summary> Classifies the non-zero components of this multi-vector as a combination of geometric <see cref="Types"/>. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/projective_geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: partial, complexity: 2}
	/// </code>
	/// </example>
	public Types Type {
		get {
			Types ret = 0; //Typ.All;
			for (int i = _C.Length; --i >= 0;) {
				if (_C[i].IsSmallerThanAbs(PgaTolerance.Float)) {
					continue;
				}

				Types typ = TypeByIndex[i];
				if (typ == 0) {
					continue;
				}

				ret |= typ;
			}

			return ret;
		}
	}

	/// <summary> <see cref="Components"/> Types </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// pass: 2
	/// mtime: 2026-07-07T17:42:06Z
	/// digest: 43f079111c5074cb136e7ba4735b701c7d2017de7aa8b2aad15aa393767bfdca
	/// tags: [code/enum, code/projective_geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 1}
	/// </code>
	/// </example>
	[Flags]
	public enum Types : byte
	{
		/// <summary> Scale-Factor, used in Combination with <see cref="Motor"/> and <see cref="Rotor"/> where it is Cos </summary>
		Scalar = 0, //1 << 0,

		/// <summary> Distance of the <see cref="Plane"/> from the Origin (scaled by the <see cref="Plane"/>-Coordinates) </summary>
		/// <remarks>
		/// When 0, this is a Plane through the Origin.
		/// </remarks>
		Distance = 1 << 1,

		/// <summary> <see cref="Planes"/>s are 1st Grade Elements in PGA</summary>
		/// <remarks>Without <see cref="Distance"/> these Planes go though the Origin. </remarks>
		Plane = 1 << 2,

		/// <summary> <see cref="AxisRot"/> are Rotation Axes </summary>
		///
		/// <example>
		/// <code language="yaml">
		/// pass: 2
		/// mtime: 2026-05-24T16:03:01Z
		/// digest: b2ec1585819fd0907ff1fcedb44d40be5aa8d5e206277c23c233ff75bfeed55d
		/// </code>
		/// </example>
		/// <remarks>Lines are <see cref="Plane"/> Intersections</remarks>
		Rotor = 1 << 3,

		/// <summary> <see cref="AxisTrans"/> are ideal Translation Axes </summary>
		Motor = 1 << 4,

		/// <summary> A <see cref="Rotor"/> combined with a <see cref="Motor"/> component; represents a projective line. </summary>
		Line = Rotor | Motor,

		/// <summary> <see cref="Points"/>s can be 'real' or 'ideal' (a <see cref="Vector"/></summary>
		Vector = 1 << 5,

		/// <summary> <see cref="Points"/>s are <see cref="Vector"/>s with a nonzero <see cref="Points.Origin"/> Component</summary>
		Point = 1 << 6,

		/// <summary>Specifies all values.</summary>
		///
		/// <example>
		/// <code language="yaml">
		/// pass: 2
		/// mtime: 2026-06-17T10:09:57Z
		/// digest: 32461ee12dc3117eaee82530606e3c9102ea18fb57601701c2bfbba6fe431bde
		/// </code>
		/// </example>
		All = Distance | Plane | Line | Vector | Point , //(1 << 7) - 1,

		///// <summary> AKA ideal Points are Vectors, the ideal Plane is the Sky Plane </summary>
		//IsIdeal = 1 << 7,
	}

	/// <summary> Base-Blades in 3D, usable as Indices for Components </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// pass: 2
	/// mtime: 2026-07-07T17:42:06Z
	/// digest: 66c81b8887d2ade3e64165ed3108c573db02f55a87f9e79187aa38293cf828b5
	/// tags: [code/enum, code/projective_geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 1}
	/// </code>
	/// </example>
	[SuppressMessage("ReSharper", "InconsistentNaming")]
	public enum Base : sbyte
	{
		/// <summary> [0] AKA e,S; Scalar e.g. Dot Product </summary>
		/// <remarks>
		/// Also used for the stable orthogonal Vector Component(s) of Rotations in a Plane. 
		/// </remarks>
		_1_,

		#region Grade1: (Hyper-)Planes/Reflections

		/// <summary> [1] = e0 => € == 0 Plane/Sphere/<see cref="Geo.Sky"/> at Infinity; Projective with e0² = 0 </summary>
		/// <remarks>
		/// w-Coordinate/Distance from Origin
		/// Projective Mirror: 1 for Points, 0 for (projective) Vectors (Directions, no Location).
		/// 
		/// Dual is <see cref="e123"/>, the <see cref="Points.Origin"/>.
		/// </remarks>
		e0,

		/// <summary> [2] = e1 => X==0 <see cref="Planes.YZ"/>-Plane E1; e1² = 1 </summary>
		/// <remarks>Dual to <see cref="e032"/>, the X-Coordinate</remarks>
		e1,

		/// <summary> [3] = e2 => Y==0 <see cref="Planes.ZX"/>-Plane E2; e2² = 1 </summary>
		/// <remarks>Dual to <see cref="e013"/>, the Y-Coordinate</remarks>
		e2,

		/// <summary> [4] = e3 => Z==0 <see cref="Planes.XY"/>-Plane E3; e3² = 1 </summary>
		/// <remarks> Dual to <see cref="e021"/>, the Z-Coordinate </remarks>
		e3,

		#endregion Grade1: (Hyper-)Planes/Reflections

		#region Grade2: Lines/Translations

		/// <summary> [5] = e01 = <see cref="Geo.Meridian"/>, <see cref="AxisTrans.X"/>-<see cref="Make.Translator(double,Pga3D)"/>;
		/// Geodetic Line on 'celestial' Sphere at Infinity, intersected with <see cref="Planes.YZ"/>-Plane; </summary>
		/// <remarks>
		/// Dual to <see cref="e12"/>, the <see cref="AxisRot.Z"/>-Rotation Axis.
		/// €==0,X==0
		/// <see cref="Geo.Meridian"/> is the Intersection of the Sphere at Infinity
		/// with the <see cref="Planes.YZ"/>-Plane.
		/// 
		/// This Geodetic Line runs through <see cref="Geo.Zenith"/>, <see cref="Geo.North"/>
		/// , <see cref="Geo.Nadir"/> and <see cref="Geo.South"/>.
		/// 
		/// Rotating 'around' this geodetic <see cref="Geo.Meridian"/> (or its Torus)
		/// moves only the X-Coordinate and leaves Y and Z constant.
		/// 
		/// In the projective Model this Rotation is largest (1) at the Origin
		/// and becomes imperceptible with 1/r, so it is rather a Deformation,
		/// instead of a Rotation around the Torus Axis <see cref="Geo.Meridian"/>. 
		/// </remarks>
		e01,

		/// <summary> [6] = e02 = <see cref="Geo.PrimeVertical"/>, <see cref="AxisTrans.Y"/>-<see cref="Make.Translator(double,Pga3D)"/>;
		/// Geodetic Line on 'celestial' Sphere at Infinity, intersected with <see cref="Planes.ZX"/></summary>
		/// <remarks>
		/// €==0,Y==0
		/// Dual to <see cref="e31"/>, the <see cref="AxisRot.Y"/>-Rotation Axis.
		///
		/// <see cref="Geo.PrimeVertical"/> is the Intersection of the Sphere at Infinity
		/// with the <see cref="Planes.ZX"/>-Plane.
		///
		/// This Geodetic Line runs through East, Zenith, West and <see cref="Geo.Nadir"/>.
		/// 
		/// Rotating 'around' this geodetic <see cref="Geo.PrimeVertical"/> 
		/// moves only the Y-Coordinate and leaves X and Z constant.
		/// 
		/// In the projective Model this Rotation is largest (1) at the Origin
		/// and becomes imperceptible with 1/r, so it is rather a Deformation,
		/// instead of a Rotation around the Torus Axis <see cref="Geo.PrimeVertical"/>. 
		/// </remarks>
		e02,

		/// <summary> [7] = e03 = <see cref="Geo.Horizon"/>, <see cref="AxisTrans.Z"/>-<see cref="Make.Translator(double,Pga3D)"/>;
		/// Geodetic Line on 'celestial' Sphere at Infinity, intersected with <see cref="Planes.XY"/></summary>
		/// <remarks>
		/// €==0,Z==0
		/// Dual to <see cref="e12"/>, the <see cref="AxisRot.Z"/>-Rotation Axis.
		///
		/// <see cref="Geo.Horizon"/> is the Intersection of the Sphere at Infinity
		/// with the <see cref="Planes.XY"/>-Plane.
		///
		/// This Geodetic Line runs through East, North, West and <see cref="Geo.South"/>
		/// 
		/// Rotating 'around' this geodetic <see cref="Geo.Horizon"/> 
		/// moves only the Z-Coordinate and leaves X and Y constant.
		/// 
		/// In the projective Model this Rotation is largest (1) at the Origin
		/// and becomes imperceptible with 1/r, so it is rather a Deformation,
		/// instead of a Rotation around the Torus Axis <see cref="Geo.Horizon"/>. 
		/// </remarks>
		e03,

		#endregion Grade2: Lines/Translations

		#region Grade2: Lines/Rotations

		/// <summary> [8] = e12 => x == 0 == y; <see cref="AxisRot.Z"/>-Axis/E12 resp. xy-Plane; e12² = k² = -1 </summary>
		/// <remarks>
		/// X==0,Y==0
		/// Dual to <see cref="e03"/>, the <see cref="AxisTrans.Z"/>-Translation Axis.
		/// AKA Quaternion Component k;
		/// </remarks>
		e12,

		/// <summary> [9] = e31 => x == 0 == z; <see cref="AxisRot.Y"/>-Axis/E31 resp. zx-Plane; e13² = j² = -1 </summary>
		/// <remarks>
		/// X==0,Z==0
		/// Dual to <see cref="e02"/>, the <see cref="AxisTrans.Y"/>-Translation Axis.
		/// AKA Quaternion Component j;
		/// </remarks>
		e31,

		/// <summary> [10] = e23 => z == 0 == y; <see cref="AxisRot.X"/>-Axis/E23 resp. yz-Plane; e23² = i² = -1 </summary>
		/// <remarks>
		/// Y==0,Z==0
		/// Dual to <see cref="e01"/>, the <see cref="AxisTrans.X"/>-Translation Axis.
		/// AKA Quaternion Component i;
		/// </remarks>
		e23,

		#endregion Grade2: Lines/Rotations

		#region Grade3: Points

		/// <summary> [11] = <see cref="Points.Z"/>-Point / E021</summary>
		/// <remarks>
		/// €=Y=X=0
		/// Dual to <see cref="e3"/>, the XY-Plane
		/// </remarks>
		e021,

		/// <summary> [12] <see cref="Points.Y"/>-Point /E013 </summary>
		/// <remarks>
		/// €=Z=X=0
		/// Dual to <see cref="e2"/>, the ZX-Plane.
		/// </remarks>
		e013,

		/// <summary> [13] <see cref="Points.X"/>-Point / E032 </summary>
		/// <remarks>
		/// €=Y=Z=0
		/// Dual to <see cref="e1"/>, the YZ-Plane
		/// </remarks>
		e032,

		/// <summary>[14] = e123 = O/W/<see cref="Points.Origin"/> for the Observer; Distance of Projection Plane from the Origin, the Intersection of all 3 x,y,z Coordinate-Hyper-Planes<br/>
		/// [6] O/W/Origin; 1 for Points, 0 for Vectors<br/>
		/// Represents i.</summary>
		/// <remarks>
		/// A Value of 0 maps the Coordinates to the infinite <see cref="Planes.Sky"/>,
		/// which is a HyperPlane with 1 Dimension less, since the Length loses Significance at Infinity.
		/// 
		/// Z=Y=X=0
		/// PGA points are tri-vectors e1 ^ e2 ^ e3 that are scaled/projected by this Component.
		/// e123 = 0 => Vector/ideal Point.
		/// 
		/// Dual is <see cref="e0"/> the <see cref="Geo.Sky"/>.
		/// </remarks>
		e123,

		#endregion Grade3: Points

		/// <summary>[15] = e0123 = Oriented Volume, a Pseudo-Scalar<br/>
		/// Represents i.</summary>
		e0123,
		/// <summary>Represents i.</summary>
		I = e0123,

		/// <summary> No Component; signals both the End of Components and 0-Elements in the Cayley Tables below </summary>
		_0,// = sbyte.MinValue
	}

	#region Cayley Tables for different Products in R3,0,1

	/// <summary>Cayley table encoding the outer (meet/wedge) product of all basis blade pairs.</summary>
	static readonly Base[][] _ProductOuter = {
		new[] {
			Base._1_, Base.e0, Base.e1, Base.e2, Base.e3, Base.e01, Base.e02, Base.e03, Base.e12, Base.e31, Base.e23,
			Base.e021, Base.e013, Base.e032, Base.e123, Base.e0123
		},
		new[] {
			Base.e0, Base._0, Base.e01, Base.e02, Base.e03, Base._0, Base._0, Base._0, ~Base.e021, ~Base.e013,
			~Base.e032, Base._0, Base._0, Base._0, Base.e0123, Base._0
		},
		new[] {
			Base.e1, ~Base.e01, Base._0, Base.e12, ~Base.e31, Base._0, Base.e021, ~Base.e013, Base._0, Base._0,
			Base.e123, Base._0, Base._0, Base.e0123, Base._0, Base._0
		},
		new[] {
			Base.e2, ~Base.e02, ~Base.e12, Base._0, Base.e23, ~Base.e021, Base._0, Base.e032, Base._0, Base.e123,
			Base._0, Base._0, Base.e0123, Base._0, Base._0, Base._0
		},
		new[] {
			Base.e3, ~Base.e03, Base.e31, ~Base.e23, Base._0, Base.e013, ~Base.e032, Base._0, Base.e123, Base._0,
			Base._0, Base.e0123, Base._0, Base._0, Base._0, Base._0
		},
		new[] {
			Base.e01, Base._0, Base._0, ~Base.e021, Base.e013, Base._0, Base._0, Base._0, Base._0, Base._0,
			Base.e0123, Base._0, Base._0, Base._0, Base._0, Base._0
		},
		new[] {
			Base.e02, Base._0, Base.e021, Base._0, ~Base.e032, Base._0, Base._0, Base._0, Base._0, Base.e0123,
			Base._0, Base._0, Base._0, Base._0, Base._0, Base._0
		},
		new[] {
			Base.e03, Base._0, ~Base.e013, Base.e032, Base._0, Base._0, Base._0, Base._0, Base.e0123, Base._0,
			Base._0, Base._0, Base._0, Base._0, Base._0, Base._0
		},
		new[] {
			Base.e12, ~Base.e021, Base._0, Base._0, Base.e123, Base._0, Base._0, Base.e0123, Base._0, Base._0,
			Base._0, Base._0, Base._0, Base._0, Base._0, Base._0
		},
		new[] {
			Base.e31, ~Base.e013, Base._0, Base.e123, Base._0, Base._0, Base.e0123, Base._0, Base._0, Base._0,
			Base._0, Base._0, Base._0, Base._0, Base._0, Base._0
		},
		new[] {
			Base.e23, ~Base.e032, Base.e123, Base._0, Base._0, Base.e0123, Base._0, Base._0, Base._0, Base._0,
			Base._0, Base._0, Base._0, Base._0, Base._0, Base._0
		},
		new[] {
			Base.e021, Base._0, Base._0, Base._0, ~Base.e0123, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0,
			Base._0, Base._0, Base._0, Base._0, Base._0
		},
		new[] {
			Base.e013, Base._0, Base._0, ~Base.e0123, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0,
			Base._0, Base._0, Base._0, Base._0, Base._0
		},
		new[] {
			Base.e032, Base._0, ~Base.e0123, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0,
			Base._0, Base._0, Base._0, Base._0, Base._0
		},
		new[] {
			Base.e123, ~Base.e0123, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0,
			Base._0, Base._0, Base._0, Base._0, Base._0
		},
		new[] {
			Base.e0123, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0,
			Base._0, Base._0, Base._0, Base._0, Base._0
		}
	};

	/// <summary>Cayley table encoding the full geometric product of all basis blade pairs.</summary>
	static readonly Base[][] _ProductGeometric = {
		new[] {
			Base._1_, Base.e0, Base.e1, Base.e2, Base.e3, Base.e01, Base.e02, Base.e03, Base.e12, Base.e31, Base.e23,
			Base.e021, Base.e013, Base.e032, Base.e123, Base.e0123
		}, new[] { Base.e0, Base._0, Base.e01, Base.e02, Base.e03, Base._0, Base._0, Base._0, ~Base.e021, ~Base.e013,
			~Base.e032, Base._0, Base._0, Base._0, Base.e0123, Base._0
		},
		new[] {
			Base.e1, ~Base.e01, Base._1_, Base.e12, ~Base.e31, ~Base.e0, Base.e021, ~Base.e013, Base.e2, ~Base.e3,
			Base.e123, Base.e02, ~Base.e03, Base.e0123, Base.e23, Base.e032
		},
		new[] {
			Base.e2, ~Base.e02, ~Base.e12, Base._1_, Base.e23, ~Base.e021, ~Base.e0, Base.e032, ~Base.e1, Base.e123,
			Base.e3, ~Base.e01, Base.e0123, Base.e03, Base.e31, Base.e013
		},
		new[] {
			Base.e3, ~Base.e03, Base.e31, ~Base.e23, Base._1_, Base.e013, ~Base.e032, ~Base.e0, Base.e123, Base.e1,
			~Base.e2, Base.e0123, Base.e01, ~Base.e02, Base.e12, Base.e021
		},
		new[] {
			Base.e01, Base._0, Base.e0, ~Base.e021, Base.e013, Base._0, Base._0, Base._0, Base.e02, ~Base.e03,
			Base.e0123, Base._0, Base._0, Base._0, ~Base.e032, Base._0
		},
		new[] {
			Base.e02, Base._0, Base.e021, Base.e0, ~Base.e032, Base._0, Base._0, Base._0, ~Base.e01, Base.e0123,
			Base.e03, Base._0, Base._0, Base._0, ~Base.e013, Base._0
		},
		new[] {
			Base.e03, Base._0, ~Base.e013, Base.e032, Base.e0, Base._0, Base._0, Base._0, Base.e0123, Base.e01,
			~Base.e02, Base._0, Base._0, Base._0, ~Base.e021, Base._0
		},
		new[] {
			Base.e12, ~Base.e021, ~Base.e2, Base.e1, Base.e123, ~Base.e02, Base.e01, Base.e0123, ~Base._1_, Base.e23,
			~Base.e31, Base.e0, Base.e032, ~Base.e013, ~Base.e3, ~Base.e03
		},
		new[] {
			Base.e31, ~Base.e013, Base.e3, Base.e123, ~Base.e1, Base.e03, Base.e0123, ~Base.e01, ~Base.e23,
			~Base._1_, Base.e12, ~Base.e032, Base.e0, Base.e021, ~Base.e2, ~Base.e02
		},
		new[] {
			Base.e23, ~Base.e032, Base.e123, ~Base.e3, Base.e2, Base.e0123, ~Base.e03, Base.e02, Base.e31,
			~Base.e12, ~Base._1_, Base.e013, ~Base.e021, Base.e0, ~Base.e1, ~Base.e01
		},
		new[] {
			Base.e021, Base._0, Base.e02, ~Base.e01, ~Base.e0123, Base._0, Base._0, Base._0, Base.e0, Base.e032,
			~Base.e013, Base._0, Base._0, Base._0, Base.e03, Base._0
		},
		new[] {
			Base.e013, Base._0, ~Base.e03, ~Base.e0123, Base.e01, Base._0, Base._0, Base._0, ~Base.e032, Base.e0,
			Base.e021, Base._0, Base._0, Base._0, Base.e02, Base._0
		},
		new[] {
			Base.e032, Base._0, ~Base.e0123, Base.e03, ~Base.e02, Base._0, Base._0, Base._0, Base.e013, ~Base.e021,
			Base.e0, Base._0, Base._0, Base._0, Base.e01, Base._0
		},
		new[] {
			Base.e123, ~Base.e0123, Base.e23, Base.e31, Base.e12, Base.e032, Base.e013, Base.e021, ~Base.e3,
			~Base.e2, ~Base.e1, ~Base.e03, ~Base.e02, ~Base.e01, ~Base._1_, Base.e0
		}, new[] { Base.e0123, Base._0, ~Base.e032, ~Base.e013, ~Base.e021, Base._0, Base._0, Base._0, ~Base.e03,
			~Base.e02, ~Base.e01, Base._0, Base._0, Base._0, ~Base.e0, Base._0
		}
	};

	/// <summary>Cayley table encoding the inner (dot) product of all basis blade pairs.</summary>
	static readonly Base[][] _ProductDot = {
		new[] {
			Base._1_, Base.e0, Base.e1, Base.e2, Base.e3, Base.e01, Base.e02, Base.e03, Base.e12, Base.e31, Base.e23,
			Base.e021, Base.e013, Base.e032, Base.e123, Base.e0123
		},
		new[] {
			Base.e0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0,
			Base._0, Base._0, Base._0, Base._0, Base._0
		},
		new[] {
			Base.e1, Base._0, Base._1_, Base._0, Base._0, ~Base.e0, Base._0, Base._0, Base.e2, ~Base.e3, Base._0,
			Base.e02, ~Base.e03, Base._0, Base.e23, Base.e032
		},
		new[] {
			Base.e2, Base._0, Base._0, Base._1_, Base._0, Base._0, ~Base.e0, Base._0, ~Base.e1, Base._0, Base.e3,
			~Base.e01, Base._0, Base.e03, Base.e31, Base.e013
		},
		new[] {
			Base.e3, Base._0, Base._0, Base._0, Base._1_, Base._0, Base._0, ~Base.e0, Base._0, Base.e1, ~Base.e2,
			Base._0, Base.e01, ~Base.e02, Base.e12, Base.e021
		},
		new[] {
			Base.e01, Base._0, Base.e0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0,
			Base._0, Base._0, Base._0, Base._0, Base._0
		},
		new[] {
			Base.e02, Base._0, Base._0, Base.e0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0,
			Base._0, Base._0, Base._0, Base._0, Base._0
		},
		new[] {
			Base.e03, Base._0, Base._0, Base._0, Base.e0, Base._0, Base._0, Base._0, Base._0, Base._0, Base._0,
			Base._0, Base._0, Base._0, Base._0, Base._0
		},
		new[] {
			Base.e12, Base._0, ~Base.e2, Base.e1, Base._0, Base._0, Base._0, Base._0, ~Base._1_, Base._0, Base._0,
			Base.e0, Base._0, Base._0, ~Base.e3, ~Base.e03
		},
		new[] {
			Base.e31, Base._0, Base.e3, Base._0, ~Base.e1, Base._0, Base._0, Base._0, Base._0, ~Base._1_, Base._0,
			Base._0, Base.e0, Base._0, ~Base.e2, ~Base.e02
		},
		new[] {
			Base.e23, Base._0, Base._0, ~Base.e3, Base.e2, Base._0, Base._0, Base._0, Base._0, Base._0, ~Base._1_,
			Base._0, Base._0, Base.e0, ~Base.e1, ~Base.e01
		},
		new[] {
			Base.e021, Base._0, Base.e02, ~Base.e01, Base._0, Base._0, Base._0, Base._0, Base.e0, Base._0, Base._0,
			Base._0, Base._0, Base._0, Base._0, Base._0
		},
		new[] {
			Base.e013, Base._0, ~Base.e03, Base._0, Base.e01, Base._0, Base._0, Base._0, Base._0, Base.e0, Base._0,
			Base._0, Base._0, Base._0, Base._0, Base._0
		},
		new[] {
			Base.e032, Base._0, Base._0, Base.e03, ~Base.e02, Base._0, Base._0, Base._0, Base._0, Base._0, Base.e0,
			Base._0, Base._0, Base._0, Base._0, Base._0
		},
		new[] {
			Base.e123, Base._0, Base.e23, Base.e31, Base.e12, Base._0, Base._0, Base._0, ~Base.e3, ~Base.e2,
			~Base.e1, Base._0, Base._0, Base._0, ~Base._1_, Base.e0
		},
		new[] {
			Base.e0123, Base._0, ~Base.e032, ~Base.e013, ~Base.e021, Base._0, Base._0, Base._0, ~Base.e03,
			~Base.e02, ~Base.e01, Base._0, Base._0, Base._0, ~Base.e0, Base._0
		}
	};

	/// <summary> ^ AKA Meet, Wedge Product </summary>
	public static readonly IReadOnlyList<IReadOnlyList<Base>> ProductOuter = _ProductOuter;

	/// <summary> * AKA Times, Geometric Product </summary>
	public static readonly IReadOnlyList<IReadOnlyList<Base>> ProductGeometric = _ProductGeometric;

	/// <summary> | AKA Dot, Scalar Product </summary>
	public static readonly IReadOnlyList<IReadOnlyList<Base>> ProductDot = _ProductDot;

	/// <summary>Ordered array of all three Cayley tables: geometric, dot, and outer; order must match <see cref="Products"/>.</summary>
	static readonly Base[][][] _Products = { _ProductGeometric, _ProductDot, _ProductOuter};
	/// <summary>Public read-only view of all three product Cayley tables indexed by product type.</summary>
	public static readonly IReadOnlyList<IReadOnlyList<IReadOnlyList<Base>>> Products = _Products;

	#endregion Cayley Tables for different Products in R3,0,0

	#region Static Base Blades

	/// <inheritdoc cref="Base._1_"/>
	public static readonly Pga3D _1_ = Base._1_;

	/// <inheritdoc cref="Base.e0"/>
	public static readonly Pga3D E0 = Base.e0;

	/// <inheritdoc cref="Base.e1"/>
	public static readonly Pga3D E1 = Base.e1;

	/// <inheritdoc cref="Base.e2"/>
	public static readonly Pga3D E2 = Base.e2;

	/// <inheritdoc cref="Base.e3"/>
	public static readonly Pga3D E3 = Base.e3;

	/// <inheritdoc cref="Base.e01"/>
	public static readonly Pga3D E01 = Base.e01;

	/// <inheritdoc cref="Base.e02"/>
	public static readonly Pga3D E02 = Base.e02;

	/// <inheritdoc cref="Base.e03"/>
	public static readonly Pga3D E03 = Base.e03;

	/// <inheritdoc cref="Base.e12"/>
	public static readonly Pga3D E12 = Base.e12;

	/// <inheritdoc cref="Base.e31"/>
	public static readonly Pga3D E31 = Base.e31;

	/// <inheritdoc cref="Base.e23"/>
	public static readonly Pga3D E23 = Base.e23;

	/// <inheritdoc cref="Base.e021"/>
	/// <example>
	/// <code language="yaml">
	/// pass: 2
	/// mtime: 2026-05-24T16:03:01Z
	/// digest: e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855
	/// </code>
	/// </example>
	public static readonly Pga3D E021 = Base.e021;

	/// <inheritdoc cref="Base.e013"/>
	public static readonly Pga3D E013 = Base.e013;

	/// <inheritdoc cref="Base.e032"/>
	public static readonly Pga3D E032 = Base.e032;

	/// <inheritdoc cref="Base.e123"/>
	public static readonly Pga3D E123 = Base.e123;

	/// <inheritdoc cref="Base.e0123"/>
	public static readonly Pga3D E0123 = Base.e0123; //e0 ^ e1 ^ e2 ^ e3;

	/// <summary>Static ordered list of all 16 unit basis blades of the 3D PGA algebra.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// pass: 2
	/// mtime: 2026-06-17T10:09:57Z
	/// digest: d631a2f3cb68a3f0224854188cb6c35044c110ab3581aab400be911a771c557d
	/// tags: [code/projective_geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: partial, complexity: 2}
	/// </code>
	/// </example>
	public static IReadOnlyList<Pga3D> Blades => _Blades;
	/// <summary>Backing array of all 16 ordered unit basis blades.</summary>
	static readonly Pga3D[] _Blades = {_1_ //Grade0
		, Planes.Dist, Planes.YZ, Planes.ZX, Planes.XY //Grade1
		, AxisTrans.X, AxisTrans.Y, AxisTrans.Z //Grade2
		, AxisRot.Z, AxisRot.Y, AxisRot.X //Grade2
		, Points.Z, Points.Y, Points.X, Points.Origin //Grade3
		, E0123 }; //Grade4

	/// <summary> Grade 1: Static Planes </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// pass: 2
	/// mtime: 2026-07-07T17:42:06Z
	/// digest: d631a2f3cb68a3f0224854188cb6c35044c110ab3581aab400be911a771c557d
	/// tags: [code/enum, code/projective_geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 1}
	/// </code>
	/// </example>
	[SuppressMessage("ReSharper", "InconsistentNaming")]
	public enum Planes : sbyte
	{
		/// <inheritdoc cref="Base.e0"/>
		Dist= Base.e0,

		/// <summary>Represents sky.</summary>
		Sky= Dist,

		/// <inheritdoc cref="Base.e1"/>
		YZ= Base.e1,

		/// <inheritdoc cref="Base.e2"/>
		ZX= Base.e2,

		/// <inheritdoc cref="Base.e3"/>
		XY= Base.e3,
	}

	/// <summary> Polar Coordinates match projective Geometry </summary>
	/// <remarks>
	/// ## Public Methods
	///
	/// | Line | Method | Description |
	/// |--:|---|---|
	/// | 1014 | <see cref="Sky"/> | Represents sky. |
	/// | 1017 | <see cref="Origin"/> | current Position of the Observer |
	/// | 1020 | <see cref="Meridian"/> | Represents meridian. |
	/// | 1023 | <see cref="PrimeVertical"/> | Represents prime Vertical. |
	/// | 1026 | <see cref="Horizon"/> | Represents horizon. |
	/// | 1039 | <see cref="Zenith"/> | Represents zenith. |
	/// | 1042 | <see cref="Nadir"/> | Represents nadir. |
	/// | 1045 | <see cref="West"/> | Represents west. |
	/// | 1055 | <see cref="East"/> | Represents east. |
	/// | 1058 | <see cref="North"/> | Represents north. |
	/// | 1068 | <see cref="South"/> | Represents south. |
	/// </remarks>
	///
	/// <example>
	/// <code language="yaml">
	/// pass: 2
	/// mtime: 2026-07-07T17:42:06Z
	/// digest: 29c9f3a451af85939d573e784c285baa9191ad285ee19927efe6c2601e336a65
	/// tags: [code/enum, code/polar_coordinates]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 1}
	/// </code>
	/// </example>
	public enum Geo : sbyte
	{
		/// <inheritdoc cref="Base.e0"/>
		Sky = Planes.Dist,

		/// <summary> current Position of the Observer </summary>
		Origin = Points.Origin,

		/// <inheritdoc cref="Base.e01"/>
		Meridian = AxisTrans.X,

		/// <inheritdoc cref="Base.e02"/>
		PrimeVertical = AxisTrans.Y,

		/// <inheritdoc cref="Base.e03"/>
		Horizon = AxisTrans.Z,

		#region antipodal 'Points' (TriPlanes) can be distinguished by Sign

		/// <inheritdoc cref="Base.e032"/>
		/// <example>
		/// <code language="yaml">
		/// pass: 2
		/// mtime: 2026-06-17T10:09:57Z
		/// digest: e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855
		/// </code>
		/// </example>

		Zenith = Points.Z,

		/// <inheritdoc cref="Base.e032"/>
		Nadir = -Points.Z,

		/// <inheritdoc cref="Base.e032"/>
		West = Points.X,

		/// <inheritdoc cref="Base.e032"/>
		/// <example>
		/// <code language="yaml">
		/// pass: 2
		/// mtime: 2026-06-17T10:09:57Z
		/// digest: e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855
		/// </code>
		/// </example>
		East = -Points.X,

		/// <inheritdoc cref="Base.e032"/>
		North = Points.Y,

		/// <inheritdoc cref="Base.e032"/>
		/// <example>
		/// <code language="yaml">
		/// pass: 2
		/// mtime: 2026-06-17T10:09:57Z
		/// digest: e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855
		/// </code>
		/// </example>
		South = -Points.Y,

		#endregion antipodal 'Points' (TriPlanes) can be distinguished by Sign
	}

	/// <summary> Grade2: euclidean Axes for <see cref="Make.Rotor"/> </summary>
	/// <remarks>
	/// These correspond to orthogonal/dual Rotation Planes.
	/// The Axes are fixed Points for their Rotations.
	/// </remarks>
	/// <example>
	/// <code language="yaml">
	/// pass: 2
	/// mtime: 2026-07-07T17:42:06Z
	/// digest: e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855
	/// tags: [code/enum, code/projective_geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 1}
	/// </code>
	/// </example>
	public enum AxisRot : sbyte
	{
		/// <inheritdoc cref="Base.e23"/>
		X = Base.e23,

		/// <inheritdoc cref="Base.e31"/>
		Y = Base.e31,

		/// <inheritdoc cref="Base.e12"/>
		Z = Base.e12,

		/// <inheritdoc cref="Base._1_"/>
		_1_ = Base._1_,
	}

	/// <summary> Grade2: 'Ideal' Axes for <see cref="Make.Translator"/>/<see cref="Make.Motor"/> </summary>
	/// <remarks>
	/// ## Public Methods
	///
	/// | Line | Method | Description |
	/// |--:|---|---|
	/// | 1112 | <see cref="X"/> | Represents x. |
	/// | 1115 | <see cref="Y"/> | Represents y. |
	/// | 1118 | <see cref="Z"/> | Represents z. |
	/// | 1121 | <see cref="_1_"/> | Represents 1. |
	/// </remarks>
	///
	/// <example>
	/// <code language="yaml">
	/// pass: 2
	/// mtime: 2026-07-07T17:42:06Z
	/// digest: e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855
	/// tags: [code/enum, code/projective_geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 1}
	/// </code>
	/// </example>
	public enum AxisTrans : sbyte
	{
		/// <inheritdoc cref="Base.e01"/>
		X = Base.e01,

		/// <inheritdoc cref="Base.e02"/>
		Y = Base.e02,

		/// <inheritdoc cref="Base.e03"/>
		Z = Base.e03,

		/// <inheritdoc cref="Base._1_"/>
		_1_ = Base._1_,
	}

	/// <summary> Grade3: Static Axes for <see cref="Make.Point"/> </summary>
	/// <remarks>
	/// ## Public Methods
	///
	/// | Line | Method | Description |
	/// |--:|---|---|
	/// | 1136 | <see cref="Origin"/> | Represents origin. |
	/// | 1139 | <see cref="Dist"/> | Represents dist. |
	/// | 1142 | <see cref="Z"/> | Represents z. |
	/// | 1145 | <see cref="Y"/> | Represents y. |
	/// | 1148 | <see cref="X"/> | Represents x. |
	/// </remarks>
	///
	/// <example>
	/// <code language="yaml">
	/// pass: 2
	/// mtime: 2026-07-07T17:42:06Z
	/// digest: e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855
	/// tags: [code/enum, code/projective_geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 1}
	/// </code>
	/// </example>
	public enum Points : sbyte
	{
		/// <inheritdoc cref="Base.e123"/>
		Origin = Base.e123,

		/// <inheritdoc cref="Base.e123"/>
		Dist = Origin,

		/// <inheritdoc cref="Base.e021"/>
		Z = Base.e021,

		/// <inheritdoc cref="Base.e013"/>
		Y = Base.e013,

		/// <inheritdoc cref="Base.e032"/>
		X = Base.e032

	}

	// PGA lines are Intersections of Planes, i.e. bi-vectors.

	// ReSharper restore InconsistentNaming
	#endregion Base Objects

	#region named Members
#pragma warning disable IDE1006 // Naming Styles
	// ReSharper disable InconsistentNaming

	/// <inheritdoc cref="Base._1_"/>
	public float s => _C[(int) Base._1_];

	/// <inheritdoc cref="Base.e0"/>
	public float e0 => _C[(int) Base.e0];

	/// <inheritdoc cref="Base.e1"/>
	public float e1 => _C[(int) Base.e1];

	/// <inheritdoc cref="Base.e2"/>
	public float e2 => _C[(int) Base.e2];

	/// <inheritdoc cref="Base.e3"/>
	public float e3 => _C[(int) Base.e3];

	/// <inheritdoc cref="Base.e01"/>
	public float e01 => _C[(int) Base.e01];

	/// <inheritdoc cref="Base.e02"/>
	public float e02 => _C[(int) Base.e02];

	/// <inheritdoc cref="Base.e03"/>
	public float e03 => _C[(int) Base.e03];

	/// <inheritdoc cref="Base.e12"/>
	public float e12 => _C[(int) Base.e12];

	/// <inheritdoc cref="Base.e31"/>
	public float e31 => _C[(int) Base.e31];

	/// <inheritdoc cref="Base.e23"/>
	public float e23 => _C[(int) Base.e23];

	/// <inheritdoc cref="Base.e021"/>
	public float e021 => _C[(int) Base.e021];

	/// <inheritdoc cref="Base.e013"/>
	public float e013 => _C[(int) Base.e013];

	/// <inheritdoc cref="Base.e032"/>
	public float e032 => _C[(int) Base.e032];

	/// <inheritdoc cref="Base.e123"/>
	public float e123 => _C[(int) Base.e123];

	/// <inheritdoc cref="Base.e0123"/>
	public float e0123 => _C[(int) Base.e0123]; //e0 ^ e1 ^ e2 ^ e3;

	// ReSharper restore InconsistentNaming
#pragma warning restore IDE1006 // Naming Styles
	#endregion

	/// <summary>Gets or sets the element at the specified <paramref name="index"/>.<br/>
	/// Gets or sets the element at the specified <paramref name="index"/>.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/projective_geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: partial, complexity: 2}
	/// </code>
	/// </example>
	public float this[AxisTrans idx] => _C[(int) idx];
	/// <summary>Gets or sets the element at the specified <paramref name="index"/>.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/projective_geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: partial, complexity: 2}
	/// </code>
	/// </example>
	public float this[AxisRot idx] => _C[(int) idx];
	/// <summary>Gets or sets the element at the specified <paramref name="index"/>.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/projective_geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: partial, complexity: 2}
	/// </code>
	/// </example>
	public float this[Points idx] => _C[(int) idx];
	/// <summary>Gets or sets the element at the specified <paramref name="index"/>.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/projective_geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: partial, complexity: 2}
	/// </code>
	/// </example>
	public float this[Planes idx] => _C[(int) idx];
	/// <inheritdoc cref="New(float[])"/>
	public float this[Base idx] => _C[(int) idx];
	/// <inheritdoc cref="New(float[])"/>
	public float this[Geo idx] => _C[(int) idx];

	/// <inheritdoc cref="New(float[])"/>
	public static Pga3D New(params float[] f) => New((IReadOnlyList<float>) f);
	/// <inheritdoc cref="New(float[])"/>
	public static Pga3D New(IReadOnlyList<float> f) => new(f);
	/// <inheritdoc />
	public static Pga3D New(double f = 0, int idx = 0) => new(f, idx);
	/// <inheritdoc cref="Create(IReadOnlyList{float})"/>
	public static Pga3D New(params Base<Base>[] values) => new(values);
	/// <inheritdoc />
	public static Pga3D New(IReadOnlyList<Base<Base>> values) => new(values);

	/// <inheritdoc />
	public override Pga3D Create(IReadOnlyList<float> values) => new(values);
	/// <inheritdoc cref="Create(IReadOnlyList{float})"/>
	public override Pga3D Create(IList<float> values) => new((IReadOnlyList<float>)values);
	/// <inheritdoc />
	protected override Pga3D Create_(float[] values) => new(values);
	/// <summary> Unchecked private Constructor for Speed </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/projective_geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: partial, complexity: 2}
	/// </code>
	/// </example>
	internal Pga3D(params float[] f) : base(f){ }

	/// <summary>Checked Constructor<br/>
	/// Initializes a new instance of <see cref="Pga3D"/> with the specified <paramref name="values"/>.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/projective_geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: partial, complexity: 2}
	/// </code>
	/// </example>
	//public Pga3D(params float[] values) : base(values){ }
	public Pga3D(IReadOnlyList<float> values) : base(values){ }
	/// <summary>Initializes a new instance of <see cref="Pga3D"/> with the specified <paramref name="values"/>.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/projective_geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: partial, complexity: 2}
	/// </code>
	/// </example>
	public Pga3D(IReadOnlyList<Base<Base>> values) : base(AsMultiVector(values)){ }
	/// <summary>Initializes a new instance of <see cref="Pga3D"/> with the specified <paramref name="values"/>.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/projective_geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: partial, complexity: 2}
	/// </code>
	/// </example>
	public Pga3D(params Base<Base>[] values) : base(AsMultiVector(values)){ }
	/// <summary>Initializes a new instance of <see cref="Pga3D"/> with the specified <paramref name="values"/>.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/projective_geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: partial, complexity: 2}
	/// </code>
	/// </example>
	public Pga3D(params Base<Points>[] values) : base(AsMultiVector(values)){ }
	/// <summary> Initializes a new instance of <see cref="Pga3D"/> from an array of weighted <see cref="Planes"/> blades. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/projective_geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: partial, complexity: 2}
	/// </code>
	/// </example>
	public Pga3D(params Base<Planes>[] values) : base(AsMultiVector(values)){ }
	/// <summary>Initializes a new instance of <see cref="Pga3D"/> with the specified <paramref name="values"/>.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/projective_geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: partial, complexity: 2}
	/// </code>
	/// </example>
	public Pga3D(params Base<AxisTrans>[] values) : base(AsMultiVector(values)){ }
	/// <summary>Initializes a new instance of <see cref="Pga3D"/> with the specified <paramref name="values"/>.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/projective_geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: partial, complexity: 2}
	/// </code>
	/// </example>
	public Pga3D(params Base<AxisRot>[] values) : base(AsMultiVector(values)){ }

	/// <summary>Implicitly converts <paramref name="axis"/> to <see cref="Pga3D"/>.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/projective_geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: partial, complexity: 2}
	/// </code>
	/// </example>
	public static float[] AsMultiVector<T>(IReadOnlyList<Base<T>> values) where T : Enum
		=> values.AsSingles(NUM_COORDS);

	/// <summary>Implicitly converts <paramref name="axis"/> to <see cref="Pga3D"/>.</summary>
	public static implicit operator Pga3D(AxisTrans axis) => new(1, axis);
	/// <summary>Implicitly converts <paramref name="axis"/> to <see cref="Pga3D"/>.</summary>
	public static implicit operator Pga3D(AxisRot axis) => new(1, axis);
	/// <summary>Implicitly converts <paramref name="axis"/> to <see cref="Pga3D"/>.</summary>
	public static implicit operator Pga3D(Planes axis) => new(1, axis);
	/// <summary>Initializes a new instance of <see cref="Pga3D"/> with the specified <paramref name="f"/> and <paramref name="idx"/>.</summary>
	public static implicit operator Pga3D(Points axis) => new(1, axis);
	/// <summary>Initializes a new instance of <see cref="Pga3D"/> with the specified <paramref name="f"/> and <paramref name="idx"/>.</summary>
	public static implicit operator Pga3D(Base axis) => new(1, axis);
	/// <summary>Initializes a new instance of <see cref="Pga3D"/> with the specified <paramref name="f"/> and <paramref name="idx"/>.</summary>
	public static implicit operator Pga3D(Geo axis) => new(1, axis);

	/// <summary>Initializes a new instance of <see cref="Pga3D"/> with the specified <paramref name="f"/> and <paramref name="idx"/>.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/projective_geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: partial, complexity: 2}
	/// </code>
	/// </example>
	public Pga3D(double f = 0, Points idx = 0) : base(f, (int)idx) {}
	/// <summary>Initializes a new instance of <see cref="Pga3D"/> with the specified <paramref name="f"/> and <paramref name="idx"/>.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/projective_geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: partial, complexity: 2}
	/// </code>
	/// </example>
	public Pga3D(double f = 0, Planes idx = 0) : base(f, (int)idx) {}
	/// <summary>Initializes a new instance of <see cref="Pga3D"/> with the specified <paramref name="f"/> and <paramref name="idx"/>.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/projective_geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: partial, complexity: 2}
	/// </code>
	/// </example>
	public Pga3D(double f = 0, AxisTrans idx = 0) : base(f, (int)idx) {}
	/// <summary>Initializes a new instance of <see cref="Pga3D"/> with the specified <paramref name="f"/> and <paramref name="idx"/>.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/projective_geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: partial, complexity: 2}
	/// </code>
	/// </example>
	public Pga3D(double f = 0, AxisRot idx = 0) : base(f, (int)idx) {}
	/// <summary> Initializes a new instance of <see cref="Pga3D"/> with the specified <paramref name="f"/> and <paramref name="idx"/>. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/projective_geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: partial, complexity: 2}
	/// </code>
	/// </example>
	public Pga3D(double f = 0, Base idx = 0) : base(f, (int)idx) {}
	/// <summary>Initializes a new instance of <see cref="Pga3D"/> with the specified <paramref name="f"/> and <paramref name="idx"/>.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/projective_geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: partial, complexity: 2}
	/// </code>
	/// </example>
	public Pga3D(double f = 0, Geo idx = 0) : base(f, (int)idx) {}
	/// <summary>Initializes a new instance of <see cref="Pga3D"/> with the specified <paramref name="f"/> and <paramref name="idx"/>.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/projective_geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: partial, complexity: 2}
	/// </code>
	/// </example>
	public Pga3D(double f = 0, int idx = 0) : base(f, idx) {}

	/// <summary> Extracts the homogeneous Euclidean XYZ coordinates of this multi-vector as a <see cref="Points"/> point, dividing by the origin component when non-zero. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/projective_geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: partial, complexity: 2}
	/// </code>
	/// </example>
	public float[] AsPoint() {
		//return Extract(Point.X, Point.Y, Point.Z);
		var ret = new[] {this[Points.X], this[Points.Y], this[Points.Z]};
		var norm = this[Points.Origin];
		if (norm.IsSmallerThanAbs(PgaTolerance.Float) || norm.IsOne()) {
			return ret;
		}
		for (int i = ret.Length; --i >= 0; i--) {
			ret[i] /= norm;
		}
		return ret;
	}

	/*float[] Extract(params Point[] coordinates) {
		for (int i = NUM_COORDS; --i >= 0; i--) {
			
		}

		var ret = new float[coordinates.Length];
		for (int i = coordinates.Length; --i >= 0; i--) {
			
		}

		return ret;//new[] {this[coordinates], this[Point.Y], this[Point.Z]};
	}*/

	/// <inheritdoc />
	public override Pga3D Dual() => new(_C.Dual16());
	/// <inheritdoc />
	public override double NormSqr() => _C.NormSqr16P();

	/// <inheritdoc cref="XPga3D.Times16"/>
	public override Pga3D Times(IReadOnlyList<float> factor) => new(_C.Times16P(factor));

	/// <inheritdoc cref="XPga3D.Times16"/>
	public override Pga3D TimesR(IReadOnlyList<float> factor) => new(factor.Times16P(_C));

	/// <inheritdoc cref="XPga3D.Dot16P"/>
	/// <inheritdoc />
	public override Pga3D Dot(IReadOnlyList<float> parallel) => new(_C.Dot16P(parallel));

	/// <inheritdoc cref="XPga3D.Meet16P"/>
	public override Pga3D Meet(IReadOnlyList<float> that) => new(_C.Meet16P(that));
	/// <inheritdoc />
	public override Pga3D MeetR(IReadOnlyList<float> that) => new(that.Meet16P(_C));

	/// <inheritdoc cref="XPga3D.Join16P"/>
	public override Pga3D Join(IReadOnlyList<float> that) => new(_C.Join16P(that));

	/// <summary> Returns true if the norm of the difference between this and <paramref name="arg"/> is negligible relative to their combined norms. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/projective_geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: partial, complexity: 2}
	/// </code>
	/// </example>
	public bool CloseTo(Pga3D arg) {
		var diff = this - arg;
		var diffNorm = diff.NormSqr();
		var compare = NormSqr() + arg.NormSqr();
		return diffNorm <= compare * 1e-7;
	}

	/// <summary> test if this is approx. <paramref name="that"/> </summary>
	/// <remarks>
	/// With Homogeneous Coordinates, Parallel Elements cancel out and you can test for a Scalar Product with itself.
	/// </remarks>
	/// <example>
	/// <code language="yaml">
	/// tags: [code/projective_geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: partial, complexity: 2}
	/// </code>
	/// </example>
	public override bool Equals(Pga3D? that) {
		if (that is null) return false;
		if (ReferenceEquals(that, this)) return true;
		return _C.IsCloseTo(that._C);
		//var prod = this * ~that;
		//return prod.IsScalar();
		//return Normalized().Equals(that?.Normalized()._C);
	}

	/// <summary>Determines whether scalar.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/projective_geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: partial, complexity: 2}
	/// </code>
	/// </example>
	public bool IsScalar() {
		var pos = Math.Abs(_C[0]) * 1e-6;
		var neg = -pos;
		for (int i = NUM_COORDS - 1; i > 0; i--) {
			if (_C[i] > pos) {
				return false;
			}
			if (_C[i] < neg) {
				return false;
			}
		}
		return true;
	}

	/// <summary> Static Factory Methods </summary>
	/// <remarks>
	/// ## Public Methods
	///
	/// | Line | Method | Description |
	/// |--:|---|---|
	/// | 1408 | <see cref="Point"/> | Point given by Coordinates x, y and z |
	/// | 1415 | <see cref="Vector"/> | Point given by Coordinates x, y and z |
	/// | 1435 | <see cref="Rotor"/> | Rotor around euclidean axisRot |
	/// | 1441 | <see cref="Rot"/> | Constructs a rotor that rotates by angle a (radians) around the given axisRot. |
	/// | 1453 | <see cref="Translator"/> |  |
	/// | 1465 | <see cref="Motor"/> | AKA Translator(double,Pga3D); translates dist along the axisTrans/Vector when using the Sandwich Product |
	/// | 1477 | <see cref="Line"/> | Line given by slope and intersect |
	/// | 1497 | <see cref="Plane"/> | Plane given by slope and intersect |
	/// | 1516 | <see cref="Circle"/> | Returns a motor that places a point at radius along the X-axis after rotating by t full turns around line. |
	/// | 1522 | <see cref="IdealLine"/> | Ideal Line. |
	/// | 1537 | <see cref="Lathe"/> | Constructs 3D Bodies around a Rotation Axis like a Lathe |
	/// | 1559 | <see cref="SqRtTwo"/> | Square root of 2, used as a scaling factor for cube spine heights. |
	/// | 1561 | <see cref="SqRtHalf"/> | Square root of 0. |
	/// | 1564 | <see cref="TestDual"/> | Test Dual. |
	/// | 1571 | <see cref="Cylinder"/> | Generates the outer Cylinder Mesh; degenerates to a Cube for numSegments = 4 |
	/// | 1578 | <see cref="CubeSpineCoords"/> | Spines of a Cube with Height = √2, not its Sides! |
	/// | 1590 | <see cref="CubeSpineCoords2"/> | Spines of a Cube with Height = 1 rotated around the X-Axis from 0 to +1, (not its Sides!) |
	/// | 1599 | <see cref="TestCubeSpineCoords"/> | NUnit test-case source providing expected CubeSpineCoords2 for CubePoints. |
	/// | 1606 | <see cref="CubePoints"/> | Cube Points. |
	/// | 1619 | <see cref="Cube"/> | Generates the 4 'Spines' of a Cube, around the X-Symmetry-Axis. |
	/// | 1623 | <see cref="Torus"/> | Generates a Torus Mesh; degenerates to a solid Polygon Line for small numLargeToroidal |
	/// | 1631 | <see cref="Sphere"/> | Generates a Sphere Mesh; degenerates to a double Pyramid for numMeridian = 2 |
	/// | 1637 | <see cref="Cone"/> | Generates a Cone/Pyramid Mesh; degenerates to a Tetrahedron for numSegments = 3 |
	/// | 1641 | <see cref="Tetrahedron"/> | Generates a regular Tetrahedron mesh with circumradius r as a degenerate 3-segment Cone. |
	/// | 1644 | <see cref="Arrow"/> | Generates an Arrow mesh composed of a cone tip, an inverted cone base, and a cylinder shaft. |
	/// | 1663 | <see cref="Planets"/> | Planet Name, Mass, Position and Speed from https://ssd. |
	/// | 1673 | <see cref="G"/> | Gravity Constant |
	///
	/// ## Collaborators
	///
	/// | Type | Role |
	/// |---|---|
	/// | <see cref="Pga3D"/> | Returned by a method. |
	/// </remarks>
	/// <example>
	/// <code language="yaml">
	/// pass: 2
	/// mtime: 2026-06-17T10:09:57Z
	/// digest: 6348caa1d98860fe344ead8a0f783fd3f3662b556b89b29766fee2bc3df0b98e
	/// tags: [code/factory, code/projective_geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: partial, complexity: 2}
	/// </code>
	/// </example>
	public static class Make
	{
		/// <summary> Point given by Coordinates <see cref="x"/>, <see cref="y"/> and <see cref="z"/> </summary>
		/// <remarks>
		/// Points are Grade 3 TriPlanes, the Intersections of 3 (Hyper-)Planes,
		/// and operate as Reflectors with themselves as Fixed-Points.
		///
		/// Points are expressed with homogeneous Coordinates,
		/// that means a Point needs to be normalized by dividing through <paramref name="norm"/>.
		/// All Points with the same normalized Coordinates are equivalent!
		///
		/// When <paramref name="norm"/> = 0, this is a Vector, a Point at the infinite Horizon/Sphere.
		/// All parallel Lines meet at the same Point at the Horizon and form a 2D Vector Space of Rotations. 
		///
		/// A point is just a homogeneous point, euclidean coordinates plus the origin
		/// </remarks>
		/// <example>
		/// <code language="yaml">
		/// tags: [code/factory, code/projective_geometric_algebra]
		/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
		/// facets: {layer: domain, status: stable, complexity: 1}
		/// </code>
		/// </example>
		// ReSharper disable once MemberHidesStaticFromOuterClass
		public static Pga3D Point(double x, double y, double z = 0, double norm = 1)
			=> new(Points.Origin.AsBlade(norm)
				, Points.X.AsBlade(x)
				, Points.Y.AsBlade(y)
				, Points.Z.AsBlade(z));

		/// <summary> Point given by Coordinates <paramref name="x"/>, <paramref name="y"/> and <paramref name="z"/> </summary>
		///
		/// <example>
		/// <code language="yaml">
		/// tags: [code/factory, code/projective_geometric_algebra]
		/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
		/// facets: {layer: domain, status: stable, complexity: 1}
		/// </code>
		/// </example>
		public static Pga3D Vector(double x, double y, double z = 0) => new(
			Points.X.AsBlade(x),
			Points.Y.AsBlade(y),
			Points.Z.AsBlade(z));

		/// <summary> A plane is defined using its homogenous equation ax + by + cz + d = 0 </summary>
		/// <remarks>
		/// Alternatively you can join three <see cref="Point"/>s.
		/// </remarks>
		/// <example>
		/// <code language="yaml">
		/// tags: [code/factory, code/projective_geometric_algebra]
		/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
		/// facets: {layer: domain, status: stable, complexity: 1}
		/// </code>
		/// </example>
		// ReSharper disable once MemberHidesStaticFromOuterClass
		public static Pga3D Plane(double ax, double by, double cz, double d)
			=> new(Planes.Dist.AsBlade(d)
				, Planes.YZ.AsBlade(ax)
				, Planes.ZX.AsBlade(by)
				, Planes.XY.AsBlade(cz));

		/// <summary> Rotor around euclidean <paramref name="axisRot"/></summary>
		/// <remarks>
		/// The Axis must be any linear Combination of <see cref="AxisRot"/> Elements.
		/// </remarks>
		/// <example>
		/// <code language="yaml">
		/// tags: [code/factory, code/projective_geometric_algebra]
		/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
		/// facets: {layer: domain, status: stable, complexity: 1}
		/// </code>
		/// </example>
		public static Pga3D Rotor(double angle, Pga3D axisRot) {
			var sinCos = (angle * 0.5).SinCos();
			return sinCos.cos + sinCos.sin * axisRot.Normalized();
		}

		/// <summary> Constructs a rotor that rotates by angle <paramref name="a"/> (radians) around the given <paramref name="axisRot"/>. </summary>
		///
		/// <example>
		/// <code language="yaml">
		/// tags: [code/factory, code/projective_geometric_algebra]
		/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
		/// facets: {layer: domain, status: stable, complexity: 1}
		/// </code>
		/// </example>
		public static Pga3D Rot(double a, Pga3D axisRot) => Math.Cos(a) + Math.Sin(a) * axisRot.Normalized();
		/// <summary>Constructs a normalized rotor that rotates by <paramref name="angle"/> (radians) around the axis (<paramref name="x"/>, <paramref name="y"/>, <paramref name="z"/>).</summary>
		///
		/// <example>
		/// <code language="yaml">
		/// tags: [code/factory, code/projective_geometric_algebra]
		/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
		/// facets: {layer: domain, status: stable, complexity: 1}
		/// </code>
		/// </example>
		public static Pga3D Rotor(double angle, double x, double y, double z) {
			var sinCos = (angle * 0.5).SinCos();
			var sin = sinCos.sin / Math.Sqrt(x * x + y * y + z * z);
			return new Pga3D(AxisRot._1_.AsBlade(sinCos.cos),
				  AxisRot.X.AsBlade(x * sin),
				  AxisRot.Y.AsBlade(y * sin),
				  AxisRot.Z.AsBlade(z * sin));
		}

		/// <inheritdoc cref="Motor(double,Pga3D)"/>
		public static Pga3D Translator(double dist, Pga3D idealLine) => 1 + dist * 0.5 * idealLine;

		/// <inheritdoc cref="Motor(double,double,double)"/>
		public static Pga3D Translator(double xHalf, double yHalf = 0, double zHalf = 0) 
			=> new(AxisTrans._1_.AsBlade()
			, AxisTrans.X.AsBlade(xHalf), AxisTrans.Y.AsBlade(yHalf), AxisTrans.Z.AsBlade(zHalf));

		/// <summary> AKA <see cref="Translator(double,Pga3D)"/>; translates <paramref name="dist"/> along the <paramref name="axisTrans"/>/Vector
		/// when using the Sandwich Product </summary>
		/// <remarks>
		/// The Axis must be a Vector (ideal Line), i.e. any linear Combination of <see cref="AxisTrans"/> Elements.
		/// </remarks>
		/// <example>
		/// <code language="yaml">
		/// tags: [code/factory, code/projective_geometric_algebra]
		/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
		/// facets: {layer: domain, status: stable, complexity: 1}
		/// </code>
		/// </example>
		public static Pga3D Motor(double dist, Pga3D axisTrans) => Translator(dist, axisTrans);

		/// <summary> Generates a Motor/Vector that translates 
		/// by twice (<paramref name="xHalf"/>,<paramref name="yHalf"/>,<paramref name="zHalf"/>) on Sandwiching</summary>
		///
		/// <example>
		/// <code language="yaml">
		/// tags: [code/factory, code/projective_geometric_algebra]
		/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
		/// facets: {layer: domain, status: stable, complexity: 1}
		/// </code>
		/// </example>
		public static Pga3D Motor(double xHalf, double yHalf, double zHalf) => Translator(xHalf, yHalf, zHalf);

		/// <summary> Line given by <paramref name="slope"/> and <paramref name="intersect"/> </summary>
		/// <remarks>
		/// Lines are Grade 1 Vectors and operate as Reflectors
		/// with themselves as Fixed-Points.
		/// All Points with the same normalized Coordinates are equivalent!
		/// </remarks>
		/// <example>
		/// <code language="yaml">
		/// tags: [code/factory, code/projective_geometric_algebra]
		/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
		/// facets: {layer: domain, status: stable, complexity: 1}
		/// </code>
		/// </example>
		public static Pga3D Line(double slope, double intersect)
			=> new(0, (float) intersect, (float) slope, -1, 0, 0, 0, 0);

		/// <summary> Line given by Point and Slope/Direction </summary>
		///
		/// <example>
		/// <code language="yaml">
		/// tags: [code/factory, code/projective_geometric_algebra]
		/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
		/// facets: {layer: domain, status: stable, complexity: 1}
		/// </code>
		/// </example>
		public static Pga3D Line(double slope, double y, double x)
			=> Line(slope, y - x * slope);

		/// <summary>Line given by 2 Points</summary>
		///
		/// <example>
		/// <code language="yaml">
		/// tags: [code/factory, code/projective_geometric_algebra]
		/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
		/// facets: {layer: domain, status: stable, complexity: 1}
		/// </code>
		/// </example>
		public static Pga3D Line(double x0, double y0, double x1, double y1) {
			var slope = (y1 - y0) / (x1 - x0);
			return Line(slope, y0, x0);
		}

		/// <summary> Plane given by <paramref name="slope"/> and <paramref name="intersect"/> </summary>
		/// <remarks>
		/// Planes are Grade 1 Vectors and operate as Reflectors
		/// with themselves as Fixed-Points.
		/// All Points with the same normalized Coordinates are equivalent!
		/// </remarks>
		/// <example>
		/// <code language="yaml">
		/// tags: [code/factory, code/projective_geometric_algebra]
		/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
		/// facets: {layer: domain, status: stable, complexity: 1}
		/// </code>
		/// </example>
		// ReSharper disable once MemberHidesStaticFromOuterClass
		public static Pga3D Plane(double slope, double intersect)
			=> new(0, (float) intersect, (float) slope, -1, 0, 0, 0, 0);

		/// <summary> Plane given by Point and Normal </summary>
		///
		/// <example>
		/// <code language="yaml">
		/// tags: [code/factory, code/projective_geometric_algebra]
		/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
		/// facets: {layer: domain, status: stable, complexity: 1}
		/// </code>
		/// </example>
		// ReSharper disable once MemberHidesStaticFromOuterClass
		public static Pga3D Plane(double slope, double y, double x)
			=> Plane(slope, y - x * slope);

		/*// <summary> Plane given by 3 Points </summary>
		// ReSharper disable once MemberHidesStaticFromOuterClass
		public static Pga3D Plane(double x0, double y0, double x1, double y1, double x2, double y2) {
			var slope = (y1 - y0) / (x1 - x0);
			return Plane(slope, y0, x0);
		}*/

		// for our toy problem (generate points on the surface of a torus)
		// we start with a function that generates motors.
		// circle(t) with t going from 0 to 1.
		/// <summary> Returns a motor that places a point at <paramref name="radius"/> along the X-axis after rotating by <paramref name="t"/> full turns around <paramref name="line"/>. </summary>
		///
		/// <example>
		/// <code language="yaml">
		/// tags: [code/factory, code/projective_geometric_algebra]
		/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
		/// facets: {layer: domain, status: stable, complexity: 1}
		/// </code>
		/// </example>
		public static Pga3D Circle(float t, float radius, Pga3D line) {
			return Rotor(t * 2 * Math.PI, line)
			       * Translator(radius, AxisTrans.X);
		}

		/// <summary>Ideal Line.</summary>
		///
		/// <example>
		/// <code language="yaml">
		/// tags: [code/unit_test, code/projective_geometric_algebra]
		/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
		/// facets: {layer: test, status: stable, complexity: 1}
		/// </code>
		/// </example>
		[Test]
		public static void IdealLine() {
			var idealLine = (Pga3D)Planes.YZ * (Pga3D)Planes.Dist;
			_ = idealLine.ShouldBe(AxisTrans.X);
		}

		/// <summary>Returns the motor that places a point on a torus formed by composing two circles with radii <paramref name="r1"/> and <paramref name="r2"/>.</summary>
		///
		/// <example>
		/// <code language="yaml">
		/// tags: [code/factory, code/projective_geometric_algebra]
		/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
		/// facets: {layer: domain, status: stable, complexity: 1}
		/// </code>
		/// </example>
		public static Pga3D Torus(float s, float t, float r1, Pga3D l1, float r2, Pga3D l2)
			=> Circle(s, r2, l2) * Circle(t, r1, l1);

		/// <summary> Constructs 3D Bodies around a Rotation Axis like a Lathe </summary>
		/// <param name="points">the points to rotate</param>
		/// <param name="numSegments">number of Rotation-Segments </param>
		/// <param name="axisRot">rotation Axis from <see cref="AxisRot"/></param>
		/// <param name="arc">arc-Length in Pi from [0..1]</param>
		/// <example>
		/// <code language="yaml">
		/// tags: [code/factory, code/mesh_data, code/projective_geometric_algebra]
		/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
		/// facets: {layer: graphics, status: stable, complexity: 2}
		/// </code>
		/// </example>
		public static IEnumerable<IEnumerable<Pga3D>> Lathe(IEnumerable<Pga3D> points, int numSegments, Pga3D axisRot, double arc = 1) => Enumerable
				.Range(0, numSegments+1).Select((_, i) => Rot(i* Math.PI*arc/numSegments,axisRot) < points);//.ToArray();

		/// <inheritdoc cref="Lathe(IEnumerable{Pga3D},int,Pga3D,double)"/>
		public static IEnumerable<Pga3D> Lathe(Pga3D point, int numSegments, Pga3D axisRot, double arc = 1) => Enumerable
				.Range(0, numSegments+1).Select((_, i) => Rot(i* Math.PI*arc/numSegments,axisRot) < point);//.ToArray();

/*/ wrap takes X, a double array of points, and generates triangles.    
		public static Pga3D wrap(Pga3D[][] X) {
			var u = X.Length - 1;
			var v = X[0].Length - 1;
			X = []. concat.apply([],X);
			var P = new List<Pga3D>();
			var vp = v + 1;
			for (var i = 0; i < u * vp; i += vp)
			for (var j = 0; j < v; j++)
				P.push([i + j, i + j + 1, vp + i + j],
				[i +j + 1,vp + i + j,vp + i + j + 1]);
			return P.map(x => x.map(x => X[x]));
		}*/

		/// <summary>Square root of 2, used as a scaling factor for cube spine heights.</summary>
		public static readonly double SqRtTwo = Math.Sqrt(2);
		/// <summary>Square root of 0.5 (= 1/√2), used as a scaling factor for cube spine coordinates.</summary>
		public static readonly double SqRtHalf = Math.Sqrt(0.5);

		/// <summary>Test Dual.</summary>
		///
		/// <example>
		/// <code language="yaml">
		/// tags: [code/unit_test, code/projective_geometric_algebra]
		/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
		/// facets: {layer: test, status: stub, complexity: 1}
		/// </code>
		/// </example>
		// TODO: LOGIC bug - computes dual and dual2 but asserts nothing; this test verifies no behavior.
		public static void TestDual() {
			var dual = !(E0 + 3 * E3);
			var dual2 = !(E0 + 3 * E3);

		}

		/// <summary> Generates the outer Cylinder Mesh; degenerates to a Cube for <paramref name="numSegments"/> = 4 </summary>
		///
		/// <example>
		/// <code language="yaml">
		/// tags: [code/factory, code/mesh_data, code/projective_geometric_algebra]
		/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
		/// facets: {layer: graphics, status: stable, complexity: 1}
		/// </code>
		/// </example>
		public static IEnumerable<IEnumerable<Pga3D>> Cylinder(double radius = 1, double height = 1, int numSegments = 32)
			=> Lathe(new []{!E0, !(E0 + radius*E3),!(E0+radius*E3+height*E1),!(E0+height*E1)},numSegments,E23);

		/// <summary> Spines of a Cube with Height = √2, not its Sides! </summary>
		/// <remarks>
		/// The Diagonals between the Spines form the Cube's Sides.
		/// </remarks>
		public static readonly float[][][] CubeSpineCoords = {
			new[] { new[] {0,0,0f}, new[] {0,0,1f}, new[] {1.41421354f,0,1}, new[] {1.41421354f,0,0}}, 
			new[] { new[] {0,0,0f}, new[] {0,-0.99999994f,0}, new[] {1.41421342f,-0.99999994f,0}, new[] {1.41421342f,0,0}}, 
			new[] { new[] {0,0,0f}, new[] {0,-1.22460635E-16f,-1}, new [] {1.41421354f,-1.22460635E-16f,-1}, new[] {1.41421354f,0,0}}, 
			new[] { new[] {0,0,0f}, new[] {0,0.99999994f,0}, new [] {1.41421342f,0.99999994f,0}, new[] {1.41421342f,0,0}}, 
			new[] { new[] {0,0,0f}, new[] {0,2.44921271E-16f,1}, new[] {1.41421354f,2.44921271E-16f,1}, new[] {1.41421354f,0,0}}
		};

		/// <summary> Spines of a Cube with Height = 1 rotated around the X-Axis from 0 to +1, (not its Sides!) </summary>
		/// <remarks>
		/// The Diagonals between the Spines form the Cube's Sides of Length 1.
		/// </remarks>
		public static readonly float[][][] CubeSpineCoords2 = {
			new[] { new[] {0, 0, 0f}, new[] {0, 0, 0.707106769f}, new[] {1, 0, 0.707106769f}, new[] {1, 0, 0f}},
			new[] { new[] {0, 0, 0f}, new[] {0,-.7071067f,0}, new[] {.99999994f,-0.7071067f,0}, new[] {.99999994f,0,0}},
			new[] { new[] {0, 0, 0f}, new[] {0,-8.659275E-17f,-0.707106769f}, new[] {1,-8.659275E-17f,-0.707106769f}, new[] {1,0,0f}},
			new[] { new[] {0, 0, 0f}, new[] {0, .7071067f,0}, new[] {.99999994f,0.7071067f,0}, new[] {.99999994f,0,0}},
			new[] { new[] {0, 0, 0f}, new[] {0, 1.731855E-16f,0.707106769f}, new[] {1,1.731855E-16f,0.707106769f}, new[] {1,0,0f}}
		};

		/// <summary> NUnit test-case source providing expected <see cref="CubeSpineCoords2"/> for <see cref="CubePoints"/>. </summary>
		///
		/// <example>
		/// <code language="yaml">
		/// tags: [code/nunit_test_case_inversion, code/projective_geometric_algebra]
		/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
		/// facets: {layer: test, status: stable, complexity: 1}
		/// </code>
		/// </example>
		public static IEnumerable<TestCaseData> TestCubeSpineCoords {
			get {
				yield return new TestCaseData(1) {ExpectedResult = CubeSpineCoords2};
			}
		}

		/// <summary>Cube Points.</summary>
		///
		/// <example>
		/// <code language="yaml">
		/// tags: [code/unit_test, code/projective_geometric_algebra]
		/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
		/// facets: {layer: test, status: stable, complexity: 1}
		/// </code>
		/// </example>
		[TestCaseSource(nameof(TestCubeSpineCoords))]
		public static float[][][] CubePoints(double r) {
			var ret = Cube(r).Select(row => row.Select(col => col.AsPoint()).ToArray()).ToArray();
			//return ret.ToDebugString()
			//ret.AsJson();
			//var str = ret.AsCSharpCode();
			return ret;
		}

		/// <summary> Generates the 4 'Spines' of a Cube, around the X-Symmetry-Axis. </summary>
		/// <remarks>The Spine-Diagonals to the Corners are √2 shorter
		/// than the resulting Cube-<paramref name="width"/>, therefore the height is adjusted.
		/// </remarks>
		/// <example>
		/// <code language="yaml">
		/// tags: [code/factory, code/mesh_data, code/projective_geometric_algebra]
		/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
		/// facets: {layer: graphics, status: stable, complexity: 1}
		/// </code>
		/// </example>
		public static IEnumerable<IEnumerable<Pga3D>> Cube(double width) => Cylinder(width*SqRtHalf, width
			, 4);

		/// <summary> Generates a Torus Mesh; degenerates to a solid Polygon Line for small <paramref name="numLargeToroidal"/> </summary>
		///
		/// <example>
		/// <code language="yaml">
		/// tags: [code/factory, code/mesh_data, code/projective_geometric_algebra]
		/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
		/// facets: {layer: graphics, status: stable, complexity: 2}
		/// </code>
		/// </example>
		public static IEnumerable<IEnumerable<Pga3D>> Torus(double r=.3
			, double r2=.25, int numLargeToroidal = 32, int numSmallPoloidal = 16) {
			var circle = Lathe(!(E0 + (E1 + E3) * r2 * SqRtHalf), numSmallPoloidal, E31);
			return Lathe(1 + r * .5 * E03 < circle, numLargeToroidal, E23);
			//return Lathe(Pga3D.New( 1 + r * .5 * E03 < circle, numLargeToroidal, E23);
		}

		/// <summary> Generates a Sphere Mesh; degenerates to a double Pyramid for <paramref name="numMeridian"/> = 2 </summary>
		///
		/// <example>
		/// <code language="yaml">
		/// tags: [code/factory, code/mesh_data, code/projective_geometric_algebra]
		/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
		/// facets: {layer: graphics, status: stable, complexity: 2}
		/// </code>
		/// </example>
		public static IEnumerable<IEnumerable<Pga3D>> Sphere(double r = 1, int numEquator = 32, int numMeridian = 16) {
			var halfCircle = Lathe(!(E0 + r * E1), numMeridian, E31, .5);
			return Lathe(halfCircle, numEquator, E23);
		}

		/// <summary> Generates a Cone/Pyramid Mesh; degenerates to a Tetrahedron for <paramref name="numSegments"/> = 3 </summary>
		///
		/// <example>
		/// <code language="yaml">
		/// tags: [code/factory, code/mesh_data, code/projective_geometric_algebra]
		/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
		/// facets: {layer: graphics, status: stable, complexity: 1}
		/// </code>
		/// </example>
		public static IEnumerable<IEnumerable<Pga3D>> Cone(double r=1, double h=1, int numSegments=64)
			=>Lathe(new []{!E0,!(E0+r*E3),!(E0+h*E1)}, numSegments, E23);

		/// <summary> Generates a regular Tetrahedron mesh with circumradius <paramref name="r"/> as a degenerate 3-segment Cone. </summary>
		///
		/// <example>
		/// <code language="yaml">
		/// tags: [code/factory, code/mesh_data, code/projective_geometric_algebra]
		/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
		/// facets: {layer: graphics, status: stable, complexity: 1}
		/// </code>
		/// </example>
		public static IEnumerable<IEnumerable<Pga3D>> Tetrahedron(double r) => Cone(r,r*SqRtTwo,3);

		/// <summary> Generates an Arrow mesh composed of a cone tip, an inverted cone base, and a cylinder shaft. </summary>
		///
		/// <example>
		/// <code language="yaml">
		/// tags: [code/factory, code/mesh_data, code/projective_geometric_algebra]
		/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
		/// facets: {layer: graphics, status: stable, complexity: 1}
		/// </code>
		/// </example>
		public static IEnumerable<IEnumerable<Pga3D>> Arrow()
			=> Cone(.15,.3).Concat(Cone(.15,0)).Concat(Cylinder(.05,-2));

		/// <summary>Pre-built sample mesh objects (arrow, tori, sphere, tetrahedron, cone, cylinder, cube) for preview rendering.</summary>
		public static IEnumerable<IEnumerable<Pga3D>>[] Objects = {
			Arrow(), Torus(0.8, .3), Sphere(.8),
			Sphere(.8,3,2), Tetrahedron(1), Cone(1,SqRtTwo,4),
			Cone(1,SqRtTwo), Torus(.8,.2,5,32), Cylinder(),
			Cube(1), Torus(.8,.3,4,4),  Torus(.8,.3,64,4)};

		/* Render and rotate them using the webGL2 previewer
	document.body.appendChild( this.graph(()=>{
		var time = performance.now()/1000;
		objs.forEach((obj,i)=>obj.transform = (1+1e0+3e03-((i%3)-1)*1.5e01-((i/3|0)-1.5)*1.5e02)*rot(time,1e12)*rot(time*0.331,1e13));
		return [0xFF0088,...objs]
	},{gl:1,animate:1}));    
*/

		/// <summary> Planet Name, Mass, Position and Speed from https://ssd.jpl.nasa.gov/horizons.cgi on 2018-01-16T00:00:00 = 1516057200s Unix Time, units KM/S  </summary>
		public static readonly object[][] Planets = {
			new object[] {"Sun"    , 1.988544E30, Point( 2.564294388666002E+05, 9.282480498916068E+05,-1.766238790604926E+04), Vector(-1.032271613682197E-02, 8.506510987745193E-03, 2.500579386306204E-04)},
			new object[] {"Mercury", 3.302E23   , Point(-4.261433008703040E+07,-5.180047961851221E+07,-3.933312499175891E+05), Vector( 2.791200817718316E+01,-2.845907905315504E+01,-4.887507665269149E+00)},
			new object[] {"Venus"  , 48.685E23  , Point( 5.357396412032661E+07,-9.395832506522638E+07,-4.396021713049673E+06), Vector( 3.028389624261208E+01, 1.704407507992616E+01,-1.514240016876114E+00)},
			new object[] {"Earth"  , 5.97219E24 , Point(-6.321181522689363E+07, 1.337035149539065E+08,-2.323422257646173E+04), Vector(-2.738214042693713E+01,-1.295254402346621E+01, 1.833826936016081E-03)},
			new object[] {"Mars"   , 6.4185E23  , Point(-2.261872038770745E+08,-8.456074820817514E+07, 3.748261255788427E+06), Vector( 9.452949401620625E+00,-2.058946931255050E+01,-6.636171336482146E-01)},
			new object[] {"Jupiter", 1898.13E24 , Point(-6.267852905434124E+08,-5.152098357372769E+08, 1.615654184230065E+07), Vector( 8.141900694513106E+00,-9.472185978646950E+00,-1.428289208967608E-01)},
		};

		/// <summary> Gravity Constant </summary>
		public static readonly double G = 6.6723E-11;
	}

	/// <inheritdoc />
	protected override double[][] Coefficients() {
		var m = new[] 
		{  new double[] {_C[00],		0, +_C[02], +_C[03], +_C[04],		0,		0,		  0, -_C[08], -_C[09], -_C[10],		0,			0,		0, -_C[14],		0,
		}, new double[] {_C[01], +_C[00],  -_C[05], -_C[06], -_C[07], +_C[02], +_C[03], +_C[04], +_C[11], +_C[12], +_C[13], +_C[08], +_C[09], +_C[10], +_C[15], -_C[14],
		}, new double[] {_C[02],		0, +_C[00], -_C[08], +_C[09],		0,		0,		  0, +_C[03], -_C[04], -_C[14],		0,			0,		0, -_C[10],		0,
		}, new double[] {_C[03],		0, +_C[08], +_C[00], -_C[10],		0,		0,		  0, -_C[02], -_C[14], +_C[04],		0,			0,		0, -_C[09],		0,
		}, new double[] {_C[04],		0, -_C[09], +_C[10], +_C[00],		0,		0,		  0, -_C[14], +_C[02], -_C[03],		0,			0,		0, -_C[08],		0,
		}, new double[] {_C[05], +_C[02],  -_C[01], -_C[11], +_C[12], +_C[00], -_C[08], +_C[09], +_C[06], -_C[07], -_C[15], -_C[03], +_C[04], +_C[14], -_C[13], -_C[10],
		}, new double[] {_C[06], +_C[03],  +_C[11], -_C[01], -_C[13], +_C[08], +_C[00], -_C[10], -_C[05], -_C[15], +_C[07], +_C[02], +_C[14], -_C[04], -_C[12], -_C[09],
		}, new double[] {_C[07], +_C[04],  -_C[12], +_C[13], -_C[01], -_C[09], +_C[10], +_C[00], -_C[15], +_C[05], -_C[06], +_C[14], -_C[02], +_C[03], -_C[11], -_C[08],
		}, new double[] {_C[08],		0, +_C[03], -_C[02], +_C[14],		0,		0,		  0, +_C[00], +_C[10], -_C[09],		0,			0,		0, +_C[04],		0,
		}, new double[] {_C[09],		0, -_C[04], +_C[14], +_C[02],		0,		0,		  0, -_C[10], +_C[00], +_C[08],		0,			0,		0, +_C[03],		0,
		}, new double[] {_C[10],		0, +_C[14], +_C[04], -_C[03],		0,		0,		  0, +_C[09], -_C[08], +_C[00],		0,			0,		0, +_C[02],		0,
		}, new double[] {_C[11], -_C[08],  +_C[06], -_C[05], +_C[15], -_C[03], +_C[02], -_C[14], -_C[01], +_C[13], -_C[12], +_C[00], +_C[10], -_C[09], +_C[07], -_C[04],
		}, new double[] {_C[12], -_C[09],  -_C[07], +_C[15], +_C[05], +_C[04], -_C[14], -_C[02], -_C[13], -_C[01], +_C[11], -_C[10], +_C[00], +_C[08], +_C[06], -_C[03],
		}, new double[] {_C[13], -_C[10],  +_C[15], +_C[07], -_C[06], -_C[14], -_C[04], +_C[03], +_C[12], -_C[11], -_C[01], +_C[09], -_C[08], +_C[00], +_C[05], -_C[02],
		}, new double[] {_C[14],		0, +_C[10], +_C[09], +_C[08],		0,		0,		  0, +_C[04], +_C[03], +_C[02],		0,			0,		0, +_C[00],		0,
		}, new double[] {_C[15], +_C[14],  +_C[13], +_C[12], +_C[11], +_C[10], +_C[09], +_C[08], +_C[07], +_C[06], +_C[05], -_C[04], -_C[03], -_C[02], -_C[01], +_C[00]
		}
		};
		return m;
	}
}
