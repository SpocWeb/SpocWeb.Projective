using System.Numerics;
using org.SpocWeb.root.data.enumerables;
using org.SpocWeb.root.Attributes;

namespace org.SpocWeb.root.interfaces.Vectors; 

/// <summary> Closest-pair algorithms and utility extensions for <see cref="Point2D{T}"/> lists. </summary>
/// <remarks>
/// ## Public Methods
///
/// | Line | Method | Description |
/// |--:|---|---|
/// | 34 | <see cref="TestBruteForceAgainstRecursion"/> | Verifies that the divide-and-conquer closest-pair result matches brute force and is faster on 1 000 random points. |
/// | 56 | <see cref="ClosestPair"/> | Searches for the closest Pair in points |
/// | 114 | <see cref="Closest"/> | Finds the closest Pair by sorting points |
///
/// ## Collaborators
///
/// | Type | Role |
/// |---|---|
/// | <see cref="Segment2D"/> | Returned by a method. |
/// </remarks>
///
/// <seealso cref="Segment2D">Segment2D: Returned by a method.</seealso>
[DocState(Pass = 2, MTime = "2026-08-10T16:36:39Z", Digest = "322008dd702ded147496b9e7abe1209f63cc2d8a6462b05b895cfa7c93fce2ec", Stale = false, Path = "Interfaces/Vectors/Point2D.T.cs", Since = "2026-08-23")]
public static class XPoint2DList {

	/// <summary> Finds the closest pair of <paramref name="points"/> by checking all O(n²) pairs. </summary>
	static Segment2D<T> ClosestBruteForce<T>(IReadOnlyList<Point2D<T>> points) {
			int n = points.Count;
			var result = Enumerable.Range(0, n-1)
				.SelectMany( i => Enumerable.Range( i+1, n-(i+1) )
					.Select( j => new Segment2D<T>( points[i], points[j] )))
				.OrderBy( seg => seg.Length.NormSqr)
				.First();
 
			return result;
		}

#if NUNIT
	[NUnit.Framework.Test]
#endif //NUNIT
	/// <summary> Verifies that the divide-and-conquer closest-pair result matches brute force and is faster on 1 000 random points. </summary>
	public static void TestBruteForceAgainstRecursion() {
			var random = new Random(10);
			var points = Enumerable.Range( 0, 1_000)
				.Select(_ => new Point2D<int>(random.NextDouble(), random.NextDouble())).ToList();
			Stopwatch sw = Stopwatch.StartNew();
			var resultByForce = ClosestBruteForce(points);
			sw.Stop();
			var timeByForce = sw.Elapsed.TotalMilliseconds;
			Trace.WriteLine($"Time used (Brute force) (float): {timeByForce} ms");

			Stopwatch sw2 = Stopwatch.StartNew();
			var resultRecursive = ClosestPair(points);
			sw2.Stop();
			var timeRecursive = sw2.Elapsed.TotalMilliseconds;
			Trace.WriteLine($"Time used (Divide & Conquer): {timeRecursive} ms");
			resultRecursive.Length.Norm.ShouldBeApprox(resultByForce.Length.Norm);
			//resultRecursive.StartPos.ShouldBeCloseTo(resultByForce.StartPos);
			//resultRecursive.ShouldBe(resultByForce);
			_ = timeRecursive.ShouldBeLessThan(timeByForce);
		}

	/// <summary> Searches for the closest Pair in <paramref name="points"/> </summary>
	public static Segment2D<T> ClosestPair<T>(this IReadOnlyList<Point2D<T>> points) 
		=> ClosestRecursively(points.OrderBy(p => p.X).ToList());

	/// <summary> Divide-and-conquer closest-pair search over <paramref name="pointsByX"/> (already sorted by X). </summary>
	static Segment2D<T> ClosestRecursively<T>(IReadOnlyList<Point2D<T>> pointsByX) {
			int count = pointsByX.Count;
			if (count <= 4) {
				return ClosestBruteForce(pointsByX);
			}
			// left and right lists sorted by X, as order retained from full list
			var leftByX = pointsByX.Take(count / 2).ToList();
			var leftResult = ClosestRecursively(leftByX);

			var rightByX = pointsByX.Skip(count / 2).ToList();
			var rightResult = ClosestRecursively(rightByX);

			var result = rightResult.Length.NormSqr < leftResult.Length.NormSqr ? rightResult : leftResult;

			// There may be a shorter distance that crosses the divider
			// Thus, extract all the points within result.Length either side
			var midX = leftByX.Last().X;
			var bandWidth = result.Length.Norm;
			var inBandByX = pointsByX.Where(p => Math.Abs(midX - p.X) <= bandWidth);

			// Sort by Y, so we can efficiently check for closer pairs
			var inBandByY = inBandByX.OrderBy(p => p.Y).ToArray();

			int iLast = inBandByY.Length - 1;
			for (int i = 0; i < iLast; i++) {
				var pLower = inBandByY[i];

				for (int j = i + 1; j <= iLast; j++) {
					var pUpper = inBandByY[j];

					// Comparing each point to successively increasing Y values
					// Thus, can terminate as soon as deltaY is greater than best result
					if (pUpper.Y - pLower.Y >= result.Length.Norm) {
						break;
					}
					if ((pLower - pUpper).NormSqr < result.Length.NormSqr) {
						result = new Segment2D<T>(pLower, pUpper);
					}
				}
			}

			return result;
		}

	/// <summary> Finds the closest Pair by sorting <paramref name="points"/> </summary>
	/// <remarks>
	/// Targeted Search: Much simpler than divide and conquer, and actually runs faster for random points.
	/// Key optimization:
	/// if the distance along the X axis is greater than the best total length you already have,
	/// you can terminate the inner loop early.
	///
	/// However, as only sorts in the X direction,
	/// it degenerates into an N^2 algorithm if all the points have the same X.
	/// </remarks>
	public static Segment2D<T> Closest<T>(List<Point2D<T>> points) {
			int count = points.Count;
			points.Sort((lhs, rhs) => lhs.X.CompareTo(rhs.X));

			var result = new Segment2D<T>(points[0], points[1]);
			var bestLength = result.Length.NormSqr;

			for (int i = 0; i < count; i++) {
				var from = points[i];

				for (int j = i + 1; j < count; j++) {
					var to = points[j];

					var dx = to.X - from.X;
					if (dx >= bestLength) {
						break;
					} // ReSharper disable once InvertIf
					if ((from - to).NormSqr < bestLength) {
						result = new Segment2D<T>(from, to);
						bestLength = result.Length.NormSqr;
					}
				}
			}

			return result;
		}

}

/// <summary> AKA Position2D; Immutable, lightweight, double-Precision, typed Position2D to avoid accidental Type Mix in Arithmetic </summary>
///
/// <remarks>
/// This is a Position/Location/Radius 'Vector' with homogenous Coordinates (x, y, 1)
/// <see cref="Point2D"/> is untyped and has only single Precision. 
/// <see cref="Point2D{T}"/>s can NOT be scaled (unlike <see cref="Vector2D{T}"/>s), 
/// <see cref="Point2D{T}"/> with different Origins must NOT be mixed, therefore they are typed! 
/// <see cref="Vector2D{T}"/> CAN be mixed, therefore they are typed! 
/// 
/// Structs are faster, because allocated on the Stack, but only up to 24 Bytes (3 doubles resp 6 ints or float). 
/// Names are consistent with <see cref="Vector2"/> but uses double Precision
/// </remarks>
[DocState(Pass = 2, MTime = "2026-08-10T16:36:39Z", Digest = "d64395aefaebccf87c37fd2c9d8dd6c7d9cddf462d6bbc15daf5fa5bf0388b20", Stale = false, Path = "Interfaces/Vectors/Point2D.T.cs", Since = "2026-08-23")]
public readonly struct Point2D<T> : IPoint2D<T>, IEquatable<Point2D<T>>, IComparable<Point2D<T>> {
	// <summary> An Array would be even more flexible, but incurs Heap and Access Overhead </summary>
	//double[] _arr = new double[2];
	
	/// <summary> Uses the hardware-accelerated <see cref="Vector2"/> </summary>
	public readonly Vector2 Vector;

	/// <summary> Smallest representable point (both components at <see cref="float.MinValue"/>). </summary>
	public static readonly Point2D<T> MIN_VALUE = new(float.MinValue, float.MinValue);

	/// <summary> Largest representable point (both components at <see cref="float.MaxValue"/>). </summary>
	public static readonly Point2D<T> MAX_VALUE = new(float.MaxValue, float.MaxValue);

	/// <inheritdoc cref="IPoint2D{T}.X"/>
	public double X => Vector.X;

	/// <inheritdoc cref="IPoint2D{T}.Y"/>
	/// <inheritdoc />
	public double Y => Vector.Y;

	/// <inheritdoc />
	double IPoint2D<T>.X => Vector.X;

	/// <inheritdoc />
	double IPoint2D<T>.Y => Vector.Y;

	// ReSharper disable PossiblyImpureMethodCallOnReadonlyVariable
	/// <summary> Squared Euclidean norm: X²+Y². </summary>
	public double NormSqr => Vector.LengthSquared();

	/// <summary> L1 (Manhattan) norm: |X|+|Y|. </summary>
	public double NormAbs => Math.Abs(Vector.X) + Math.Abs(Vector.Y);

	/// <summary> Euclidean length: √(X²+Y²). </summary>
	public double Norm => Vector.Length();

	// ReSharper restore PossiblyImpureMethodCallOnReadonlyVariable
	
	/// <summary> Constructs a point from double-precision coordinates (cast to <see cref="float"/>). </summary>
	public Point2D(double x, double y) => Vector = new Vector2((float)x, (float)y);

	/// <summary> Constructs a point from single-precision coordinates. </summary>
	public Point2D(float x, float y) => Vector = new Vector2(x, y);

	/// <summary> Constructs a point from an existing <see cref="Vector2"/>. </summary>
	public Point2D(Vector2 vector) => Vector = vector;

	/// <summary> No Scaling, no Negation, only Subtraction and Addition of Vectors </summary>
	public static Point2D<T> operator +(Vector2D<T> self, Point2D<T> that) => new(self.Vector + that.Vector);

	/// <inheritdoc cref="operator +(Vector2D{T}, Point2D{T})"/>
	public static Point2D<T> operator +(Point2D<T> self, Vector2D<T> that) => new(self.Vector + that.Vector);

	/// <summary> Subtracts a displacement vector from this point, yielding a new <see cref="Point2D{T}"/>. </summary>
	public static Point2D<T> operator -(Point2D<T> self, Vector2D<T> that) => new(self.Vector - that.Vector);

	/// <summary> Returns the displacement vector from <paramref name="that"/> to <paramref name="self"/>. </summary>
	public static Vector2D<T> operator -(Point2D<T> self, Point2D<T> that) => new(self.Vector - that.Vector);

	/// <summary> Returns this point displaced by <paramref name="that"/>. </summary>
	public Point2D<T> Plus(Vector2D<T> that) => new(Vector + that.Vector);

	/// <summary> Returns the displacement vector from <paramref name="that"/> to this point. </summary>
	public Vector2D<T> Minus(Point2D<T> that) => new(Vector - that.Vector);

	/// <summary>Gets the number of elements.</summary>
	public int Count => 2;

	/// <summary> Returns the X component for index 0 and the Y component for index 1. </summary>
	public double this[int index]
	=> index switch {
	0 => Vector.X
	, 1 => Vector.Y
	, _ => throw new ArgumentOutOfRangeException(nameof(index), index, "must be 0 or 1")
	};

	/// <inheritdoc />
	IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

	/// <inheritdoc />
	public IEnumerator<double> GetEnumerator() {
	yield return Vector.X;
	yield return Vector.Y;
	}

	/// <inheritdoc />
	public override string ToString() => Vector.ToString();

	/// <summary> TODO: Does NOT math the Behavior of <see cref="Equals(Point2D{T})"/> </summary>
	public override int GetHashCode() => Vector.GetHashCode();

	/// <summary> Returns <see langword="true"/> when both components are within floating-point tolerance or both are NaN. </summary>
	public bool Equals(Point2D<T> that) => Vector.IsCloseToOrNaN(that.Vector);

	/// <inheritdoc cref="Equals(Point2D{T})"/>
	public bool Equals(IPoint2D<T> that) => that is not null
	&& Vector.X.IsCloseToOrNaN(that.X)
	&& Vector.Y.IsCloseToOrNaN(that.Y);

	/// <summary> Explicitly converts to the untyped <see cref="Point2D"/>. </summary>
	public static explicit operator Point2D(Point2D<T> self) => new(self.Vector);

	/// <summary> Explicitly converts from the untyped <see cref="Point2D"/>. </summary>
	public static explicit operator Point2D<T>(Point2D self) => new(self.Vector);

	/// <summary> Returns <see langword="true"/> when <paramref name="self"/> and <paramref name="that"/> are within floating-point tolerance. </summary>
	public static bool operator ==(Point2D<T> self, Point2D<T> that) => self.Equals(that);

	/// <inheritdoc cref="operator ==(Point2D{T}, Point2D{T})"/>
	public static bool operator !=(Point2D<T> self, Point2D<T> that) => !self.Equals(that);

	//public static bool operator ==(Position2D<T> self, IVector2D<T> that) => self.Equals(that);
	//public static bool operator ==(IVector2D<T> self, Position2D<T> that) => that.Equals(self);
	//public static bool operator !=(Position2D<T> self, IVector2D<T> that) => !self.Equals(that);
	//public static bool operator !=(IVector2D<T> self, Position2D<T> that) => !that.Equals(self);
	
	/// <inheritdoc />
	public override bool Equals(object? that) => that is Point2D<T> position && Equals(position);

	/// <summary> Arbitrary in multi-dimensional Spaces </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// pass: 2
	/// mtime: 2026-05-24T15:40:29Z
	/// digest: e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855
	/// </code>
	/// </example>
	/// <remarks>
	/// <see cref="XEnumerator.CompareTo{T}(System.Collections.Generic.IEnumerable{T},System.Collections.Generic.IEnumerable{T},System.Func{T,T,int}?)"/>
	/// does the same in a Loop.
	/// </remarks>
	public int CompareTo(Point2D<T> that) => Vector.CompareTo(that.Vector);

	}
	
	/// <summary> A List of Points to be interpreted as a List of Triangles connected to each other </summary>
/// <remarks>
/// This implicit Structure is quite common and saves looking up Vectors.
/// 2/3 of Transforms are saved by reusing the previous 2 Points. 
/// </remarks>
[DocState(Pass = 2, MTime = "2026-08-10T16:36:39Z", Digest = "e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855", Stale = false, Path = "Interfaces/Vectors/Point2D.T.cs", Since = "2026-08-23")]

public class TriangleStrip2D<T> : Point2DList<T>;

/// <summary> Allows for comfortable Declaration of ordered Lists and Polygons </summary>
/// <remarks>
/// ## Public Methods
///
/// | Line | Method | Description |
/// |--:|---|---|
/// | 310 | <see cref="Add"/> | Adds a new Point2D constructed from x and y. |
/// </remarks>
/// <example><code lang="C#">
/// new Point2DList{
///		{1.1,2.2},
///		{3.3,4.2},
///		...
/// }
/// </code></example>
/// <see cref="NaturalLang.NumbersAsWords.TupleList"/>
[DocState(Pass = 2, MTime = "2026-08-10T16:36:39Z", Digest = "029a6ebc8bd5266a11be2baf88b28afd53068c3e82e278a87aceb60894824ae0", Stale = false, Path = "Interfaces/Vectors/Point2D.T.cs", Since = "2026-08-23")]
public class Point2DList<T> : List<Point2D<T>> {
	/// <summary> Adds a new <see cref="Point2D{T}"/> constructed from <paramref name="x"/> and <paramref name="y"/>. </summary>
	public void Add(double x, double y) => Add(new Point2D<T>(x, y));
}
