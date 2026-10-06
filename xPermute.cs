using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using org.SpocWeb.root.Attributes;

namespace org.SpocWeb.root.maths.pga;

/// <summary> Extension methods for generating all permutations of a list in-place
/// via Heap's algorithm, yielding each permutation together with its parity sign. </summary>
/// <remarks>
/// ## Public Methods
///
/// | Line | Method | Description |
/// |--:|---|---|
/// | 30 | <see cref="Test"/> | Test. |
/// | 84 | <see cref="Swap"/> | Swaps the elements at positions i and k in array. |
/// | 96 | <see cref="Permute"/> | Permutes the list in place and yields the individual Permutations together with their Sign |
/// </remarks>
///
[DocState(Pass = 2, MTime = "2026-05-24T15:36:24Z", Digest = "14c0750e0efe0945d41e8f6c9d8235462381d9207aeda34d5901191b9fa91edb", Stale = false, Path = "xPermute.cs", Since = "2026-10-06")]
[Facets(Layer = "domain", Status = "stable", Complexity = 4)]
[Tags("code/extension_method", "code/permutation", "code/heaps_algorithm")]
[System.ComponentModel.Description("Extension methods for generating all permutations of a list in-place via Heap's algorithm, yielding each permutation together with its parity sign.")]
[Concept("Mathematics\\Statistics\\Combinatorics.md")]
public static class xPermute {
 
	/// <summary>Test.</summary>
	///
	[Facets(Layer = "test", Status = "stable", Complexity = 1)]
	[Tags("code/unit_test", "code/nunit_test")]
	[System.ComponentModel.Description("Test.")]
	[Test]
	[Concept("Mathematics\\Statistics\\Combinatorics.md")]
	public static void Test() {
		int[] array = Enumerable.Range(0, 4)
			.ToArray();
		Recursive(array);
		Console.WriteLine();
		foreach (var pair in Permute(array)) {
			pair.permutation.Output(pair.isEven);
		}
	}
 
	/// <summary> Starts Heap's algorithm on <paramref name="array"/>, defaulting n to the full length. </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 2)]
	[Tags("code/heaps_algorithm", "code/recursion")]
	[System.ComponentModel.Description("Starts Heap's algorithm on array, defaulting n to the full length.")]
	[Concept("Mathematics\\Statistics\\Combinatorics.md")]
	static void Recursive<T>(IList<T> array, int n = int.MinValue) {
		Recursive(array, n == int.MinValue ? array.Count : n, true);
	}
 
	/// <summary> Recursively generates all n! permutations of <paramref name="array"/> by swapping a single pair per step. </summary>
	///
	[Facets(Layer = "domain", Status = "stable", Complexity = 3)]
	[Tags("code/heaps_algorithm", "code/permutation_generation", "code/recursion")]
	[System.ComponentModel.Description("Recursively generates all n! permutations of array by swapping a single pair per step.")]
	[Concept("Mathematics\\Statistics\\Combinatorics.md")]
	static void Recursive<T>(IList<T> array, int n, bool plus) {
		if (n == 1) {
			Output(array, plus);
		} else {
			for (int i = 0; i < n; i++) {
				Recursive(array, n - 1, i == 0);
				Swap(array, n % 2 == 0 ? i : 0, n - 1);
			}
		}
	}
 
	/// <summary> Prints the current permutation with its sign to <see cref="Console"/>. </summary>
	///
	[Facets(Layer = "presentation", Status = "stable", Complexity = 1)]
	[Tags("code/extension_method", "code/console_output")]
	[System.ComponentModel.Description("Prints the current permutation with its sign to Console.")]
	[Concept("Mathematics\\Statistics\\Combinatorics.md")]
	static void Output<T>(this IEnumerable<T> array, bool plus) {
		Console.WriteLine(string.Join(",", array) + (plus ? " +1" : " -1"));
	}

	/// <summary> Swaps the elements at positions <paramref name="i"/> and <paramref name="k"/> in <paramref name="array"/>. </summary>
	///
	[Facets(Layer = "utility", Status = "stable", Complexity = 1)]
	[Tags("code/extension_method", "code/swap")]
	[System.ComponentModel.Description("Swaps the elements at positions i and k in array.")]
	[Concept("Technology\\IT\\Data\\Data_Storage\\Data_structure.md")]
	public static void Swap<T>(this IList<T> array, int i, int k) => (array[i], array[k]) = (array[k], array[i]);

	/// <summary> Permutes the <paramref name="list"/> in place and yields the individual Permutations together with their Sign </summary>
	/// <remarks>
	/// <a href='https://en.wikipedia.org/wiki/Heap%27s_algorithm'>Heap's Algorithm</a> minimizes movement:
	/// It generates each permutation from the previous one by interchanging a single pair of elements;
	/// the other n−2 elements are not disturbed.
	/// </remarks>
	[Facets(Layer = "domain", Status = "stable", Complexity = 4)]
	[Tags("code/extension_method", "code/permutation_generation", "code/custom_iterator")]
	[System.ComponentModel.Description("Permutes the list in place and yields the individual Permutations together with their Sign")]
	[Concept("Mathematics\\Statistics\\Combinatorics.md")]
	public static IEnumerable<(IList<T> permutation, bool isEven)> Permute<T>(this IList<T> list, int n = int.MinValue) {
		if (n == int.MinValue) {
			n = list.Count;
		}
		int[] c = new int[n];
		Output(list, true);
		bool plus = false;
		for (int i = 0; i < n; ) {
			if (c[i] < i) {
				Swap(list, (i & 1) == 0 ? 0 : c[i], i);
				yield return (list, plus);
				plus = !plus;
				c[i]++;
				i = 0;
			} else {
				c[i] = 0;
				i++;
			}
		}
	}
}
