using org.SpocWeb.root.Attributes;
namespace org.SpocWeb.root.interfaces.converters {

	/// <summary> Given four source and four destination points, it will compute the transformation implied between them. </summary>
	/// <remarks>
	/// ## Public Methods
	///
	/// | Line | Method | Description |
	/// |--:|---|---|
	/// | 60 | <see cref="QuadrilateralToQuadrilateral"/> | Returns a perspective transform mapping the source quadrilateral (x0–x3, y0–y3) to the destination quadrilateral (x0P–x3P, y0P–y3P). |
	/// | 74 | <see cref="TransformPoints"/> | Transforms an array of alternating x, y coordinates in-place using this perspective transform. |
	/// | 117 | <see cref="SquareToQuadrilateral"/> | Returns a perspective transform mapping the unit square to the quadrilateral defined by the four corner points. |
	/// | 149 | <see cref="QuadrilateralToSquare"/> | Returns a perspective transform mapping the quadrilateral defined by the four corner points to the unit square, via the adjoint of the inverse. |
	///
	/// ## Collaborators
	///
	/// | Type | Role |
	/// |---|---|
	/// | <see cref="PerspectiveTransform"/> | Returned by a method. |
	/// </remarks>
	///
	[DocState(Pass = 2, MTime = "2026-05-24T15:36:44Z", Digest = "7514c9931478b175bf6b01507a2f841d0e26761ae96af29da2b9e7465c511f8c", Stale = false, Path = "typed/PerspectiveTransform.cs", Since = "2026-10-06")]
	[Facets(Layer = "graphics", Status = "stable", Complexity = 3)]
	[Tags("code/perspective_transform", "code/computational_geometry")]
	[System.ComponentModel.Description("Given four source and four destination points, it will compute the transformation implied between them.")]
	[Replaces("../IMathsImpl/Interfaces/Converters/PerspectiveTransform.cs")]
	[Concept("Mathematics\\Geometry.md")]
	public sealed class PerspectiveTransform {

		readonly float A11;
		readonly float A12;
		readonly float A13;
		readonly float A21;
		readonly float A22;
		readonly float A23;
		readonly float A31;
		readonly float A32;
		readonly float A33;

		/// <summary>Initializes a new instance of <see cref="PerspectiveTransform"/> with the specified <paramref name="a11"/>, <paramref name="a21"/>, <paramref name="a31"/>, <paramref name="a12"/>, <paramref name="a22"/>, <paramref name="a32"/>, <paramref name="a13"/>, <paramref name="a23"/> and <paramref name="a33"/>.</summary>
		///
		[Facets(Layer = "graphics", Status = "stable", Complexity = 3)]
		[Tags("code/perspective_transform", "code/computational_geometry")]
		[System.ComponentModel.Description("Initializes a new instance of PerspectiveTransform with the specified a11, a21, a31, a12, a22, a32, a13, a23 and a33.")]
		[Concept("Mathematics\\Geometry.md")]
		PerspectiveTransform(float a11, float a21, float a31, float a12, float a22, float a32, float a13, float a23, float a33) {
			A11 = a11;
			A12 = a12;
			A13 = a13;
			A21 = a21;
			A22 = a22;
			A23 = a23;
			A31 = a31;
			A32 = a32;
			A33 = a33;
		}

		/// <summary> Returns a perspective transform mapping the source quadrilateral (x0–x3, y0–y3) to the destination quadrilateral (x0P–x3P, y0P–y3P). </summary>
		///
		[Facets(Layer = "graphics", Status = "stable", Complexity = 3)]
		[Tags("code/perspective_transform", "code/computational_geometry")]
		[System.ComponentModel.Description("Returns a perspective transform mapping the source quadrilateral (x0–x3, y0–y3) to the destination quadrilateral (x0P–x3P, y0P–y3P).")]
		[Concept("Mathematics\\Geometry.md")]
		public static PerspectiveTransform QuadrilateralToQuadrilateral(float x0, float y0, float x1, float y1, float x2,
			float y2, float x3, float y3, float x0P, float y0P, float x1P, float y1P, float x2P, float y2P, float x3P,
			float y3P) {
			var qToS = QuadrilateralToSquare(x0, y0, x1, y1, x2, y2, x3, y3);
			var sToQ = SquareToQuadrilateral(x0P, y0P, x1P, y1P, x2P, y2P, x3P, y3P);
			return sToQ.Times(qToS);
		}

		/// <summary> Transforms an array of alternating x, y coordinates in-place using this perspective transform. </summary>
		///
		[Facets(Layer = "graphics", Status = "stable", Complexity = 3)]
		[Tags("code/perspective_transform", "code/computational_geometry")]
		[System.ComponentModel.Description("Transforms an array of alternating x, y coordinates in-place using this perspective transform.")]
		[Concept("Mathematics\\Geometry.md")]
		public void TransformPoints(float[] points) {
			var a11 = A11;
			var a12 = A12;
			var a13 = A13;
			var a21 = A21;
			var a22 = A22;
			var a23 = A23;
			var a31 = A31;
			var a32 = A32;
			var a33 = A33;
			var maxI = points.Length - 1; // points.length must be even
			for (var i = 0; i < maxI; i += 2) {
				var x = points[i];
				var y = points[i + 1];
				var denominator = a13 * x + a23 * y + a33;
				points[i] = (a11 * x + a21 * y + a31) / denominator;
				points[i + 1] = (a12 * x + a22 * y + a32) / denominator;
			}
		}

		/// <summary>Convenience method, not optimized for performance. </summary>
		///
		[Facets(Layer = "graphics", Status = "stable", Complexity = 3)]
		[Tags("code/perspective_transform", "code/computational_geometry")]
		[System.ComponentModel.Description("Convenience method, not optimized for performance.")]
		[Concept("Mathematics\\Geometry.md")]
		public void TransformPoints(float[] xValues, float[] yValues) {
			var n = xValues.Length;
			for (var i = 0; i < n; i++) {
				var x = xValues[i];
				var y = yValues[i];
				var denominator = A13 * x + A23 * y + A33;
				xValues[i] = (A11 * x + A21 * y + A31) / denominator;
				yValues[i] = (A12 * x + A22 * y + A32) / denominator;
			}
		}

		/// <summary> Returns a perspective transform mapping the unit square to the quadrilateral defined by the four corner points. </summary>
		///
		[Facets(Layer = "graphics", Status = "stable", Complexity = 3)]
		[Tags("code/perspective_transform", "code/computational_geometry")]
		[System.ComponentModel.Description("Returns a perspective transform mapping the unit square to the quadrilateral defined by the four corner points.")]
		[Concept("Mathematics\\Geometry.md")]
		public static PerspectiveTransform SquareToQuadrilateral(float x0, float y0,
			float x1, float y1,
			float x2, float y2,
			float x3, float y3) {
			var dx3 = x0 - x1 + x2 - x3;
			var dy3 = y0 - y1 + y2 - y3;
			if (dx3 == 0.0f && dy3 == 0.0f) {
				// Affine
				return new PerspectiveTransform
				(x1 - x0, x2 - x1, x0,
					y1 - y0, y2 - y1, y0,
					0.0f, 0.0f, 1.0f);
			}
			var dx1 = x1 - x2;
			var dx2 = x3 - x2;
			var dy1 = y1 - y2;
			var dy2 = y3 - y2;
			var denominator = dx1 * dy2 - dx2 * dy1;
			var a13 = (dx3 * dy2 - dx2 * dy3) / denominator;
			var a23 = (dx1 * dy3 - dx3 * dy1) / denominator;
			return new PerspectiveTransform
			(x1 - x0 + a13 * x1, x3 - x0 + a23 * x3, x0,
				y1 - y0 + a13 * y1, y3 - y0 + a23 * y3, y0,
				a13, a23, 1.0f);
		}

		/// <summary> Returns a perspective transform mapping the quadrilateral defined by the four corner points to the unit square, via the adjoint of the inverse. </summary>
		///
		[Facets(Layer = "graphics", Status = "stable", Complexity = 3)]
		[Tags("code/perspective_transform", "code/computational_geometry")]
		[System.ComponentModel.Description("Returns a perspective transform mapping the quadrilateral defined by the four corner points to the unit square, via the adjoint of the inverse.")]
		[Concept("Mathematics\\Geometry.md")]
		public static PerspectiveTransform QuadrilateralToSquare(float x0, float y0, float x1, float y1, float x2, float y2,
			float x3, float y3)
			// Here, the adjoint serves as the inverse:
			=> SquareToQuadrilateral(x0, y0, x1, y1, x2, y2, x3, y3).BuildAdjoint();

		// Adjoint is the transpose of the co-factor matrix:
		/// <summary> Returns a new <see cref="PerspectiveTransform"/> that is the adjoint (transpose of the cofactor matrix) of this transform — equivalent to the inverse up to scaling. </summary>
		///
		[Facets(Layer = "graphics", Status = "stable", Complexity = 3)]
		[Tags("code/perspective_transform", "code/computational_geometry")]
		[System.ComponentModel.Description("Returns a new PerspectiveTransform that is the adjoint (transpose of the cofactor matrix) of this transform — equivalent to the inverse up to scaling.")]
		[Concept("Mathematics\\Geometry.md")]
		internal PerspectiveTransform BuildAdjoint() => new
		(A22 * A33 - A23 * A32,
			A23 * A31 - A21 * A33,
			A21 * A32 - A22 * A31,
			A13 * A32 - A12 * A33,
			A11 * A33 - A13 * A31,
			A12 * A31 - A11 * A32,
			A12 * A23 - A13 * A22,
			A13 * A21 - A11 * A23,
			A11 * A22 - A12 * A21);

		/// <summary> Returns the matrix product of this transform and <paramref name="other"/>, combining both perspective mappings. </summary>
		///
		[Facets(Layer = "graphics", Status = "stable", Complexity = 3)]
		[Tags("code/perspective_transform", "code/computational_geometry")]
		[System.ComponentModel.Description("Returns the matrix product of this transform and other, combining both perspective mappings.")]
		[Concept("Mathematics\\Geometry.md")]
		internal PerspectiveTransform Times(PerspectiveTransform other) => new
		(A11 * other.A11 + A21 * other.A12 + A31 * other.A13,
			A11 * other.A21 + A21 * other.A22 + A31 * other.A23,
			A11 * other.A31 + A21 * other.A32 + A31 * other.A33,
			A12 * other.A11 + A22 * other.A12 + A32 * other.A13,
			A12 * other.A21 + A22 * other.A22 + A32 * other.A23,
			A12 * other.A31 + A22 * other.A32 + A32 * other.A33,
			A13 * other.A11 + A23 * other.A12 + A33 * other.A13,
			A13 * other.A21 + A23 * other.A22 + A33 * other.A23,
			A13 * other.A31 + A23 * other.A32 + A33 * other.A33);

	}

}
