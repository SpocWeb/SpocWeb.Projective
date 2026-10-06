using org.SpocWeb.root.Attributes;
namespace org.SpocWeb.root.interfaces.Vectors; 

/// <summary> Typed Position2D Vector2D to avoid accidental Type Mix </summary>
/// <remarks>
/// Position2D Vector2Ds cannot be scaled like Vector2Ds. 
/// Position2D Vector2Ds with different Origins cannot be mixed! 
/// 
/// structs are faster, because allocated on the Stack, but only up to 24 Bytes (3 doubles). 
/// </remarks>
[DocState(Pass = 2, MTime = "2026-07-29T18:02:50Z", Digest = "44704a11085368b4b112624e4b249c2f6a6d68d05d7169dc76667470672638b2", Stale = false, Path = "Interfaces/Vectors/Point4Dbl.T.cs", Since = "2026-08-23")]
public readonly struct Point4Dbl<T> : IEquatable<Point4Dbl<T>>, IReadOnlyList<double> {

	/// <summary> X coordinate. </summary>
	public readonly double X;

	/// <summary> Y coordinate. </summary>
	public readonly double Y;

	/// <summary> Z coordinate. </summary>
	public readonly double Z;

	/// <summary> W (homogeneous/time) coordinate. </summary>
	public readonly double W;

	/// <summary> Minkowski-metric squared norm: X²+Y²+Z²−W². </summary>
	public double NormSqr => X * X + Y * Y + Z * Z - W * W;

	/// <summary> Minkowski length: √(X²+Y²+Z²−W²). </summary>
	public double Norm => NormSqr.SqRt();

	/// <inheritdoc />
	public override string ToString() => "(" + X + ';' + Y + ';' + Z + ';' + W + ')';

	/// <summary> Constructs a <see cref="Point4Dbl{T}"/> from its four coordinates. </summary>
	public Point4Dbl(double x, double y, double z, double t)
		: this() {
			X = x;
			Y = y;
			Z = z;
			W = t;
		}

	/// <summary> Displaces this point by a <see cref="Vector4Dbl{T}"/>, yielding a new <see cref="Point4Dbl{T}"/>. </summary>
	public static Point4Dbl<T> operator +(Point4Dbl<T> self, Vector4Dbl<T> that)
		=> new(self.X + that.X, self.Y + that.Y, self.Z + that.Z, self.W + that.W);

	/// <inheritdoc cref="operator +(Point4Dbl{T}, Vector4Dbl{T})"/>
	public static Point4Dbl<T> operator +(Vector4Dbl<T> self, Point4Dbl<T> that)
		=> new(self.X + that.X, self.Y + that.Y, self.Z + that.Z, self.W + that.W);

	/// <summary> Returns the displacement vector from <paramref name="that"/> to <paramref name="self"/>. </summary>
	public static Vector4Dbl<T> operator -(Point4Dbl<T> self, Point4Dbl<T> that)
		=> new(self.X - that.X, self.Y - that.Y, self.Z - that.Z, self.W + that.W);

	/// <summary> Returns this point displaced by <paramref name="that"/>. </summary>
	public Point4Dbl<T> Plus(Vector4Dbl<T> that)
		=> new(X + that.X, Y + that.Y, Z + that.Z, W + that.W);

	/// <summary> Returns the displacement vector from <paramref name="that"/> to this point. </summary>
	public Vector4Dbl<T> Minus(Point4Dbl<T> that)
		=> new(X - that.X, Y - that.Y, Z - that.Z, W - that.W);

	/// <summary>Gets the number of elements.</summary>
	public int Count => 4;

	/// <summary> Returns X for 0, Y for 1, Z for 2, W for 3. </summary>
	public double this[int index] => index switch {
		0 => X
		, 1 => Y
		, 2 => Z
		, 3 => W
		, _ => throw new ArgumentOutOfRangeException(nameof(index), index, "must be 0 or 1")
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

	/// <summary> TODO: Does NOT math the Behavior of <see cref="Equals(Point4Dbl{T})"/> </summary>
	public override int GetHashCode() => X.GetHashCode() ^ Y.GetHashCode() ^ Z.GetHashCode() ^ W.GetHashCode();

	/// <summary> Returns <see langword="true"/> when all four components are within floating-point tolerance or both are NaN. </summary>
	public bool Equals(Point4Dbl<T> that)
		=> X.IsCloseToOrNaN(that.X) && Y.IsCloseToOrNaN(that.Y)
		                            && Z.IsCloseToOrNaN(that.Z) && W.IsCloseToOrNaN(that.W);

	/// <inheritdoc />
	public override bool Equals(object? that) => that is Point4Dbl<T> position && Equals(position);

}
