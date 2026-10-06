using org.SpocWeb.root.array.strings;
using org.SpocWeb.root.data.enumerables;
using org.SpocWeb.root.Attributes;

namespace org.SpocWeb.root.interfaces.Vectors; 

/// <summary> Lightweight passive Space segment (Offset/Length pair). </summary>
/// <remarks>
/// Unlike <see cref="Interval{T}"/> this does NOT sort its Arguments,
/// so you can have a negative <see cref="Length"/>. 
/// </remarks>
[DocState(Pass = 2, MTime = "2026-08-10T16:36:39Z", Digest = "53bff2f088bf143c850f2c1efd78d8e9ca34953655252c51b78449eb7cca6d08", Stale = false, Path = "Interfaces/Vectors/Segment3D.cs", Since = "2026-08-23")]
public readonly struct Segment3D<T> : ISlice<Point3D<T>, Vector3D<T>> {

	/// <summary>Gets the full.</summary>
	public IInterval<Point3D<T>> Full => FULL;
	/// <summary> Singleton spanning the full range from <see cref="Point3D{T}.MIN_VALUE"/> to <see cref="Point3D{T}.MAX_VALUE"/>. </summary>
	public static readonly Segment3D<T> FULL = new(Point3D<T>.MIN_VALUE, Point3D<T>.MAX_VALUE);

	/// <summary>Gets the offset.</summary>
	public Point3D<T> Offset => StartPos;
	/// <summary> Starting position of this segment. </summary>
	public Point3D<T> StartPos { get; }

	/// <summary> Ending position of this segment. </summary>
	public Point3D<T> StoppPos { get; }

	/// <summary> Displacement vector from <see cref="StartPos"/> to <see cref="StoppPos"/>; may be negative. </summary>
	public Vector3D<T> Length => StoppPos - StartPos; //{ get; }

	/// <summary> Constructs a <see cref="Segment3D{T}"/> from explicit start and end positions. </summary>
	public Segment3D(Point3D<T> leftPos, Point3D<T> rightPos) {
		StartPos = leftPos;
		StoppPos = rightPos;
	}

	/// <summary> Constructs a <see cref="Segment3D{T}"/> from a start position and an offset <paramref name="length"/>. </summary>
	public Segment3D(Point3D<T> leftPos, Vector3D<T> length) {
		StartPos = leftPos;
		StoppPos = leftPos + length;
	}

	/// <inheritdoc />
	public override bool Equals(object? that) => Equals(that as IRange<Point3D<T>>);
	/// <summary> Returns <see langword="true"/> when both endpoints are equal. </summary>
	public bool Equals(IRange<Point3D<T>>? that) => StartPos == that?.StartPos && StoppPos == that.StoppPos;

	/// <inheritdoc />
	public override int GetHashCode() => StoppPos.GetHashCode() ^ (StartPos.GetHashCode() << 16);

	/// <summary> Returns negative/zero/positive when <paramref name="that"/> is before/inside/after this segment. </summary>
	public int CompareTo(Point3D<T> that) {
		var left = StartPos.CompareTo(that);
		var right = StoppPos.CompareTo(that);
		return left switch {
			< 0 when right < 0 => left,
			> 0 when right > 0 => right,
			_ => 0
		};
	}

	/// <summary>5 Cases: -4,-2,0,2,4 </summary>
	/// <remarks>
	/// 7 Cases when considering Edge Cases 
	/// </remarks>
	public int CompareTo(IRange<Point3D<T>>? that) => this.CompareSum(that);

	/// <summary> Returns <see langword="true"/> when both <see cref="Segment3D{T}"/> values are equal. </summary>
	public static bool operator ==(Segment3D<T> left, Segment3D<T> right) => left.Equals(right);
	/// <inheritdoc cref="operator ==(Segment3D{T}, Segment3D{T})"/>
	public static bool operator !=(Segment3D<T> left, Segment3D<T> right) => !left.Equals(right);
	/// <inheritdoc cref="operator ==(Segment3D{T}, Segment3D{T})"/>
	public static bool operator ==(Segment3D<T> left, IInterval<Point3D<T>> right) => left.Equals(right);
	/// <inheritdoc cref="operator ==(Segment3D{T}, Segment3D{T})"/>
	public static bool operator !=(Segment3D<T> left, IInterval<Point3D<T>> right) => !left.Equals(right);
	/// <inheritdoc cref="operator ==(Segment3D{T}, Segment3D{T})"/>
	public static bool operator ==(IInterval<Point3D<T>> left, Segment3D<T> right) => right.Equals(left);
	/// <inheritdoc cref="operator ==(Segment3D{T}, Segment3D{T})"/>
	public static bool operator !=(IInterval<Point3D<T>> left, Segment3D<T> right) => !right.Equals(left);

}