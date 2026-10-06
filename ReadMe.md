---
facet-complexity: 2
facet-status: stable
facet-layer: domain
concepts:
  - projective_geometric_algebra
tags:
  - code/geometric_algebra
description: "A C# library implementing Projective Geometric Algebra (PGA) for 2D and 3D rigid-body simulation, coordinate transformations, and geometric computation. PGA unifies points, lines, planes, motors (screw motions), and reflections in a single algebraic framework, eliminating the gimbal lock and singularities of Euler angles while delivering hardware-accelerated, allocation-free arithmetic on .NET SIMD types."
digest:
  local-classes:
    AGeoGebra:
      mtime: "2026-10-06T11:08:59Z"
      digest: "0fc01dbe2d6a5f92b60c3e52510653481520b89ed866849458805648de02cd17"
    AGeoGebraDbl:
      mtime: "2026-10-06T11:09:00Z"
      digest: "ab5618df5e998d1dffbb622be76a34df2c98f1359e049fcc2f1f08d1868318e6"
    IGeoGebra:
      mtime: "2026-10-06T11:09:00Z"
      digest: "a4d2b57bd6374d82cb5e033479bf99dc7f43745bef0b823755da917c35cd90a7"
    PGA3D:
      mtime: "2026-10-06T11:08:53Z"
      digest: "6d60f7c980c4240cabf7e6b6dd02f664f7f8b1649bc85b56d382a4fb89920faf"
    PgaAssert:
      mtime: "2026-10-06T11:08:53Z"
      digest: "9c5947d037dd231cae90a225bb186c60f38637996cc3dd1ac6e9345acb4763f6"
    PgaTolerance:
      mtime: "2026-10-06T11:08:47Z"
      digest: "a00acfe9dcd8084f66c8b2655c64aa4f4d760f094d79a8a8c5daa9590a5b23b3"
    Program:
      mtime: "2026-07-07T17:48:55Z"
      digest: "f234e40f5e704a92b71f3319f42ca08c1a7ac00a71e7e907857ef0cd7107df26"
    XGeoGebra:
      mtime: "2026-10-06T11:08:59Z"
      digest: "f156f02232b25b54fe9bafeb7b1ae7db681ff0ce7d94436796a6b8e421f0c728"
    xPermute:
      mtime: "2026-07-07T17:48:55Z"
      digest: "14c0750e0efe0945d41e8f6c9d8235462381d9207aeda34d5901191b9fa91edb"
    XPGA3D:
      mtime: "2026-10-06T11:08:53Z"
      digest: "9c04d76f03537170aab4c1ae4c444e6556113ee3c59e3c26518026f411c7fde1"
  folders: {}
related:
  - path: ../_Matthias/Code/NET/_SpocWeb.Root/_std/SpocWeb.Projective/ga
    shared-tags: [code/geometric_algebra]
  - path: ../_Matthias/Code/NET/_SpocWeb.Root/_std/SpocWeb.Projective/pga
    shared-tags: [code/geometric_algebra]
  - path: ../_Matthias/Code/NET/_SpocWeb.Root/_std/SpocWeb.Projective/typed
    shared-tags: [code/geometric_algebra]
dv_has_:
  sub_:
    folders: 3
    files: 144
    units: 113
    facet_:
      layer_:
        domain: 103
        test: 6
        presentation: 2
        foundation: 1
        scaffold: 1
      status_:
        stable: 102
        buggy: 5
        partial: 5
        stub: 1
      complexity_:
        "1": 44
        "2": 43
        "3": 23
        "4": 3
    tag_:
      code_:
        projective_geometric_algebra: 39
        clifford_algebra: 30
        rigid_body_physics: 12
        conformal_geometric_algebra: 11
        geometric_algebra: 5
        vector_math: 7
        polar_coordinates: 3
        computational_geometry: 4
        factory: 5
        mass_distribution: 2
    concept_:
      "Mathematics\\Geometry\\Geometric_Algebra.md": 87
      physics_simulation: 10
      "Mathematics\\Geometry\\Vector.md": 11
      projective_geometric_algebra: 2
      float_tolerance_comparison: 1
      multivector_components: 1
      numerical_tolerance: 1
      reproducible_test_seed: 1
      "Mathematics\\Statistics\\Combinatorics.md": 1
has_sub_folders: 3
has_sub_files: 144
has_sub_units: 113
has_sub_facet_layer_domain: 103
has_sub_facet_layer_test: 6
has_sub_facet_layer_presentation: 2
has_sub_facet_layer_foundation: 1
has_sub_facet_layer_scaffold: 1
has_sub_facet_status_stable: 102
has_sub_facet_status_buggy: 5
has_sub_facet_status_partial: 5
has_sub_facet_status_stub: 1
has_sub_facet_complexity_1: 44
has_sub_facet_complexity_2: 43
has_sub_facet_complexity_3: 23
has_sub_facet_complexity_4: 3
has_sub_tag_code_projective_geometric_algebra: 39
has_sub_tag_code_clifford_algebra: 30
has_sub_tag_code_rigid_body_physics: 12
has_sub_tag_code_conformal_geometric_algebra: 11
has_sub_tag_code_geometric_algebra: 5
has_sub_tag_code_vector_math: 7
has_sub_tag_code_polar_coordinates: 3
has_sub_tag_code_computational_geometry: 4
has_sub_tag_code_factory: 5
has_sub_tag_code_mass_distribution: 2
has_sub_concept_mathematics_geometry_geometric_algebra_md: 87
has_sub_concept_physics_simulation: 10
has_sub_concept_mathematics_geometry_vector_md: 11
has_sub_concept_projective_geometric_algebra: 2
has_sub_concept_float_tolerance_comparison: 1
has_sub_concept_multivector_components: 1
has_sub_concept_numerical_tolerance: 1
has_sub_concept_reproducible_test_seed: 1
has_sub_concept_mathematics_statistics_combinatorics_md: 1
---
# maths.pga

A C# library implementing Projective Geometric Algebra (PGA) for 2D and 3D rigid-body
simulation, coordinate transformations, and geometric computation.
PGA unifies points, lines, planes, motors (screw motions), and reflections in a single
algebraic framework, eliminating the gimbal lock and singularities of Euler angles
while delivering hardware-accelerated, allocation-free arithmetic on .NET SIMD types.

## Quick Start

| Step | Command |
|---|---|
| Build | `dotnet build maths.pga.csproj` |
| Test | `dotnet test` |
| Run | `dotnet run` |

## Dependencies

### Project References

- [SpocWeb.IMaths](../SpocWeb.IMaths/ReadMe.md)
- [SpocWeb.interfaces](../SpocWeb.interfaces/ReadMe.md)

### NuGet Packages

- `NUnit`

## Architecture

```mermaid
flowchart TD
  subgraph maths.pga
    typed["typed/ — SIMD-backed geometric primitives"]
    pga["pga/ — motors & reflectors (PGA products)"]
    ga["ga/ — algebra spaces & rigid-body dynamics"]

    typed -->|consumed by| pga
    linkStyle 0 opacity:1

    typed -->|consumed by| ga
    linkStyle 1 opacity:1

    pga -->|sandwich product applied to| ga
    linkStyle 2 opacity:1
  end
```

## Subsystems

| Folder | Domain Role |
|---|---|
| [`ga/`](ga/ReadMe.md) | Concrete implementations of low-dimensional Geometric Algebra spaces (R0,0,1 through R4,1,0) together with rigid-body dynamics and geometric shape representations. |
| [`pga/`](pga/ReadMe.md) | Optimised structs and extension methods implementing 2D and 3D Projective Geometric Algebra (PGA) motors, reflectors, and their products. |
| [`typed/`](typed/ReadMe.md) | Strongly-typed, hardware-accelerated geometric primitives for 2D and 3D Projective Geometric Algebra (PGA). |

## Key Concepts

| Term | Definition |
|---|---|
| Multi-vector | An element of a geometric algebra combining scalar, vector, bivector, … and pseudoscalar grades. |
| Motor | Even-grade multi-vector encoding a rigid-body screw motion (rotation + translation); stored as `Motor3P` / `Motor2P`. |
| Reflector | Odd-grade multi-vector encoding reflections in planes and points; stored as `Reflector3P` / `Reflector2P`. |
| Sandwich product | `~M * X * M` — applies motor M to geometric object X; coordinate-free and grade-preserving. |
| BiVector | Grade-2 element representing an oriented plane (3D) or line (2D); stored as `BiVector3D` / `BiVector4D`. |
| TriVector | Grade-3 element representing a 3D plane in homogeneous coordinates; stored as `TriVector4D`. |
| Cayley table | Precomputed sign tables encoding the product rules of a specific algebra signature R(p,q,r). |

## Further Reading

| Document | Purpose |
|---|---|
| `typed/README.md` | SIMD-backed primitive types (Vector2D, Point3D, BiVector4D, …). |
| `pga/README.md` | Motor and reflector algebra; sandwich product; geometric products. |
| `ga/README.md` | Algebra space implementations (R001…R410) and rigid-body physics. |

## Classes

| Class | Responsibility | Key Collaborators |
|---|---|---|
| [XGeoGebra](AGeoGebra.cs) | Extension Methods and Tests for IGeoGebra and PGA Classes |  |
| [AGeoGebra](AGeoGebra.cs) | Abstract Base Class for Multi-Vector-Spaces |  |
| [AGeoGebraDbl](AGeoGebraDbl.cs) | Abstract Base Class for Multi-Vector-Spaces |  |
| [IGeoGebra](IGeoGebra.cs) | GA define several Products that transform its 2^n Dimensions into each other, described by Cayley Tables. |  |
| [XPGA3D](pga3d.cs) | Static extension and utility methods for the PGA3D G(3,0,1) multivector type. | `PGA3D` |
| [PGA3D](pga3d.cs) | Pga3D Projective Geometric Algebra in 3D, also known as 3D PGA, extends geometric algebra to include projective geometry. It provides a powerful tool for representing and manipulating geometric objects such as - points, lines, planes, and transformations in three-dimensional space. In 3D PGA, geometric entities are represented as multivectors, which can be combined using various algebraic operations to perform geometric transformations and calculations. This framework is particularly useful in computer graphics, robotics, and physics for modeling and analyzing spatial relationships and transformations. | `PGA3D` |
| [PgaAssert](PgaAssert.cs) | Component-wise Comparison of float Multivectors with an explicit Tolerance. |  |
| [PgaTolerance](PgaTolerance.cs) | Explicit absolute Tolerances for Zero- and Equality-Tests of normalized PGA Components. |  |
| [Program](Program.cs) | Entry point for the PGA demo/test runner. |  |
| [xPermute](xPermute.cs) | Extension methods for generating all permutations of a list in-place via Heap's algorithm, yielding each permutation together with its parity sign. |  |
