using System;
using System.Collections.Generic;
using org.SpocWeb.root.iMath;
using org.SpocWeb.root.interfaces;
using org.SpocWeb.root.interfaces.maths;

namespace org.SpocWeb.root.maths.pga;

/// <summary> GA define several Products that transform its 2^n Dimensions into each other, described by Cayley Tables. </summary>
/// <remarks>
/// Every geometric Algebra is a VectorSpace of the Elements
///
/// Sub-Algebras: 
/// * G+ = take only even grades of the algebra (0=scalar,2=bi-vector...)
/// * G- = take only odd grades of the algebra (1=vector,3-tri-vector...)
/// 
/// Designation	Geometric Algebra based on
/// G(2,0,0)	2D multi-vector 
/// G(3,0,0)	3D multi-vector 
/// G(4,0,0)	4D multi-vector 
/// G(2,1,0)	complex Numbers/Rotations/Boost
/// G(2,1,1)	2D Rotations &amp; Translations
/// G(1,0,1)	Dual Numbers
/// G(1,0,0)	Real Numbers
/// G+2,0,0)	complex Numbers: x and y not used; Scalar + i = e12
/// G+3,0,0)	quaternions:  x, y and z not used; Scalar + i = e23 + j = e31 + k = e12; I = e123 not used
/// G(3,1,0)	space-time algebra (STA)
/// </remarks>
/// <example>
/// <code language="yaml">
/// pass: 2
/// mtime: 2026-05-24T15:36:24Z
/// digest: d288fe3f0b875d8b5a25e3c511a8a67419286f46ac396e9c09322e3ee63e0cd8
/// tags: [code/interface, code/geometric_algebra]
/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
/// facets: {layer: domain, status: stable, complexity: 2}
/// </code>
/// </example>
public interface IGeoGebra<T,F> : IReadOnlyList<F>, IEquatable<T>
	, ICanScaleWith<IIMeasureAble, T, IReadOnlyList<F>> //IVectorSpace<T> 
	where T : IGeoGebra<T, F>
{
	/// <summary> Dimensionality of the Basis-Vector Space R^<see cref="Dim"/> </summary>
	/// <remarks> <see cref="IReadOnlyCollection{T}.Count"/> = 2^<see cref="Dim"/>
	/// is the Dimensionality of the resulting euclidean Multi-Vector-Space E</remarks>
	/// <example>
	/// <code language="yaml">
	/// tags: [code/interface, code/geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 2}
	/// </code>
	/// </example>
	byte Dim { get; }

	/// <summary> ! Poincare dual; </summary>
	/// <remarks>Bi-Potent Operator; yields the orthogonal Sub-Space.
	/// Is constructed by multiplying with the R^n Unit Volume.
	/// !(A�B) = !A x !B
	/// So Dot and Cross Products are Dual Operators
	/// that combined describe invertible Product. 
	/// </remarks>
	/// <example>
	/// <code language="yaml">
	/// tags: [code/interface, code/geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 2}
	/// </code>
	/// </example>
	T Dual();

	/// <summary> * Scalar product. </summary>
	/// <remarks>
	/// commutative.
	/// </remarks>
	/// <example>
	/// <code language="yaml">
	/// tags: [code/interface, code/geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 2}
	/// </code>
	/// </example>
	T Times(double factor);

	/// <summary>Full geometric product: ^ + � resp. &amp; and |<br/>
	/// Reverse of <see cref="Times(IReadOnlyList{F})"/></summary>
	/// <remarks>
	/// Not commutative; has <see cref="Meet"/> as anti-commuting,
	/// and <see cref="Dot"/> as commuting Component.
	/// </remarks>
	/// <example>
	/// <code language="yaml">
	/// tags: [code/interface, code/geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 2}
	/// </code>
	/// </example>
	T Times(IReadOnlyList<F> factor);
	/// <summary> Geometric product of <paramref name="factor"/> with this multivector (factor * this). </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/interface, code/geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 2}
	/// </code>
	/// </example>
	T TimesR(IReadOnlyList<F> factor);

	/// <summary> |,� Dot/inner/regressive/Tensor-Product; reduces the Grade </summary>
	/// <remarks>
	/// Inner product by a vector reduces the grade of a multi-vector by 1 (regressive).
	/// Only the <paramref name="parallel"/> Part counts, weighted by the Metric.
	/// All other Components are orthogonal.
	/// </remarks>
	/// <example>
	/// <code language="yaml">
	/// tags: [code/interface, code/geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 2}
	/// </code>
	/// </example>
	T Dot(IReadOnlyList<F> parallel);

	/// <summary>^ Wedge/Meet/outer Product<br/>
	/// ^ MEET reverse outer product.</summary>
	/// <remarks>
	/// 'Outer' product by a vector increases the grade of a multi-vector by 1 (progressive).
	/// In 3D it corresponds to the Cross-Product: a x b = ia^b.
	///
	/// Anti-commuting between orthogonal Elements.
	/// </remarks>
	/// <example>
	/// <code language="yaml">
	/// tags: [code/interface, code/geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 2}
	/// </code>
	/// </example>
	T Meet(IReadOnlyList<F> that);
	/// <summary> Outer (wedge / meet) product of <paramref name="that"/> with this multivector (that ^ this). </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/interface, code/geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 2}
	/// </code>
	/// </example>
	T MeetR(IReadOnlyList<F> that);

	/// <summary> v,&amp; Join/regressive Product </summary>
	/// <remarks>
	/// Grassmann�s regressive Join Product is designed to be the Dual to the Wedge/<see cref="Meet"/> Product:
	///
	/// (A v B)~ = A~ ^ B~
	/// 
	/// (B ^ C) v (A ^ B) = (A ^ B ^ C) v B
	/// 
	/// The Symbols ^ and v should remind of the dual Operations of Intersect/Meet and Union/Join. 
	/// </remarks>
	/// <example>
	/// <code language="yaml">
	/// tags: [code/interface, code/geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 2}
	/// </code>
	/// </example>
	T Join(IReadOnlyList<F> that);

	/// <inheritdoc cref="Plus(IReadOnlyList{F})"/>
	T Plus<B>(double scalar, B basis) where B : Enum;

	/// <inheritdoc cref="Minus(IReadOnlyList{F})"/>
	T Minus<B>(double scalar, B basis) where B : Enum;

	/// <inheritdoc cref="MinusR(IReadOnlyList{F})"/>
	T MinusR<B>(double scalar, B basis) where B : Enum;

	/// <summary> Adds <paramref name="b"/> component-wise to this multivector. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/interface, code/geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 2}
	/// </code>
	/// </example>
	T Plus(IReadOnlyList<F> b);
	/// <summary> Subtracts <paramref name="b"/> component-wise from this multivector. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/interface, code/geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 2}
	/// </code>
	/// </example>
	T Minus(IReadOnlyList<F> b);
	/// <summary> Subtracts this multivector from <paramref name="b"/> component-wise (b - this). </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/interface, code/geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 2}
	/// </code>
	/// </example>
	T MinusR(IReadOnlyList<F> b);
	/// <summary> Creates a new multivector from <paramref name="list"/>, copying its values. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/interface, code/geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 2}
	/// </code>
	/// </example>
	T Create(IList<F> list);
	/// <summary> Signed square norm; equals (this * Conjugate())[0]. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/interface, code/geometric_algebra]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 2}
	/// </code>
	/// </example>
	double NormSqr();
	//double NormAbs();
}

/// <summary> Extension Methods for <see cref="IGeoGebra{T,F}"/>. </summary>
/// <remarks>
/// ## Public Methods
///
/// | Line | Method | Description |
/// |--:|---|---|
/// | 138 | <see cref="Plus"/> | Adds the unit basis blade basis to multiVector. |
/// | 141 | <see cref="Minus"/> | Subtracts the unit basis blade basis from multiVector. |
/// | 144 | <see cref="MinusR"/> | Reverse subtraction: unit basis blade basis minus multiVector. |
/// | 156 | <see cref="ProjectedOn"/> | Non-normalized projection of a onto normal. |
/// | 168 | <see cref="RejectedFrom"/> | Component of a orthogonal to normal (equals a minus its projection onto normal). |
/// | 172 | <see cref="ReflectedByNormal"/> | Reflects a at the HyperPlane perpendicular to normal |
///
/// ## Collaborators
///
/// | Type | Role |
/// |---|---|
/// | <see cref="IGeoGebra"/> | Returned by a method. |
/// </remarks>
///
/// <example>
/// <code language="yaml">
/// pass: 2
/// mtime: 2026-06-17T05:55:16Z
/// digest: c3d57ec6c170096dcf07a1d24e70fe9d7c119b6675407199c0a0900c7dbf102f
/// tags: [code/extension_method, code/geometric_algebra]
/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
/// facets: {layer: domain, status: stable, complexity: 2}
/// </code>
/// </example>
public static partial class XGeoGebra
{

	/// <summary> Adds the unit basis blade <paramref name="basis"/> to <paramref name="multiVector"/>. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/extension_method, code/addition]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 1}
	/// </code>
	/// </example>
	public static T Plus<T,F,B>(this T multiVector, B basis) where T : IGeoGebra<T,F> where B : Enum => multiVector.Plus(1, basis);

	/// <summary> Subtracts the unit basis blade <paramref name="basis"/> from <paramref name="multiVector"/>. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/extension_method, code/subtraction]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 1}
	/// </code>
	/// </example>
	public static T Minus<T,F,B>(this T multiVector, B basis) where T : IGeoGebra<T,F> where B : Enum => multiVector.Minus(1, basis);

	/// <summary> Reverse subtraction: unit basis blade <paramref name="basis"/> minus <paramref name="multiVector"/>. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/extension_method, code/subtraction]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 1}
	/// </code>
	/// </example>
	public static T MinusR<T,F,B>(this T multiVector, B basis) where T : IGeoGebra<T,F> where B : Enum => multiVector.MinusR(1, basis);

	/// <summary> Adds scalar <paramref name="x"/> to the scalar component of <paramref name="multiVector"/>. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/extension_method, code/scalar_addition]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 1}
	/// </code>
	/// </example>
	public static T Plus<T,F>(this T multiVector, double x) where T : IGeoGebra<T,F> => multiVector.Plus(x, (DayOfWeek)0);

	/// <summary> Subtracts scalar <paramref name="x"/> from the scalar component of <paramref name="multiVector"/>. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/extension_method, code/subtraction]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 1}
	/// </code>
	/// </example>
	public static T Minus<T,F>(this T multiVector, double x) where T : IGeoGebra<T,F> => multiVector.Minus(x, (DayOfWeek)0);

	/// <summary> Reverse subtraction: scalar <paramref name="x"/> minus the scalar component of <paramref name="multiVector"/>. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/extension_method, code/subtraction]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 1}
	/// </code>
	/// </example>
	public static T MinusR<T,F>(this T multiVector, double x) where T : IGeoGebra<T,F> => multiVector.MinusR(x, (DayOfWeek)0);

	/// <summary> Non-normalized projection of <paramref name="a"/> onto <paramref name="normal"/>. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/extension_method, code/vector_projection]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 2}
	/// </code>
	/// </example>
	public static IGeoGebra<T,F> ProjectedOn<T,F>(this IGeoGebra<T,F> a, IGeoGebra<T,F> normal) where T : IGeoGebra<T,F> {
		T dot = a.Dot(normal);
		double factor = Convert.ToDouble(dot[0]);
		var normSqr = normal.NormSqr();
		if (!normSqr.IsOne()) {
			factor /= normSqr;
		}
		return normal.Times(factor);
	}

	/// <summary> Component of <paramref name="a"/> orthogonal to <paramref name="normal"/>
	/// (equals <paramref name="a"/> minus its projection onto <paramref name="normal"/>). </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/extension_method, code/vector_projection]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 1}
	/// </code>
	/// </example>
	public static IGeoGebra<T,F> RejectedFrom<T,F>(this IGeoGebra<T,F> a, IGeoGebra<T,F> normal)
		where T : IGeoGebra<T,F> => a.Minus(a.ProjectedOn(normal));

	/// <summary> Reflects <paramref name="a"/> at the HyperPlane perpendicular to <paramref name="normal"/> </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/extension_method, code/vector_reflection]
	/// concepts: [Mathematics\Geometry\Geometric_Algebra.md]
	/// facets: {layer: domain, status: stable, complexity: 1}
	/// </code>
	/// </example>
	public static IGeoGebra<T,F> ReflectedByNormal<T,F>(this IGeoGebra<T,F> a, IGeoGebra<T,F> normal) 
		where T : IGeoGebra<T,F> => a.Minus(a.ProjectedOn(normal).Times(2));

	//public static T Plus<T>(this IGeoGebra<T,F> self, IReadOnlyList<F> that) where T : IGeoGebra<T,F> 
	//	=> self.Create(that.Plus(self));
	//public static T Minus<T>(this IGeoGebra<T,F> self, IReadOnlyList<F> that) where T : IGeoGebra<T,F> 
	//	=> self.Create(((IReadOnlyList<F>)self).Minus(that));
	//public static T MinusR<T>(this IGeoGebra<T,F> self, IReadOnlyList<F> that) where T : IGeoGebra<T,F> 
	//	=> self.Create(that.Minus(self));
}
