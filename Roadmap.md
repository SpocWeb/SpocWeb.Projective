# Roadmap

## IGraphs consolidation (decision 22)

| IGraphs file | counterpart | verdict | members ported | action |
|---|---|---|---|---|
| _std/IGraphs/Interfaces/Vectors/Point2D.T.cs | typed/Point2D.T.cs | older-subset | 0 | IGraphs file deleted, ReplacedBy removed |
| _std/IGraphs/Interfaces/Vectors/Point2Dbl.cs | typed/Point2Dbl.cs | older-subset (only explicit-interface names differ, ILocation2D/ILocation1D vs IVector2D) | 0 | IGraphs file deleted, 33 ReplacedBy removed |
| _std/IGraphs/Interfaces/Vectors/Point3D.T.cs | typed/Point3D.T.cs | older-subset (IGraphs only has a NotImplemented IsZero() stub) | 0 | IGraphs file deleted, 10 ReplacedBy removed |
| _std/IGraphs/Interfaces/Vectors/Point3Dbl.T.cs | typed/Point3Dbl.T.cs | identical (code-wise) | 0 | IGraphs file deleted, ReplacedBy removed |
| _std/IGraphs/Interfaces/Vectors/Point4D.T.cs | typed/Point4D.T.cs | older-subset (heuristic "richer" was a field/type-parameter rename Vector/V, V/T only) | 0 | IGraphs file deleted, 5 ReplacedBy removed |
| _std/IGraphs/Interfaces/Vectors/Point4Dbl.T.cs | typed/Point4Dbl.T.cs | identical (code-wise) | 0 | IGraphs file deleted, ReplacedBy removed |
| _std/IGraphs/Interfaces/Vectors/Segment2D.cs | typed/Segment2D.cs | identical (code-wise) | 0 | IGraphs file deleted, ReplacedBy removed |
| _std/IGraphs/Interfaces/Vectors/Segment3D.cs | typed/Segment3D.cs | identical (code-wise) | 0 | IGraphs file deleted, ReplacedBy removed |

Note: all eight counterparts live in `typed/` (excluded from compilation until 2026-10-07, compiled now). The Point2Dbl overlap with the
XVector2.Times (CS0121) is resolved, see "Consolidation 2026-10-07". Deleted IGraphs files are the provenance targets of the
removed `[ReplacedBy]` attributes; they remain in the IGraphs git history. No `.vrn` sidecars existed.

## Moved in from NET/_std/IGraphs (decision 22, 2026-10-06)

| Source | Now | State | Note |
|---|---|---|---|
| `_std/IGraphs/Interfaces/Converters/PerspectiveTransform.cs` | `typed/PerspectiveTransform.cs` | compiles | 4x4 perspective/homography quad transform (ZXing-style); replaces legacy twin _std/IMathsImpl/Interfaces |
| `_std/IGraphs/Interfaces/Converters/PerspectiveTransformTests.cs` | `typed/PerspectiveTransformTests.cs` | excluded (1 errors, port later) | tests of PerspectiveTransform; replaces legacy twin _std/IMathsImpl/Interfaces |

## Consolidation 2026-10-07

| Pair | Kept | Removed | Ported | Reason |
|---|---|---|---|---|
| typed/Point2Dbl.cs `XPoint2Dbl` vs typed/Point2D.T.cs `XPoint2DList` | `XPoint2DList` | `XPoint2Dbl.TestBruteForceAgainstRecursion`, `ClosestPair`, `ClosestRecursively`, `ClosestBruteForce`, `Closest` (line-for-line copies; only the "(double)" trace text and the `this` on `Closest` differed) | `this` on `XPoint2DList.Closest(List<Point2D<T>>)` | duplicate code |
| `XPoint2Dbl.Times(Complex, Vector2)` -> Size2Dbl vs `XVector2.Times(Complex, Vector2)` -> Vector2 (CS0121 in Shape2D) | `XVector2` (single precision, used by `Shape2D.ApplyTo`) and `XSize2Dbl.Times` (double precision, reached through the implicit Vector2 -> Size2Dbl conversion) | both `XPoint2Dbl.Times` overloads | `XVector2.Times(Vector2, Complex)` (was only in `XPoint2Dbl`) | the removed pair computed the same formulas as `XSize2Dbl.Times`; the left-hand overload clashed with `XVector2` |
| `XPoint2Dbl.IsCloseTo(Point2Dbl, Point2Dbl)` | kept | - | - | unique (uses the static `Accuracy`) |
| `Point2D<T>`, `Point3D<T>`, `Point4D<T>`, `Point3Dbl<T>`, `Point4Dbl<T>`, `Segment2D<T>`, `Segment3D<T>`, `Point2Dbl`, `Size2Dbl`, `Rect2Dbl` | all kept | - | - | no other copy exists in a compiled assembly (IGraphs twins were deleted earlier); the `Compile Remove` lines are gone, the typed/ files now compile on net48 and net10.0 |
| typed/Point2D.cs (PGA homogeneous point, `maths.pga.typed`) vs SpocWeb.Basics `Interfaces/maths/Vectors/Point2D.cs` (`interfaces.Vectors`) | both | - | - | genuinely different: Basics is a float point with `Size2D`/`Rect2D`/`GetIntersect`; typed is a double PGA point with `Vector2D`/`BiVector3D` wedge operators and 3D/4D views; only the name coincides |

Fixes needed to compile typed/ on net48 (TreatWarningsAsErrors): explicit tolerances replace the obsolete `IsCloseToOrNaN`/`ShouldBeApprox` overloads (`Comparers.RelAccuracy`, `XDouble.ACCURACY`, same values as before), `Point2D<T>.Equals(IPoint2D<T>?)` nullability, `Segment2D<T>.CompareTo(null)` returns 1 instead of dereferencing null.

`Point2D<T>` now compiles here on net48 and net10.0. `_std/IMathsImpl` (`MathsImpl.csproj`, net48;net10.0) could reference `SpocWeb.Projective` (no cycle: Projective references only IMaths, Url, Interfaces) to re-enable GeoHash/Olc (`Point2D<Geo>`, `Segment2D`, `Vector2D<T>`); not done here.