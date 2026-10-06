using System.Numerics;
using org.SpocWeb.root.Attributes;

namespace org.SpocWeb.root.interfaces.Vectors; 

/// <summary> Allows for comfortable Declaration of ordered Lists and Polygons </summary>
/// <remarks>
/// ## Public Methods
///
/// | Line | Method | Description |
/// |--:|---|---|
/// | 16 | <see cref="Add"/> | Appends a new point with the given coordinates. |
/// </remarks>
/// <example><code lang="C#">
/// new Point4DList{
///		{1.1,2.2},
///		{3.3,4.2},
///		...
/// }
/// </code></example>
/// <see cref="NaturalLang.NumbersAsWords.TupleList"/>
[DocState(Pass = 2, MTime = "2026-08-10T16:36:39Z", Digest = "673c2a69ab4629804804f86c3c07aa1802962fd34bd69cc0670e04ecc98686e6", Stale = false, Path = "Interfaces/Vectors/Point4D.T.cs", Since = "2026-08-23")]
public class Point4DList<T> : List<Point4D<T>> {
	/// <summary> Appends a new point with the given coordinates. </summary>
	public void Add(double x, double y, double z, double w) => Add(new Point4D<T>(x, y, z, w));
}

/// <summary> Typed Position3D Vector4D to avoid accidental Type Mix </summary>
/// <remarks>
/// Position3D Vector4Ds cannot be scaled like Vector4Ds. 
/// Position3D Vector4Ds with different Origins cannot be mixed! 
/// 
/// structs are faster, because allocated on the Stack, but only up to 24 Bytes (3 doubles). 
/// Names are consistent with <see cref="Vector4"/> but uses double Precision
/// </remarks>
/// <inheritdoc cref="IPoint4D{V}"/>
/// <inheritdoc cref="IEquatable{T}"/>
[DocState(Pass = 2, MTime = "2026-08-10T16:36:39Z", Digest = "89cc566cff2e454ccb3318cffe214c4e3bc618f4f6f666ec066f3c7022455a38", Stale = false, Path = "Interfaces/Vectors/Point4D.T.cs", Since = "2026-08-23")]
public readonly struct Point4D<T> : IPoint4D<T>, IEquatable<Point4D<T>>//, IPoint4D
{
	/// <summary> Uses the hardware-accelerated <see cref="Vector4"/> Type </summary>
	public readonly Vector4 V;

	/// <summary> Used as absolute lower Bound </summary>
	public static Point4D<T> MIN_VALUE = new(float.MinValue, float.MinValue, float.MinValue, float.MinValue);
	/// <summary> Used as absolute upper Bound </summary>
	public static Point4D<T> MAX_VALUE = new(float.MaxValue, float.MaxValue, float.MaxValue, float.MaxValue);

	/// <summary>Gets the w.</summary>
	public double W => V.W;
	/// <summary>Gets the x.</summary>
	public double X => V.X;
	/// <summary>Gets the y.</summary>
	public double Y => V.Y;
	/// <summary>Gets the z.</summary>
	public double Z => V.Z;

	/// <summary>Gets the norm Abs.</summary>
	public double NormAbs => V.NormAbs();
	/// <summary>Gets the norm Sqr.</summary>
	public double NormSqr => V.NormSqr();

	/// <summary>Gets the norm.</summary>
	public double Norm => NormSqr.SqRt();

	/// <summary> Determines whether this point's coordinates approximately equal <paramref name="other"/>'s. </summary>
	public bool Equals(IVector4D other) => this.IsApprox(other);
	/// <inheritdoc />
	public bool Equals(Point4D<T> other) => this.IsApprox(other);

	/// <inheritdoc />
	public bool Equals(IPoint4D<T>? other) => this.IsApprox(other);

	/// <inheritdoc />
	public override string ToString() => "(" + X + ';' + Y + ';' + Z + ';' + W + ')';

	/// <summary> Creates a point from an <see cref="IVector4D"/> interface value. </summary>
	public Point4D(IVector4D vector) => V = new Vector4((float) vector.X, (float) vector.Y, (float) vector.Z, (float) vector.W);
	/// <summary> Creates a point from double-precision coordinates. </summary>
	public Point4D(double x, double y, double z, double w) => V = new Vector4((float) x, (float) y, (float) z, (float) w);
	/// <summary> Creates a point from single-precision coordinates. </summary>
	public Point4D(float x, float y, float z, float w) => V = new Vector4(x, y, z, w);
	/// <summary> Creates a point wrapping an existing <see cref="Vector4"/>. </summary>
	public Point4D(Vector4 vector) => V = vector;

	/// <summary> Translates <paramref name="self"/> by <paramref name="that"/>. </summary>
	public static Point4D<T> operator +(Point4D<T> self, Vector4D<T> that)
		=> new(self.X + that.X, self.Y + that.Y, self.Z + that.Z, self.W + that.W);

	/// <inheritdoc cref="op_Addition(Point4D{T},Vector4D{T})"/>
	public static Point4D<T> operator +(Point4D<T> self, IVector4D<T> that)
		=> new(self.X + that.X, self.Y + that.Y, self.Z + that.Z, self.W - that.W);

	/// <inheritdoc cref="op_Addition(Point4D{T},Vector4D{T})"/>
	public static Point4D<T> operator +(Vector4D<T> self, Point4D<T> that)
		=> new(self.X + that.X, self.Y + that.Y, self.Z + that.Z, self.W + that.W);

	/// <inheritdoc cref="op_Addition(Point4D{T},Vector4D{T})"/>
	public static Point4D<T> operator +(IVector4D<T> self, Point4D<T> that)
		=> new(self.X + that.X, self.Y + that.Y, self.Z + that.Z, self.W + that.W);

	/// <summary> Returns the displacement vector from <paramref name="that"/> to <paramref name="self"/>. </summary>
	public static Vector4D<T> operator -(Point4D<T> self, Point4D<T> that)
		=> new(self.X - that.X, self.Y - that.Y, self.Z - that.Z, self.W - that.W);

	/// <summary> Returns this point translated by <paramref name="addend"/>. </summary>
	public Point4D<T> Plus(Vector4D<T> addend) => new(V + addend.V);
	/// <summary> Returns the displacement vector from <paramref name="subtrahend"/> to this point. </summary>
	public Vector4D<T> Minus(Point4D<T> subtrahend) => new(V - subtrahend.V);
	/// <summary> Returns the displacement vector from this point to <paramref name="minuend"/>. </summary>
	public Vector4D<T> MinusR(Point4D<T> minuend) => new(minuend.V - V);

#pragma warning disable 8633
	/// <inheritdoc />
	public bool IsEqualTo<S>(S that) where S : IVector4D<IPoint4D<T>, T> => this.IsApprox(that);

	/// <inheritdoc />
	public IPoint4D<T> Minus<P>(P subtrahend) where P : IVector4D<IPoint4D<T>, T>
		=> new Point4D<T>(V.X - subtrahend.X, V.Y - subtrahend.Y, V.Z - subtrahend.Z, V.W - subtrahend.W);

	/// <inheritdoc />
	public IPoint4D<T> Plus<V1>(V1 addend) where V1 : IVector4D<IPoint4D<T>, T>
		=> new Point4D<T>(addend.X + V.X, addend.Y + V.Y, addend.Z + V.Z, addend.W + V.W);

	/// <inheritdoc />
	public IPoint4D<T> MinusR<P>(P minuend) where P : IVector4D<IPoint4D<T>, T>
		=> new Point4D<T>(minuend.X - V.X, minuend.Y - V.Y, minuend.Z - V.Z, minuend.W - V.W);
#pragma warning restore 8633

	/// <summary>Gets the number of elements.</summary>
	public int Count => 2;

	/// <summary>Gets or sets the element at the specified <paramref name="index"/>.</summary>
	public double this[int index] => index switch {
		0 => X
		, 1 => Y
		, 2 => Z
		, 3 => W
		, _ => throw new ArgumentOutOfRangeException(nameof(index), index, @" must be 0..3")
	};

	/// <inheritdoc />
	IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	/// <inheritdoc />
	public IEnumerator<double> GetEnumerator() {
		yield return X;
		yield return Y;
		yield return Z;
		yield return W;
	}

	/// <summary> TODO: Does NOT math the Behavior of <see cref="Equals(Point4D{T})"/> </summary>
	public override int GetHashCode() => X.GetHashCode() ^ Y.GetHashCode() ^ Z.GetHashCode();

	/// <inheritdoc />
	public bool Equals(IVector4D<T>? that) => that is not null && this.IsApprox(that);
	/// <inheritdoc />
	public bool Equals(Point4D<T>? that) => that is not null && this.IsApprox(that);

	/// <inheritdoc />
	public override bool Equals(object? that) => that is Point4D<T> position && Equals(position);

	/// <summary> Returns <see langword="true"/> when both points are approximately equal. </summary>
	public static bool operator ==(Point4D<T> self, Point4D<T> that) => self.Equals(that);
	/// <summary> Returns <see langword="true"/> when the points differ. </summary>
	public static bool operator !=(Point4D<T> self, Point4D<T> that) => !self.Equals(that);
	//public static bool operator ==(Position3D<T> self, IVector4D<T> that) => self.Equals(that);
	//public static bool operator ==(IVector4D<T> self, Position3D<T> that) => that.Equals(self);
	//public static bool operator !=(Position3D<T> self, IVector4D<T> that) => !self.Equals(that);
	//public static bool operator !=(IVector4D<T> self, Position3D<T> that) => !that.Equals(self);
	/// <inheritdoc />
	public IPoint4D<T> Neg() => new Point4D<T>(-V);

	/// <inheritdoc />
	public bool IsZero(double absAccuracy) => V.IsZero(absAccuracy);

	/// <inheritdoc />
	public int ValueHash() => V.GetHashCode();
}
