namespace org.SpocWeb.root.maths.pga;

/// <summary> Explicit absolute Tolerances for Zero- and Equality-Tests of normalized PGA Components. </summary>
/// <remarks>
/// Replaces the obsolete global-accuracy overloads of <c>IsZero()</c> and <c>IsApprox()</c>.
/// Components are of Magnitude ~1, so absolute Tolerances are meaningful.
/// </remarks>
public static class PgaTolerance {

	/// <summary> About 10 float Epsilons (1.2e-7 each); for <see cref="float"/> Components. </summary>
	public const double Float = 1e-6;

	/// <summary> For <see cref="double"/> Components; the library's default for Calculations with doubles. </summary>
	public const double Double = 1e-9;

}
