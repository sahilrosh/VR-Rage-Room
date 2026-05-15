# RageRoom

A VR destruction sandbox built with Unity. Grab objects and throw them at destructibles—objects only break on a hard impact, not a soft toss. Debris scatters with haptic feedback on Meta Quest.
## Demo
![Gameplay demo](docs/demo.gif)

## Features

- **Destructible objects** — only break when hit with enough force (a hard throw); a soft throw or gentle bump does nothing. Above the threshold, debris and particles.
- **Debris fade-out** — pieces dissolve after a short delay
- **Haptic feedback** — controller rumble scales with impact force while grabbing
- **Score tracking** — points awarded per object destroyed

## Requirements

- [Unity 2022.3.62f1](https://unity.com/releases/editor/whats-new/2022.3.62) (or compatible 2022.3 LTS)
- Meta Quest headset (OpenXR)
- Packages (via `Packages/manifest.json`):
  - Meta XR SDK (`com.meta.xr.sdk.all`)
  - XR Interaction Toolkit 2.6.5
  - OpenXR

## Getting started

1. Clone the repository.
2. Open the project folder in Unity Hub and select Unity **2022.3.62f1**.
3. Open `Assets/Scenes/SampleScene.unity`.
4. Connect your Quest via Link or build an Android APK (`File → Build Settings → Android`).

Unity will regenerate `Library/` locally; it is not committed.

## Project structure

```
RageRoom/
├── Assets/
│   ├── Scenes/
│   │   └── SampleScene.unity          # Main playable scene
│   ├── Scripts/
│   │   ├── Destructible.cs            # Break-on-impact logic (force threshold)
│   │   ├── DebrisPiece.cs             # Debris fade-out
│   │   └── HapticFeedback.cs          # Controller haptics on collision
│   ├── Basics/
│   │   ├── Pre fab/
│   │   │   └── Debris.prefab          # Debris spawned when objects break
│   │   ├── Future Scope/
│   │   │   ├── ScoreManager.cs        # Destruction score UI
│   │   │   └── ObjectRespawner.cs     # Respawn helpers (WIP)
│   │   └── materials PloyHeaven/      # PBR floor/surface textures
│   ├── Oculus/                        # Meta Quest project config
│   ├── Resources/                     # Oculus / Meta XR runtime settings
│   ├── XR/                            # OpenXR loaders and settings
│   ├── XRI/                           # XR Interaction Toolkit settings
│   └── Samples/
│       └── XR Interaction Toolkit/    # XRI starter assets & demo scene
├── Packages/
│   ├── manifest.json                  # Unity package dependencies
│   └── packages-lock.json
├── ProjectSettings/                   # Unity editor & build settings
├── docs/
│   └── demo.gif                       # README gameplay preview
├── .gitignore
└── README.md
```

Folders such as `Library/`, `Temp/`, `Logs/`, and `UserSettings/` are generated locally by Unity and are not tracked in git.

## Author

**Sahil Roshan**

## License

Add a license here if you plan to open-source the project.
