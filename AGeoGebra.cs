using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using NUnit.Framework;
using org.SpocWeb.root.array;
using org.SpocWeb.root.expressions;
using org.SpocWeb.root.extensions.collections;
using org.SpocWeb.root.extensions.maths;
using org.SpocWeb.root.iMath;
using org.SpocWeb.root.interfaces;
using org.SpocWeb.root.interfaces.maths;
using org.SpocWeb.root.tensors;
using org.SpocWeb.root.Attributes;

namespace org.SpocWeb.root.maths.pga;

/// <summary> Extension Methods and Tests for <see cref="IGeoGebra{T,F}"/> and PGA Classes </summary>
/// <remarks>
/// ## Public Methods
///
/// | Line | Method | Description |
/// |--:|---|---|
/// | 58 | <see cref="NormAbs"/> | Sum of absolute values of all components (L1 norm) of a float multi-vector. |
/// | 88 | <see cref="Grade2DTests"/> | Test cases for 2D grade computation covering key basis blades. |
/// | 104 | <see cref="Grade3DTests"/> | Test cases for 3D grade computation covering key basis blades. |
/// | 122 | <see cref="MinGrade"/> | Minimum Grade; -1 for Zero |
/// | 133 | <see cref="MaxGrade"/> | Maximum Grade; -1 for Zero |
/// | 180 | <see cref="MaxNonZero"/> | Maximum Grade; -1 for Zero |
/// | 203 | <see cref="MaxNonZeroTests"/> | Maximum Grade; -1 for Zero  Maximum non-zero component index; -1 for Zero |
/// | 231 | <see cref="Pga3DTests"/> | Test cases enumerating all 3D basis blades with their expected component indices. |
/// | 240 | <see cref="Pga2DTests"/> | Test cases enumerating all 2D basis blades with their expected component indices. |
/// | 250 | <see cref="MinNonZeroTests"/> | Minimum Grade; -1 for Zero  Minimum non-zero component index; -1 for Zero |
/// | 260 | <see cref="MinNonZero"/> |  |
/// | 300 | <see cref="GetNonZeroBits"/> | Bits set for every Non-Zero Component |
///
/// ## Collaborators
///
/// | Type | Role |
/// |---|---|
/// | <see cref="IGeoGebra"/> | Passed as a parameter. |
/// | <see cref="Pga2D"/> | Passed as a parameter. |
/// | <see cref="Pga3D"/> | Passed as a parameter. |
/// </remarks>
///
[DocState(Pass = 2, MTime = "2026-05-24T16:42:09Z", Digest = "f156f02232b25b54fe9bafeb7b1ae7db681ff0ce7d94436796a6b8e421f0c728", Stale = false, Path = "AGeoGebra.cs", Since = "2026-10-06")]
[Facets(Layer = "domain", Status = "stable", Complexity = 3)]
[Tags("code/extension_method", "code/unit_test", "code/geometric_algebra")]
[System.ComponentModel.Description("Extension Methods and Tests for IGeoGebra and PGA Classes")]
[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
public static partial class XGeoGebra
{
	/// <summary> Sum of absolute values of all components (L1 norm) of a float multi-vector. </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/extension_method", "code/norm_computation")]
	[System.ComponentModel.Description("Sum of absolute values of all components (L1 norm) of a float multi-vector.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public static double NormAbs<T>(this IGeoGebra<T, float> mv) where T : IGeoGebra<T, float> {
		var i = mv.Count;
		var ret = Math.Abs(mv[--i]);
		for (; --i >= 0; ) {
			ret += Math.Abs(mv[i]);
		}
		return ret;
	}

	/// <summary> Sum of absolute values of all components (L1 norm) of a double multi-vector. </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/extension_method", "code/norm_computation")]
	[System.ComponentModel.Description("Sum of absolute values of all components (L1 norm) of a double multi-vector.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public static double NormAbs<T>(this IGeoGebra<T, double> mv) where T : IGeoGebra<T, double> {
		var i = mv.Count;
		var ret = Math.Abs(mv[--i]);
		for (; --i >= 0; ) {
			ret += Math.Abs(mv[i]);
		}
		return ret;
	}

	/// <summary> Test cases for 2D grade computation covering key basis blades. </summary>
	///
	[Facets(Layer = "generator", Status = "stable", Complexity = 2)]
	[Tags("code/test_data_generation")]
	[System.ComponentModel.Description("Test cases for 2D grade computation covering key basis blades.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public static IEnumerable<TestCaseData> Grade2DTests() {
		yield return new TestCaseData(Pga2D.E12) {ExpectedResult = 2};
		yield return new TestCaseData(Pga2D.E1) {ExpectedResult = 1};
		yield return new TestCaseData(Pga2D.E012) {ExpectedResult = 3};
		yield return new TestCaseData(Pga2D.E0) {ExpectedResult = 1};
		yield return new TestCaseData(Pga2D._1_) {ExpectedResult = 0};
		//yield return new TestCaseData(new Pga2D(0, Pga2D.Base._1_)) {ExpectedResult = -1};
		//yield return new TestCaseData(Pga2D.Blades) {ExpectedResult = 0};
	}

	/// <summary> Test cases for 3D grade computation covering key basis blades. </summary>
	///
	[Facets(Layer = "generator", Status = "stable", Complexity = 2)]
	[Tags("code/test_data_generation")]
	[System.ComponentModel.Description("Test cases for 3D grade computation covering key basis blades.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public static IEnumerable<TestCaseData> Grade3DTests() {
		yield return new TestCaseData(Pga3D.E12) {ExpectedResult = 2};
		yield return new TestCaseData(Pga3D.E1) {ExpectedResult = 1};
		yield return new TestCaseData(Pga3D.E123) {ExpectedResult = 3};
		yield return new TestCaseData(Pga3D.E0123) {ExpectedResult = 4};
		yield return new TestCaseData(Pga3D._1_) {ExpectedResult = 0};
		//yield return new TestCaseData(new Pga3D(0, Pga3D.Base._1_)) {ExpectedResult = -1};
		
		//yield return new TestCaseData(Pga3D.E0123 + Pga3D._1_) {ExpectedResult = 4};
		//yield return new TestCaseData(Pga3D.E123 + Pga3D._1_) {ExpectedResult = 3};
	}

	/// <summary> Minimum Grade; -1 for Zero </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 1)]
	[Tags("code/extension_method", "code/grade_computation")]
	[System.ComponentModel.Description("Minimum Grade; -1 for Zero")]
	[TestCaseSource(nameof(Grade2DTests))]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public static sbyte MinGrade(this Pga2D mv) => MinGrade(mv.MinNonZero(), mv.Dim);
	/// <inheritdoc cref="MinGrade(Pga2D)"/>
	[TestCaseSource(nameof(Grade3DTests))]
	public static sbyte MinGrade(this Pga3D mv) => MinGrade(mv.MinNonZero(), mv.Dim);
	/// <summary> Maximum Grade; -1 for Zero </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/extension_method", "code/grade_computation")]
	[System.ComponentModel.Description("Maximum Grade; -1 for Zero")]
	[TestCaseSource(nameof(Grade2DTests))]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public static sbyte MaxGrade(this Pga2D mv) => (sbyte) (mv.Dim - MinGrade(mv.Count - mv.MaxNonZero() - 1, mv.Dim));
	/// <inheritdoc cref="MaxGrade(Pga2D)"/>
	[TestCaseSource(nameof(Grade3DTests))]
	public static sbyte MaxGrade(this Pga3D mv) => (sbyte) (mv.Dim - MinGrade(mv.Count - mv.MaxNonZero() - 1, mv.Dim));
	/// <inheritdoc cref="MinGrade(Pga2D)"/>
	public static sbyte MinGrade<T>(this IGeoGebra<T, double> mv) where T : IGeoGebra<T, double> => MinGrade(mv.MinNonZero(), mv.Dim);
	/// <summary> Maximum Grade; -1 for Zero </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/extension_method", "code/grade_computation")]
	[System.ComponentModel.Description("Maximum Grade; -1 for Zero")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public static sbyte MaxGrade<T>(this IGeoGebra<T, double> mv) where T : IGeoGebra<T, double> 
		=> (sbyte) (mv.Dim - MinGrade(mv.Count - mv.MaxNonZero() - 1, mv.Dim));
	/// <inheritdoc cref="MinGrade(Pga2D)"/>
	public static sbyte MinGrade<T>(this IGeoGebra<T, float> mv) where T : IGeoGebra<T, float>
		=> MinGrade(mv.MinNonZero(), mv.Dim);
	/// <summary> Maximum Grade; -1 for Zero </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/extension_method", "code/grade_computation")]
	[System.ComponentModel.Description("Maximum Grade; -1 for Zero")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public static sbyte MaxGrade<T>(this IGeoGebra<T, float> mv) where T : IGeoGebra<T, float> 
		=> (sbyte) (mv.Dim - MinGrade(mv.Count - mv.MaxNonZero() - 1, mv.Dim));

	/// <inheritdoc cref="MinGrade(Pga2D)"/>
	static sbyte MinGrade(long min, byte dim) {
		sbyte grade = -1; //mv.Count;
		foreach (var numCombos in dim.Combinations()) {
			if (min < 0) {
				return grade;
			}
			min -= numCombos;
			++grade;
		}

		return grade;
	}

	/// <summary> Maximum Grade; -1 for Zero </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 3)]
	[Tags("code/extension_method", "code/tolerance_checking")]
	[System.ComponentModel.Description("Maximum Grade; -1 for Zero")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public static sbyte MaxNonZero<T>(this IGeoGebra<T, double> mv) where T : IGeoGebra<T, double> {
		var acc = mv.NormAbs();
		if (acc < Number.ACCURACY) {
			return -1;
		}
		acc = acc.MulAccuracy();
		var accNeg = -acc;
		for (var i = mv.Count; --i >= 0; ) {
			if (mv[i] >= acc ||
			    mv[i] <= accNeg) {
				return (sbyte)i;
			}
		}
		return -1;
	}

	/// <summary>Maximum Grade; -1 for Zero<br/>
	/// Maximum non-zero component index; -1 for Zero</summary>
	///
	[Facets(Layer = "test", Status = "stable", Complexity = 1)]
	[Tags("code/extension_method", "code/unit_test")]
	[System.ComponentModel.Description("Maximum Grade; -1 for Zero Maximum non-zero component index; -1 for Zero")]
	[TestCaseSource(nameof(Pga3DTests))]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public static sbyte MaxNonZeroTests(this Pga3D mv) => MaxNonZero(mv);
	/// <inheritdoc cref="MaxNonZeroTests(Pga3D)"/>
	[TestCaseSource(nameof(Pga2DTests))]
	public static sbyte MaxNonZeroTests(this Pga2D mv) => MaxNonZero(mv);
	/// <inheritdoc cref="MaxNonZero{T}(IGeoGebra{T,double})"/>
	public static sbyte MaxNonZero<T>(this IGeoGebra<T, float> mv) where T : IGeoGebra<T, float> {
		var acc = mv.NormAbs();
		if (acc < Number.ACCURACY) {
			return -1;
		}
		acc = acc.MulAccuracy();
		var accNeg = -acc;
		for (var i = mv.Count; --i >= 0; ) {
			if (mv[i] >= acc ||
			    mv[i] <= accNeg) {
				return (sbyte)i;
			}
		}
		return -1;
	}

	/// <summary> Test cases enumerating all 3D basis blades with their expected component indices. </summary>
	///
	[Facets(Layer = "generator", Status = "stable", Complexity = 1)]
	[Tags("code/test_data_generation", "code/test_case_data_source")]
	[System.ComponentModel.Description("Test cases enumerating all 3D basis blades with their expected component indices.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public static IEnumerable<TestCaseData> Pga3DTests => Pga3D.Blades.Select((b,i)
		=> new TestCaseData(b){ExpectedResult = i});

	/// <summary> Test cases enumerating all 2D basis blades with their expected component indices. </summary>
	///
	[Facets(Layer = "generator", Status = "stable", Complexity = 1)]
	[Tags("code/test_data_generation", "code/test_case_data_source")]
	[System.ComponentModel.Description("Test cases enumerating all 2D basis blades with their expected component indices.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public static IEnumerable<TestCaseData> Pga2DTests => Pga2D.Blades.Select((b,i)
		=> new TestCaseData(b){ExpectedResult = i});

	/// <summary>Minimum Grade; -1 for Zero<br/>
	/// Minimum non-zero component index; -1 for Zero</summary>
	///
	[Facets(Layer = "test", Status = "stable", Complexity = 1)]
	[Tags("code/extension_method", "code/unit_test")]
	[System.ComponentModel.Description("Minimum Grade; -1 for Zero Minimum non-zero component index; -1 for Zero")]
	[TestCaseSource(nameof(Pga3DTests))]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public static sbyte MinNonZeroTests(this Pga3D mv) => MinNonZero(mv);
	/// <inheritdoc cref="MinNonZeroTests(Pga3D)"/>
	[TestCaseSource(nameof(Pga2DTests))]
	public static sbyte MinNonZeroTests(this Pga2D mv) => MinNonZero(mv);
	/// <inheritdoc cref="MinNonZero{T}(IGeoGebra{T,double})"/>
	public static sbyte MinNonZero<T>(this IGeoGebra<T, float> mv) where T : IGeoGebra<T, float> {
		var acc = mv.NormAbs();
		if (acc < Number.ACCURACY) {
			return -1;
		}
		acc = acc.MulAccuracy();
		var accNeg = -acc;
		for (int i = -1; ++i < mv.Count; ) {
			if (mv[i] >= acc ||
			    mv[i] <= accNeg) {
				return (sbyte)i;
			}
		}
		return -1;
	}

	/// <summary> Minimum Grade; -1 for Zero </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 3)]
	[Tags("code/extension_method", "code/tolerance_checking")]
	[System.ComponentModel.Description("Minimum Grade; -1 for Zero")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public static sbyte MinNonZero<T>(this IGeoGebra<T, double> mv) where T : IGeoGebra<T, double> {
		var acc = mv.NormAbs();
		if (acc < Number.ACCURACY) {
			return -1;
		}
		acc = acc.MulAccuracy();
		var accNeg = -acc;
		for (int i = 0; i < mv.Count; ++i) {
			if (mv[i] >= acc ||
			    mv[i] <= accNeg) {
				return (sbyte)i;
			}
		}
		return -1;
	}

	/// <summary> Bits set for every Non-Zero Component </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 3)]
	[Tags("code/extension_method", "code/bitmask_position_scan", "code/tolerance_checking")]
	[System.ComponentModel.Description("Bits set for every Non-Zero Component")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public static long GetNonZeroBits<T>(this IGeoGebra<T, double> mv) where T : IGeoGebra<T, double> {
		var acc = mv.NormAbs();
		if (acc < Number.ACCURACY) {
			return 0;
		}
		acc = acc.MulAccuracy();
		long mask = 1, result = 0;
		var accNeg = -acc;
		for (int i = 0; i < mv.Count; i++, mask <<= 1) {
			if (mv[i] >= acc ||
			    mv[i] <= accNeg) {
				result |= mask;
			}
		}

		return result;
	}

}

/// <summary> Abstract Base Class for Multi-Vector-Spaces </summary>
///
/// <remarks>
/// By implementing <see cref="IReadOnlyList{Single}"/>, Operators would need to be defined only once.
/// But to support Lists from the Left and to resolve the resulting Ambiguity you still have to define all 3 Operators.
/// </remarks>
/// <inheritdoc cref="IGeoGebra{T,Single}"/>
[DocState(Pass = 2, MTime = "2026-05-24T16:42:09Z", Digest = "4f1293b6c1fcea76f512f6dad7376753c312e8df770f0136059b759b258a85cb", Stale = false, Path = "AGeoGebra.cs", Since = "2026-10-06")]
[Facets(Layer = "domain", Status = "stable", Complexity = 4)]
[Tags("code/abstract_base", "code/geometric_algebra")]
[System.ComponentModel.Description("Abstract Base Class for Multi-Vector-Spaces")]
[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
public abstract class AGeoGebra<T> : IGeoGebra<T,float>, IExpression<T>, IReadOnlyList<float>
	where T : AGeoGebra<T>
{
	// ReSharper disable once StaticMemberInGenericType
	/// <summary> Separator string inserted between components in string output. </summary>
	public static string Infix = ", ";

	/// <summary>Number of basis dimensions (e.g. 4 for 3D PGA).<br/>
	/// Total number of multi-vector components (2^<see cref="Dim"/>).</summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 4)]
	[Tags("code/abstract_base", "code/geometric_algebra")]
	[System.ComponentModel.Description("Number of basis dimensions (e.g. 4 for 3D PGA). Total number of multi-vector components (2^Dim).")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public abstract byte Dim { get; }
	/// <summary>Gets the number of elements.</summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 4)]
	[Tags("code/abstract_base", "code/geometric_algebra")]
	[System.ComponentModel.Description("Gets the number of elements.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public int Count => 1 << Dim;
	/// <summary> Returns the <paramref name="index"/>-th component coefficient. </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 4)]
	[Tags("code/abstract_base", "code/geometric_algebra")]
	[System.ComponentModel.Description("Returns the index-th component coefficient.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public abstract float this[int index] { get; }

	/// <inheritdoc />
	[DebuggerStepThrough]
	IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	/// <summary> Returns an enumerator over all component coefficients. </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 4)]
	[Tags("code/abstract_base", "code/geometric_algebra")]
	[System.ComponentModel.Description("Returns an enumerator over all component coefficients.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public abstract IEnumerator<float> GetEnumerator();

	/// <summary> Names of the basis blades in component-index order. </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 4)]
	[Tags("code/abstract_base", "code/geometric_algebra")]
	[System.ComponentModel.Description("Names of the basis blades in component-index order.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public abstract IReadOnlyList<string> Basis { get; }

	/// <summary> Writes all component coefficients separated by <see cref="Infix"/> to <paramref name="writer"/>. </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 4)]
	[Tags("code/abstract_base", "code/geometric_algebra")]
	[System.ComponentModel.Description("Writes all component coefficients separated by Infix to writer.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public virtual long WriteTo(TextWriter writer, long lengthLeft) {
		for (int i = 0; i < Count; i++) {
			writer.Write(this[i]);
			writer.Write(Infix);
		}
		return lengthLeft;
	}

	/// <summary> Returns a hash code based solely on the component values. </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 4)]
	[Tags("code/abstract_base", "code/geometric_algebra")]
	[System.ComponentModel.Description("Returns a hash code based solely on the component values.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public abstract int ValueHash();// => Hash.
	/// <inheritdoc cref="ValueHash"/>
	public override int GetHashCode() => ValueHash();

	/// <summary>Returns this instance typed as <typeparamref name="T"/>.<br/>
	/// Evaluates the expression by returning <see cref="Self"/>.</summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 4)]
	[Tags("code/abstract_base", "code/geometric_algebra")]
	[System.ComponentModel.Description("Returns this instance typed as. Evaluates the expression by returning Self.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public abstract T Self();
	/// <summary> Evaluates the expression by returning this instance typed as <typeparamref name="T"/>. </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 4)]
	[Tags("code/abstract_base", "code/geometric_algebra")]
	[System.ComponentModel.Description("Evaluates the expression by returning this instance typed as.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public T Evaluate() => Self();

	/// <summary> Returns true when all components of <paramref name="that"/> are approximately equal to this. </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 4)]
	[Tags("code/abstract_base", "code/geometric_algebra")]
	[System.ComponentModel.Description("Returns true when all components of that are approximately equal to this.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public abstract bool Equals(IReadOnlyList<float>? that);
	/// <inheritdoc cref="Equals(IReadOnlyList{float})"/>
	public virtual bool Equals(T? that) => ReferenceEquals(this, that) || Equals((IReadOnlyList<float>?) that);
	/// <inheritdoc cref="Equals(IReadOnlyList{float})"/>
	public override bool Equals(object? that) {
		if (that is null) return false;
		if (that.GetType() != GetType()) return false;
		return Equals(that as IReadOnlyList<float>);
	}

	/// <summary> Unchecked Creation with Reference (no Copy!) </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 4)]
	[Tags("code/abstract_base", "code/geometric_algebra")]
	[System.ComponentModel.Description("Unchecked Creation with Reference (no Copy!)")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	protected abstract T Create_(float[] values);

	/// <summary> Returns true when all components are zero (within numerical accuracy). </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 4)]
	[Tags("code/abstract_base", "code/geometric_algebra")]
	[System.ComponentModel.Description("Returns true when all components are zero (within numerical accuracy).")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public bool IsZero() => this.All(c => c.IsSmallerThanAbs(PgaTolerance.Float));

	/// <summary> True when all Components are within <paramref name="absAccuracy"/> of 0. </summary>
	[Facets(Layer = "domain", Status = "stable", Complexity = 4)]
	[Tags("code/abstract_base", "code/geometric_algebra")]
	[System.ComponentModel.Description("True when all Components are within absAccuracy of 0.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public bool IsZero(double absAccuracy) => this.All(c => Math.Abs(c) <= absAccuracy);

	/// <summary> Euclidean norm. (strictly positive). </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 4)]
	[Tags("code/abstract_base", "code/geometric_algebra")]
	[System.ComponentModel.Description("Euclidean norm. (strictly positive).")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public virtual double Norm() => Math.Sqrt(Math.Abs(NormSqr()));

	/// <summary> Signed Square Norm; this * this.Conjugate()[0] </summary>
	/// <remarks>
	/// !optimize by calculating ONLY the [0]th Component of the geometric Product!
	/// </remarks>
	[Facets(Layer = "domain", Status = "stable", Complexity = 4)]
	[Tags("code/abstract_base", "code/geometric_algebra")]
	[System.ComponentModel.Description("Signed Square Norm; this * this.Conjugate()[0]")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public abstract double NormSqr(); // => Times(Conjugate())[0];

	/// <summary> NormSqr of the PseudoScalar, typically -1 </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 4)]
	[Tags("code/abstract_base", "code/geometric_algebra")]
	[System.ComponentModel.Description("NormSqr of the PseudoScalar, typically -1")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public virtual double NormSqrI() => -1;

	/// <summary> Ideal norm. (signed) </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 4)]
	[Tags("code/abstract_base", "code/geometric_algebra")]
	[System.ComponentModel.Description("Ideal norm. (signed)")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public virtual double NormI() => this[1].IsSmallerThanAbs(PgaTolerance.Float) ? Count > 15 && this[15].IsSmallerThanAbs(PgaTolerance.Float) ? Norm() : this[15] : this[1];

	/// <summary> AKA Sign, Direction; normalized this element; not for ideal (pure) Vectors. </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 4)]
	[Tags("code/abstract_base", "code/geometric_algebra")]
	[System.ComponentModel.Description("AKA Sign, Direction; normalized this element; not for ideal (pure) Vectors.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
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

	/// <inheritdoc cref="ToString()"/>
	public sealed override string ToString() => ToString("");
	/// <inheritdoc cref="ToString()"/>
	public string ToString(string infix, string suffix = " ", bool all = false, string format = "G5") {
		var count = Count;
		var sb = new StringBuilder();
		var e = Basis;
		if (this[0] != 0) {
			sb.Append(this[0].ToString(format)).Append(suffix);
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
	[Facets(Layer = "domain", Status = "stable", Complexity = 4)]
	[Tags("code/abstract_base", "code/geometric_algebra")]
	[System.ComponentModel.Description("- Negative Multi-Vector")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public T Neg() => Create_(Neg_());

	/// <inheritdoc cref="Neg()"/>
	IReadOnlyList<float> ICanSubtract<IReadOnlyList<float>, T>.Neg() => Neg_();

	/// <summary> Returns a raw coefficient array with every component negated. </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 4)]
	[Tags("code/abstract_base", "code/geometric_algebra")]
	[System.ComponentModel.Description("Returns a raw coefficient array with every component negated.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	protected abstract float[] Neg_();

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
	[Facets(Layer = "domain", Status = "stable", Complexity = 4)]
	[Tags("code/abstract_base", "code/geometric_algebra")]
	[System.ComponentModel.Description("\\/ Square Root")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public T SqRt() {
		//Works for real and Points, but not for  
		var denom = 2 * (1 + this[0]);
		var factor = 1 / (float) Math.Sqrt(denom);
		if (!this[4].IsSmallerThanAbs(PgaTolerance.Float)) {
			factor *= 1 - this[4] / denom;
		}
		return Create_(Succ().Times(factor));
	}

	/// <summary> ++; this + 1 </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 4)]
	[Tags("code/abstract_base", "code/geometric_algebra")]
	[System.ComponentModel.Description("++; this + 1")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public T Succ() => Plus(1);

	/// <summary> --; this - 1 </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 4)]
	[Tags("code/abstract_base", "code/geometric_algebra")]
	[System.ComponentModel.Description("--; this - 1")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
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
	[Facets(Layer = "domain", Status = "stable", Complexity = 4)]
	[Tags("code/abstract_base", "code/geometric_algebra")]
	[System.ComponentModel.Description("! Poincare Dual, NOT the Reciprocal!")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
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
	[Facets(Layer = "domain", Status = "stable", Complexity = 4)]
	[Tags("code/abstract_base", "code/geometric_algebra")]
	[System.ComponentModel.Description("~ Complex Conjugate. Reverse Transformation.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public abstract T Reverted();

	/// <summary> Clifford Conjugate; x*x.Conjugate() = x.<see cref="NormSqr"/>() </summary>
	/// <remarks>
	/// Product of <see cref="Involute"/> and <see cref="Reverted"/>.
	/// 
	/// Used to define x.<see cref="NormSqr"/> = x*x.Conjugate();
	///
	/// <see cref="Rcp"/>
	/// </remarks>
	[Facets(Layer = "domain", Status = "stable", Complexity = 4)]
	[Tags("code/abstract_base", "code/geometric_algebra")]
	[System.ComponentModel.Description("Clifford Conjugate; x*x.Conjugate() = x.NormSqr()")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
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
	[Facets(Layer = "domain", Status = "stable", Complexity = 4)]
	[Tags("code/abstract_base", "code/geometric_algebra")]
	[System.ComponentModel.Description("Main/Grade involution")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public abstract T Involute();

	#endregion unary Functions

	#region binary Functions

	/// <summary> Geometric product of this multivector with <paramref name="factor"/> (this * factor). </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 4)]
	[Tags("code/abstract_base", "code/geometric_algebra")]
	[System.ComponentModel.Description("Geometric product of this multivector with factor (this * factor).")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public abstract T Times(IReadOnlyList<float> factor);

	/// <summary> Geometric product of <paramref name="factor"/> with this multivector (factor * this). </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 4)]
	[Tags("code/abstract_base", "code/geometric_algebra")]
	[System.ComponentModel.Description("Geometric product of factor with this multivector (factor * this).")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public abstract T TimesR(IReadOnlyList<float> factor);

	/// <summary>Scales all components by <paramref name="factor"/>, returning a raw coefficient array.<br/>
	/// Divides all components by <paramref name="factor"/>, returning a raw coefficient array.</summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 4)]
	[Tags("code/abstract_base", "code/geometric_algebra")]
	[System.ComponentModel.Description("Scales all components by factor, returning a raw coefficient array. Divides all components by factor, returning a raw coefficient array.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public abstract float[] Times(float factor);
	/// <summary> Divides all components by <paramref name="factor"/>, returning a raw coefficient array. </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 4)]
	[Tags("code/abstract_base", "code/geometric_algebra")]
	[System.ComponentModel.Description("Divides all components by factor, returning a raw coefficient array.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public abstract float[] Per(float factor);

	/// <summary> Inner (dot) product of this multivector with <paramref name="that"/>. </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 4)]
	[Tags("code/abstract_base", "code/geometric_algebra")]
	[System.ComponentModel.Description("Inner (dot) product of this multivector with that.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public abstract T Dot(IReadOnlyList<float> that);

	/// <summary> Outer (wedge / meet) product of this multivector with <paramref name="that"/>. </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 4)]
	[Tags("code/abstract_base", "code/geometric_algebra")]
	[System.ComponentModel.Description("Outer (wedge / meet) product of this multivector with that.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public abstract T Meet(IReadOnlyList<float> that);

	/// <summary> Outer (wedge / meet) product of <paramref name="that"/> with this multivector. </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 4)]
	[Tags("code/abstract_base", "code/geometric_algebra")]
	[System.ComponentModel.Description("Outer (wedge / meet) product of that with this multivector.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public abstract T MeetR(IReadOnlyList<float> that);

	/// <summary> Regressive (join / vee) product of this multivector with <paramref name="that"/>. </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 4)]
	[Tags("code/abstract_base", "code/geometric_algebra")]
	[System.ComponentModel.Description("Regressive (join / vee) product of this multivector with that.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public abstract T Join(IReadOnlyList<float> that);

	//public abstract T Plus(IReadOnlyList<float> versor);

	/// <summary>Adds <paramref name="scalar"/> to the component indicated by <paramref name="basis"/>.<br/>
	/// Subtracts <paramref name="scalar"/> from the component indicated by <paramref name="basis"/>.</summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 4)]
	[Tags("code/abstract_base", "code/geometric_algebra")]
	[System.ComponentModel.Description("Adds scalar to the component indicated by basis. Subtracts scalar from the component indicated by basis.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public abstract T Plus<B>(double scalar, B basis) where B : Enum;
	/// <inheritdoc cref="Minus(double)"/>
	public abstract T Minus<B>(double scalar, B basis) where B : Enum;
	/// <summary> Subtracts this from <paramref name="scalar"/> at the component indicated by <paramref name="basis"/> (scalar - this). </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 4)]
	[Tags("code/abstract_base", "code/geometric_algebra")]
	[System.ComponentModel.Description("Subtracts this from scalar at the component indicated by basis (scalar - this).")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public abstract T MinusR<B>(double scalar, B basis) where B : Enum;

	/// <summary> Creates a new multivector from <paramref name="list"/>, copying its values. </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 4)]
	[Tags("code/abstract_base", "code/geometric_algebra")]
	[System.ComponentModel.Description("Creates a new multivector from list, copying its values.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public abstract T Create(IList<float> list);

	/// <summary>Adds <paramref name="scalar"/> to the scalar component.<br/>
	/// Subtracts <paramref name="scalar"/> from the scalar component.</summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 4)]
	[Tags("code/abstract_base", "code/geometric_algebra")]
	[System.ComponentModel.Description("Adds scalar to the scalar component. Subtracts scalar from the scalar component.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public T Plus(double scalar) => Plus(scalar, (DayOfWeek) 0);
	/// <summary> Subtracts <paramref name="scalar"/> from the scalar component. </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 4)]
	[Tags("code/abstract_base", "code/geometric_algebra")]
	[System.ComponentModel.Description("Subtracts scalar from the scalar component.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public T Minus(double scalar) => Minus(scalar, (DayOfWeek) 0);
	/// <summary> Subtracts the scalar component from <paramref name="scalar"/> (scalar - this[0]). </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 4)]
	[Tags("code/abstract_base", "code/geometric_algebra")]
	[System.ComponentModel.Description("Subtracts the scalar component from scalar (scalar - this[0]).")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public T MinusR(double scalar) => MinusR(scalar, (DayOfWeek) 0);

	/// <summary>Scales all components by the scalar <paramref name="factor"/>.<br/>
	/// Divides all components by the scalar <paramref name="factor"/>.</summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 4)]
	[Tags("code/abstract_base", "code/geometric_algebra")]
	[System.ComponentModel.Description("Scales all components by the scalar factor. Divides all components by the scalar factor.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public T Times(double factor) => Create_(Times((float) factor));
	/// <inheritdoc cref="Per(float)"/>
	public T Per(double factor) => Create_(Per((float) factor));
	/// <summary> Divides this multivector by <paramref name="divisor"/> via the geometric product with its reciprocal. </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 4)]
	[Tags("code/abstract_base", "code/geometric_algebra")]
	[System.ComponentModel.Description("Divides this multivector by divisor via the geometric product with its reciprocal.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public T Per(T divisor) => Times(divisor.Rcp());

	/// <summary> Computes the reciprocal by LU-decomposing the left-multiplication matrix and back-substituting. </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 4)]
	[Tags("code/abstract_base", "code/geometric_algebra")]
	[System.ComponentModel.Description("Computes the reciprocal by LU-decomposing the left-multiplication matrix and back-substituting.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	protected T _Rcp() {
		var m = Coefficients();
		var rows = new int[Count]; // ReSharper disable once CoVariantArrayConversion
		var isOdd = m.DECOMPOSE_LU_AT(rows);
		if (isOdd is null) {
			throw new ArgumentOutOfRangeException(@"Matrix is singular and cannot be inverted: " + this);
		}

		var rcp = DOUBLES(0);
		m.SOLVE_LU_AT(rows, rcp);
		if (DoCheckInverse) {
			m = Coefficients();
			var x = m.MAP(rcp); //.Times(y);
			x.ShouldBeApprox(DOUBLES(0), 2e-8);
		}
		return Create_(rcp.AsSingle());
	}
	/// <summary> When true, verifies the computed inverse against the identity after each <see cref="Rcp"/> call. </summary>
	public bool DoCheckInverse = true;

	/// <summary> Returns a double array of length <see cref="Count"/> with <paramref name="value"/> at <paramref name="pos"/> and zeros elsewhere. </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 4)]
	[Tags("code/abstract_base", "code/geometric_algebra")]
	[System.ComponentModel.Description("Returns a double array of length Count with value at pos and zeros elsewhere.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	protected double[] DOUBLES(int pos, double value = 1) {
		var ret = new double[Count];
		ret[pos] = value;
		return ret;
	}

	/// <summary>Reciprocal of this geometric Number</summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 4)]
	[Tags("code/abstract_base", "code/geometric_algebra")]
	[System.ComponentModel.Description("Reciprocal of this geometric Number")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	protected abstract double[][] Coefficients();
	/// <summary> Returns the multiplicative reciprocal, choosing the fastest path based on grade. </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 4)]
	[Tags("code/abstract_base", "code/geometric_algebra")]
	[System.ComponentModel.Description("Returns the multiplicative reciprocal, choosing the fastest path based on grade.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public virtual T Rcp() {
		var maxGrade = this.MaxGrade();
		if (maxGrade == 0) {
			var ret = new float[Count];
			ret[0] = 1 / this[0];
			return Create_(ret);
		}
		if (maxGrade <= 1) {
			return RcpVector();
		}
		var minGrade = this.MinGrade();
		if (minGrade == Dim) {
			var ret = new float[Count];
			ret[Count-1] = (float) (Self().NormSqrI() / this[Count-1]);
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
	[Facets(Layer = "domain", Status = "stable", Complexity = 4)]
	[Tags("code/abstract_base", "code/geometric_algebra")]
	[System.ComponentModel.Description("Computes the reciprocal of a pure vector or co-vector via conjugation and norm scaling.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	protected T RcpVector() {
		var ret = Conjugate(); //TODO: do inversion symbolically and then simplify!
		var normSqr = NormSqr(); //that should yield the same result. 
		if (normSqr.IsOne() || normSqr.IsSmallerThanAbs(PgaTolerance.Double)) { // || normSqr.IsMinusOne()) {
			return ret;
		}

		return ret.Times(1 / normSqr);
	}

	/// <summary> Adds <paramref name="addend"/> component-wise to this multivector. </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 4)]
	[Tags("code/abstract_base", "code/geometric_algebra")]
	[System.ComponentModel.Description("Adds addend component-wise to this multivector.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public abstract T Plus<V>(V addend) where V : IReadOnlyList<float>;

#pragma warning disable 8633

	/// <summary> Subtracts <paramref name="subtrahend"/> component-wise from this multivector. </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 4)]
	[Tags("code/abstract_base", "code/geometric_algebra")]
	[System.ComponentModel.Description("Subtracts subtrahend component-wise from this multivector.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public abstract IReadOnlyList<float> Minus<P>(P subtrahend) where P : T;

	/// <summary>Subtracts this multivector from <paramref name="minuend"/> component-wise (minuend - this).<br/>
	/// Scales this multivector by the measure value of <paramref name="multiplicand"/>.</summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 4)]
	[Tags("code/abstract_base", "code/geometric_algebra")]
	[System.ComponentModel.Description("Subtracts this multivector from minuend component-wise (minuend - this). Scales this multivector by the measure value of multiplicand.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public IReadOnlyList<float> MinusR<P>(P minuend) where P : T => Minus(minuend);
	/// <inheritdoc cref="Times(IReadOnlyList{float})"/>
	public IReadOnlyList<float> Times<S>(S multiplicand) where S : IIMeasureAble => Times(multiplicand.AsDouble());

	/// <summary> Returns true when all components of <paramref name="that"/> are exactly equal to those of this multivector. </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 4)]
	[Tags("code/abstract_base", "code/geometric_algebra")]
	[System.ComponentModel.Description("Returns true when all components of that are exactly equal to those of this multivector.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public bool IsEqualTo<S>(S that) where S : T => this.SequenceEqual(that);

#pragma warning restore 8633

	/// <inheritdoc cref="Plus(double)"/>
	IReadOnlyList<float> ICanMerge<T, IReadOnlyList<float>>.Plus<V>(V addend) => Plus(addend);

	/// <summary>Creates a new multivector from the values in <paramref name="versor"/>.<br/>
	/// Adds <paramref name="b"/> component-wise and returns the result as a new multivector.</summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 4)]
	[Tags("code/abstract_base", "code/geometric_algebra")]
	[System.ComponentModel.Description("Creates a new multivector from the values in versor. Adds b component-wise and returns the result as a new multivector.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public abstract T Create(IReadOnlyList<float> versor);
	/// <inheritdoc cref="Plus(double)"/>
	public virtual T Plus(IReadOnlyList<float> b) => Create(b.Plus(this));
	/// <summary> Subtracts <paramref name="b"/> component-wise and returns the result as a new multivector. </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 4)]
	[Tags("code/abstract_base", "code/geometric_algebra")]
	[System.ComponentModel.Description("Subtracts b component-wise and returns the result as a new multivector.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public virtual T Minus(IReadOnlyList<float> b) => Create(ArrayFloat.Minus(this, b));
	/// <summary> Subtracts this from <paramref name="b"/> component-wise and returns the result as a new multivector. </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 4)]
	[Tags("code/abstract_base", "code/geometric_algebra")]
	[System.ComponentModel.Description("Subtracts this from b component-wise and returns the result as a new multivector.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public virtual T MinusR(IReadOnlyList<float> b) => Create(b.Minus(this));

	#endregion binary Functions

	#region Unary Operators

	/// <inheritdoc cref="Neg"/>
	public static T operator - (AGeoGebra<T> a) => a.Neg();

	/// <inheritdoc cref="Reverted"/>
	public static T operator ~ (AGeoGebra<T> a) => a.Reverted();

	/// <inheritdoc cref="Dual"/>
	public static T operator ! (AGeoGebra<T> a) => a.Dual();

	#endregion Unary Operators

	#region Binary Operators, all associative

	/// <summary> Full geometric product: ^ + * </summary>
	public static T operator * (AGeoGebra<T> a, IReadOnlyList<float> b) => a.Times(b);
	/// <inheritdoc cref="TimesR"/>
	public static T operator * (IReadOnlyList<float> b, AGeoGebra<T> a) => a.TimesR(b);
	/// <inheritdoc cref="Times(IReadOnlyList{float})"/>
	public static T operator * (AGeoGebra<T> a, AGeoGebra<T> b) => a.Times(b);

	/// <summary> ^ outer product. (MEET) </summary>
	public static T operator ^ (AGeoGebra<T> a, IReadOnlyList<float> b) => a.Meet(b);
	/// <inheritdoc cref="MeetR"/>
	public static T operator ^ (IReadOnlyList<float> b, AGeoGebra<T> a) => a.MeetR(b);
	/// <inheritdoc cref="Meet"/>
	public static T operator ^ (AGeoGebra<T> b, AGeoGebra<T> a) => a.MeetR(b);

	/// <summary> &amp; regressive product. (JOIN); associative </summary>
	public static T operator & (AGeoGebra<T> a, IReadOnlyList<float> b) => a.Join(b);
	/// <inheritdoc cref="Join"/>
	public static T operator & (IReadOnlyList<float> a, AGeoGebra<T> b) => b.Join(a);
	/// <inheritdoc cref="Join"/>
	public static T operator & (AGeoGebra<T> a, AGeoGebra<T> b) => b.Join(a);

	/// <summary> | Dot; inner product. </summary>
	public static T operator | (AGeoGebra<T> a, IReadOnlyList<float> b) => a.Dot(b);
	/// <inheritdoc cref="Dot"/>
	public static T operator | (IReadOnlyList<float> b, AGeoGebra<T> a) => a.Dot(b);
	/// <inheritdoc cref="Dot"/>
	public static T operator | (AGeoGebra<T> a, AGeoGebra<T> b) => a.Dot(b);

	/// <summary> + MultiVector addition </summary>
	public static T operator + (AGeoGebra<T> a, AGeoGebra<T> b) => a.Plus(b);
	/// <inheritdoc cref="Plus(IReadOnlyList{float})"/>
	public static T operator + (AGeoGebra<T> a, IReadOnlyList<float> b) => a.Plus(b);
	/// <inheritdoc cref="Plus(IReadOnlyList{float})"/>
	public static T operator + (IReadOnlyList<float> b, AGeoGebra<T> a) => a.Plus(b);

	/// <summary> MultiVector subtraction </summary>
	public static T operator - (AGeoGebra<T> a, AGeoGebra<T> b) => a.Minus(b);
	/// <inheritdoc cref="Minus(IReadOnlyList{float})"/>
	public static T operator - (AGeoGebra<T> a, IReadOnlyList<float> b) => a.Minus(b);
	/// <inheritdoc cref="MinusR(IReadOnlyList{float})"/>
	public static T operator - (IReadOnlyList<float> b, AGeoGebra<T> a) => a.MinusR(b);

	/// <inheritdoc cref="Sandwich"/>
	public static T operator <(AGeoGebra<T> versor, AGeoGebra<T> v) => versor.Sandwich(v);
	/// <inheritdoc cref="Sandwich"/>
	public static IEnumerable<T> operator <(AGeoGebra<T> versor, IEnumerable<AGeoGebra<T>> vectors) => vectors.Select(versor.Sandwich);
	/// <inheritdoc cref="SandwichBy"/>
	public static IEnumerable<T> operator >(AGeoGebra<T> vector, IEnumerable<AGeoGebra<T>> versors) => versors.Select(versor => versor.Sandwich(vector));

	/// <inheritdoc cref="SandwichBy"/>
	public static T operator >(AGeoGebra<T> v, AGeoGebra<T> versor) => versor.Sandwich(v);
	/// <inheritdoc cref="SandwichBy"/>
	public static IEnumerable<T> operator >(IEnumerable<AGeoGebra<T>> vectors, AGeoGebra<T> versor) => vectors.Select(versor.Sandwich);
	/// <inheritdoc cref="Sandwich"/>
	public static IEnumerable<T> operator <(IEnumerable<AGeoGebra<T>> versors, AGeoGebra<T> vector) => versors.Select(versor => versor.Sandwich(vector));

	/// <summary> &lt; AKA Map, 'Sandwich' Product: ~this * <paramref name="vector"/> * this </summary>
	/// <remarks>
	/// Applies this Transformation to <paramref name="vector"/>. 
	/// When the <see cref="NormSqr"/> is not 1, the Result should subsequently be normed! 
	///
	/// The <see cref="Sandwich"/> Product distributes over the geometric Product <see cref="Times(IReadOnlyList{float})"/>.
	/// I.e. Sandwich(a*b) == Sandwich(a)*Sandwich(b).
	/// This makes it so useful, because it can be applied to any geometric Object
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
	[Facets(Layer = "domain", Status = "stable", Complexity = 4)]
	[Tags("code/abstract_base", "code/geometric_algebra")]
	[System.ComponentModel.Description("&lt; AKA Map, 'Sandwich' Product: ~this * vector * this")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public T Sandwich(AGeoGebra<T> vector) => Conjugate() * vector * this;

	/// <summary> > AKA Map, 'Sandwich' Product: ~<paramref name="versor"/> * this * <paramref name="versor"/> </summary>
	/// <remarks>
	/// Applies the Transformation defined by <paramref name="versor"/>. 
	/// When the <see cref="NormSqr"/> is not 1, the Result should subsequently be normed.
	/// 
	/// <paramref name="versor"/> itself is invariant under this Transformation! (prove by inserting into Expression)
	/// </remarks>
	[Facets(Layer = "domain", Status = "stable", Complexity = 4)]
	[Tags("code/abstract_base", "code/geometric_algebra")]
	[System.ComponentModel.Description("> AKA Map, 'Sandwich' Product: ~versor * this * versor")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public T SandwichBy(AGeoGebra<T> versor) => versor.Conjugate() * this * versor;

	/// <summary> scalar/multiVector multiplication </summary>
	public static T operator * (double factor, AGeoGebra<T> b) => b.Times(factor);

	/// <summary> multiVector/scalar multiplication </summary>
	public static T operator * (AGeoGebra<T> a, double factor) => a.Times(factor);

	/// <summary> multiVector/scalar division </summary>
	public static T operator / (AGeoGebra<T> a, double divisor) => a.Per(divisor);

	/// <summary> +; Plus, Add; multiVector/scalar addition </summary>
	public static T operator + (double a, AGeoGebra<T> b) => b.Plus(a, (DayOfWeek)0);

	/// <summary> +; Plus, Add; multiVector/scalar addition </summary>
	public static T operator + (AGeoGebra<T> a, double b) => a.Plus(b, (DayOfWeek)0);

	/// <summary> -; Minus, Sub; scalar/multiVector subtraction </summary>
	public static T operator - (double a, AGeoGebra<T> b) => b.MinusR(a, (DayOfWeek)0);

	/// <summary> - multiVector -scalar subtraction </summary>
	public static T operator - (AGeoGebra<T> a, double b) => a.Minus(b, (DayOfWeek)0);

	#endregion Binary Operators

}
