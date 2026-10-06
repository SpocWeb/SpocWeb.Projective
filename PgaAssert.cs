using org.SpocWeb.root.Attributes;
namespace org.SpocWeb.root.maths.pga;

/// <summary> Component-wise Comparison of float Multivectors with an explicit Tolerance. </summary>
/// <remarks>
/// ## Public Methods
///
/// | Line | Method | Description |
/// |--:|---|---|
/// | 22 | <see cref="AreClose"/> | Asserts that all Components differ by at most tolerance * max(1, |expected|). |
/// </remarks>
[DocState(Pass = 2, MTime = "2026-10-06T10:57:00Z", Digest = "9c5947d037dd231cae90a225bb186c60f38637996cc3dd1ac6e9345acb4763f6", Stale = false, Path = "PgaAssert.cs", Since = "2026-10-06")]
[Facets(Layer = "test", Status = "stable", Complexity = 1)]
[Tags("code/assertion", "code/test_helper", "code/nunit")]
[System.ComponentModel.Description("Component-wise Comparison of float Multivectors with an explicit Tolerance.")]
[Concept("float_tolerance_comparison")]
[Concept("multivector_components")]
public static class PgaAssert {

	/// <summary> Asserts that all Components differ by at most <paramref name="tolerance"/> * max(1, |expected|). </summary>
	/// <remarks> Relative for large and absolute for small Components, so 1e12 +- 6e4 float-Noise passes. </remarks>
	[Facets(Layer = "test", Status = "stable", Complexity = 1)]
	[Tags("code/assertion", "code/numeric_comparison")]
	[System.ComponentModel.Description("Asserts that all Components differ by at most tolerance * max(1, |expected|).")]
	[Concept("float_tolerance_comparison")]
	[Concept("mixed_relative_absolute_tolerance")]
	public static void AreClose(IReadOnlyList<float> actual, IReadOnlyList<float> expected, double tolerance = PgaTolerance.Float) {
		Assert.That(actual.Count, Is.EqualTo(expected.Count), "Component Count");
		for (var i = 0; i < expected.Count; i++) {
			var allowed = tolerance * Math.Max(1.0, Math.Abs(expected[i]));
			Assert.That(actual[i], Is.EqualTo(expected[i]).Within(allowed),
				$"Component [{i}] of {string.Join(", ", actual)} vs expected {string.Join(", ", expected)}");
		}
	}

}
