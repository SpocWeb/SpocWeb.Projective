using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using org.SpocWeb.root.array;
using org.SpocWeb.root.expressions;
using org.SpocWeb.root.extensions.collections;
using org.SpocWeb.root.iMath;
using org.SpocWeb.root.interfaces;
using org.SpocWeb.root.interfaces.maths;
using org.SpocWeb.root.tensors;

namespace org.SpocWeb.root.maths.pga;

/// <summary> Abstract Base Class for Multi-Vector-Spaces </summary>
/// <remarks>
/// By implementing <see cref="IReadOnlyList{Double}"/>,
/// Operators would need to be defined only once.
/// 
/// But to support Lists from the Left and to resolve the resulting Ambiguity
/// you still have to define all 4 Operators for <see cref="IReadOnlyList{T}"/>,
/// <see cref="IList{T}"/>, <see cref="List{T}"/> and Array.
/// </remarks>
/// <inheritdoc cref="IGeoGebra{T}"/>
/// <example>
/// <code language="yaml">
/// pass: 2
/// mtime: 2026-05-24T15:36:24Z
/// digest: bf1c9ff1d35dda84c85322b9e154a083c9dcf67662c575c50562d12cbe64c17d
/// tags: [code/abstract_base, code/geometric_algebra]
/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
/// facets: {layer: domain, status: buggy, complexity: 3}
/// </code>
/// </example>
public abstract class AGeoGebraDbl<T> : IGeoGebra<T,double>, IExpression<T>//, IReadOnlyList<T>
	where T : AGeoGebraDbl<T>
{
	// ReSharper disable once StaticMemberInGenericType
	public static string Infix = ", ";

	/// <summary>Gets the dim.<br/>
	/// Gets the number of elements.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/abstract_base, code/geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: buggy, complexity: 3}
	/// </code>
	/// </example>
	public abstract byte Dim { get; }
	/// <summary>Gets the number of elements.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/abstract_base, code/geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: buggy, complexity: 3}
	/// </code>
	/// </example>
	public int Count => 1 << Dim;
	/// <summary>Gets or sets the element at the specified <paramref name="index"/>.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/abstract_base, code/geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: buggy, complexity: 3}
	/// </code>
	/// </example>
	public abstract double this[int index] { get; }

	/// <inheritdoc />
	[DebuggerStepThrough]
	IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	/// <inheritdoc cref="GetEnumerator()"/>
	public abstract IEnumerator<double> GetEnumerator();

	/// <summary>Gets the basis.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/abstract_base, code/geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: buggy, complexity: 3}
	/// </code>
	/// </example>
	public abstract IReadOnlyList<string> Basis { get; }

	/// <summary> Writes all component coefficients separated by <see cref="Infix"/> to <paramref name="writer"/>. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/abstract_base, code/geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: buggy, complexity: 3}
	/// </code>
	/// </example>
	public virtual long WriteTo(TextWriter writer, long lengthLeft) {
		for (int i = 0; i < Count; i++) {
			writer.Write(this[i]);
			writer.Write(Infix);
		}

		return lengthLeft;
	}

	/// <summary> Returns a hash code based solely on the component values. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/abstract_base, code/geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: buggy, complexity: 3}
	/// </code>
	/// </example>
	public abstract int ValueHash();// => Hash.
	/// <inheritdoc />
	public override int GetHashCode() => ValueHash();

	/// <summary> Returns this instance typed as <typeparamref name="T"/>. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/abstract_base, code/geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: buggy, complexity: 3}
	/// </code>
	/// </example>
	public abstract T Self();
	/// <summary> Evaluates the expression by returning this instance typed as <typeparamref name="T"/>. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/abstract_base, code/geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: buggy, complexity: 3}
	/// </code>
	/// </example>
	public T Evaluate() => Self();

	/// <summary> Returns true when all components of <paramref name="that"/> are approximately equal to this. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/abstract_base, code/geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: buggy, complexity: 3}
	/// </code>
	/// </example>
	public abstract bool Equals(IReadOnlyList<double>? that);
	/// <inheritdoc cref="Equals(IReadOnlyList{double}?)"/>
	public virtual bool Equals(T? that) => ReferenceEquals(this, that) || Equals((IReadOnlyList<double>?) that);
	/// <inheritdoc cref="Equals(IReadOnlyList{double}?)"/>
	public override bool Equals(object? that) {
		if (that is null) return false;
		if (that.GetType() != GetType()) return false;
		return Equals(that as IReadOnlyList<double>);
	}

	/// <summary> Unchecked Creation with Reference (no Copy!) </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/abstract_base, code/geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: buggy, complexity: 3}
	/// </code>
	/// </example>
	protected abstract T Create_(double[] values);

	/// <summary>Determines whether zero.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/abstract_base, code/geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: buggy, complexity: 3}
	/// </code>
	/// </example>
	public bool IsZero() => this.All(c => c.IsSmallerThanAbs(PgaTolerance.Double));

	/// <summary> True when all Components are within <paramref name="absAccuracy"/> of 0. </summary>
	public bool IsZero(double absAccuracy) => this.All(c => Math.Abs(c) <= absAccuracy);

	/// <summary> Euclidean norm. (strictly positive). </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/abstract_base, code/geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: buggy, complexity: 3}
	/// </code>
	/// </example>
	public virtual double Norm() => Math.Sqrt(Math.Abs(NormSqr()));

	/// <summary> Signed Square Norm; this * this.Conjugate()[0] </summary>
	/// <remarks>
	/// !optimize by calculating ONLY the [0]th Component of the geometric Product!
	/// </remarks>
	/// <example>
	/// <code language="yaml">
	/// tags: [code/abstract_base, code/geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: buggy, complexity: 3}
	/// </code>
	/// </example>
	public abstract double NormSqr(); // => Times(Conjugate())[0];

	/// <summary> NormSqr of the PseudoScalar, typically -1 </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/abstract_base, code/geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: buggy, complexity: 3}
	/// </code>
	/// </example>
	public virtual double NormSqrI() => -1;

	/// <summary> Ideal norm. (signed) </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/abstract_base, code/geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: buggy, complexity: 3}
	/// </code>
	/// </example>
	public virtual double NormI() => this[1].IsSmallerThanAbs(PgaTolerance.Double) ? Count > 15 && this[15].IsSmallerThanAbs(PgaTolerance.Double) ? Norm() : this[15] : this[1];

	/// <summary> AKA Sign, Direction; normalized this element; not for ideal (pure) Vectors. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/abstract_base, code/geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: buggy, complexity: 3}
	/// </code>
	/// </example>
	public T Normalized() {
		if (IsZero()) {
			return Self();
		}

		var norm = Math.Abs(NormSqr());
		if (norm.IsOne()) {
			return Self();
		}

		return this / Math.Sqrt(norm);
	}

	/// <inheritdoc />
	public sealed override string ToString() => ToString("");
	/// <inheritdoc cref="ToString()"/>
	public string ToString(string infix, string suffix = " ", bool all = false, string format = "G5") {
		var count = Count;
		var sb = new StringBuilder();
		var e = Basis;
		if (this[0] != 0) {
			sb.Append(this[0]).Append(suffix);
		}
		for (int i = 0; ++i < count;) {
			double value = this[i];
			if (value > Number.ACCURACY) {
				_ = sb.Append('+');
			} else if (value < Number.NEG_ACCURACY) {
				_ = sb.Append('-');
				value = -value;
			} else if (!all) {
				continue;
			}
			sb.Append(suffix);
			if (!value.IsOne()) {
				sb.Append(value.ToString(format));
			}
			if (e[i].Length > 0) {
			    _ = sb.Append(infix).Append(e[i]);
			}
			sb.Append(suffix);
		}
		if (sb.Length <= 0) {
			return "0";
		}

		sb.Length -= suffix.Length;
		return sb.ToString();
	}

	#region unary Functions

	/// <summary> - Negative Multi-Vector </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/abstract_base, code/geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: buggy, complexity: 3}
	/// </code>
	/// </example>
	public T Neg() => Create_(Neg_());

	/// <inheritdoc cref="Neg()"/>
	IReadOnlyList<double> ICanSubtract<IReadOnlyList<double>, T>.Neg() => Neg_();

	/// <summary> Returns a raw coefficient array with every component negated. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/abstract_base, code/geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: buggy, complexity: 3}
	/// </code>
	/// </example>
	protected abstract double[] Neg_();

	/// <summary> \/ Square Root </summary>
	/// <remarks>
	/// Log, Exp and SqRt Implementations can be found
	/// <a href='https://geometricalgebra.org/ga_sandbox/e3ga_util.cpp.html'>3D MultiVectors with up to 8 Coordinates</a>
	/// <a href='https://geometricalgebra.org/ga_sandbox/h3ga_util.cpp.html'>3D MultiVectors with up to Coordinates</a>
	/// <a href='https://geometricalgebra.org/ga_sandbox/c3ga_util.cpp.html'>conformal 3D MultiVectors with up to 32 Coordinates</a>
	/// Exp first scales down by Powers of 2 until 1 > largest Coordinate.
	/// Then it evaluates the Power Series
	/// At last it scales up by squaring the Result.
	///
	/// Log could theoretically do this in Reverse.
	/// </remarks>
	/// <example>
	/// <code language="yaml">
	/// tags: [code/abstract_base, code/geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: buggy, complexity: 3}
	/// </code>
	/// </example>
	public T SqRt() {
		//Works for real and Points, but not for  
		var denom = 2 * (1 + this[0]);
		var factor = 1 / Math.Sqrt(denom);
		if (!this[4].IsSmallerThanAbs(PgaTolerance.Double)) {
			factor *= 1 - this[4] / denom;
		}
		return Create(Succ().Times(factor));
	}

	/// <summary> ++; this + 1 </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/abstract_base, code/geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: buggy, complexity: 3}
	/// </code>
	/// </example>
	public T Succ() => Plus(1);

	/// <summary> --; this - 1 </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/abstract_base, code/geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: buggy, complexity: 3}
	/// </code>
	/// </example>
	public T Pred() => Plus(-1);

	/// <summary> ! Poincare Dual, NOT the Reciprocal! </summary>
	/// <remarks>
	/// Bi-Potent Operator; yields the orthogonal Sub-Space.
	/// Is usually constructed by multiplying with the Pseudo-Scalar, the R^n Unit Volume,
	/// but in PGA e0123 == 0, so we need the Poincar�-Dual.
	/// 
	/// !(A�B) = !A x !B
	/// 
	/// So Dot and Cross Products are Dual Operators
	/// that combined describe invertible Product.
	///
	/// Dua
	/// </remarks>
	/// <example>
	/// <code language="yaml">
	/// tags: [code/abstract_base, code/geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: buggy, complexity: 3}
	/// </code>
	/// </example>
	public abstract T Dual();

	/// <summary> ~ Complex Conjugate. Reverse Transformation. </summary>
	/// <remarks>
	/// � Bi-Potent unary Operator; yields the reciprocal Blade.
	/// A� = A*(-1)^(|A|/2)
	///
	/// Used to form the Norm and to revert Sandwich Transformations.
	/// Complex Numbers and Quaternions Inverses are: 1/x = ~x/|x|�
	///
	/// AKA: Second main involution, principal anti-automorphism
	/// due to: (xy)� = y� x� 
	/// resp.: (xy).Reverted() = y.Reverted()*x.Reverted()
	///
	/// This is formed by reverting the order of all Factor-Dimensions, i.e. e1^e2 => e2^e1
	/// TODO: rename to Cjg <see cref="Conjugate"/>
	/// </remarks>
	/// <example>
	/// <code language="yaml">
	/// tags: [code/abstract_base, code/geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: buggy, complexity: 3}
	/// </code>
	/// </example>
	public abstract T Reverted();

	/// <summary> Clifford Conjugate; x*x.Conjugate() = x.<see cref="NormSqr"/>() </summary>
	/// <remarks>
	/// Product of <see cref="Involute"/> and <see cref="Reverted"/>.
	/// 
	/// Used to define x.<see cref="NormSqr"/> = x*x.Conjugate();
	///
	/// <see cref="Rcp"/>
	/// </remarks>
	/// <example>
	/// <code language="yaml">
	/// tags: [code/abstract_base, code/geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: buggy, complexity: 3}
	/// </code>
	/// </example>
	public abstract T Conjugate();

	/// <summary> Main/Grade involution </summary>
	/// <remarks>
	/// A* := A*(-1)^|A|
	/// 
	/// (xy)* = x* y*
	/// v* = -v
	/// 
	/// Corresponds to Complex and Quaternion Conjugation.
	/// changes sign on all non-scalar (i.e. imaginary) grades.
	///
	/// Involutions for Cl(8):
	/// |Cl0	|Cl1	|Cl2	|Cl3	|Cl4	|Cl5	|Cl6	|Cl7	|
	/// |	+	|	-	|	+	|	-	|	+	|	-	|	+	|	-	|Grade Involution	|
	/// |	+	|	+	|	-	|	-	|	+	|	+	|	-	|	-	|Reversion	|
	/// |	+	|	-	|	-	|	+	|	+	|	-	|	-	|	+	|Clifford Conjugate	|
	///
	/// The different Involutions correspond to each other,
	/// e.g. Reversion and Clifford Conjugate on the even Sub-Algebra yield the same Sign.
	/// 
	/// </remarks>
	/// <example>
	/// <code language="yaml">
	/// tags: [code/abstract_base, code/geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: buggy, complexity: 3}
	/// </code>
	/// </example>
	public abstract T Involute();

	#endregion unary Functions

	#region binary Functions

	/// <summary> Returns the geometric product of this multivector with <paramref name="factor"/>. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/abstract_base, code/geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: buggy, complexity: 3}
	/// </code>
	/// </example>
	public abstract T Times(IReadOnlyList<double> factor);

	/// <summary> Returns the geometric product of <paramref name="factor"/> with this multivector (reversed operand order). </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/abstract_base, code/geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: buggy, complexity: 3}
	/// </code>
	/// </example>
	public abstract T TimesR(IReadOnlyList<double> factor);

	/// <summary> Returns the inner (dot) product of this multivector with <paramref name="that"/>. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/abstract_base, code/geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: buggy, complexity: 3}
	/// </code>
	/// </example>
	public abstract T Dot(IReadOnlyList<double> that);

	/// <summary> Returns the regressive product (meet) of this multivector with <paramref name="that"/>. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/abstract_base, code/geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: buggy, complexity: 3}
	/// </code>
	/// </example>
	public abstract T Meet(IReadOnlyList<double> that);

	/// <summary> Returns the regressive product (meet) of <paramref name="that"/> with this multivector (reversed operand order). </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/abstract_base, code/geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: buggy, complexity: 3}
	/// </code>
	/// </example>
	public abstract T MeetR(IReadOnlyList<double> that);

	/// <summary> Returns the outer product (join) of this multivector with <paramref name="that"/>. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/abstract_base, code/geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: buggy, complexity: 3}
	/// </code>
	/// </example>
	public abstract T Join(IReadOnlyList<double> that);

	//public abstract T Plus(IReadOnlyList<double> versor);

	/// <inheritdoc cref="Plus(double)"/>
	public abstract T Plus<B>(double scalar, B basis) where B : Enum;
	/// <inheritdoc cref="Minus(double)"/>
	public abstract T Minus<B>(double scalar, B basis) where B : Enum;
	/// <inheritdoc cref="MinusR(double)"/>
	public abstract T MinusR<B>(double scalar, B basis) where B : Enum;

	/// <summary> Creates a new instance of <typeparamref name="T"/> from raw component values in <paramref name="list"/>. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/abstract_base, code/geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: buggy, complexity: 3}
	/// </code>
	/// </example>
	public abstract T Create(IList<double> list);

	/// <summary> Adds <paramref name="scalar"/> to the scalar component. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/abstract_base, code/geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: buggy, complexity: 3}
	/// </code>
	/// </example>
	public T Plus(double scalar) => Plus(scalar, (DayOfWeek) 0);
	/// <summary> Subtracts <paramref name="scalar"/> from the scalar component. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/abstract_base, code/geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: buggy, complexity: 3}
	/// </code>
	/// </example>
	public T Minus(double scalar) => Minus(scalar, (DayOfWeek) 0);
	/// <summary> Subtracts the scalar component from <paramref name="scalar"/> (scalar - this[0]). </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/abstract_base, code/geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: buggy, complexity: 3}
	/// </code>
	/// </example>
	public T MinusR(double scalar) => MinusR(scalar, (DayOfWeek) 0);

	/// <inheritdoc cref="Times(IReadOnlyList{double})"/>
	public abstract T Times(double factor);
	/// <summary> Divides all components by <paramref name="factor"/> via multiplication by its reciprocal. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/abstract_base, code/geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: buggy, complexity: 3}
	/// </code>
	/// </example>
	public T Per(double factor) => Times(1/factor);
	/// <inheritdoc cref="Per(double)"/>
	public T Per(T divisor) => Times(divisor.Rcp());

	/// <summary> Computes the reciprocal by LU-decomposing the left-multiplication matrix and back-substituting. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/abstract_base, code/geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: buggy, complexity: 3}
	/// </code>
	/// </example>
	protected T _Rcp() {
		var m = Coefficients();
		var rows = new int[Count]; // ReSharper disable once CoVariantArrayConversion
		var isOdd = m.DECOMPOSE_LU_AT(rows);
		if (isOdd is null) {
			throw new ArgumentOutOfRangeException();
		}

		var rcp = DOUBLES(0);
		m.SOLVE_LU_AT(rows, rcp);
		if (DoCheckInverse) {
			m = Coefficients();
			var x = m.MAP(rcp); //.Times(y);
			x.ShouldBeApprox(DOUBLES(0), 1e-9);
		}
		return Create_(rcp);
	}
	public bool DoCheckInverse = true;

	/// <summary> Returns the left-multiplication matrix whose columns represent the geometric product with each basis blade. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/abstract_base, code/geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: buggy, complexity: 3}
	/// </code>
	/// </example>
	protected abstract double[][] Coefficients();

	/// <summary> Returns a double array of length <see cref="Count"/> with <paramref name="value"/> at <paramref name="pos"/> and zeros elsewhere. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/abstract_base, code/geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: buggy, complexity: 3}
	/// </code>
	/// </example>
	protected double[] DOUBLES(int pos, double value = 1) {
		var ret = new double[Count];
		ret[pos] = value;
		return ret;
	}

	/// <summary> Reciprocal of this geometric Number </summary>
	/// <returns></returns>
	/// <example>
	/// <code language="yaml">
	/// tags: [code/abstract_base, code/geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: buggy, complexity: 3}
	/// </code>
	/// </example>
	public virtual T Rcp() {
		var maxGrade = this.MaxGrade();
		if (maxGrade == 0) {
			var ret = new double[Count];
			ret[0] = 1 / this[0];
			return Create_(ret);
		}
		if (maxGrade == 1) {
			return RcpVector();
		}
		var minGrade = this.MinGrade();
		if (minGrade == Dim) {
			var ret = new double[Count];
			ret[Count-1] = Self().NormSqrI() / this[Count-1];
			return Create_(ret);
		}
		if (minGrade == Dim - 1) {
			return RcpVector();
		}
		// invert the Matrix in O(n�) with n=2^D => O(2^3D)
		return _Rcp();
	}

	/// <summary> Computes the reciprocal of a pure vector or co-vector via conjugation and norm scaling. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/abstract_base, code/geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: buggy, complexity: 3}
	/// </code>
	/// </example>
	protected T RcpVector() {
		var ret = Conjugate();
		var normSqr = NormSqr();
		if (normSqr.IsOne() || normSqr.IsSmallerThanAbs(PgaTolerance.Double)) {
			return ret;
		}

		return ret.Times(1 / normSqr);
	}

	/// <inheritdoc cref="Plus(double)"/>
	public abstract T Plus<V>(V addend) where V : IReadOnlyList<double>;

#pragma warning disable 8633

	/// <inheritdoc cref="Minus(double)"/>
	public abstract IReadOnlyList<double> Minus<P>(P subtrahend) where P : T;

	/// <inheritdoc cref="MinusR(double)"/>
	public IReadOnlyList<double> MinusR<P>(P minuend) where P : T => Minus(minuend);
	/// <inheritdoc cref="Times(IReadOnlyList{double})"/>
	public IReadOnlyList<double> Times<S>(S multiplicand) where S : IIMeasureAble => Times(multiplicand.AsDouble());

	/// <summary>Determines whether equal To.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/abstract_base, code/geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: buggy, complexity: 3}
	/// </code>
	/// </example>
	public bool IsEqualTo<S>(S that) where S : T => this.SequenceEqual(that);

#pragma warning restore 8633

	/// <inheritdoc cref="Plus(double)"/>
	IReadOnlyList<double> ICanMerge<T, IReadOnlyList<double>>.Plus<V>(V addend) => Plus(addend);

	/// <inheritdoc cref="Create(IList{double})"/>
	public abstract T Create(IReadOnlyList<double> versor);
	/// <inheritdoc cref="Plus(double)"/>
	public virtual T Plus(IReadOnlyList<double> b) => Create(b.Plus(this));
	/// <inheritdoc cref="Minus(double)"/>
	public virtual T Minus(IReadOnlyList<double> b) => Create(ArrayDbl.Minus(this, b));
	/// <inheritdoc cref="MinusR(double)"/>
	public virtual T MinusR(IReadOnlyList<double> b) => Create(b.Minus(this));

	#endregion binary Functions

	#region Unary Operators

	/// <inheritdoc cref="Neg"/>
	public static T operator - (AGeoGebraDbl<T> a) => a.Neg();

	/// <inheritdoc cref="Reverted"/>
	public static T operator ~ (AGeoGebraDbl<T> a) => a.Reverted();

	/// <inheritdoc cref="Dual"/>
	public static T operator ! (AGeoGebraDbl<T> a) => a.Dual();

	#endregion Unary Operators

	#region Binary Operators, all associative

	/// <summary>Full geometric product: ^ + *<br/>
	/// Multiplies <paramref name="b"/> by <paramref name="a"/>.</summary>
	public static T operator * (AGeoGebraDbl<T> a, IReadOnlyList<double> b) => a.Times(b);
	/// <summary>Multiplies <paramref name="b"/> by <paramref name="a"/>.</summary>
	public static T operator * (IReadOnlyList<double> b, AGeoGebraDbl<T> a) => a.TimesR(b);
	/// <summary>Multiplies <paramref name="a"/> by <paramref name="b"/>.</summary>
	public static T operator * (AGeoGebraDbl<T> a, AGeoGebraDbl<T> b) => a.Times(b);

	/// <summary>^ outer product. (MEET)</summary>
	public static T operator ^ (AGeoGebraDbl<T> a, IReadOnlyList<double> b) => a.Meet(b);
	/// <summary> ^ outer product. (MEET) </summary>
	public static T operator ^ (IReadOnlyList<double> b, AGeoGebraDbl<T> a) => a.MeetR(b);
	/// <summary> ^ outer product. (MEET) </summary>
	public static T operator ^ (AGeoGebraDbl<T> b, AGeoGebraDbl<T> a) => a.MeetR(b);

	/// <summary>&amp; regressive product. (JOIN); associative</summary>
	public static T operator & (AGeoGebraDbl<T> a, IReadOnlyList<double> b) => a.Join(b);
	/// <summary> &amp; regressive product. (JOIN); associative </summary>
	public static T operator & (IReadOnlyList<double> a, AGeoGebraDbl<T> b) => b.Join(a);
	/// <summary> &amp; regressive product. (JOIN); associative </summary>
	public static T operator & (AGeoGebraDbl<T> a, AGeoGebraDbl<T> b) => b.Join(a);

	/// <summary>| Dot; inner product.</summary>
	public static T operator | (AGeoGebraDbl<T> a, IReadOnlyList<double> b) => a.Dot(b);
	/// <summary> | Dot; inner product. </summary>
	public static T operator | (IReadOnlyList<double> b, AGeoGebraDbl<T> a) => a.Dot(b);
	/// <summary> | Dot; inner product. </summary>
	public static T operator | (AGeoGebraDbl<T> a, AGeoGebraDbl<T> b) => a.Dot(b);

	/// <summary>+ MultiVector addition<br/>
	/// Adds <paramref name="a"/> and <paramref name="b"/>.</summary>
	public static T operator + (AGeoGebraDbl<T> a, AGeoGebraDbl<T> b) => a.Plus(b);
	/// <summary>Adds <paramref name="a"/> and <paramref name="b"/>.</summary>
	public static T operator + (AGeoGebraDbl<T> a, IReadOnlyList<double> b) => a.Plus(b);
	/// <summary>Adds <paramref name="b"/> and <paramref name="a"/>.</summary>
	public static T operator + (IReadOnlyList<double> b, AGeoGebraDbl<T> a) => a.Plus(b);

	/// <summary>MultiVector subtraction<br/>
	/// Subtracts <paramref name="b"/> from <paramref name="a"/>.</summary>
	public static T operator - (AGeoGebraDbl<T> a, AGeoGebraDbl<T> b) => a.Minus(b);
	/// <summary>Subtracts <paramref name="b"/> from <paramref name="a"/>.</summary>
	public static T operator - (AGeoGebraDbl<T> a, IReadOnlyList<double> b) => a.Minus(b);
	/// <summary>Subtracts <paramref name="a"/> from <paramref name="b"/>.</summary>
	public static T operator - (IReadOnlyList<double> b, AGeoGebraDbl<T> a) => a.MinusR(b);

	/// <inheritdoc cref="Sandwich"/>
	public static T operator <(AGeoGebraDbl<T> versor, AGeoGebraDbl<T> v) => versor.Sandwich(v);
	/// <summary>Determines whether <paramref name="versor"/> is less than <paramref name="vectors"/>.</summary>
	public static IEnumerable<T> operator <(AGeoGebraDbl<T> versor, IEnumerable<AGeoGebraDbl<T>> vectors) => vectors.Select(versor.Sandwich);
	/// <summary>Determines whether <paramref name="vector"/> is greater than <paramref name="versors"/>.</summary>
	public static IEnumerable<T> operator >(AGeoGebraDbl<T> vector, IEnumerable<AGeoGebraDbl<T>> versors) => versors.Select(versor => versor.Sandwich(vector));

	/// <inheritdoc cref="Sandwich"/>
	public static T operator >(AGeoGebraDbl<T> v, AGeoGebraDbl<T> versor) => versor.Sandwich(v);
	/// <summary>Determines whether <paramref name="vectors"/> is greater than <paramref name="versor"/>.</summary>
	public static IEnumerable<T> operator >(IEnumerable<AGeoGebraDbl<T>> vectors, AGeoGebraDbl<T> versor) => vectors.Select(versor.Sandwich);
	/// <summary>Determines whether <paramref name="versors"/> is less than <paramref name="vector"/>.</summary>
	public static IEnumerable<T> operator <(IEnumerable<AGeoGebraDbl<T>> versors, AGeoGebraDbl<T> vector) => versors.Select(versor => versor.Sandwich(vector));

	/// <summary> &lt; AKA Map, 'Sandwich' Product: ~this * <paramref name="vector"/> * this </summary>
	/// <remarks>
	/// Applies this Transformation to <paramref name="vector"/>. 
	/// When the <see cref="NormSqr"/> is not 1, the Result should subsequently be normed.
	/// 
	/// 'this' itself is invariant under this Transformation:
	/// ~this*this*this = this * this.NormSqr()
	///
	/// Since ~this*this = this*~this = this.NormSqr()
	/// 
	/// </remarks>
	/// <example>
	/// <code language="yaml">
	/// tags: [code/abstract_base, code/geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: buggy, complexity: 3}
	/// </code>
	/// </example>
	public T Sandwich(AGeoGebraDbl<T> vector) => Conjugate() * vector * this;

	/// <summary><paramref name="self"/> >> <paramref name="that"/> applies <paramref name="that"/> to self</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/abstract_base, code/geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: buggy, complexity: 3}
	/// </code>
	/// </example>
	[SpecialName] public static T op_RightShift(AGeoGebraDbl<T> self, AGeoGebraDbl<T> that) => that.Sandwich(self);
	/// <summary> &lt;&lt; applies this sandwich product to <paramref name="that"/>: ~<paramref name="self"/> * <paramref name="that"/> * <paramref name="self"/> </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/abstract_base, code/geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: buggy, complexity: 3}
	/// </code>
	/// </example>
	[SpecialName] public static T op_LeftShift(AGeoGebraDbl<T> self, AGeoGebraDbl<T> that) => self.Sandwich(that);

	/// <summary> > AKA Map, 'Sandwich' Product: ~<paramref name="versor"/> * this * <paramref name="versor"/> </summary>
	/// <remarks>
	/// Applies the Transformation defined by <paramref name="versor"/>. 
	/// When the <see cref="NormSqr"/> is not 1, the Result should subsequently be normed.
	/// 
	/// <paramref name="versor"/> itself is invariant under this Transformation! (prove by inserting into Expression)
	/// </remarks>
	/// <example>
	/// <code language="yaml">
	/// tags: [code/abstract_base, code/geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: buggy, complexity: 3}
	/// </code>
	/// </example>
	public T SandwichBy(AGeoGebraDbl<T> versor) => versor.Conjugate() * this * versor;

	/// <summary> scalar/multiVector multiplication </summary>
	public static T operator * (double factor, AGeoGebraDbl<T> b) => b.Times(factor);

	/// <summary> multiVector/scalar multiplication </summary>
	public static T operator * (AGeoGebraDbl<T> a, double factor) => a.Times(factor);

	/// <summary> multiVector/scalar division </summary>
	public static T operator / (AGeoGebraDbl<T> a, double divisor) => a.Per(divisor);

	/// <summary> +; Plus, Add; multiVector/scalar addition </summary>
	public static T operator + (double a, AGeoGebraDbl<T> b) => b.Plus(a, (DayOfWeek)0);

	/// <summary> +; Plus, Add; multiVector/scalar addition </summary>
	public static T operator + (AGeoGebraDbl<T> a, double b) => a.Plus(b, (DayOfWeek)0);

	/// <summary> -; Minus, Sub; scalar/multiVector subtraction </summary>
	public static T operator - (double a, AGeoGebraDbl<T> b) => b.MinusR(a, (DayOfWeek)0);

	/// <summary> - multiVector -scalar subtraction </summary>
	public static T operator - (AGeoGebraDbl<T> a, double b) => a.Minus(b, (DayOfWeek)0);

	#endregion Binary Operators

}
