---
facet-complexity: 2
facet-status: stable
facet-layer: presentation
concepts:
  - projective_geometric_algebra
tags:
  - code/wpf_application
description: "WPF application stub for Projective Geometric Algebra (PGA) visualization. Currently contains the application entry point and main window shell only; PGA rendering logic is not yet implemented."
digest:
  local-classes:
    App:
      mtime: "2026-05-29T04:42:45Z"
      digest: "e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855"
    MainWindow:
      mtime: "2026-06-14T07:04:41Z"
      digest: "068bb55f06d5a2b719500a378ba08755b2d2bbdbe62c7bddcbecbeba3456c437"
  folders: {}
related:
  - path: ../_Matthias/Code/NET/Parkettierung
    shared-tags: [code/wpf_application]
  - path: ../_Matthias/Code/NET/_core/Maths.Wpf
    shared-tags: [code/wpf_application]
  - path: ../_Matthias/Code/NET/_core/Maths.Wpf3D
    shared-tags: [code/wpf_application]
  - path: ../_Matthias/Code/NET/KnowledgeWeb
    shared-tags: [code/wpf_application]
---
# PgaGui

WPF application stub for Projective Geometric Algebra (PGA) visualization.
Currently contains the application entry point and main window shell only;
PGA rendering logic is not yet implemented.

## Architecture

```mermaid
flowchart TD
    subgraph PgaGui
        MW["MainWindow\nshell — PGA rendering not yet implemented"]
    end
```

## Classes

| Class | Responsibility |
|---|---|
| [App](App.xaml.cs) | Interaction logic for App. |
| [MainWindow](MainWindow.xaml.cs) | Interaction logic for MainWindow. |
