using org.SpocWeb.root.array.strings;
using org.SpocWeb.root.Attributes;

namespace org.SpocWeb.root.interfaces.Vectors; 

/// <summary> AKA Slice2D; Lightweight passive 2D segment Pair (<see cref="Offset"/>/<see cref="Length"/> resp Start/End or <see cref="StartPos"/>/<see cref="StoppPos"/>). </summary>
/// <remarks>
/// To compare Segments, rather use <see cref="IInterval{T}"/> as the Points are sorted. 
/// Unlike <see cref="Interval{T}"/> this does NOT sort its Arguments,
/// so you can have a negative <see cref="Length"/>.
/// <see cref="Data.geo.Geo.Segment"/> redefined as a class. 
/// </remarks>
[DocState(Pass = 2, MTime = "2026-08-10T16:36:39Z", Digest = "32dcee966363ed20493b2639f02f04941524441f5e55a739eea0957ad63a4bf6", Stale = false, Path = "Interfaces/Vectors/Segment2D.cs", Since = "2026-08-23")]
public readonly struct Segment2D<T> : ISlice<Point2D<T>, Vector2D<T>> {

	/// <summary>Gets the offset.</summary>
	public Point2D<T> Offset => StartPos;

	/// <summary> AKA Start, AKA LeftPos </summary>
	public Point2D<T> StartPos { get; }

	/// <summary> AKA End, AKA RightPos </summary>
	public Point2D<T> StoppPos { get; }

	/// <summary>Gets the full.</summary>
	public IInterval<Point2D<T>> Full => FULL;
	/// <summary>Gets the fULL.</summary>
	public static readonly Segment2D<T> FULL = new(Point2D<T>.MIN_VALUE, Point2D<T>.MAX_VALUE);

	/// <summary> AKA Width; AKA Size </summary>
	public Vector2D<T> Length => StoppPos - StartPos; //{ get; }

	/// <summary>Initializes a new instance of <see cref="Segment2D"/> with the specified <paramref name="leftPos"/> and <paramref name="rightPos"/>.</summary>
	public Segment2D(Point2D<T> leftPos, Point2D<T> rightPos) {
			StartPos = leftPos;
			StoppPos = rightPos;
		}

	/// <summary>Initializes a new instance of <see cref="Segment2D"/> with the specified <paramref name="leftPos"/> and <paramref name="length"/>.</summary>
	public Segment2D(Point2D<T> leftPos, Vector2D<T> length) {
			StartPos = leftPos;
			StoppPos = leftPos + length;
		}

	/// <inheritdoc />
	public override string ToString() => StartPos + " + " + Length;

	/// <inheritdoc />
	public override bool Equals(object? that) => Equals(that as IInterval<Point2D<T>>);
	/// <inheritdoc cref="Equals(object?)"/>
	public bool Equals(IRange<Point2D<T>>? that) => StartPos == that?.StartPos && StoppPos == that.StoppPos;

	/// <inheritdoc />
	public override int GetHashCode() => StoppPos.GetHashCode() ^ (StartPos.GetHashCode() << 16);

	/// <summary> <returns> 0 also for the Edge Cases</returns> </summary>
	public int CompareTo(Point2D<T> that) => this.CompareSum(that);

	/// <summary>9 Cases: -4..4 </summary>
	public int CompareTo(IRange<Point2D<T>>? that) 
		=> CompareTo(that.StartPos) + CompareTo(that.StoppPos);

	/// <summary>Determines whether <paramref name="left"/> equals <paramref name="right"/>.</summary>
	public static bool operator ==(Segment2D<T> left, Segment2D<T> right) => left.Equals(right); 
	/// <summary>Determines whether <paramref name="left"/> does not equal <paramref name="right"/>.</summary>
	public static bool operator !=(Segment2D<T> left, Segment2D<T> right) => !left.Equals(right); 
	/// <summary>Determines whether <paramref name="left"/> equals <paramref name="right"/>.</summary>
	public static bool operator ==(Segment2D<T> left, IInterval<Point2D<T>> right) => left.Equals(right); 
	/// <summary>Determines whether <paramref name="left"/> does not equal <paramref name="right"/>.</summary>
	public static bool operator !=(Segment2D<T> left, IInterval<Point2D<T>> right) => !left.Equals(right); 
	/// <summary>Determines whether <paramref name="left"/> equals <paramref name="right"/>.</summary>
	public static bool operator ==(IInterval<Point2D<T>> left, Segment2D<T> right) => right.Equals(left); 
	/// <summary>Determines whether <paramref name="left"/> does not equal <paramref name="right"/>.</summary>
	public static bool operator !=(IInterval<Point2D<T>> left, Segment2D<T> right) => !right.Equals(left);

}
