using org.SpocWeb.root.Attributes;
using NUnit.Framework;
using org.SpocWeb.root.data.extensions;

namespace org.SpocWeb.root.interfaces.converters {

	/// <summary>Tests for perspective Transform.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// pass: 2
	/// mtime: 2026-05-24T15:36:44Z
	/// digest: 6f686ec058aa3dc35be3850080da6e59cbe0776086956601411936c395219ef8
	/// tags: [code/unit_test, code/perspective_transform]
	/// concepts: [Mathematics\Geometry.md]
	/// facets: {layer: test, status: stable, complexity: 2}
	/// </code>
	/// </example>
	[Replaces("../IMathsImpl/Interfaces/Converters/PerspectiveTransformTests.cs")]
	[TestFixture]
	public static class PerspectiveTransformTests {

		/// <summary>Specifies the constant ePSILON.</summary>
		const float EPSILON = 1.0E-4f;

		/// <summary>Test-Helper asserting that <paramref name="pt"/> transforms the Point (<paramref name="sourceX"/>, <paramref name="sourceY"/>) to (<paramref name="expectedX"/>, <paramref name="expectedY"/>) within <see cref="EPSILON"/>.</summary>
		///
		/// <example>
		/// <code language="yaml">
		/// tags: [code/unit_test, code/perspective_transform]
		/// concepts: [perspective_transform, Mathematics\Geometry.md]
		/// facets: {layer: test, status: stable, complexity: 2}
		/// </code>
		/// </example>
		static void AssertPointEquals(float expectedX,
			float expectedY,
			float sourceX,
			float sourceY,
			PerspectiveTransform pt) {
			float[] points = {sourceX, sourceY};
			pt.TransformPoints(points);
			expectedX.ShouldBeApprox(points[0], EPSILON);
			points[1].ShouldBeApprox(expectedY, EPSILON);
		}

		/// <summary>Test Quadrilateral To Quadrilateral.</summary>
		///
		/// <example>
		/// <code language="yaml">
		/// tags: [code/unit_test, code/perspective_transform]
		/// concepts: [Mathematics\Geometry.md]
		/// facets: {layer: test, status: stable, complexity: 2}
		/// </code>
		/// </example>
		[Test]
		public static void TestQuadrilateralToQuadrilateral() {
			var pt = PerspectiveTransform.QuadrilateralToQuadrilateral
			(
				2.0f, 3.0f, 10.0f, 4.0f, 16.0f, 15.0f, 4.0f, 9.0f,
				103.0f, 110.0f, 300.0f, 120.0f, 290.0f, 270.0f, 150.0f, 280.0f);
			AssertPointEquals(103.0f, 110.0f, 2.0f, 3.0f, pt);
			AssertPointEquals(300.0f, 120.0f, 10.0f, 4.0f, pt);
			AssertPointEquals(290.0f, 270.0f, 16.0f, 15.0f, pt);
			AssertPointEquals(150.0f, 280.0f, 4.0f, 9.0f, pt);
			AssertPointEquals(7.1516876f, -64.60185f, 0.5f, 0.5f, pt);
			AssertPointEquals(328.09116f, 334.16385f, 50.0f, 50.0f, pt);
		}

		/// <summary>Test Square To Quadrilateral.</summary>
		///
		/// <example>
		/// <code language="yaml">
		/// tags: [code/unit_test, code/perspective_transform]
		/// concepts: [Mathematics\Geometry.md]
		/// facets: {layer: test, status: stable, complexity: 2}
		/// </code>
		/// </example>
		[Test]
		public static void TestSquareToQuadrilateral() {
			var pt = PerspectiveTransform.SquareToQuadrilateral
			(
				2.0f, 3.0f, 10.0f, 4.0f, 16.0f, 15.0f, 4.0f, 9.0f);
			AssertPointEquals(2.0f, 3.0f, 0.0f, 0.0f, pt);
			AssertPointEquals(10.0f, 4.0f, 1.0f, 0.0f, pt);
			AssertPointEquals(4.0f, 9.0f, 0.0f, 1.0f, pt);
			AssertPointEquals(16.0f, 15.0f, 1.0f, 1.0f, pt);
			AssertPointEquals(6.535211f, 6.8873234f, 0.5f, 0.5f, pt);
			AssertPointEquals(48.0f, 42.42857f, 1.5f, 1.5f, pt);
		}

	}

}
