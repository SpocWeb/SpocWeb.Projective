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

Note: all eight counterparts live in `typed/` and are excluded from compilation (see csproj). The Point2Dbl overlap with the
compiled XPoint2Dbl members (CS0121) is recorded, not resolved here. Deleted IGraphs files are the provenance targets of the
removed `[ReplacedBy]` attributes; they remain in the IGraphs git history. No `.vrn` sidecars existed.
