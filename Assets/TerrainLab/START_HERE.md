# Terrain Lab — student exercise

1. [Download the student package](https://github.com/Omar-Makhlouf/Unity-Authorized-Educator-Program-Session-2026/raw/refs/heads/main/Downloads/TerrainLab-Students.unitypackage) and create an empty **Universal 3D (URP)** project in Unity **6000.3.24f1**. No repository clone or ZIP is needed.
2. Choose **Assets > Import Package > Custom Package**, select **TerrainLab-Students.unitypackage**, and import everything.
3. Open **Assets/Scenes/TerrainClassroom.unity**. This scene starts with a sun and player capsule; students create the terrain during the lesson.
4. For the finished reference, open **Assets/Scenes/TerrainFinalized.unity**.

## Requirements

Use the Universal 3D template with **Universal RP** and **Input System** installed. This workshop was made with URP 17.3.0 and Input System 1.20.0. If Input System is missing, install it from **Window > Package Management > Package Manager > Unity Registry**. If Unity asks to enable the new input backends, accept and restart. Alternatively set **Edit > Project Settings > Player > Active Input Handling** to **Input System Package (New)** or **Both**, then restart when prompted.

The package contains workshop assets, not Unity registry packages or project settings. Your Universal 3D template supplies the render pipeline. No Git, Git LFS, or AI tools are needed by students.

## Start the ground

With Play stopped, create **GameObject > 3D Object > Terrain**. In Terrain Settings set Width/Length **200**, Terrain Height **80**, and Heightmap Resolution **513 × 513**. In Paint Terrain > Set Height, try **20 > Flatten All**, then reset the ground with **12 > Flatten All**. Reset the Terrain Transform to Position **(0, 0, 0)**, Rotation **(0, 0, 0)**, Scale **(1, 1, 1)**.

The player starts at **(100, 12.12, 65)**. Create ground before pressing Play. Flatten All erases sculpting, so use it only before making hills, never on the finished example.

Add Grass/Dirt/Sand from **Assets/TerrainClassroom/Layers**, Rock from **Assets/TerrainFinalized/Layers**, and the tree prototype **Assets/TerrainFinalized/Vegetation/ClassroomOak.prefab**.

## Build your landscape

1. Use **Raise or Lower Terrain** to sculpt a C-shaped mountain border. Leave an entrance and keep the player spawn clear. Use **Smooth Height** for gentle slopes.
2. In **Paint Texture > Edit Terrain Layers > Add Layer**, add Grass first, then the other supplied layers. Paint a dirt path and rocky slopes.
3. In **Paint Trees > Edit Trees > Add Tree**, register the oak prefab. Paint two small groups beside the path; use **Shift + brush** to erase a patch.
4. Press Play, walk your route, and find one thing to improve. Stop Play before making changes.

**Pond challenge:** create a pond with level water, banks above it, and a route the player can walk back out of. Use the finished scene as a reference and work out your own approach.

**Controls:** WASD/arrows walk, mouse look, Shift sprint, Space jump, Escape release cursor, click resume, R respawn.

Save the scene and use **File > Save Project** for terrain edits.

## Credits

Terrain textures are Poly Haven CC0 assets: Leafy Grass, Brown Mud 02, Rock Boulder Dry, and Sand 01.
https://polyhaven.com/a/leafy_grass
https://polyhaven.com/a/brown_mud_02
https://polyhaven.com/a/rock_boulder_dry
https://polyhaven.com/a/sand_01
https://polyhaven.com/license

The player, oak, and bench were created for this workshop.
