# Terrain workshop: a 30-minute teacher script

**Audience:** beginners using Unity 6.
**Duration:** 30 minutes, including demonstrations and short student tasks.
**Learning goal:** sculpt a landscape, paint its surfaces and trees, explain a prefab, and explore the result with a capsule character.

## Prepare before class

Give each student a separate project copy. Open the project in Unity 6000.3.24f1. Arrange the Scene view, Game view, Hierarchy, Project window, and Inspector so students can follow your demonstrations.

Use Assets/Scenes/TerrainClassroom.unity as the student starting point and Assets/Scenes/TerrainFinalized.unity as the teacher reference. Both scenes contain a playable Classroom Player capsule. The starter is flat and has no painted trees; the finished scene contains mountains, a path, pond, bench, and 38 terrain trees.

Test both scenes before students arrive: enter Play mode, click inside the Game view, move, look around, jump, and stop Play mode. Return to the starter scene. Terrain authoring should happen outside Play mode.

The prepared controller, tree, textures, and bench keep this session focused on terrain. Students do not need to write movement code or download assets during class. For students new to Editor navigation, demonstrate the pond and bench and reserve building their own for a later lesson.

### Character controls

| Control | Action |
| --- | --- |
| W/A/S/D or arrow keys | Walk and strafe relative to the direction the player faces. |
| Mouse | Look around. |
| Left Shift | Sprint while moving. |
| Space | Jump while grounded. |
| Escape | Release the cursor and suspend horizontal movement/look. |
| Left-click the Game view | Capture the mouse again. |
| R | Return to the player's original scene spawn point. |

The player uses a CharacterController capsule, gravity, and a first-person camera at eye height. Its body is hidden from the player's camera but casts a shadow. Select Classroom Player in the Hierarchy to inspect the capsule in the Scene view. The original aerial camera is retained as a disabled Overview Camera.

## 00:00-03:00 — Introduce the goal and show the result

**Teacher says:** “Today we will turn a flat terrain into an outdoor environment. We will change the ground's height, paint its surface, paint trees, and explore our work from eye level.”

Open TerrainFinalized. From the Scene view, point to the C-shaped mountains, open entrance, grassy clearing, rocky slopes, path, trees, pond, and bench.

**Teacher says:** “Most of the ground is one Terrain object. Mountains and the pond basin come from changing its height. Texture painting changes its appearance. Trees are stored on the terrain. The bench is a separate prefab instance.”

Enter Play mode. Click the Game view, walk a few steps, look toward the mountains, and jump. Press Escape and stop Play mode.

**Ask:** “Which operation changes the shape of the ground, and which changes its appearance?”

**Expected answer:** height editing changes shape; texture painting changes appearance.

**Checkpoint:** students can distinguish shape, surface materials, and placed objects. Open TerrainClassroom for the next demonstration.

## 03:00-06:00 — Locate the tools and establish editing habits

Select Student Terrain. Show its Terrain and TerrainCollider components. Explain that TerrainData stores heights, texture paint, and painted tree positions; the collider lets the character stand on the ground.

**Teacher says:** “Edit the landscape in the Scene view while Play is stopped. Test the game in the Game view. Stop the game before returning to sculpting.”

Select the Paint Terrain brush icon and show its tool dropdown. Demonstrate right mouse plus W/A/S/D to fly the Scene camera, scrolling to adjust viewing distance, and F to frame the selected object.

**Student action:** select their terrain, find Paint Terrain, and frame the terrain. Confirm Play mode is off.

**Ask:** “If I move the Scene camera, have I moved the character?”

**Expected answer:** no; the Scene camera is an editing view.

**Checkpoint:** everyone has the terrain selected and can find the tool dropdown.

## 06:00-11:00 — Sculpt a C-shaped mountain border

Choose Raise or Lower Terrain. Start with a soft brush around 20-30 metres wide and low opacity, around 10-20. Adjust these values to how quickly the brush responds.

**Teacher says:** “Build height with several light strokes. Large brushes make broad landforms. Small brushes make sharper details. Keep one side open so our player can enter the clearing.”

Demonstrate short strokes along the back of the terrain, curving toward the left and right sides. Leave the front entrance and player spawn clear. Hold Shift while brushing to lower an over-raised patch. Choose Smooth Height to soften one steep transition.

**Student task — about three minutes:** build connected hills around a flat clearing. Leave an opening and a gentle walking route. The goal is a readable shape, not an exact copy of the reference.

Circulate. For spikes, demonstrate Undo, a larger brush, and lower opacity. If the border closes completely, lower a section to reopen it.

**Ask:** “Why might a very steep mountain be difficult for the character?”

**Expected answer:** the controller has a slope limit and cannot walk up every cliff.

**Checkpoint by 11:00:** raised border, open entrance, and flat walking space. Save scene and project assets.

## 11:00-15:00 — Paint grass, a path, and rock

Choose Paint Texture. Select Grass and paint a small patch. Switch to Dirt and begin a winding path. Show how low opacity blends the new layer with the existing ground.

**Teacher says:** “Surface paint changes the material, not the terrain's height. A dirt path suggests a route; rock suggests exposed mountain surfaces.”

The starter already contains Grass, Dirt, and Sand. Demonstrate adding a fourth existing layer using Edit Terrain Layers > Add Layer, then select Assets/TerrainFinalized/Layers/Rock.terrainlayer. No download is needed. The finished scene already contains all four layers.

**Student task — about two minutes:** paint a dirt route through the entrance and rock on part of a mountain. Keep grass in the clearing. Paint Grass back over unwanted marks.

Briefly select the Grass TerrainLayer asset. Point to the photographic color map, normal map, and green Color Tint. Explain that the normal map adds lighting detail without creating more terrain geometry. Both teaching scenes now use a greener tint; students can keep the shared settings for this exercise.

**Ask:** “Could the texture brush make a deep hole?”

**Expected answer:** no; it changes the surface material. Height tools create a basin.

**Checkpoint by 15:00:** at least two visible materials and an identifiable path.

## 15:00-19:00 — Paint and erase trees

Select Paint Trees and click the ClassroomOak thumbnail. It is already registered on both terrains. The starter intentionally begins with zero trees.

**Teacher says:** “The tree prototype tells Unity which prefab the brush should place. The terrain stores many positions, sizes, and rotations. These painted trees are not individual objects in the Hierarchy.”

Open Edit Trees > Add Tree to show the Tree Prefab field, then cancel because the prototype is already configured. Point to Assets/TerrainFinalized/Vegetation/ClassroomOak.prefab in the Project window. Explain that this tree was created locally for the project.

Use Brush Size around 15 and low Tree Density, around 10-20. Set random height around 0.8-1.2 and lock width to height. Paint two small groups. Demonstrate Shift + brush to erase an area and explain Ctrl + brush to erase only the selected species.

**Student task — about two minutes:** paint two groups beside the path, keep the walking route clear, and erase a small patch. Avoid repeated dense strokes over the same area.

**Ask:** “Why does every painted tree not appear in the Hierarchy?”

**Expected answer:** they are Terrain tree instances stored in TerrainData.

**Checkpoint by 19:00:** every student has painted trees and erased a small group.

## 19:00-23:00 — Explain the pond and bench prefab

Save student work and open TerrainFinalized for a teacher-led demonstration. Select Pond Water - Flat Plane and temporarily disable it to reveal the basin.

**Teacher says:** “This water is a flat plane. The depth comes from lowering the ground below it. The bank is above the water and the basin floor is below it.”

The finished scene has banks around Y=12, water at Y=10, and a floor around Y=3. Explain these as relative levels. This example is a depression, not a Terrain Paint Holes cutout: ground still exists at the bottom. Re-enable the plane.

If useful, demonstrate lowering a shallow practice patch, then Undo it. Explain that the starter begins around Y=5 with a 40-metre height range; it has less room for a deep basin. Students should not copy the finished scene's absolute water height onto the starter terrain.

Select Park Bench (Prefab). Show its prefab connection and the asset at Assets/TerrainFinalized/Prefabs/ParkBench.prefab. Identify seat slats, back slats, and supports. Drag a second bench into the Scene to demonstrate reuse, then Undo the extra instance.

**Teacher says:** “A prefab is a reusable object definition. A bench is a normal prefab instance. A painted tree also starts from a prefab, but the Terrain tool manages its painted copies.”

**Ask:** “What would you reuse for another bench, and what tool would you use for many trees?”

**Expected answer:** the bench prefab; Paint Trees with the tree prototype.

**Checkpoint by 23:00:** students understand the basin/plane relationship and prefab reuse. Return to the student scene.

## 23:00-28:00 — Playtest the landscape

**Teacher says:** “A landscape can look good from above but feel difficult to move through. We will check our entrance, path, slopes, and tree spacing from eye level.”

Select Classroom Player. Show the CharacterController capsule and child Player Camera. Explain that this prepared player does not need a Rigidbody.

Enter Play mode and click the Game view. Demonstrate walking, mouse look, sprinting, and jumping. Show Escape to release the cursor, clicking to resume, and R to return to spawn.

**Student task — about three minutes:** walk through the entrance, follow the path, pass between tree groups, and try a gentle slope. Identify one thing to improve.

**Teacher says:** “Stop Play mode, make one focused change, then test it again.”

Students stop, improve one issue, and retest if time permits. Do not continue sculpting during Play mode. If students raised the ground into the spawn, stop Play and move Classroom Player above the new surface before testing again. The controller remembers the player's scene position at the start of each run.

The finished pond has no water collider or swimming system. The player can descend into the basin and walk out along the gentle east-side ramp (the right side when facing the mountains from the spawn). Use R to return immediately if needed. Explain that looking like water and behaving like water are separate tasks. Walking off the terrain eventually triggers an automatic respawn below Y=-30.

**Checkpoint by 28:00:** students have used keyboard and mouse and can name one improvement prompted by playtesting.

## 28:00-30:00 — Review, save, and exit ticket

Stop Play mode. Save the scene with Ctrl+S and use File > Save Project to save terrain asset edits.

**Teacher says:** “We used height tools for shape, layers for surface appearance, tree painting for vegetation, a prefab for a reusable prop, and a capsule player to test our work.”

Ask for three short exit answers:

1. Which tool changes the ground's shape?
2. What must be assigned before Paint Trees can place a tree?
3. What did you improve after walking through your landscape?

Expected answers: a height tool such as Raise or Lower Terrain; a tree prefab/prototype; a specific improvement such as clearing a path or smoothing a slope.

**Success criteria:** an open mountain border, two or more surface materials, painted trees, and a tested walking route. Understanding the pond and bench demonstration is required; reproducing the whole finished environment is optional extension work.

## Teacher troubleshooting

| Symptom | Response |
| --- | --- |
| No keyboard/mouse response | Click inside the Game view. After Escape, click again. Check that Play is running and Classroom Player is enabled. |
| Looking is too fast | Stop Play mode and lower Mouse Sensitivity on the player's controller. |
| Player starts inside a hill | Stop Play mode and move the player above the sculpted ground. |
| Cannot climb a mountain | The slope limit is 45 degrees. Smooth a gentler route. |
| Player fell off the terrain or into the pond | Press R; falling below Y=-30 also resets the player. |
| No trees defined | Select the correct Terrain; use Edit Trees > Add Tree and assign ClassroomOak.prefab if the prototype was removed. |
| Too many trees | Lower density and Shift-brush to erase. |
| Color Variation does not affect trees | This custom oak uses ordinary URP materials without the Terrain instance-color shader property. Size and rotation variation work. |
| Only an aerial view appears when playing | Player Camera should be enabled and Overview Camera disabled. Keep one enabled camera and AudioListener. |
| A duplicated scene changes another terrain | Both may share TerrainData. Duplicate it and assign the copy to Terrain and TerrainCollider. |

## Asset and implementation reference

| Asset | Purpose |
| --- | --- |
| Assets/Player/ClassroomPlayer.prefab | Shared capsule controller and first-person camera. |
| Assets/Scripts/ClassroomFirstPersonController.cs | Movement, jump, gravity, look, cursor capture, and respawn. |
| Assets/TerrainClassroom/ClassroomTerrain.asset | Starter TerrainData: 200 x 200 metres, 513 x 513 heightmap, 40-metre height range. |
| Assets/TerrainFinalized/FinalizedTerrain.asset | Finished TerrainData: 200 x 200 metres, 80-metre height range, pond basin, four paint layers, 38 trees. |
| Assets/TerrainFinalized/Vegetation/ClassroomOak.prefab | Locally created tree: trunk collider, leaf geometry, URP materials, and three mesh LODs. No wind or distant billboard. |
| Assets/TerrainFinalized/Prefabs/ParkBench.prefab | Reusable wooden bench with iron supports and colliders. |
| Assets/TerrainFinalized/Textures/PolyHaven | Photographic surface color and normal maps shared by both scenes. |

Movement defaults: walk 5 m/s, sprint 8 m/s, jump 1.2 metres, mouse sensitivity 0.12 degrees per pixel, camera pitch limited to 85 degrees up/down. The capsule is 2 metres tall, radius 0.4 metres, with a 0.35-metre step offset. The runtime controller owns a private copy of the existing InputSystem_Actions Player map, selecting keyboard/mouse bindings without changing the source action asset. Escape, click, and R are classroom convenience controls.

The scenes have separate TerrainData assets. Duplicating only a scene does not duplicate terrain data. For independent exercises within one project, duplicate TerrainData and assign it to both Terrain and TerrainCollider. Separate project copies are simpler for class.

### Improvements to inspect in the finished example

- Follow the smoothed entrance path from spawn, then take the dirt loop around the pond. The bench sits beside the approach instead of blocking it. Four trees were relocated to keep the routes clear; the terrain still has 38 painted trees.
- Walk into the pond basin and leave using the east-side ramp. Its centreline slope is approximately 23 degrees, below the player's 45-degree slope limit. It is formed from terrain heights, with no hidden bridge or water collider.
- Grass uses a 6-metre repeat scale on both terrains. The finished clearing also blends subtle broad dirt patches into the grass to break up the repeated photographic pattern. The starter remains a clear grass surface for student painting.
- The shared oak prefab switches between near, medium, and far meshes based on screen size. Triangle counts are 12,204, 4,532, and 1,840 respectively. That reduces per-tree geometry by approximately 63% at medium distance and 85% at long distance; actual frame-rate improvement depends on the computer and view. The trunk collider and Paint Trees compatibility are retained on both terrains.

Validation used a 2-metre CharacterController capsule with the same radius, slope limit, and step settings as the player. It traversed the entrance path, the complete pond loop, and the basin exit in Play mode without jumping. This is a focused route check, not a performance benchmark or exhaustive terrain test.

### Texture credits and further reading

The photographic maps are [Leafy Grass](https://polyhaven.com/a/leafy_grass), [Brown Mud 02](https://polyhaven.com/a/brown_mud_02), [Rock Boulder Dry](https://polyhaven.com/a/rock_boulder_dry), and [Sand 01](https://polyhaven.com/a/sand_01), provided under [Poly Haven's CC0 license](https://polyhaven.com/license). They can be included in student project copies. The downloaded 2K color/OpenGL normal maps were checksum-verified. Color maps use sRGB; normal maps use Unity's Normal Map import type. Both use repeat wrapping and mipmaps. Both Grass layers have an adjustable greener Color Tint.

Unity reference: [Add trees to the terrain](https://docs.unity.com/en-us/engine/6000.3/manual/creating-environments/script-terrain/terrain-trees/terrain-trees).

