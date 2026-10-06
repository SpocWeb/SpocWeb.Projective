using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using org.SpocWeb.root.expressions;
using org.SpocWeb.root.extensions.maths;
using org.SpocWeb.root.Attributes;

namespace org.SpocWeb.root.maths.pga;

/// <summary> 3D Projective Algebra Odd/Reflector Components: Planes and Points (2*4*float) </summary>
/// <remarks>
/// <see cref="Vector4"/> is an incomplete geometric Number.
/// It cannot be inverted.
/// </remarks>
[DocState(Pass = 2, MTime = "2026-05-24T15:36:37Z", Digest = "1cde3d8d337430e1709e2e44d4e868cf33d108601843f60f27b848b314f58306", Stale = false, Path = "pga/Reflector3P.cs", Since = "2026-10-06")]
[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
[Tags("code/projective_geometric_algebra", "code/value_object")]
[System.ComponentModel.Description("3D Projective Algebra Odd/Reflector Components: Planes and Points (2*4*float)")]
[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
public class Reflector3P : IEquatable<Reflector3P>, //AGeoGebra16<Pga3D>,
	IExpression<Reflector3P>, //AGeoGebra16<Pga3D>,
	IReadOnlyList<float>
{
	#region Grade1: (Hyper-)Planes/Reflections

	/// <inheritdoc cref="Pga3D.Base.e0"/>
	public readonly float Sky;

	/// <inheritdoc cref="Pga3D.Base.e1"/>
	public readonly float YZ;

	/// <inheritdoc cref="Pga3D.Base.e2"/>
	public readonly float ZX;

	/// <inheritdoc cref="Pga3D.Base.e3"/>
	public readonly float XY;

	#endregion Grade1: (Hyper-)Planes/Reflections

	#region Grade3: Points

	/// <inheritdoc cref="Pga3D.Base.e032"/>
	public readonly float X;

	/// <inheritdoc cref="Pga3D.Base.e013"/>
	public readonly float Y;

	/// <inheritdoc cref="Pga3D.Base.e021"/>
	public readonly float Z;

	/// <inheritdoc cref="Pga3D.Base.e123"/>
	public readonly float W;

	#endregion Grade3: Points

	/// <summary>Initializes a new instance of <see cref="Reflector3P"/> with the specified <paramref name="sky"/>, <paramref name="yz"/>, <paramref name="zx"/>, <paramref name="xy"/>, <paramref name="x"/>, <paramref name="y"/>, <paramref name="z"/> and <paramref name="w"/>.</summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/projective_geometric_algebra", "code/value_object")]
	[System.ComponentModel.Description("Initializes a new instance of Reflector3P with the specified sky, yz, zx, xy, x, y, z and w.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public Reflector3P(float sky, float yz, float zx, float xy, float x, float y, float z, float w) {
		Sky = sky;
		YZ = yz;
		ZX = zx;
		XY = xy;
		X = x;
		Y = y;
		Z = z;
		W = w;
	}

	/// <summary> Returns a value-based hash code for use in equality-sensitive collections. </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/projective_geometric_algebra", "code/value_object")]
	[System.ComponentModel.Description("Returns a value-based hash code for use in equality-sensitive collections.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public int ValueHash() => GetHashCode();
	/// <inheritdoc />
	public override int GetHashCode() {
		unchecked {
			var hashCode = Sky.GetHashCode();
			hashCode = (hashCode << 1) ^ X.GetHashCode();
			hashCode = (hashCode << 1) ^ Y.GetHashCode();
			hashCode = (hashCode << 1) ^ Z.GetHashCode();
			hashCode = (hashCode << 1) ^ XY.GetHashCode();
			hashCode = (hashCode << 1) ^ ZX.GetHashCode();
			hashCode = (hashCode << 1) ^ YZ.GetHashCode();
			hashCode = (hashCode << 1) ^ W.GetHashCode();
			return hashCode;
		}
	}

	/// <inheritdoc />
	public override bool Equals(object obj) => obj is Reflector3P reflector && Equals(reflector);
	/// <summary>Determines whether equal To.</summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/projective_geometric_algebra", "code/value_object")]
	[System.ComponentModel.Description("Determines whether equal To.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public bool IsEqualTo(Reflector3P that) => Equals(that);

	/// <inheritdoc cref="Equals(object)"/>
	public bool Equals(Reflector3P other) => Sky.IsApprox(other.Sky, PgaTolerance.Float)
		&& X.Equals(other.X) && Y.IsApprox(other.Y, PgaTolerance.Float) && Z.IsApprox(other.Z, PgaTolerance.Float)
		&& XY.IsApprox(other.XY, PgaTolerance.Float) && ZX.IsApprox(other.ZX, PgaTolerance.Float) && YZ.IsApprox(other.YZ, PgaTolerance.Float) && W.IsApprox(other.W, PgaTolerance.Float);

	/// <summary>Separator string inserted between component values when writing to a text stream.</summary>
	public static string Infix = ", ";
	/// <summary> Writes the eight components separated by <see cref="Infix"/> to <paramref name="writer"/> and returns <paramref name="lengthLeft"/> unchanged. </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/projective_geometric_algebra", "code/value_object")]
	[System.ComponentModel.Description("Writes the eight components separated by Infix to writer and returns lengthLeft unchanged.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public long WriteTo(TextWriter writer, long lengthLeft) {
		writer.Write(Sky);
		writer.Write(Infix); writer.Write(YZ);
		writer.Write(Infix); writer.Write(ZX);
		writer.Write(Infix); writer.Write(XY);
		writer.Write(Infix); writer.Write(X);
		writer.Write(Infix); writer.Write(Y);
		writer.Write(Infix); writer.Write(Z);
		writer.Write(Infix); writer.Write(W);
		return lengthLeft;
	}

	/// <inheritdoc />
	public Reflector3P Evaluate() => this;
	/// <inheritdoc />
	public Reflector3P Self() => this;

	/// <summary>Gets the number of elements.</summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/projective_geometric_algebra", "code/value_object")]
	[System.ComponentModel.Description("Gets the number of elements.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public int Count => 8;

	/// <inheritdoc />
	IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	/// <inheritdoc cref="GetEnumerator()"/>
	public IEnumerator<float> GetEnumerator() {
		yield return Sky;
		yield return YZ;
		yield return ZX;
		yield return XY;
		yield return X;
		yield return Y;
		yield return Z;
		yield return W;
	}

	/// <summary>Gets or sets the element at the specified <paramref name="index"/>.</summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/projective_geometric_algebra", "code/value_object")]
	[System.ComponentModel.Description("Gets or sets the element at the specified index.")]
	[Concept("Mathematics\\Geometry\\Geometric_Algebra.md")]
	public float this[int index] =>
		index switch {
			0 => Sky,
			1 => YZ,
			2 => ZX,
			3 => XY,
			4 => X,
			5 => Y,
			6 => Z,
			7 => W,
			_ => throw new IndexOutOfRangeException()
		};
}
