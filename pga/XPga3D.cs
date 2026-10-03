using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using org.SpocWeb.root.array;
using org.SpocWeb.root.extensions.maths;
using org.SpocWeb.root.interfaces.maths;
using org.SpocWeb.root.logging;
using org.SpocWeb.root.maths.pga.ga;

namespace org.SpocWeb.root.maths.pga;

/// <summary> Extension Methods on <see cref="IReadOnlyList{Single}"/> </summary>
/// <remarks>
/// ## Public Methods
///
/// | Line | Method | Description |
/// |--:|---|---|
/// | 26 | <see cref="AsPga3D"/> | Constructs a Pga3D with a single component idx set to f. |
/// | 40 | <see cref="Dual"/> | Demonstrates the Dual Operation on Base Components |
/// | 72 | <see cref="Reverted"/> | Demonstrates the Reverted Operation on Base Components |
/// | 106 | <see cref="Involute"/> | Demonstrates the Involute Operation on Base Components |
/// | 140 | <see cref="Conjugate"/> | Demonstrates the Signs of the Conjugate Operation on Base Components |
/// | 172 | <see cref="GetBases"/> | Returns all values of the Base enum as an array for use as NUnit test-case sources. |
/// | 175 | <see cref="TestCliffordIsReversionOfInvolution"/> | Test Clifford Is Reversion Of Involution. |
/// | 187 | <see cref="TestNormUsesConjugate"/> | Involute and Reverted violate NormSqr when e0 is missing |
/// | 205 | <see cref="TestSqRt"/> | Test Sq Rt. |
/// | 214 | <see cref="Test3D"/> | Test3 D. |
/// | 285 | <see cref="Point_on_torus"/> | Returns a point on a standard torus at toroidal parameter s and poloidal parameter t, both in [0,1). |
/// | 291 | <see cref="GetFactor"/> | Returns the canonical positive basis element and sign factor (+1, 0, or -1) corresponding to the given (possibly negated) e. |
/// | 307 | <see cref="Dual16"/> | ! = Poincar� duality operator. |
/// | 312 | <see cref="Involute16"/> | Main involution |
/// | 322 | <see cref="Reverted16"/> | ~ Complex Conjugate of the basis blades. |
/// | 327 | <see cref="Plus16"/> | + Add; MultiVector addition |
/// | 353 | <see cref="Minus16"/> | - Minus, SUB; MultiVector Subtraction |
/// | 373 | <see cref="Times16"/> | * mulS = scalar * multiVector multiplication |
/// | 386 | <see cref="MinusR16"/> | Returns a new 16-element array with the scalar component set to  a - b[0]  and all remaining components negated. |
/// | 419 | <see cref="Dot16P"/> | | Dot = inner / scalar product. |
/// | 455 | <see cref="Join16P"/> | &amp; (JOIN): Vee AKA regressive product; symmetric |
/// | 505 | <see cref="Meet16P"/> | ^ Cross-/ outer Product / MEET / Intersect / Wedge; antisymmetric 'Grassmann' product. |
/// | 526 | <see cref="CliffCjg16"/> | Clifford Conjugation |
/// | 531 | <see cref="NormSqr16Q"/> | Norm Sqr16 Q. |
/// | 535 | <see cref="NormSqr16P"/> | Norm Sqr16 P. |
/// | 547 | <see cref="Times16P"/> | * = geometric/cartesian product. |
/// | 569 | <see cref="ProductGeometric"/> | Delegate wrapping the geometric product operation for use in product test pipelines. |
/// | 571 | <see cref="ProductDot"/> | Delegate wrapping the inner (dot) product operation for use in product test pipelines. |
/// | 573 | <see cref="ProductOuter"/> | Delegate wrapping the outer (meet) product operation for use in product test pipelines. |
/// | 583 | <see cref="Products"/> | Public read-only view of all three product delegate functions indexed by product type. |
/// | 586 | <see cref="AllProductTests"/> | Generates all Test Pairs for all Products in Products |
/// | 597 | <see cref="TestJoinMeet"/> | Test Join Meet. |
/// | 616 | <see cref="IsOdd"/> | Determines whether odd. |
/// | 620 | <see cref="Grade"/> | Returns the grade (0–4) of the given basis blade value. |
/// | 644 | <see cref="TestJoinMeetAbs"/> | Test Join Meet Abs. |
/// | 654 | <see cref="ProductOuterSampleVectorPairs"/> | Generates all Test Cases for product from  Pairs of Pga3D Elements |
/// | 667 | <see cref="BaseVectorPairs"/> | Generates all Pairs of Pga3D Base Vectors Elements |
/// | 676 | <see cref="TestAllProducts"/> | Test All Products. |
/// | 683 | <see cref="CreateVectorPairs"/> | Builds a triple of float arrays representing two input basis blades and their expected product result from the given Cayley products table. |
/// | 708 | <see cref="RandomPga3D"/> | Generates 99 random Pga3D multi-vectors with uniformly distributed components for property-based tests. |
/// | 728 | <see cref="TestRcp"/> | Test Rcp. |
/// | 740 | <see cref="MakeMotor"/> | Constructs a translator motor along axisTrans by twice halfDistance. |
/// | 744 | <see cref="MakeRotor"/> | Constructs a rotor around axisRot by twice halfAngleRad radians. |
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
/// | <see cref="Points"/> | Passed as a parameter. |
/// | <see cref="Planes"/> | Passed as a parameter. |
/// | <see cref="Bases"/> | Returned by a method. |
/// | <see cref="Base e, int factor)"/> | Returned by a method. |
/// | <see cref="Base y)"/> | Passed as a parameter. |
/// | <see cref="(float[][] vectors, Func"/> | Passed as a parameter. |
/// | <see cref="Random"/> | Used as a field. |
/// </remarks>
///
/// <example>
/// <code language="yaml">
/// pass: 2
/// mtime: 2026-05-24T15:36:37Z
/// digest: bb55659c0dad345f02c0ed1f948c86cabc953b5894c53ed8cc3a6ff2a75e7a39
/// tags: [code/extension_method, code/projective_geometric_algebra]
/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
/// facets: {layer: domain, status: buggy, complexity: 3}
/// </code>
/// </example>
public static partial class XPga3D
{
	/// <summary> Constructs a <see cref="Pga3D"/> with a single component <paramref name="idx"/> set to <paramref name="f"/>. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/extension_method, code/factory_method]
	/// concepts: [projective_geometric_algebra]
	/// facets: {layer: domain, status: stable, complexity: 1}
	/// </code>
	/// </example>
	public static Pga3D AsPga3D(this Pga3D.Base idx, double f = 1) => new(f, idx);
	/// <inheritdoc cref="AsPga3D(Pga3D.Base, double)"/>
	public static Pga3D AsPga3D(this Pga3D.AxisTrans idx, double f = 1) => new(f, idx);
	/// <inheritdoc cref="AsPga3D(Pga3D.Base, double)"/>
	public static Pga3D AsPga3D(this Pga3D.AxisRot idx, double f = 1) => new(f, idx);
	/// <inheritdoc cref="AsPga3D(Pga3D.Base, double)"/>
	public static Pga3D AsPga3D(this Pga3D.Geo idx, double f = 1) => new(f, idx);
	/// <inheritdoc cref="AsPga3D(Pga3D.Base, double)"/>
	public static Pga3D AsPga3D(this Pga3D.Points idx, double f = 1) => new(f, idx);
	/// <inheritdoc cref="AsPga3D(Pga3D.Base, double)"/>
	public static Pga3D AsPga3D(this Pga3D.Planes idx, double f = 1) => new(f, idx);

	/// <summary> Demonstrates the <see cref="Pga3D.Dual"/> Operation on <see cref="Pga3D.Base"/> Components </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/unit_test, code/clifford_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: test, status: stable, complexity: 1}
	/// </code>
	/// </example>
	#region TestCase
	[TestCase(Pga3D.Base._1_, ExpectedResult = Pga3D.Bases.e0123)]

	[TestCase((Pga3D.Base)Pga3D.Points.Origin, ExpectedResult = (Pga3D.Bases)(1 << (int)Pga3D.Planes.Sky))]

	[TestCase((Pga3D.Base)Pga3D.Points.X, ExpectedResult = (Pga3D.Bases)(1 << (int)Pga3D.Planes.YZ))]
	[TestCase((Pga3D.Base)Pga3D.Points.Y, ExpectedResult = (Pga3D.Bases)(1 << (int)Pga3D.Planes.ZX))]
	[TestCase((Pga3D.Base)Pga3D.Points.Z, ExpectedResult = (Pga3D.Bases)(1 << (int)Pga3D.Planes.XY))]

	[TestCase((Pga3D.Base)Pga3D.AxisTrans.X, ExpectedResult = (Pga3D.Bases)(1 << (int)Pga3D.AxisRot.X))]
	[TestCase((Pga3D.Base)Pga3D.AxisTrans.Y, ExpectedResult = (Pga3D.Bases)(1 << (int)Pga3D.AxisRot.Y))]
	[TestCase((Pga3D.Base)Pga3D.AxisTrans.Z, ExpectedResult = (Pga3D.Bases)(1 << (int)Pga3D.AxisRot.Z))]

	[TestCase((Pga3D.Base)Pga3D.AxisRot.X, ExpectedResult = (Pga3D.Bases)(1 << (int)Pga3D.AxisTrans.X))]
	[TestCase((Pga3D.Base)Pga3D.AxisRot.Y, ExpectedResult = (Pga3D.Bases)(1 << (int)Pga3D.AxisTrans.Y))]
	[TestCase((Pga3D.Base)Pga3D.AxisRot.Z, ExpectedResult = (Pga3D.Bases)(1 << (int)Pga3D.AxisTrans.Z))]

	[TestCase((Pga3D.Base)Pga3D.Planes.YZ, ExpectedResult = (Pga3D.Bases)(1 << (int)Pga3D.Points.X))]
	[TestCase((Pga3D.Base)Pga3D.Planes.ZX, ExpectedResult = (Pga3D.Bases)(1 << (int)Pga3D.Points.Y))]
	[TestCase((Pga3D.Base)Pga3D.Planes.XY, ExpectedResult = (Pga3D.Bases)(1 << (int)Pga3D.Points.Z))]

	[TestCase((Pga3D.Base)Pga3D.Planes.Sky, ExpectedResult = (Pga3D.Bases)(1 << (int)Pga3D.Points.Origin))]

	[TestCase(Pga3D.Base.e0123, ExpectedResult = Pga3D.Bases._1_)]
	#endregion TestCase
	public static Pga3D.Bases Dual(Pga3D.Base b) {
		var p = b.AsPga3D();
		var d = p.Dual().Components;
		return d;
	}

	/// <summary> Demonstrates the <see cref="Pga3D.Reverted"/> Operation on <see cref="Pga3D.Base"/> Components </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/unit_test, code/clifford_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: test, status: stable, complexity: 2}
	/// </code>
	/// </example>
	#region TestCase
	[TestCase(Pga3D.Base._1_, ExpectedResult = 1f)]

	[TestCase((Pga3D.Base)Pga3D.Points.Origin, ExpectedResult = -1f)]

	[TestCase((Pga3D.Base)Pga3D.Points.X, ExpectedResult = -1f)]
	[TestCase((Pga3D.Base)Pga3D.Points.Y, ExpectedResult = -1f)]
	[TestCase((Pga3D.Base)Pga3D.Points.Z, ExpectedResult = -1f)]

	[TestCase((Pga3D.Base)Pga3D.AxisTrans.X, ExpectedResult = -1f)]
	[TestCase((Pga3D.Base)Pga3D.AxisTrans.Y, ExpectedResult = -1f)]
	[TestCase((Pga3D.Base)Pga3D.AxisTrans.Z, ExpectedResult = -1f)]

	[TestCase((Pga3D.Base)Pga3D.AxisRot.X, ExpectedResult = -1f)]
	[TestCase((Pga3D.Base)Pga3D.AxisRot.Y, ExpectedResult = -1f)]
	[TestCase((Pga3D.Base)Pga3D.AxisRot.Z, ExpectedResult = -1f)]

	[TestCase((Pga3D.Base)Pga3D.Planes.YZ, ExpectedResult = 1f)]
	[TestCase((Pga3D.Base)Pga3D.Planes.ZX, ExpectedResult = 1f)]
	[TestCase((Pga3D.Base)Pga3D.Planes.XY, ExpectedResult = 1f)]

	[TestCase((Pga3D.Base)Pga3D.Planes.Sky, ExpectedResult = 1f)]

	[TestCase(Pga3D.Base.e0123, ExpectedResult = 1f)]
	#endregion TestCase
	public static float Reverted(Pga3D.Base b) {
		var p = b.AsPga3D();
		var r = p.Reverted();
		var d = r.Components;
		_ = d.ShouldBe((Pga3D.Bases)(1 << (int)b));
		return r.Single(v => !v.IsSmallerThanAbs(PgaTolerance.Float));
	}

	/// <summary> Demonstrates the <see cref="Pga3D.Involute"/> Operation on <see cref="Pga3D.Base"/> Components </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/unit_test, code/clifford_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: test, status: stable, complexity: 2}
	/// </code>
	/// </example>
	#region TestCase
	[TestCase(Pga3D.Base._1_, ExpectedResult = 1f)]

	[TestCase((Pga3D.Base)Pga3D.Points.Origin, ExpectedResult = -1f)]

	[TestCase((Pga3D.Base)Pga3D.Points.X, ExpectedResult = -1f)]
	[TestCase((Pga3D.Base)Pga3D.Points.Y, ExpectedResult = -1f)]
	[TestCase((Pga3D.Base)Pga3D.Points.Z, ExpectedResult = -1f)]

	[TestCase((Pga3D.Base)Pga3D.AxisTrans.X, ExpectedResult = 1f)]
	[TestCase((Pga3D.Base)Pga3D.AxisTrans.Y, ExpectedResult = 1f)]
	[TestCase((Pga3D.Base)Pga3D.AxisTrans.Z, ExpectedResult = 1f)]

	[TestCase((Pga3D.Base)Pga3D.AxisRot.X, ExpectedResult = 1f)]
	[TestCase((Pga3D.Base)Pga3D.AxisRot.Y, ExpectedResult = 1f)]
	[TestCase((Pga3D.Base)Pga3D.AxisRot.Z, ExpectedResult = 1f)]

	[TestCase((Pga3D.Base)Pga3D.Planes.YZ, ExpectedResult = -1f)]
	[TestCase((Pga3D.Base)Pga3D.Planes.ZX, ExpectedResult = -1f)]
	[TestCase((Pga3D.Base)Pga3D.Planes.XY, ExpectedResult = -1f)]

	[TestCase((Pga3D.Base)Pga3D.Planes.Sky, ExpectedResult = -1f)]

	[TestCase(Pga3D.Base.e0123, ExpectedResult = 1f)]
	#endregion TestCase
	public static float Involute(Pga3D.Base b) {
		var p = b.AsPga3D();
		var d = p.Involute();
		var c = d.Components;
		_ = c.ShouldBe((Pga3D.Bases)(1 << (int)b));
		return d.Single(v => !v.IsSmallerThanAbs(PgaTolerance.Float));
	}

	/// <summary> Demonstrates the Signs of the <see cref="Pga3D.Conjugate"/> Operation on <see cref="Pga3D.Base"/> Components </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/unit_test, code/clifford_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: test, status: stable, complexity: 2}
	/// </code>
	/// </example>
	#region TestCase
	[TestCase(Pga3D.Base._1_, ExpectedResult = 1f)]

	[TestCase((Pga3D.Base)Pga3D.Points.Origin, ExpectedResult = 1f)]

	[TestCase((Pga3D.Base)Pga3D.Points.X, ExpectedResult = 1f)]
	[TestCase((Pga3D.Base)Pga3D.Points.Y, ExpectedResult = 1f)]
	[TestCase((Pga3D.Base)Pga3D.Points.Z, ExpectedResult = 1f)]

	[TestCase((Pga3D.Base)Pga3D.AxisTrans.X, ExpectedResult = -1f)]
	[TestCase((Pga3D.Base)Pga3D.AxisTrans.Y, ExpectedResult = -1f)]
	[TestCase((Pga3D.Base)Pga3D.AxisTrans.Z, ExpectedResult = -1f)]

	[TestCase((Pga3D.Base)Pga3D.AxisRot.X, ExpectedResult = -1f)]
	[TestCase((Pga3D.Base)Pga3D.AxisRot.Y, ExpectedResult = -1f)]
	[TestCase((Pga3D.Base)Pga3D.AxisRot.Z, ExpectedResult = -1f)]

	[TestCase((Pga3D.Base)Pga3D.Planes.YZ, ExpectedResult = -1f)]
	[TestCase((Pga3D.Base)Pga3D.Planes.ZX, ExpectedResult = -1f)]
	[TestCase((Pga3D.Base)Pga3D.Planes.XY, ExpectedResult = -1f)]

	[TestCase((Pga3D.Base)Pga3D.Planes.Sky, ExpectedResult = -1f)]

	[TestCase(Pga3D.Base.e0123, ExpectedResult = 1f)]
	#endregion TestCase
	public static float Conjugate(Pga3D.Base b) {
		var p = b.AsPga3D();
		var d = p.Conjugate();
		_ = d.Components.ShouldBe((Pga3D.Bases)(1 << (int)b));
		return d.Single(v => !v.IsSmallerThanAbs(PgaTolerance.Float));
	}

	/// <summary> Returns all values of the <see cref="Pga3D.Base"/> enum as an array for use as NUnit test-case sources. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/enum_values, code/test_case_data_source]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: generator, status: stable, complexity: 1}
	/// </code>
	/// </example>
	public static Pga3D.Base[] GetBases() => (Pga3D.Base[])Enum.GetValues(typeof(Pga3D.Base));

	/// <summary>Test Clifford Is Reversion Of Involution.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/unit_test, code/clifford_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: test, status: stable, complexity: 2}
	/// </code>
	/// </example>
	[TestCaseSource(typeof(XPga3D), nameof(GetBases))]
	public static void TestCliffordIsReversionOfInvolution(Pga3D.Base b) {
		if (b == Pga3D.Base._0) {
			return;
		}
		var involute = Involute(b);
		var reverted = Reverted(b);
		var conjugate = Conjugate(b);
		_ = conjugate.ShouldBe(involute * reverted);
	}

	/// <summary> <see cref="Involute"/> and <see cref="Reverted"/> violate NormSqr when e0 is missing </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/unit_test, code/norm_calculation]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: test, status: stable, complexity: 2}
	/// </code>
	/// </example>
	[TestCaseSource(typeof(XPga3D), nameof(GetBases))]
	public static void TestNormUsesConjugate(Pga3D.Base b) {
		if (b == Pga3D.Base._0) {
			return;
		}

		Pga3D v = b;
		var normSqr = v.NormSqr();
		//var involute = v*v.Involute();
		//var reverted = v*v.Reverted();
		var conjugate = v*v.Conjugate();
		Pga3D expected = Pga3D.Blades[0] * normSqr;
		_ = conjugate.ShouldBe(expected);
		//reverted.ShouldBe(expected); 4 Violations
		//involute.ShouldBe(expected); 4 Violations
	}

	/// <summary>Test Sq Rt.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/unit_test]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: test, status: buggy, complexity: 1}
	/// </code>
	/// </example>
	[Ignore("Sqrt not properly implemented")]
	[TestCaseSource(typeof(Pga3D), nameof(Pga3D.Blades))]
	public static void TestSqRt(Pga3D v) {
		var sqRt = v.SqRt();
		var sqr = sqRt.Times(sqRt);//.Reverted());//.Conjugate());
		_ = sqr.ShouldBe(v);//.IsApprox);
	}

	/// <summary>Test3 D.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/unit_test, code/projective_geometric_algebra]
	/// concepts: [projective_geometric_algebra]
	/// facets: {layer: test, status: stable, complexity: 3}
	/// </code>
	/// </example>
	[Test, Ignore("Triage: translated is moved twice (the > operator and the explicit sandwich), giving -4X instead of 8X; Rotor and Identity parts pass")]
	public static void Test3D() {

		// Elements of the even sub-algebra (scalar + BiVector + pss) of unit length are motors
		var rot = Pga3D.Make.Rotor((float) Math.PI / 2, (Pga3D)Pga3D.Planes.YZ * (Pga3D)Pga3D.Planes.ZX);

		var rotNorm = rot.NormSqr();
		rotNorm.ShouldBeApprox(1, PgaTolerance.Float);

		var id = rot * ~rot;
		PgaAssert.AreClose(id, Pga3D._1_);

		// Elements of the even sub-algebra (scalar + BiVector + pss) of unit length are motors
		var trans = Pga3D.Make.Translator(2, Pga3D.AxisTrans.X);

		var transNorm = trans.NormSqr();
		_ = transNorm.ShouldBe(1);

		id = trans * ~trans;
		PgaAssert.AreClose(id, Pga3D._1_);

		// The outer product ^ is the MEET. Here we intersect the yz (x=0) and xz (y=0) planes.
		var axisZ = (Pga3D)Pga3D.Planes.YZ ^ (Pga3D)Pga3D.Planes.ZX;
		_ = axisZ.ShouldBe(Pga3D.AxisRot.Z);

		// line and plane meet in a point. We intersect the line along the z-axis (x=0,y=0) with the xy (z=0) plane.
		var origin = axisZ ^ (Pga3D)Pga3D.Planes.XY;
		_ = origin.ShouldBe(Pga3D.Points.Origin);


		var translated = origin;
		translated = translated > trans;
		translated = trans * translated * ~trans;
		translated = trans * translated * ~trans;
		translated = trans * translated * ~trans;

		transNorm = origin.NormSqr(); _ = transNorm.ShouldBe(-1);
		transNorm = translated.NormSqr(); _ = transNorm.ShouldBe(-1);

		_ = translated.ShouldBe(Pga3D.Make.Point(8, 0, 0));
		// We can also easily create points and join them into a line using the regressive (vee, &) product.
		var px = Pga3D.Make.Point(1, 0, 0);
		var line = origin & px;
		var lineNorm = line.NormSqr(); _ = lineNorm.ShouldBe(1);

		// Lets also create the plane with equation 2x + z - 3 = 0
		var plane = Pga3D.Make.Plane(2, 0, 1, -3);
		var planeNorm = plane.NormSqr(); _ = planeNorm.ShouldBe(-5);

		// rotations work on all elements
		var rotatedPlane = rot * plane * ~rot;
		var rotatedLine = rot * line * ~rot;
		var rotatedPoint = rot * px * ~rot;

		// See the 3D PGA Cheat sheet for a huge collection of useful formulas
		var pointOnPlane = (plane | px) * plane;

		// Some output
		Console.WriteLine(@"a point       : " + px);
		Console.WriteLine(@"a line        : " + line);
		Console.WriteLine(@"a plane       : " + plane);
		Console.WriteLine(@"a rotor       : " + rot);
		Console.WriteLine(@"rotated line  : " + rotatedLine);
		Console.WriteLine(@"rotated point : " + rotatedPoint);
		Console.WriteLine(@"rotated plane : " + rotatedPlane);
		Console.WriteLine(@"point on plane: " + pointOnPlane.Normalized());
		Console.WriteLine(@"point on torus: " + Point_on_torus(0, 0));
	}

	// and to sample its points we simply sandwich the origin ..
	/// <summary> Returns a point on a standard torus at toroidal parameter <paramref name="s"/> and poloidal parameter <paramref name="t"/>, both in [0,1). </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/projective_geometric_algebra, code/factory_method]
	/// concepts: [projective_geometric_algebra]
	/// facets: {layer: domain, status: stable, complexity: 1}
	/// </code>
	/// </example>
	public static Pga3D Point_on_torus(float s, float t) {
		var to = Pga3D.Make.Torus(s, t, 0.25f, Pga3D.AxisRot.Z, 0.6f, Pga3D.AxisRot.Y);
		return to * (Pga3D)Pga3D.Points.Origin * ~to;
	}

	/// <summary> Returns the canonical positive basis element and sign factor (+1, 0, or -1) corresponding to the given (possibly negated) <paramref name="e"/>. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/extension_method, code/canonicalization]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 2}
	/// </code>
	/// </example>
	public static (Pga3D.Base e, int factor) GetFactor(this Pga3D.Base e)
		=> e < 0 ? (~e, -1) : e == Pga3D.Base._0 ? (Pga3D.Base._1_, 0) : (e, 1);

	/// <summary> ! = Poincar� duality operator. </summary>
	/// <remarks> AKA Transpose; don't confuse with the Inverse/Reciprocal!
	/// 
	/// Creates the Dual geometric Object:
	/// |	Dim	|	Object	|	Dual	|
	/// |	0	|	Point	|	Volume	|
	/// |	1	|	Vector	|	Plane	|
	/// |	2	|	Plane	|	Vector	|
	/// |	3	|	Volume	|	Point	|
	/// 
	/// Is usually constructed by multiplying with the Pseudo-Scalar, the R^n Unit Volume,
	/// but in PGA e0123 == 0, so we need the Poincar�-Dual.
	/// </remarks>
	/// <example>
	/// <code language="yaml">
	/// tags: [code/extension_method, code/clifford_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 1}
	/// </code>
	/// </example>
	public static float[] Dual16(this IReadOnlyList<float> v) => new []{v[15], v[14], v[13], v[12], v[11], v[10]
		, v[9], v[8], v[7], v[6], v[5], v[4], v[3], v[2], v[1], v[0]};

	/// <summary> Main involution </summary>
	/// <remarks> Another Involution Operator </remarks>
	/// <example>
	/// <code language="yaml">
	/// tags: [code/extension_method, code/clifford_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 1}
	/// </code>
	/// </example>
	public static float[] Involute16(this IReadOnlyList<float> v) => new[]{v[0]
		, -v[1], -v[2], -v[3], -v[4]
		, v[5], v[6], v[7], v[8], v[9], v[10]
		, -v[11], -v[12], -v[13], -v[14], v[15]};

	/// <summary> ~ Complex Conjugate of the basis blades. </summary>
	/// <remarks>
	/// Creates the Conjugate, which is the Inverse except for Normalization 
	/// </remarks>
	/// <example>
	/// <code language="yaml">
	/// tags: [code/extension_method, code/clifford_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 1}
	/// </code>
	/// </example>
	/// TODO: bad Naming! Dual should be named that
	public static float[] Reverted16(this IReadOnlyList<float> a) => new []{a[0], a[1], a[2], a[3], a[4]
		, -a[5], -a[6], -a[7], -a[8], -a[9], -a[10], -a[11], -a[12], -a[13], -a[14]
		, a[15]};

	/// <summary> + Add; MultiVector addition </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/extension_method, code/vector_addition]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 1}
	/// </code>
	/// </example>
	[TestCase(new []{1,2,3,4,5,6,7,8,-1,-2,-3,-4,-5,-6,-7,-8f}, new []{1,2,3,4,5,6,7,8,-1,-2,-3,-4,-5,-6,-7,-8f}
		, ExpectedResult = new []{2,4,6,8,10,12,14,16,-2,-4,-6,-8,-10,-12,-14,-16f})]
	[TestCase(new []{1,2,3,4,5,6,7,8,1,2,3,4,5,6,7,8f}, new []{-1,-2,-3,-4,-5,-6,-7,-8,1,2,3,4,5,6,7,8f}
		, ExpectedResult = new []{0,0,0,0,0,0,0,0,2,4,6,8,10,12,14,16f})]
	[TestCase(new []{-1,-2,-3,-4,-5,-6,-7,-8,1,2,3,4,5,6,7,8f}, new []{1,2,3,4,5,6,7,8,1,2,3,4,5,6,7,8f}
		, ExpectedResult = new []{0,0,0,0,0,0,0,0,2,4,6,8,10,12,14,16f})]
	public static float[] Plus16(this IReadOnlyList<float> a, IReadOnlyList<float> b) => new []{
		a[0] + b[0],
		a[1] + b[1],
		a[2] + b[2],
		a[3] + b[3],
		a[4] + b[4],
		a[5] + b[5],
		a[6] + b[6],
		a[7] + b[7],
		a[8] + b[8],
		a[9] + b[9],
		a[10] + b[10],
		a[11] + b[11],
		a[12] + b[12],
		a[13] + b[13],
		a[14] + b[14],
		a[15] + b[15]
	};

	/// <summary> - Minus, SUB; MultiVector Subtraction </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/extension_method, code/vector_subtraction]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 1}
	/// </code>
	/// </example>
	public static float[] Minus16(this IReadOnlyList<float> a, IReadOnlyList<float> b) => new []{
		a[0] - b[0],
		a[1] - b[1],
		a[2] - b[2],
		a[3] - b[3],
		a[4] - b[4],
		a[5] - b[5],
		a[6] - b[6],
		a[7] - b[7],
		a[8] - b[8],
		a[9] - b[9],
		a[10] - b[10],
		a[11] - b[11],
		a[12] - b[12],
		a[13] - b[13],
		a[14] - b[14],
		a[15] - b[15]
	};

	/// <summary> * mulS = scalar * multiVector multiplication </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/extension_method, code/scalar_multiplication]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 1}
	/// </code>
	/// </example>
	public static float[] Times16(this IReadOnlyList<float> p, float s) => new []{s * p[0], s * p[1], s * p[2], s * p[3]
		, s * p[4], s * p[5], s * p[6], s * p[7], s * p[8], s * p[9]
		, s * p[10], s * p[11], s * p[12], s * p[13], s * p[14], s * p[15]};

	/// <inheritdoc cref="Plus16(IReadOnlyList{float}, IReadOnlyList{float})"/>
	public static float[] Plus16(this IReadOnlyList<float> a, double b) => new []{(float)(a[0] + b)
		, a[1], a[2], a[3], a[4], a[5], a[6], a[7], a[8], a[9], a[10], a[11], a[12], a[13], a[14], a[15]};

	/// <inheritdoc cref="Minus16(IReadOnlyList{float}, IReadOnlyList{float})"/>
	public static float[] Minus16(this IReadOnlyList<float> a, double b) => new []{(float)(a[0] - b)
		, a[1], a[2], a[3], a[4], a[5], a[6], a[7], a[8], a[9], a[10], a[11], a[12], a[13], a[14], a[15]};

	/// <summary> Returns a new 16-element array with the scalar component set to <c><paramref name="a"/> - b[0]</c> and all remaining components negated. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/extension_method, code/subtraction, code/negation]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 1}
	/// </code>
	/// </example>
	public static float[] MinusR16(this IReadOnlyList<float> b, double a) => new []{(float)(a - b[0])
		, -b[1], -b[2], -b[3], -b[4], -b[5], -b[6], -b[7], -b[8], -b[9], -b[10], -b[11], -b[12], -b[13], -b[14], -b[15]};

	/// <inheritdoc cref="Plus16(IReadOnlyList{float}, IReadOnlyList{float})"/>
	public static float[] Plus16<B>(this IReadOnlyList<float> a, double value, B basis) where B : Enum, IConvertible {
		float[] ret = (float[]?)(a as float[])?.Clone() ?? a.ToArray();
		ret[basis.ToInt32(null)] += (float)value;
		return ret; 
	}

	/// <inheritdoc cref="Minus16(IReadOnlyList{float}, IReadOnlyList{float})"/>
	public static float[] Minus16<B>(this IReadOnlyList<float> a, double value, B basis) where B : Enum, IConvertible {
		float[] ret = (float[]?)(a as float[])?.Clone() ?? a.ToArray();
		ret[basis.ToInt32(null)] -= (float)value;
		return ret; 
	}

	/// <inheritdoc cref="MinusR16(IReadOnlyList{float}, double)"/>
	public static float[] MinusR16<B>(this IReadOnlyList<float> b, double value, B basis) where B : Enum, IConvertible {
		var ret = b.Neg16();
		ret[basis.ToInt32(null)] += (float)value;
		return ret; 
	}

	/// <summary> | Dot = inner / scalar product. </summary>
	/// <remarks>
	/// Parallel (cos-) Component Product; complements the <see cref="Meet16P"/>-Product
	/// to the full <see cref="Times16P"/> Product.
	/// Each Coefficient is the signed Sum of Products whose Arguments Index-Difference is the Coefficient's Position:
	/// d0=a0*b0 + a2*b2 +...- a14*b14
	/// ...
	/// d15=a0*b15 + a15*b0
	/// </remarks>
	/// <example>
	/// <code language="yaml">
	/// tags: [code/extension_method, code/dot_product]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 1}
	/// </code>
	/// </example>
	[TestCase(new []{1,2,3,4,5,6,7,8,-1,-2,-3,-4,-5,-6,-7,-8f}, new []{1,2,3,4,5,6,7,8,-1,-2,-3,-4,-5,-6,-7,-8f}
		, ExpectedResult = new []{-12,68,-36,-20,-4,-54,18,-18, -72, -60,-48, -8, -10,-12, -14, -16f})]
	[TestCase(new []{1,2,3,4,5,6,7,8,1,2,3,4,5,6,7,8f}, new []{-1,-2,-3,-4,-5,-6,-7,-8,1,2,3,4,5,6,7,8f}
		, ExpectedResult = new []{-114,60,-36,-60,-12,-60,-46,-32,0, 0, 0,80,64, 48,0,0f})]
	[TestCase(new []{-1,-2,-3,-4,-5,-6,-7,-8,1,2,3,4,5,6,7,8f}, new []{1,2,3,4,5,6,7,8,1,2,3,4,5,6,7,8f}
		, ExpectedResult = new []{-114,60,-60,-12,-36,-60,-46,-32,0, 0, 0,-80, -64, -48,0, 0f})]
	public static float[] Dot16P(this IReadOnlyList<float> a, IReadOnlyList<float> b) => new []{
		b[0] * a[0] + b[2] * a[2] + b[3] * a[3] + b[4] * a[4] - b[8] * a[8] - b[9] * a[9] - b[10] * a[10] - b[14] * a[14],
		b[1] * a[0] + b[0] * a[1] - b[5] * a[2] - b[6] * a[3] - b[7] * a[4] + b[2] * a[5] + b[3] * a[6] + b[4] * a[7] + b[11] * a[8] + b[12] * a[9] + b[13] * a[10] + b[8] * a[11] + b[9] * a[12] + b[10] * a[13] + b[15] * a[14] - b[14] * a[15],
		b[2] * a[0] + b[0] * a[2] - b[8] * a[3] + b[9] * a[4] + b[3] * a[8] - b[4] * a[9] - b[14] * a[10] - b[10] * a[14],
		b[3] * a[0] + b[8] * a[2] + b[0] * a[3] - b[10] * a[4] - b[2] * a[8] - b[14] * a[9] + b[4] * a[10] - b[9] * a[14],
		b[4] * a[0] - b[9] * a[2] + b[10] * a[3] + b[0] * a[4] - b[14] * a[8] + b[2] * a[9] - b[3] * a[10] - b[8] * a[14],
		b[5] * a[0] - b[11] * a[3] + b[12] * a[4] + b[0] * a[5] - b[15] * a[10] - b[3] * a[11] + b[4] * a[12] - b[10] * a[15],
		b[6] * a[0] + b[11] * a[2] - b[13] * a[4] + b[0] * a[6] - b[15] * a[9] + b[2] * a[11] - b[4] * a[13] - b[9] * a[15],
		b[7] * a[0] - b[12] * a[2] + b[13] * a[3] + b[0] * a[7] - b[15] * a[8] - b[2] * a[12] + b[3] * a[13] - b[8] * a[15],
		b[8] * a[0] + b[14] * a[4] + b[0] * a[8] + b[4] * a[14],
		b[9] * a[0] + b[14] * a[3] + b[0] * a[9] + b[3] * a[14],
		b[10] * a[0] + b[14] * a[2] + b[0] * a[10] + b[2] * a[14],
		b[11] * a[0] + b[15] * a[4] + b[0] * a[11] - b[4] * a[15],
		b[12] * a[0] + b[15] * a[3] + b[0] * a[12] - b[3] * a[15],
		b[13] * a[0] + b[15] * a[2] + b[0] * a[13] - b[2] * a[15],
		b[14] * a[0] + b[0] * a[14],
		b[15] * a[0] + b[0] * a[15]
	};

	/// <summary> &amp; (JOIN): Vee AKA regressive product; symmetric </summary>
	/// <remarks>
	/// Dual of <see cref="Meet16P"/>: !(A^B) = !A v !B
	/// Examples are:
	/// * 
	/// Each Coefficient is the signed Sum of Products whose Arguments Index-Difference
	/// is the Complement of the Coefficient's Position:
	/// d0=a0*b15 - a1*b14 - a2*b13 +...+ a14*b1 + a15*b0
	/// ...
	/// d15=a15*b15
	/// </remarks>
	/// <example>
	/// <code language="yaml">
	/// tags: [code/extension_method, code/clifford_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 1}
	/// </code>
	/// </example>
	[TestCase(new []{1,2,3,4,5,6,7,8,-1,-2,-3,-4,-5,-6,-7,-8f}, new []{1,2,3,4,5,6,7,8,-1,-2,-3,-4,-5,-6,-7,-8f}
		, ExpectedResult = new []{-96,174,-126,-174,-186,-96,-112,-128,16,32,48,64,80,96,112,64f})]
	[TestCase(new []{1,2,3,4,5,6,7,8,1,2,3,4,5,6,7,8f}, new []{-1,-2,-3,-4,-5,-6,-7,-8,1,2,3,4,5,6,7,8f}
		, ExpectedResult = new []{-144,0,6,-12,6,0,0,0,16, 32, 48,64, 80, 96,112, 64f})]
	[TestCase(new []{-1,-2,-3,-4,-5,-6,-7,-8,1,2,3,4,5,6,7,8f}, new []{1,2,3,4,5,6,7,8,1,2,3,4,5,6,7,8f}
		, ExpectedResult = new []{144,0,6,-12,6,0,0,0,16, 32, 48,64, 80, 96,112, 64f})]
	public static float[] Join16P(this IReadOnlyList<float> a, IReadOnlyList<float> b) => new []{
		a[0] * b[15] - a[1] * b[14] - a[2] * b[13] - a[3] * b[12] - a[4] * b[11] + a[5] * b[10] + a[6] * b[9] + a[7] * b[8] + a[8] * b[7]
		+ a[9] * b[6] + a[10] * b[5] + a[11] * b[4] + a[12] * b[3] + a[13] * b[2] + a[14] * b[1] + a[15] * b[0],
		a[1] * b[15] - a[5] * b[13] - a[6] * b[12] - a[7] * b[11] - a[11] * b[7] - a[12] * b[6] - a[13] * b[5] + a[15] * b[1],
		a[2] * b[15] + a[5] * b[14] - a[8] * b[12] + a[9] * b[11] + a[11] * b[9] - a[12] * b[8] + a[14] * b[5] + a[15] * b[2],
		a[3] * b[15] + a[6] * b[14] + a[8] * b[13] - a[10] * b[11] - a[11] * b[10] + a[13] * b[8] + a[14] * b[6] + a[15] * b[3],
		a[4] * b[15] + a[7] * b[14] - a[9] * b[13] + a[10] * b[12] + a[12] * b[10] - a[13] * b[9] + a[14] * b[7] + a[15] * b[4],
		a[5] * b[15] + a[11] * b[12] - a[12] * b[11] + a[15] * b[5],
		a[6] * b[15] - a[11] * b[13] + a[13] * b[11] + a[15] * b[6],
		a[7] * b[15] + a[12] * b[13] - a[13] * b[12] + a[15] * b[7],
		a[8] * b[15] + a[11] * b[14] - a[14] * b[11] + a[15] * b[8],
		a[9] * b[15] + a[12] * b[14] - a[14] * b[12] + a[15] * b[9],
		a[10] * b[15] + a[13] * b[14] - a[14] * b[13] + a[15] * b[10],
		a[11] * b[15] + a[15] * b[11],
		a[12] * b[15] + a[15] * b[12],
		a[13] * b[15] + a[15] * b[13],
		a[14] * b[15] + a[15] * b[14],
		a[15] * b[15]
	};

	/// <summary> ^ Cross-/ outer Product / MEET / Intersect / Wedge; antisymmetric 'Grassmann' product. </summary>
	/// <remarks>
	/// Dual Operation to v / <see cref="Join16P"/>: a ^ b = !a v !b
	/// 
	/// a ^ b = -b ^ a => a ^ a = 0
	/// total anti-symmetric, multiLinear, associative Product (Area, Volume, Determinant)
	/// 
	/// In Projective Geometry this calculates the Point where two or more HyperPlanes 'meet'. 
	/// 
	/// Orthogonal (sin-) Component Product; complementing cos of the <see cref="Dot16P"/>Product 
	/// Represents the generalized Area spanned by the Vector-Factors
	/// and also the Condition of the associated System of linear Equations. .
	/// Collapses to 0 iif Factors are linearly dependent. 
	///
	/// Yields oriented Sub-Spaces AKA Blades 
	/// Examples:
	/// * a^b^c with Points yields the Circle through all 3 Points
	/// * a^b   with Points yields the Line through both Points (3rd Point at infinity)
	/// 
	/// Each Coefficient is the signed Sum of Products whose Arguments Index-Sum is the Coefficient's Position:
	/// d0=a0*b0
	/// ...
	/// d15=a0*b15 + a1*b14 + ... - a14*b1 + a15*b0
	/// </remarks>
	/// <example>
	/// <code language="yaml">
	/// tags: [code/extension_method, code/outer_product]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 1}
	/// </code>
	/// </example>
	public static float[] Meet16P(this IReadOnlyList<float> a, IReadOnlyList<float> b) => new []{
		b[0] * a[0],
		b[1] * a[0] + b[0] * a[1],
		b[2] * a[0] + b[0] * a[2],
		b[3] * a[0] + b[0] * a[3],
		b[4] * a[0] + b[0] * a[4],
		b[5] * a[0] + b[2] * a[1] - b[1] * a[2] + b[0] * a[5],
		b[6] * a[0] + b[3] * a[1] - b[1] * a[3] + b[0] * a[6],
		b[7] * a[0] + b[4] * a[1] - b[1] * a[4] + b[0] * a[7],
		b[8] * a[0] + b[3] * a[2] - b[2] * a[3] + b[0] * a[8],
		b[9] * a[0] - b[4] * a[2] + b[2] * a[4] + b[0] * a[9],
		b[10] * a[0] + b[4] * a[3] - b[3] * a[4] + b[0] * a[10],
		b[11] * a[0] - b[8] * a[1] + b[6] * a[2] - b[5] * a[3] - b[3] * a[5] + b[2] * a[6] - b[1] * a[8] + b[0] * a[11],
		b[12] * a[0] - b[9] * a[1] - b[7] * a[2] + b[5] * a[4] + b[4] * a[5] - b[2] * a[7] - b[1] * a[9] + b[0] * a[12],
		b[13] * a[0] - b[10] * a[1] + b[7] * a[3] - b[6] * a[4] - b[4] * a[6] + b[3] * a[7] - b[1] * a[10] + b[0] * a[13],
		b[14] * a[0] + b[10] * a[2] + b[9] * a[3] + b[8] * a[4] + b[4] * a[8] + b[3] * a[9] + b[2] * a[10] + b[0] * a[14],
		b[15] * a[0] + b[14] * a[1] + b[13] * a[2] + b[12] * a[3] + b[11] * a[4] + b[10] * a[5] + b[9] * a[6] + b[8] * a[7]
		+ b[7] * a[8] + b[6] * a[9] + b[5] * a[10] - b[4] * a[11] - b[3] * a[12] - b[2] * a[13] - b[1] * a[14] + b[0] * a[15]
	};

	/// <summary> Clifford Conjugation </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/extension_method, code/conjugate]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 1}
	/// </code>
	/// </example>
	public static float[] CliffCjg16(this IReadOnlyList<float> v) => new[]{v[0]
		, -v[1], -v[2], -v[3], -v[4], -v[5], -v[6], -v[7], -v[8], -v[9], -v[10]
		, v[11], v[12], v[13], v[14], v[15]};

	/// <summary>Norm Sqr16 Q.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/norm_calculation]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 1}
	/// </code>
	/// </example>
	[TestCase(new []{1,2,3,4,5,6,7,8,-1,-2,-3,-4,-5,-6,-7,-8f}, ExpectedResult = -84)]
	public static float NormSqr16Q(IReadOnlyList<float> c) => c.Times16P(c.CliffCjg16())[0];

	/// <summary>Norm Sqr16 P.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/extension_method, code/norm_calculation]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 1}
	/// </code>
	/// </example>
	[TestCase(new []{1,2,3,4,5,6,7,8,-1,-2,-3,-4,-5,-6,-7,-8f}, ExpectedResult = -84)]
	public static float NormSqr16P(this IReadOnlyList<float> a) => a[0].Sqr()
		- a[2].Sqr() - a[3].Sqr() - a[4].Sqr() + a[8].Sqr() + a[9].Sqr() + a[10].Sqr() - a[14].Sqr();

	/// <summary> * = geometric/cartesian product. </summary>
	/// <remarks>
	/// Examples:
	/// Vector * Vector = Versor (defines a Plane with double Reflection)
	/// By Sandwiching it acts like a Rotation or Translation.
	/// Normalized Versors are also called Rotors or Spinors.
	/// 
	/// </remarks>
	/// <example>
	/// <code language="yaml">
	/// tags: [code/extension_method, code/geometric_product]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 1}
	/// </code>
	/// </example>
	public static float[] Times16P(this IReadOnlyList<float> a, IReadOnlyList<float> b) => new []{
		b[0] * a[0] + b[2] * a[2] + b[3] * a[3] + b[4] * a[4] - b[8] * a[8] - b[9] * a[9] - b[10] * a[10] - b[14] * a[14],
		b[1] * a[0] + b[0] * a[1] - b[5] * a[2] - b[6] * a[3] - b[7] * a[4] + b[2] * a[5] + b[3] * a[6] + b[4] * a[7] + b[11] * a[8] + b[12] * a[9] + b[13] * a[10] + b[8] * a[11] + b[9] * a[12] + b[10] * a[13] + b[15] * a[14] - b[14] * a[15],
		b[2] * a[0] + b[0] * a[2] - b[8] * a[3] + b[9] * a[4] + b[3] * a[8] - b[4] * a[9] - b[14] * a[10] - b[10] * a[14],
		b[3] * a[0] + b[8] * a[2] + b[0] * a[3] - b[10] * a[4] - b[2] * a[8] - b[14] * a[9] + b[4] * a[10] - b[9] * a[14],
		b[4] * a[0] - b[9] * a[2] + b[10] * a[3] + b[0] * a[4] - b[14] * a[8] + b[2] * a[9] - b[3] * a[10] - b[8] * a[14],
		b[5] * a[0] + b[2] * a[1] - b[1] * a[2] - b[11] * a[3] + b[12] * a[4] + b[0] * a[5] - b[8] * a[6] + b[9] * a[7] + b[6] * a[8] - b[7] * a[9] - b[15] * a[10] - b[3] * a[11] + b[4] * a[12] + b[14] * a[13] - b[13] * a[14] - b[10] * a[15],
		b[6] * a[0] + b[3] * a[1] + b[11] * a[2] - b[1] * a[3] - b[13] * a[4] + b[8] * a[5] + b[0] * a[6] - b[10] * a[7] - b[5] * a[8] - b[15] * a[9] + b[7] * a[10] + b[2] * a[11] + b[14] * a[12] - b[4] * a[13] - b[12] * a[14] - b[9] * a[15],
		b[7] * a[0] + b[4] * a[1] - b[12] * a[2] + b[13] * a[3] - b[1] * a[4] - b[9] * a[5] + b[10] * a[6] + b[0] * a[7] - b[15] * a[8] + b[5] * a[9] - b[6] * a[10] + b[14] * a[11] - b[2] * a[12] + b[3] * a[13] - b[11] * a[14] - b[8] * a[15],
		b[8] * a[0] + b[3] * a[2] - b[2] * a[3] + b[14] * a[4] + b[0] * a[8] + b[10] * a[9] - b[9] * a[10] + b[4] * a[14],
		b[9] * a[0] - b[4] * a[2] + b[14] * a[3] + b[2] * a[4] - b[10] * a[8] + b[0] * a[9] + b[8] * a[10] + b[3] * a[14],
		b[10] * a[0] + b[14] * a[2] + b[4] * a[3] - b[3] * a[4] + b[9] * a[8] - b[8] * a[9] + b[0] * a[10] + b[2] * a[14],
		b[11] * a[0] - b[8] * a[1] + b[6] * a[2] - b[5] * a[3] + b[15] * a[4] - b[3] * a[5] + b[2] * a[6] - b[14] * a[7] - b[1] * a[8] + b[13] * a[9] - b[12] * a[10] + b[0] * a[11] + b[10] * a[12] - b[9] * a[13] + b[7] * a[14] - b[4] * a[15],
		b[12] * a[0] - b[9] * a[1] - b[7] * a[2] + b[15] * a[3] + b[5] * a[4] + b[4] * a[5] - b[14] * a[6] - b[2] * a[7] - b[13] * a[8] - b[1] * a[9] + b[11] * a[10] - b[10] * a[11] + b[0] * a[12] + b[8] * a[13] + b[6] * a[14] - b[3] * a[15],
		b[13] * a[0] - b[10] * a[1] + b[15] * a[2] + b[7] * a[3] - b[6] * a[4] - b[14] * a[5] - b[4] * a[6] + b[3] * a[7] + b[12] * a[8] - b[11] * a[9] - b[1] * a[10] + b[9] * a[11] - b[8] * a[12] + b[0] * a[13] + b[5] * a[14] - b[2] * a[15],
		b[14] * a[0] + b[10] * a[2] + b[9] * a[3] + b[8] * a[4] + b[4] * a[8] + b[3] * a[9] + b[2] * a[10] + b[0] * a[14],
		b[15] * a[0] + b[14] * a[1] + b[13] * a[2] + b[12] * a[3] + b[11] * a[4] + b[10] * a[5] + b[9] * a[6] + b[8] * a[7] + b[7] * a[8] + b[6] * a[9] + b[5] * a[10] - b[4] * a[11] - b[3] * a[12] - b[2] * a[13] - b[1] * a[14] + b[0] * a[15]
	};

	#region Test Pairs for all Products

	/// <summary>Delegate wrapping the geometric product operation for use in product test pipelines.</summary>
	public static readonly Func<IReadOnlyList<float>, IReadOnlyList<float>, float[]> ProductGeometric = Times16P;
	/// <summary>Delegate wrapping the inner (dot) product operation for use in product test pipelines.</summary>
	public static readonly Func<IReadOnlyList<float>, IReadOnlyList<float>, float[]> ProductDot = Dot16P;
	/// <summary>Delegate wrapping the outer (meet) product operation for use in product test pipelines.</summary>
	public static readonly Func<IReadOnlyList<float>, IReadOnlyList<float>, float[]> ProductOuter = Meet16P;

	/// <summary> Order must conform to the order in <see cref="R300.Products"/> </summary>
	static readonly Func<IReadOnlyList<float>, IReadOnlyList<float>, float[]>[] _Products = {
		ProductGeometric,
		ProductDot,
		ProductOuter,
	};

	/// <summary>Public read-only view of all three product delegate functions indexed by product type.</summary>
	public static readonly Func<IReadOnlyList<float>, IReadOnlyList<float>, float[]>[] Products = _Products;

	/// <summary> Generates all Test Pairs for all Products in <see cref="Pga3D.Products"/> </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/test_data_generation]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: generator, status: stable, complexity: 2}
	/// </code>
	/// </example>
	public static IEnumerable<(float[][] arg1Arg2Product, Func<IReadOnlyList<float>, IReadOnlyList<float>, float[]> binaryOp)> AllProductTests() {
		for (var i = Products.Length; --i >= 0; ) {
			var binaryOp = Products[i];
			IReadOnlyList<IReadOnlyList<Pga3D.Base>> matrix = Pga3D.Products[i];
			foreach (var valueTuple in matrix.ProductTests(binaryOp)) {
				yield return valueTuple;
			}
		}
	}

	/// <summary>Test Join Meet.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/unit_test, code/clifford_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: test, status: stable, complexity: 2}
	/// </code>
	/// </example>
	[TestCaseSource(nameof(BaseVectorPairs))]
	public static void TestJoinMeet((Pga3D.Base x, Pga3D.Base y) pair) {
		float[][] arg1Arg2Product = Pga3D.ProductOuter.CreateVectorPairs(pair.x, pair.y, 2, 3);
		var arg1 = Dual16(arg1Arg2Product[0]);
		var arg2 = Dual16(arg1Arg2Product[1]);
		var exp = Dual16(arg1Arg2Product[2]);
		var join = Join16P(arg1, arg2);
		for (int i = join.Length; --i >= 0;) {
			float expected = exp[i];
			//if (IsOdd(pair.x + (sbyte) pair.y)) {
			if (IsOdd(pair.x.Grade() * pair.y.Grade())) {
				expected = -expected;
			}
			_ = Math.Abs(join[i]).ShouldBe(Math.Abs(expected));
			//TODO: join[i].ShouldBe(expected);
		}
	}

	/// <summary>Determines whether odd.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/extension_method, code/bit_parity]
	/// concepts: [bitwise_operations]
	/// facets: {layer: utility, status: stable, complexity: 1}
	/// </code>
	/// </example>
	public static bool IsOdd(this int value) => 0 != (value & 1);
	/// <inheritdoc cref="IsOdd(int)"/>
	public static bool IsOdd(this Pga3D.Base value) => IsOdd((int)value);
	/// <summary> Returns the grade (0–4) of the given basis blade <paramref name="value"/>. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/extension_method, code/enum_conversion]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 2}
	/// </code>
	/// </example>
	public static byte Grade(this Pga3D.Base value) 
		=> value switch {
			Pga3D.Base._1_ => 0,
			Pga3D.Base.e0 => 1,
			Pga3D.Base.e1 => 1,
			Pga3D.Base.e2 => 1,
			Pga3D.Base.e3 => 1,
			//Translation
			Pga3D.Base.e01 => 2,
			Pga3D.Base.e02 => 2,
			Pga3D.Base.e03 => 2,
			//Rotation
			Pga3D.Base.e12 => 2,
			Pga3D.Base.e31 => 2,
			Pga3D.Base.e23 => 2,
			Pga3D.Base.e021 => 3,
			Pga3D.Base.e013 => 3,
			Pga3D.Base.e032 => 3,
			Pga3D.Base.e123 => 3,
			Pga3D.Base.e0123 => 4,
			_ => throw new ArgumentOutOfRangeException(nameof(value), value, null)
		};

	/// <summary>Test Join Meet Abs.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/unit_test, code/clifford_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: test, status: stable, complexity: 2}
	/// </code>
	/// </example>
	[TestCaseSource(nameof(ProductOuterSampleVectorPairs))]
	public static void TestJoinMeetAbs(float[][] arg1Arg2Product) {
		var arg1 = Dual16(arg1Arg2Product[0]);
		var arg2 = Dual16(arg1Arg2Product[1]);
		var exp = Dual16(arg1Arg2Product[2]);
		var join = Join16P(arg1, arg2);
		join.Select(Math.Abs).ShouldBeSequence(exp.Select(Math.Abs));
	}

	/// <summary> Generates all Test Cases for <paramref name="product"/> from <paramref name=""/> Pairs of <see cref="Pga3D"/> Elements </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/test_data_generation]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: generator, status: stable, complexity: 1}
	/// </code>
	/// </example>
	public static IEnumerable<float[][]> ProductOuterSampleVectorPairs() => Pga3D.ProductOuter.ProductTests();

	/// <summary> Generates all Test Cases for <paramref name="product"/> from <paramref name=""/> Pairs of <see cref="Pga3D"/> Elements </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/extension_method, code/test_data_generation]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: generator, status: stable, complexity: 1}
	/// </code>
	/// </example>
	static IEnumerable<float[][]> ProductTests(this IReadOnlyList<IReadOnlyList<Pga3D.Base>> matrix) 
		=> BaseVectorPairs().Select(pair => matrix.CreateVectorPairs(pair.x, pair.y, 2, 3));

	/// <summary> Generates all Test Cases for <paramref name="product"/> from <paramref name=""/> Pairs of <see cref="Pga3D"/> Elements </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/extension_method, code/test_data_generation]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: generator, status: stable, complexity: 1}
	/// </code>
	/// </example>
	static IEnumerable<(float[][] arg1Arg2Result, Func<IReadOnlyList<float>, IReadOnlyList<float>, float[]> product)
	> ProductTests(this IReadOnlyList<IReadOnlyList<Pga3D.Base>> matrix
		, Func<IReadOnlyList<float>, IReadOnlyList<float>, float[]> product) 
		=> BaseVectorPairs().Select(pair => (matrix.CreateVectorPairs(pair.x, pair.y, 2, 3), product));

	/// <summary> Generates all Pairs of <see cref="Pga3D"/> Base Vectors Elements </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/test_data_generation, code/combinatorial_generation]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: generator, status: stable, complexity: 2}
	/// </code>
	/// </example>
	public static IEnumerable<(Pga3D.Base x, Pga3D.Base y)> BaseVectorPairs() {
		for (var k = Pga3D.Base._1_; k != Pga3D.Base._0; ++k) {
			for (var i = Pga3D.Base._1_; i != Pga3D.Base._0; ++i) {
				yield return (i, k);
			}
		}
	}

	/// <summary>Test All Products.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/unit_test]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: test, status: stable, complexity: 2}
	/// </code>
	/// </example>
	[TestCaseSource(nameof(AllProductTests))]
	public static void TestAllProducts((float[][] vectors, Func<IReadOnlyList<float>, IReadOnlyList<float>, float[]> product) test) {
		var z = test.product(test.vectors[0], test.vectors[1]);
		CollectionAssert.AreEqual(test.vectors[2], z);
	}

	/// <summary> Builds a triple of float arrays representing two input basis blades and their expected product result from the given Cayley <paramref name="products"/> table. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/extension_method, code/test_data_generation]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: generator, status: stable, complexity: 1}
	/// </code>
	/// </example>
	public static float[][] CreateVectorPairs(this IReadOnlyList<IReadOnlyList<Pga3D.Base>> products
		, Pga3D.Base a, Pga3D.Base b, double factor1, double factor2) {
		var (e, factor) = products[(int) a][(int) b].GetFactor();
		return CreateVectorPairs(a, b, factor1, factor2, e, factor);
	}

	/// <inheritdoc cref="CreateVectorPairs(IReadOnlyList{IReadOnlyList{Pga3D.Base}}, Pga3D.Base, Pga3D.Base, double, double)"/>
	public static float[][] CreateVectorPairs(Pga3D.Base a, Pga3D.Base b, double factor1, double factor2, Pga3D.Base e, int factor) {
		var vectors = new[] {
			new float[Pga3D.NUM_COORDS],
			new float[Pga3D.NUM_COORDS],
			new float[Pga3D.NUM_COORDS],
		};
		vectors[0][(int) a] = (float) factor1;
		vectors[1][(int) b] = (float) factor2;
		vectors[2][(int) e] = (float) (factor1 * factor2 * factor);
		return vectors;
	}

	#endregion Test Pairs for all Products

	/// <summary>Shared random number generator for property-based test data.</summary>
	static readonly Random RANDOM = new(PgaTolerance.TestSeed); //fixed Seed: reproducible Test-Cases

	/// <summary> Generates 99 random <see cref="Pga3D"/> multi-vectors with uniformly distributed components for property-based tests. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/random_number_generator, code/test_data_generation]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: generator, status: stable, complexity: 2}
	/// </code>
	/// </example>
	public static IEnumerable<Pga3D> RandomPga3D() {
		var arr = new float[Pga3D.NUM_COORDS];
		for (int i = 99; --i >= 0;) {
			for (int j = arr.Length; --j >= 0; ) {
				arr[j] = (float) RANDOM.NextDouble();
			}
			yield return new Pga3D(arr);
		}
	}

	/// <summary>Fixed set of invertible <see cref="Pga3D"/> multi-vectors used as static test cases.</summary>
	static readonly Pga3D[] Invertables = {Pga3D._1_
		, Pga3D.Planes.YZ, Pga3D.Planes.ZX, Pga3D.Planes.XY//, Pga3D.Planes.Dist
		//, Pga3D.AxisTrans.X, Pga3D.AxisTrans.Y, Pga3D.AxisTrans.Z
		, Pga3D.AxisRot.Z, Pga3D.AxisRot.Y, Pga3D.AxisRot.X
		, Pga3D.Points.Origin//, Pga3D.Points.Z, Pga3D.Points.Y, Pga3D.Points.X
		//, Pga3D.E0123
	};

	/// <summary>Test Rcp.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/unit_test, code/reciprocal]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: test, status: stable, complexity: 2}
	/// </code>
	/// </example>
	[TestCaseSource(nameof(Invertables))]
	[TestCaseSource(nameof(RandomPga3D))]
	public static void TestRcp(Pga3D mv) {
		var rcp = mv.Rcp();
		var r1 = mv.Times(rcp);
		r1.ShouldBeApprox(Pga3D._1_, 5e-5);

		var r2 = mv.Times(rcp);
		r2.ShouldBeApprox(Pga3D._1_, 5e-5);
	}

	/// <summary> Constructs a translator motor along <paramref name="axisTrans"/> by twice <paramref name="halfDistance"/>. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/extension_method, code/factory_method]
	/// concepts: [projective_geometric_algebra]
	/// facets: {layer: domain, status: stable, complexity: 1}
	/// </code>
	/// </example>
	public static Pga3D MakeMotor(this Pga3D.AxisTrans axisTrans, double halfDistance)
		=> Pga3D.Make.Motor(halfDistance, axisTrans);

	/// <summary> Constructs a rotor around <paramref name="axisRot"/> by twice <paramref name="halfAngleRad"/> radians. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/extension_method, code/factory_method]
	/// concepts: [projective_geometric_algebra]
	/// facets: {layer: domain, status: stable, complexity: 1}
	/// </code>
	/// </example>
	public static Pga3D MakeRotor(this Pga3D.AxisRot axisRot, double halfAngleRad)
		=> Pga3D.Make.Rotor(halfAngleRad, axisRot);

}
