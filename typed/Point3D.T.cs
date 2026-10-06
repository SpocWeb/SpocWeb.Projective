using System.Numerics;
using org.SpocWeb.root.Attributes;

namespace org.SpocWeb.root.interfaces.Vectors; 

/// <summary> Typed Position3D Vector3D to avoid accidental Type Mix </summary>
/// <remarks>
/// Position3D Vector3Ds cannot be scaled like Vector3Ds. 
/// Position3D Vector3Ds with different Origins cannot be mixed! 
/// 
/// structs are faster, because allocated on the Stack, but only up to 24 Bytes (3 doubles). 
/// Names are consistent with <see cref="Vector3"/> but uses double Precision
/// </remarks>
[DocState(Pass = 2, MTime = "2026-09-22T07:27:58Z", Digest = "78b866b6c545ceb7063f5a9fb1b0220dc01de3a05a8b7e1490237ab551516c44", Stale = false, Path = "typed/Point3D.T.cs", Since = "2026-10-06")]
[Facets(Layer = "structures", Status = "buggy", Complexity = 3)]
[Tags("code/value_object", "code/vector_math")]
[System.ComponentModel.Description("Typed Position3D Vector3D to avoid accidental Type Mix")]
[Concept("Mathematics\\Geometry\\Vector.md")]
public readonly struct Point3D<T> : IPoint3D<T>, IEquatable<Point3D<T>?> {

	/// <summary> Uses the hardware-accelerated <see cref="Vector3"/> Type </summary>
	public readonly Vector3 Vector;
	/// <summary> Point at the minimum representable float coordinates. </summary>
	public static Point3D<T> MIN_VALUE = new(float.MinValue, float.MinValue, float.MinValue);
	/// <summary> Point at the maximum representable float coordinates. </summary>
	public static Point3D<T> MAX_VALUE = new(float.MaxValue, float.MaxValue, float.MaxValue);

	/// <summary>Gets the x.</summary>
	///
	[Facets(Layer = "structures", Status = "buggy", Complexity = 3)]
	[Tags("code/value_object", "code/vector_math")]
	[System.ComponentModel.Description("Gets the x.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public double X => Vector.X;
	/// <summary>Gets the y.</summary>
	///
	[Facets(Layer = "structures", Status = "buggy", Complexity = 3)]
	[Tags("code/value_object", "code/vector_math")]
	[System.ComponentModel.Description("Gets the y.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public double Y => Vector.Y;
	/// <summary>Gets the z.</summary>
	///
	[Facets(Layer = "structures", Status = "buggy", Complexity = 3)]
	[Tags("code/value_object", "code/vector_math")]
	[System.ComponentModel.Description("Gets the z.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public double Z => Vector.Z;

	/// <summary>Gets the norm Sqr.</summary>
	///
	[Facets(Layer = "structures", Status = "buggy", Complexity = 3)]
	[Tags("code/value_object", "code/vector_math")]
	[System.ComponentModel.Description("Gets the norm Sqr.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public double NormSqr => X * X + Y * Y + Z * Z;

	/// <summary>Gets the norm Abs.</summary>
	///
	[Facets(Layer = "structures", Status = "buggy", Complexity = 3)]
	[Tags("code/value_object", "code/vector_math")]
	[System.ComponentModel.Description("Gets the norm Abs.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public double NormAbs => Math.Abs(X) + Math.Abs(Y) + Math.Abs(Z);
	/// <summary>Gets the norm.</summary>
	///
	[Facets(Layer = "structures", Status = "buggy", Complexity = 3)]
	[Tags("code/value_object", "code/vector_math")]
	[System.ComponentModel.Description("Gets the norm.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public double Norm => NormSqr.SqRt();

	/// <inheritdoc />
	public override string ToString() => "(" + X + ';' + Y + ';' + Z + ')';

	/// <summary> Creates a point from an <see cref="IVector3D"/> interface value. </summary>
	///
	[Facets(Layer = "structures", Status = "buggy", Complexity = 3)]
	[Tags("code/value_object", "code/vector_math")]
	[System.ComponentModel.Description("Creates a point from an IVector3D interface value.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public Point3D(IVector3D vector) => Vector = new Vector3((float) vector.X, (float) vector.Y, (float) vector.Z);
	/// <summary> Creates a point from double-precision coordinates. </summary>
	///
	[Facets(Layer = "structures", Status = "buggy", Complexity = 3)]
	[Tags("code/value_object", "code/vector_math")]
	[System.ComponentModel.Description("Creates a point from double-precision coordinates.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public Point3D(double x, double y, double z) => Vector = new Vector3((float) x, (float) y, (float) z);
	/// <summary> Creates a point from single-precision coordinates. </summary>
	///
	[Facets(Layer = "structures", Status = "buggy", Complexity = 3)]
	[Tags("code/value_object", "code/vector_math")]
	[System.ComponentModel.Description("Creates a point from single-precision coordinates.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public Point3D(float x, float y, float z) => Vector = new Vector3(x, y, z);
	/// <summary> Creates a point wrapping an existing <see cref="Vector3"/>. </summary>
	///
	[Facets(Layer = "structures", Status = "buggy", Complexity = 3)]
	[Tags("code/value_object", "code/vector_math")]
	[System.ComponentModel.Description("Creates a point wrapping an existing Vector3.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public Point3D(Vector3 vector) => Vector = vector;

	/// <summary> Translates <paramref name="self"/> by <paramref name="that"/>. </summary>
	public static Point3D<T> operator +(Point3D<T> self, Vector3D<T> that) => self.Plus(that);
	/// <inheritdoc cref="op_Addition(Point3D{T},Vector3D{T})"/>
	public static Point3D<T> operator +(Point3D<T> self, IVector3D<T> that) => self.Plus(that);
	/// <inheritdoc cref="op_Addition(Point3D{T},Vector3D{T})"/>
	public static Point3D<T> operator +(Vector3D<T> self, Point3D<T> that) => that.Plus(self);
	/// <inheritdoc cref="op_Addition(Point3D{T},Vector3D{T})"/>
	public static Point3D<T> operator +(IVector3D<T> self, Point3D<T> that) => that.Plus(self);

	/// <summary> Returns the displacement vector from <paramref name="that"/> to <paramref name="self"/>. </summary>
	public static Vector3D<T> operator -(Point3D<T> self, Point3D<T> that) => self.Minus(that);

	/// <summary>Gets the number of elements.</summary>
	///
	[Facets(Layer = "structures", Status = "buggy", Complexity = 3)]
	[Tags("code/value_object", "code/vector_math")]
	[System.ComponentModel.Description("Gets the number of elements.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public int Count => 2;

	/// <summary>Gets or sets the element at the specified <paramref name="index"/>.</summary>
	///
	[Facets(Layer = "structures", Status = "buggy", Complexity = 3)]
	[Tags("code/value_object", "code/vector_math")]
	[System.ComponentModel.Description("Gets or sets the element at the specified index.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public double this[int index] => index switch {
		0 => X
		, 1 => Y
		, 2 => Z
		, _ => throw new ArgumentOutOfRangeException(nameof(index), index, "must be 0 to " + Count)
	};

	/// <inheritdoc />
	IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	/// <inheritdoc />
	public IEnumerator<double> GetEnumerator() {
		yield return X;
		yield return Y;
		yield return Z;
	}

	/// <summary> TODO: Does NOT math the Behavior of <see cref="Equals(Point3D{T})"/> </summary>
	///
	[Facets(Layer = "structures", Status = "buggy", Complexity = 3)]
	[Tags("code/value_object", "code/vector_math")]
	[System.ComponentModel.Description("TODO: Does NOT math the Behavior of Equals(Point3D)")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	public override int GetHashCode() => X.GetHashCode() ^ Y.GetHashCode() ^ Z.GetHashCode();

	/// <inheritdoc />
	public IPoint3D<T> Plus<V>(V addend) where V : IVector3D<IPoint3D<T>, T> => Plus((IVector3D<IVector3D<T>, T>) addend);
	/// <inheritdoc />
	public Point3D<T> Plus(Vector3D<T> that) => new(X + that.X, Y + that.Y, Z + that.Z);
	/// <inheritdoc />
	public Point3D<T> Plus(IVector3D<IVector3D<T>, T> addend)
		=> new(addend.X + X, addend.Y + Y, addend.Z + Z);

	/// <inheritdoc />
	public IPoint3D<T> Minus<P>(P subtrahend) where P : IVector3D<IPoint3D<T>, T> => Minus((IVector3D<IPoint3D<T>, T>)subtrahend);
	/// <inheritdoc />
	public Vector3D<T> Minus(Point3D<T> that) => new(X - that.X, Y - that.Y, Z - that.Z);
	/// <inheritdoc />
	public Point3D<T> Minus(IVector3D<IPoint3D<T>, T> subtrahend)
		=> new(X - subtrahend.X, Y - subtrahend.Y, Z - subtrahend.Z);

	/// <inheritdoc />
	public IPoint3D<T> MinusR<P>(P minuend) where P : IVector3D<IPoint3D<T>, T> => MinusR((IVector3D<IPoint3D<T>, T>) minuend);
	/// <inheritdoc />
	public Point3D<T> MinusR(IVector3D<IPoint3D<T>, T> minuend)
		=> new(minuend.X - X, minuend.Y - Y, minuend.Z - Z);

	/// <inheritdoc />
	public override bool Equals(object? that) {
		if (that is Point3D<T> point3D) {
			return Equals(point3D);
		}
		if (that is IPoint3D<T> iPoint3D) {
			return Equals(iPoint3D);
		}

		return false;
	}

	/// <inheritdoc />
	public bool Equals(Point3D<T>? that) => that is not null && Equals(that.Value);

	/// <inheritdoc />
	public bool Equals(Point3D<T> that) {
		var acc = (that.NormAbs + NormAbs).MulAccuracy();
		return X.IsApprox(that.X, acc) && Y.IsApprox(that.Y, acc) && Z.IsApprox(that.Z, acc);
	}

	/// <inheritdoc />
	public bool Equals(IPoint3D<T>? that) => Equals((IPoint3D?) that);
	//public bool Equals(Point3D<T>? that) => Equals((IPoint3D?) that);
	/// <inheritdoc />
	public bool Equals(IPoint3D? that) {
		if (that is null) {
			return false;
		}
		var acc = (that.NormAbs + NormAbs).MulAccuracy();
		return X.IsApprox(that.X, acc) && Y.IsApprox(that.Y, acc) && Z.IsApprox(that.Z, acc);
	}

	/// <summary> Returns <see langword="true"/> when both points are approximately equal. </summary>
	public static bool operator ==(Point3D<T> self, Point3D<T> that) => self.Equals(that);
	/// <summary> Returns <see langword="true"/> when the points differ. </summary>
	public static bool operator !=(Point3D<T> self, Point3D<T> that) => !self.Equals(that);
	//public static bool operator ==(Position3D<T> self, IVector3D<T> that) => self.Equals(that);
	//public static bool operator ==(IVector3D<T> self, Position3D<T> that) => that.Equals(self);
	//public static bool operator !=(Position3D<T> self, IVector3D<T> that) => !self.Equals(that);
	//public static bool operator !=(IVector3D<T> self, Position3D<T> that) => !that.Equals(self);

	/// <inheritdoc />
	public IPoint3D<T> Neg() => throw new NotImplementedException();

	/// <inheritdoc />
	public bool IsEqualTo<S>(S that) where S : IVector3D<IPoint3D<T>, T> => throw new NotImplementedException();

	/// <inheritdoc />
	public bool IsZero(double absAccuracy) => X.IsZero(absAccuracy) && Y.IsZero(absAccuracy) && Z.IsZero(absAccuracy);

	/// <inheritdoc />
	public int ValueHash() => throw new NotImplementedException();
}

/// <summary> A List of Points to be interpreted as a List of Triangles connected to each other </summary>
///
/// <remarks>
/// This implicit Structure is quite common and saves looking up Vectors.
/// 2/3 of Transforms are saved by reusing the previous 2 Points: 
///
/// 1-3-5-...
/// |/|/|/
/// 2-4-6
///
/// Triangle Fans all sharing the same Point
/// can be converted into Strips by repeating the center Point,
/// creating degenerated Line-Triangles:
///   2---3
///  / \ / \
/// 1---0---4
///  \ / \ /
///   6---5
///
/// 1-2-3-...
/// |/|/|/
/// 0-0-0
///
/// </remarks>
[DocState(Pass = 2, MTime = "2026-09-22T07:27:58Z", Digest = "e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855", Stale = false, Path = "typed/Point3D.T.cs", Since = "2026-10-06")]
[Facets(Layer = "domain", Status = "stable", Complexity = 1)]
[Tags("code/collection", "code/computational_geometry")]
[System.ComponentModel.Description("A List of Points to be interpreted as a List of Triangles connected to each other")]
[Concept("Mathematics\\Geometry\\Vector.md")]
public class TriangleStrip3D<T> : Point3DList<T>;

/// <summary> Allows for comfortable Declaration of ordered Lists and Polygons </summary>
/// <remarks>
/// ## Public Methods
///
/// | Line | Method | Description |
/// |--:|---|---|
/// | 287 | <see cref="Add"/> | Adds x to this instance. |
/// </remarks>
/// <example><code lang="C#">
/// new Point3DList{
///		{1.1,2.2},
///		{3.3,4.2},
///		...
/// }
/// </code></example>
/// <see cref="NaturalLang.NumbersAsWords.TupleList"/>
[Facets(Layer = "structures", Status = "legacy", Complexity = 1)]
[Tags("code/data_structure", "code/geometry")]
[System.ComponentModel.Description("Allows for comfortable Declaration of ordered Lists and Polygons")]
[Concept("Mathematics\\Geometry.md")]
[Concept("polygon")]
public class Point3DList<T> : List<Point3D<T>> {
	/// <summary>Adds <paramref name="x"/> to this instance.</summary>
	///
	[Facets(Layer = "structures", Status = "legacy", Complexity = 1)]
	[Tags("code/data_structure", "code/geometry")]
	[System.ComponentModel.Description("Adds x to this instance.")]
	[Concept("Mathematics\\Geometry.md")]
	[Concept("polygon")]
	public void Add(double x, double y, double z) => Add(new Point3D<T>(x, y, z));
}
