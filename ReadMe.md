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
      mtime: "2026-07-07T17:54:19Z"
      digest: "b894a9103cf6ec9bb71802de5c4534a4329b3dca30a68a23d06822cfba2d3b9e"
    AGeoGebraDbl:
      mtime: "2026-07-07T17:54:44Z"
      digest: "9df6a09523671483460f3f629527911117a4b1df4c42e2bc9f6f680f9b00db77"
    IGeoGebra:
      mtime: "2026-07-07T17:54:19Z"
      digest: "e80d05b24a30601df8838834480ad82cecee355df579fc6f1808108b33479dd6"
    PGA3D:
      mtime: "2026-07-07T17:54:19Z"
      digest: "7b23aa487c2c2d59d036d3896573500236f80fbc91ec15e65d96912528f404a5"
    Program:
      mtime: "2026-07-07T17:48:55Z"
      digest: "f234e40f5e704a92b71f3319f42ca08c1a7ac00a71e7e907857ef0cd7107df26"
    XGeoGebra:
      mtime: "2026-07-07T17:54:19Z"
      digest: "c3d57ec6c170096dcf07a1d24e70fe9d7c119b6675407199c0a0900c7dbf102f"
    xPermute:
      mtime: "2026-07-07T17:48:55Z"
      digest: "14c0750e0efe0945d41e8f6c9d8235462381d9207aeda34d5901191b9fa91edb"
    XPGA3D:
      mtime: "2026-07-07T17:54:19Z"
      digest: "edca1df48022bd017d1f37dcc79ccb3ec13bf181a44868bb1de9c39c036406f9"
  folders: {}
related:
  - path: ../_Matthias/Code/NET/_std/pga/ga
    shared-tags: [code/geometric_algebra]
  - path: ../_Matthias/Code/NET/_std/pga/pga
    shared-tags: [code/geometric_algebra]
  - path: ../_Matthias/Code/NET/_std/pga/typed
    shared-tags: [code/geometric_algebra]
dv_has_:
  sub_:
    folders: 3
    files: 138
    units: 112
    facet_:
      layer_:
        domain: 105
        test: 6
        scaffold: 1
      status_:
        stable: 101
        buggy: 5
        partial: 5
        stub: 1
      complexity_:
        "1": 41
        "2": 44
        "3": 24
        "4": 3
    tag_:
      code_:
        projective_geometric_algebra: 39
        clifford_algebra: 30
        rigid_body_physics: 12
        conformal_geometric_algebra: 11
        geometric_algebra: 8
        polar_coordinates: 3
        vector_math: 7
        computational_geometry: 4
        mass_distribution: 2
        typed_wrapper: 2
    concept_:
      "Mathematics\\Geometry\\Geometric_Algebra.md": 87
      physics_simulation: 10
      "Mathematics\\Geometry\\Vector.md": 11
      geometric_algebra_spaces: 1
      pga_motors_:
        reflectors: 1
      typed_geometric_primitives: 1
      "Mathematics\\Statistics\\Combinatorics.md": 1
has_sub_folders: 3
has_sub_files: 138
has_sub_units: 112
has_sub_facet_layer_domain: 105
has_sub_facet_layer_test: 6
has_sub_facet_layer_scaffold: 1
has_sub_facet_status_stable: 101
has_sub_facet_status_buggy: 5
has_sub_facet_status_partial: 5
has_sub_facet_status_stub: 1
has_sub_facet_complexity_1: 41
has_sub_facet_complexity_2: 44
has_sub_facet_complexity_3: 24
has_sub_facet_complexity_4: 3
has_sub_tag_code_projective_geometric_algebra: 39
has_sub_tag_code_clifford_algebra: 30
has_sub_tag_code_rigid_body_physics: 12
has_sub_tag_code_conformal_geometric_algebra: 11
has_sub_tag_code_geometric_algebra: 8
has_sub_tag_code_polar_coordinates: 3
has_sub_tag_code_vector_math: 7
has_sub_tag_code_computational_geometry: 4
has_sub_tag_code_mass_distribution: 2
has_sub_tag_code_typed_wrapper: 2
has_sub_concept_mathematics_geometry_geometric_algebra_md: 87
has_sub_concept_physics_simulation: 10
has_sub_concept_mathematics_geometry_vector_md: 11
has_sub_concept_geometric_algebra_spaces: 1
has_sub_concept_pga_motors_reflectors: 1
has_sub_concept_typed_geometric_primitives: 1
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

| Class | Responsibility |
|---|---|
| [XGeoGebra](AGeoGebra.cs) | Extension Methods and Tests for IGeoGebra and PGA Classes |
| [AGeoGebra](AGeoGebra.cs) | Abstract Base Class for Multi-Vector-Spaces |
| [AGeoGebraDbl](AGeoGebraDbl.cs) | Abstract Base Class for Multi-Vector-Spaces |
| [IGeoGebra](IGeoGebra.cs) | GA define several Products that transform its 2^n Dimensions into each other, described by Cayley Tables. |
| [XGeoGebra](IGeoGebra.cs) | Extension Methods for IGeoGebra. |
| [XPGA3D](pga3d.cs) | Static extension and utility methods for the PGA3D G(3,0,1) multivector type. |
| [PGA3D](pga3d.cs) | Pga3D Projective Geometric Algebra in 3D, also known as 3D PGA,  extends geometric algebra to include projective geometry. |
| [Program](Program.cs) | Entry point for the PGA demo/test runner. |
| [xPermute](xPermute.cs) | Extension methods for generating all permutations of a list in-place via Heap's algorithm, yielding each permutation together with its parity sign. |
