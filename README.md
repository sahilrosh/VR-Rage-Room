# RageRoom

A VR destruction sandbox built with Unity. Grab objects and throw them at destructibles—objects only break on a hard impact, not a soft toss. Debris scatters with haptic feedback on Meta Quest.

![Gameplay demo](docs/demo.gif)

## Features

- **Destructible objects** — only break when hit with enough force (a hard throw); a soft throw or gentle bump does nothing. Above the threshold, debris, particles, and 3D break sounds play
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

## Project layout

| Path | Description |
|------|-------------|
| `Assets/Scenes/` | Main scene |
| `Assets/Scripts/` | `Destructible`, `DebrisPiece`, `HapticFeedback` |
| `Assets/Basics/` | Prefabs, materials, future-scope scripts |
| `docs/demo.gif` | README gameplay preview |

## License

Add a license here if you plan to open-source the project.
