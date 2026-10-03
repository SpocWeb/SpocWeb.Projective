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
      mtime: "2026-08-09T13:51:45Z"
      digest: "7d8d59be706a6aa66c8958fe87b3dfbc3e1c05098c03222c134ef291c4e0e89d"
    BiVector4D:
      mtime: "2026-08-09T13:51:45Z"
      digest: "ed0000b54ba502bedc65d5522712f1a5e2523e59c2368659ac5c7bbf29233b2b"
    Point2D:
      mtime: "2026-08-09T13:51:45Z"
      digest: "1829923865bd072fe762298ab3f3163320a5edac2971d514c0a2f7648d0a9eaf"
    Point3D:
      mtime: "2026-08-09T13:51:45Z"
      digest: "056d6422db22c33aed5ed349caa3fc60f3c5edc612f08da2939c75f54d880756"
    TriVector4D:
      mtime: "2026-07-07T17:54:25Z"
      digest: "d35f606502ff3fd5b80173c72ad61b9416e8d3cd04fed390c04286d8e3d0e51b"
    Vector2D:
      mtime: "2026-08-09T13:51:45Z"
      digest: "b9aed8b92012a6eaed128137c1d6a11032d3182a25f10aa8089b22ee3444c079"
    Vector3D:
      mtime: "2026-08-09T13:51:45Z"
      digest: "85988c4fe1b7ee7c8904d2fdbba48ba3823bb919360556cbdc22bc3d50ab0921"
    Vector4D:
      mtime: "2026-07-07T17:54:25Z"
      digest: "85afa6bce2ea414aa2267ffc8e9661e1259e19342c4e46615371804d2bf203ee"
    XBiVector3D:
      mtime: "2026-08-09T13:51:45Z"
      digest: "926e1307e16bff028084bde87c32ed6b996fa0e178f14547b813049091df8346"
    XBiVector4D:
      mtime: "2026-08-09T13:51:45Z"
      digest: "bb130c65ab37711ab1c62db2fa5791601d5cc3ea2ab0c6d48eeaff413eb531f8"
    XVector2:
      mtime: "2026-08-09T13:51:45Z"
      digest: "9b1e17dd8d922bb8cd498f75da9fc1f5ba40d88d35129375aba5cb50b26bfb1a"
  folders: {}
related:
  - path: ../_Matthias/Code/NET/_std/pga
    shared-tags: [code/geometric_algebra]
  - path: ../_Matthias/Code/NET/_std/pga/ga
    shared-tags: [code/geometric_algebra]
  - path: ../_Matthias/Code/NET/_std/pga/pga
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
| [BiVector4D](BiVector4D.cs) | Represents a line in 3D projective space via six Plücker coordinates:  a Direction (vector part) and a Moment (bivector part). |
| [Point2D](Point2D.cs) | Vector2-backed immutable 2D affine point with homogeneous W = 1,  supporting addition/subtraction with Vector2D and wedge products that produce lines. |
| [Point3D](Point3D.cs) | 3D Point accelerated by Vector3 |
| [TriVector4D](TriVector4D.cs) | 4D tri-vector having floating-point components x, y, z, and w. |
| [XVector2](Vector2D.cs) | Provides extension methods for Complex. |
| [Vector2D](Vector2D.cs) | Vector2-backed struct impl. |
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
