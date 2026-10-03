using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using org.SpocWeb.root.expressions;
using org.SpocWeb.root.extensions.maths;
using org.SpocWeb.root.interfaces;
using org.SpocWeb.root.interfaces.maths;

namespace org.SpocWeb.root.maths.pga;

/// <summary> Even sub-algebra of <see cref="Pga2D"/> G(2,0,1) encoding 2D rigid-body transformations<br/>
/// (rotation around Z and translation in X/Y) as a PGA Motor. </summary>
/// <remarks>
/// Contains basically all BiVectors:
/// 3*Translations and
/// 3*Rotations plus the necessary Scalar and Imaginary Elements.
///
/// 8 * 4 Bytes = 32 Bytes, still OK for a struct.
/// 
/// Saves half of both Memory and CPU.
/// Does not allocate on the Heap, but the Stack, which further improves Speed.
///
/// Any Number of successive Transformations combines to another Transformation,
/// that represents a Screw-Motion:
/// * a rotation around the Axis preceded or followed by
/// * a translation along the Axis
/// 
/// </remarks>
/// <example>
/// <code language="yaml">
/// pass: 2
/// mtime: 2026-05-24T15:36:37Z
/// digest: 48a7e5ae0e8a5f345db41134cb59e73ddb3c2e23b9ed4a0b622739d2b76a9d0c
/// tags: [code/projective_geometric_algebra, code/rigid_body_physics]
/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
/// facets: {layer: domain, status: stable, complexity: 2}
/// </code>
/// </example>
public readonly struct Motor2P : //IGeoGebra<Pga2DTrafo, float>, 
	IEquatable<Motor2P>, //AGeoGebra16<Pga2D>,
	IExpression<Motor2P>, //AGeoGebra16<Pga2D>,
	IReadOnlyList<float>
{
	/// <summary>Gets the basis.</summary>
	public static readonly IReadOnlyList<string> Basis = new[] {"" //1 Scalar 
		//"e0", "e1", "e2", 
		, "e01", "e20", "e12" // Point- Coordinates: 2 Translations + 1 Rotation
		//, "e0123" //1 Dual Pseudo-Scalar
	};

	/// <inheritdoc cref="Pga2D.Base._1_"/>
	/// <remarks> cos(phi) for Rotations, 1 for Translations = cos(0) </remarks>
	public readonly float _1_; //1 Scalar 


	/// <inheritdoc cref="Pga2D.Base.e01"/>
	public readonly float TransX;

	/// <inheritdoc cref="Pga2D.Base.e20"/>
	public readonly float TransY;


	/// <inheritdoc cref="Pga2D.Base.e12"/>
	public readonly float RotZ;

	/// <summary>Initializes a new instance of <see cref="Motor2P"/> with the specified <paramref name="scale"/>, <paramref name="transX"/>, <paramref name="transY"/> and <paramref name="rotZ"/>.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/projective_geometric_algebra, code/rigid_body_physics]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 2}
	/// </code>
	/// </example>
	public Motor2P(float scale, float transX, float transY, float rotZ)
	{
		_1_ = scale;
		TransX = transX;
		TransY = transY;
		RotZ = rotZ;
	}

	/// <summary> real e1 + e2 + projective e0 </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/projective_geometric_algebra, code/rigid_body_physics]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 2}
	/// </code>
	/// </example>
	public byte Dim => 3;

	/// <summary> 2^3 = 1 + 3 + 3 + 1 </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/projective_geometric_algebra, code/rigid_body_physics]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 2}
	/// </code>
	/// </example>
	public int Count => 8;

	/// <summary>Gets or sets the element at the specified <paramref name="index"/>.<br/>
	/// Gets or sets the element at the specified <paramref name="index"/>.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/projective_geometric_algebra, code/rigid_body_physics]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 2}
	/// </code>
	/// </example>
	public float this[int index] => this[(Pga2D.Base) index];
	/// <summary>Gets or sets the element at the specified <paramref name="index"/>.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/projective_geometric_algebra, code/rigid_body_physics]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 2}
	/// </code>
	/// </example>
	public float this[Pga2D.Base index] => index switch {
		Pga2D.Base._1_ => _1_,
		Pga2D.Base.e01 => TransX,
		Pga2D.Base.e20 => TransY,
		Pga2D.Base.e12 => RotZ,
		_ => 0
	};

	/// <summary>Gets or sets the element at the specified <paramref name="index"/>.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/projective_geometric_algebra, code/rigid_body_physics]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 2}
	/// </code>
	/// </example>
	public float this[Pga2D.Points index] => index switch {
		Pga2D.Points._1_ => _1_,
		Pga2D.Points.X => TransX,
		Pga2D.Points.Y => TransY,
		Pga2D.Points.O => RotZ,
		_ => 0
	};

	/// <inheritdoc />
	IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	/// <summary> yields 0s for the odd Grades </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/projective_geometric_algebra, code/rigid_body_physics]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 2}
	/// </code>
	/// </example>
	public IEnumerator<float> GetEnumerator() {
		yield return _1_;

		yield return 0;
		yield return 0;
		yield return 0;

		yield return TransX;
		yield return TransY;
		yield return RotZ;

		yield return 0;
	}

	/// <summary> Returns this motor as its own evaluated form (identity for <see cref="IExpression{T}"/>). </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/projective_geometric_algebra, code/rigid_body_physics]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 2}
	/// </code>
	/// </example>
	public Motor2P Evaluate() => this;
	/// <summary> Returns this motor as its own canonical form (identity for <see cref="IExpression{T}"/>). </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/projective_geometric_algebra, code/rigid_body_physics]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 2}
	/// </code>
	/// </example>
	public Motor2P Self() => this;

	/// <summary> Returns the hash code of this motor's coordinate values for use in expression caching. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/projective_geometric_algebra, code/rigid_body_physics]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 2}
	/// </code>
	/// </example>
	public int ValueHash() => GetHashCode();
	/// <inheritdoc />
	public override int GetHashCode() => (((((_1_.GetHashCode() << 1) ^ TransX.GetHashCode()) << 1) ^ TransY.GetHashCode()) << 1) ^ RotZ.GetHashCode();

	/// <inheritdoc />
	public override bool Equals(object obj) => obj is Motor2P trafo && Equals(trafo);
	/// <summary>Determines whether equal To.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/projective_geometric_algebra, code/rigid_body_physics]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 2}
	/// </code>
	/// </example>
	public bool IsEqualTo(Motor2P that) => Equals(that);

	/// <inheritdoc cref="Equals(object)"/>
	public bool Equals(Motor2P other) {
		var norm = NormAbs().MulAccuracy();
		return _1_.IsApprox(other._1_, norm)
			&& TransX.IsApprox(other.TransX, norm)
			&& TransY.IsApprox(other.TransY, norm)
			&& RotZ.IsApprox(other.RotZ, norm);
	}

	/// <summary> Returns the L1 (Manhattan) norm of this motor's four coordinate components. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/projective_geometric_algebra, code/rigid_body_physics]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 2}
	/// </code>
	/// </example>
	public double NormAbs() => Math.Abs(_1_) + Math.Abs(TransX) + Math.Abs(TransY) + Math.Abs(RotZ);

	/// <summary> Scales all components of this motor by the given scalar <paramref name="factor"/>. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/projective_geometric_algebra, code/rigid_body_physics]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 2}
	/// </code>
	/// </example>
	public Motor2P Times(double factor) => Times((float)factor);
	/// <inheritdoc cref="Times(double)"/>
	public Motor2P Times(float factor) => new(factor * _1_
		, factor * TransX, factor * TransY, factor * RotZ);

	/// <inheritdoc cref="Times(double)"/>
	public Motor2P Times<S>(S multiplicand) where S : IIMeasureAble => Times((float)multiplicand.AsDouble());

	public static string Infix = ", ";
	/// <summary> Writes the four motor components to <paramref name="writer"/> separated by <see cref="Infix"/>. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/projective_geometric_algebra, code/rigid_body_physics]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 2}
	/// </code>
	/// </example>
	public long WriteTo(TextWriter writer, long lengthLeft) {
		//new Pga2D().WriteTo(writer, lengthLeft);
		//MemoryMarshal.Cast< Trafo3P, float >(this);
		writer.Write(_1_);
		writer.Write(Infix); writer.Write(TransX);
		writer.Write(Infix); writer.Write(TransY);
		writer.Write(Infix); writer.Write(RotZ);
		return lengthLeft;
	}

	/// <summary>Determines whether zero.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/projective_geometric_algebra, code/rigid_body_physics]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 2}
	/// </code>
	/// </example>
	public bool IsZero() => _1_.IsSmall() && TransX.IsSmall() && TransY.IsSmall() && RotZ.IsSmall();

	/// <summary> Returns the squared norm of this motor's rotational part (scalar² + rotZ²). </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/projective_geometric_algebra, code/rigid_body_physics]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 2}
	/// </code>
	/// </example>
	public double NormSqr() => _1_.Sqr() + RotZ.Sqr();

	/// <summary> Returns this motor with all components negated. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/projective_geometric_algebra, code/rigid_body_physics]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 2}
	/// </code>
	/// </example>
	public Motor2P Neg() => new(-_1_, -TransX, -TransY, -RotZ);
	/// <summary> Returns the Poincaré dual of this motor by swapping scalar and bivector components. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/projective_geometric_algebra, code/rigid_body_physics]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 2}
	/// </code>
	/// </example>
	public Motor2P Dual() => new(RotZ, TransY, TransX, _1_);

	/// <inheritdoc cref="Plus(Motor2P)"/>
	public Motor2P Plus(double value, Pga2D.Base basis) => basis switch {
		Pga2D.Base._1_ => new(_1_ + (float) value, TransX, TransY, RotZ),
		Pga2D.Base.e01 => new(_1_, TransX + (float) value, TransY, RotZ),
		Pga2D.Base.e20 => new(_1_, TransX, TransY + (float) value, RotZ),
		Pga2D.Base.e12 => new(_1_, TransX, TransY, RotZ + (float) value),
		_ => throw new ArgumentOutOfRangeException(nameof(basis), basis, null)
	};

	/// <inheritdoc cref="Minus(Motor2P)"/>
	public Motor2P Minus(double value, Pga2D.Base basis) => basis switch {
		Pga2D.Base._1_ => new(_1_ - (float) value, TransX, TransY, RotZ),
		Pga2D.Base.e01 => new(_1_, TransX - (float) value, TransY, RotZ),
		Pga2D.Base.e20 => new(_1_, TransX, TransY - (float) value, RotZ),
		Pga2D.Base.e12 => new(_1_, TransX, TransY, RotZ - (float) value),
		_ => throw new ArgumentOutOfRangeException(nameof(basis), basis, null)
	};

	/// <inheritdoc cref="MinusR(Motor2P)"/>
	public Motor2P MinusR(double value, Pga2D.Base basis) => basis switch {
		Pga2D.Base._1_ => new((float)value - _1_, -TransX, -TransY, -RotZ),
		Pga2D.Base.e01 => new(-_1_, (float)value - TransX, -TransY, -RotZ),
		Pga2D.Base.e20 => new(-_1_, -TransX, (float)value - TransY, -RotZ),
		Pga2D.Base.e12 => new(-_1_, -TransX, -TransY, (float)value - RotZ),
		_ => throw new ArgumentOutOfRangeException(nameof(basis), basis, null)
	};

	/// <summary> Subtracts <paramref name="subtrahend"/> component-wise from this motor. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/projective_geometric_algebra, code/rigid_body_physics]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 2}
	/// </code>
	/// </example>
	public Motor2P Minus(Motor2P subtrahend) => new(
		_1_ - subtrahend._1_,
		TransX - subtrahend.TransX,
		TransY - subtrahend.TransY,
		RotZ - subtrahend.RotZ);

	/// <summary> Adds <paramref name="addend"/> component-wise to this motor. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/projective_geometric_algebra, code/rigid_body_physics]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 2}
	/// </code>
	/// </example>
	public Motor2P Plus(Motor2P addend) => new(
		addend._1_ + _1_,
		addend.TransX + TransX,
		addend.TransY + TransY,
		addend.RotZ + RotZ);

	/// <summary> Returns <paramref name="minuend"/> minus this motor (reversed subtraction). </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/projective_geometric_algebra, code/rigid_body_physics]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 2}
	/// </code>
	/// </example>
	public Motor2P MinusR(Motor2P minuend) => new(
		minuend._1_ + _1_,
		minuend.TransX + TransX,
		minuend.TransY + TransY,
		minuend.RotZ + RotZ);

	/// <inheritdoc cref="XPga2D.Times8P(IReadOnlyList{float},IReadOnlyList{float})"/>
	public Motor2P TimesR(Motor2P factor) => factor.Times(this);

	/// <inheritdoc cref="XPga2D.Dot8P(IReadOnlyList{float},IReadOnlyList{float})"/>
	public Motor2P Dot(Motor2P b) => new(
		b._1_ * _1_ - b.RotZ * RotZ,
		b.TransX * _1_ + b._1_ * TransX,
		b.TransY * _1_ + b._1_ * TransY,
		b.RotZ * _1_ + b._1_ * RotZ);

	/// <inheritdoc cref="XPga2D.Meet8P(IReadOnlyList{float},IReadOnlyList{float})"/>
	public Motor2P Meet(Motor2P b) => new(b._1_ * _1_,
		b.TransX * _1_ + b._1_ * TransX,
		b.TransY * _1_ + b._1_ * TransY,
		b.RotZ * _1_ + b._1_ * RotZ);

	/// <summary> Returns the outer (Meet) product with the operands swapped: <paramref name="that"/> Meet this. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/projective_geometric_algebra, code/rigid_body_physics]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 2}
	/// </code>
	/// </example>
	public Motor2P MeetR(Motor2P that) => that.Meet(this);

	/// <inheritdoc cref="XPga2D.Join8P(IReadOnlyList{float},IReadOnlyList{float})"/>
	public Motor2P Join(Reflector2P b) => new(
		_1_ * b.I,
		TransX * b.I,
		TransY * b.I,
		RotZ * b.I
	);

	/// <summary>Determines whether <paramref name="left"/> equals <paramref name="right"/>.<br/>
	/// Determines whether <paramref name="left"/> does not equal <paramref name="right"/>.</summary>
	public static bool operator ==(Motor2P left, Motor2P right) => left.Equals(right);
	/// <summary>Determines whether <paramref name="left"/> does not equal <paramref name="right"/>.</summary>
	public static bool operator !=(Motor2P left, Motor2P right) => !left.Equals(right);

	/// <summary>Multiplies <paramref name="versor"/> by <paramref name="v"/>.</summary>
	public static Motor2P operator *(Motor2P versor, Motor2P v) => versor.Times(v);
	/// <inheritdoc cref="Sandwich"/>
	public static Motor2P operator <(Motor2P versor, Motor2P v) => versor.Sandwich(v);
	/// <summary>Determines whether <paramref name="versor"/> is less than <paramref name="vectors"/>.</summary>
	public static IEnumerable<Motor2P> operator <(Motor2P versor, IEnumerable<Motor2P> vectors) => vectors.Select(versor.Sandwich);
	/// <summary>Determines whether <paramref name="vector"/> is greater than <paramref name="versors"/>.</summary>
	public static IEnumerable<Motor2P> operator >(Motor2P vector, IEnumerable<Motor2P> versors) => versors.Select(versor => versor.Sandwich(vector));

	/// <inheritdoc cref="Sandwich"/>
	public static Motor2P operator >(Motor2P v, Motor2P versor) => versor.Sandwich(v);
	/// <summary>Determines whether <paramref name="vectors"/> is greater than <paramref name="versor"/>.</summary>
	public static IEnumerable<Motor2P> operator >(IEnumerable<Motor2P> vectors, Motor2P versor) => vectors.Select(versor.Sandwich);
	/// <summary>Determines whether <paramref name="versors"/> is less than <paramref name="vector"/>.</summary>
	public static IEnumerable<Motor2P> operator <(IEnumerable<Motor2P> versors, Motor2P vector) => versors.Select(versor => versor.Sandwich(vector));

	/// <summary> &lt; AKA Map, 'Sandwich' Product: ~this * <paramref name="trafo"/> * this </summary>
	/// <remarks>
	/// Applies this Transformation to <paramref name="trafo"/>. 
	/// When the <see cref="NormSqr"/> is not 1, the Result should subsequently be normed! 
	///
	/// The <see cref="Sandwich"/> Product distributes over the geometric Product <see cref="XMotor2P.Times(Motor2P,Motor2P)"/>.
	/// I.e. Sandwich(a*b) == Sandwich(a)*Sandwich(b).
	/// This is what makes it so useful, because it can be applied to any geometric Object
	/// and it will not change the 'Character' of its Components.
	///
	/// This makes the Sandwich Product Coordinate-free. 
	/// 
	/// 'this' itself is invariant under this Transformation:
	/// ~this*this*this = this * this.NormSqr()
	///
	/// Since ~this*this = this*~this = this.NormSqr()
	/// 
	/// </remarks>
	/// <example>
	/// <code language="yaml">
	/// tags: [code/projective_geometric_algebra, code/rigid_body_physics]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 2}
	/// </code>
	/// </example>
	public Motor2P Sandwich(Motor2P trafo) => this.Conjugate() * trafo * this;

	/// <summary> > AKA Map, 'Sandwich' Product: ~<paramref name="versor"/> * this * <paramref name="versor"/> </summary>
	/// <remarks>
	/// Applies the Transformation defined by <paramref name="versor"/>. 
	/// When the <see cref="NormSqr"/> is not 1, the Result should subsequently be normed.
	/// 
	/// <paramref name="versor"/> itself is invariant under this Transformation! (prove by inserting into Expression)
	/// </remarks>
	/// <example>
	/// <code language="yaml">
	/// tags: [code/projective_geometric_algebra, code/rigid_body_physics]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 2}
	/// </code>
	/// </example>
	public Motor2P SandwichBy(Motor2P versor) => versor.Conjugate() * this * versor;

}
