using org.SpocWeb.root.Attributes;
namespace org.SpocWeb.root.maths.pga;

/// <summary> Explicit absolute Tolerances for Zero- and Equality-Tests of normalized PGA Components. </summary>
/// <remarks>
/// Replaces the obsolete global-accuracy overloads of <c>IsZero()</c> and <c>IsApprox()</c>.
/// Components are of Magnitude ~1, so absolute Tolerances are meaningful.
/// </remarks>
[DocState(Pass = 2, MTime = "2026-10-06T10:57:01Z", Digest = "a00acfe9dcd8084f66c8b2655c64aa4f4d760f094d79a8a8c5daa9590a5b23b3", Stale = false, Path = "PgaTolerance.cs", Since = "2026-10-06")]
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
