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
//[Obsolete("Rather use Vector2, which is hardware-accelerated, but not enumerable")]
[DocState(Pass = 2, MTime = "2026-10-06T19:01:31Z", Digest = "ff37cfb8701b4c95e960b1c4b31a492faf79b321c1c12064ac0b0dcc4c84ab1c", Stale = false, Path = "typed/Point2Dbl.cs", Since = "2026-10-06")]
[Facets(Layer = "structures", Status = "broken", Complexity = 2)]
[Tags("code/value_object", "code/geometry")]
[System.ComponentModel.Description("AKA Vector2Dbl; 2D double-Precision, Platform-neutral Pendant to Size; this is a Vector like the hardware-accelerated Vector")]
[Concept("Mathematics\\Geometry\\Vector.md")]
[Concept("typed_geometric_primitives")]
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
	[Facets(Layer = "structures", Status = "broken", Complexity = 2)]
	[Tags("code/value_object", "code/geometry")]
	[System.ComponentModel.Description("Default Accuracy for IsCloseTo(Size2Dbl, double)")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	[Concept("typed_geometric_primitives")]
	public static double ACCURACY {
		get => _ACCURACY;
		set {
			_ACCURACY = value;
			NormUpper = 1 + _ACCURACY;
			NormLower = 1 - _ACCURACY;
		}
	}

	/// <summary> Threshold for expensive Norm Corrections </summary>
	[Facets(Layer = "structures", Status = "broken", Complexity = 2)]
	[Tags("code/value_object", "code/geometry")]
	[System.ComponentModel.Description("Threshold for expensive Norm Corrections")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	[Concept("typed_geometric_primitives")]
	public static double NormUpper { get; set; } = 1 + _ACCURACY;

	/// <summary> Lower threshold for expensive norm corrections (1 - <see cref="ACCURACY"/>). </summary>
	[Facets(Layer = "structures", Status = "broken", Complexity = 2)]
	[Tags("code/value_object", "code/geometry")]
	[System.ComponentModel.Description("Lower threshold for expensive norm corrections (1 - ACCURACY).")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	[Concept("typed_geometric_primitives")]
	public static double NormLower { get; set; } = 1 - _ACCURACY;

	/// <summary> The origin (0,0) </summary>
	public static readonly Size2Dbl Zero = new();
	/// <summary> <see langword="true"/> when both components are within <see cref="ACCURACY"/> of zero. </summary>
	[Facets(Layer = "structures", Status = "broken", Complexity = 2)]
	[Tags("code/value_object", "code/geometry")]
	[System.ComponentModel.Description("when both components are within ACCURACY of zero.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	[Concept("typed_geometric_primitives")]
	public bool IsZero() => Math.Abs(Length) < ACCURACY && Math.Abs(Width) < ACCURACY;

	/// <summary> The Unit X Position (1,0) </summary>
	public static readonly Size2Dbl UnitX = new(1, 0);

	/// <summary> The Unit Y Position (0,1) </summary>
	public static readonly Size2Dbl UnitY = new(0, 1);

	// ReSharper disable PossiblyImpureMethodCallOnReadonlyVariable
	/// <summary> Squared Euclidean length (Length² + Width²). </summary>
	[Facets(Layer = "structures", Status = "broken", Complexity = 2)]
	[Tags("code/value_object", "code/geometry")]
	[System.ComponentModel.Description("Squared Euclidean length (Length² + Width²).")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	[Concept("typed_geometric_primitives")]
	public double NormSqr => Length * Length + Width * Width;
	/// <summary> Euclidean length √(Length² + Width²). </summary>
	[Facets(Layer = "structures", Status = "broken", Complexity = 2)]
	[Tags("code/value_object", "code/geometry")]
	[System.ComponentModel.Description("Euclidean length √(Length² + Width²).")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	[Concept("typed_geometric_primitives")]
	public double Norm => Math.Sqrt(NormSqr);
	/// <summary> Manhattan (L1) length |Length| + |Width|. </summary>
	[Facets(Layer = "structures", Status = "broken", Complexity = 2)]
	[Tags("code/value_object", "code/geometry")]
	[System.ComponentModel.Description("Manhattan (L1) length |Length| + |Width|.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	[Concept("typed_geometric_primitives")]
	public double NormAbs => Math.Abs(Length) + Math.Abs(Width);
	// ReSharper restore PossiblyImpureMethodCallOnReadonlyVariable

	/// <summary> Constructs a vector from explicit <paramref name="width"/> and <paramref name="height"/> components. </summary>
	[Facets(Layer = "structures", Status = "broken", Complexity = 2)]
	[Tags("code/value_object", "code/geometry")]
	[System.ComponentModel.Description("Constructs a vector from explicit width and height components.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	[Concept("typed_geometric_primitives")]
	public Size2Dbl(double width, double height) { Length = width; Width = height; }
	/// <summary> Constructs a vector from a <see cref="Vector2"/> (single-precision). </summary>
	[Facets(Layer = "structures", Status = "broken", Complexity = 2)]
	[Tags("code/value_object", "code/geometry")]
	[System.ComponentModel.Description("Constructs a vector from a Vector2 (single-precision).")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	[Concept("typed_geometric_primitives")]
	public Size2Dbl(Vector2 vector) { Length = vector.X; Width = vector.Y; }

	/// <inheritdoc />
	IEnumerator<double> IEnumerable<double>.GetEnumerator() {
		yield return Length;
		yield return Width;
	}

	/// <inheritdoc />
	IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	/// <summary> Enumerates [Length, Width]. </summary>
	[Facets(Layer = "structures", Status = "broken", Complexity = 2)]
	[Tags("code/value_object", "code/geometry")]
	[System.ComponentModel.Description("Enumerates [Length, Width].")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	[Concept("typed_geometric_primitives")]
	public IEnumerator<double> GetEnumerator() {
		yield return Length;
		yield return Width;
	}

	/// <summary> Always 2. </summary>
	[Facets(Layer = "structures", Status = "broken", Complexity = 2)]
	[Tags("code/value_object", "code/geometry")]
	[System.ComponentModel.Description("Always 2.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	[Concept("typed_geometric_primitives")]
	public int Count => 2;

	/// <inheritdoc />
	double IReadOnlyList<double>.this[int index]
		=> index switch {
			0 => Length
			, 1 => Width
			, _ => throw new ArgumentOutOfRangeException(nameof(index), index, null)
		};

	/// <summary> Returns <see cref="Length"/> (index 0) or <see cref="Width"/> (index 1). </summary>
	[Facets(Layer = "structures", Status = "broken", Complexity = 2)]
	[Tags("code/value_object", "code/geometry")]
	[System.ComponentModel.Description("Returns Length (index 0) or Width (index 1).")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	[Concept("typed_geometric_primitives")]
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
	[Facets(Layer = "structures", Status = "broken", Complexity = 2)]
	[Tags("code/value_object", "code/geometry")]
	[System.ComponentModel.Description("Converts to a single-precision Vector2.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	[Concept("typed_geometric_primitives")]
	public Vector2 AsVector2() => new((float) Length, (float) Width);

	/// <summary> Component-wise addition. </summary>
	[Facets(Layer = "structures", Status = "broken", Complexity = 2)]
	[Tags("code/value_object", "code/geometry")]
	[System.ComponentModel.Description("Component-wise addition.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	[Concept("typed_geometric_primitives")]
	public Size2Dbl Plus(Size2Dbl s) => new(Length + s.Length, Width + s.Width);
	/// <summary> Component-wise subtraction. </summary>
	[Facets(Layer = "structures", Status = "broken", Complexity = 2)]
	[Tags("code/value_object", "code/geometry")]
	[System.ComponentModel.Description("Component-wise subtraction.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	[Concept("typed_geometric_primitives")]
	public Size2Dbl Minus(Size2Dbl s) => new(Length - s.Length, Width - s.Width);

	/// <summary> Scalar multiplication. </summary>
	[Facets(Layer = "structures", Status = "broken", Complexity = 2)]
	[Tags("code/value_object", "code/geometry")]
	[System.ComponentModel.Description("Scalar multiplication.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	[Concept("typed_geometric_primitives")]
	public Size2Dbl Times(double f) => new(Length * f, Width * f);
	/// <summary> Scalar division. </summary>
	[Facets(Layer = "structures", Status = "broken", Complexity = 2)]
	[Tags("code/value_object", "code/geometry")]
	[System.ComponentModel.Description("Scalar division.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	[Concept("typed_geometric_primitives")]
	public Size2Dbl Divide(double f) => new(Length / f, Width / f);

	/// <summary> Additive inverse (negation). </summary>
	[Facets(Layer = "structures", Status = "broken", Complexity = 2)]
	[Tags("code/value_object", "code/geometry")]
	[System.ComponentModel.Description("Additive inverse (negation).")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	[Concept("typed_geometric_primitives")]
	public Size2Dbl Minus() => new(-Length, -Width);
	/// <summary> Complex conjugate (same as negation for a real 2D vector). </summary>
	[Facets(Layer = "structures", Status = "broken", Complexity = 2)]
	[Tags("code/value_object", "code/geometry")]
	[System.ComponentModel.Description("Complex conjugate (same as negation for a real 2D vector).")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	[Concept("typed_geometric_primitives")]
	public Size2Dbl Cjg() => Minus();

	#region Equality members

	/// <inheritdoc />
	public override bool Equals(object? that) => that is Size2Dbl other && Equals(other);

	/// <inheritdoc />
	public override int GetHashCode() => (Length.GetHashCode() << 1) ^ Width.GetHashCode();

	/// <summary> <see langword="true"/> when <paramref name="that"/> is within <see cref="ACCURACY"/> of this vector. </summary>
	[Facets(Layer = "structures", Status = "broken", Complexity = 2)]
	[Tags("code/value_object", "code/geometry")]
	[System.ComponentModel.Description("when that is within ACCURACY of this vector.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	[Concept("typed_geometric_primitives")]
	public bool Equals(IVector2D? that) => that?.IsCloseTo(this) == true;
	/// <summary> Value equality within default <see cref="ACCURACY"/>. </summary>
	[Facets(Layer = "structures", Status = "broken", Complexity = 2)]
	[Tags("code/value_object", "code/geometry")]
	[System.ComponentModel.Description("Value equality within default ACCURACY.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	[Concept("typed_geometric_primitives")]
	public bool Equals(Size2Dbl that) => that.IsCloseTo(this);

	/// <inheritdoc />
	public override string ToString() => GetType().Name
	                                     + ": " + nameof(Length) + " = " + Length.ToString(CultureInfo.InvariantCulture)
	                                     + "; " + nameof(Width) + " = " + Width.ToString(CultureInfo.InvariantCulture);

	#endregion Equality members

	/// <summary> <see langword="true"/> when either component is NaN. </summary>
	[Facets(Layer = "structures", Status = "broken", Complexity = 2)]
	[Tags("code/value_object", "code/geometry")]
	[System.ComponentModel.Description("when either component is NaN.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	[Concept("typed_geometric_primitives")]
	[Pure] public
		bool IsNaN => double.IsNaN(Length) || double.IsNaN(Width);
	/// <summary> <see langword="true"/> when the distance to <paramref name="that"/> is within <paramref name="relAccuracySqr"/> (relative, squared). </summary>
	[Facets(Layer = "structures", Status = "broken", Complexity = 2)]
	[Tags("code/value_object", "code/geometry")]
	[System.ComponentModel.Description("when the distance to that is within relAccuracySqr (relative, squared).")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	[Concept("typed_geometric_primitives")]
	[Pure] [MethodImpl(MethodImplOptions.AggressiveInlining)] public
		bool IsCloseTo(Size2Dbl that, double relAccuracySqr)
		=> IsCloseToOrNaN(that, relAccuracySqr) && !IsNaN && !that.IsNaN;

	/// <summary> Like <see cref="IsCloseTo(Size2Dbl,double)"/> but returns <see langword="true"/> when either operand is NaN. </summary>
	[Facets(Layer = "structures", Status = "broken", Complexity = 2)]
	[Tags("code/value_object", "code/geometry")]
	[System.ComponentModel.Description("Like IsCloseTo(Size2Dbl, double) but returns when either operand is NaN.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	[Concept("typed_geometric_primitives")]
	[Pure] [MethodImpl(MethodImplOptions.AggressiveInlining)] public
		bool IsCloseToOrNaN(Size2Dbl that, double relAccuracySqr)
		=> Minus(that).NormSqr <= (NormSqr + that.NormSqr) * relAccuracySqr;

	/// <summary> <see langword="true"/> when neither component is infinite. </summary>
	[Facets(Layer = "structures", Status = "broken", Complexity = 2)]
	[Tags("code/value_object", "code/geometry")]
	[System.ComponentModel.Description("when neither component is infinite.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	[Concept("typed_geometric_primitives")]
	[Pure] public
		bool IsFinite => !double.IsInfinity(Length) || !double.IsInfinity(Width);
	/// <summary> <see langword="true"/> when either component is infinite. </summary>
	[Facets(Layer = "structures", Status = "broken", Complexity = 2)]
	[Tags("code/value_object", "code/geometry")]
	[System.ComponentModel.Description("when either component is infinite.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	[Concept("typed_geometric_primitives")]
	[Pure] public
		bool IsInfinite => double.IsInfinity(Length) || double.IsInfinity(Width);

	/// <summary> <see langword="true"/> when this is within default accuracy of <paramref name="y"/>. </summary>
	[Facets(Layer = "structures", Status = "broken", Complexity = 2)]
	[Tags("code/value_object", "code/geometry")]
	[System.ComponentModel.Description("when this is within default accuracy of y.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	[Concept("typed_geometric_primitives")]
	[Pure] [MethodImpl(MethodImplOptions.AggressiveInlining)] public
		bool IsCloseTo(Vector2 y) => IsCloseToOrNaN(y) && !IsNaN && !y.IsNaN();

	/// <summary> <see langword="true"/> when the distance to <paramref name="y"/> is within <paramref name="relAccuracySqr"/>. </summary>
	[Facets(Layer = "structures", Status = "broken", Complexity = 2)]
	[Tags("code/value_object", "code/geometry")]
	[System.ComponentModel.Description("when the distance to y is within relAccuracySqr.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	[Concept("typed_geometric_primitives")]
	[Pure] [MethodImpl(MethodImplOptions.AggressiveInlining)] public
		bool IsCloseTo(Vector2 y, double relAccuracySqr)
		=> IsCloseToOrNaN(y, relAccuracySqr) && !IsNaN && !y.IsNaN();

	/// <summary> Like <see cref="IsCloseTo(Vector2,double)"/> but returns <see langword="true"/> when either operand is NaN. </summary>
	[Facets(Layer = "structures", Status = "broken", Complexity = 2)]
	[Tags("code/value_object", "code/geometry")]
	[System.ComponentModel.Description("Like IsCloseTo(Vector2, double) but returns when either operand is NaN.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	[Concept("typed_geometric_primitives")]
	[Pure] [MethodImpl(MethodImplOptions.AggressiveInlining)] public
		bool IsCloseToOrNaN(Vector2 b, double relAccuracySqr)
		=> Minus(b).NormSqr <= (NormSqr + b.LengthSquared()) * relAccuracySqr;

	/// <summary> Like <see cref="IsCloseTo(Vector2)"/> using default accuracy, but returns <see langword="true"/> when either operand is NaN. </summary>
	[Facets(Layer = "structures", Status = "broken", Complexity = 2)]
	[Tags("code/value_object", "code/geometry")]
	[System.ComponentModel.Description("Like IsCloseTo(Vector2) using default accuracy, but returns when either operand is NaN.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	[Concept("typed_geometric_primitives")]
	[Pure] [MethodImpl(MethodImplOptions.AggressiveInlining)] public
		bool IsCloseToOrNaN(Vector2 b)
		=> Minus(b).NormSqr <= (NormSqr + b.LengthSquared()) * XDouble.RelAccuracySqr;

}

/// <summary> Extension Methods with <see cref="Size2Dbl"/> </summary>
/// <remarks>
/// ## Public Methods
///
/// | Line | Method | Description |
/// |--:|---|---|
/// | 386 | <see cref="Times"/> | Scalar multiplication (commutative scalar on left). |
/// </remarks>
///
[DocState(Pass = 2, MTime = "2026-07-14T17:11:43Z", Digest = "8fd461b1ea8a329ac42ce8da44eedb8622e33262c8b75778d545b7a6c770ba43", Stale = false, Path = "typed/Point2Dbl.cs", Since = "2026-10-06")]
[Facets(Layer = "domain", Status = "broken", Complexity = 1)]
[Tags("code/extension_method", "code/geometry")]
[System.ComponentModel.Description("Extension Methods with Size2Dbl")]
[Concept("Mathematics\\Geometry\\Vector.md")]
public static class XSize2Dbl {

	/// <summary> Scalar multiplication (commutative scalar on left). </summary>
	[Facets(Layer = "domain", Status = "broken", Complexity = 2)]
	[Tags("code/extension_method", "code/complex_numbers")]
	[System.ComponentModel.Description("Scalar multiplication (commutative scalar on left).")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	[Concept("complex_number")]
	public static Size2Dbl Times(this double f, Size2Dbl s) => s.Times(f);

	/// <summary> Rotates and Scales <paramref name="translate"/> by <paramref name="scaleRot"/> from the Right </summary>
	[Facets(Layer = "domain", Status = "broken", Complexity = 2)]
	[Tags("code/extension_method", "code/complex_numbers")]
	[System.ComponentModel.Description("Rotates and Scales translate by scaleRot from the Right")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	[Concept("complex_number")]
	public static Size2Dbl Times(this Size2Dbl translate, Complex scaleRot) => new
	(
		translate.Length * scaleRot.Real + scaleRot.Imaginary * translate.Width,
		translate.Width * scaleRot.Real - scaleRot.Imaginary * translate.Length);

	/// <summary> Rotates and Scales <paramref name="translate"/> by <paramref name="scaleRot"/> from the Left </summary>
	/// <remarks>
	/// With |<paramref name="scaleRot"/>| == 1 it implements the 2D Rotation Matrix. 
	/// </remarks>
	[Facets(Layer = "domain", Status = "broken", Complexity = 2)]
	[Tags("code/extension_method", "code/complex_numbers")]
	[System.ComponentModel.Description("Rotates and Scales translate by scaleRot from the Left")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	[Concept("complex_number")]
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
[DocState(Pass = 2, MTime = "2026-10-06T19:01:31Z", Digest = "4544b5ef6486423ecd53884dcc011092bc354cf75cd595d6a742704503592e33", Stale = false, Path = "typed/Point2Dbl.cs", Since = "2026-10-06")]
[Facets(Layer = "structures", Status = "broken", Complexity = 2)]
[Tags("code/value_object", "code/geometry")]
[System.ComponentModel.Description("Immutable, lightweight, single-Precision Pendant to System.Drawing.Point and Vector2")]
[Concept("Mathematics\\Geometry\\Vector.md")]
[Concept("typed_geometric_primitives")]
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
	[Facets(Layer = "structures", Status = "broken", Complexity = 2)]
	[Tags("code/value_object", "code/geometry")]
	[System.ComponentModel.Description("Squared Euclidean distance from the origin (X² + Y²).")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	[Concept("typed_geometric_primitives")]
	public double NormSqr => X * X + Y * Y;

	/// <summary> Euclidean distance from the origin √(X² + Y²). </summary>
	[Facets(Layer = "structures", Status = "broken", Complexity = 2)]
	[Tags("code/value_object", "code/geometry")]
	[System.ComponentModel.Description("Euclidean distance from the origin √(X² + Y²).")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	[Concept("typed_geometric_primitives")]
	public double Norm => Math.Sqrt(NormSqr);
	/// <summary> Manhattan (L1) distance from the origin |X| + |Y|. </summary>
	[Facets(Layer = "structures", Status = "broken", Complexity = 2)]
	[Tags("code/value_object", "code/geometry")]
	[System.ComponentModel.Description("Manhattan (L1) distance from the origin |X| + |Y|.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	[Concept("typed_geometric_primitives")]
	public double NormAbs => Math.Abs(X) + Math.Abs(Y);

	/// <summary> Constructs a point from a double-precision list [x, y]. </summary>
	[Facets(Layer = "structures", Status = "broken", Complexity = 2)]
	[Tags("code/value_object", "code/geometry")]
	[System.ComponentModel.Description("Constructs a point from a double-precision list [x, y].")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	[Concept("typed_geometric_primitives")]
	public Point2Dbl(IReadOnlyList<double> xy) { X = xy[0]; Y = xy[1]; }
	/// <summary> Constructs a point from a single-precision list [x, y]. </summary>
	[Facets(Layer = "structures", Status = "broken", Complexity = 2)]
	[Tags("code/value_object", "code/geometry")]
	[System.ComponentModel.Description("Constructs a point from a single-precision list [x, y].")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	[Concept("typed_geometric_primitives")]
	public Point2Dbl(IReadOnlyList<float> xy) { X = xy[0]; Y = xy[1]; }
	/// <summary> Constructs a point from explicit <paramref name="x"/> and <paramref name="y"/> coordinates. </summary>
	[Facets(Layer = "structures", Status = "broken", Complexity = 2)]
	[Tags("code/value_object", "code/geometry")]
	[System.ComponentModel.Description("Constructs a point from explicit x and y coordinates.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	[Concept("typed_geometric_primitives")]
	public Point2Dbl(double x, double y) { X = x; Y = y; }

	/// <summary> Constructs a point from a single-precision <see cref="Vector2"/>. </summary>
	[Facets(Layer = "structures", Status = "broken", Complexity = 2)]
	[Tags("code/value_object", "code/geometry")]
	[System.ComponentModel.Description("Constructs a point from a single-precision Vector2.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	[Concept("typed_geometric_primitives")]
	public Point2Dbl(Vector2 vector) { X = vector.X; Y = vector.Y; }

	/// <summary> <see langword="true"/> when <paramref name="that"/> is within default accuracy of this point. </summary>
	[Facets(Layer = "structures", Status = "broken", Complexity = 2)]
	[Tags("code/value_object", "code/geometry")]
	[System.ComponentModel.Description("when that is within default accuracy of this point.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	[Concept("typed_geometric_primitives")]
	public bool Equals(IPoint2D? that) => that?.IsCloseTo(this) == true;

	/// <inheritdoc />
	IEnumerator<double> IEnumerable<double>.GetEnumerator() {
		yield return X;
		yield return Y;
	}
	/// <inheritdoc />
	IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	/// <summary> Enumerates [X, Y]. </summary>
	[Facets(Layer = "structures", Status = "broken", Complexity = 2)]
	[Tags("code/value_object", "code/geometry")]
	[System.ComponentModel.Description("Enumerates [X, Y].")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	[Concept("typed_geometric_primitives")]
	public IEnumerator<double> GetEnumerator() {
		yield return X;
		yield return Y;
	}

	/// <summary> Always 2. </summary>
	[Facets(Layer = "structures", Status = "broken", Complexity = 2)]
	[Tags("code/value_object", "code/geometry")]
	[System.ComponentModel.Description("Always 2.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	[Concept("typed_geometric_primitives")]
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
	[Facets(Layer = "structures", Status = "broken", Complexity = 2)]
	[Tags("code/value_object", "code/geometry")]
	[System.ComponentModel.Description("Returns X (index 0) or Y (index 1).")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	[Concept("typed_geometric_primitives")]
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
	[Facets(Layer = "structures", Status = "broken", Complexity = 2)]
	[Tags("code/value_object", "code/geometry")]
	[System.ComponentModel.Description("Returns the point reflected through the origin.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	[Concept("typed_geometric_primitives")]
	public Point2Dbl Minus() => new(-X, -Y);
	/// <summary> Returns the displacement vector from <paramref name="point"/> to this. </summary>
	[Facets(Layer = "structures", Status = "broken", Complexity = 2)]
	[Tags("code/value_object", "code/geometry")]
	[System.ComponentModel.Description("Returns the displacement vector from point to this.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	[Concept("typed_geometric_primitives")]
	public Size2Dbl Minus(Point2Dbl point) => new(X - point.X, Y - point.Y);
	/// <summary> Returns the displacement vector from <paramref name="p2"/> to this. </summary>
	[Facets(Layer = "structures", Status = "broken", Complexity = 2)]
	[Tags("code/value_object", "code/geometry")]
	[System.ComponentModel.Description("Returns the displacement vector from p2 to this.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	[Concept("typed_geometric_primitives")]
	public IVector2D Minus(IPoint2D p2) => new Size2Dbl(X - p2.X, Y - p2.Y);

	/// <summary> Translates this point by subtracting <paramref name="size"/>. </summary>
	[Facets(Layer = "structures", Status = "broken", Complexity = 2)]
	[Tags("code/value_object", "code/geometry")]
	[System.ComponentModel.Description("Translates this point by subtracting size.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	[Concept("typed_geometric_primitives")]
	public Point2Dbl Minus(Size2Dbl size) => new(X - size.Length, Y - size.Width);
	/// <summary> Translates this point by adding <paramref name="size"/>. </summary>
	[Facets(Layer = "structures", Status = "broken", Complexity = 2)]
	[Tags("code/value_object", "code/geometry")]
	[System.ComponentModel.Description("Translates this point by adding size.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	[Concept("typed_geometric_primitives")]
	public Point2Dbl Plus(Size2Dbl size) => new(X + size.Length, Y + size.Width);

	/// <summary> Translates this point by subtracting a single-precision vector. </summary>
	[Facets(Layer = "structures", Status = "broken", Complexity = 2)]
	[Tags("code/value_object", "code/geometry")]
	[System.ComponentModel.Description("Translates this point by subtracting a single-precision vector.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	[Concept("typed_geometric_primitives")]
	public Point2Dbl Minus(Vector2 size) => new(X - size.X, Y - size.Y);
	/// <summary> Translates this point by adding a single-precision vector. </summary>
	[Facets(Layer = "structures", Status = "broken", Complexity = 2)]
	[Tags("code/value_object", "code/geometry")]
	[System.ComponentModel.Description("Translates this point by adding a single-precision vector.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	[Concept("typed_geometric_primitives")]
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
	[Facets(Layer = "structures", Status = "broken", Complexity = 2)]
	[Tags("code/value_object", "code/geometry")]
	[System.ComponentModel.Description("Reinterprets this point as a displacement vector from the origin.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	[Concept("typed_geometric_primitives")]
	public Size2Dbl AsSize2D() => new(X, Y);

	/// <summary> <see langword="true"/> when either coordinate is NaN. </summary>
	[Facets(Layer = "structures", Status = "broken", Complexity = 2)]
	[Tags("code/value_object", "code/geometry")]
	[System.ComponentModel.Description("when either coordinate is NaN.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	[Concept("typed_geometric_primitives")]
	[Pure] public
		bool IsNaN => double.IsNaN(X) || double.IsNaN(Y);
	/// <summary> <see langword="true"/> when the distance to <paramref name="that"/> is within <paramref name="relAccuracySqr"/> (relative, squared). </summary>
	[Facets(Layer = "structures", Status = "broken", Complexity = 2)]
	[Tags("code/value_object", "code/geometry")]
	[System.ComponentModel.Description("when the distance to that is within relAccuracySqr (relative, squared).")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	[Concept("typed_geometric_primitives")]
	[Pure] [MethodImpl(MethodImplOptions.AggressiveInlining)] public
		bool IsCloseTo(Point2Dbl that, double relAccuracySqr)
		=> IsCloseToOrNaN(that, relAccuracySqr) && !IsNaN && !that.IsNaN;

	/// <summary> Like <see cref="IsCloseTo(Point2Dbl,double)"/> but returns <see langword="true"/> when either operand is NaN. </summary>
	[Facets(Layer = "structures", Status = "broken", Complexity = 2)]
	[Tags("code/value_object", "code/geometry")]
	[System.ComponentModel.Description("Like IsCloseTo(Point2Dbl, double) but returns when either operand is NaN.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	[Concept("typed_geometric_primitives")]
	[Pure] [MethodImpl(MethodImplOptions.AggressiveInlining)] public
		bool IsCloseToOrNaN(Point2Dbl that, double relAccuracySqr)
		=> Minus(that).NormSqr <= (NormSqr + that.NormSqr) * relAccuracySqr;

	/// <summary> <see langword="true"/> when neither coordinate is infinite. </summary>
	[Facets(Layer = "structures", Status = "broken", Complexity = 2)]
	[Tags("code/value_object", "code/geometry")]
	[System.ComponentModel.Description("when neither coordinate is infinite.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	[Concept("typed_geometric_primitives")]
	[Pure] public
		bool IsFinite => !double.IsInfinity(X) || !double.IsInfinity(Y);
	/// <summary> <see langword="true"/> when either coordinate is infinite. </summary>
	[Facets(Layer = "structures", Status = "broken", Complexity = 2)]
	[Tags("code/value_object", "code/geometry")]
	[System.ComponentModel.Description("when either coordinate is infinite.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	[Concept("typed_geometric_primitives")]
	[Pure] public
		bool IsInfinite => double.IsInfinity(X) || double.IsInfinity(Y);

	/// <summary> <see langword="true"/> when this is within default accuracy of <paramref name="y"/>. </summary>
	[Facets(Layer = "structures", Status = "broken", Complexity = 2)]
	[Tags("code/value_object", "code/geometry")]
	[System.ComponentModel.Description("when this is within default accuracy of y.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	[Concept("typed_geometric_primitives")]
	[Pure] [MethodImpl(MethodImplOptions.AggressiveInlining)] public
		bool IsCloseTo(Vector2 y) => IsCloseToOrNaN(y) && !IsNaN && !y.IsNaN();

	/// <summary> <see langword="true"/> when the distance to <paramref name="y"/> is within <paramref name="relAccuracySqr"/>. </summary>
	[Facets(Layer = "structures", Status = "broken", Complexity = 2)]
	[Tags("code/value_object", "code/geometry")]
	[System.ComponentModel.Description("when the distance to y is within relAccuracySqr.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	[Concept("typed_geometric_primitives")]
	[Pure] [MethodImpl(MethodImplOptions.AggressiveInlining)] public
		bool IsCloseTo(Vector2 y, double relAccuracySqr)
		=> IsCloseToOrNaN(y, relAccuracySqr) && !IsNaN && !y.IsNaN();

	/// <summary> Like <see cref="IsCloseTo(Vector2,double)"/> but returns <see langword="true"/> when either operand is NaN. </summary>
	[Facets(Layer = "structures", Status = "broken", Complexity = 2)]
	[Tags("code/value_object", "code/geometry")]
	[System.ComponentModel.Description("Like IsCloseTo(Vector2, double) but returns when either operand is NaN.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	[Concept("typed_geometric_primitives")]
	[Pure] [MethodImpl(MethodImplOptions.AggressiveInlining)] public
		bool IsCloseToOrNaN(Vector2 b, double relAccuracySqr)
		=> Minus(b).NormSqr <= (NormSqr + b.LengthSquared()) * relAccuracySqr;

	/// <summary> Like <see cref="IsCloseTo(Vector2)"/> using default accuracy, but returns <see langword="true"/> when either operand is NaN. </summary>
	[Facets(Layer = "structures", Status = "broken", Complexity = 2)]
	[Tags("code/value_object", "code/geometry")]
	[System.ComponentModel.Description("Like IsCloseTo(Vector2) using default accuracy, but returns when either operand is NaN.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	[Concept("typed_geometric_primitives")]
	[Pure] [MethodImpl(MethodImplOptions.AggressiveInlining)] public
		bool IsCloseToOrNaN(Vector2 b)
		=> Minus(b).NormSqr <= (NormSqr + b.LengthSquared()) * XDouble.RelAccuracySqr;

}

/// <summary> Platform-neutral Pendant to System.Drawing.Rectangle </summary>
/// <remarks>
/// ## Public Methods
///
/// | Line | Method | Description |
/// |--:|---|---|
/// | 765 | <see cref="Rect2Dbl"/> | Constructs a rectangle from a point (top-left) and a size. |
/// | 780 | <see cref="X"/> | Left edge (X coordinate of Point). |
/// | 787 | <see cref="Y"/> | Top edge (Y coordinate of Point). |
/// | 795 | <see cref="Width"/> | Horizontal extent (Length component of Size). |
/// | 802 | <see cref="Height"/> | Vertical extent (Width component of Size). |
/// </remarks>
///
[DocState(Pass = 2, MTime = "2026-07-14T17:11:43Z", Digest = "808f9374941495308286bf85e83b76f00c6c2bb40d0819ff9ec7ec05abe100aa", Stale = false, Path = "typed/Point2Dbl.cs", Since = "2026-10-06")]
[Facets(Layer = "structures", Status = "broken", Complexity = 2)]
[Tags("code/value_object", "code/geometry")]
[System.ComponentModel.Description("Platform-neutral Pendant to System.Drawing.Rectangle")]
[Concept("Mathematics\\Geometry\\Vector.md")]
[Concept("typed_geometric_primitives")]
public readonly struct Rect2Dbl {

	#region Conceptually and Computationally higher Abstractions

	/// <summary> Top-left corner of the rectangle. </summary>
	public readonly Point2Dbl Point;
	/// <summary> Width and height of the rectangle. </summary>
	public readonly Size2Dbl Size;

	/// <summary> Constructs a rectangle from a <paramref name="point"/> (top-left) and a <paramref name="size"/>. </summary>
	[Facets(Layer = "structures", Status = "broken", Complexity = 2)]
	[Tags("code/value_object", "code/geometry")]
	[System.ComponentModel.Description("Constructs a rectangle from a point (top-left) and a size.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	[Concept("typed_geometric_primitives")]
	public Rect2Dbl(Point2Dbl point, Size2Dbl size) {
		Point = point;
		Size = size;
	}

	#endregion Conceptually and Computationally higher Abstractions

	#region Properties for the Law of Demeter

	/// <summary> Left edge (X coordinate of <see cref="Point"/>). </summary>
	[Facets(Layer = "structures", Status = "broken", Complexity = 2)]
	[Tags("code/value_object", "code/geometry")]
	[System.ComponentModel.Description("Left edge (X coordinate of Point).")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	[Concept("typed_geometric_primitives")]
	public double X => Point.X;
	/// <summary> Top edge (Y coordinate of <see cref="Point"/>). </summary>
	[Facets(Layer = "structures", Status = "broken", Complexity = 2)]
	[Tags("code/value_object", "code/geometry")]
	[System.ComponentModel.Description("Top edge (Y coordinate of Point).")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	[Concept("typed_geometric_primitives")]
	public double Y => Point.Y;

	/// <summary> Horizontal extent (Length component of <see cref="Size"/>). </summary>
	[Facets(Layer = "structures", Status = "broken", Complexity = 2)]
	[Tags("code/value_object", "code/geometry")]
	[System.ComponentModel.Description("Horizontal extent (Length component of Size).")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	[Concept("typed_geometric_primitives")]
	public double Width => Size.Length;
	/// <summary> Vertical extent (Width component of <see cref="Size"/>). </summary>
	[Facets(Layer = "structures", Status = "broken", Complexity = 2)]
	[Tags("code/value_object", "code/geometry")]
	[System.ComponentModel.Description("Vertical extent (Width component of Size).")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	[Concept("typed_geometric_primitives")]
	public double Height => Size.Width;

	#endregion Properties for the Law of Demeter
}

/// <summary> Extension methods for <see cref="Point2Dbl"/> and related 2D types. </summary>
/// <remarks>
/// ## Public Methods
///
/// | Line | Method | Description |
/// |--:|---|---|
/// | 825 | <see cref="IsCloseTo"/> | when the distance between arg1 and arg2 is within Accuracy. |
/// </remarks>
///
[DocState(Pass = 2, MTime = "2026-07-14T17:11:43Z", Digest = "7e4fa29226f76a97516c1b395958f6c948f99769087d42d63b0075274bd27436", Stale = false, Path = "typed/Point2Dbl.cs", Since = "2026-10-06")]
[Facets(Layer = "domain", Status = "broken", Complexity = 2)]
[Tags("code/extension_method", "code/geometry")]
[System.ComponentModel.Description("Extension methods for Point2Dbl and related 2D types.")]
[Concept("Mathematics\\Geometry\\Vector.md")]
public static class XPoint2Dbl {

	/// <summary> Default proximity threshold for <see cref="IsCloseTo"/>. </summary>
	public static double Accuracy = 1e-9;

	/// <summary> <see langword="true"/> when the distance between <paramref name="arg1"/> and <paramref name="arg2"/> is within <see cref="Accuracy"/>. </summary>
	[Facets(Layer = "domain", Status = "broken", Complexity = 1)]
	[Tags("code/extension_method", "code/tolerance_checking")]
	[System.ComponentModel.Description("when the distance between arg1 and arg2 is within Accuracy.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	[Concept("float_tolerance_comparison")]
	public static bool IsCloseTo(this Point2Dbl arg1, Point2Dbl arg2) => arg1.IsCloseTo(arg2, Accuracy);
}
