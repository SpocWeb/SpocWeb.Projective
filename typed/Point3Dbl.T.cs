using org.SpocWeb.root.Attributes;
namespace org.SpocWeb.root.interfaces.Vectors; 

/// <summary> AKA Position/Location; Typed, double-precision Position3D Vector3D to avoid accidental Type Mix </summary>
/// <remarks>
/// Position3D Vector3Ds cannot be scaled like Vector3Ds. 
/// Position3D Vector3Ds with different Origins cannot be mixed! 
/// 
/// structs are faster, because allocated on the Stack, but only up to 24 Bytes (3 doubles). 
/// Names are consistent with <see cref="System.Numerics.Vector3"/> but uses double Precision
/// </remarks>
[Facets(Layer = "structures", Status = "legacy", Complexity = 2)]
[Tags("code/value_object", "code/geometry")]
[System.ComponentModel.Description("AKA Position/Location; Typed, double-precision Position3D Vector3D to avoid accidental Type Mix")]
[DocState(Pass = 2, MTime = "2026-10-06T19:01:31Z", Digest = "461c50db8dbfefa494d623f1cb1f2efc09984f7290d3133d5c7a68a5d340da5c", Stale = false, Path = "typed/Point3Dbl.T.cs", Since = "2026-08-23")]
[Concept("Mathematics\\Geometry\\Vector.md")]
[Concept("typed_geometric_primitives")]
public readonly struct Point3Dbl<T> : IEquatable<Point3Dbl<T>>, IReadOnlyList<double> {

	/// <summary> X coordinate. </summary>
	public readonly double X;

	/// <summary> Y coordinate. </summary>
	public readonly double Y;

	/// <summary> Z coordinate. </summary>
	public readonly double Z;

	/// <summary> Squared Euclidean norm: X²+Y²+Z². </summary>
	[Facets(Layer = "structures", Status = "legacy", Complexity = 2)]
	[Tags("code/value_object", "code/geometry")]
	[System.ComponentModel.Description("Squared Euclidean norm: X²+Y²+Z².")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	[Concept("typed_geometric_primitives")]
	public double NormSqr => X * X + Y * Y + Z * Z;

	/// <summary> Euclidean length: √(X²+Y²+Z²). </summary>
	[Facets(Layer = "structures", Status = "legacy", Complexity = 2)]
	[Tags("code/value_object", "code/geometry")]
	[System.ComponentModel.Description("Euclidean length: √(X²+Y²+Z²).")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	[Concept("typed_geometric_primitives")]
	public double Norm => NormSqr.SqRt();

	/// <inheritdoc />
	public override string ToString() => "(" + X + ';' + Y + ';' + Z + ')';

	/// <summary> Constructs a <see cref="Point3Dbl{T}"/> from its three coordinates. </summary>
	[Facets(Layer = "structures", Status = "legacy", Complexity = 2)]
	[Tags("code/value_object", "code/geometry")]
	[System.ComponentModel.Description("Constructs a Point3Dbl from its three coordinates.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	[Concept("typed_geometric_primitives")]
	public Point3Dbl(double x, double y, double z)
		: this() {
			X = x;
			Y = y;
			Z = z;
		}

	/// <summary> Displaces this point by a <see cref="Vector3D{T}"/>, yielding a new <see cref="Point3Dbl{T}"/>. </summary>
	public static Point3Dbl<T> operator +(Point3Dbl<T> self, Vector3D<T> that)
		=> new(self.X + that.X, self.Y + that.Y, self.Z + that.Z);

	/// <inheritdoc cref="operator +(Point3Dbl{T}, Vector3D{T})"/>
	public static Point3Dbl<T> operator +(Point3Dbl<T> self, IVector3D<T> that)
		=> new(self.X + that.X, self.Y + that.Y, self.Z + that.Z);

	/// <inheritdoc cref="operator +(Point3Dbl{T}, Vector3D{T})"/>
	public static Point3Dbl<T> operator +(Vector3D<T> self, Point3Dbl<T> that)
		=> new(self.X + that.X, self.Y + that.Y, self.Z + that.Z);

	/// <inheritdoc cref="operator +(Point3Dbl{T}, Vector3D{T})"/>
	public static Point3Dbl<T> operator +(IVector3D<T> self, Point3Dbl<T> that)
		=> new(self.X + that.X, self.Y + that.Y, self.Z + that.Z);

	/// <summary> Returns the displacement vector from <paramref name="that"/> to <paramref name="self"/>. </summary>
	public static Vector3D<T> operator -(Point3Dbl<T> self, Point3Dbl<T> that)
		=> new(self.X - that.X, self.Y - that.Y, self.Z - that.Z);

	/// <summary> Returns this point displaced by <paramref name="that"/>. </summary>
	[Facets(Layer = "structures", Status = "legacy", Complexity = 2)]
	[Tags("code/value_object", "code/geometry")]
	[System.ComponentModel.Description("Returns this point displaced by that.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	[Concept("typed_geometric_primitives")]
	public Point3Dbl<T> Plus(Vector3D<T> that)
		=> new(X + that.X, Y + that.Y, Z + that.Z);

	/// <summary> Returns the displacement vector from <paramref name="that"/> to this point. </summary>
	[Facets(Layer = "structures", Status = "legacy", Complexity = 2)]
	[Tags("code/value_object", "code/geometry")]
	[System.ComponentModel.Description("Returns the displacement vector from that to this point.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	[Concept("typed_geometric_primitives")]
	public Vector3D<T> Minus(Point3Dbl<T> that)
		=> new(X - that.X, Y - that.Y, Z - that.Z);

	/// <summary>Gets the number of elements.</summary>
	[Facets(Layer = "structures", Status = "legacy", Complexity = 2)]
	[Tags("code/value_object", "code/geometry")]
	[System.ComponentModel.Description("Gets the number of elements.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	[Concept("typed_geometric_primitives")]
	public int Count => 2;

	/// <summary> Returns X for index 0, Y for 1, Z for 2. </summary>
	[Facets(Layer = "structures", Status = "legacy", Complexity = 2)]
	[Tags("code/value_object", "code/geometry")]
	[System.ComponentModel.Description("Returns X for index 0, Y for 1, Z for 2.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	[Concept("typed_geometric_primitives")]
	public double this[int index] => index switch {
		0 => X
		, 1 => Y
		, 2 => Z
		, _ => throw new ArgumentOutOfRangeException(nameof(index), index, "must be 0 or 1")
	};

	/// <inheritdoc />
	IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	/// <inheritdoc />
	public IEnumerator<double> GetEnumerator() {
			yield return X;
			yield return Y;
			yield return Z;
		}

	/// <summary> TODO: Does NOT math the Behavior of <see cref="Equals(Point3Dbl{T})"/> </summary>
	[Facets(Layer = "structures", Status = "legacy", Complexity = 2)]
	[Tags("code/value_object", "code/geometry")]
	[System.ComponentModel.Description("TODO: Does NOT math the Behavior of Equals(Point3Dbl)")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	[Concept("typed_geometric_primitives")]
	public override int GetHashCode() => X.GetHashCode() ^ Y.GetHashCode() ^ Z.GetHashCode();

	/// <summary> Returns <see langword="true"/> when all three components are within floating-point tolerance or both are NaN. </summary>
	[Facets(Layer = "structures", Status = "legacy", Complexity = 2)]
	[Tags("code/value_object", "code/geometry")]
	[System.ComponentModel.Description("Returns when all three components are within floating-point tolerance or both are NaN.")]
	[Concept("Mathematics\\Geometry\\Vector.md")]
	[Concept("typed_geometric_primitives")]
	public bool Equals(Point3Dbl<T> that)
		=> X.IsCloseToOrNaN(that.X) && Y.IsCloseToOrNaN(that.Y) && Z.IsCloseToOrNaN(that.Z);

	/// <inheritdoc />
	public override bool Equals(object? that) => that is Point3Dbl<T> position && Equals(position);

	/// <summary> Returns <see langword="true"/> when <paramref name="self"/> and <paramref name="that"/> are within floating-point tolerance. </summary>
	public static bool operator ==(Point3Dbl<T> self, Point3Dbl<T> that) => self.Equals(that);
	/// <inheritdoc cref="operator ==(Point3Dbl{T}, Point3Dbl{T})"/>
	public static bool operator !=(Point3Dbl<T> self, Point3Dbl<T> that) => !self.Equals(that);
	//public static bool operator ==(Position3D<T> self, IVector3D<T> that) => self.Equals(that);
	//public static bool operator ==(IVector3D<T> self, Position3D<T> that) => that.Equals(self);
	//public static bool operator !=(Position3D<T> self, IVector3D<T> that) => !self.Equals(that);
	//public static bool operator !=(IVector3D<T> self, Position3D<T> that) => !that.Equals(self);
}
