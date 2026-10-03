using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace org.SpocWeb.root.maths.pga;

/// <summary> Extension methods for generating all permutations of a list in-place
/// via Heap's algorithm, yielding each permutation together with its parity sign. </summary>
/// <remarks>
/// ## Public Methods
///
/// | Line | Method | Description |
/// |--:|---|---|
/// | 22 | <see cref="Test"/> | Test. |
/// | 56 | <see cref="Swap"/> | Swaps the elements at positions i and k in array. |
/// | 64 | <see cref="Permute"/> | Permutes the list in place and yields the individual Permutations together with their Sign |
/// </remarks>
///
/// <example>
/// <code language="yaml">
/// pass: 2
/// mtime: 2026-05-24T15:36:24Z
/// digest: 14c0750e0efe0945d41e8f6c9d8235462381d9207aeda34d5901191b9fa91edb
/// tags: [code/extension_method, code/permutation, code/heaps_algorithm]
/// concepts: [Mathematics\Statistics\Combinatorics.md]
/// facets: {layer: domain, status: stable, complexity: 4}
/// </code>
/// </example>
public static class xPermute {
 
	/// <summary>Test.</summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/unit_test, code/nunit_test]
	/// concepts: [Mathematics\Statistics\Combinatorics.md]
	/// facets: {layer: test, status: stable, complexity: 1}
	/// </code>
	/// </example>
	[Test]
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
	/// <example>
	/// <code language="yaml">
	/// tags: [code/heaps_algorithm, code/recursion]
	/// concepts: [Mathematics\Statistics\Combinatorics.md]
	/// facets: {layer: domain, status: stable, complexity: 2}
	/// </code>
	/// </example>
	static void Recursive<T>(IList<T> array, int n = int.MinValue) {
		Recursive(array, n == int.MinValue ? array.Count : n, true);
	}
 
	/// <summary> Recursively generates all n! permutations of <paramref name="array"/> by swapping a single pair per step. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/heaps_algorithm, code/permutation_generation, code/recursion]
	/// concepts: [Mathematics\Statistics\Combinatorics.md]
	/// facets: {layer: domain, status: stable, complexity: 3}
	/// </code>
	/// </example>
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
	/// <example>
	/// <code language="yaml">
	/// tags: [code/extension_method, code/console_output]
	/// concepts: [Mathematics\Statistics\Combinatorics.md]
	/// facets: {layer: presentation, status: stable, complexity: 1}
	/// </code>
	/// </example>
	static void Output<T>(this IEnumerable<T> array, bool plus) {
		Console.WriteLine(string.Join(",", array) + (plus ? " +1" : " -1"));
	}

	/// <summary> Swaps the elements at positions <paramref name="i"/> and <paramref name="k"/> in <paramref name="array"/>. </summary>
	///
	/// <example>
	/// <code language="yaml">
	/// tags: [code/extension_method, code/swap]
	/// concepts: [Technology\IT\Data\Data_Storage\Data_structure.md]
	/// facets: {layer: utility, status: stable, complexity: 1}
	/// </code>
	/// </example>
	public static void Swap<T>(this IList<T> array, int i, int k) => (array[i], array[k]) = (array[k], array[i]);

	/// <summary> Permutes the <paramref name="list"/> in place and yields the individual Permutations together with their Sign </summary>
	/// <remarks>
	/// <a href='https://en.wikipedia.org/wiki/Heap%27s_algorithm'>Heap's Algorithm</a> minimizes movement:
	/// It generates each permutation from the previous one by interchanging a single pair of elements;
	/// the other n−2 elements are not disturbed.
	/// </remarks>
	/// <example>
	/// <code language="yaml">
	/// tags: [code/extension_method, code/permutation_generation, code/custom_iterator]
	/// concepts: [Mathematics\Statistics\Combinatorics.md]
	/// facets: {layer: domain, status: stable, complexity: 4}
	/// </code>
	/// </example>
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
