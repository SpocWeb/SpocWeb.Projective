using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using org.SpocWeb.root.expressions;
using org.SpocWeb.root.extensions.maths;
using org.SpocWeb.root.interfaces.maths;
using org.SpocWeb.root.Attributes;

namespace org.SpocWeb.root.maths.pga;

/// <summary> 2D Projective Algebra Reflector Components: 3 Lines + Z Scale </summary>
/// <remarks>
/// Only odd Components of the full Algebra
/// </remarks>
[DocState(Pass = 2, MTime = "2026-05-24T15:36:37Z", Digest = "398df9672285acce0792bcd93e1eb0bb8cf183995263e5ae547745c69a49702a", Stale = false, Path = "pga/Reflector2P.cs", Since = "2026-10-06")]
[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
[Tags("code/projective_geometric_algebra", "code/value_object")]
[System.ComponentModel.Description("2D Projective Algebra Reflector Components: 3 Lines + Z Scale")]
[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
public readonly struct Reflector2P : 
	IEquatable<Reflector2P>,
	IExpression<Reflector2P>, //AGeoGebra16<Pga2D>,
	IReadOnlyList<float>
{
	/// <inheritdoc />
	public Reflector2P Evaluate() => this;
	/// <inheritdoc />
	public Reflector2P Self() => this;

	#region Grade1: (Hyper-)Lines/Reflections

	/// <inheritdoc cref="Pga2D.Base.e0"/>
	public readonly float Horizon;

	/// <inheritdoc cref="Pga2D.Base.e1"/>
	public readonly float AxisX;

	/// <inheritdoc cref="Pga2D.Base.e2"/>
	public readonly float AxisY;

	#endregion Grade1: (Hyper-)Lines/Reflections

	/// <inheritdoc cref="Pga2D.Base.e12"/>
	/// <summary> Grade 3: Projective Z-Distance from the Base-Plane</summary>
	public readonly float I;

	/// <summary> real e1 + e2 + projective e0 </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/projective_geometric_algebra", "code/value_object")]
	[System.ComponentModel.Description("real e1 + e2 + projective e0")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public byte Dim => 3;

	/// <summary> 2^3 = 1 + 3 + 3 + 1 </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/projective_geometric_algebra", "code/value_object")]
	[System.ComponentModel.Description("2^3 = 1 + 3 + 3 + 1")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public int Count => 8;

	/// <summary>Gets or sets the element at the specified <paramref name="index"/>.<br/>
	/// Gets or sets the element at the specified <paramref name="index"/>.</summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/projective_geometric_algebra", "code/value_object")]
	[System.ComponentModel.Description("Gets or sets the element at the specified index. Gets or sets the element at the specified index.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public float this[int index] => this[(Pga2D.Base)index];
	/// <summary>Gets or sets the element at the specified <paramref name="index"/>.</summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/projective_geometric_algebra", "code/value_object")]
	[System.ComponentModel.Description("Gets or sets the element at the specified index.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public float this[Pga2D.Base index] => index switch
	{
		Pga2D.Base._1_ => Horizon,
		Pga2D.Base.e01 => AxisX,
		Pga2D.Base.e20 => AxisY,
		Pga2D.Base.e12 => I,
		_ => 0
	};

	/// <summary>Gets or sets the element at the specified <paramref name="index"/>.</summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/projective_geometric_algebra", "code/value_object")]
	[System.ComponentModel.Description("Gets or sets the element at the specified index.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public float this[Pga2D.Lines index] => index switch
	{
		Pga2D.Lines.Horizon => Horizon,
		Pga2D.Lines.X => AxisX,
		Pga2D.Lines.Y => AxisY,
		Pga2D.Lines.I => I,
		_ => 0
	};

	/// <summary>Initializes a new instance of <see cref="Reflector2P"/> with the specified <paramref name="sky"/>, <paramref name="x"/>, <paramref name="y"/> and <paramref name="z"/>.</summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/projective_geometric_algebra", "code/value_object")]
	[System.ComponentModel.Description("Initializes a new instance of Reflector2P with the specified sky, x, y and z.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public Reflector2P(float sky, float x, float y, float z) {
		Horizon = sky;
		AxisX = x;
		AxisY = y;
		I = z;
	}

	/// <inheritdoc />
	IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	/// <inheritdoc cref="GetEnumerator()"/>
	public IEnumerator<float> GetEnumerator()
	{
		yield return Horizon;
		yield return AxisX;
		yield return AxisY;
		yield return I;
	}

	/// <inheritdoc />
	public override bool Equals(object? obj) => obj is Reflector2P other && Equals(other);
	/// <inheritdoc cref="Equals(object?)"/>
	public bool Equals(Reflector2P other) {
		var norm = this.NormAbs().MulAccuracy();
		return Horizon.IsApprox(other.Horizon, norm)
			&& AxisX.IsApprox(other.AxisX, norm)
			&& AxisY.IsApprox(other.AxisY, norm)
			&& I.IsApprox(other.I, norm);
	}

	/// <summary>Separator string inserted between component values when writing to a text stream.</summary>
	public static string Infix = ", ";
	/// <summary> Writes the four components separated by <see cref="Infix"/> to <paramref name="writer"/> and returns <paramref name="lengthLeft"/> unchanged. </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/projective_geometric_algebra", "code/value_object")]
	[System.ComponentModel.Description("Writes the four components separated by Infix to writer and returns lengthLeft unchanged.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public long WriteTo(TextWriter writer, long lengthLeft) {
		writer.Write(Horizon);
		writer.Write(Infix); writer.Write(AxisX);
		writer.Write(Infix); writer.Write(AxisY);
		writer.Write(Infix); writer.Write(I);
		return lengthLeft;
	}

	/// <summary> Returns the L1 norm of the four components as an absolute-value sum. </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/projective_geometric_algebra", "code/value_object")]
	[System.ComponentModel.Description("Returns the L1 norm of the four components as an absolute-value sum.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public double NormAbs() => Math.Abs(Horizon) + Math.Abs(AxisX) + Math.Abs(AxisY) + Math.Abs(I);

	/// <inheritdoc />
	public override int GetHashCode() => (((((Horizon.GetHashCode() << 1) ^ AxisX.GetHashCode()) << 1) ^ AxisY.GetHashCode()) << 1) ^ I.GetHashCode();

	/// <summary>Determines whether <paramref name="left"/> equals <paramref name="right"/>.<br/>
	/// Determines whether <paramref name="left"/> does not equal <paramref name="right"/>.</summary>
	public static bool operator ==(Reflector2P left, Reflector2P right) => left.Equals(right);
	/// <summary>Determines whether <paramref name="left"/> does not equal <paramref name="right"/>.</summary>
	public static bool operator !=(Reflector2P left, Reflector2P right) => !left.Equals(right);
}
