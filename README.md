<div align="center">

# 🌿 Terrain Lab

### Sculpt a landscape. Paint a world. Step inside it.

A hands-on Unity terrain workshop for the **Unity Authorized Educator Program · 2026**.

![Unity](https://img.shields.io/badge/Unity-6000.3.24f1-111827?logo=unity&logoColor=white)
![Rendering](https://img.shields.io/badge/Rendering-URP-3b82f6)
![Lesson](https://img.shields.io/badge/Lesson-30_minutes-22c55e)
![Level](https://img.shields.io/badge/Level-Beginner-f59e0b)

[**Start the workshop**](#-get-started) · [**Teacher script**](Docs/TerrainClassroom.md) · [**Explore the scenes**](#-two-scenes-one-learning-journey)

![Finished terrain with C-shaped mountains, a pond loop, trees, and a walking path](Docs/Images/terrain-overview.png)

*From a blank terrain to a landscape you can explore.*

</div>

## 🏞️ Two scenes, one learning journey

| Start with a blank canvas | Explore the finished example |
| --- | --- |
| **TerrainClassroom** | **TerrainFinalized** |
| Flat, 200 × 200 metre terrain with surface layers, a tree palette, and a playable capsule. | C-shaped mountains, rocky slopes, painted trees, a pond, a reusable bench, and walkable paths. |
| Build your own landscape with Unity's Terrain tools. | Inspect how the pieces fit together, then explore from eye level. |
| [Open scene](Assets/Scenes/TerrainClassroom.unity) | [Open scene](Assets/Scenes/TerrainFinalized.unity) |

Both scenes have independent terrain data and the same first-person player prefab.

## ✨ What you'll build and learn

- **Shape the land** — raise hills, lower valleys, and smooth a C-shaped mountain border.
- **Paint the surface** — blend grass, dirt, sand, and rock using photographic textures and normal maps.
- **Grow a landscape** — paint and erase trees using a registered oak prefab and Terrain tree instances.
- **Understand a pond** — use a flat water plane above a lowered terrain basin, with a gentle exit ramp.
- **Reuse a prop** — inspect and place a wooden bench prefab.
- **Test at eye level** — walk, sprint, jump, and check whether your landscape feels accessible.

The finished example includes **38 painted oaks**, a clear approach path, and a walking loop around the pond. The shared tree prefab has three mesh LODs to reduce geometry at a distance.

## 🚀 Get started

### 1. Clone with Git LFS

Install [Git LFS](https://git-lfs.com/) before cloning so the photographic textures download correctly.

```bash
git lfs install
git clone https://github.com/Omar-Makhlouf/Unity-Authorized-Educator-Program-Session-2026.git
cd Unity-Authorized-Educator-Program-Session-2026
git lfs pull
```

### 2. Open in Unity Hub

1. Install **Unity 6000.3.24f1** through Unity Hub.
2. Add the cloned project folder and open it.
3. Allow Unity to import assets and resolve the packages in the project manifest.

### 3. Pick a scene and press Play

- **For the lesson:** open `Assets/Scenes/TerrainClassroom.unity`.
- **For a tour:** open `Assets/Scenes/TerrainFinalized.unity`.
- Press **Play**, then click inside the **Game view** to capture the mouse.

The finished example is the first enabled scene in Build Settings, followed by the starter scene.

## 🎮 Explore with keyboard and mouse

![First-person view along the path toward the pond, bench, and mountains](Docs/Images/first-person-view.png)

| Input | Action |
| --- | --- |
| **W A S D** / **Arrow keys** | Walk and strafe |
| **Mouse** | Look around |
| **Left Shift** | Sprint |
| **Space** | Jump |
| **Escape** | Release the cursor and suspend movement/look |
| **Left-click Game view** | Capture the mouse again |
| **R** | Return to spawn |

**Edit in the Scene view with Play stopped. Explore in the Game view with Play running.** If you sculpt over the spawn area, move **Classroom Player** above the new ground before testing again.

## 👩‍🏫 A ready-to-teach, 30-minute workshop

The [**complete teacher script**](Docs/TerrainClassroom.md) includes spoken prompts, demonstrations, student exercises, checkpoints, troubleshooting, and exit questions.

| Time | Activity |
| --- | --- |
| 00:00–03:00 | Tour the finished environment |
| 03:00–06:00 | Find the tools and learn the editing workflow |
| 06:00–11:00 | Sculpt a mountain border |
| 11:00–15:00 | Paint grass, a path, and rocky slopes |
| 15:00–19:00 | Paint and erase trees |
| 19:00–23:00 | Demonstrate the pond and bench prefab |
| 23:00–28:00 | Walk through the landscape and improve one thing |
| 28:00–30:00 | Review, save, and answer exit questions |

Give each student a **separate project copy**. Duplicating a scene alone still shares its TerrainData; for independent work in one project, duplicate the TerrainData and assign it to both the Terrain and TerrainCollider.

<details>
<summary><strong>See the starting canvas</strong></summary>

![Flat starter terrain ready for student sculpting and painting](Docs/Images/starter-terrain.png)

The starter keeps the surface clear for student practice. Its tree palette is configured, but no trees are painted initially.

</details>

## 🧭 Find your way around the project

| Location | Contents |
| --- | --- |
| `Assets/Scenes/` | Starter and finished teaching scenes |
| `Assets/Player/` | Shared capsule player prefab and material |
| `Assets/Scripts/ClassroomFirstPersonController.cs` | Input, movement, gravity, mouse look, and respawn |
| `Assets/TerrainClassroom/` | Starter terrain data and surface layers |
| `Assets/TerrainFinalized/` | Finished terrain, materials, textures, and props |
| `Assets/TerrainFinalized/Vegetation/` | Paintable oak prefab and three mesh LODs |
| `Assets/TerrainFinalized/Prefabs/ParkBench.prefab` | Reusable bench |
| `Docs/TerrainClassroom.md` | Full teacher script and classroom reference |

### A few useful teaching details

- Painted trees live in **TerrainData**, rather than appearing as individual Hierarchy objects.
- The pond is a **heightmap depression**, with ground at the bottom. It does not use the Terrain Paint Holes tool.
- Water is a simple visual plane; there is no swimming system. Walk out using the east-side ramp or press **R**.
- The oak uses mesh LODs of **12,204 → 4,532 → 1,840 triangles**. It has a trunk collider, without wind animation or a distant billboard.
- The player uses the project's **Input System** actions and a **CharacterController**.

## ✅ Validation

Both scenes were checked in Unity for walking, sprinting, jumping, mouse look, cursor release, and respawning. A capsule collision probe traversed the finished entrance, complete pond loop, and east basin exit without jumping. Saved scene, texture, prefab, and tree LOD references were also checked.

These are Editor and focused Play mode checks. A standalone build and a classroom hardware performance benchmark have not been run.

## 📸 Texture credits

Photographic terrain textures come from [Poly Haven](https://polyhaven.com/) under its [CC0 asset license](https://polyhaven.com/license):

[Leafy Grass](https://polyhaven.com/a/leafy_grass) · [Brown Mud 02](https://polyhaven.com/a/brown_mud_02) · [Rock Boulder Dry](https://polyhaven.com/a/rock_boulder_dry) · [Sand 01](https://polyhaven.com/a/sand_01)

The tree and bench were created locally for this workshop. The CC0 statement above applies to the credited Poly Haven assets.

---

<div align="center">

**Build the landscape. Walk the route. Teach the process.**

[Open the teacher script →](Docs/TerrainClassroom.md)

</div>
