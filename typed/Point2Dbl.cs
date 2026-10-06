using org.SpocWeb.root.Attributes;
using System.Numerics;

namespace org.SpocWeb.root.interfaces.Vectors; 

/// <summary> AKA Vector2Dbl; 2D double-Precision, Platform-neutral Pendant to <see cref="System.Drawing.Size"/>; this is a Vector like the hardware-accelerated <see cref="Vector"/></summary>
/// <remarks>
/// This is a proper Vector with homogenous Coordinates (x, y, 0)
/// <see cref="Vector2"/> and <see cref="Vector2D{T}"/>
/// <see cref="Vector3"/> and <see cref="Vector3D{T}"/>
/// <see cref="Vector4"/> and <see cref="Vector4Dbl{T}"/>
/// </remarks>
/// <example>
/// <code language="yaml">
/// pass: 2
/// mtime: 2026-07-14T17:11:43Z
/// digest: 3798f14f760016f74c980cf38989bb805ac8da7d7ab598aa5c4b5c9cae7e0a1f
/// </code>
/// </example>
//[Obsolete("Rather use Vector2, which is hardware-accelerated, but not enumerable")]
public readonly struct Size2Dbl : IVector2D, IEquatable<Size2Dbl> {

	/// <summary> AKA Longitude; X-Extension; May be negative, although the Name seems to imply positive Definiteness like <see cref="Interval"/> </summary>
	/// <remarks>
	/// Better make it read-only to avoid tempting to modify a local copy
	/// </remarks>
	public readonly double Length;

	/// <summary> AKA Latitude; y-Extension; </summary>
	public readonly double Width;

	/// <inheritdoc />
	double ILocation2D<double>.Y => Length;
	/// <inheritdoc />
	double ILocation1D<double>.X => Width;

	static double _ACCURACY = 1e-9;

	/// <summary> Default Accuracy for <see cref="IsCloseTo(Size2Dbl, double)"/> </summary>
	public static double ACCURACY {
		get => _ACCURACY;
		set {
			_ACCURACY = value;
			NormUpper = 1 + _ACCURACY;
			NormLower = 1 - _ACCURACY;
		}
	}

	/// <summary> Threshold for expensive Norm Corrections </summary>
	public static double NormUpper { get; set; } = 1 + _ACCURACY;

	/// <summary> Lower threshold for expensive norm corrections (1 - <see cref="ACCURACY"/>). </summary>
	public static double NormLower { get; set; } = 1 - _ACCURACY;

	/// <summary> The origin (0,0) </summary>
	public static readonly Size2Dbl Zero = new();
	/// <summary> <see langword="true"/> when both components are within <see cref="ACCURACY"/> of zero. </summary>
	public bool IsZero() => Math.Abs(Length) < ACCURACY && Math.Abs(Width) < ACCURACY;

	/// <summary> The Unit X Position (1,0) </summary>
	public static readonly Size2Dbl UnitX = new(1, 0);

	/// <summary> The Unit Y Position (0,1) </summary>
	public static readonly Size2Dbl UnitY = new(0, 1);

	// ReSharper disable PossiblyImpureMethodCallOnReadonlyVariable
	/// <summary> Squared Euclidean length (Length² + Width²). </summary>
	public double NormSqr => Length * Length + Width * Width;
	/// <summary> Euclidean length √(Length² + Width²). </summary>
	public double Norm => Math.Sqrt(NormSqr);
	/// <summary> Manhattan (L1) length |Length| + |Width|. </summary>
	public double NormAbs => Math.Abs(Length) + Math.Abs(Width);
	// ReSharper restore PossiblyImpureMethodCallOnReadonlyVariable

	/// <summary> Constructs a vector from explicit <paramref name="width"/> and <paramref name="height"/> components. </summary>
	public Size2Dbl(double width, double height) { Length = width; Width = height; }
	/// <summary> Constructs a vector from a <see cref="Vector2"/> (single-precision). </summary>
	public Size2Dbl(Vector2 vector) { Length = vector.X; Width = vector.Y; }

	/// <inheritdoc />
	IEnumerator<double> IEnumerable<double>.GetEnumerator() {
		yield return Length;
		yield return Width;
	}

	/// <inheritdoc />
	IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	/// <summary> Enumerates [Length, Width]. </summary>
	public IEnumerator<double> GetEnumerator() {
		yield return Length;
		yield return Width;
	}

	/// <summary> Always 2. </summary>
	public int Count => 2;

	/// <inheritdoc />
	double IReadOnlyList<double>.this[int index]
		=> index switch {
			0 => Length
			, 1 => Width
			, _ => throw new ArgumentOutOfRangeException(nameof(index), index, null)
		};

	/// <summary> Returns <see cref="Length"/> (index 0) or <see cref="Width"/> (index 1). </summary>
	public double this[int index]
		=> index switch {
			0 => Length
			, 1 => Width
			, _ => throw new ArgumentOutOfRangeException(nameof(index), index, null)
		};

	#region operators

	/// <summary> Component-wise addition. </summary>
	public static Size2Dbl operator +(Size2Dbl p, Size2Dbl s) => p.Plus(s);
	/// <summary> Component-wise subtraction. </summary>
	public static Size2Dbl operator -(Size2Dbl p, Size2Dbl m) => p.Minus(m);

	/// <summary> Value equality within <see cref="ACCURACY"/>. </summary>
	public static bool operator ==(Size2Dbl p, Size2Dbl s) => p.Equals(s);
	/// <summary> Value inequality. </summary>
	public static bool operator !=(Size2Dbl p, Size2Dbl m) => !p.Equals(m);

	/// <summary> Negation (additive inverse). </summary>
	public static Size2Dbl operator -(Size2Dbl s) => s.Minus();
	///// <summary> returns the boolean Complement 1-this or the complex Conjugate/Transpose </summary>
	//public static Size2Dbl operator ~(Size2Dbl s) => s.Minus();
	//public static Size2Dbl operator *(Size2Dbl s) => s;
	//public static Size2Dbl operator /(Size2Dbl s) => s.Rcp();
	//public static Size2Dbl operator +(Size2Dbl s) => s;

	/// <summary> Scalar multiplication. </summary>
	public static Size2Dbl operator *(Size2Dbl s, double f) => s.Times(f);
	/// <summary> Scalar multiplication (commutative). </summary>
	public static Size2Dbl operator *(double f, Size2Dbl s) => s.Times(f);

	/// <summary> Scalar division. </summary>
	public static Size2Dbl operator /(Size2Dbl s, double f) => s.Divide(f);

	/// <summary> Implicit widening from single-precision <see cref="Vector2"/>. </summary>
	public static implicit operator Size2Dbl(Vector2 vector) => new(vector);
	/// <summary> Explicit narrowing to single-precision <see cref="Vector2"/>. </summary>
	public static explicit operator Vector2(Size2Dbl size) => size.AsVector2();

	#endregion operators

	/// <summary> Converts to a single-precision <see cref="Vector2"/>. </summary>
	public Vector2 AsVector2() => new((float) Length, (float) Width);

	/// <summary> Component-wise addition. </summary>
	public Size2Dbl Plus(Size2Dbl s) => new(Length + s.Length, Width + s.Width);
	/// <summary> Component-wise subtraction. </summary>
	public Size2Dbl Minus(Size2Dbl s) => new(Length - s.Length, Width - s.Width);

	/// <summary> Scalar multiplication. </summary>
	public Size2Dbl Times(double f) => new(Length * f, Width * f);
	/// <summary> Scalar division. </summary>
	public Size2Dbl Divide(double f) => new(Length / f, Width / f);

	/// <summary> Additive inverse (negation). </summary>
	public Size2Dbl Minus() => new(-Length, -Width);
	/// <summary> Complex conjugate (same as negation for a real 2D vector). </summary>
	public Size2Dbl Cjg() => Minus();

	#region Equality members

	/// <inheritdoc />
	public override bool Equals(object? that) => that is Size2Dbl other && Equals(other);

	/// <inheritdoc />
	public override int GetHashCode() => (Length.GetHashCode() << 1) ^ Width.GetHashCode();

	/// <summary> <see langword="true"/> when <paramref name="that"/> is within <see cref="ACCURACY"/> of this vector. </summary>
	public bool Equals(IVector2D? that) => that?.IsCloseTo(this) == true;
	/// <summary> Value equality within default <see cref="ACCURACY"/>. </summary>
	public bool Equals(Size2Dbl that) => that.IsCloseTo(this);

	/// <inheritdoc />
	public override string ToString() => GetType().Name
	                                     + ": " + nameof(Length) + " = " + Length.ToString(CultureInfo.InvariantCulture)
	                                     + "; " + nameof(Width) + " = " + Width.ToString(CultureInfo.InvariantCulture);

	#endregion Equality members

	/// <summary> <see langword="true"/> when either component is NaN. </summary>
	[Pure] public
		bool IsNaN => double.IsNaN(Length) || double.IsNaN(Width);
	/// <summary> <see langword="true"/> when the distance to <paramref name="that"/> is within <paramref name="relAccuracySqr"/> (relative, squared). </summary>
	[Pure] [MethodImpl(MethodImplOptions.AggressiveInlining)] public
		bool IsCloseTo(Size2Dbl that, double relAccuracySqr)
		=> IsCloseToOrNaN(that, relAccuracySqr) && !IsNaN && !that.IsNaN;

	/// <summary> Like <see cref="IsCloseTo(Size2Dbl,double)"/> but returns <see langword="true"/> when either operand is NaN. </summary>
	[Pure] [MethodImpl(MethodImplOptions.AggressiveInlining)] public
		bool IsCloseToOrNaN(Size2Dbl that, double relAccuracySqr)
		=> Minus(that).NormSqr <= (NormSqr + that.NormSqr) * relAccuracySqr;

	/// <summary> <see langword="true"/> when neither component is infinite. </summary>
	[Pure] public
		bool IsFinite => !double.IsInfinity(Length) || !double.IsInfinity(Width);
	/// <summary> <see langword="true"/> when either component is infinite. </summary>
	[Pure] public
		bool IsInfinite => double.IsInfinity(Length) || double.IsInfinity(Width);

	/// <summary> <see langword="true"/> when this is within default accuracy of <paramref name="y"/>. </summary>
	[Pure] [MethodImpl(MethodImplOptions.AggressiveInlining)] public
		bool IsCloseTo(Vector2 y) => IsCloseToOrNaN(y) && !IsNaN && !y.IsNaN();

	/// <summary> <see langword="true"/> when the distance to <paramref name="y"/> is within <paramref name="relAccuracySqr"/>. </summary>
	[Pure] [MethodImpl(MethodImplOptions.AggressiveInlining)] public
		bool IsCloseTo(Vector2 y, double relAccuracySqr)
		=> IsCloseToOrNaN(y, relAccuracySqr) && !IsNaN && !y.IsNaN();

	/// <summary> Like <see cref="IsCloseTo(Vector2,double)"/> but returns <see langword="true"/> when either operand is NaN. </summary>
	[Pure] [MethodImpl(MethodImplOptions.AggressiveInlining)] public
		bool IsCloseToOrNaN(Vector2 b, double relAccuracySqr)
		=> Minus(b).NormSqr <= (NormSqr + b.LengthSquared()) * relAccuracySqr;

	/// <summary> Like <see cref="IsCloseTo(Vector2)"/> using default accuracy, but returns <see langword="true"/> when either operand is NaN. </summary>
	[Pure] [MethodImpl(MethodImplOptions.AggressiveInlining)] public
		bool IsCloseToOrNaN(Vector2 b)
		=> Minus(b).NormSqr <= (NormSqr + b.LengthSquared()) * XDouble.RelAccuracySqr;

}

/// <summary> Extension Methods with <see cref="Size2Dbl"/> </summary>
///
/// <example>
/// <code language="yaml">
/// pass: 2
/// mtime: 2026-07-14T17:11:43Z
/// digest: 8fd461b1ea8a329ac42ce8da44eedb8622e33262c8b75778d545b7a6c770ba43
/// </code>
/// </example>
public static class XSize2Dbl {

	/// <summary> Scalar multiplication (commutative scalar on left). </summary>
	public static Size2Dbl Times(this double f, Size2Dbl s) => s.Times(f);

	/// <summary> Rotates and Scales <paramref name="translate"/> by <paramref name="scaleRot"/> from the Right </summary>
	public static Size2Dbl Times(this Size2Dbl translate, Complex scaleRot) => new
	(
		translate.Length * scaleRot.Real + scaleRot.Imaginary * translate.Width,
		translate.Width * scaleRot.Real - scaleRot.Imaginary * translate.Length);

	/// <summary> Rotates and Scales <paramref name="translate"/> by <paramref name="scaleRot"/> from the Left </summary>
	/// <remarks>
	/// With |<paramref name="scaleRot"/>| == 1 it implements the 2D Rotation Matrix. 
	/// </remarks>
	public static Size2Dbl Times(this Complex scaleRot, Size2Dbl translate, bool normalize = false) {
		var ret = new Size2Dbl(
			translate.Length * scaleRot.Real - scaleRot.Imaginary * translate.Width,
			translate.Width * scaleRot.Real + scaleRot.Imaginary * translate.Length);

		if (!normalize) {
			return ret;
		}
		var normSqr = scaleRot.NormSqr();
		if (normSqr > Size2Dbl.NormUpper ||
		    normSqr < Size2Dbl.NormLower &&
		    normSqr > 0) {
			ret /= Math.Sqrt(normSqr);
		}
		return ret;
	}

}

/// <summary> Immutable, lightweight, single-Precision Pendant to System.Drawing.Point and <see cref="Vector2"/> </summary>
/// <remarks>
/// This is a Position/Location/Radius 'Vector' with homogenous Coordinates (x, y, 1)
/// <see cref="Point2D{T}"/>s cannot be scaled (unlike <see cref="Vector2D{T}"/>s), 
/// 
/// <see cref="Vector2D{T}"/> for a strongly Typed Difference Vector
/// <see cref="Point"/> for integer Coordinates (on a 2D Raster Display)
/// <see cref="Point1D{S}"/> have immutable double Precision
/// <see cref="Point2D{V}"/>
/// <see cref="Point3D{T}"/>
/// <see cref="Point4Dbl{M}"/>
/// <see cref="ValueTuple"/> is a good alternative, because it supports (De-)Construction.
/// </remarks>
/// <example>
/// <code language="yaml">
/// pass: 2
/// mtime: 2026-07-14T17:11:43Z
/// digest: 0976fdd6c502b37fb2a6bcba3ca5a084ad78463a6d3bf78b5ef9e39dc88747c5
/// </code>
/// </example>
public readonly struct Point2Dbl : IPoint2D {

	/// <summary> Horizontal coordinate. </summary>
	public readonly double X;
	/// <summary> Vertical coordinate. </summary>
	public readonly double Y;

	/// <inheritdoc />
	double IPoint2D.X => X;
	/// <inheritdoc />
	double IPoint2D.Y => Y;

	/// <summary> Squared Euclidean distance from the origin (X² + Y²). </summary>
	public double NormSqr => X * X + Y * Y;

	/// <summary> Euclidean distance from the origin √(X² + Y²). </summary>
	public double Norm => Math.Sqrt(NormSqr);
	/// <summary> Manhattan (L1) distance from the origin |X| + |Y|. </summary>
	public double NormAbs => Math.Abs(X) + Math.Abs(Y);

	/// <summary> Constructs a point from a double-precision list [x, y]. </summary>
	public Point2Dbl(IReadOnlyList<double> xy) { X = xy[0]; Y = xy[1]; }
	/// <summary> Constructs a point from a single-precision list [x, y]. </summary>
	public Point2Dbl(IReadOnlyList<float> xy) { X = xy[0]; Y = xy[1]; }
	/// <summary> Constructs a point from explicit <paramref name="x"/> and <paramref name="y"/> coordinates. </summary>
	public Point2Dbl(double x, double y) { X = x; Y = y; }

	/// <summary> Constructs a point from a single-precision <see cref="Vector2"/>. </summary>
	public Point2Dbl(Vector2 vector) { X = vector.X; Y = vector.Y; }

	/// <summary> <see langword="true"/> when <paramref name="that"/> is within default accuracy of this point. </summary>
	public bool Equals(IPoint2D? that) => that?.IsCloseTo(this) == true;

	/// <inheritdoc />
	IEnumerator<double> IEnumerable<double>.GetEnumerator() {
		yield return X;
		yield return Y;
	}
	/// <inheritdoc />
	IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	/// <summary> Enumerates [X, Y]. </summary>
	public IEnumerator<double> GetEnumerator() {
		yield return X;
		yield return Y;
	}

	/// <summary> Always 2. </summary>
	public int Count => 2;

	/// <summary> The origin (0,0) </summary>
	public static readonly Point2Dbl Zero = new();

	/// <summary> The Unit X Position (1,0) </summary>
	public static readonly Point2Dbl UnitX = new(1, 0);

	/// <summary> The Unit Y Position (0,1) </summary>
	public static readonly Point2Dbl UnitY = new(0, 1);

	/// <inheritdoc />
	double IReadOnlyList<double>.this[int index] => this[index];
	/// <summary> Returns <see cref="X"/> (index 0) or <see cref="Y"/> (index 1). </summary>
	public double this[int index]
		=> index switch {
			0 => X
			, 1 => Y
			, _ => throw new ArgumentOutOfRangeException(nameof(index), index, null)
			/*set {
				switch (index) {
					case 0:  X = value; break;
					case 1:  Y = value; break;
					default: throw new ArgumentOutOfRangeException(nameof(index), index, null);
				}
			}*/
		};

	/// <summary> Returns the point reflected through the origin. </summary>
	public Point2Dbl Minus() => new(-X, -Y);
	/// <summary> Returns the displacement vector from <paramref name="point"/> to this. </summary>
	public Size2Dbl Minus(Point2Dbl point) => new(X - point.X, Y - point.Y);
	/// <summary> Returns the displacement vector from <paramref name="p2"/> to this. </summary>
	public IVector2D Minus(IPoint2D p2) => new Size2Dbl(X - p2.X, Y - p2.Y);

	/// <summary> Translates this point by subtracting <paramref name="size"/>. </summary>
	public Point2Dbl Minus(Size2Dbl size) => new(X - size.Length, Y - size.Width);
	/// <summary> Translates this point by adding <paramref name="size"/>. </summary>
	public Point2Dbl Plus(Size2Dbl size) => new(X + size.Length, Y + size.Width);

	/// <summary> Translates this point by subtracting a single-precision vector. </summary>
	public Point2Dbl Minus(Vector2 size) => new(X - size.X, Y - size.Y);
	/// <summary> Translates this point by adding a single-precision vector. </summary>
	public Point2Dbl Plus(Vector2 size) => new(X + size.X, Y + size.Y);

	/// <summary> Negation (reflection through origin). </summary>
	public static Point2Dbl operator -(Point2Dbl p1) => p1.Minus();
	/// <summary> Returns the displacement vector from <paramref name="p2"/> to <paramref name="p1"/>. </summary>
	public static Size2Dbl operator -(Point2Dbl p1, Point2Dbl p2) => p1.Minus(p2);
	//public static Size2Dbl operator -(Point2Dbl p1, Point2Dbl p2) => new Size2Dbl(p1.Vector -p2.Vector);

	/// <summary> Translates a point by subtracting a vector. </summary>
	public static Point2Dbl operator -(Point2Dbl p, Size2Dbl s) => p.Minus(s);
	/// <summary> Translates a point by adding a vector. </summary>
	public static Point2Dbl operator +(Point2Dbl p, Size2Dbl s) => p.Plus(s);
	/// <summary> Translates a point by adding a vector (commutative). </summary>
	public static Point2Dbl operator +(Size2Dbl s, Point2Dbl p) => p.Plus(s);

	/// <summary> Translates a point by subtracting a single-precision vector. </summary>
	public static Point2Dbl operator -(Point2Dbl p, Vector2 s) => p.Minus(s);
	/// <summary> Translates a point by adding a single-precision vector. </summary>
	public static Point2Dbl operator +(Point2Dbl p, Vector2 s) => p.Plus(s);
	/// <summary> Translates a point by adding a single-precision vector (commutative). </summary>
	public static Point2Dbl operator +(Vector2 s, Point2Dbl p) => p.Plus(s);

	/// <summary> Reinterprets this point as a displacement vector from the origin. </summary>
	public Size2Dbl AsSize2D() => new(X, Y);

	/// <summary> <see langword="true"/> when either coordinate is NaN. </summary>
	[Pure] public
		bool IsNaN => double.IsNaN(X) || double.IsNaN(Y);
	/// <summary> <see langword="true"/> when the distance to <paramref name="that"/> is within <paramref name="relAccuracySqr"/> (relative, squared). </summary>
	[Pure] [MethodImpl(MethodImplOptions.AggressiveInlining)] public
		bool IsCloseTo(Point2Dbl that, double relAccuracySqr)
		=> IsCloseToOrNaN(that, relAccuracySqr) && !IsNaN && !that.IsNaN;

	/// <summary> Like <see cref="IsCloseTo(Point2Dbl,double)"/> but returns <see langword="true"/> when either operand is NaN. </summary>
	[Pure] [MethodImpl(MethodImplOptions.AggressiveInlining)] public
		bool IsCloseToOrNaN(Point2Dbl that, double relAccuracySqr)
		=> Minus(that).NormSqr <= (NormSqr + that.NormSqr) * relAccuracySqr;

	/// <summary> <see langword="true"/> when neither coordinate is infinite. </summary>
	[Pure] public
		bool IsFinite => !double.IsInfinity(X) || !double.IsInfinity(Y);
	/// <summary> <see langword="true"/> when either coordinate is infinite. </summary>
	[Pure] public
		bool IsInfinite => double.IsInfinity(X) || double.IsInfinity(Y);

	/// <summary> <see langword="true"/> when this is within default accuracy of <paramref name="y"/>. </summary>
	[Pure] [MethodImpl(MethodImplOptions.AggressiveInlining)] public
		bool IsCloseTo(Vector2 y) => IsCloseToOrNaN(y) && !IsNaN && !y.IsNaN();

	/// <summary> <see langword="true"/> when the distance to <paramref name="y"/> is within <paramref name="relAccuracySqr"/>. </summary>
	[Pure] [MethodImpl(MethodImplOptions.AggressiveInlining)] public
		bool IsCloseTo(Vector2 y, double relAccuracySqr)
		=> IsCloseToOrNaN(y, relAccuracySqr) && !IsNaN && !y.IsNaN();

	/// <summary> Like <see cref="IsCloseTo(Vector2,double)"/> but returns <see langword="true"/> when either operand is NaN. </summary>
	[Pure] [MethodImpl(MethodImplOptions.AggressiveInlining)] public
		bool IsCloseToOrNaN(Vector2 b, double relAccuracySqr)
		=> Minus(b).NormSqr <= (NormSqr + b.LengthSquared()) * relAccuracySqr;

	/// <summary> Like <see cref="IsCloseTo(Vector2)"/> using default accuracy, but returns <see langword="true"/> when either operand is NaN. </summary>
	[Pure] [MethodImpl(MethodImplOptions.AggressiveInlining)] public
		bool IsCloseToOrNaN(Vector2 b)
		=> Minus(b).NormSqr <= (NormSqr + b.LengthSquared()) * XDouble.RelAccuracySqr;

}

/// <summary> Platform-neutral Pendant to System.Drawing.Rectangle </summary>
///
/// <example>
/// <code language="yaml">
/// pass: 2
/// mtime: 2026-07-14T17:11:43Z
/// digest: 808f9374941495308286bf85e83b76f00c6c2bb40d0819ff9ec7ec05abe100aa
/// </code>
/// </example>
public readonly struct Rect2Dbl {

	#region Conceptually and Computationally higher Abstractions

	/// <summary> Top-left corner of the rectangle. </summary>
	public readonly Point2Dbl Point;
	/// <summary> Width and height of the rectangle. </summary>
	public readonly Size2Dbl Size;

	/// <summary> Constructs a rectangle from a <paramref name="point"/> (top-left) and a <paramref name="size"/>. </summary>
	public Rect2Dbl(Point2Dbl point, Size2Dbl size) {
		Point = point;
		Size = size;
	}

	#endregion Conceptually and Computationally higher Abstractions

	#region Properties for the Law of Demeter

	/// <summary> Left edge (X coordinate of <see cref="Point"/>). </summary>
	public double X => Point.X;
	/// <summary> Top edge (Y coordinate of <see cref="Point"/>). </summary>
	public double Y => Point.Y;

	/// <summary> Horizontal extent (Length component of <see cref="Size"/>). </summary>
	public double Width => Size.Length;
	/// <summary> Vertical extent (Width component of <see cref="Size"/>). </summary>
	public double Height => Size.Width;

	#endregion Properties for the Law of Demeter
}

/// <summary> Extension methods for <see cref="Point2Dbl"/> and related 2D types. </summary>
///
/// <example>
/// <code language="yaml">
/// pass: 2
/// mtime: 2026-07-14T17:11:43Z
/// digest: 7e4fa29226f76a97516c1b395958f6c948f99769087d42d63b0075274bd27436
/// </code>
/// </example>
public static class XPoint2Dbl {

	/// <summary> Default proximity threshold for <see cref="IsCloseTo"/>. </summary>
	public static double Accuracy = 1e-9;

	/// <summary> <see langword="true"/> when the distance between <paramref name="arg1"/> and <paramref name="arg2"/> is within <see cref="Accuracy"/>. </summary>
	public static bool IsCloseTo(this Point2Dbl arg1, Point2Dbl arg2) => arg1.IsCloseTo(arg2, Accuracy);

	///// <summary> Rotates and Scales this by <paramref name="rightScaleRot"/> </summary>
	//public static Point2Dbl Times(this Point2Dbl translate, Complex rightScaleRot) => new Point2Dbl(
	//	(translate.X * rightScaleRot.Real + rightScaleRot.Imaginary * translate.Y),
	//	(translate.Y * rightScaleRot.Real - rightScaleRot.Imaginary * translate.X));

	//public static Point2Dbl Times(this Complex scaleRot, Point2Dbl rightTranslate) => new Point2Dbl(
	//	(rightTranslate.X * scaleRot.Real - scaleRot.Imaginary * rightTranslate.Y),
	//	(rightTranslate.Y * scaleRot.Real + scaleRot.Imaginary * rightTranslate.X));

	/// <summary> Rotates and Scales the <paramref name="vector"/> by <paramref name="scaleRot"/> </summary>
	public static Size2Dbl Times(this Vector2 vector, Complex scaleRot) => new(
		vector.X * scaleRot.Real + scaleRot.Imaginary * vector.Y,
		vector.Y * scaleRot.Real - scaleRot.Imaginary * vector.X);

	/// <summary> Rotates and Scales the <paramref name="vector"/> by <paramref name="scaleRot"/> </summary>
	/// <remarks>Multiplication from the Left results in opposite Rotation.
	/// Unlike the Sandwich Product, this performs only a single Rotation.
	/// </remarks>
	public static Size2Dbl Times(this Complex scaleRot, Vector2 vector) => new(
		vector.X * scaleRot.Real - scaleRot.Imaginary * vector.Y,
		vector.Y * scaleRot.Real + scaleRot.Imaginary * vector.X);

	static Segment2D<T> ClosestBruteForce<T>(IReadOnlyList<Point2D<T>> points) {
		int n = points.Count;
		var result = Enumerable.Range(0, n-1)
			.SelectMany( i => Enumerable.Range( i+1, n-(i+1) )
				.Select( j => new Segment2D<T>( points[i], points[j] )))
			.OrderBy( seg => seg.Length.NormSqr)
			.First();
 
		return result;
	}

	/// <summary> Verifies that the divide-and-conquer closest-pair result matches brute force and is faster. </summary>
#if NUNIT
	[NUnit.Framework.Test]
#endif //NUNIT
	public static void TestBruteForceAgainstRecursion() {
		var random = new Random(10);
		var points = Enumerable.Range( 0, 1_000)
			.Select( _ => new Point2D<int>(random.NextDouble(), random.NextDouble())).ToList();
		Stopwatch sw = Stopwatch.StartNew();
		var resultByForce = ClosestBruteForce(points);
		sw.Stop();
		var timeByForce = sw.Elapsed.TotalMilliseconds;
		Trace.WriteLine($"Time used (Brute force) (double): {timeByForce} ms");

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

	static Segment2D<T> ClosestRecursively<T>(this IReadOnlyList<Point2D<T>> pointsByX) {
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
		var midX = Enumerable.Last(leftByX).X;
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
	public static Segment2D<T> Closest<T>(this List<Point2D<T>> points) {
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
