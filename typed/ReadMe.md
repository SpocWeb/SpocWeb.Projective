---
facet-complexity: 3
facet-status: stable
facet-layer: domain
concepts:
  - typed_geometric_primitives
tags:
  - code/geometric_algebra
description: "Strongly-typed, hardware-accelerated geometric primitives for 2D and 3D Projective Geometric Algebra (PGA). Each struct wraps a `System.Numerics` SIMD vector (`Vector2`, `Vector3`, or `Vector4`) to deliver cache-friendly, allocation-free arithmetic on the hot paths of simulation and rendering code."
digest:
  local-classes:
    BiVector3D:
      mtime: "2026-10-06T10:57:19Z"
      digest: "d62224abb1fdefbf87d269e67b2f2bd638d1da4c4a64ee9862b33335b05cb847"
    BiVector4D:
      mtime: "2026-10-06T11:08:57Z"
      digest: "4978d999b4b3565a5438537eb827da872f660631229a6a947112b63cb9420a40"
    Point2D:
      mtime: "2026-10-06T11:08:58Z"
      digest: "45dfe294652032a800df2d168f03696930a308929023ab7840b7fe2600cd2cc3"
    Point3D:
      mtime: "2026-10-06T11:08:58Z"
      digest: "c67006e522c51fe4e192ebb384ff0ccbb3bd097f6ab08a0b6913bdcd1ff768a6"
    TriVector4D:
      mtime: "2026-10-06T10:57:20Z"
      digest: "83369c305b449318903d911cf21a38ebe40afebff113f3d007cdeda63275bf46"
    Vector2D:
      mtime: "2026-10-06T11:08:58Z"
      digest: "0da81f3edacab246e9009bcd38de6c530ff9bffb5d8386fc5870b29e3bc9f5bb"
    Vector3D:
      mtime: "2026-10-06T11:08:58Z"
      digest: "1f6e3ce7b150be66688fb0d0e14ea43dbb05aee539ba41baf5e90f3f1b8c7192"
    Vector4D:
      mtime: "2026-10-06T10:57:22Z"
      digest: "8dac1d0ea6917dd16c9e77a09b23116ea052517968eb65257fb6b56760d49945"
    XBiVector3D:
      mtime: "2026-08-09T13:51:45Z"
      digest: "926e1307e16bff028084bde87c32ed6b996fa0e178f14547b813049091df8346"
    XBiVector4D:
      mtime: "2026-10-06T11:08:57Z"
      digest: "8431e0f46cb89ce6da929586f5f67cdf43f49a973307705fdbbd137c8ce272e9"
    XVector2:
      mtime: "2026-08-09T13:51:45Z"
      digest: "9b1e17dd8d922bb8cd498f75da9fc1f5ba40d88d35129375aba5cb50b26bfb1a"
  folders: {}
related:
  - path: ../_Matthias/Code/NET/_SpocWeb.Root/_std/SpocWeb.Projective
    shared-tags: [code/geometric_algebra]
  - path: ../_Matthias/Code/NET/_SpocWeb.Root/_std/SpocWeb.Projective/ga
    shared-tags: [code/geometric_algebra]
  - path: ../_Matthias/Code/NET/_SpocWeb.Root/_std/SpocWeb.Projective/pga
    shared-tags: [code/geometric_algebra]
dv_has_:
  sub_:
    folders: 0
    files: 16
    units: 11
    facet_:
      layer_:
        domain: 11
      status_:
        stable: 8
        buggy: 3
      complexity_:
        "2": 3
        "3": 8
    tag_:
      code_:
        vector_math: 6
        value_object: 8
        plucker_coordinates: 1
        affine_geometry: 1
        simd: 1
        homogeneous_coordinates: 1
        complex_math: 1
        factory: 1
        extension_method: 2
    concept_:
      "Mathematics\\Geometry\\Vector.md": 11
has_sub_folders: 0
has_sub_files: 16
has_sub_units: 11
has_sub_facet_layer_domain: 11
has_sub_facet_status_stable: 8
has_sub_facet_status_buggy: 3
has_sub_facet_complexity_2: 3
has_sub_facet_complexity_3: 8
has_sub_tag_code_vector_math: 6
has_sub_tag_code_value_object: 8
has_sub_tag_code_plucker_coordinates: 1
has_sub_tag_code_affine_geometry: 1
has_sub_tag_code_simd: 1
has_sub_tag_code_homogeneous_coordinates: 1
has_sub_tag_code_complex_math: 1
has_sub_tag_code_factory: 1
has_sub_tag_code_extension_method: 2
has_sub_concept_mathematics_geometry_vector_md: 11
---
# typed

Strongly-typed, hardware-accelerated geometric primitives for 2D and 3D Projective
Geometric Algebra (PGA).
Each struct wraps a `System.Numerics` SIMD vector (`Vector2`, `Vector3`, or `Vector4`)
to deliver cache-friendly, allocation-free arithmetic on the hot paths of simulation
and rendering code.

The types distinguish *directions* (zero W component, can be added/scaled) from
*points* (W = 1, affine position), and *bivectors* (oriented planes or lines) from
plain vectors, encoding the PGA grade structure directly in the C# type system.

## Classes

| Class | Responsibility |
|---|---|
| [BiVector3D](BiVector3D.cs) | three floating-point components named x, y, and z of the Cross-Product |
| [XBiVector3D](BiVector3D.cs) | Extension methods for BiVector3D and related vector types. |
| [XBiVector4D](BiVector4D.cs) | Static factory methods constructing BiVector4D lines via wedge products of homogeneous 3D points and direction vectors. |
| [BiVector4D](BiVector4D.cs) | Represents a line in 3D projective space via six Plücker coordinates: a Direction (vector part) and a Moment (bivector part). |
| [Point2D](Point2D.cs) | Vector2-backed immutable 2D affine point with homogeneous W = 1, supporting addition/subtraction with Vector2D and wedge products that produce lines. |
| [Point3D](Point3D.cs) | 3D Point accelerated by Vector3 |
| [TriVector4D](TriVector4D.cs) | 4D tri-vector having floating-point components x, y, z, and w. |
| [XVector2](Vector2D.cs) | Provides extension methods for Complex. |
| [Vector2D](Vector2D.cs) | Vector2-backed struct impl. up to IVector4D |
| [Vector3D](Vector3D.cs) | Vector3-backed immutable 3D direction vector that implements IVector4D with W = 0, supporting rotations, projection, rejection, and standard arithmetic. |
| [Vector4D](Vector4D.cs) | single-precision Point-/Place-Vector in 3D, used for (Position-)Vectors in homogeneous Coordinates |

## Relationships

```mermaid
flowchart TD
    V2D[Vector2D]
    V3D[Vector3D]
    V4D[Vector4D]
    P2D[Point2D]
    P3D[Point3D]
    BV3D[BiVector3D]
    BV4D[BiVector4D]
    TV4D[TriVector4D]

    V2D -->|wedge| BV3D
    linkStyle 0 opacity:1

    P2D -->|wedge| BV3D
    linkStyle 1 opacity:1

    V3D -->|wedge| BV3D
    linkStyle 2 opacity:1

    P3D -->|wedge| BV4D
    linkStyle 3 opacity:1

    V3D -->|wedge| BV4D
    linkStyle 4 opacity:1

    BV4D -->|wedge| TV4D
    linkStyle 5 opacity:1

    TV4D -->|anti-wedge| BV4D
    linkStyle 6 opacity:1

    BV4D -->|anti-wedge| V4D
    linkStyle 7 opacity:1
```

## Entry Points

| Method | Description |
|---|---|
| `Point2D ^ Point2D` | Wedge product giving the 2D line through two points. |
| `Point3D ^ Point3D` | Wedge product giving the 3D line through two points. |
| `BiVector4D.Project(Point3D, BiVector4D)` | Projects a point onto a unitized line. |
| `TriVector4D.Unitize()` | Normalises a plane to unit weight. |
| `Vector2D.CosSin(float)` | Creates a unit direction from an angle in radians. |
