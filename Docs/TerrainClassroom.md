# Terrain workshop — quick teacher guide

**30 minutes · Beginners · Unity 6000.3.24f1**

Students create their own terrain, sculpt hills, paint surfaces and trees, then walk through it. The pond is an extension challenge.

## Before class

- Share the [student package download](https://github.com/Omar-Makhlouf/Unity-Authorized-Educator-Program-Session-2026/raw/refs/heads/main/Downloads/TerrainLab-Students.unitypackage). Students create an empty **Universal 3D (URP)** project in Unity **6000.3.24f1**, then use **Assets > Import Package > Custom Package** and import everything. No cloning needed; teacher instructions stay outside the package.
- The repository is private: students need GitHub access for the link, or you can share the `.unitypackage` file directly.
- Check **Input System** is installed and Active Input Handling is **Input System Package (New)** or **Both**. See the package's `Assets/TerrainLab/START_HERE.md` for setup help.
- Use `Assets/Scenes/TerrainFinalized.unity` to show the finished example.
- Start students in `Assets/Scenes/TerrainClassroom.unity`: it contains only the sun and player capsule. Create ground before pressing Play.
- Keep Play stopped while editing. Students create a **new Terrain**; do not assign the old `ClassroomTerrain.asset`.

## 00–03 min · Show the goal

Open **TerrainFinalized**, walk around briefly, then stop Play and open **TerrainClassroom**.

**Say:** “We will build this landscape from an empty scene. The pond is your challenge once the basics are finished.”

## 03–09 min · Create and set up the terrain

1. Choose **GameObject > 3D Object > Terrain**. Name it **Student Terrain**.
2. In **Terrain Settings**, set:

   | Setting | Value |
   | --- | --- |
   | Terrain Width / Length | 200 / 200 |
   | Terrain Height | 80 |
   | Heightmap Resolution | 513 × 513 |

3. Choose **Paint Terrain > Set Height**. Enter **20**, then click **Flatten All**.
4. Change the height to **12** and click **Flatten All** again. This is our starting ground level.
5. In the Terrain's **Transform** menu, choose **Reset**. Check Position **(0, 0, 0)**, Rotation **(0, 0, 0)**, Scale **(1, 1, 1)**.
6. Check **Classroom Player** is at **(100, 12.12, 65)**, just above the ground.

**Explain:** Terrain Height sets the available vertical range. Set Height changes the ground elevation. Transform moves the whole Terrain. Ground at 12 leaves room to dig a pond below it.

**Remember:** Flatten All erases sculpting. Use it only during initial setup, never on the finished example. Press **F** to frame the selected Terrain.

## 09–13 min · Sculpt hills

- Select **Raise or Lower Terrain**. Try a soft brush, size **20–30**, opacity **10–20**.
- Raise hills along the back and sides, leaving the front entrance and player spawn clear.
- Show **Shift + brush** to lower ground and **Smooth Height** to soften slopes.

**Student task:** make a C-shaped mountain border with a gentle walking route.

## 13–17 min · Paint surfaces

Select **Paint Texture > Edit Terrain Layers > Add Layer**. Add these existing assets:

| Layer | Location |
| --- | --- |
| Grass, then Dirt and Sand | `Assets/TerrainClassroom/Layers/` |
| Rock | `Assets/TerrainFinalized/Layers/Rock.terrainlayer` |

Grass goes first so it covers the ground. Paint a Dirt path and Rock on the hills. Use low opacity to blend; paint Grass over unwanted marks.

**Say:** “Height tools change shape. Texture painting changes appearance.”

**Student task:** paint a clear path and a rocky patch.

## 17–21 min · Add trees

1. Select **Paint Trees > Edit Trees > Add Tree**.
2. Assign `Assets/TerrainFinalized/Vegetation/ClassroomOak.prefab` and add it.
3. Select the oak thumbnail. Try brush size **15** and density **10–20**.
4. Paint small groups beside the path. Use **Shift + brush** to erase.

**Explain:** painted trees are stored in TerrainData, so they do not appear as separate Hierarchy objects.

**Student task:** paint two groups, erase a patch, and keep the route clear.

## 21–23 min · Set the challenge

**Ask:** “Can you build a pond with level water, banks above it, and a route the player can walk back out of?”

Keep the finished pond as a reference. Let students work out the construction after the core lesson or next session.

Briefly show `Assets/TerrainFinalized/Prefabs/ParkBench.prefab`: drag it into the scene to demonstrate reuse, then Undo the extra bench. Save student work before switching scenes and return to their scene afterward.

## 23–28 min · Walk and improve

Press Play and click the Game view.

**Controls:** WASD/arrows = walk · Mouse = look · Shift = sprint · Space = jump · Escape = release cursor · Click = resume · R = respawn.

**Student task:** walk the route, find one problem, stop Play, and fix it. Test again if time allows.

## 28–30 min · Save and review

Stop Play. Use **Ctrl+S**, then **File > Save Project** to save terrain asset changes too.

Ask:

- How are Terrain Height, Set Height, and Transform position different?
- What must you add before painting trees?
- What did you improve after walking through your scene?

**Done when:** students have created Terrain at the origin, sculpted hills, painted at least two surfaces, added trees, and tested a route. The pond is optional extension work.

## Quick fixes

| Problem | Fix |
| --- | --- |
| Player falls immediately | Create the Terrain first. |
| Ground is at the wrong level | Check height range **80**, Set Height **12**, Terrain position **(0, 0, 0)**. Do not flatten completed sculpting. |
| Player starts inside ground | Stop Play and move the player above the surface. |
| Controls do not respond | Click the Game view while Play is running. |
| Trees will not paint | Add the oak prefab through **Edit Trees > Add Tree**. |
| Slope is too steep | Smooth a gentler route. Press **R** if stuck. |

**Teacher-only pond hint:** lower a basin, add a flat water plane, and smooth an exit. Keep ground at the bottom; do not use Paint Holes. The reference has banks around **Y=12**, water **Y=10**, and floor **Y=3**, with no swimming system.

For project details and texture credits, see the [README](../README.md).
