using org.SpocWeb.root.Attributes;
namespace org.SpocWeb.root.maths.pga;

/// <summary> Explicit absolute Tolerances for Zero- and Equality-Tests of normalized PGA Components. </summary>
/// <remarks>
/// Replaces the obsolete global-accuracy overloads of <c>IsZero()</c> and <c>IsApprox()</c>.
/// Components are of Magnitude ~1, so absolute Tolerances are meaningful.
/// </remarks>
[Facets(Layer = "foundation", Status = "stable", Complexity = 1)]
[Tags("code/numeric_constants", "code/constant")]
[System.ComponentModel.Description("Explicit absolute Tolerances for Zero- and Equality-Tests of normalized PGA Components.")]
[Concept("numerical_tolerance")]
[Concept("reproducible_test_seed")]
public static class PgaTolerance {

	/// <summary> About 10 float Epsilons (1.2e-7 each); for <see cref="float"/> Components. </summary>
	public const double Float = 1e-6;

	/// <summary> For <see cref="double"/> Components; the library's default for Calculations with doubles. </summary>
	public const double Double = 1e-9;

	/// <summary> Fixed Seed for the random Test-Inputs, so that Failures are reproducible. </summary>
	public const int TestSeed = 20261003;

}
